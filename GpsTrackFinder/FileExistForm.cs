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

namespace GpsTrackFinder
{
	public partial class FileExistForm : Form
	{
		/// <summary>
		/// Результат работы формы.</summary>
		public EFileExist ReturnValue1 { get; set; }

		public FileExistForm(string fileName)
		{
			InitializeComponent();
			this.Text = "Внимание";
			textBoxFileName.Text = "Файл уже существует: " + Environment.NewLine + fileName;
		}

		private void buttonOverride_Click(object sender, EventArgs e)
		{
			if (checkBox1.CheckState == CheckState.Checked)
				ReturnValue1 = EFileExist.OverrideAll;
			else
				ReturnValue1 = EFileExist.Override;
			this.Close();
		}

		private void buttonSkip_Click(object sender, EventArgs e)
		{
			if (checkBox1.CheckState == CheckState.Checked)
				ReturnValue1 = EFileExist.SkipAll;
			else
				ReturnValue1 = EFileExist.Skip;
			this.Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			ReturnValue1 = EFileExist.Cancel;
			this.Close();
		}

		private void FileExistForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			ReturnValue1 = EFileExist.Cancel;
		}
	}
}
