using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinRefinery
{
	internal class EditRegistry
	{
		public static async Task SetItemProperty(string path, string name, object value)
		{
			try
			{
				// Check if the registry key exists
				string[] parts = path.Split('\\');
				string hive = parts[0].ToUpper();
				string subKey = string.Join("\\", parts, 1, parts.Length - 1);
				RegistryKey baseKey;
				if (hive == "HKEY_LOCAL_MACHINE")
				{
					baseKey = Registry.LocalMachine;
				}
				else if (hive == "HKEY_CURRENT_USER")
				{
					baseKey = Registry.CurrentUser;
				}
				else
				{
					throw new ArgumentException("Invalid registry hive name: " + hive);
				}
				string[] pathParts = subKey.Split('\\');
				RegistryKey key = baseKey;
				foreach (string part in pathParts)
				{
					if (part != "SOFTWARE")
					{
						RegistryKey? registryKey = await Task.Run(() => key.OpenSubKey(part, true));
						key = registryKey ?? await Task.Run(() => baseKey.CreateSubKey(subKey, true));
					}
				}
				if (key == null)
				{
					OutputLogHandler.AppendMessage($"Registry key does not exist: {path}", Color.Black, false);
					return;
				}

				// Check if the DWORD value exists
				if (key.GetValue(name) == null)
				{
					// Create the DWORD value if it doesn't exist
					await Task.Run(() => key.SetValue(name, Convert.ToInt32(value), RegistryValueKind.DWord));
				}
				else
				{
					// Update the DWORD value if it already exists
					await Task.Run(() => key.SetValue(name, Convert.ToInt32(value), RegistryValueKind.DWord));
				}

				OutputLogHandler.AppendMessage($"Registry key {path} set {name} to {value}.", Color.Black, false);
			}
			catch (Exception ex)
			{
				OutputLogHandler.AppendMessage($"Error setting registry key {path} with name {name}: {ex.Message}", Color.Red, true);
				return;
			}
		}
	}
}
