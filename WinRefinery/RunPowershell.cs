using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinRefinery
{
	internal class RunPowershell
	{
		public void Script(string script, bool setBool = true)
		{
			try
			{
				// Check if the directory exists
				if (script.StartsWith("Get-ChildItem") && script.Contains("-Path"))
				{
					string[] parts = script.Split(new[] { " -Path " }, StringSplitOptions.None);
					string path = parts[1].Trim('"');
					if (!Directory.Exists(path))
					{
						OutputLogHandler.AppendMessage($"Directory does not exist: {path}", Color.Black, false);
						return;
					}
				}

				var psi = new ProcessStartInfo
				{
					FileName = "powershell.exe",
					Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"{script}\"",
					UseShellExecute = setBool,
					RedirectStandardOutput = true,
					RedirectStandardError = true,
					CreateNoWindow = true
				};

				using (var process = Process.Start(psi))
				{
					if (process != null)
					{
						string output = process.StandardOutput.ReadToEnd();
						string error = process.StandardError.ReadToEnd();
						process.WaitForExit();

						if (process.ExitCode == 0)
						{
							OutputLogHandler.AppendMessage($"PowerShell command executed successfully: {script}", Color.Green, true);
							if (!string.IsNullOrEmpty(output))
							{
								OutputLogHandler.AppendMessage(output, Color.Black, false);
							}
						}
						else
						{
							OutputLogHandler.AppendMessage($"Error executing PowerShell command: {script}", Color.Red, true);
							if (!string.IsNullOrEmpty(error))
							{
								OutputLogHandler.AppendMessage(error, Color.Red, false);
							}
						}
					}
					else
					{
						OutputLogHandler.AppendMessage($"Failed to start PowerShell process for command: {script}", Color.Red, true);
					}
				}
			}
			catch (Exception ex)
			{
				OutputLogHandler.AppendMessage($"Error executing PowerShell command: {ex.Message}", Color.Red, true);
				return;
			}
		}
	}
}
