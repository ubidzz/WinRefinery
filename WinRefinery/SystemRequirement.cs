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
			bool os = false;

			try
			{
				// Check if the operating system is Windows
				RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");

				if (registryKey != null)
				{
					// Check if the operating system is Windows 11
					string versionString = registryKey.GetValue("DisplayVersion").ToString();
					if (versionString != null)
					{
						if (int.Parse(versionString) >= 22000)
						{
							// Check if the 24H2 update is installed
							string buildNumber = registryKey.GetValue("CurrentBuildNumber").ToString();
							if (buildNumber != null)
							{
								if (buildNumber.Contains("24H2"))
								{
									os = true;
								}
								else
								{
									MessageBox.Show(
										"The 24H2 update is not installed. Please install the 24H2 update before using WinRefinery.",
										"WinRefinery System Requirement",
										MessageBoxButtons.OK,
										MessageBoxIcon.Warning
									);
								}
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
						}
					}
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
			}

			return os;
		}
	}
}
