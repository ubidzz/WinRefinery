using System.Diagnostics;

namespace WinRefinery
{
	public partial class BloatPrograms : Form
	{
		//private readonly Progress_Tasks_Window OutputMessage_window;
		private readonly WinRefineryGUI Debloating;
		//private readonly CreatingRestorePoint RestorePoint;


		private async Task ExecuteDebloatingProgramsAsync(Array appList)
		{
			foreach (var app in appList)
			{
				var checkAppPsi = new ProcessStartInfo
				{
					FileName = "powershell.exe",
					Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"Get-AppxPackage -Name '{app}'\"",
					UseShellExecute = false,
					RedirectStandardOutput = true,
					RedirectStandardError = true,
					CreateNoWindow = true
				};

				using (var checkAppProcess = Process.Start(checkAppPsi))
				{
					if (checkAppProcess != null)
					{
						string checkAppOutput = await checkAppProcess.StandardOutput.ReadToEndAsync();
						string checkAppError = await checkAppProcess.StandardError.ReadToEndAsync();
						checkAppProcess.WaitForExit();

						if (string.IsNullOrEmpty(checkAppOutput))
						{
							AppendMessageSafe($"{app} is not installed.", Color.Blue, false);
							continue;
						}
					}
					else
					{
						AppendMessageSafe($"Failed to start process for checking {app}.", Color.Red, true);
						continue;
					}
				}

				var removeAppPsi = new ProcessStartInfo
				{
					FileName = "powershell.exe",
					Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"Get-AppxPackage -Name '{app}' | Remove-AppxPackage -AllUsers -ErrorAction SilentlyContinue\"",
					UseShellExecute = false,
					RedirectStandardOutput = true,
					RedirectStandardError = true,
					CreateNoWindow = true
				};

				using var removeAppProcess = Process.Start(removeAppPsi);
				if (removeAppProcess != null)
				{
					string removeAppOutput = await removeAppProcess.StandardOutput.ReadToEndAsync();
					string removeAppError = await removeAppProcess.StandardError.ReadToEndAsync();
					removeAppProcess.WaitForExit();

					if (removeAppProcess.ExitCode == 0)
					{
						AppendMessageSafe($"{app} uninstalled successfully.", Color.Green, false);
						if (!string.IsNullOrEmpty(removeAppOutput))
						{
							AppendMessageSafe(removeAppOutput, Color.Black, false);
						}
					}
					else
					{
						AppendMessageSafe($"Error uninstalling {app}: {removeAppError}", Color.Red, true);
					}
				}
				else
				{
					AppendMessageSafe($"Failed to start process for {app}.", Color.Red, true);
				}
			}
		}

		public async Task BuildProgramList()
		{
			string[] appxNames = new string[49];

			int index = 0;

			if (checkBox1.Checked) { appxNames[index++] = "*Microsoft.3DBuilder*"; }
			if (checkBox2.Checked) { appxNames[index++] = "*Microsoft.BingNews*"; }
			if (checkBox3.Checked) { appxNames[index++] = "*Microsoft.BingWeather*"; }
			if (checkBox4.Checked) { appxNames[index++] = "*Microsoft.Camera*"; }
			if (checkBox5.Checked) { appxNames[index++] = "*Microsoft.GetHelp*"; }
			if (checkBox6.Checked) { appxNames[index++] = "*Microsoft.Getstarted*"; }
			if (checkBox7.Checked) { appxNames[index++] = "*Microsoft.Microsoft3DViewer*"; }
			if (checkBox8.Checked) { appxNames[index++] = "*Microsoft.MicrosoftJournal*"; }
			if (checkBox9.Checked) { appxNames[index++] = "*Microsoft.MicrosoftOfficeHub*"; }
			if (checkBox10.Checked) { appxNames[index++] = "*Microsoft.MicrosoftSolitaireCollection*"; }
			if (checkBox11.Checked) { appxNames[index++] = "*Microsoft.MicrosoftStickyNotes*"; }
			if (checkBox12.Checked) { appxNames[index++] = "*Microsoft.MixedReality.Portal*"; }
			if (checkBox13.Checked) { appxNames[index++] = "*Microsoft.MSPaint*"; }
			if (checkBox14.Checked) { appxNames[index++] = "*Microsoft.Office.OneNote*"; }
			if (checkBox15.Checked) { appxNames[index++] = "*Microsoft.Office.Sway*"; }
			if (checkBox16.Checked) { appxNames[index++] = "*Microsoft.OneConnect*"; }
			if (checkBox17.Checked) { appxNames[index++] = "*Microsoft.OneDrive*"; }
			if (checkBox18.Checked) { appxNames[index++] = "*Microsoft.People*"; }
			if (checkBox19.Checked) { appxNames[index++] = "*Microsoft.Print3D*"; }
			if (checkBox20.Checked) { appxNames[index++] = "*Microsoft.SkypeApp*"; }
			if (checkBox21.Checked) { appxNames[index++] = "*Microsoft.Todos*"; }
			if (checkBox22.Checked) { appxNames[index++] = "*Microsoft.WindowsStore*"; }
			if (checkBox23.Checked) { appxNames[index++] = "*Microsoft.WindowsAlarms*"; }
			if (checkBox24.Checked) { appxNames[index++] = "*Microsoft.WindowsCalculator*"; }
			if (checkBox25.Checked) { appxNames[index++] = "*Microsoft.WindowsCamera*"; }
			if (checkBox26.Checked) { appxNames[index++] = "*Microsoft.WindowsFeedbackHub*"; }
			if (checkBox27.Checked) { appxNames[index++] = "*Microsoft.WindowsMaps*"; }
			if (checkBox28.Checked) { appxNames[index++] = "*Microsoft.WindowsNotepad*"; }
			if (checkBox29.Checked) { appxNames[index++] = "*Microsoft.Windows.Photos*"; }
			if (checkBox30.Checked) { appxNames[index++] = "*Microsoft.WindowsSoundRecorder*"; }
			if (checkBox31.Checked) { appxNames[index++] = "*Microsoft.Xbox.TCUI*"; }
			if (checkBox32.Checked) { appxNames[index++] = "*Microsoft.XboxApp*"; }
			if (checkBox33.Checked) { appxNames[index++] = "*Microsoft.XboxGameOverlay*"; }
			if (checkBox34.Checked) { appxNames[index++] = "*Microsoft.XboxGamingOverlay*"; }
			if (checkBox35.Checked) { appxNames[index++] = "*Microsoft.XboxSpeechToTextOverlay*"; }
			if (checkBox36.Checked) { appxNames[index++] = "*Microsoft.YourPhone*"; }
			if (checkBox37.Checked) { appxNames[index++] = "*Microsoft.ZuneMusic*"; }
			if (checkBox38.Checked) { appxNames[index++] = "*Microsoft.ZuneVideo*"; }
			if (checkBox39.Checked) { appxNames[index++] = "*SpotifyAB.SpotifyMusic*"; }
			if (checkBox40.Checked) { appxNames[index++] = "*TikTok.TikTok*"; }
			if (checkBox41.Checked) { appxNames[index++] = "*Facebook.Facebook*"; }
			if (checkBox42.Checked) { appxNames[index++] = "*Instagram.Instagram*"; }
			if (checkBox43.Checked) { appxNames[index++] = "*WhatsApp.WhatsApp*"; }
			if (checkBox44.Checked) { appxNames[index++] = "*AdobeSystemsIncorporated.AdobeExpress*"; }
			if (checkBox45.Checked) { appxNames[index++] = "*McAfee*"; }
			if (checkBox46.Checked) { appxNames[index++] = "*Norton*"; }
			if (checkBox47.Checked) { appxNames[index++] = "*ESPN*"; }
			if (checkBox48.Checked) { appxNames[index++] = "*LinkedIn.LinkedIn*"; }
			if (checkBox49.Checked) { appxNames[index++] = "*Flipgrid*"; }

			// Remove null values from the array
			appxNames = [.. appxNames.Where(x => x != null)];

			await ExecuteDebloatingProgramsAsync(appxNames);
		}

		private void AppendMessageSafe(string message, Color color, bool bold)
		{
			//if (OutputMessage_window == null || OutputMessage_window.IsDisposed) return;

			//if (OutputMessage_window.InvokeRequired)
			//{
			//	OutputMessage_window.Invoke((MethodInvoker)(() => AppendMessageInternal(message, color, bold)));
			//}
			//else
			//{
			//	AppendMessageInternal(message, color, bold);
			//}
		}

		private void AppendMessageInternal(string message, Color color, bool bold)
		{
			// Skip if OutputMessage_window is already disposed
			//if (OutputMessage_window == null || OutputMessage_window.IsDisposed) return;

			//OutputMessage_window.AppendMessage(message, color, OutputMessage_window.GetSelectionStart(), bold);
		}

		private void BtnSelectAll_Click(object sender, EventArgs e)
		{
			for (int i = 1; i <= 49; i++)
			{
				CheckBox? checkBox = (CheckBox?)this.Controls["checkBox" + i];
				if (checkBox != null)
				{
					checkBox.Checked = true;
				}
			}
		}

		private async void BtnUninstall_Click(object sender, EventArgs e)
		{
			//await RestorePoint.CreateRestorePoint();
		}

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private readonly Form tooltipForm = new();
		private readonly RichTextBox richTextBox = new();

		private void BloatPrograms_Load(object? sender, EventArgs e)
		{
			tooltipForm.FormBorderStyle = FormBorderStyle.None;
			tooltipForm.ShowInTaskbar = false;
			tooltipForm.Visible = false;

			richTextBox.Font = new Font("Arial", 10);
			richTextBox.ForeColor = Color.White;
			richTextBox.BackColor = Color.Black;
			richTextBox.Dock = DockStyle.Fill;
			tooltipForm.Controls.Add(richTextBox);

			for (int i = 1; i <= 49; i++)
			{
				AssignEventHandlers(i);
			}
		}

		private void AssignEventHandlers(int index)
		{
			Control? control = this.Controls["checkBox" + (index)];
			if (control is CheckBox checkBox)
			{
				checkBox.MouseEnter += (sender, e) =>
				{
					string text = GetToolTipText(index);
					richTextBox.Text = text;
					richTextBox.ScrollBars = RichTextBoxScrollBars.None;
					richTextBox.WordWrap = true;
					richTextBox.AutoSize = true;
					richTextBox.ReadOnly = true;
					richTextBox.BorderStyle = BorderStyle.None;
					Size size = richTextBox.GetPreferredSize(new Size(350, int.MaxValue));
					richTextBox.Size = size;
					Point point = checkBox.PointToScreen(new Point(0, 0));
					tooltipForm.Location = new Point(point.X, point.Y - size.Height - 5);
					tooltipForm.Size = size;
					tooltipForm.Visible = true;
					//MessageBox.Show(index.ToString()); // This should show the correct index
				};

				checkBox.MouseLeave += (sender, e) =>
				{
					tooltipForm.Visible = false;
				};
			}
		}

		private static string GetToolTipText(int index)
		{
			return index switch
			{
				1 => "3D Builder is a free Windows app from Microsoft that allows users to view, create, personalize, repair, and print 3D models. It's a user-friendly tool for both beginners and those with more experience in 3D modeling and printing.",
				2 => "Bing News is a section within the Bing search engine that provides news coverage from various sources. It offers customizable news feeds, topic-specific searches, and in-depth articles to keep users informed about trending stories, local events, and global news.",
				3 => "Microsoft Bing Weather, now referred to as MSN Weather, is a weather service provided by Microsoft that offers current and forecast weather information for various locations. It's accessible through the  Windows 10 weather app, and mobile apps. The service provides detailed weather data, including hourly, daily, and 10-day forecasts, and also includes features like interactive maps and weather alerts",
				4 => "The Camera app is a built-in Windows 10 and 11 app that allows users to capture photos and videos using their device's camera. It offers various features like photo editing, video recording, and sharing options.",
				5 => "Get Help is a Windows 10 and 11 app that provides users with support and troubleshooting resources for their device. It offers various features like online support, troubleshooting guides, and contact information for Microsoft support.",
				6 => "The Get Started app is a Windows 10 and 11 app that helps users get started with their device. It offers various features like tutorials, tips, and recommendations for using Windows 10.",
				7 => "Microsoft 3D Viewer is a Windows 10 and 11 app that allows users to view and interact with 3D models. It offers various features like model viewing, editing, and sharing options.",
				8 => "Microsoft Journal is a Windows 10 and 11 app that allows users to take notes and organize their thoughts. It offers various features like note-taking, organization, and sharing options.",
				9 => "Microsoft Office Hub is a Windows 10 and 11 app that provides users with access to Microsoft Office apps like Word, Excel, and PowerPoint. It offers various features like document editing, sharing, and collaboration options.",
				10 => "Microsoft Solitaire Collection is a Windows 10 and 11 app that offers various solitaire games like Klondike, Spider, and Freecell. It provides various features like game customization, scoring, and sharing options.",
				11 => "Microsoft Sticky Notes is a Windows 10 and 11 app that allows users to take notes and reminders. It offers various features like note-taking, organization, and sharing options.",
				12 => "Microsoft Mixed Reality Portal is a Windows 10 and 11 app that provides users with access to mixed reality experiences. It offers various features like MR experience browsing, launching, and sharing options.",
				13 => "Microsoft Paint is a Windows 10 and 11 app that allows users to create and edit images. It offers various features like image editing, drawing, and sharing options.",
				14 => "Microsoft OneNote is a Windows 10 and 11 app that allows users to take notes and organize their thoughts. It offers various features like note-taking, organization, and sharing options.",
				15 => "Microsoft Sway is a Windows 10 and 11 app that allows users to create and share interactive presentations. It offers various features like presentation creation, customization, and sharing options.",
				16 => "Microsoft OneConnect is a Windows 10 and 11 app that allows users to connect to their Microsoft account and access various Microsoft services. It offers various features like account management, service access, and sharing options.",
				17 => "Microsoft OneDrive is a Windows 10 and 11 app that allows users to store and access their files in the cloud. It offers various features like file storage, sharing, and collaboration options.",
				18 => "Microsoft People is a Windows 10 and 11 app that allows users to manage their contacts and relationships. It offers various features like contact management, messaging, and sharing options.",
				19 => "Microsoft Print 3D is a Windows 10 and 11 app that allows users to print 3D models. It offers various features like 3D model printing, customization, and sharing options.",
				20 => "Microsoft Skype is a Windows 10 and 11 app that allows users to make voice and video calls, send messages, and share files. It offers various features like communication, sharing, and collaboration options.",
				21 => "Microsoft To Do is a Windows 10 and 11 app that allows users to manage their tasks and reminders. It offers various features like task management, organization, and sharing options.",
				22 => "Microsoft Store is a Windows 10 and 11 app that allows users to discover, download, and install various apps and games. It offers various features like app browsing, purchasing, and installation options.",
				23 => "Microsoft Alarms & Clock is a Windows 10 and 11 app that allows users to set alarms, timers, and reminders. It offers various features like alarm management, timer customization, and sharing options.",
				24 => "Microsoft Calculator is a Windows 10 and 11 app that allows users to perform mathematical calculations. It offers various features like calculation, conversion, and sharing options.",
				25 => "Microsoft Camera is a Windows 10 and 11 app that allows users to capture photos and videos using their device's camera. It offers various features like photo editing, video recording, and sharing options.",
				26 => "Microsoft Feedback Hub is a Windows 10 and 11 app that allows users to provide feedback and suggestions for Windows 10. It offers various features like feedback submission, suggestion tracking, and sharing options.",
				27 => "Microsoft Maps is a Windows 10 and 11 app that allows users to view and interact with maps. It offers various features like map viewing, navigation, and sharing options.",
				28 => "Microsoft Notepad is a Windows 10 and 11 app that allows users to create and edit text files. It offers various features like text editing, formatting, and sharing options.",
				29 => "Microsoft Photos is a Windows 10 and 11 app that allows users to view, edit, and share photos. It offers various features like photo viewing, editing, and sharing options.",
				30 => "Microsoft Sound Recorder is a Windows 10 and 11 app that allows users to record and play back audio. It offers various features like audio recording, playback, and sharing options.",
				31 => "Microsoft Xbox TCUI is a Windows 10 and 11 app that allows users to access Xbox features and settings. It offers various features like Xbox settings management, game access, and sharing options.",
				32 => "Microsoft Xbox App is a Windows 10 and 11 app that allows users to access Xbox features and games. It offers various features like game access, Xbox settings management, and sharing options.",
				33 => "Microsoft Xbox Game Overlay is a Windows 10 and 11 app that allows users to access Xbox game features and settings. It offers various features like game settings management, game access, and sharing options.",
				34 => "Microsoft Xbox Gaming Overlay is a Windows 10 and 11 app that allows users to access Xbox gaming features and settings. It offers various features like gaming settings management, game access, and sharing options.",
				35 => "Microsoft Xbox Speech to Text Overlay is a Windows 10 and 11 app that allows users to access Xbox speech to text features and settings. It offers various features like speech to text settings management, game access, and sharing options.",
				36 => "Microsoft Your Phone is a Windows 10 and 11 app that allows users to access their phone's features and settings from their PC. It offers various features like phone settings management, file transfer, and sharing options.",
				37 => "Microsoft Zune Music is a Windows 10 and 11 app that allows users to access and manage their music library. It offers various features like music playback, library management, and sharing options.",
				38 => "Microsoft Zune Video is a Windows 10 and 11 app that allows users to access and manage their video library. It offers various features like video playback, library management, and sharing options.",
				39 => "Spotify Music is a Windows 10 and 11 app that allows users to access and stream music from Spotify. It offers various features like music streaming, playlist management, and sharing options.",
				40 => "TikTok is a Windows 10 and 11 app that allows users to create and share short-form videos. It offers various features like video creation, sharing, and community features.",
				41 => "Facebook is a Windows 10 and 11 app that allows users to access and manage their Facebook account. It offers various features like social networking, messaging, and sharing options.",
				42 => "Instagram is a Windows 10 and 11 app that allows users to access and manage their Instagram account. It offers various features like photo and video sharing, messaging, and community features.",
				43 => "WhatsApp is a Windows 10 and 11 app that allows users to access and manage their WhatsApp account. It offers various features like messaging, file transfer, and sharing options.",
				44 => "Adobe Express is a Windows 10 and 11 app that allows users to create and edit multimedia content. It offers various features like content creation, editing, and sharing options.",
				45 => "McAfee is a Windows 10 and 11 app that provides antivirus and security features to protect users' devices. It offers various features like virus scanning, malware removal, and security settings management.",
				46 => "Norton is a Windows 10 and 11 app that provides antivirus and security features to protect users' devices. It offers various features like virus scanning, malware removal, and security settings management.",
				47 => "ESPN is a Windows 10 and 11 app that allows users to access sports news, scores, and videos. It offers various features like sports news, live streaming, and sharing options.",
				48 => "LinkedIn is a Windows 10 and 11 app that allows users to access and manage their LinkedIn account. It offers various features like professional networking, job searching, and sharing options.",
				49 => "Flipgrid is a Windows 10 and 11 app that allows users to create and share short-form videos. It offers various features like video creation, sharing, and community features.",
				_ => "",
			};
		}
	}
}
