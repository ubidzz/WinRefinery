using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinRefinery
{
	public partial class DonateGUI : Form
	{
		public DonateGUI()
		{
			InitializeComponent();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnDonate_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start(new ProcessStartInfo { FileName = "https://www.paypal.com/donate/?hosted_button_id=6SML6HZVTG6E8", UseShellExecute = true });
		}
	}
}
