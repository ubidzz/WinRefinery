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
		public static void License()
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

		public static void AboutWinRefinery()
		{
			string version = System.Reflection.Assembly.GetExecutingAssembly()?.GetName()?.Version?.ToString() ?? "Unknown";
			string message =
				$"About WinRefinery v{version}\r\n\r\n" +
				"WinRefinery is your go-to Windows 11 optimization toolkit—designed to empower users of all skill levels to reclaim performance, privacy, and a clean, personalized interface. Whether you’re a seasoned power user or just looking for a smoother, distraction-free experience, WinRefinery gives you the tools to make Windows 11 truly yours.\r\n\r\n" +

				"=== Our Mission ===\r\n" +
				"To provide a safe, straightforward, and effective way to:\r\n" +
				"• Eliminate unwanted bloatware\r\n" +
				"• Tweak and beautify your UI\r\n" +
				"• Fix common system annoyances\r\n" +
				"• Protect your privacy\r\n" +
				"All without compromising system stability.\r\n\r\n" +

				"=== Key Features ===\r\n" +
				"• One‑Click Debloat – Remove pre-installed apps and services you don’t need.\r\n" +
				"• UI Customization – Tailor the Start menu, taskbar, window accents, and more.\r\n" +
				"• System Repairs & Tweaks – Restore features and apply safe performance boosts.\r\n" +
				"• Privacy Protection – Disable telemetry and background data collection.\r\n" +
				"• Safe & Reversible Changes – Automatic restore points and undo options.\r\n\r\n" +

				"=== Why Choose WinRefinery? ===\r\n" +
				"• User-Friendly Interface – Clear, organized sections for quick optimization.\r\n" +
				"• Lightweight & Fast – No bloat; minimal resource usage.\r\n" +
				"• Transparent & Secure – No spyware, no hidden activity.\r\n" +
				"• Actively Developed – Community feedback shapes every update.\r\n";

			MessageBox.Show(
				message,
				"About " + Application.ProductName,
				MessageBoxButtons.OK,
				MessageBoxIcon.Information
			);
		}
	}
}
