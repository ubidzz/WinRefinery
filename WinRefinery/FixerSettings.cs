using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinRefinery
{
	internal class FixerSettings
	{
		public static string[] FixerCategoriesList()
		{
			string[] categories = [
				"Issues",
				"System",
				"MS Edge",
				"Ads",
				"AI",
				"UI",
				"Gaming",
				"Privacy",
				"Extras"
			];
			return categories;
		}
		public static string[][] FixerCheckboxList()
		{
			string[][] checkboxes = [
				// Issues
				[
					"Basic Disk Cleanup",
					"Winget App Updates",
				],

				// System
				[
					"Show BSOD details instead of sad smiley",
					"Enable Verbose Logon status messages",
					"Speed up Shutdown Time",
					"Disable Network Throttling",
					"Optimize System Responsivness",
					"Speed Up Menu Show Delay",
					"Enable End Task",
					"Enable Numlock on Logon Screen"
				],

				// MS Edge
				[
					"Disable Browser sign-in and sync services",
					"Don't show Sponsored Links in new tabs pages",
					"Disable Microsoft edge as default browser",
					"Disable Access to collections feature",
					"Disable Shopping Assistant",
					"Don't Show First Run Eperience",
					"Disable Gamer Mode",
					"Disable Copilot Symbol in Edge",
					"Don't Allow Import of data from other browsers",
					"Disable Start Boost",
					"Don't Show Quick Links in new tabs page",
					"Don't Submit user feedback options"
				],

				// Ads
				[
					"Disable File Explorer Ads",
					"Disable Finish Setup Ads",
					"Disable Lock Screen Tips and Ads",
					"Disable Personalized Ads",
					"Disable Settings Ads",
					"Disable Start Menu Ads",
					"Disable Tailored Experiences",
					"Disable Gerneral Tips and Ads",
					"Disable welcome Experience Ads"
				],

				// AI
				[
					"Don't Show Copilot in Taskbar",
					"Turn off Recall in Windows 11"
				],

				//UI
				[
					"Show Full context menu in Windows 11",
					"Don't use personalized lock screen",
					"Hide search box on taskbar",
					"Hide Most used apps in start menu",
					"Hide Task view button on taskbar",
					"Disable Search box suggestions",
					"Pin more Apps on start menu",
					"Align Start button to left",
					"Disable Transparent Effects",
					"Enable Dark Mode for Apps",
					"Enable Dark Mode for System",
					"Disable Snap Assist Flyout"
				],

				// Gaming
				[
					"Disable Game DVR",
					"Disable Power Throttling",
					"Disable Visual Effects"
				],

				// Privacy
				[
					"Disable active history",
					"Disable location tracking",
					"Disable privacy Settings Experience at sign-in",
					"Turn off Telemetry data collection"
				],

				// Extras
				[
					"Install the latest Powershell version",
					"Install Microsoft PC Manager"
				]
			];
			return checkboxes;
		}


		public static void BuildFixerList(WinRefineryGUI WinRefineryGUI)
		{
			// Define the categories and their corresponding checkboxes
			string[] categories = FixerCategoriesList();
			string[][] checkboxes = FixerCheckboxList();

			// Create a panel to hold the checkboxes
			WinRefineryGUI.functionPanel.AutoScroll = true;
			WinRefineryGUI.functionPanel.AutoScrollMinSize = new Size(0, 1000); // Set the minimum size to a larger value

			// Add the categories and checkboxes to the panel
			int y = 10;
			for (int i = 0; i < categories.Length; i++)
			{
				// Add a "Select All" checkbox for the current category
				CheckBox selectAllCheckBox = new()
				{
					Text = categories[i],
					Location = new Point(10, y),
					Font = new Font("Arial", 10, FontStyle.Bold)
				};

				List<CheckBox> checkBoxes = [];
				selectAllCheckBox.CheckedChanged += (sender1, e1) =>
				{
					if (selectAllCheckBox.Checked)
					{
						// Toggle the state of all checkboxes in this category
						foreach (CheckBox checkBox in checkBoxes)
						{
							checkBox.Checked = true;
						}
					}
					else
					{
						// Toggle the state of all checkboxes in this category
						foreach (CheckBox checkBox in checkBoxes)
						{
							checkBox.Checked = false;
						}
					}
				};

				WinRefineryGUI.functionPanel.Controls.Add(selectAllCheckBox);

				Label label = new()
				{
					Text = categories[i],
					Location = new Point(30, y)
				};
				WinRefineryGUI.functionPanel.Controls.Add(label);

				y += 20;

				// Add the checkboxes for the current category
				for (int j = 0; j < checkboxes[i].Length; j++)
				{
					CheckBox checkBox = new()
					{
						Text = checkboxes[i][j],
						Location = new Point(30, y),
						Width = 250 // Set the width of the checkbox
					};
					checkBox.CheckedChanged += (sender1, e1) =>
					{
						if (checkBox.Checked)
						{
							// Do something when the checkbox is checked
						}
					};

					checkBoxes.Add(checkBox);
					WinRefineryGUI.functionPanel.Controls.Add(checkBox);
					y += 20;
				}

				// Add a blank line to separate the categories
				y += 10;
			}
		}

		public static async Task RunCheckedFixersAsync(WinRefineryGUI WinRefineryGUI)
		{
			// Get the checkboxes from the functionPanel
			var checkboxes = WinRefineryGUI.functionPanel.Controls.OfType<CheckBox>().ToList();

			// Loop through the checkboxes and check their state
			foreach (var checkBox in checkboxes)
			{
				if (checkBox.Checked)
				{
					// Run different code based on the checkbox's text
					switch (checkBox.Text)
					{
						// Issues
						case "Basic Disk Cleanup":
							// Code to perform basic disk cleanup
							break;
						case "Winget App Updates":
							// Code to update Winget apps
							break;

						// System
						case "Show BSOD details instead of sad smiley":
							// Code to show BSOD details instead of sad smiley
							OutputLogHandler.AppendMessage($"Show BSOD details instead of sad smiley", Color.Black, false);
							break;
						case "Enable Verbose Logon status messages":
							// Code to enable verbose logon status messages
							break;
						case "Speed up Shutdown Time":
							// Code to speed up shutdown time
							break;
						case "Disable Network Throttling":
							// Code to disable network throttling
							break;
						case "Optimize System Responsivness":
							// Code to optimize system responsiveness
							break;
						case "Speed Up Menu Show Delay":
							// Code to speed up menu show delay
							break;
						case "Enable End Task":
							// Code to enable end task
							break;
						case "Enable Numlock on Logon Screen":
							// Code to enable numlock on logon screen
							break;

						// MS Edge
						case "Disable Browser sign-in and sync services":
							// Code to disable browser sign-in and sync services
							await EditRegistry.SetItemProperty(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Edge", "BrowserSignin", 0);
							await EditRegistry.SetItemProperty(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Edge", "SyncDisabled", 1);
							await EditRegistry.SetItemProperty(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Edge", "HideFirstRunExperience", 1);
							break;
						case "Don't show Sponsored Links in new tabs pages":
							// Code to not show sponsored links in new tabs pages
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\MicrosoftEdge\NewTabPage", "AllowSponsoredContent", 0);
							break;
						case "Disable Microsoft edge as default browser":
							// Code to disable Microsoft Edge as default browser
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.html\UserChoice", "Progid", "");
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.htm\UserChoice", "Progid", "");
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.xhtml\UserChoice", "Progid", "");
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.pdf\UserChoice", "Progid", "");
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.shtml\UserChoice", "Progid", "");
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.xht\UserChoice", "Progid", "");
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.hta\UserChoice", "Progid", "");
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.htc\UserChoice", "Progid", "");
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.mht\UserChoice", "Progid", "");
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.mhtml\UserChoice", "Progid", "");
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.url\UserChoice", "Progid", "");
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.webp\UserChoice", "Progid", "");
							break;
						case "Disable Access to collections feature":
							// Code to disable access to collections feature
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\MicrosoftEdge\Main", "CollectionsEnabled", 0);
							break;
						case "Disable Shopping Assistant":
							// Code to disable shopping assistant
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\MicrosoftEdge\ShoppingAssistant", "Enabled", 0);
							break;
						case "Don't Show First Run Eperience":
							// Code to not show first run experience
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\MicrosoftEdge\Main", "HideFirstRunExperience", 1);
							break;
						case "Disable Gamer Mode":
							// Code to disable gamer mode
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\MicrosoftEdge\Gaming", "GamerModeEnabled", 0);
							break;
						case "Disable Copilot Symbol in Edge":
							// Code to disable copilot symbol in Edge
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\MicrosoftEdge\Main", "CopilotEnabled", 0);
							break;
						case "Don't Allow Import of data from other browsers":
							// Code to not allow import of data from other browsers
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\MicrosoftEdge\Main", "AllowImportFromOtherBrowsers", 0);
							break;
						case "Disable Start Boost":
							// Code to disable start boost
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\MicrosoftEdge\StartBoost", "Enabled", 0);
							break;
						case "Don't Show Quick Links in new tabs page":
							// Code to not show quick links in new tabs page
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\MicrosoftEdge\NewTabPage", "ShowQuickLinks", 0);
							break;
						case "Don't Submit user feedback options":
							// Code to not submit user feedback options
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\MicrosoftEdge\Feedback", "SubmitFeedbackEnabled", 0);
							break;

						// Ads
						case "Disable File Explorer Ads":
							// Code to disable file explorer ads
							break;
						case "Disable Finish Setup Ads":
							// Code to disable finish setup ads
							break;
						case "Disable Lock Screen Tips and Ads":
							// Code to disable lock screen tips and ads
							break;
						case "Disable Personalized Ads":
							// Code to disable personalized ads
							break;
						case "Disable Settings Ads":
							// Code to disable settings ads
							break;
						case "Disable Start Menu Ads":
							// Code to disable start menu ads
							break;
						case "Disable Tailored Experiences":
							// Code to disable tailored experiences
							break;
						case "Disable Gerneral Tips and Ads":
							// Code to disable general tips and ads
							break;
						case "Disable welcome Experience Ads":
							// Code to disable welcome experience ads
							break;

						// AI
						case "Don't Show Copilot in Taskbar":
							// Code to not show copilot in taskbar
							break;
						case "Turn off Recall in Windows 11":
							// Code to turn off recall in Windows 11
							break;

						// UI
						case "Show Full context menu in Windows 11":
							// Code to show full context menu in Windows 11
							break;
						case "Don't use personalized lock screen":
							// Code to not use personalized lock screen
							break;
						case "Hide search box on taskbar":
							// Code to hide search box on taskbar
							break;
						case "Hide Most used apps in start menu":
							// Code to hide most used apps in start menu
							break;
						case "Hide Task view button on taskbar":
							// Code to hide task view button on taskbar
							break;
						case "Disable Search box suggestions":
							// Code to disable search box suggestions
							break;
						case "Pin more Apps on start menu":
							// Code to pin more apps on start menu
							break;
						case "Align Start button to left":
							// Code to align start button to left
							break;
						case "Disable Transparent Effects":
							// Code to disable transparent effects
							break;
						case "Enable Dark Mode for Apps":
							// Code to enable dark mode for apps
							break;
						case "Enable Dark Mode for System":
							// Code to enable dark mode for system
							break;
						case "Disable Snap Assist Flyout":
							// Code to disable snap assist flyout
							break;

						// Gaming
						case "Disable Game DVR":
							// Code to disable game DVR
							break;
						case "Disable Power Throttling":
							// Code to disable power throttling
							break;
						case "Disable Visual Effects":
							// Code to disable visual effects
							break;

						// Privacy
						case "Disable active history":
							// Code to disable active history
							break;
						case "Disable location tracking":
							// Code to disable location tracking
							break;
						case "Disable privacy Settings Experience at sign-in":
							// Code to disable privacy settings experience at sign-in
							break;
						case "Turn off Telemetry data collection":
							// Code to turn off telemetry data collection
							break;

						// Extras
						case "Install the latest Powershell version":
							// Code to install the latest Powershell version
							break;
						case "Install Microsoft PC Manager":
							// Code to install Microsoft PC Manager
							break;

						default:
							// Handle unknown checkbox text
							break;
					}
				}
			}
		}
	}
}
