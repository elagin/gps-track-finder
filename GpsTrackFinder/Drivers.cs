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
using System.Xml;

namespace GpsTrackFinder
{
	enum State { grad, min, sec, end };
	enum CorrectMode { none, maxSpeed, divideByDay, divideByMonth, divideBySegment, regularizeByTime };

	/// <summary>
	/// Базовый класс для хранения строк трека.<summary>
	abstract class ParseBase
	{

		/// <summary>
		/// Список для хранения заголовка трека.<summary>
		protected List<string> _headers;

		public abstract void Clear();
		public abstract int Count();
		public abstract void addPoint(string point);
		public abstract List<string> getPoints();

		public List<string> Headers
		{
			get { return _headers; }
			set { _headers = value; }
		}

		public void addHeader(string str)
		{
			_headers.Add(str);
		}
	}

	/// <summary>
	/// Класс для хранения строк трека сортированными по времени.<summary>
	class ParcedDataSortable : ParseBase
	{
		private SortedDictionary<DateTime, string> _points;

		public ParcedDataSortable()
		{
			_headers = new List<string>();
			_points = new SortedDictionary<DateTime, string>();
		}

		public override void Clear()
		{
			_points.Clear();
		}

		public override int Count()
		{
			return _points.Count;
		}

		public override void addPoint(string point)
		{
			string[] split = point.Split(',');
			DateTime date = Drivers.ConvertToDate(split[4]);
			try
			{
				_points.Add(date, point);
			}
			catch (ArgumentException)
			{
				//Элемент уже присутствует, откидываем.
			}
		}

		public override List<string> getPoints()
		{
			List<string> res = new List<string>();
			foreach (KeyValuePair<DateTime, string> pair in _points)
			{
				res.Add(pair.Value);
			}
			return res;
		}
	}

	/// <summary>
	/// Класс для хранения строк трека.<summary>
	class ParcedData : ParseBase
	{
		private List<string> _points;

		public ParcedData()
		{
			_points = new List<string>();
			_headers = new List<string>();
		}

		public override void Clear()
		{
			_points.Clear();
		}

		public override int Count()
		{
			return _points.Count;
		}

		public override void addPoint(string point)
		{
			_points.Add(point);
		}

		public override List<string> getPoints()
		{
			return _points;
		}
	}

	/// <summary>
	/// Хранит статистику по файлу.</summary>
	public class TrackStat
	{
		private double _length;
		private double _minDist;
		private int _points;
		private string _fileName;
		private double _maxSpeed;

		public string FileName
		{
			get { return _fileName; }
			set { _fileName = value; }
		}

		/// <summary>
		/// Общая длина трека (м.)</summary>
		public double Length
		{
			get { return _length; }
			set { _length = value; }
		}

		/// <summary>
		/// Минимальное расстояние до трека (м.)</summary>
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

		/// <summary>
		/// Максимальная скорость (км.ч.)</summary>
		public double MaxSpeed
		{
			get { return _maxSpeed; }
			set { _maxSpeed = value; }
		}
	}

	/// <summary>
	/// Класс для хранения географической координаты.</summary>
	public class GpsPoint
	{
		private double _lat;
		private double _lon;
		private DateTime _date;
		private int _speed;
		private string _line;

		public GpsPoint(GpsPoint ob)
		{
			this._lat = ob._lat;
			this._lon = ob._lon;
			this._date = ob._date;
		}

		public GpsPoint() { }

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

		public GpsPoint(string lat, string lon, string date)
		{
			lat = lat.Trim();
			lon = lon.Trim();

			CultureInfo invC = CultureInfo.InvariantCulture;
			_lat = Convert.ToDouble(lat, invC);
			_lon = Convert.ToDouble(lon, invC);
			if (date != null && date.Length > 0)
				_date = Drivers.ConvertToDate(date);
		}

		public GpsPoint(string lat, string lon, string date, string line)
		{
			lat = lat.Trim();
			lon = lon.Trim();

			CultureInfo invC = CultureInfo.InvariantCulture;
			_lat = Convert.ToDouble(lat, invC);
			_lon = Convert.ToDouble(lon, invC);
			if (date != null && date.Length > 0)
				_date = Drivers.ConvertToDate(date);

			_line = line;
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

		public DateTime Date
		{
			get { return _date; }
			set { _date = value; }
		}

		public int Speed
		{
			get { return _speed; }
			set { _speed = value; }
		}

		public string Line
		{
			get { return _line; }
			set { _line = value; }
		}
	}

	class Drivers
	{
		private static int fileSegment = 0;

		/// <summary>
		/// Извлечение даты из Delphi формата.</summary>
		public static DateTime ConvertToDate(string date)
		{
			date = date.Replace(".", ",");
			double time = Convert.ToDouble(date);
			return DateTime.FromOADate(time);
		}

		/// <summary>
		/// Расчет расстояния (в метрах) между двумя географическими координатами.</summary>
		// http://gis-lab.info/qa/great-circles.html
		public static double calcDist(GpsPoint first, GpsPoint second)
		{
			// Иначе расстояние будет 30 000 км.
			if (first.Lon == second.Lon && first.Lat == second.Lat)
				return 0;
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
		/// Парсинг GPX-файла.</summary>
		public static TrackStat ParseGpx(int aDist, string fileName, List<GpsPoint> points)
		{
			GpsPoint prevPoint = null;
			TrackStat res = new TrackStat();
			res.FileName = fileName;

			try
			{
				using (FileStream fs = new FileStream(fileName, FileMode.Open))
				{
					using (XmlReader tr = XmlReader.Create(fs))
					{
						string lat = "";
						string lon = "";

						double MinDist = double.MaxValue;
						while (tr.Read())
						{
							if (tr.NodeType == XmlNodeType.EndElement && tr.Name == "trkpt")
							{
								GpsPoint tmp = new GpsPoint(lat, lon);
								if (prevPoint != null)
								{
									res.Length += calcDist(prevPoint, tmp);
								}
								prevPoint = tmp;
								res.Points++;
								foreach (GpsPoint item in points)
								{
									double dist = calcDist(item, tmp);
									if (MinDist > dist)
										MinDist = dist;
								}
							}

							if (tr.NodeType == XmlNodeType.Element)
							{
								if (tr.Name == "trkpt")
								{
									lat = tr.GetAttribute("lat");
									lon = tr.GetAttribute("lon");

									GpsPoint tmp = new GpsPoint(tr.GetAttribute("lat"), tr.GetAttribute("lon"), "0");
									if (prevPoint != null)
									{
										res.Length += calcDist(prevPoint, tmp);
									}
									prevPoint = tmp;
									res.Points++;
									foreach (GpsPoint item in points)
									{
										double dist = calcDist(item, tmp);
										if (MinDist > dist)
											MinDist = dist;
									}
								}
								else if (tr.Name == "speed")
								{
									double speed = tr.ReadElementContentAsDouble();
									if (res.MaxSpeed < speed)
										res.MaxSpeed = speed;
								}
							}
						}
						if (MinDist < double.MaxValue)
							res.MinDist = MinDist;
					}
				}
			}
			catch (Exception ex)
			{
				string caption = "Произошла ошибка при работе с файлом.";
				MessageBox.Show(fileName + "\r\n" + ex.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			return res;
		}

		// http://www.realbiker.ru/OziExplorer/fileformats.shtml
		/// <summary>
		/// Исправление PLT-файла.</summary>
		public static void CorrectPlt(string fileName, ParseBase data, bool saveBackup, CorrectMode mode, DateTime lastDate)
		{
			try
			{
				if ((mode == CorrectMode.maxSpeed && saveBackup) || mode == CorrectMode.regularizeByTime)
				{
					string backupName = fileName.Insert(fileName.LastIndexOf(".plt"), "_backup_");
					System.IO.File.Move(fileName, backupName);
				}
				else if (mode == CorrectMode.divideByMonth)
				{
					fileName = fileName.Insert(fileName.LastIndexOf(".plt"), lastDate.ToString("-yyyy-MM"));
				}
				else if (mode == CorrectMode.divideByDay)
				{
					fileName = fileName.Insert(fileName.LastIndexOf(".plt"), lastDate.ToString("-yyyy-MM-dd"));
				}
				else if (mode == CorrectMode.divideBySegment)
				{
					fileName = fileName.Insert(fileName.LastIndexOf(".plt"), lastDate.ToString("-yyyy-MM-dd-") + fileSegment.ToString());
					fileSegment++;
				}

				using (StreamWriter file = new StreamWriter(fileName, false, Encoding.GetEncoding("Windows-1251")))
				{
					foreach (string line in data.Headers)
					{
						file.WriteLine(line);
					}

					foreach (string line in data.getPoints())
					{
						file.WriteLine(line);
					}
				}
			}
			catch (Exception ex)
			{
				string caption = "Произошла ошибка при корректировке файла.";
				MessageBox.Show(fileName + "\r\n" + ex.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		// http://www.realbiker.ru/OziExplorer/fileformats.shtml
		/// <summary>
		/// Парсинг PLT-файла.</summary>
		public static TrackStat ParsePlt(int aDist, string fileName, List<GpsPoint> points, ref Settings settings, bool needCorrect)
		{
			GpsPoint prevPos = null;
			TrackStat res = new TrackStat();
			CCorrect correct = settings.Correct;
			CorrectMode mode = new CorrectMode();
			ParseBase parcedData = null;

			try
			{
				using (StreamReader fileRead = new StreamReader(fileName, Encoding.GetEncoding("Windows-1251")))
				{
					if (needCorrect)
					{
						fileSegment = 0;
						if (correct.ApplyFilters && correct.ApplyMaxSpeedFilter && correct.MaxSpeedFilter > 0)
						{
							mode = CorrectMode.maxSpeed;
						}
						else if (settings.Correct.ApplyDivideBy)
						{
							switch (settings.Correct.DivideBy)
							{
								case 0:
									mode = CorrectMode.divideByMonth;
									break;
								case 1:
									mode = CorrectMode.divideByDay;
									break;
								case 2:
									mode = CorrectMode.divideBySegment;
									break;
							}
						}
						else if(settings.Correct.RegularizeByTime)
						{
							mode = CorrectMode.regularizeByTime;
						}

						if (mode == CorrectMode.regularizeByTime)
						{
							parcedData = new ParcedDataSortable();
						}
						else
						{
							parcedData = new ParcedData();
						}
					}

					double MinDist = double.MaxValue;
					for (int i = 0; i < 6; i++)		// Пропускаем заголовок
					{
						string header = fileRead.ReadLine();
						if (mode != CorrectMode.none)
							parcedData.addHeader(header);
					}

					while (!fileRead.EndOfStream)
					{
						string line = fileRead.ReadLine();
						if (line.Length > 0)
						{
							string[] split = line.Split(',');
							GpsPoint currentPos = new GpsPoint(split[0], split[1], split[4]);

							// Начало нового сегмента, вероятно нужно сохранить предидущий
							if (split[2] == "1")
							{
								if (needCorrect && prevPos != null)
								{
									if (mode == CorrectMode.divideByMonth && prevPos.Date.Month != currentPos.Date.Month)
									{
										CorrectPlt(fileName, parcedData, correct.SaveBackup, mode, prevPos.Date);
										parcedData.Clear();
									}
									else if (mode == CorrectMode.divideByDay && prevPos.Date.Day != currentPos.Date.Day)
									{
										CorrectPlt(fileName, parcedData, correct.SaveBackup, mode, prevPos.Date);
										parcedData.Clear();
									}
									else if (mode == CorrectMode.divideBySegment)
									{
										CorrectPlt(fileName, parcedData, correct.SaveBackup, mode, prevPos.Date);
										parcedData.Clear();
									}
								}
								else
								{
									prevPos = null;
								}
							}

							if (prevPos != null)
							{
								if (mode == CorrectMode.divideByMonth ||
									mode == CorrectMode.divideByDay ||
									mode == CorrectMode.divideBySegment ||
									mode == CorrectMode.regularizeByTime)
								{
									parcedData.addPoint(line);
								}
								else
								{
									double dist = calcDist(prevPos, currentPos);
									res.Length += dist;
									TimeSpan delta = currentPos.Date - prevPos.Date;
									if (delta.TotalSeconds > 0) // Почему-то бывает и так
									{
										double speed = dist / delta.TotalSeconds * 3.6;
										if ((mode == CorrectMode.maxSpeed && correct.MaxSpeedFilter > speed))
										{
											parcedData.addPoint(line);
										}
										if (res.MaxSpeed < speed)
											res.MaxSpeed = speed;
									}
								}
							}
							else if (mode != CorrectMode.none)
							{
								parcedData.addPoint(line);
							}
							prevPos = currentPos;
							res.Points++;

							if (points != null)
							{
								foreach (GpsPoint item in points)
								{
									double dist = calcDist(item, currentPos);
									if (MinDist > dist)
										MinDist = dist;
								}
							}
						}
					}
					if (MinDist < double.MaxValue)
						res.MinDist = MinDist;
					res.FileName = fileName;
				}
				if (parcedData != null && parcedData.Count() > 0)
					CorrectPlt(fileName, parcedData, correct.SaveBackup, mode, prevPos.Date);
			}
			catch (Exception ex)
			{
				string caption = "Произошла ошибка при работе с файлом.";
				MessageBox.Show(fileName + "\r\n" + ex.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			return res;
		}

		/// <summary>
		/// Парсинг WPT-файла.</summary>
		public static void ParseWpt(string fileName, ref List<GpsPoint> res)
		{
			if (fileName.Length > 0)
			{
				try
				{
					using (StreamReader file = new StreamReader(fileName))
					{
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
			}
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
				Char separator = CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0];

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
								tmp = value.Substring(start, value.Length - start).Replace('.', separator);
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
				String logStr = "Произошла ошибка при преобразовании координаты: " + value + ". Пожалуйста, проверьте формат.";
				throw new Exception(logStr);
			}
		}
	}
}
