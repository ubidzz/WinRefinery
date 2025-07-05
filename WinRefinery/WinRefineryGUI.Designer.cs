using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Logging;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Policy;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.DataFormats;

namespace WinRefinery
{
	public partial class WinRefineryGUI : Form
	{
		public WinRefineryGUI()
		{
			if (!SystemRequirement.CheckWindows())
			{
				this.Load += (sender, e) =>
				{
					this.Close();
				};
			}

			InitializeComponent();
			OutputLogHandler.Initialize(this);
			backgroundBanner.MouseDown += GUIAppWindow_MouseDown;
			backgroundBanner.MouseMove += GUIAppWindow_MouseMove;
			backgroundBanner.MouseUp += GUIAppWindow_MouseUp;
			logoPicture.MouseDown += GUIAppWindow_MouseDown;
			logoPicture.MouseMove += GUIAppWindow_MouseMove;
			logoPicture.MouseUp += GUIAppWindow_MouseUp;
		}

		private async void btnRun_Click(object sender, EventArgs e)
		{
			try
			{
				await RestorePoint.StartCreatingTask();
				OutputLogHandler.AppendMessage("\n", Color.Black, false);
				switch (btnRun.Text)
				{
					case "Run Fixer":
						OutputLogHandler.AppendMessage($"Processing the fixer...", Color.Black, false);
						FixerSettings.RunCheckedFixers(this);
						break;
					case "Run App Uninstaller":
						break;
					case "Run Restore":
						break;
				}
			}
			catch (Exception ex)
			{
				OutputLogHandler.AppendMessage($"Error creating system restore point: {ex.Message}", Color.Red, true);
				return;
			}
		}

		private void btnRemoveBloatware_Click(object sender, EventArgs e)
		{
			try
			{
				//BloatPrograms bloatProgramsForm = new BloatPrograms(AppendMessage, this);
				//bloatProgramsForm.Show();
			}
			catch (Exception ex)
			{
				OutputLogHandler.AppendMessage($"Error opening Bloat Programs window: {ex.Message}", Color.Red, true);
				return;
			}
		}

		public async Task ExecuteDebloatingOperations()
		{
			/*
			if (chkRemoveAds.Checked)
			{
				OutputLogHandler.AppendMessage("\n", Color.Black,  false);
				OutputLogHandler.AppendMessage("Removing ads...", Color.Black, true);
				await Ads.ExecuteRemoveAds();
			}

			if (chkDisableTracking.Checked)
			{
				OutputLogHandler.AppendMessage("\n", Color.Black,  false);
				OutputLogHandler.AppendMessage("Disabling tracking...", Color.Black,  true);
				await Tracking.Disable();
			}

			if (chkOptimizeWindows.Checked)
			{
				OutputLogHandler.AppendMessage("\n", Color.Black,  false);
				OutputLogHandler.AppendMessage("Optimizing Windows...", Color.Black,  true);
				await Optimize.Optimize();
			}

			if (chkWingetUpdater.Checked)
			{
				OutputLogHandler.AppendMessage("\n", Color.Black,  false);
				OutputLogHandler.AppendMessage("Updating installed Winget packages...", Color.Black,  true);
				UpdateWinget();
			}

			if (chkSystemFileCheck.Checked)
			{
				OutputLogHandler.AppendMessage("\n", Color.Black,  false);
				OutputLogHandler.AppendMessage("Checking Windows system files...", Color.Green,  true);
				SFC();
			}

			if (chkRestart.Checked)
			{
				OutputLogHandler.AppendMessage("\n", Color.Black,  false);
				OutputLogHandler.AppendMessage("Restarting computer...", Color.Green,  true);
				await RestartComputer();
			}*/
		}

		private async Task RestartComputer()
		{
			try
			{
				System.Timers.Timer timer = new System.Timers.Timer(1000); // 1000 milliseconds = 5 seconds
				int countdown = 20;

				timer.Elapsed += (sender, e) =>
				{
					if (countdown > 0)
					{
						OutputLogHandler.AppendMessage($"Computer will restart in: {countdown} seconds", Color.Green, true);
						countdown--;
					}
					else
					{
						timer.Stop();
						Process.Start("shutdown", "/r /t 0");
					}
				};

				timer.Start();

				await Task.Delay(30000); // wait for 30 seconds
			}
			catch (Exception ex)
			{
				OutputLogHandler.AppendMessage($"Error restarting computer: {ex.Message}", Color.Red, true);
				return;
			}
		}

		private void btnFixer_Click(object sender, EventArgs e)
		{
			titleBox.Text = "Fixer";
			functionPanel.Controls.Clear();
			appCounter.Visible = false;
			btnFixer.BackColor = Color.LightBlue;
			btnApps.BackColor = Color.DarkGreen;
			btnRestore.BackColor = Color.DarkGreen;
			btnRestorePoint.BackColor = Color.DarkGreen;
			FixerSettings.BuildFixerList(this);
			btnAnalyze.Visible = true;
			btnAnalyze.Text = "Analyze what is turned on!";
			btnRun.Visible = true;
			btnRun.Text = "Run Fixer";
		}

		private void btnApps_Click(object sender, EventArgs e)
		{
			titleBox.Text = "Apps";
			functionPanel.Controls.Clear();
			btnApps.BackColor = Color.LightBlue;
			btnFixer.BackColor = Color.DarkGreen;
			btnRestore.BackColor = Color.DarkGreen;
			btnRestorePoint.BackColor = Color.DarkGreen;
			AppList.GetAppList(this);
			btnAnalyze.Visible = false;
			btnRun.Visible = true;
			btnRun.Text = "Run App Uninstaller";
		}

		private void btnRestore_Click(object sender, EventArgs e)
		{
			titleBox.Text = "Restore";
			functionPanel.Controls.Clear();
			btnApps.BackColor = Color.DarkGreen;
			btnFixer.BackColor = Color.DarkGreen;
			btnRestore.BackColor = Color.LightBlue;
			btnRestorePoint.BackColor = Color.DarkGreen;
			appCounter.Visible = false;
			btnAnalyze.Text = "Analyze what is not installed!";
			btnAnalyze.Visible = true;
			btnRun.Visible = true;
			btnRun.Text = "Run Restore";
		}
		private async void btnRestorePoint_Click(object sender, EventArgs e)
		{
			btnApps.BackColor = Color.DarkGreen;
			btnFixer.BackColor = Color.DarkGreen;
			btnRestore.BackColor = Color.DarkGreen;
			btnRestorePoint.BackColor = Color.LightBlue;
			functionPanel.Controls.Clear();
			titleBox.Text = "";
			appCounter.Visible = false;
			btnRun.Visible = false;
			btnAnalyze.Visible = false;

			await RestorePoint.StartCreatingTask();
		}

		private void btnDonation_Click(object sender, EventArgs e)
		{
			DonateGUI donateGUI = new DonateGUI();
			donateGUI.Show();
		}

		private void btnLicense_Click(object sender, EventArgs e)
		{
			AboutInfo.License();
		}

		private void btnAbout_Click(object sender, EventArgs e)
		{
			AboutInfo.AboutWinRefinery();
		}

		private void btnCloseWindow_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
