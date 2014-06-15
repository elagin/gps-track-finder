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
	public partial class CorrectForm : Form
	{
		private Settings settings = new Settings();

		public CorrectForm(ref Settings aSettings)
		{
			InitializeComponent();
			settings = aSettings;

			if (settings.Correct.ApplyFilters)
			{
				checkBoxFilterEnable.CheckState = CheckState.Checked;
				groupBoxFilter.Enabled = true;
			}
			if (settings.Correct.ApplyMaxSpeedFilter)
				checkBoxMaxSpeed.CheckState = CheckState.Checked;
			textBoxMaxSpeed.Text = Convert.ToString(settings.Correct.MaxSpeedFilter);

			if (settings.Correct.SaveBackup)
				checkBoxBackup.CheckState = CheckState.Checked;

			if (settings.Correct.ApplyDivideBy)
			{
				checkBoxDivideEnable.CheckState = CheckState.Checked;
				groupBoxDivide.Enabled = true;
			}
			comboBoxDivide.SelectedIndex = settings.Correct.DivideBy;

			if (settings.Correct.RegularizeByTime)
			{
				checkBoxRegularizeByTime.CheckState = CheckState.Checked;
				groupBoxRegularizeByTime.Enabled = true;
			}
		}

		private void buttonStart_Click(object sender, EventArgs e)
		{
			if (checkBoxFilterEnable.CheckState == CheckState.Unchecked && 
				checkBoxDivideEnable.CheckState == CheckState.Unchecked &&
				checkBoxRegularizeByTime.CheckState == CheckState.Unchecked)
			{
				string msg = "Вы не выбрали не один из способов обработки трека\r\nВернуться обратно?";
				string caption = "Внимание";
				var result = MessageBox.Show(msg, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
				if (result == System.Windows.Forms.DialogResult.No)
				{
					this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
					this.Close();
				}
			}
			else
			{
				settings.Correct.ApplyFilters = checkBoxFilterEnable.CheckState == CheckState.Checked;
				settings.Correct.ApplyMaxSpeedFilter = checkBoxMaxSpeed.CheckState == CheckState.Checked;
				settings.Correct.MaxSpeedFilter = Convert.ToInt32(textBoxMaxSpeed.Text);
				settings.Correct.SaveBackup = checkBoxBackup.CheckState == CheckState.Checked;

				settings.Correct.ApplyDivideBy = checkBoxDivideEnable.CheckState == CheckState.Checked;
				settings.Correct.DivideBy = comboBoxDivide.SelectedIndex;

				settings.Correct.RegularizeByTime = checkBoxRegularizeByTime.CheckState == CheckState.Checked;

				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}

		private void buttonClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void checkBoxDivideEnable_Click(object sender, EventArgs e)
		{
			if (checkBoxDivideEnable.CheckState == CheckState.Checked)
			{
				groupBoxFilter.Enabled = false;
				groupBoxRegularizeByTime.Enabled = false;
				groupBoxDivide.Enabled = true;
				checkBoxFilterEnable.CheckState = CheckState.Unchecked;
				checkBoxRegularizeByTime.CheckState = CheckState.Unchecked;
			}
			else
			{
				groupBoxDivide.Enabled = false;
			}
			checkOkButton();
		}

		private void checkBoxFilterEnable_Click(object sender, EventArgs e)
		{
			if (checkBoxFilterEnable.CheckState == CheckState.Checked)
			{
				groupBoxDivide.Enabled = false;
				groupBoxRegularizeByTime.Enabled = false;
				groupBoxFilter.Enabled = true;
				checkBoxDivideEnable.CheckState = CheckState.Unchecked;
				checkBoxRegularizeByTime.CheckState = CheckState.Unchecked;
			}
			else
			{
				groupBoxFilter.Enabled = false;
			}
			checkOkButton();
		}

		private void checkBoxRegularizeByTime_Click(object sender, EventArgs e)
		{
			if (checkBoxRegularizeByTime.CheckState == CheckState.Checked)
			{
				groupBoxFilter.Enabled = false;
				groupBoxDivide.Enabled = false;
				groupBoxRegularizeByTime.Enabled = true;
				checkBoxFilterEnable.CheckState = CheckState.Unchecked;
				checkBoxDivideEnable.CheckState = CheckState.Unchecked;
			}
			else
			{
				groupBoxRegularizeByTime.Enabled = false;
			}
			checkOkButton();
		}

		/// <summary>
		/// Проверяет доступность кнопки buttonStart.</summary>
		private void checkOkButton()
		{
			buttonStart.Enabled = (checkBoxDivideEnable.CheckState == CheckState.Checked ||
		checkBoxRegularizeByTime.CheckState == CheckState.Checked ||
			checkBoxFilterEnable.CheckState == CheckState.Checked);
		}
	}
}
