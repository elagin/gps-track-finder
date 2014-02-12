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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using System.Diagnostics;

namespace GpsTrackFinder
{
	public partial class MainForm : Form
	{
		/// <summary>
		/// Хранит настройки.</summary>
		private Settings settings = new Settings("config");	// Настройки

		public MainForm()
		{
			InitializeComponent();
			fillCtrls();
			listView1.View = View.Details;
			listView1.Columns.Add("Имя файла", 500, HorizontalAlignment.Left);
			listView1.Columns.Add("Минимальное расстояние (км.)", 160, HorizontalAlignment.Left);
		}

		/// <summary>
		/// Настраивает элементы UI.</summary>
		private void fillCtrls()
		{
			System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
			FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);

			this.Text = String.Format("GPS Track Finder v.{0}", fvi.FileVersion);

			comboBoxLat.Items.Add(new ComboItem("N", 0));
			comboBoxLat.Items.Add(new ComboItem("S", 1));

			comboBoxLon.Items.Add(new ComboItem("E",+ 0));
			comboBoxLon.Items.Add(new ComboItem("W", 1));

			// Есть минус, ставим букву и минус выкидываем
			if (settings.CentralPoint.Lat[0] == '-')
			{
				comboBoxLat.SelectedIndex = 1;
				settings.CentralPoint.Lat = settings.CentralPoint.Lat.Remove(0, 1);
				//settings.CentralPoint.Lat = settings.CentralPoint.Lat * -1;
			}
			else
				comboBoxLat.SelectedIndex = 0;

			// Есть минус, ставим букву и минус выкидываем
			if (settings.CentralPoint.Lon[0] == '-')
			{
				comboBoxLon.SelectedIndex = 1;
				settings.CentralPoint.Lon = settings.CentralPoint.Lon.Remove(0, 1);
				//settings.CentralPoint.Lon = settings.CentralPoint.Lon * -1;
			}
			else
				comboBoxLon.SelectedIndex = 0;

			textBoxLat.Text = Convert.ToString(settings.CentralPoint.Lat);
			textBoxLon.Text = Convert.ToString(settings.CentralPoint.Lon);

			textBoxFindFolder.Text = settings.SearchFolder;

			textBoxDistance.Text = settings.Distaice.ToString();
		}

		/// <summary>
		/// Сохраняет состояния элементов UI.</summary>
		private void SaveCtrls()
		{
			CultureInfo invC = CultureInfo.InvariantCulture;

			if (textBoxLat.Text.Length > 0 && textBoxLon.Text.Length > 0)
			{
				//double lat = 0;
				//double lon = 0;

				//lat = Convert.ToDouble(textBoxLat.Text, invC);
				if (comboBoxLat.SelectedIndex == 0)
					settings.CentralPoint.Lat = textBoxLat.Text;
				else
					settings.CentralPoint.Lat = "-" + textBoxLat.Text;

				//lon = Convert.ToDouble(textBoxLon.Text, invC);
				if (comboBoxLon.SelectedIndex == 0)
					settings.CentralPoint.Lon = textBoxLon.Text;
				else
					settings.CentralPoint.Lon = "-" + textBoxLon.Text;
			}
			settings.SearchFolder = textBoxFindFolder.Text;

			if (textBoxDistance.Text.Length > 0)
				settings.Distaice =	Convert.ToInt32(textBoxDistance.Text, invC);
		}

		/// <summary>
		/// Обрабатываем данные.</summary>
		private void buttonStart_Click(object sender, EventArgs e)
		{
			SaveCtrls();

			string filepath = textBoxFindFolder.Text;
			DirectoryInfo d = new DirectoryInfo(filepath);
			foreach (var file in d.GetFiles("*.plt"))
			{
				ListViewItem row = new ListViewItem(file.FullName);

				GpsPoint searchPoint = new GpsPoint(settings.CentralPoint.Lat, settings.CentralPoint.Lon);
				double dist = Drivers.ParsePlt("", searchPoint, settings.Distaice, file.FullName);

				row.SubItems.Add(String.Format("{0:N0}", dist));
				listView1.Items.Add(row);
			}
		}

		/// <summary>
		/// Отображает диалог указания папки.</summary>
		private string getFolder()
		{
			FolderBrowserDialog dlg = new FolderBrowserDialog();
			dlg.Description = "Поиск папки";
			DialogResult result = dlg.ShowDialog();
			if (result == DialogResult.OK)
				return dlg.SelectedPath;
			else
				return "";
		}

		/// <summary>
		/// Обработка нажатия кнопки смены папки поиска.</summary>
		private void buttonBrowse_Click(object sender, EventArgs e)
		{
			string newFolder = getFolder();
			if (newFolder.Length > 0)
			{
				textBoxFindFolder.Text = newFolder;
				settings.SearchFolder = newFolder;
			}
		}

		/// <summary>
		/// Подготовка к закрытию формы.</summary>
		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			SaveCtrls();
			settings.save();
		}

		private void buttonCopyPath_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedIndices.Count > 0)
			{
				try
				{
					string fileName = listView1.Items[listView1.SelectedIndices[0]].Text;
					Clipboard.SetData(DataFormats.Text, (Object)fileName);
				}
				catch (Exception ex)
				{
					string caption = "Произошла ошибка при вставке в буфер обмена";
					var result = MessageBox.Show(ex.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void buttonOpenFolder_Click(object sender, EventArgs e)
		{
			foreach (ListViewItem item in listView1.SelectedItems)
			{
				Process Proc = new Process();
				Proc.StartInfo.FileName = "explorer";
				Proc.StartInfo.Arguments = item.Text;
				Proc.Start();
				Proc.Close();
			}
		}

		private void buttonAbout_Click(object sender, EventArgs e)
		{
			using (FormAbout about = new FormAbout())
			{
				DialogResult resDlg = about.ShowDialog();
			}
		}
	}

	/// <summary>
	/// Класс для хранения элементов ComboBox.</summary>
	public class ComboItem
	{
		public string Name;
		public int Value;

		public ComboItem(string name, int value)
		{
			Name = name; Value = value;
		}

		public override string ToString()
		{
			/// <summary>
			///  Generates the text shown in the combo box.</summary>
			return Name;
		}
	}
}

