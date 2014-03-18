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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			this.textBoxLat = new System.Windows.Forms.TextBox();
			this.textBoxLon = new System.Windows.Forms.TextBox();
			this.textBoxDistance = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxFindFolder = new System.Windows.Forms.TextBox();
			this.buttonBrowse = new System.Windows.Forms.Button();
			this.buttonStart = new System.Windows.Forms.Button();
			this.comboBoxLat = new System.Windows.Forms.ComboBox();
			this.comboBoxLon = new System.Windows.Forms.ComboBox();
			this.buttonCopyPath = new System.Windows.Forms.Button();
			this.buttonOpenFolder = new System.Windows.Forms.Button();
			this.buttonAbout = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.id = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.filename = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.distance = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.length = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.points = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.points_p_m = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.panel1 = new System.Windows.Forms.Panel();
			this.buttonDelete = new System.Windows.Forms.Button();
			this.buttonCopyToFilder = new System.Windows.Forms.Button();
			this.buttonDrowseCopyToFilder = new System.Windows.Forms.Button();
			this.textBoxCopyToFilder = new System.Windows.Forms.TextBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.buttonWptBrowse = new System.Windows.Forms.Button();
			this.textBoxWptFile = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.labelFoundInfo = new System.Windows.Forms.Label();
			this.labelCurrentFolder = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBoxLat
			// 
			this.textBoxLat.Location = new System.Drawing.Point(50, 24);
			this.textBoxLat.Name = "textBoxLat";
			this.textBoxLat.Size = new System.Drawing.Size(100, 20);
			this.textBoxLat.TabIndex = 0;
			this.textBoxLat.TextChanged += new System.EventHandler(this.textBoxLat_TextChanged);
			// 
			// textBoxLon
			// 
			this.textBoxLon.Location = new System.Drawing.Point(199, 24);
			this.textBoxLon.Name = "textBoxLon";
			this.textBoxLon.Size = new System.Drawing.Size(100, 20);
			this.textBoxLon.TabIndex = 1;
			this.textBoxLon.TextChanged += new System.EventHandler(this.textBoxLon_TextChanged);
			// 
			// textBoxDistance
			// 
			this.textBoxDistance.Location = new System.Drawing.Point(313, 24);
			this.textBoxDistance.Name = "textBoxDistance";
			this.textBoxDistance.Size = new System.Drawing.Size(100, 20);
			this.textBoxDistance.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(310, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(89, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Дистанция (км):";
			// 
			// textBoxFindFolder
			// 
			this.textBoxFindFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxFindFolder.Location = new System.Drawing.Point(54, 60);
			this.textBoxFindFolder.Name = "textBoxFindFolder";
			this.textBoxFindFolder.Size = new System.Drawing.Size(839, 20);
			this.textBoxFindFolder.TabIndex = 4;
			this.textBoxFindFolder.TextChanged += new System.EventHandler(this.textBoxFindFolder_TextChanged);
			// 
			// buttonBrowse
			// 
			this.buttonBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonBrowse.Location = new System.Drawing.Point(899, 57);
			this.buttonBrowse.Name = "buttonBrowse";
			this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
			this.buttonBrowse.TabIndex = 5;
			this.buttonBrowse.Text = "Изменить...";
			this.buttonBrowse.UseVisualStyleBackColor = true;
			this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
			// 
			// buttonStart
			// 
			this.buttonStart.Location = new System.Drawing.Point(419, 22);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(142, 23);
			this.buttonStart.TabIndex = 3;
			this.buttonStart.Text = "Старт";
			this.buttonStart.UseVisualStyleBackColor = true;
			this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
			// 
			// comboBoxLat
			// 
			this.comboBoxLat.FormattingEnabled = true;
			this.comboBoxLat.Location = new System.Drawing.Point(12, 24);
			this.comboBoxLat.Name = "comboBoxLat";
			this.comboBoxLat.Size = new System.Drawing.Size(35, 21);
			this.comboBoxLat.TabIndex = 8;
			// 
			// comboBoxLon
			// 
			this.comboBoxLon.FormattingEnabled = true;
			this.comboBoxLon.Location = new System.Drawing.Point(161, 24);
			this.comboBoxLon.Name = "comboBoxLon";
			this.comboBoxLon.Size = new System.Drawing.Size(35, 21);
			this.comboBoxLon.TabIndex = 9;
			// 
			// buttonCopyPath
			// 
			this.buttonCopyPath.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.buttonCopyPath.Location = new System.Drawing.Point(0, 414);
			this.buttonCopyPath.Name = "buttonCopyPath";
			this.buttonCopyPath.Size = new System.Drawing.Size(123, 23);
			this.buttonCopyPath.TabIndex = 10;
			this.buttonCopyPath.Text = "Скопировать имя";
			this.buttonCopyPath.UseVisualStyleBackColor = true;
			this.buttonCopyPath.Click += new System.EventHandler(this.buttonCopyPath_Click);
			// 
			// buttonOpenFolder
			// 
			this.buttonOpenFolder.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.buttonOpenFolder.Location = new System.Drawing.Point(139, 414);
			this.buttonOpenFolder.Name = "buttonOpenFolder";
			this.buttonOpenFolder.Size = new System.Drawing.Size(128, 23);
			this.buttonOpenFolder.TabIndex = 11;
			this.buttonOpenFolder.Text = "Открыть в редакторе";
			this.buttonOpenFolder.UseVisualStyleBackColor = true;
			this.buttonOpenFolder.Click += new System.EventHandler(this.buttonOpenFolder_Click);
			// 
			// buttonAbout
			// 
			this.buttonAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAbout.Location = new System.Drawing.Point(899, 21);
			this.buttonAbout.Name = "buttonAbout";
			this.buttonAbout.Size = new System.Drawing.Size(75, 23);
			this.buttonAbout.TabIndex = 12;
			this.buttonAbout.Text = "Автора!";
			this.buttonAbout.UseVisualStyleBackColor = true;
			this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 13);
			this.label2.TabIndex = 13;
			this.label2.Text = "Широта:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(158, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(53, 13);
			this.label3.TabIndex = 14;
			this.label3.Text = "Долгота:";
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToOrderColumns = true;
			this.dataGridView1.AllowUserToResizeRows = false;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView1.ColumnHeadersHeight = 20;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.filename,
            this.distance,
            this.length,
            this.points,
            this.points_p_m});
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle6.Format = "N4";
			dataGridViewCellStyle6.NullValue = null;
			dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle6;
			this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.dataGridView1.Location = new System.Drawing.Point(3, 0);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(971, 402);
			this.dataGridView1.TabIndex = 15;
			this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
			this.dataGridView1.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGridView1_ColumnWidthChanged);
			// 
			// id
			// 
			this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.id.DataPropertyName = "id";
			this.id.HeaderText = "";
			this.id.Name = "id";
			this.id.Width = 50;
			// 
			// filename
			// 
			this.filename.DataPropertyName = "filename";
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.filename.DefaultCellStyle = dataGridViewCellStyle1;
			this.filename.HeaderText = "Имя файла";
			this.filename.Name = "filename";
			this.filename.ReadOnly = true;
			// 
			// distance
			// 
			this.distance.DataPropertyName = "distance";
			dataGridViewCellStyle2.Format = "N0";
			dataGridViewCellStyle2.NullValue = null;
			this.distance.DefaultCellStyle = dataGridViewCellStyle2;
			this.distance.HeaderText = "Мин. расстояние";
			this.distance.Name = "distance";
			this.distance.ReadOnly = true;
			// 
			// length
			// 
			this.length.DataPropertyName = "length";
			dataGridViewCellStyle3.Format = "N0";
			dataGridViewCellStyle3.NullValue = null;
			this.length.DefaultCellStyle = dataGridViewCellStyle3;
			this.length.HeaderText = "Длинна трека";
			this.length.Name = "length";
			this.length.ReadOnly = true;
			// 
			// points
			// 
			this.points.DataPropertyName = "points";
			dataGridViewCellStyle4.Format = "N0";
			dataGridViewCellStyle4.NullValue = null;
			this.points.DefaultCellStyle = dataGridViewCellStyle4;
			this.points.HeaderText = "Количество точек";
			this.points.Name = "points";
			this.points.ReadOnly = true;
			// 
			// points_p_m
			// 
			this.points_p_m.DataPropertyName = "points_p_m";
			dataGridViewCellStyle5.Format = "N0";
			dataGridViewCellStyle5.NullValue = null;
			this.points_p_m.DefaultCellStyle = dataGridViewCellStyle5;
			this.points_p_m.HeaderText = "Точек на км.";
			this.points_p_m.Name = "points_p_m";
			this.points_p_m.ReadOnly = true;
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Controls.Add(this.buttonDelete);
			this.panel1.Controls.Add(this.buttonCopyToFilder);
			this.panel1.Controls.Add(this.buttonDrowseCopyToFilder);
			this.panel1.Controls.Add(this.textBoxCopyToFilder);
			this.panel1.Controls.Add(this.dataGridView1);
			this.panel1.Controls.Add(this.buttonCopyPath);
			this.panel1.Controls.Add(this.buttonOpenFolder);
			this.panel1.Location = new System.Drawing.Point(12, 139);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(977, 437);
			this.panel1.TabIndex = 16;
			// 
			// buttonDelete
			// 
			this.buttonDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.buttonDelete.Location = new System.Drawing.Point(285, 414);
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.Size = new System.Drawing.Size(128, 23);
			this.buttonDelete.TabIndex = 19;
			this.buttonDelete.Text = "Удалить";
			this.buttonDelete.UseVisualStyleBackColor = true;
			this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
			// 
			// buttonCopyToFilder
			// 
			this.buttonCopyToFilder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCopyToFilder.Location = new System.Drawing.Point(473, 414);
			this.buttonCopyToFilder.Name = "buttonCopyToFilder";
			this.buttonCopyToFilder.Size = new System.Drawing.Size(95, 23);
			this.buttonCopyToFilder.TabIndex = 18;
			this.buttonCopyToFilder.Text = "Скопировать в:";
			this.buttonCopyToFilder.UseVisualStyleBackColor = true;
			this.buttonCopyToFilder.Click += new System.EventHandler(this.buttonCopyToFilder_Click);
			// 
			// buttonDrowseCopyToFilder
			// 
			this.buttonDrowseCopyToFilder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonDrowseCopyToFilder.Location = new System.Drawing.Point(943, 414);
			this.buttonDrowseCopyToFilder.Name = "buttonDrowseCopyToFilder";
			this.buttonDrowseCopyToFilder.Size = new System.Drawing.Size(31, 23);
			this.buttonDrowseCopyToFilder.TabIndex = 17;
			this.buttonDrowseCopyToFilder.Text = "...";
			this.buttonDrowseCopyToFilder.UseVisualStyleBackColor = true;
			this.buttonDrowseCopyToFilder.Click += new System.EventHandler(this.buttonDrowseCopyToFilder_Click);
			// 
			// textBoxCopyToFilder
			// 
			this.textBoxCopyToFilder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxCopyToFilder.Location = new System.Drawing.Point(574, 416);
			this.textBoxCopyToFilder.Name = "textBoxCopyToFilder";
			this.textBoxCopyToFilder.Size = new System.Drawing.Size(363, 20);
			this.textBoxCopyToFilder.TabIndex = 16;
			this.textBoxCopyToFilder.TextChanged += new System.EventHandler(this.textBoxCopyToFilder_TextChanged);
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.Controls.Add(this.buttonWptBrowse);
			this.panel2.Controls.Add(this.textBoxWptFile);
			this.panel2.Controls.Add(this.label5);
			this.panel2.Controls.Add(this.label4);
			this.panel2.Controls.Add(this.labelFoundInfo);
			this.panel2.Controls.Add(this.labelCurrentFolder);
			this.panel2.Controls.Add(this.textBoxLat);
			this.panel2.Controls.Add(this.textBoxFindFolder);
			this.panel2.Controls.Add(this.buttonAbout);
			this.panel2.Controls.Add(this.textBoxLon);
			this.panel2.Controls.Add(this.buttonBrowse);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Controls.Add(this.textBoxDistance);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.buttonStart);
			this.panel2.Controls.Add(this.comboBoxLon);
			this.panel2.Controls.Add(this.comboBoxLat);
			this.panel2.Location = new System.Drawing.Point(12, 12);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(977, 121);
			this.panel2.TabIndex = 17;
			// 
			// buttonWptBrowse
			// 
			this.buttonWptBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonWptBrowse.Location = new System.Drawing.Point(899, 90);
			this.buttonWptBrowse.Name = "buttonWptBrowse";
			this.buttonWptBrowse.Size = new System.Drawing.Size(75, 23);
			this.buttonWptBrowse.TabIndex = 20;
			this.buttonWptBrowse.Text = "Изменить...";
			this.buttonWptBrowse.UseVisualStyleBackColor = true;
			this.buttonWptBrowse.Click += new System.EventHandler(this.buttonWptBrowse_Click);
			// 
			// textBoxWptFile
			// 
			this.textBoxWptFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxWptFile.Location = new System.Drawing.Point(68, 90);
			this.textBoxWptFile.Name = "textBoxWptFile";
			this.textBoxWptFile.Size = new System.Drawing.Size(825, 20);
			this.textBoxWptFile.TabIndex = 5;
			this.textBoxWptFile.TextChanged += new System.EventHandler(this.textBoxWptFile_TextChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(9, 93);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(53, 13);
			this.label5.TabIndex = 18;
			this.label5.Text = "wpt-файл";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(9, 62);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(39, 13);
			this.label4.TabIndex = 17;
			this.label4.Text = "Папка";
			// 
			// labelFoundInfo
			// 
			this.labelFoundInfo.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelFoundInfo.AutoSize = true;
			this.labelFoundInfo.Location = new System.Drawing.Point(567, 26);
			this.labelFoundInfo.Name = "labelFoundInfo";
			this.labelFoundInfo.Size = new System.Drawing.Size(123, 13);
			this.labelFoundInfo.TabIndex = 16;
			this.labelFoundInfo.Text = "Найдено/выбрано: 0/0";
			// 
			// labelCurrentFolder
			// 
			this.labelCurrentFolder.AutoSize = true;
			this.labelCurrentFolder.Location = new System.Drawing.Point(416, 0);
			this.labelCurrentFolder.Name = "labelCurrentFolder";
			this.labelCurrentFolder.Size = new System.Drawing.Size(42, 13);
			this.labelCurrentFolder.TabIndex = 15;
			this.labelCurrentFolder.Text = "Поиск:";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1001, 588);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "MainForm";
			this.Text = "GpsTrackFinder";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.Resize += new System.EventHandler(this.MainForm_Resize);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxLat;
		private System.Windows.Forms.TextBox textBoxLon;
		private System.Windows.Forms.TextBox textBoxDistance;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxFindFolder;
		private System.Windows.Forms.Button buttonBrowse;
		private System.Windows.Forms.Button buttonStart;
		private System.Windows.Forms.ComboBox comboBoxLat;
		private System.Windows.Forms.ComboBox comboBoxLon;
		private System.Windows.Forms.Button buttonCopyPath;
		private System.Windows.Forms.Button buttonOpenFolder;
		private System.Windows.Forms.Button buttonAbout;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label labelCurrentFolder;
		private System.Windows.Forms.Button buttonDrowseCopyToFilder;
		private System.Windows.Forms.TextBox textBoxCopyToFilder;
		private System.Windows.Forms.Button buttonCopyToFilder;
		private System.Windows.Forms.Label labelFoundInfo;
		private System.Windows.Forms.DataGridViewCheckBoxColumn id;
		private System.Windows.Forms.DataGridViewTextBoxColumn filename;
		private System.Windows.Forms.DataGridViewTextBoxColumn distance;
		private System.Windows.Forms.DataGridViewTextBoxColumn length;
		private System.Windows.Forms.DataGridViewTextBoxColumn points;
		private System.Windows.Forms.DataGridViewTextBoxColumn points_p_m;
		private System.Windows.Forms.Button buttonDelete;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button buttonWptBrowse;
		private System.Windows.Forms.TextBox textBoxWptFile;
		private System.Windows.Forms.Label label5;
	}
}

