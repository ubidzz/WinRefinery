using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinRefinery
{
	internal class OutputLogHandler
	{
		public static WinRefineryGUI WinRefineryGUI = new();

		public static void AppendMessage(string message, Color color, bool bold = false)
		{
			if (WinRefineryGUI.logOutput == null || WinRefineryGUI.logOutput.IsDisposed) return;

			int selectionStart = WinRefineryGUI.logOutput.SelectionStart;

			// Move to the end of the textbox to append the new message
			WinRefineryGUI.logOutput.SelectionStart = WinRefineryGUI.logOutput.TextLength;
			WinRefineryGUI.logOutput.SelectionLength = 0;

			// Apply the color
			WinRefineryGUI.logOutput.SelectionColor = color;

			// Apply the bold style if requested
			WinRefineryGUI.logOutput.SelectionFont = new Font(WinRefineryGUI.logOutput.Font, bold ? FontStyle.Bold : FontStyle.Regular);

			// Append the message
			WinRefineryGUI.logOutput.AppendText(message + Environment.NewLine);

			// Scroll to the end of the textbox
			WinRefineryGUI.logOutput.SelectionStart = WinRefineryGUI.logOutput.TextLength;
			WinRefineryGUI.logOutput.ScrollToCaret();
		}

		public static void DeleteLogsFromWindow()
		{
			WinRefineryGUI.logOutput.Clear();
		}
	}
}
