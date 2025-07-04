using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinRefinery
{
	internal class AppList
	{
		public static void GetAppList(WinRefineryGUI WinRefineryGUI)
		{
			List<string> installedApps = InstalledApps.GetInstalledApps();
			installedApps = installedApps.OrderBy(app => app).ToList(); // Sort the apps by alphabet
			int appCount = installedApps.Count;

			WinRefineryGUI.appCounter.Visible = true;
			WinRefineryGUI.appCounter.Text = "You have " + appCount.ToString() + " installed apps";

			WinRefineryGUI.functionPanel.AutoScroll = true;
			WinRefineryGUI.functionPanel.AutoScrollMinSize = new Size(0, 1000); // Set the minimum size to a larger value

			// Create a checkbox for each installed app
			int y = 0;
			foreach (string app in installedApps)
			{
				CheckBox checkBox = new CheckBox();
				checkBox.Text = app;
				checkBox.Location = new Point(10, y);
				checkBox.AutoSize = true;
				WinRefineryGUI.functionPanel.Controls.Add(checkBox);

				y += 25;
			}
		}
	}
}
