namespace WinRefinery
{
	internal class OptimizeWindows()
	{
		private RunPowershell RunPowershell;
		private EditRegistry EditRegistry;

		public async Task Optimize()
		{
			try
			{
				OutputLogHandler.AppendMessage("Stopping Windows Search service...", Color.Black, false);
				RunPowershell.Script("Stop-Service -Name \"WSearch\" -Force; Set-Service -Name \"WSearch\" -StartupType Disabled", false);
				OutputLogHandler.AppendMessage("Windows Search service stopped successfully.", Color.Green, true);

				OutputLogHandler.AppendMessage("Setting power plan to Ultimate Performance...", Color.Black, false);
				RunPowershell.Script("powercfg /setactive SCHEME_MIN", false);
				OutputLogHandler.AppendMessage("Power plan set to Ultimate Performance successfully.", Color.Green, true);

				OutputLogHandler.AppendMessage("Disabling animations...", Color.Black, false);
				await EditRegistry.SetItemProperty(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects", "VisualFXSetting", 2);
				OutputLogHandler.AppendMessage("Animations disabled successfully.", Color.Green, true);

				OutputLogHandler.AppendMessage("Disabling Windows Update...", Color.Black, false);
				await EditRegistry.SetItemProperty(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU", "NoAutoUpdate", 1);
				OutputLogHandler.AppendMessage("Windows Update disabled successfully.", Color.Green, true);

				OutputLogHandler.AppendMessage("Cleaning up temporary files...", Color.Black, false);
				RunPowershell.Script("Get-ChildItem -Path \"C:\\Windows\\Temp\" -Recurse -Force | Remove-Item -Recurse -Force -ErrorAction SilentlyContinue");
				OutputLogHandler.AppendMessage("Temporary files cleaned up successfully.", Color.Green, true);

				//send a message to the user that the task is complete
				OutputLogHandler.AppendMessage("Windows optimized successfully.", Color.Green, false);

				//send a message to the user that the task is complete
				//OutputMessage_window.GetSelectionStart(), true);
			}
			catch (Exception ex)
			{
				OutputLogHandler.AppendMessage($"Error optimizing windows: {ex.Message}", Color.Red, true);
				return;
			}
		}
	}
}
