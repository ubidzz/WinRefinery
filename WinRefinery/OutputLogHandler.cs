using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinRefinery
{
	internal class OutputLogHandler
	{
		private static WinRefineryGUI _gui;

		public static void Initialize(WinRefineryGUI gui)
		{
			_gui = gui;
		}

		static OutputLogHandler()
		{
			_gui = null;
		}

		public static void AppendMessage(string message, Color color, bool bold)
		{
			if (_gui.logOutput == null || _gui.logOutput.IsDisposed || _gui.logOutput.Handle == IntPtr.Zero) return;

			if (_gui.InvokeRequired)
			{
				_gui.Invoke(new Action(() =>
				{
					AppendMessage(message, color, bold);
				}));
			}
			else
			{
				int selectionStart = _gui.logOutput.SelectionStart;

				// Move to the end of the textbox to append the new message
				_gui.logOutput.SelectionStart = _gui.logOutput.TextLength;
				_gui.logOutput.SelectionLength = 0;

				// Apply the color
				_gui.logOutput.SelectionColor = color;

				// Apply the bold style if requested
				_gui.logOutput.SelectionFont = new Font(_gui.logOutput.Font, bold ? FontStyle.Bold : FontStyle.Regular);

				// Append the message
				_gui.logOutput.AppendText(message + Environment.NewLine);

				// Scroll to the end of the textbox
				_gui.logOutput.SelectionStart = _gui.logOutput.TextLength;
				_gui.logOutput.ScrollToCaret();
			}
		}

		public static void DeleteLogsFromWindow()
		{
			if (_gui != null)
			{
				_gui.logOutput.Clear();
			}
		}
	}
}
