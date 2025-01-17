namespace Program
{
    partial class Form_OTP
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_OTP));
            this.timerLabel = new System.Windows.Forms.Label();
            this.otpTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.otpTimer = new System.Windows.Forms.Timer(this.components);
            this.confirmButton = new ReaLTaiizor.Controls.HopeButton();
            this.backButton = new ReaLTaiizor.Controls.HopeButton();
            this.otp = new ReaLTaiizor.Forms.HopeForm();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.timerLabel.Location = new System.Drawing.Point(198, 197);
            this.timerLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(41, 16);
            this.timerLabel.TabIndex = 75;
            this.timerLabel.Text = "Timer";
            // 
            // otpTextbox
            // 
            this.otpTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.otpTextbox.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.otpTextbox.Location = new System.Drawing.Point(176, 229);
            this.otpTextbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.otpTextbox.Name = "otpTextbox";
            this.otpTextbox.Size = new System.Drawing.Size(129, 29);
            this.otpTextbox.TabIndex = 0;
            this.otpTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.otpTextbox_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.label1.Location = new System.Drawing.Point(29, 238);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 19);
            this.label1.TabIndex = 73;
            this.label1.Text = "Enter OTP code:";
            // 
            // otpTimer
            // 
            this.otpTimer.Tick += new System.EventHandler(this.otpTimer_Tick);
            // 
            // confirmButton
            // 
            this.confirmButton.BorderColor = System.Drawing.Color.Black;
            this.confirmButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.confirmButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.confirmButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.confirmButton.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.confirmButton.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.confirmButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.confirmButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.confirmButton.Location = new System.Drawing.Point(113, 303);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(168)))), ((int)(((byte)(117)))));
            this.confirmButton.Size = new System.Drawing.Size(122, 41);
            this.confirmButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.confirmButton.TabIndex = 78;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.TextColor = System.Drawing.Color.White;
            this.confirmButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click_1);
            // 
            // backButton
            // 
            this.backButton.BorderColor = System.Drawing.Color.Black;
            this.backButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.backButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.backButton.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.backButton.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.backButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.backButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.backButton.Location = new System.Drawing.Point(113, 363);
            this.backButton.Name = "backButton";
            this.backButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(168)))), ((int)(((byte)(117)))));
            this.backButton.Size = new System.Drawing.Size(122, 41);
            this.backButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.backButton.TabIndex = 77;
            this.backButton.Text = "Back";
            this.backButton.TextColor = System.Drawing.Color.White;
            this.backButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.backButton.Click += new System.EventHandler(this.backButton_Click_1);
            // 
            // otp
            // 
            this.otp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(211)))));
            this.otp.ControlBoxColorH = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.otp.ControlBoxColorHC = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.otp.ControlBoxColorN = System.Drawing.Color.White;
            this.otp.Cursor = System.Windows.Forms.Cursors.Default;
            this.otp.Dock = System.Windows.Forms.DockStyle.Top;
            this.otp.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.otp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.otp.Image = null;
            this.otp.Location = new System.Drawing.Point(0, 0);
            this.otp.Name = "otp";
            this.otp.Size = new System.Drawing.Size(348, 40);
            this.otp.TabIndex = 76;
            this.otp.Text = "OTP";
            this.otp.ThemeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::Program.Properties.Resources.logo;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(10, 62);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(319, 123);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 79;
            this.pictureBox1.TabStop = false;
            // 
            // Form_OTP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(211)))));
            this.ClientSize = new System.Drawing.Size(348, 453);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.otpTextbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.otp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximumSize = new System.Drawing.Size(1440, 829);
            this.MinimumSize = new System.Drawing.Size(190, 40);
            this.Name = "Form_OTP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_OTP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_OTP_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.TextBox otpTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer otpTimer;
        private ReaLTaiizor.Controls.HopeButton confirmButton;
        private ReaLTaiizor.Controls.HopeButton backButton;
        private ReaLTaiizor.Forms.HopeForm otp;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}