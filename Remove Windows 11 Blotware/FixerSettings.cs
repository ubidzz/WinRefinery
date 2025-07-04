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
				CheckBox selectAllCheckBox = new CheckBox();
				selectAllCheckBox.Text = categories[i];
				selectAllCheckBox.Location = new Point(10, y);
				selectAllCheckBox.Font = new Font("Arial", 10, FontStyle.Bold);

				List<CheckBox> checkBoxes = new List<CheckBox>();
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

				Label label = new Label();
				label.Text = categories[i];
				label.Location = new Point(30, y);
				WinRefineryGUI.functionPanel.Controls.Add(label);

				y += 20;

				// Add the checkboxes for the current category
				for (int j = 0; j < checkboxes[i].Length; j++)
				{
					CheckBox checkBox = new CheckBox();
					checkBox.Text = checkboxes[i][j];
					checkBox.Location = new Point(30, y);
					checkBox.Width = 250; // Set the width of the checkbox
					checkBox.CheckedChanged += (sender1, e1) =>
					{
						if (checkBox.Checked)
						{
							// Do something when the checkbox is checked
						}
						else
						{
							// Do something when the checkbox is unchecked
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
	}
}
