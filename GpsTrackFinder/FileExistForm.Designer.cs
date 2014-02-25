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
	partial class FileExistForm
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
			this.buttonOverride = new System.Windows.Forms.Button();
			this.buttonSkip = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.textBoxFileName = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// buttonOverride
			// 
			this.buttonOverride.Location = new System.Drawing.Point(94, 70);
			this.buttonOverride.Name = "buttonOverride";
			this.buttonOverride.Size = new System.Drawing.Size(100, 23);
			this.buttonOverride.TabIndex = 0;
			this.buttonOverride.Text = "Перезаписать";
			this.buttonOverride.UseVisualStyleBackColor = true;
			this.buttonOverride.Click += new System.EventHandler(this.buttonOverride_Click);
			// 
			// buttonSkip
			// 
			this.buttonSkip.Location = new System.Drawing.Point(220, 70);
			this.buttonSkip.Name = "buttonSkip";
			this.buttonSkip.Size = new System.Drawing.Size(100, 23);
			this.buttonSkip.TabIndex = 2;
			this.buttonSkip.Text = "Пропустить";
			this.buttonSkip.UseVisualStyleBackColor = true;
			this.buttonSkip.Click += new System.EventHandler(this.buttonSkip_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(346, 70);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(100, 23);
			this.buttonCancel.TabIndex = 3;
			this.buttonCancel.Text = "Отмена";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(207, 102);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(127, 17);
			this.checkBox1.TabIndex = 4;
			this.checkBox1.Text = "Применить ко всем";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// textBoxFileName
			// 
			this.textBoxFileName.BackColor = System.Drawing.SystemColors.Control;
			this.textBoxFileName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxFileName.Location = new System.Drawing.Point(12, 12);
			this.textBoxFileName.Multiline = true;
			this.textBoxFileName.Name = "textBoxFileName";
			this.textBoxFileName.Size = new System.Drawing.Size(517, 52);
			this.textBoxFileName.TabIndex = 6;
			// 
			// FileExistForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(541, 128);
			this.Controls.Add(this.textBoxFileName);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonSkip);
			this.Controls.Add(this.buttonOverride);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FileExistForm";
			this.Text = "FileExistForm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FileExistForm_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonOverride;
		private System.Windows.Forms.Button buttonSkip;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.TextBox textBoxFileName;
	}
}