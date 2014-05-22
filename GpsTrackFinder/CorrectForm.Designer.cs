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
			this.SuspendLayout();
			// 
			// buttonStart
			// 
			this.buttonStart.Location = new System.Drawing.Point(26, 78);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(75, 23);
			this.buttonStart.TabIndex = 3;
			this.buttonStart.Text = "Старт";
			this.buttonStart.UseVisualStyleBackColor = true;
			this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
			// 
			// textBoxMaxSpeed
			// 
			this.textBoxMaxSpeed.Location = new System.Drawing.Point(20, 9);
			this.textBoxMaxSpeed.Name = "textBoxMaxSpeed";
			this.textBoxMaxSpeed.Size = new System.Drawing.Size(31, 20);
			this.textBoxMaxSpeed.TabIndex = 0;
			this.textBoxMaxSpeed.Text = "0";
			// 
			// checkBoxMaxSpeed
			// 
			this.checkBoxMaxSpeed.AutoSize = true;
			this.checkBoxMaxSpeed.Location = new System.Drawing.Point(57, 12);
			this.checkBoxMaxSpeed.Name = "checkBoxMaxSpeed";
			this.checkBoxMaxSpeed.Size = new System.Drawing.Size(153, 17);
			this.checkBoxMaxSpeed.TabIndex = 1;
			this.checkBoxMaxSpeed.Text = "Максимальная скорость";
			this.checkBoxMaxSpeed.UseVisualStyleBackColor = true;
			// 
			// buttonClose
			// 
			this.buttonClose.Location = new System.Drawing.Point(130, 78);
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
			this.checkBoxBackup.Location = new System.Drawing.Point(20, 44);
			this.checkBoxBackup.Name = "checkBoxBackup";
			this.checkBoxBackup.Size = new System.Drawing.Size(212, 17);
			this.checkBoxBackup.TabIndex = 2;
			this.checkBoxBackup.Text = "Сохранять резервные копии файлов";
			this.checkBoxBackup.UseVisualStyleBackColor = true;
			// 
			// CorrectForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(266, 120);
			this.Controls.Add(this.checkBoxBackup);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.checkBoxMaxSpeed);
			this.Controls.Add(this.textBoxMaxSpeed);
			this.Controls.Add(this.buttonStart);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CorrectForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Корректировка треков";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonStart;
		private System.Windows.Forms.TextBox textBoxMaxSpeed;
		private System.Windows.Forms.CheckBox checkBoxMaxSpeed;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.CheckBox checkBoxBackup;
	}
}