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
using System.Collections;

namespace GpsTrackFinder
{
	public partial class MainForm : Form
	{
		/// <summary>
		/// Хранит настройки.</summary>
		private Settings settings = new Settings("config");
		private DataTable dt = new DataTable();

		private GpsPoint _internalDegres = new GpsPoint();

		private System.ComponentModel.BackgroundWorker bgw = new BackgroundWorker();
		private Stopwatch sWatch = new Stopwatch();

		/// <summary>
		/// Индекс столбца для сортировки.</summary>
		private int _sortColunm = 2;

		/// <summary>
		/// Количество найденных треков.</summary>
		private int _tracksFound = 0;

		/// <summary>
		/// CheckBox для переключения всех галок в столбце id.</summary>
		CheckBox checkBox;

		public MainForm()
		{
			InitializeComponent();
			fillCtrls();
			checkAvaibleCtrls();

			bgw.DoWork += new DoWorkEventHandler(bgw_DoWork);
			bgw.ProgressChanged += new ProgressChangedEventHandler(bgw_ProgressChanged);
			bgw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgw_RunWorkerCompleted);
			bgw.WorkerReportsProgress = true;
			bgw.WorkerSupportsCancellation = true;
		}

		/// <summary>
		/// Инициализирует dataGridView.</summary>
		private void initDataGridView()
		{
			dt.Columns.Add("id", typeof(bool));
			dt.Columns.Add("filename", typeof(string));
			dt.Columns.Add("distance", typeof(int));
			dt.Columns.Add("length", typeof(int));
			dt.Columns.Add("points", typeof(int));
			dt.Columns.Add("points_p_m", typeof(double));
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

			comboBoxLon.Items.Add(new ComboItem("E", 0));
			comboBoxLon.Items.Add(new ComboItem("W", 1));

			_internalDegres.Lat = Drivers.getDeg(settings.CentralPoint.Lat);
			_internalDegres.Lon = Drivers.getDeg(settings.CentralPoint.Lon);

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

			textBoxCopyToFilder.Text = settings.CopyToFilder;
			buttonCopyToFilder.Enabled = settings.CopyToFilder.Length > 0;

			textBoxWptFile.Text = settings.WptFileName;

			initDataGridView();

			checkBox = new CheckBox();
			checkBox.CheckedChanged += new EventHandler(checkBox_CheckedChanged);
			checkBox.Size = new Size(18, 18);
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

				_internalDegres.Lat = Drivers.getDeg(settings.CentralPoint.Lat);
				_internalDegres.Lon = Drivers.getDeg(settings.CentralPoint.Lon);

			}
			settings.SearchFolder = textBoxFindFolder.Text;

			if (textBoxDistance.Text.Length > 0)
				settings.Distaice = Convert.ToInt32(textBoxDistance.Text, invC);

			settings.CopyToFilder = textBoxCopyToFilder.Text;
			settings.WptFileName = textBoxWptFile.Text;
		}

		/// <summary>
		/// Обрабатываем данные.</summary>
		private void buttonStart_Click(object sender, EventArgs e)
		{
			if (!bgw.IsBusy)
			{
				SaveCtrls();
				dt.Clear();

				string filepath = textBoxFindFolder.Text;
				bgw.RunWorkerAsync();
				buttonStart.Text = "Стоп";
				checkBox.Checked = false;
				_tracksFound = 0;
				dataGridView1.DataSource = dt;
				dataGridView1.Sort(dataGridView1.Columns[_sortColunm], ListSortDirection.Ascending);
			}
			else
				bgw.CancelAsync();
		}

		/// <summary>
		/// Отображает диалог указания папки.</summary>
		private string getFolder()
		{
			FolderBrowserDialog dlg = new FolderBrowserDialog();
			dlg.Description = "Поиск папки";
			dlg.SelectedPath = textBoxFindFolder.Text;
			DialogResult result = dlg.ShowDialog();
			if (result == DialogResult.OK)
				return dlg.SelectedPath;
			else
				return "";
		}

		/// <summary>
		/// Отображает диалог указания файла.</summary>
		private string getFileName()
		{
			OpenFileDialog dlg = new OpenFileDialog();

			dlg.InitialDirectory = textBoxFindFolder.Text;
			dlg.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
			dlg.FilterIndex = 2;
			dlg.RestoreDirectory = true;

			DialogResult result = dlg.ShowDialog();
			if (result == DialogResult.OK)
				return dlg.FileName;
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

		/// <summary>
		/// Возвращает список имен выделеных файлов.</summary>
		private List<string> getSelectedFilenames()
		{
			List<string> res = new List<string>();
			foreach (DataGridViewRow item in dataGridView1.Rows)
			{
				if (item.Cells["id"].Value != null && (bool)item.Cells["id"].FormattedValue)
					res.Add(item.Cells["filename"].FormattedValue.ToString());
			}
			return res;
		}

		/// <summary>
		/// Копирует имена выделеных файлов в буфер обмена.</summary>
		private void buttonCopyPath_Click(object sender, EventArgs e)
		{
			try
			{
				StringBuilder buff = new StringBuilder();
				List<string> fileNames = getSelectedFilenames();
				foreach (string item in fileNames)
					buff.Append(item + Environment.NewLine);

				if (buff.Length > 0)
					Clipboard.SetData(DataFormats.Text, (Object)buff.ToString());
			}
			catch (Exception ex)
			{
				string caption = "Произошла ошибка при вставке в буфер обмена";
				var result = MessageBox.Show(ex.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// Открывает выделеные файлы в редакторе по-умолчанию.</summary>
		private void buttonOpenFolder_Click(object sender, EventArgs e)
		{
			List<string> fileNames = getSelectedFilenames();
			foreach (string item in fileNames)
			{
				Process Proc = new Process();
				Proc.StartInfo.FileName = "explorer";
				Proc.StartInfo.Arguments = item;
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

		/// <summary>
		/// Проверяет доступность элементов UI для пользователя.</summary>
		private void checkAvaibleCtrls()
		{
			buttonStart.Enabled = (textBoxFindFolder.Text.Length > 0 && (textBoxWptFile.Text.Length > 0 || (textBoxLat.Text.Length > 0 && textBoxLon.Text.Length > 0)));
			int count = 0;
			foreach (DataGridViewRow item in dataGridView1.Rows)
				if (item.Cells["id"].Value != null && (bool)item.Cells["id"].FormattedValue)
					count++;
			buttonCopyPath.Enabled = count > 0;
			buttonOpenFolder.Enabled = count > 0;
			buttonDelete.Enabled = count > 0;
			buttonCopyToFilder.Enabled = (settings.CopyToFilder.Length > 0 && count > 0);
			labelFoundInfo.Text = String.Format("Найдено/выбрано: {0}/{1}", _tracksFound, count);
		}

		private void textBoxFindFolder_TextChanged(object sender, EventArgs e)
		{
			checkAvaibleCtrls();
		}

		private void textBoxWptFile_TextChanged(object sender, EventArgs e)
		{
			checkAvaibleCtrls();
		}

		private void textBoxLat_TextChanged(object sender, EventArgs e)
		{
			checkAvaibleCtrls();
		}

		private void textBoxLon_TextChanged(object sender, EventArgs e)
		{
			checkAvaibleCtrls();
		}

		/// <summary>
		/// Отслеживает смену текста в пути для копирования треков.</summary>
		private void textBoxCopyToFilder_TextChanged(object sender, EventArgs e)
		{
			settings.CopyToFilder = textBoxCopyToFilder.Text;
			checkAvaibleCtrls();
		}

		/// <summary>
		/// Запоминает индекс столбца для сортировки.</summary>
		private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			_sortColunm = e.ColumnIndex;
		}

		/// <summary>
		/// Задача вторичного потока.</summary>
		void bgw_DoWork(object sender, DoWorkEventArgs e)
		{
			try
			{
				List<GpsPoint> list = Drivers.ParseWpt(settings.WptFileName);
				list.Add(_internalDegres);
				folderWalker(ref bgw, settings.SearchFolder, list);
			}
			catch (Exception ex)
			{
				const string caption = "Ошибка";
				var result = MessageBox.Show(ex.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// Событие изменения прогресс-бара.</summary>
		void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			WorkState state = (WorkState)e.UserState;
			dt.Rows.Add(state.arr);
			labelCurrentFolder.Text = "Поиск: " + state.path;
			_tracksFound++;
			labelFoundInfo.Text = String.Format("Найдено/выбрано: {0}/0", _tracksFound);
		}

		/// <summary>
		/// Вторичный поток работу закончил.</summary>
		void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			sWatch.Stop();
			buttonStart.Text = "Старт";
			labelCurrentFolder.Text = "Поиск: завершен";
			TimeSpan tSpan = sWatch.Elapsed;
		}

		/// <summary>
		/// Обрабатывает треки в указанной папке.</summary>
		private void folderWalker(ref BackgroundWorker bgw, string path, List<GpsPoint> points)
		{
			if (!bgw.CancellationPending)
			{
				DirectoryInfo d = new DirectoryInfo(path);
				foreach (var file in d.GetFiles("*.plt"))
				{
					TrackStat stat = Drivers.ParsePlt(settings.Distaice, file.FullName, points);

					if (settings.Distaice * 1000 > (int)stat.MinDist)
					{
						WorkState state = new WorkState();

						object[] arr = new object[6];
						arr[0] = false;
						arr[1] = stat.FileName;
						arr[2] = (int)stat.MinDist;
						arr[3] = (int)stat.Length;
						arr[4] = stat.Points;
						arr[5] = stat.Points / (stat.Length / 1000);

						state.arr = arr;
						state.path = path;
						bgw.ReportProgress(0, state);  // Обновляем информацию о результатах работы.
					}
				}
				foreach (var folder in d.GetDirectories())
					folderWalker(ref bgw, path + "\\" + folder.Name, points);
			}
		}

		/// <summary>
		/// Позволяет сменить папку для копирования треков.</summary>
		private void buttonDrowseCopyToFilder_Click(object sender, EventArgs e)
		{
			string newFolder = getFolder();
			if (newFolder.Length > 0)
			{
				textBoxCopyToFilder.Text = newFolder;
				settings.CopyToFilder = newFolder;
			}
		}

		/// <summary>
		/// Копирует выделенные треки в указанную папку.</summary>
		private void buttonCopyToFilder_Click(object sender, EventArgs e)
		{
			EFileExist behavior = EFileExist.Unknown;
			try
			{
				settings.CopyToFilder = textBoxCopyToFilder.Text;
				if (!System.IO.Directory.Exists(settings.CopyToFilder))
					System.IO.Directory.CreateDirectory(settings.CopyToFilder);

				List<string> fileNames = getSelectedFilenames();
				foreach (string item in fileNames)
				{
					FileInfo infoSrc = new FileInfo(item);
					
					string fileNameDst = settings.CopyToFilder + "\\" + infoSrc.Name;
					FileInfo infoDst = new FileInfo(fileNameDst);

					if (infoDst.Exists && (behavior == EFileExist.Unknown || behavior == EFileExist.Skip || behavior == EFileExist.Override))
					{
						using (FileExistForm form = new FileExistForm(fileNameDst))
						{
							DialogResult resDlg = form.ShowDialog();
							behavior = form.ReturnValue1;
						}
						if (behavior == EFileExist.Cancel)
							break;
					}

					if (!infoDst.Exists || behavior == EFileExist.OverrideAll || behavior == EFileExist.Override)
						infoSrc.CopyTo(fileNameDst, true);
				}
			}
			catch (Exception ex)
			{
				const string caption = "Ошибка при копировании файла";
				MessageBox.Show(ex.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// Удаляет выделенные треки.</summary>
		private void buttonDelete_Click(object sender, EventArgs e)
		{
			List<string> fileNames = getSelectedFilenames();
			string message = String.Format("Вы действительно хотите удалить {0} треков?", fileNames.Count);
			if (MessageBox.Show(message, "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
			{
				foreach (string item in fileNames)
				{
					try
					{
						File.Delete(item);
						foreach (DataRow row in dt.Rows)
						{
							if (row["filename"].Equals(item))
							{
								row.Delete();
								break;
							}
						}
					}
					catch (Exception ex)
					{
						string caption = "Ошибка при удалении файла.";
						MessageBox.Show(item + Environment.NewLine + ex.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				checkAvaibleCtrls();
			}
		}

		/// <summary>
		/// Позволяет отследить какой checkBox будет изменен.</summary>
		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
			checkAvaibleCtrls();
		}

		/// <summary>
		/// Событие при загрузке формы.</summary>
		private void MainForm_Load(object sender, EventArgs e)
		{
			setCheckBoxPos();
			dataGridView1.Controls.Add(checkBox);
		}

		/// <summary>
		/// Событие при нажатии на переключатель галок.</summary>
		void checkBox_CheckedChanged(object sender, EventArgs e)
		{
			foreach (DataGridViewRow item in dataGridView1.Rows)
				item.Cells["id"].Value = checkBox.Checked;

// todo: Попытка исправить ошибку с выбором элементов
/*
			foreach (DataRow item in dt.Rows)
				item["id"] = checkBox.Checked;
*/
			checkAvaibleCtrls();
		}

		/// <summary>
		/// Событие при изменении размеров формы</summary>
		private void MainForm_Resize(object sender, EventArgs e)
		{
			setCheckBoxPos();
		}

		/// <summary>
		/// Событие при изменении ширины столбца</summary>
		private void dataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
		{
			if (e.Column.Name.Equals("id"))
				setCheckBoxPos();
		}

		/// <summary>
		/// Устанавливает checkBox на нужное место.</summary>
		private void setCheckBoxPos()
		{
			if (checkBox != null)
			{
				Rectangle rect = dataGridView1.GetCellDisplayRectangle(0, -1, true);
				checkBox.Location = new Point(
					rect.Left + rect.Width / 2 - checkBox.Size.Width / 2 + 1,
					rect.Top + rect.Height / 2 - checkBox.Size.Height / 2);
			}
		}

		private void buttonWptBrowse_Click(object sender, EventArgs e)
		{
			string newFile = getFileName();
			if (newFile.Length > 0)
			{
				textBoxWptFile.Text = newFile;
				settings.WptFileName = newFile;
			}
		}
	}

	/// <summary>
	/// Класс для хранения статистики по работе второго потока.</summary>
	public class WorkState
	{
		public object[] arr { get; set; }
		public string path { get; set; }
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

	/// <summary>
	/// Результат формы "файл существует"</summary>
	public enum EFileExist
	{
		Unknown,
		Override,
		OverrideAll,
		Skip,
		SkipAll,
		Cancel,
	};
}

