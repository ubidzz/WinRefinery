using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace WinRefinery
{
	internal class SystemRequirement
	{
		public static bool CheckWindows()
		{

			// Get the operating system version
			try
			{
				RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
				string versionString = registryKey.GetValue("DisplayVersion").ToString();
				string buildNumber = registryKey.GetValue("CurrentBuildNumber").ToString();

				// Check if the operating system is Windows 11
				if (int.Parse(buildNumber) >= 22000)
				{
					// Check if the 24H2 update is installed
					if (versionString.Contains("24H2"))
					{
						return true;
					}
					else
					{
						MessageBox.Show(
							"The 24H2 update is not installed. Please install the 24H2 update before using WinRefinery.",
							"WinRefinery System Requirement",
							MessageBoxButtons.OK,
							MessageBoxIcon.Warning
						);
						return false;
					}
				}
				else
				{
					Console.WriteLine("Not Windows 11");
					MessageBox.Show(
						"Windows 11 is not installed. Please install the update before using WinRefinery.",
						"WinRefinery System Requirement",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning
					);
					return false;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					$"There was an error -> {ex}",
					"WinRefinery System Requirement",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning
				);
				return false;
			}
		}
	}
}
