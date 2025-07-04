namespace WinRefinery
{
	internal class DisableTracking(WinRefineryGUI debloating)
	{
		//private readonly Progress_Tasks_Window OutputMessage_window = outputMessageWindow ?? throw new ArgumentNullException(nameof(outputMessageWindow));
		private readonly WinRefineryGUI Debloating = debloating ?? throw new ArgumentNullException(nameof(debloating));

		public async Task Disable()
		{
			try
			{
				//await Debloating.SetItemProperty(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\DataCollection", "AllowTelemetry", 0);
				//await Debloating.SetItemProperty(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Windows Search", "AllowCortana", 0);
				//await Debloating.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows\CloudContent", "DisableWindowsSpotlightOnSettings", 1);
				//await Debloating.SetItemProperty(@"HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows\CloudContent", "DisableWindowsSpotlightOnActionCenter", 1);
				//send a message to the user that the task is complete
				//OutputMessage_window.AppendMessage("Tracking disabled successfully.", Color.Green,
				//send a message to the user that the task is complete
				//OutputMessage_window.GetSelectionStart(), true);
			}
			catch (Exception ex)
			{
				//OutputMessage_window.AppendMessage($"Error disabling tracking: {ex.Message}", Color.Red, OutputMessage_window.GetSelectionStart(), true);
				return;
			}
		}
	}
}
