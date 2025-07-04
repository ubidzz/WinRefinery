using System.Management;

namespace WinRefinery
{
	internal class RestorePoint()
	{
		public EditRegistry EditRegistry = new();
		public OutputLogHandler OutputLogHandler = new();

		public async Task StartCreatingTask()
		{
			// Deleting the old logs from the log window
			OutputLogHandler.DeleteLogsFromWindow();

			// Add logging
			OutputLogHandler.AppendMessage("Creating system restore! Give this task a few minutes to complete.", Color.Green, true);

			await EditRegistry.SetItemProperty(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\SystemRestore", "SystemRestorePointCreationFrequency", 0);

			string errorMessage = await CreateSystemRestorePointAsync();
			if (!string.IsNullOrEmpty(errorMessage))
			{
				OutputLogHandler.AppendMessage(errorMessage, Color.Red, true);
				// Revert the registry setting
				await EditRegistry.SetItemProperty(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\SystemRestore", "SystemRestorePointCreationFrequency", 1440);
				return; // Stop further execution
			}
			else
			{
				OutputLogHandler.AppendMessage("Creating the Windows 11 system restore point was created successfully", Color.Green, true);
			}

			// Revert the registry setting for restore point creation back to default of 24hrs
			OutputLogHandler.AppendMessage("Resetting the system restore point back to default of 24hrs! \nWe only overrighted the registry so we can make the system restore point or it won't make a system restore point if one was made within 24hrs", Color.Blue, false);
			await EditRegistry.SetItemProperty(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\SystemRestore", "SystemRestorePointCreationFrequency", 1440);
		}

		private static async Task<string> CreateSystemRestorePointAsync()
		{
			return await Task.Run(() =>
			{
				try
				{
					// Check if the WMI service is available
					var scope = new ManagementScope("\\\\localhost\\root\\default");
					scope.Connect();
					OutputLogHandler.AppendMessage("Connected to WMI service.", Color.Black, false);

					// Create a ManagementClass object
					var mc = new ManagementClass(scope, new ManagementPath("SystemRestore"), null);
					OutputLogHandler.AppendMessage("Created ManagementClass object.", Color.Black, false);

					// Get the method parameters for "CreateRestorePoint"
					var mbo = mc.GetMethodParameters("CreateRestorePoint");
					if (mbo == null)
					{
						string error = "Failed to get method parameters for CreateRestorePoint.";
						OutputLogHandler.AppendMessage(error, Color.Red, true);
						return error;
					}
					OutputLogHandler.AppendMessage("Got method parameters for CreateRestorePoint.", Color.Black, false);

					mbo["Description"] = "Created by Windows 11 Crap Fixer";
					mbo["RestorePointType"] = 0; // APPLICATION_INSTALL
					mbo["EventType"] = 100; // BEGIN_SYSTEM_CHANGE

					// Invoke the method
					var result = mc.InvokeMethod("CreateRestorePoint", mbo, null);
					if (result == null)
					{
						string error = "Failed to invoke CreateRestorePoint method.";
						OutputLogHandler.AppendMessage(error, Color.Red, true);
						return error;
					}
					OutputLogHandler.AppendMessage("Invoked CreateRestorePoint method.", Color.Black, false);

					var returnValue = result["ReturnValue"];
					if (returnValue == null)
					{
						string error = $"CreateRestorePoint method returned: {returnValue}";
						OutputLogHandler.AppendMessage(error, Color.Red, true);
						return error;
					}
					OutputLogHandler.AppendMessage($"CreateRestorePoint method returned: {returnValue}", Color.Black, false);

					// Check the return value
					if ((uint)returnValue != 0)
					{
						string error = $"Failed to create restore point. Error code: {returnValue}";
						OutputLogHandler.AppendMessage(error, Color.Red, true);
						return error;
					}
				}
				catch (ManagementException ex)
				{
					string error = $"WMI error while creating restore point: {ex.Message}";
					OutputLogHandler.AppendMessage(error, Color.Red, true);
					return error;
				}
				catch (UnauthorizedAccessException ex)
				{
					string error = $"Access denied while creating restore point: {ex.Message}";
					OutputLogHandler.AppendMessage(error, Color.Red, true);
					return error;
				}
				catch (Exception ex)
				{
					string error = $"Exception while creating restore point: {ex.Message}";
					OutputLogHandler.AppendMessage(error, Color.Red, true);
					return error;
				}
				return ""; // Success
			});
		}
	}
}
