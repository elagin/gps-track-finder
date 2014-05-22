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

			if (settings.Correct.ApplyMaxSpeedFilter)
			    checkBoxMaxSpeed.CheckState = CheckState.Checked;
			textBoxMaxSpeed.Text = Convert.ToString(settings.Correct.MaxSpeedFilter);
			
			if (settings.Correct.SaveBackup)
			    checkBoxBackup.CheckState = CheckState.Checked;
		}

		private void buttonStart_Click(object sender, EventArgs e)
		{
			settings.Correct.ApplyMaxSpeedFilter = checkBoxMaxSpeed.CheckState == CheckState.Checked;
			settings.Correct.MaxSpeedFilter = Convert.ToInt32(textBoxMaxSpeed.Text);
			settings.Correct.SaveBackup = checkBoxBackup.CheckState == CheckState.Checked;
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void buttonClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
