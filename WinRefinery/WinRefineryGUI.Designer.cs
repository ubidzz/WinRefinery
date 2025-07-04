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
		public Panel functionPanel;
		public Label appCounter;
		public RichTextBox logOutput;

		public WinRefineryGUI()
		{
			InitializeComponent();
			versionText.Text = "v" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
		}

		private async void btnRun_Click(object sender, EventArgs e)
		{
			try
			{
				await RestorePoint.StartCreatingTask();
				switch (btnRun.Text)
				{
					case "Run Fixer":
						//await ExecuteDebloatingOperations();
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
			if (chkRemoveAds.Checked)
			{
				OutputLogHandler.AppendMessage("\n", Color.Black,  false);
				OutputLogHandler.AppendMessage("Removing ads...", Color.Black, true);
				await Ads.ExecuteRemoveAds();
			}
/*
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

		private void UpdateWinget()
		{
			Process process = new Process();
			process.StartInfo.FileName = "cmd.exe";
			process.StartInfo.Arguments = "/c winget update --all";
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.RedirectStandardError = true;
			process.StartInfo.CreateNoWindow = true;

			process.OutputDataReceived += (sender, data) =>
			{
				if (data.Data != null)
				{
					//AppendMessage.Invoke((MethodInvoker)delegate
					//{
					OutputLogHandler.AppendMessage(data.Data, Color.Black, false);
					//});
				}
			};

			process.ErrorDataReceived += (sender, data) =>
			{
				if (data.Data != null)
				{
					//AppendMessage.Invoke((MethodInvoker)delegate
					//{
					OutputLogHandler.AppendMessage(data.Data, Color.Red, true);
					//});
				}
			};

			process.Start();
			process.BeginOutputReadLine();
			process.BeginErrorReadLine();
		}

		private void SFC()
		{
			OutputLogHandler.AppendMessage("Running sfc /scannow...", Color.Black, false);

			Process process = new Process();
			process.StartInfo.FileName = "powershell.exe";
			process.StartInfo.Arguments = "/c sfc /scannow";
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.RedirectStandardError = true;
			process.StartInfo.CreateNoWindow = false;

			process.OutputDataReceived += (sender, data) =>
			{
				if (data.Data != null)
				{
					//AppendMessage.Invoke((System.Reflection.MethodInvoker)delegate
					//{
					OutputLogHandler.AppendMessage(data.Data, Color.Black, false);
					//});
				}
			};

			process.Start();
			process.BeginOutputReadLine();
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
			btnAnalyze.Visible = true;
			btnAnalyze.Text = "Analyze what is installed!";
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
			System.Diagnostics.Process.Start(new ProcessStartInfo { FileName = "https://www.paypal.com/donate/?hosted_button_id=6SML6HZVTG6E8", UseShellExecute = true });
		}

		private void btnLicense_Click(object sender, EventArgs e)
		{
			MessageBox.Show(
				"Copyright 2025 Jason Turner\n" +
				"All Rights Reserved.\n\n" +
				"This software, “WinRefinery”, is licensed, not sold.\n\n" +
				"You are granted a non-exclusive, non-transferable, revocable license to use this software for personal or internal business purposes only. \n\n" +
				"You MAY NOT:\n" +
				"- Sell, distribute, sublicense, lease, or rent this software.\n" +
				"- Modify, reverse engineer, or repackage the software.\n" +
				"- Rename or rebrand this software or create derivative works under a different name.\n" +
				"- Use this software for unlawful purposes.\n\n" +
				"You MAY:\n" +
				"- Use the software on your personal or company-owned Windows 11 systems.\n" +
				"- Share screenshots or reviews with proper attribution.\n\n" +
				"Unauthorized use, reproduction, distribution, or modification of this software is strictly prohibited and constitutes a violation of copyright law.\n\n" +
				"### Disclaimer of Warranty and Liability:\n\n" +
				"This software is provided \"AS IS\", without warranty of any kind, express or implied.  \n" +
				"You assume full responsibility for the installation, use, and any consequences resulting from the use of this software.\n\n" +
				"In no event shall the author (Jason Turner) be held liable for any direct, indirect, incidental, special, or consequential damages, including data loss or system malfunction, arising from the use or inability to use this software.\n\n" +
				"Use of this software indicates your acceptance of these terms.",
				"WinRefinery License Agreement",
				MessageBoxButtons.OK,
				MessageBoxIcon.Information
			);
		}
	}
}
