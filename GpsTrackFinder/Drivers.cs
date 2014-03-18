/*
 * GPS Track Finder. Find gps tracks near point 
 * Copyright © 2014 Pavel Elagin elagin.pasha@gmail.com

 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.

 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU General Public License for more details.

 * You should have received a copy of the GNU General Public License
 * along with this program. If not, see <www.gnu.org/licenses/>
 * 
 * Source code: https://github.com/elagin/gps-track-finder
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Globalization;
using System.Diagnostics;
using System.ComponentModel;
using System.Data;

namespace GpsTrackFinder
{
	enum State { grad, min, sec, end };

	public class TrackStat
	{
		private double _length;
		private double _minDist;
		private int _points;
		private string _fileName;

		public string FileName
		{
			get { return _fileName; }
			set { _fileName = value; }
		}

		public double Length
		{
			get { return _length; }
			set { _length = value; }
		}

		public double MinDist
		{
			get { return _minDist; }
			set { _minDist = value; }
		}

		public int Points
		{
			get { return _points; }
			set { _points = value; }
		}

	}

	/// <summary>
	/// Класс для хранения географической координаты.</summary>
	public class GpsPoint
	{
		private double _lat;
		private double _lon;

		public GpsPoint(GpsPoint ob)
		{
			this._lat = ob._lat;
			this._lon = ob._lon;
		}

		public GpsPoint()
		{
		}

		public GpsPoint(double lat, double lon)
		{
			_lat = lat;
			_lon = lon;
		}

		public GpsPoint(string lat, string lon)
		{
			lat = lat.Trim();
			lon = lon.Trim();

			CultureInfo invC = CultureInfo.InvariantCulture;
			_lat = Convert.ToDouble(lat, invC);
			_lon = Convert.ToDouble(lon, invC);
		}

		public double Lat
		{
			get { return _lat; }
			set { _lat = value; }
		}

		public double Lon
		{
			get { return _lon; }
			set { _lon = value; }
		}
	}
	
	class Drivers
	{
		/// <summary>
		/// Расчет расстояния (в метрах) между двумя географическими координатами.</summary>
		// http://gis-lab.info/qa/great-circles.html
		public static double calcDist(GpsPoint first, GpsPoint second)
		{
			//rad - радиус сферы (Земли)
			int rad = 6372795;
			//в радианах
			double lat1 = first.Lat * Math.PI / 180;
			double lat2 = second.Lat * Math.PI / 180;
			double long1 = first.Lon * Math.PI / 180;
			double long2 = second.Lon * Math.PI / 180;

			//косинусы и синусы широт и разницы долгот
			double cl1 = Math.Cos(lat1);
			double cl2 = Math.Cos(lat2);
			double sl1 = Math.Sin(lat1);
			double sl2 = Math.Sin(lat2);
			double delta = long2 - long1;
			double cdelta = Math.Cos(delta);
			double sdelta = Math.Sin(delta);

			//вычисления длины большого круга
			double y = Math.Sqrt(Math.Pow(cl2 * sdelta, 2) + Math.Pow(cl1 * sl2 - sl1 * cl2 * cdelta, 2));
			double x = sl1 * sl2 + cl1 * cl2 * cdelta;
			double ad = Math.Atan2(y, x);
			double dist = ad * rad;
			return dist;
		}

		/// <summary>
		/// Парсинг PLT-файла.</summary>
		public static TrackStat ParsePlt(int aDist, string fileName, List<GpsPoint> points)
		{
			GpsPoint prevPoint = null;
			TrackStat stat = new TrackStat();

			try
			{
				using (StreamReader file = new StreamReader(fileName))
				{
					double MinDist = double.MaxValue;
					int lineNumber = 6;

					for (int i = 0; i < 6; i++)		// Пропускаем заголовок
						file.ReadLine();

					while (!file.EndOfStream)
					{
						string line = file.ReadLine();
						if (line.Length > 0)
						{
							try
							{
								string[] split = line.Split(',');
								GpsPoint tmp = new GpsPoint(split[0], split[1]);
								if (prevPoint != null)
								{
									stat.Length += calcDist(prevPoint, tmp);
									prevPoint = tmp;
								}
								else
									prevPoint = tmp;

								stat.Points++;

								foreach (GpsPoint item in points)
								{
									double dist = calcDist(item, tmp);
									if (MinDist > dist)
										MinDist = dist;
								}
							}
							catch (Exception ex)
							{
								string caption = "Произошла ошибка при работе с файлом.";
								var result = MessageBox.Show(fileName + "\r\n" + "в строке: " + Convert.ToString(lineNumber) + "\r\n" + ex.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
							}
						}
						lineNumber++;
					}
					if (MinDist < double.MaxValue)
						stat.MinDist = MinDist;
					stat.FileName = fileName;
				}
			}
			catch (Exception ex)
			{
				string caption = "Произошла ошибка при работе с файлом.";
				var result = MessageBox.Show(fileName + "\r\n" + ex.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			return stat;
		}

		/// <summary>
		/// Парсинг WPT-файла.</summary>
		public static List<GpsPoint> ParseWpt(string fileName)
		{
			List<GpsPoint> res = new List<GpsPoint>();

			if (fileName.Length == 0)
			{
				return res;
			}

			try
			{
				using (StreamReader file = new StreamReader(fileName))
				{
					double MinDist = double.MaxValue;
					int lineNumber = 6;

					for (int i = 0; i < 4; i++)		// Пропускаем заголовок
						file.ReadLine();

					while (!file.EndOfStream)
					{
						string line = file.ReadLine();
						if (line.Length > 0)
						{
							try
							{
								string[] split = line.Split(',');
								GpsPoint tmp = new GpsPoint(split[2], split[3]);
								res.Add(tmp);
							}
							catch (Exception ex)
							{
								string caption = "Произошла ошибка при работе с файлом.";
								var result = MessageBox.Show(fileName + "\r\n" + "в строке: " + Convert.ToString(lineNumber) + "\r\n" + ex.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				string caption = "Произошла ошибка при работе с файлом.";
				var result = MessageBox.Show(fileName + "\r\n" + ex.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			return res;
		}

		/// <summary>
		/// Приводит координату любого формата к градусам.<summary>
		public static double getDeg(string value)
		{
			double res = 0;
			try
			{
				State state = State.grad;
				int res_grad = 0;
				double res_min = 0;
				double res_sec = 0;
				int start = 0;
				string tmp = "";
				int tmpSize = 0;
				int mul = 1;
				Char separator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0];

				if (value[0] == '-')
				{
					value = value.Remove(0, 1);
					mul = -1;
				}

				for (int i = 0; i < value.Length; i++)
				{
					if (!Char.IsDigit(value[i]) || i == value.Length - 1)
					{
						if (i != value.Length - 1)
							tmpSize = i - start;
						else
							tmpSize = i - start + 1;

						switch (state)
						{
							case State.grad:
								if (value[i].CompareTo('.') == 0 || value[i].CompareTo(',') == 0)
								{
									tmp = value.Substring(start, value.Length - start);
									res = Convert.ToDouble(tmp.Replace('.', separator));
									return res;
								}
								else
								{
									tmp = value.Substring(start, tmpSize);
									res_grad = Convert.ToInt32(tmp);
									state = State.min;
								}
								break;
							case State.min:
								if (value[i].CompareTo('.') == 0 || value[i].CompareTo(',') == 0)
								{
									tmp = value.Substring(start, value.Length - start);
									state = State.end;
								}
								else
								{
									tmp = value.Substring(start, tmpSize);
									state = State.sec;
								}
								res_min = Convert.ToDouble(tmp.Replace('.', separator));
								break;
							case State.sec:
								tmp = value.Substring(start, value.Length - start);
								res_sec = Convert.ToDouble(tmp);
								state = State.end;
								break;
						}
						start = i + 1;
					}
				}
				double sec = res_sec / 60;
				double min = (res_min + sec) / 60;
				res = (res_grad + min) * mul;
				return res;
			}
			catch (Exception ex)
			{
				string caption = "Произошла ошибка при преобразовании координаты: " + value + ". Пожалуйста, проверьте формат.";
				var result = MessageBox.Show(ex.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return 0;
			}
		}
	}
}
