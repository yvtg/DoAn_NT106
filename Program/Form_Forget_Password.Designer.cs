namespace Program
{
    partial class Form_Forget_Password
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Forget_Password));
            this.ForgetPassword = new ReaLTaiizor.Forms.HopeForm();
            this.emailTextbox = new ReaLTaiizor.Controls.HopeTextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.sendButton = new ReaLTaiizor.Controls.HopeButton();
            this.backButton = new ReaLTaiizor.Controls.HopeButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ForgetPassword
            // 
            this.ForgetPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(211)))));
            this.ForgetPassword.ControlBoxColorH = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.ForgetPassword.ControlBoxColorHC = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.ForgetPassword.ControlBoxColorN = System.Drawing.Color.White;
            this.ForgetPassword.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForgetPassword.Dock = System.Windows.Forms.DockStyle.Top;
            this.ForgetPassword.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForgetPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.ForgetPassword.Image = null;
            this.ForgetPassword.Location = new System.Drawing.Point(0, 0);
            this.ForgetPassword.Name = "ForgetPassword";
            this.ForgetPassword.Size = new System.Drawing.Size(348, 40);
            this.ForgetPassword.TabIndex = 59;
            this.ForgetPassword.Text = "Forget Password";
            this.ForgetPassword.ThemeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            // 
            // emailTextbox
            // 
            this.emailTextbox.BackColor = System.Drawing.Color.White;
            this.emailTextbox.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.emailTextbox.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.emailTextbox.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.emailTextbox.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.emailTextbox.Hint = "";
            this.emailTextbox.Location = new System.Drawing.Point(71, 230);
            this.emailTextbox.MaxLength = 32767;
            this.emailTextbox.Multiline = false;
            this.emailTextbox.Name = "emailTextbox";
            this.emailTextbox.PasswordChar = '\0';
            this.emailTextbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.emailTextbox.SelectedText = "";
            this.emailTextbox.SelectionLength = 0;
            this.emailTextbox.SelectionStart = 0;
            this.emailTextbox.Size = new System.Drawing.Size(267, 33);
            this.emailTextbox.TabIndex = 0;
            this.emailTextbox.TabStop = false;
            this.emailTextbox.UseSystemPasswordChar = false;
            this.emailTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.emailTextbox_KeyDown);
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.emailLabel.Location = new System.Drawing.Point(15, 242);
            this.emailLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(56, 19);
            this.emailLabel.TabIndex = 59;
            this.emailLabel.Text = "Email";
            // 
            // sendButton
            // 
            this.sendButton.BorderColor = System.Drawing.Color.Black;
            this.sendButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.sendButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sendButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.sendButton.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sendButton.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.sendButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.sendButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.sendButton.Location = new System.Drawing.Point(114, 288);
            this.sendButton.Name = "sendButton";
            this.sendButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(168)))), ((int)(((byte)(117)))));
            this.sendButton.Size = new System.Drawing.Size(113, 39);
            this.sendButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.sendButton.TabIndex = 74;
            this.sendButton.Text = "Send";
            this.sendButton.TextColor = System.Drawing.Color.White;
            this.sendButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click_1);
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
            this.backButton.Location = new System.Drawing.Point(114, 349);
            this.backButton.Name = "backButton";
            this.backButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(168)))), ((int)(((byte)(117)))));
            this.backButton.Size = new System.Drawing.Size(113, 40);
            this.backButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.backButton.TabIndex = 73;
            this.backButton.Text = "Back";
            this.backButton.TextColor = System.Drawing.Color.White;
            this.backButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.backButton.Click += new System.EventHandler(this.backButton_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::Program.Properties.Resources.logo;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(10, 76);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(319, 123);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 75;
            this.pictureBox1.TabStop = false;
            // 
            // Form_Forget_Password
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(211)))));
            this.ClientSize = new System.Drawing.Size(348, 453);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.ForgetPassword);
            this.Controls.Add(this.emailTextbox);
            this.Controls.Add(this.emailLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(1440, 829);
            this.MinimumSize = new System.Drawing.Size(190, 40);
            this.Name = "Form_Forget_Password";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Forget_Password";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ReaLTaiizor.Forms.HopeForm ForgetPassword;
        private ReaLTaiizor.Controls.HopeTextBox emailTextbox;
        private System.Windows.Forms.Label emailLabel;
        private ReaLTaiizor.Controls.HopeButton sendButton;
        private ReaLTaiizor.Controls.HopeButton backButton;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}