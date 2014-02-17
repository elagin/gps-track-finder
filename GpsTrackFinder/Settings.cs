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
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Xml;
using System.Reflection;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using GpsTrackFinder;

public class SettingsGpsPoint
{
	private string _lat;
	private string _lon;

	public SettingsGpsPoint()
	{
	}

	public SettingsGpsPoint(string lat, string lon)
	{
		_lat = lat.Trim();
		_lon = lon.Trim();
	}

	public string Lat
	{
		get { return _lat; }
		set { _lat = value; }
	}

	public string Lon
	{
		get { return _lon; }
		set { _lon = value; }
	}
}

public class Settings
{
	private string _filename;
	private string _searchFolder;
	private string _сopyToFilder;
	private SettingsGpsPoint _centralPoint;
	private int _dist;

	public SettingsGpsPoint CentralPoint
	{
		get { return _centralPoint; }
		set { _centralPoint = value; }
	}

	public string SearchFolder
	{
		get { return _searchFolder; }
		set { _searchFolder = value; }
	}

	public string CopyToFilder
	{
		get { return _сopyToFilder; }
		set { _сopyToFilder = value; }
	}

	public int Distaice
	{
		get { return _dist; }
		set { _dist = value; }
	}

	public Settings()
	{
	}

	public Settings(string fileName)
	{
		try
		{
			_filename = Assembly.GetExecutingAssembly().Location;// +".config";
			int start_ptr = _filename.LastIndexOf('\\');
			_filename = _filename.Substring(0, start_ptr + 1) + fileName + ".xml";
			SetDefault();
			load();
		}
		catch (Exception ex)
		{
			String logStr = "Settings Exception: " + ex.ToString();
			throw new Exception(logStr);
		}
	}

	public void load()
	{
		try
		{
			if (System.IO.File.Exists(_filename))
			{
				XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
				ns.Add("", "");

				XmlSerializer xmls = new XmlSerializer(typeof(Settings));
				using (FileStream ms = new FileStream(_filename, System.IO.FileMode.OpenOrCreate))
				{
					XmlWriterSettings settings = new XmlWriterSettings();
					using (XmlTextReader reader = new XmlTextReader(ms))
					{
						Settings Clss1 = (Settings)xmls.Deserialize(reader);
						this.CopyFrom(Clss1);
						reader.Close();
					}
				}
			}
		}
		catch (Exception ex)
		{
			string caption = "Произошла ошибка при загрузке файла настроек: " + _filename;
			var result = MessageBox.Show(ex.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}

	public void save()
	{
		try
		{
			XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
			ns.Add("", "");
			XmlSerializer xmls = new XmlSerializer(typeof(Settings));
			if (System.IO.File.Exists(_filename))
				System.IO.File.Delete(_filename);

			using (FileStream ms = new FileStream(_filename, System.IO.FileMode.OpenOrCreate))
			{
				XmlWriterSettings settings = new XmlWriterSettings();
				//settings.Encoding = Encoding.GetEncoding(1251)
				settings.Indent = true;
				using (XmlWriter writer = XmlTextWriter.Create(ms, settings))
				{
					xmls.Serialize(writer, this, ns);
					writer.Flush();
					writer.Close();
				}
				ms.Flush();
				ms.Close();
			}
		}
		catch (Exception ex)
		{
			string caption = "Произошла ошибка при сохранении файла настроек: " + _filename;
			var result = MessageBox.Show(ex.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}

	private void SetDefault()
	{
		this._searchFolder = "";
		this._сopyToFilder = "";
		this._centralPoint = new SettingsGpsPoint("1", "1");
		this._dist = 20;
	}

	private void CopyFrom(Settings Obj)
	{
		this.SearchFolder = Obj.SearchFolder;
		this.CopyToFilder = Obj.CopyToFilder;
		this.Distaice = Obj.Distaice;

		// Нового объекта может не быть в старой версии настроек
		if (Obj.CentralPoint != null)
			this.CentralPoint = Obj.CentralPoint;
	}
}


