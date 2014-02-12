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
	partial class MainForm
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
			this.textBoxLat = new System.Windows.Forms.TextBox();
			this.textBoxLon = new System.Windows.Forms.TextBox();
			this.textBoxDistance = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxFindFolder = new System.Windows.Forms.TextBox();
			this.buttonBrowse = new System.Windows.Forms.Button();
			this.buttonStart = new System.Windows.Forms.Button();
			this.listView1 = new System.Windows.Forms.ListView();
			this.comboBoxLat = new System.Windows.Forms.ComboBox();
			this.comboBoxLon = new System.Windows.Forms.ComboBox();
			this.buttonCopyPath = new System.Windows.Forms.Button();
			this.buttonOpenFolder = new System.Windows.Forms.Button();
			this.buttonAbout = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBoxLat
			// 
			this.textBoxLat.Location = new System.Drawing.Point(53, 26);
			this.textBoxLat.Name = "textBoxLat";
			this.textBoxLat.Size = new System.Drawing.Size(100, 20);
			this.textBoxLat.TabIndex = 0;
			// 
			// textBoxLon
			// 
			this.textBoxLon.Location = new System.Drawing.Point(217, 27);
			this.textBoxLon.Name = "textBoxLon";
			this.textBoxLon.Size = new System.Drawing.Size(100, 20);
			this.textBoxLon.TabIndex = 1;
			// 
			// textBoxDistance
			// 
			this.textBoxDistance.Location = new System.Drawing.Point(347, 27);
			this.textBoxDistance.Name = "textBoxDistance";
			this.textBoxDistance.Size = new System.Drawing.Size(100, 20);
			this.textBoxDistance.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(344, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(83, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Дистанция (м):";
			// 
			// textBoxFindFolder
			// 
			this.textBoxFindFolder.Location = new System.Drawing.Point(43, 85);
			this.textBoxFindFolder.Name = "textBoxFindFolder";
			this.textBoxFindFolder.Size = new System.Drawing.Size(704, 20);
			this.textBoxFindFolder.TabIndex = 4;
			// 
			// buttonBrowse
			// 
			this.buttonBrowse.Location = new System.Drawing.Point(770, 85);
			this.buttonBrowse.Name = "buttonBrowse";
			this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
			this.buttonBrowse.TabIndex = 5;
			this.buttonBrowse.Text = "Изменить...";
			this.buttonBrowse.UseVisualStyleBackColor = true;
			this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
			// 
			// buttonStart
			// 
			this.buttonStart.Location = new System.Drawing.Point(430, 123);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(75, 23);
			this.buttonStart.TabIndex = 6;
			this.buttonStart.Text = "Старт";
			this.buttonStart.UseVisualStyleBackColor = true;
			this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
			// 
			// listView1
			// 
			this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.listView1.FullRowSelect = true;
			this.listView1.GridLines = true;
			this.listView1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.listView1.Location = new System.Drawing.Point(12, 176);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(910, 319);
			this.listView1.TabIndex = 7;
			this.listView1.UseCompatibleStateImageBehavior = false;
			// 
			// comboBoxLat
			// 
			this.comboBoxLat.FormattingEnabled = true;
			this.comboBoxLat.Location = new System.Drawing.Point(12, 25);
			this.comboBoxLat.Name = "comboBoxLat";
			this.comboBoxLat.Size = new System.Drawing.Size(35, 21);
			this.comboBoxLat.TabIndex = 8;
			// 
			// comboBoxLon
			// 
			this.comboBoxLon.FormattingEnabled = true;
			this.comboBoxLon.Location = new System.Drawing.Point(176, 26);
			this.comboBoxLon.Name = "comboBoxLon";
			this.comboBoxLon.Size = new System.Drawing.Size(35, 21);
			this.comboBoxLon.TabIndex = 9;
			// 
			// buttonCopyPath
			// 
			this.buttonCopyPath.Location = new System.Drawing.Point(53, 509);
			this.buttonCopyPath.Name = "buttonCopyPath";
			this.buttonCopyPath.Size = new System.Drawing.Size(133, 23);
			this.buttonCopyPath.TabIndex = 10;
			this.buttonCopyPath.Text = "Скопировать имя";
			this.buttonCopyPath.UseVisualStyleBackColor = true;
			this.buttonCopyPath.Click += new System.EventHandler(this.buttonCopyPath_Click);
			// 
			// buttonOpenFolder
			// 
			this.buttonOpenFolder.Location = new System.Drawing.Point(228, 509);
			this.buttonOpenFolder.Name = "buttonOpenFolder";
			this.buttonOpenFolder.Size = new System.Drawing.Size(133, 23);
			this.buttonOpenFolder.TabIndex = 11;
			this.buttonOpenFolder.Text = "Открыть в проводнике";
			this.buttonOpenFolder.UseVisualStyleBackColor = true;
			this.buttonOpenFolder.Click += new System.EventHandler(this.buttonOpenFolder_Click);
			// 
			// buttonAbout
			// 
			this.buttonAbout.Location = new System.Drawing.Point(829, 36);
			this.buttonAbout.Name = "buttonAbout";
			this.buttonAbout.Size = new System.Drawing.Size(75, 23);
			this.buttonAbout.TabIndex = 12;
			this.buttonAbout.Text = "Автора!";
			this.buttonAbout.UseVisualStyleBackColor = true;
			this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(934, 544);
			this.Controls.Add(this.buttonAbout);
			this.Controls.Add(this.buttonOpenFolder);
			this.Controls.Add(this.buttonCopyPath);
			this.Controls.Add(this.comboBoxLon);
			this.Controls.Add(this.comboBoxLat);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.buttonStart);
			this.Controls.Add(this.buttonBrowse);
			this.Controls.Add(this.textBoxFindFolder);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxDistance);
			this.Controls.Add(this.textBoxLon);
			this.Controls.Add(this.textBoxLat);
			this.Name = "MainForm";
			this.Text = "GpsTrackFinder";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxLat;
		private System.Windows.Forms.TextBox textBoxLon;
		private System.Windows.Forms.TextBox textBoxDistance;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxFindFolder;
		private System.Windows.Forms.Button buttonBrowse;
		private System.Windows.Forms.Button buttonStart;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ComboBox comboBoxLat;
		private System.Windows.Forms.ComboBox comboBoxLon;
		private System.Windows.Forms.Button buttonCopyPath;
		private System.Windows.Forms.Button buttonOpenFolder;
		private System.Windows.Forms.Button buttonAbout;
	}
}

