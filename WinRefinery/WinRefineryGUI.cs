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
		private TextBox appTitle;
		private TextBox windowsVersion;
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
		private AboutInfo aboutInfo;

		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinRefineryGUI));
			chkRemoveAds = new CheckBox();
			btnRun = new Button();
			btnFixer = new Button();
			logOutput = new RichTextBox();
			appTitle = new TextBox();
			windowsVersion = new TextBox();
			panel1 = new Panel();
			processLogsText = new TextBox();
			appCounter = new Label();
			btnAnalyze = new Button();
			functionPanel = new Panel();
			titleBox = new TextBox();
			shadowPanel1 = new Panel();
			shadowPanel2 = new Panel();
			btnApps = new Button();
			logoPicture = new PictureBox();
			btnRestore = new Button();
			btnRestorePoint = new Button();
			btnLicense = new Button();
			btnAbout = new Button();
			btnDonation = new Button();
			backgroundBanner = new Panel();
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
			btnRun.Cursor = Cursors.Hand;
			btnRun.Name = "btnRun";
			btnRun.UseVisualStyleBackColor = false;
			btnRun.Click += btnRun_Click;
			// 
			// btnFixer
			// 
			resources.ApplyResources(btnFixer, "btnFixer");
			btnFixer.BackColor = Color.DarkGreen;
			btnFixer.Cursor = Cursors.Hand;
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
			// appTitle
			// 
			resources.ApplyResources(appTitle, "appTitle");
			appTitle.BackColor = Color.FromArgb(25, 25, 25);
			appTitle.BorderStyle = BorderStyle.None;
			appTitle.ForeColor = Color.White;
			appTitle.Name = "appTitle";
			appTitle.ReadOnly = true;
			// 
			// windowsVersion
			// 
			resources.ApplyResources(windowsVersion, "windowsVersion");
			windowsVersion.BackColor = Color.FromArgb(25, 25, 25);
			windowsVersion.BorderStyle = BorderStyle.None;
			windowsVersion.ForeColor = Color.White;
			windowsVersion.Name = "windowsVersion";
			windowsVersion.ReadOnly = true;
			// 
			// panel1
			// 
			resources.ApplyResources(panel1, "panel1");
			panel1.BackColor = Color.White;
			panel1.BorderStyle = BorderStyle.Fixed3D;
			panel1.Controls.Add(processLogsText);
			panel1.Controls.Add(appCounter);
			panel1.Controls.Add(btnAnalyze);
			panel1.Controls.Add(functionPanel);
			panel1.Controls.Add(titleBox);
			panel1.Controls.Add(logOutput);
			panel1.Controls.Add(btnRun);
			panel1.Controls.Add(shadowPanel1);
			panel1.Controls.Add(shadowPanel2);
			panel1.Name = "panel1";
			// 
			// processLogsText
			// 
			resources.ApplyResources(processLogsText, "processLogsText");
			processLogsText.BackColor = Color.White;
			processLogsText.ForeColor = Color.Black;
			processLogsText.Name = "processLogsText";
			processLogsText.ReadOnly = true;
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
			btnAnalyze.Cursor = Cursors.Hand;
			btnAnalyze.Name = "btnAnalyze";
			btnAnalyze.UseVisualStyleBackColor = false;
			btnAnalyze.Click += btnRestore_Click;
			// 
			// functionPanel
			// 
			resources.ApplyResources(functionPanel, "functionPanel");
			functionPanel.BackColor = Color.Gainsboro;
			functionPanel.BorderStyle = BorderStyle.FixedSingle;
			functionPanel.Name = "functionPanel";
			// 
			// titleBox
			// 
			resources.ApplyResources(titleBox, "titleBox");
			titleBox.BackColor = Color.White;
			titleBox.ForeColor = Color.Black;
			titleBox.Name = "titleBox";
			titleBox.ReadOnly = true;
			// 
			// shadowPanel1
			// 
			resources.ApplyResources(shadowPanel1, "shadowPanel1");
			shadowPanel1.BackColor = Color.FromArgb(50, 0, 0, 0);
			shadowPanel1.Name = "shadowPanel1";
			// 
			// shadowPanel2
			// 
			resources.ApplyResources(shadowPanel2, "shadowPanel2");
			shadowPanel2.BackColor = Color.FromArgb(50, 0, 0, 0);
			shadowPanel2.Name = "shadowPanel2";
			// 
			// btnApps
			// 
			resources.ApplyResources(btnApps, "btnApps");
			btnApps.BackColor = Color.DarkGreen;
			btnApps.Cursor = Cursors.Hand;
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
			btnRestore.Cursor = Cursors.Hand;
			btnRestore.Name = "btnRestore";
			btnRestore.UseVisualStyleBackColor = false;
			btnRestore.Click += btnRestore_Click;
			// 
			// btnRestorePoint
			// 
			resources.ApplyResources(btnRestorePoint, "btnRestorePoint");
			btnRestorePoint.BackColor = Color.DarkGreen;
			btnRestorePoint.Cursor = Cursors.Hand;
			btnRestorePoint.Name = "btnRestorePoint";
			btnRestorePoint.UseVisualStyleBackColor = false;
			btnRestorePoint.Click += btnRestorePoint_Click;
			// 
			// btnLicense
			// 
			resources.ApplyResources(btnLicense, "btnLicense");
			btnLicense.Cursor = Cursors.Hand;
			btnLicense.Name = "btnLicense";
			btnLicense.UseVisualStyleBackColor = true;
			btnLicense.Click += btnLicense_Click;
			// 
			// btnAbout
			// 
			resources.ApplyResources(btnAbout, "btnAbout");
			btnAbout.Cursor = Cursors.Hand;
			btnAbout.Name = "btnAbout";
			btnAbout.UseVisualStyleBackColor = true;
			btnAbout.Click += btnAbout_Click;
			// 
			// btnDonation
			// 
			resources.ApplyResources(btnDonation, "btnDonation");
			btnDonation.Cursor = Cursors.Hand;
			btnDonation.Name = "btnDonation";
			btnDonation.UseVisualStyleBackColor = true;
			btnDonation.Click += btnDonation_Click;
			// 
			// backgroundBanner
			// 
			resources.ApplyResources(backgroundBanner, "backgroundBanner");
			backgroundBanner.BackColor = Color.FromArgb(25, 25, 25);
			backgroundBanner.Name = "backgroundBanner";
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
			Controls.Add(windowsVersion);
			Controls.Add(appTitle);
			Controls.Add(btnFixer);
			Controls.Add(chkRemoveAds);
			Controls.Add(backgroundBanner);
			Controls.Add(panel1);
			FormBorderStyle = FormBorderStyle.FixedSingle;
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
