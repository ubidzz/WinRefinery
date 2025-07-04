namespace WinRefinery
{
	internal class RemoveAds(WinRefineryGUI debloating)
	{
		//private readonly Progress_Tasks_Window OutputMessage_window = outputMessageWindow ?? throw new ArgumentNullException(nameof(outputMessageWindow));
		private readonly WinRefineryGUI Debloating = debloating ?? throw new ArgumentNullException(nameof(debloating));

		private void EnsureOutputMessageWindow()
		{
			//if (OutputMessage_window == null || OutputMessage_window.IsDisposed)
			//{
			//	throw new InvalidOperationException("OutputMessage_window is not available.");
			//}
			//else if (!OutputMessage_window.Visible)
			//{
			//	OutputMessage_window.Show();
			//}
			//else
			//{
			//	OutputMessage_window.BringToFront();
			//}
		}

		public async Task ExecuteRemoveAds()
		{
			EnsureOutputMessageWindow();
			//OutputMessage_window.ClearMessages(); // Clear previous messages

			try
			{
				// Append an initial message to confirm the method is running
				//OutputMessage_window.AppendMessage("Starting RemoveAds task...", Color.Blue, OutputMessage_window.GetSelectionStart(), false);

				// Disable Spotlight & Ads
				//await Debloating.SetItemProperty(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\CloudContent", "DisableWindowsSpotlightFeatures", 1);
				//await Debloating.SetItemProperty(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\CloudContent", "DisableConsumerFeatures", 1);
				//await Debloating.SetItemProperty(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\CloudContent", "DisableTailoredExperiencesWithDiagnosticData", 1);
				//OutputMessage_window.AppendMessage("Disabled Spotlight and Ads.", Color.Green, OutputMessage_window.GetSelectionStart(), true);
				//OutputMessage_window.AppendMessage("\n", Color.Black, OutputMessage_window.GetSelectionStart(), false);

				// Remove Search Ads and Web Content
				//await Debloating.SetItemProperty(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\SearchSettings", "IsDynamicSearchBoxEnabled", 0);
				//await Debloating.SetItemProperty(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Search", "BingSearchEnabled", 0);
				//await Debloating.SetItemProperty(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Search", "AllowSearchToUseLocation", 0);
				//await Debloating.SetItemProperty(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Search", "SearchOnTaskbarMode", 0);
				//await Debloating.SetItemProperty(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Search", "SearchHighlights", 0);
				//await Debloating.SetItemProperty(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Search", "ShowIndexingWarnings", 0);
				//await Debloating.SetItemProperty(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\PolicyManager\default\Search\DisableSearch", "value", 1);
				//OutputMessage_window.AppendMessage("Removed Search Ads and Web Content.", Color.Green, OutputMessage_window.GetSelectionStart(), true);
				//OutputMessage_window.AppendMessage("\n", Color.Black, OutputMessage_window.GetSelectionStart(), false);

				// Widgets – prevent news/content
				//await Debloating.SetItemProperty(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Dsh", "AllowNewsAndInterests", 0);
				//await Debloating.SetItemProperty(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Feeds", "ShellFeedsTaskbarViewMode", 2);
				//OutputMessage_window.AppendMessage("Removed Widgets.", Color.Black, OutputMessage_window.GetSelectionStart(), true);
				//OutputMessage_window.AppendMessage("\n", Color.Black, OutputMessage_window.GetSelectionStart(), false);

				// Optional: Disable Cortana
				//await Debloating.SetItemProperty(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Windows Search", "AllowCortana", 0);
				//await Debloating.SetItemProperty(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Search", "CortanaConsent", 0);
				//OutputMessage_window.AppendMessage("Disabled Cortana.", Color.Green, OutputMessage_window.GetSelectionStart(), true);
				//OutputMessage_window.AppendMessage("\n", Color.Black, OutputMessage_window.GetSelectionStart(), false);

				// Send a message to the user that the task is complete
				//OutputMessage_window.AppendMessage("Removed all Ads successfully.", Color.Green, OutputMessage_window.GetSelectionStart(), true);
			}
			catch (Exception ex)
			{
				//OutputMessage_window.AppendMessage($"Error setting remove ads registry keys: {ex.Message}", Color.Red, OutputMessage_window.GetSelectionStart(), true);
			}
		}
	}
}