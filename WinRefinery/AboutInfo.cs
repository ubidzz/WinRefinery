using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinRefinery
{
	internal class AboutInfo
	{
		public void License()
		{
			MessageBox.Show(
				"Copyright 2025 Jason Turner\n" +
				"All Rights Reserved.\n\n" +
				"This software, “WinRefinery”, is licensed, not sold.\n\n" +
				"You are granted a non-exclusive, non-transferable, revocable license to use this software for personal or internal business purposes only. \n\n" +
				"You MAY NOT:\n" +
				"- Sell, distribute, sublicense, lease, or rent this software.\n" +
				"- Modify, reverse engineer, or repackage the software.\n" +
				"- Rename or rebrand this software or create derivative works under a different name.\n" +
				"- Use this software for unlawful purposes.\n\n" +
				"You MAY:\n" +
				"- Use the software on your personal or company-owned Windows 11 systems.\n" +
				"- Share screenshots or reviews with proper attribution.\n\n" +
				"Unauthorized use, reproduction, distribution, or modification of this software is strictly prohibited and constitutes a violation of copyright law.\n\n" +
				"### Disclaimer of Warranty and Liability:\n\n" +
				"This software is provided \"AS IS\", without warranty of any kind, express or implied.  \n" +
				"You assume full responsibility for the installation, use, and any consequences resulting from the use of this software.\n\n" +
				"In no event shall the author (Jason Turner) be held liable for any direct, indirect, incidental, special, or consequential damages, including data loss or system malfunction, arising from the use or inability to use this software.\n\n" +
				"Use of this software indicates your acceptance of these terms.",
				"WinRefinery License Agreement",
				MessageBoxButtons.OK,
				MessageBoxIcon.Information
			);
		}

		public void AboutWinRefinery()
		{
			MessageBox.Show(
				" About WinRefinery v" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(),
				"About " + Application.ProductName,
				MessageBoxButtons.OK,
				MessageBoxIcon.Information
			);
		}
	}
}
