namespace WinRefinery
{
	public partial class WinRefineryGUI : Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private readonly System.ComponentModel.IContainer? components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private Button btnFixer;
		private TextBox textBox7;
		private TextBox textBox8;
		private TextBox versionText;
		private TextBox descriptionText;
		private Panel panel1;
		private TextBox titleBox;
		private Button btnApps;
		private CheckBox chkRemoveAds;
		private Button btnRun;
		private PictureBox logoPicture;
		private Button btnAnalyze;
		private Button btnRestore;
		private readonly RemoveAds Ads;
		private readonly DisableTracking Tracking;
		private readonly OptimizeWindows Optimize;
		private Button btnRestorePoint;
		private RestorePoint RestorePoint = new();
		private Button btnLicense;
		private Button btnAbout;
		private Button btnDonation;

		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinRefineryGUI));
			chkRemoveAds = new CheckBox();
			btnRun = new Button();
			btnFixer = new Button();
			logOutput = new RichTextBox();
			textBox7 = new TextBox();
			textBox8 = new TextBox();
			versionText = new TextBox();
			descriptionText = new TextBox();
			panel1 = new Panel();
			appCounter = new Label();
			btnAnalyze = new Button();
			functionPanel = new Panel();
			titleBox = new TextBox();
			btnApps = new Button();
			logoPicture = new PictureBox();
			btnRestore = new Button();
			btnRestorePoint = new Button();
			btnLicense = new Button();
			btnAbout = new Button();
			btnDonation = new Button();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)logoPicture).BeginInit();
			SuspendLayout();
			// 
			// chkRemoveAds
			// 
			resources.ApplyResources(chkRemoveAds, "chkRemoveAds");
			chkRemoveAds.Name = "chkRemoveAds";
			chkRemoveAds.UseVisualStyleBackColor = true;
			// 
			// btnRun
			// 
			resources.ApplyResources(btnRun, "btnRun");
			btnRun.BackColor = Color.Transparent;
			btnRun.Name = "btnRun";
			btnRun.UseVisualStyleBackColor = false;
			btnRun.Click += btnRun_Click;
			// 
			// btnFixer
			// 
			resources.ApplyResources(btnFixer, "btnFixer");
			btnFixer.BackColor = Color.DarkGreen;
			btnFixer.Name = "btnFixer";
			btnFixer.UseVisualStyleBackColor = false;
			btnFixer.Click += btnFixer_Click;
			// 
			// logOutput
			// 
			resources.ApplyResources(logOutput, "logOutput");
			logOutput.BackColor = Color.Gainsboro;
			logOutput.BorderStyle = BorderStyle.FixedSingle;
			logOutput.Name = "logOutput";
			logOutput.ReadOnly = true;
			logOutput.TabStop = false;
			// 
			// textBox7
			// 
			resources.ApplyResources(textBox7, "textBox7");
			textBox7.BackColor = Color.FromArgb(25, 25, 25);
			textBox7.BorderStyle = BorderStyle.None;
			textBox7.ForeColor = SystemColors.Info;
			textBox7.Name = "textBox7";
			// 
			// textBox8
			// 
			resources.ApplyResources(textBox8, "textBox8");
			textBox8.BackColor = Color.FromArgb(25, 25, 25);
			textBox8.BorderStyle = BorderStyle.None;
			textBox8.ForeColor = SystemColors.Info;
			textBox8.Name = "textBox8";
			// 
			// versionText
			// 
			resources.ApplyResources(versionText, "versionText");
			versionText.BackColor = Color.FromArgb(25, 25, 25);
			versionText.BorderStyle = BorderStyle.None;
			versionText.ForeColor = SystemColors.Info;
			versionText.Name = "versionText";
			// 
			// descriptionText
			// 
			resources.ApplyResources(descriptionText, "descriptionText");
			descriptionText.BackColor = Color.FromArgb(25, 25, 25);
			descriptionText.BorderStyle = BorderStyle.None;
			descriptionText.ForeColor = SystemColors.Info;
			descriptionText.Name = "descriptionText";
			// 
			// panel1
			// 
			resources.ApplyResources(panel1, "panel1");
			panel1.BackColor = Color.White;
			panel1.BorderStyle = BorderStyle.Fixed3D;
			panel1.Controls.Add(appCounter);
			panel1.Controls.Add(btnAnalyze);
			panel1.Controls.Add(functionPanel);
			panel1.Controls.Add(titleBox);
			panel1.Controls.Add(logOutput);
			panel1.Controls.Add(btnRun);
			panel1.Name = "panel1";
			// 
			// appCounter
			// 
			resources.ApplyResources(appCounter, "appCounter");
			appCounter.Name = "appCounter";
			// 
			// btnAnalyze
			// 
			resources.ApplyResources(btnAnalyze, "btnAnalyze");
			btnAnalyze.BackColor = Color.Transparent;
			btnAnalyze.Name = "btnAnalyze";
			btnAnalyze.UseVisualStyleBackColor = false;
			btnAnalyze.Click += btnRestore_Click;
			// 
			// functionPanel
			// 
			resources.ApplyResources(functionPanel, "functionPanel");
			functionPanel.BackColor = Color.White;
			functionPanel.BorderStyle = BorderStyle.Fixed3D;
			functionPanel.Name = "functionPanel";
			// 
			// titleBox
			// 
			resources.ApplyResources(titleBox, "titleBox");
			titleBox.Name = "titleBox";
			titleBox.ReadOnly = true;
			// 
			// btnApps
			// 
			resources.ApplyResources(btnApps, "btnApps");
			btnApps.BackColor = Color.DarkGreen;
			btnApps.Name = "btnApps";
			btnApps.UseVisualStyleBackColor = false;
			btnApps.Click += btnApps_Click;
			// 
			// logoPicture
			// 
			resources.ApplyResources(logoPicture, "logoPicture");
			logoPicture.BackColor = Color.FromArgb(25, 25, 25);
			logoPicture.Name = "logoPicture";
			logoPicture.TabStop = false;
			// 
			// btnRestore
			// 
			resources.ApplyResources(btnRestore, "btnRestore");
			btnRestore.BackColor = Color.DarkGreen;
			btnRestore.Name = "btnRestore";
			btnRestore.UseVisualStyleBackColor = false;
			btnRestore.Click += btnRestore_Click;
			// 
			// btnRestorePoint
			// 
			resources.ApplyResources(btnRestorePoint, "btnRestorePoint");
			btnRestorePoint.BackColor = Color.DarkGreen;
			btnRestorePoint.Name = "btnRestorePoint";
			btnRestorePoint.UseVisualStyleBackColor = false;
			btnRestorePoint.Click += btnRestorePoint_Click;
			// 
			// btnLicense
			// 
			resources.ApplyResources(btnLicense, "btnLicense");
			btnLicense.Name = "btnLicense";
			btnLicense.UseVisualStyleBackColor = true;
			btnLicense.Click += btnLicense_Click;
			// 
			// btnAbout
			// 
			resources.ApplyResources(btnAbout, "btnAbout");
			btnAbout.Name = "btnAbout";
			btnAbout.UseVisualStyleBackColor = true;
			// 
			// btnDonation
			// 
			resources.ApplyResources(btnDonation, "btnDonation");
			btnDonation.Name = "btnDonation";
			btnDonation.UseVisualStyleBackColor = true;
			btnDonation.Click += btnDonation_Click;
			// 
			// WinRefineryGUI
			// 
			resources.ApplyResources(this, "$this");
			AutoScaleMode = AutoScaleMode.Inherit;
			BackColor = Color.DimGray;
			Controls.Add(btnDonation);
			Controls.Add(btnAbout);
			Controls.Add(btnLicense);
			Controls.Add(btnRestorePoint);
			Controls.Add(btnRestore);
			Controls.Add(logoPicture);
			Controls.Add(btnApps);
			Controls.Add(descriptionText);
			Controls.Add(versionText);
			Controls.Add(textBox8);
			Controls.Add(textBox7);
			Controls.Add(btnFixer);
			Controls.Add(chkRemoveAds);
			Controls.Add(panel1);
			FormBorderStyle = FormBorderStyle.Fixed3D;
			MaximizeBox = false;
			Name = "WinRefineryGUI";
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)logoPicture).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
