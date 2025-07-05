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
					"Turn off Recall in Windows 11",
					"Disable AI-powered suggestions",
					"Disable AI-powered search",
					"Disable AI-powered Cortana",
					"Disable AI-powered Windows Search",
					"Disable AI-powered Microsoft Edge",
					"Disable AI-powered Office"
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
							await EditRegistry.SetItemProperty(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Debug", "DisplayDisabled", 0);
							break;
						case "Enable Verbose Logon status messages":
							await EditRegistry.SetItemProperty(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System", "verbosestatus", 1);
							break;
						case "Speed up Shutdown Time":
							await EditRegistry.SetItemProperty(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management", "ClearPageFileAtShutdown", 1);
							await EditRegistry.SetItemProperty(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management", "PagingFiles", 0);
							break;
						case "Disable Network Throttling":
							await EditRegistry.SetItemProperty(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Psched", "NonBestEffortLimit", 0);
							break;
						case "Optimize System Responsivness":
							await EditRegistry.SetItemProperty(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management", "LargeSystemCache", 0);
							break;
						case "Speed Up Menu Show Delay":
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\Control Panel\Desktop", "MenuShowDelay", 0);
							break;
						case "Enable End Task":
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\Control Panel\Desktop", "AutoEndTasks", 1);
							break;
						case "Enable Numlock on Logon Screen":
							await EditRegistry.SetItemProperty(@"HKEY_USERS\.DEFAULT\Control Panel\Keyboard", "InitialKeyboardIndicators", 2);
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
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "ShowSyncProviderNotifications", 0);
							break;
						case "Disable Finish Setup Ads":
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", "SubscribedContent-338388Enabled", 0);
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", "SubscribedContent-338389Enabled", 0);
							break;
						case "Disable Lock Screen Tips and Ads":
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", "LockScreenTipsEnabled", 0);
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", "RotatingLockScreenEnabled", 0);
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", "RotatingLockScreenOverlayEnabled", 0);
							break;
						case "Disable Personalized Ads":
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\AdvertisingInfo", "Enabled", 0);
							break;
						case "Disable Settings Ads":
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", "SettingsPageSuggestionsEnabled", 0);
							break;
						case "Disable Start Menu Ads":
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", "SystemMaintenanceEnabled", 0);
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", "PreInstalledAppsEnabled", 0);
							break;
						case "Disable Tailored Experiences":
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", "TailoredExperiencesWithDiagnosticDataEnabled", 0);
							break;
						case "Disable General Tips and Ads":
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", "SoftLandingEnabled", 0);
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", "PreInstalledAppsEnabled", 0);
							break;
						case "Disable Welcome Experience Ads":
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", "WelcomeExperienceEnabled", 0);
							break;

						// AI
						case "Disable AI-powered suggestions":
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", "AI-poweredSuggestionsEnabled", 0);
							break;
						case "Disable AI-powered search":
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", "AI-poweredSearchEnabled", 0);
							break;
						case "Disable AI-powered Cortana":
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", "CortanaEnabled", 0);
							break;
						case "Disable AI-powered Windows Search":
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", "WindowsSearchEnabled", 0);
							break;
						case "Disable AI-powered Microsoft Edge":
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\MicrosoftEdge", "AI-poweredEdgeEnabled", 0);
							break;
						case "Disable AI-powered Office":
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Office", "AI-poweredOfficeEnabled", 0);
							break;
						case "Don't Show Copilot in Taskbar":
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", "CopilotInTaskbarEnabled", 0);
							break;
						case "Turn off Recall in Windows 11":
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", "RecallEnabled", 0);
							break;

						// UI
						case "Show Full context menu in Windows 11":
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "FullContextMenu", 1);
							break;
						case "Don't use personalized lock screen":
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", "LockScreenPersonalizationEnabled", 0);
							break;
						case "Hide search box on taskbar":
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Search", "SearchBoxTaskbarMode", 0);
							break;
						case "Hide Most used apps in start menu":
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows\CurrentVersion\Explorer", "HideMostUsedApps", 1);
							break;
						case "Hide Task view button on taskbar":
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "ShowTaskViewButton", 0);
							break;
						case "Disable Search box suggestions":
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", "SearchBoxSuggestionsEnabled", 0);
							break;
						case "Pin more Apps on start menu":
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "Start_PlaceHoldEntries_Max", 20);
							break;
						case "Align Start button to left":
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "TaskbarAl", 0);
							break;
						case "Disable Transparent Effects":
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Themes\Personalize", "EnableTransparency", 0);
							break;
						case "Enable Dark Mode for Apps":
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Themes\Personalize", "AppsUseLightTheme", 0);
							break;
						case "Enable Dark Mode for System":
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Themes\Personalize", "SystemUsesLightTheme", 0);
							break;
						case "Disable Snap Assist Flyout":
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "SnapAssistFlyoutEnabled", 0);
							break;

						// Gaming
						case "Disable Game DVR":
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows\GameDVR", "AllowGameDVR", 0);
							break;
						case "Disable Power Throttling":
							await EditRegistry.SetItemProperty(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Power\PowerThrottling", "PowerThrottling", 0);
							break;
						case "Disable Visual Effects":
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects", "VisualFXSetting", 3);
							break;

						// Privacy
						case "Disable active history":
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\SettingSync\Groups\windows.web", "Enabled", 0);
							break;
						case "Disable location tracking":
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\DeviceAccess\Global\Location", "Value", 2);
							break;
						case "Disable privacy Settings Experience at sign-in":
							await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", "PrivacySettingsExperienceEnabled", 0);
							break;
						case "Turn off Telemetry data collection":
							await EditRegistry.SetItemProperty(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\DataCollection", "AllowTelemetry", 0);
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
