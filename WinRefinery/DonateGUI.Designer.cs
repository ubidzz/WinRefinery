﻿namespace WinRefinery
{
	partial class DonateGUI
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DonateGUI));
			qrCode = new PictureBox();
			btnDonate = new Button();
			textBox1 = new TextBox();
			textBox3 = new TextBox();
			btnClose = new Button();
			paypalLogo = new PictureBox();
			((System.ComponentModel.ISupportInitialize)qrCode).BeginInit();
			((System.ComponentModel.ISupportInitialize)paypalLogo).BeginInit();
			SuspendLayout();
			// 
			// qrCode
			// 
			qrCode.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			qrCode.BackgroundImageLayout = ImageLayout.None;
			qrCode.Image = (Image)resources.GetObject("qrCode.Image");
			qrCode.Location = new Point(12, 233);
			qrCode.Name = "qrCode";
			qrCode.Size = new Size(325, 137);
			qrCode.SizeMode = PictureBoxSizeMode.CenterImage;
			qrCode.TabIndex = 0;
			qrCode.TabStop = false;
			// 
			// btnDonate
			// 
			btnDonate.FlatStyle = FlatStyle.System;
			btnDonate.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnDonate.Location = new Point(111, 402);
			btnDonate.Name = "btnDonate";
			btnDonate.Size = new Size(128, 31);
			btnDonate.TabIndex = 1;
			btnDonate.Text = "Donate";
			btnDonate.UseVisualStyleBackColor = true;
			btnDonate.Click += btnDonate_Click;
			// 
			// textBox1
			// 
			textBox1.BackColor = SystemColors.GradientInactiveCaption;
			textBox1.BorderStyle = BorderStyle.None;
			textBox1.Enabled = false;
			textBox1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			textBox1.ForeColor = Color.Black;
			textBox1.Location = new Point(12, 376);
			textBox1.Multiline = true;
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(325, 20);
			textBox1.TabIndex = 2;
			textBox1.Text = "or";
			textBox1.TextAlign = HorizontalAlignment.Center;
			// 
			// textBox3
			// 
			textBox3.BackColor = SystemColors.GradientInactiveCaption;
			textBox3.BorderStyle = BorderStyle.None;
			textBox3.Enabled = false;
			textBox3.ForeColor = Color.Black;
			textBox3.Location = new Point(12, 12);
			textBox3.Multiline = true;
			textBox3.Name = "textBox3";
			textBox3.Size = new Size(323, 96);
			textBox3.TabIndex = 4;
			textBox3.Text = "If you’d like to support the development of WinRefinery, please scan the QR code or click the “Donate” button below. Your contribution helps keep the project alive and improving. \r\n\r\nThank you!";
			// 
			// btnClose
			// 
			btnClose.FlatStyle = FlatStyle.System;
			btnClose.Location = new Point(111, 458);
			btnClose.Name = "btnClose";
			btnClose.Size = new Size(128, 29);
			btnClose.TabIndex = 5;
			btnClose.Text = "Close Window";
			btnClose.UseVisualStyleBackColor = true;
			btnClose.Click += btnClose_Click;
			// 
			// paypalLogo
			// 
			paypalLogo.Image = (Image)resources.GetObject("paypalLogo.Image");
			paypalLogo.Location = new Point(12, 114);
			paypalLogo.Name = "paypalLogo";
			paypalLogo.Size = new Size(325, 113);
			paypalLogo.SizeMode = PictureBoxSizeMode.StretchImage;
			paypalLogo.TabIndex = 6;
			paypalLogo.TabStop = false;
			// 
			// DonateGUI
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.GradientInactiveCaption;
			ClientSize = new Size(349, 499);
			Controls.Add(paypalLogo);
			Controls.Add(btnClose);
			Controls.Add(textBox3);
			Controls.Add(textBox1);
			Controls.Add(btnDonate);
			Controls.Add(qrCode);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Icon = (Icon)resources.GetObject("$this.Icon");
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "DonateGUI";
			ShowInTaskbar = false;
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Support WinRefinery";
			((System.ComponentModel.ISupportInitialize)qrCode).EndInit();
			((System.ComponentModel.ISupportInitialize)paypalLogo).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private PictureBox qrCode;
		private Button btnDonate;
		private TextBox textBox1;
		private TextBox textBox3;
		private Button btnClose;
		private PictureBox paypalLogo;
	}
}