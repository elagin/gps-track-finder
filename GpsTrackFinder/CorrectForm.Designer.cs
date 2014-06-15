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
namespace GpsTrackFinder
{
	partial class CorrectForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.buttonStart = new System.Windows.Forms.Button();
			this.textBoxMaxSpeed = new System.Windows.Forms.TextBox();
			this.checkBoxMaxSpeed = new System.Windows.Forms.CheckBox();
			this.buttonClose = new System.Windows.Forms.Button();
			this.checkBoxBackup = new System.Windows.Forms.CheckBox();
			this.groupBoxFilter = new System.Windows.Forms.GroupBox();
			this.checkBoxFilterEnable = new System.Windows.Forms.CheckBox();
			this.groupBoxDivide = new System.Windows.Forms.GroupBox();
			this.comboBoxDivide = new System.Windows.Forms.ComboBox();
			this.checkBoxDivideEnable = new System.Windows.Forms.CheckBox();
			this.groupBoxRegularizeByTime = new System.Windows.Forms.GroupBox();
			this.checkBoxRegularizeByTime = new System.Windows.Forms.CheckBox();
			this.groupBoxFilter.SuspendLayout();
			this.groupBoxDivide.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonStart
			// 
			this.buttonStart.Location = new System.Drawing.Point(194, 163);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(75, 23);
			this.buttonStart.TabIndex = 3;
			this.buttonStart.Text = "Старт";
			this.buttonStart.UseVisualStyleBackColor = true;
			this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
			// 
			// textBoxMaxSpeed
			// 
			this.textBoxMaxSpeed.Location = new System.Drawing.Point(5, 22);
			this.textBoxMaxSpeed.Name = "textBoxMaxSpeed";
			this.textBoxMaxSpeed.Size = new System.Drawing.Size(31, 20);
			this.textBoxMaxSpeed.TabIndex = 0;
			this.textBoxMaxSpeed.Text = "0";
			// 
			// checkBoxMaxSpeed
			// 
			this.checkBoxMaxSpeed.AutoSize = true;
			this.checkBoxMaxSpeed.Location = new System.Drawing.Point(42, 25);
			this.checkBoxMaxSpeed.Name = "checkBoxMaxSpeed";
			this.checkBoxMaxSpeed.Size = new System.Drawing.Size(153, 17);
			this.checkBoxMaxSpeed.TabIndex = 1;
			this.checkBoxMaxSpeed.Text = "Максимальная скорость";
			this.checkBoxMaxSpeed.UseVisualStyleBackColor = true;
			// 
			// buttonClose
			// 
			this.buttonClose.Location = new System.Drawing.Point(331, 163);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(75, 23);
			this.buttonClose.TabIndex = 4;
			this.buttonClose.Text = "Отмена";
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
			// 
			// checkBoxBackup
			// 
			this.checkBoxBackup.AutoSize = true;
			this.checkBoxBackup.Location = new System.Drawing.Point(194, 128);
			this.checkBoxBackup.Name = "checkBoxBackup";
			this.checkBoxBackup.Size = new System.Drawing.Size(212, 17);
			this.checkBoxBackup.TabIndex = 2;
			this.checkBoxBackup.Text = "Сохранять резервные копии файлов";
			this.checkBoxBackup.UseVisualStyleBackColor = true;
			// 
			// groupBoxFilter
			// 
			this.groupBoxFilter.Controls.Add(this.textBoxMaxSpeed);
			this.groupBoxFilter.Controls.Add(this.checkBoxMaxSpeed);
			this.groupBoxFilter.Enabled = false;
			this.groupBoxFilter.Location = new System.Drawing.Point(12, 11);
			this.groupBoxFilter.Name = "groupBoxFilter";
			this.groupBoxFilter.Size = new System.Drawing.Size(225, 76);
			this.groupBoxFilter.TabIndex = 5;
			this.groupBoxFilter.TabStop = false;
			this.groupBoxFilter.Text = "Фильтр";
			// 
			// checkBoxFilterEnable
			// 
			this.checkBoxFilterEnable.AutoSize = true;
			this.checkBoxFilterEnable.Location = new System.Drawing.Point(12, 93);
			this.checkBoxFilterEnable.Name = "checkBoxFilterEnable";
			this.checkBoxFilterEnable.Size = new System.Drawing.Size(99, 17);
			this.checkBoxFilterEnable.TabIndex = 5;
			this.checkBoxFilterEnable.Text = "Использовать";
			this.checkBoxFilterEnable.UseVisualStyleBackColor = true;
			this.checkBoxFilterEnable.Click += new System.EventHandler(this.checkBoxFilterEnable_Click);
			// 
			// groupBoxDivide
			// 
			this.groupBoxDivide.Controls.Add(this.comboBoxDivide);
			this.groupBoxDivide.Enabled = false;
			this.groupBoxDivide.Location = new System.Drawing.Point(255, 11);
			this.groupBoxDivide.Name = "groupBoxDivide";
			this.groupBoxDivide.Size = new System.Drawing.Size(146, 76);
			this.groupBoxDivide.TabIndex = 6;
			this.groupBoxDivide.TabStop = false;
			this.groupBoxDivide.Text = "Разбиение";
			// 
			// comboBoxDivide
			// 
			this.comboBoxDivide.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxDivide.FormattingEnabled = true;
			this.comboBoxDivide.Items.AddRange(new object[] {
            "Месяц",
            "Сутки",
            "Раздел"});
			this.comboBoxDivide.Location = new System.Drawing.Point(6, 25);
			this.comboBoxDivide.Name = "comboBoxDivide";
			this.comboBoxDivide.Size = new System.Drawing.Size(121, 21);
			this.comboBoxDivide.TabIndex = 0;
			// 
			// checkBoxDivideEnable
			// 
			this.checkBoxDivideEnable.AutoSize = true;
			this.checkBoxDivideEnable.Location = new System.Drawing.Point(255, 93);
			this.checkBoxDivideEnable.Name = "checkBoxDivideEnable";
			this.checkBoxDivideEnable.Size = new System.Drawing.Size(99, 17);
			this.checkBoxDivideEnable.TabIndex = 6;
			this.checkBoxDivideEnable.Text = "Использовать";
			this.checkBoxDivideEnable.UseVisualStyleBackColor = true;
			this.checkBoxDivideEnable.Click += new System.EventHandler(this.checkBoxDivideEnable_Click);
			// 
			// groupBoxRegularizeByTime
			// 
			this.groupBoxRegularizeByTime.Enabled = false;
			this.groupBoxRegularizeByTime.Location = new System.Drawing.Point(419, 11);
			this.groupBoxRegularizeByTime.Name = "groupBoxRegularizeByTime";
			this.groupBoxRegularizeByTime.Size = new System.Drawing.Size(171, 76);
			this.groupBoxRegularizeByTime.TabIndex = 7;
			this.groupBoxRegularizeByTime.TabStop = false;
			this.groupBoxRegularizeByTime.Text = "Упорядочивание по времени";
			// 
			// checkBoxRegularizeByTime
			// 
			this.checkBoxRegularizeByTime.AutoSize = true;
			this.checkBoxRegularizeByTime.Location = new System.Drawing.Point(419, 93);
			this.checkBoxRegularizeByTime.Name = "checkBoxRegularizeByTime";
			this.checkBoxRegularizeByTime.Size = new System.Drawing.Size(99, 17);
			this.checkBoxRegularizeByTime.TabIndex = 6;
			this.checkBoxRegularizeByTime.Text = "Использовать";
			this.checkBoxRegularizeByTime.UseVisualStyleBackColor = true;
			this.checkBoxRegularizeByTime.Click += new System.EventHandler(this.checkBoxRegularizeByTime_Click);
			// 
			// CorrectForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(601, 203);
			this.Controls.Add(this.checkBoxRegularizeByTime);
			this.Controls.Add(this.groupBoxRegularizeByTime);
			this.Controls.Add(this.checkBoxDivideEnable);
			this.Controls.Add(this.checkBoxBackup);
			this.Controls.Add(this.checkBoxFilterEnable);
			this.Controls.Add(this.groupBoxDivide);
			this.Controls.Add(this.groupBoxFilter);
			this.Controls.Add(this.buttonStart);
			this.Controls.Add(this.buttonClose);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CorrectForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Корректировка треков";
			this.groupBoxFilter.ResumeLayout(false);
			this.groupBoxFilter.PerformLayout();
			this.groupBoxDivide.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonStart;
		private System.Windows.Forms.TextBox textBoxMaxSpeed;
		private System.Windows.Forms.CheckBox checkBoxMaxSpeed;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.CheckBox checkBoxBackup;
		private System.Windows.Forms.GroupBox groupBoxFilter;
		private System.Windows.Forms.GroupBox groupBoxDivide;
		private System.Windows.Forms.ComboBox comboBoxDivide;
		private System.Windows.Forms.CheckBox checkBoxFilterEnable;
		private System.Windows.Forms.CheckBox checkBoxDivideEnable;
		private System.Windows.Forms.GroupBox groupBoxRegularizeByTime;
		private System.Windows.Forms.CheckBox checkBoxRegularizeByTime;
	}
}