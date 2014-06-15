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

public class CCorrect
{
	private bool _applyFilters;
	private bool _applyMaxSpeedFilter;
	private int _maxSpeedFilter;
	private bool _saveBackup;
	private bool _applyDivideBy;
	private int _divideBy;
	private bool _regularizeByTime;

	public CCorrect()
	{ }

	public bool ApplyFilters
	{
		get { return _applyFilters; }
		set { _applyFilters = value; }
	}

	public bool ApplyMaxSpeedFilter
	{
		get { return _applyMaxSpeedFilter; }
		set { _applyMaxSpeedFilter = value; }
	}

	public int MaxSpeedFilter
	{
		get { return _maxSpeedFilter; }
		set { _maxSpeedFilter = value; }
	}

	public bool SaveBackup
	{
		get { return _saveBackup; }
		set { _saveBackup = value; }
	}

	public bool ApplyDivideBy
	{
		get { return _applyDivideBy; }
		set { _applyDivideBy = value; }
	}

	public int DivideBy
	{
		get { return _divideBy; }
		set { _divideBy = value; }
	}

	public bool RegularizeByTime
	{
		get { return _regularizeByTime; }
		set { _regularizeByTime = value; }
	}

}

public class Settings
{
	private string _filename;
	private string _searchFolder;
	private string _сopyToFilder;
	private string _wptFileName;
	private SettingsGpsPoint _centralPoint;
	private int _dist;
	private bool _searchSubFolder;
	private bool _searchByPos;
	private bool _searchByWpt;
	private CCorrect _correct;

	public CCorrect Correct
	{
		get { return _correct; }
		set { _correct = value; }
	}

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

	public string WptFileName
	{
		get { return _wptFileName; }
		set { _wptFileName = value; }
	}

	public int Distaice
	{
		get { return _dist; }
		set { _dist = value; }
	}

	public bool SearchSubFolder
	{
		get { return _searchSubFolder; }
		set { _searchSubFolder = value; }
	}

	public bool SearchByPos
	{
		get { return _searchByPos; }
		set { _searchByPos = value; }
	}

	public bool SearchByWpt
	{
		get { return _searchByWpt; }
		set { _searchByWpt = value; }
	}

	public Settings()
	{
		;
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
		this.Correct = new CCorrect();
		this.Correct.MaxSpeedFilter = 120;
		this.Correct.SaveBackup = true;
		this.Correct.ApplyFilters = false;
		this.Correct.ApplyMaxSpeedFilter = false;
		this.Correct.ApplyDivideBy = false;
		this.Correct.DivideBy = 0;
		this.Correct.RegularizeByTime = false;
	}

	private void CopyFrom(Settings Obj)
	{
		this.SearchFolder = Obj.SearchFolder;
		this.Distaice = Obj.Distaice;

		// Нового объекта может не быть в старой версии настроек
		if (Obj.CentralPoint != null)
			this.CentralPoint = Obj.CentralPoint;
		if (Obj.CopyToFilder != null)
			this.CopyToFilder = Obj.CopyToFilder;
		if (Obj.WptFileName != null)
			this.WptFileName = Obj.WptFileName;
		this.SearchSubFolder = Obj.SearchSubFolder;
		this.SearchByPos = Obj.SearchByPos;
		this.SearchByWpt = Obj.SearchByWpt;

		if (Obj.Correct != null)
		{
			this.Correct = Obj.Correct;
			this.Correct.MaxSpeedFilter = Obj.Correct.MaxSpeedFilter;
			this.Correct.SaveBackup = Obj.Correct.SaveBackup;
			this.Correct.ApplyMaxSpeedFilter = Obj.Correct.ApplyMaxSpeedFilter;
			this.Correct.ApplyFilters = Obj.Correct.ApplyFilters;
			this.Correct.ApplyDivideBy = Obj.Correct.ApplyDivideBy;
			this.Correct.DivideBy = Obj.Correct.DivideBy;
			this.Correct.RegularizeByTime = Obj.Correct.RegularizeByTime;
		}
	}
}


