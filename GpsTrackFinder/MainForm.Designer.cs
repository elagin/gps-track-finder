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
			this.SuspendLayout();
			// 
			// textBoxLat
			// 
			this.textBoxLat.Location = new System.Drawing.Point(43, 30);
			this.textBoxLat.Name = "textBoxLat";
			this.textBoxLat.Size = new System.Drawing.Size(100, 20);
			this.textBoxLat.TabIndex = 0;
			// 
			// textBoxLon
			// 
			this.textBoxLon.Location = new System.Drawing.Point(149, 30);
			this.textBoxLon.Name = "textBoxLon";
			this.textBoxLon.Size = new System.Drawing.Size(100, 20);
			this.textBoxLon.TabIndex = 1;
			// 
			// textBoxDistance
			// 
			this.textBoxDistance.Location = new System.Drawing.Point(276, 30);
			this.textBoxDistance.Name = "textBoxDistance";
			this.textBoxDistance.Size = new System.Drawing.Size(100, 20);
			this.textBoxDistance.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(273, 14);
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
			// 
			// buttonStart
			// 
			this.buttonStart.Location = new System.Drawing.Point(430, 123);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(75, 23);
			this.buttonStart.TabIndex = 6;
			this.buttonStart.Text = "Старт";
			this.buttonStart.UseVisualStyleBackColor = true;
			// 
			// listView1
			// 
			this.listView1.Location = new System.Drawing.Point(12, 176);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(910, 281);
			this.listView1.TabIndex = 7;
			this.listView1.UseCompatibleStateImageBehavior = false;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(934, 544);
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
	}
}

