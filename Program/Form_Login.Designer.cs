namespace Program
{
    partial class Form_Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Login));
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passLabel = new System.Windows.Forms.Label();
            this.regBtn = new ReaLTaiizor.Controls.HopeButton();
            this.loginButton = new ReaLTaiizor.Controls.HopeButton();
            this.usernameTextbox = new ReaLTaiizor.Controls.HopeTextBox();
            this.passTextbox = new ReaLTaiizor.Controls.HopeTextBox();
            this.showPwCheckBox = new ReaLTaiizor.Controls.HopeCheckBox();
            this.lawBtn = new ReaLTaiizor.Controls.HopeButton();
            this.forgetLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.login = new ReaLTaiizor.Forms.HopeForm();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.usernameLabel.Location = new System.Drawing.Point(9, 250);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(112, 23);
            this.usernameLabel.TabIndex = 0;
            this.usernameLabel.Text = "Username";
            // 
            // passLabel
            // 
            this.passLabel.AutoSize = true;
            this.passLabel.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.passLabel.Location = new System.Drawing.Point(9, 327);
            this.passLabel.Name = "passLabel";
            this.passLabel.Size = new System.Drawing.Size(111, 23);
            this.passLabel.TabIndex = 1;
            this.passLabel.Text = "Password";
            // 
            // regBtn
            // 
            this.regBtn.BorderColor = System.Drawing.Color.Black;
            this.regBtn.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.regBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.regBtn.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.regBtn.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.regBtn.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regBtn.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.regBtn.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.regBtn.Location = new System.Drawing.Point(56, 432);
            this.regBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.regBtn.Name = "regBtn";
            this.regBtn.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(168)))), ((int)(((byte)(117)))));
            this.regBtn.Size = new System.Drawing.Size(152, 44);
            this.regBtn.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.regBtn.TabIndex = 8;
            this.regBtn.Text = "Register";
            this.regBtn.TextColor = System.Drawing.Color.White;
            this.regBtn.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.regBtn.Click += new System.EventHandler(this.regBtn_Click);
            // 
            // loginButton
            // 
            this.loginButton.BorderColor = System.Drawing.Color.Black;
            this.loginButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.loginButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.loginButton.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.loginButton.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.loginButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.loginButton.Location = new System.Drawing.Point(244, 432);
            this.loginButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.loginButton.Name = "loginButton";
            this.loginButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(168)))), ((int)(((byte)(117)))));
            this.loginButton.Size = new System.Drawing.Size(152, 44);
            this.loginButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.loginButton.TabIndex = 9;
            this.loginButton.Text = "Login";
            this.loginButton.TextColor = System.Drawing.Color.White;
            this.loginButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click_1);
            // 
            // usernameTextbox
            // 
            this.usernameTextbox.BackColor = System.Drawing.Color.White;
            this.usernameTextbox.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.usernameTextbox.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.usernameTextbox.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.usernameTextbox.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.usernameTextbox.Hint = "";
            this.usernameTextbox.Location = new System.Drawing.Point(154, 246);
            this.usernameTextbox.Margin = new System.Windows.Forms.Padding(0, 2, 3, 2);
            this.usernameTextbox.MaxLength = 32767;
            this.usernameTextbox.Multiline = false;
            this.usernameTextbox.Name = "usernameTextbox";
            this.usernameTextbox.PasswordChar = '\0';
            this.usernameTextbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.usernameTextbox.SelectedText = "";
            this.usernameTextbox.SelectionLength = 0;
            this.usernameTextbox.SelectionStart = 0;
            this.usernameTextbox.Size = new System.Drawing.Size(287, 40);
            this.usernameTextbox.TabIndex = 10;
            this.usernameTextbox.TabStop = false;
            this.usernameTextbox.UseSystemPasswordChar = false;
            // 
            // passTextbox
            // 
            this.passTextbox.BackColor = System.Drawing.Color.White;
            this.passTextbox.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.passTextbox.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.passTextbox.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.passTextbox.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.passTextbox.Hint = "";
            this.passTextbox.Location = new System.Drawing.Point(154, 321);
            this.passTextbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.passTextbox.MaxLength = 32767;
            this.passTextbox.Multiline = false;
            this.passTextbox.Name = "passTextbox";
            this.passTextbox.PasswordChar = '\0';
            this.passTextbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.passTextbox.SelectedText = "";
            this.passTextbox.SelectionLength = 0;
            this.passTextbox.SelectionStart = 0;
            this.passTextbox.Size = new System.Drawing.Size(287, 40);
            this.passTextbox.TabIndex = 11;
            this.passTextbox.TabStop = false;
            this.passTextbox.UseSystemPasswordChar = true;
            // 
            // showPwCheckBox
            // 
            this.showPwCheckBox.AutoSize = true;
            this.showPwCheckBox.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.showPwCheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showPwCheckBox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(168)))), ((int)(((byte)(117)))));
            this.showPwCheckBox.DisabledStringColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(107)))), ((int)(((byte)(111)))));
            this.showPwCheckBox.Enable = true;
            this.showPwCheckBox.EnabledCheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(107)))), ((int)(((byte)(111)))));
            this.showPwCheckBox.EnabledStringColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(107)))), ((int)(((byte)(111)))));
            this.showPwCheckBox.EnabledUncheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(168)))), ((int)(((byte)(117)))));
            this.showPwCheckBox.Font = new System.Drawing.Font("Cooper Black", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showPwCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.showPwCheckBox.Location = new System.Drawing.Point(154, 382);
            this.showPwCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.showPwCheckBox.Name = "showPwCheckBox";
            this.showPwCheckBox.Size = new System.Drawing.Size(173, 20);
            this.showPwCheckBox.TabIndex = 13;
            this.showPwCheckBox.Text = "Show Password";
            this.showPwCheckBox.UseVisualStyleBackColor = true;
            this.showPwCheckBox.CheckedChanged += new System.EventHandler(this.showPwCheckBox_CheckedChanged);
            // 
            // lawBtn
            // 
            this.lawBtn.BorderColor = System.Drawing.Color.Black;
            this.lawBtn.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.lawBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lawBtn.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.lawBtn.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lawBtn.Font = new System.Drawing.Font("Cooper Black", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lawBtn.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.lawBtn.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.lawBtn.Location = new System.Drawing.Point(384, 73);
            this.lawBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lawBtn.Name = "lawBtn";
            this.lawBtn.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(107)))), ((int)(((byte)(111)))));
            this.lawBtn.Size = new System.Drawing.Size(57, 44);
            this.lawBtn.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.lawBtn.TabIndex = 14;
            this.lawBtn.Text = "?";
            this.lawBtn.TextColor = System.Drawing.Color.White;
            this.lawBtn.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.lawBtn.Click += new System.EventHandler(this.lawBtn_Click);
            // 
            // forgetLabel
            // 
            this.forgetLabel.AutoSize = true;
            this.forgetLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.forgetLabel.Font = new System.Drawing.Font("Cooper Black", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forgetLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.forgetLabel.Location = new System.Drawing.Point(237, 512);
            this.forgetLabel.Name = "forgetLabel";
            this.forgetLabel.Size = new System.Drawing.Size(164, 20);
            this.forgetLabel.TabIndex = 26;
            this.forgetLabel.Text = "Forgot Password?";
            this.forgetLabel.Click += new System.EventHandler(this.forgetLabel_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::Program.Properties.Resources.logo;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(16, 73);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(425, 151);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // login
            // 
            this.login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(211)))));
            this.login.ControlBoxColorH = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.login.ControlBoxColorHC = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.login.ControlBoxColorN = System.Drawing.Color.White;
            this.login.Cursor = System.Windows.Forms.Cursors.Default;
            this.login.Dock = System.Windows.Forms.DockStyle.Top;
            this.login.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.login.Image = null;
            this.login.Location = new System.Drawing.Point(0, 0);
            this.login.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(464, 40);
            this.login.TabIndex = 27;
            this.login.Text = "Login";
            this.login.ThemeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.login.MouseDown += new System.Windows.Forms.MouseEventHandler(this.login_MouseDown);
            this.login.MouseMove += new System.Windows.Forms.MouseEventHandler(this.login_MouseMove);
            this.login.MouseUp += new System.Windows.Forms.MouseEventHandler(this.login_MouseUp);
            // 
            // Form_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(211)))));
            this.ClientSize = new System.Drawing.Size(464, 558);
            this.Controls.Add(this.lawBtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.login);
            this.Controls.Add(this.forgetLabel);
            this.Controls.Add(this.showPwCheckBox);
            this.Controls.Add(this.passTextbox);
            this.Controls.Add(this.usernameTextbox);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.regBtn);
            this.Controls.Add(this.passLabel);
            this.Controls.Add(this.usernameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(2560, 1270);
            this.MinimumSize = new System.Drawing.Size(190, 40);
            this.Name = "Form_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Login_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label passLabel;
        private ReaLTaiizor.Controls.HopeButton regBtn;
        private ReaLTaiizor.Controls.HopeButton loginButton;
        private ReaLTaiizor.Controls.HopeTextBox usernameTextbox;
        private ReaLTaiizor.Controls.HopeTextBox passTextbox;
        private ReaLTaiizor.Controls.HopeCheckBox showPwCheckBox;
        private ReaLTaiizor.Controls.HopeButton lawBtn;
        private System.Windows.Forms.Label forgetLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ReaLTaiizor.Forms.HopeForm login;
    }
}