using Microsoft.Win32;
using System.Text.RegularExpressions;

namespace WinRefinery
{
	internal class InstalledApps
	{
		public static List<string> GetInstalledApps()
		{
			List<string> installedApps = [];

			// Check if the system is 64-bit
			if (Environment.Is64BitOperatingSystem)
			{
				// Get the uninstall registry key for 64-bit apps
				RegistryKey? uninstallKey64 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");

				// Check if the uninstall key for 64-bit apps exists
				if (uninstallKey64 != null)
				{
					// Iterate over the subkeys for 64-bit apps
					foreach (string subKeyName in uninstallKey64.GetSubKeyNames())
					{
						RegistryKey? subKey = uninstallKey64.OpenSubKey(subKeyName);

						if (subKey != null)
						{
							// Get the publisher of the app
							_ = subKey.GetValue("Publisher") as string;

							// Check if the app is not a Windows app
							if (subKey.GetValue("DisplayName") is string displayName && subKey.GetValue("DisplayVersion") is string displayVersion && subKey.GetValue("InstallLocation") is string installLocation && !installLocation.StartsWith("C:\\Windows") && !installLocation.StartsWith("C:\\ProgramData"))
							{

								// Check if the app is installed in the Program Files directory
								if (installLocation.StartsWith("C:\\Program Files") || installLocation.StartsWith("C:\\Program Files (x86)"))
								{
									// Check if the app has a display Version
									string appInfo = displayName;
									appInfo = Regex.Replace(appInfo, @"-[\d\.]+|[\d]+|\(32bit\)|\(64bit\)|-bit|\.|\+|\(|\)|en-US", "", RegexOptions.IgnoreCase);
									if (!string.IsNullOrEmpty(displayVersion))
									{
										if (displayVersion != null && displayVersion != "")
										{
											appInfo += " - v" + displayVersion;
										}
									}
									installedApps.Add(appInfo);
								}
							}
						}
					}

					// Get the uninstall registry key for 32-bit apps
					RegistryKey? uninstallKey32 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall");

					// Check if the uninstall key for 32-bit apps exists
					if (uninstallKey32 != null)
					{
						// Iterate over the subkeys for 32-bit apps
						foreach (string subKeyName in uninstallKey32.GetSubKeyNames())
						{
							RegistryKey? subKey = uninstallKey32.OpenSubKey(subKeyName);

							if (subKey != null)
							{
								// Check if the app is not a Windows app
								if (subKey.GetValue("DisplayName") is string displayName && subKey.GetValue("DisplayVersion") is string displayVersion && subKey.GetValue("InstallLocation") is string installLocation && !installLocation.StartsWith("C:\\Windows") && !installLocation.StartsWith("C:\\ProgramData"))
								{
									// Check if the app is installed in the Program Files directory
									if (installLocation.StartsWith("C:\\Program Files") || installLocation.StartsWith("C:\\Program Files (x86)"))
									{
										// Check if the app has a display Version
										string appInfo = displayName;
										appInfo = Regex.Replace(appInfo, @"-[\d\.]+|[\d]+|\(32bit\)|\(64bit\)|-bit|\.|\+|\(|\)|en-US", "", RegexOptions.IgnoreCase);
										if (!string.IsNullOrEmpty(displayVersion))
										{
											if (displayVersion != null && displayVersion != "")
											{
												appInfo += " - v" + displayVersion;
											}
										}
										installedApps.Add(appInfo);
									}
								}
							}
						}
					}
				}
			}
			else
			{
				// Get the uninstall registry key for 32-bit apps
				RegistryKey? uninstallKey32 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");

				// Check if the uninstall key for 32-bit apps exists
				if (uninstallKey32 != null)
				{
					// Iterate over the subkeys for 32-bit apps
					foreach (string subKeyName in uninstallKey32.GetSubKeyNames())
					{
						RegistryKey? subKey = uninstallKey32.OpenSubKey(subKeyName);

						if (subKey != null)
						{
							// Check if the app is not a Windows app
							if (subKey.GetValue("DisplayName") is string displayName && subKey.GetValue("DisplayVersion") is string displayVersion && subKey.GetValue("InstallLocation") is string installLocation && !installLocation.StartsWith("C:\\Windows") && !installLocation.StartsWith("C:\\ProgramData"))
							{
								// Check if the app is installed in the Program Files directory
								if (installLocation.StartsWith("C:\\Program Files") || installLocation.StartsWith("C:\\Program Files (x86)"))
								{
									// Check if the app has a display Version
									string appInfo = displayName;
									appInfo = Regex.Replace(appInfo, @"-[\d\.]+|[\d]+|\(32bit\)|\(64bit\)|-bit|\.|\+|\(|\)|en-US", "", RegexOptions.IgnoreCase);
									if (!string.IsNullOrEmpty(displayVersion))
									{
										if (displayVersion != null && displayVersion != "")
										{
											appInfo += " - v" + displayVersion;
										}
									}
									installedApps.Add(appInfo);
								}
							}
						}
					}
				}
			}
			return installedApps;
		}
	}
}