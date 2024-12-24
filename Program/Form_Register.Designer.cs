namespace Program
{
    partial class Form_Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Register));
            this.passwordLabel = new System.Windows.Forms.Label();
            this.confirmpassLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.emailTextbox = new ReaLTaiizor.Controls.HopeTextBox();
            this.usernameTextbox = new ReaLTaiizor.Controls.HopeTextBox();
            this.confirmpassTextbox = new ReaLTaiizor.Controls.HopeTextBox();
            this.passwordTextbox = new ReaLTaiizor.Controls.HopeTextBox();
            this.registerButton = new ReaLTaiizor.Controls.HopeButton();
            this.backButton = new ReaLTaiizor.Controls.HopeButton();
            this.showPwCheckBox = new ReaLTaiizor.Controls.HopeCheckBox();
            this.register = new ReaLTaiizor.Forms.HopeForm();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Pixel Sans Serif Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.passwordLabel.Location = new System.Drawing.Point(11, 263);
            this.passwordLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(100, 21);
            this.passwordLabel.TabIndex = 7;
            this.passwordLabel.Text = "password";
            // 
            // confirmpassLabel
            // 
            this.confirmpassLabel.AutoSize = true;
            this.confirmpassLabel.Font = new System.Drawing.Font("Pixel Sans Serif Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmpassLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.confirmpassLabel.Location = new System.Drawing.Point(11, 313);
            this.confirmpassLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.confirmpassLabel.Name = "confirmpassLabel";
            this.confirmpassLabel.Size = new System.Drawing.Size(100, 42);
            this.confirmpassLabel.TabIndex = 12;
            this.confirmpassLabel.Text = "confirm\r\npassword";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Pixel Sans Serif Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.usernameLabel.Location = new System.Drawing.Point(11, 163);
            this.usernameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(100, 21);
            this.usernameLabel.TabIndex = 6;
            this.usernameLabel.Text = "username";
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("Pixel Sans Serif Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.emailLabel.Location = new System.Drawing.Point(11, 213);
            this.emailLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(56, 21);
            this.emailLabel.TabIndex = 14;
            this.emailLabel.Text = "email";
            // 
            // emailTextbox
            // 
            this.emailTextbox.BackColor = System.Drawing.Color.White;
            this.emailTextbox.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.emailTextbox.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.emailTextbox.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.emailTextbox.Font = new System.Drawing.Font("FVF Fernando 08", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.emailTextbox.Hint = "";
            this.emailTextbox.Location = new System.Drawing.Point(126, 213);
            this.emailTextbox.MaxLength = 32767;
            this.emailTextbox.Multiline = false;
            this.emailTextbox.Name = "emailTextbox";
            this.emailTextbox.PasswordChar = '\0';
            this.emailTextbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.emailTextbox.SelectedText = "";
            this.emailTextbox.SelectionLength = 0;
            this.emailTextbox.SelectionStart = 0;
            this.emailTextbox.Size = new System.Drawing.Size(210, 44);
            this.emailTextbox.TabIndex = 21;
            this.emailTextbox.TabStop = false;
            this.emailTextbox.UseSystemPasswordChar = false;
            // 
            // usernameTextbox
            // 
            this.usernameTextbox.BackColor = System.Drawing.Color.White;
            this.usernameTextbox.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.usernameTextbox.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.usernameTextbox.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.usernameTextbox.Font = new System.Drawing.Font("FVF Fernando 08", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.usernameTextbox.Hint = "";
            this.usernameTextbox.Location = new System.Drawing.Point(126, 163);
            this.usernameTextbox.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.usernameTextbox.MaxLength = 32767;
            this.usernameTextbox.Multiline = false;
            this.usernameTextbox.Name = "usernameTextbox";
            this.usernameTextbox.PasswordChar = '\0';
            this.usernameTextbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.usernameTextbox.SelectedText = "";
            this.usernameTextbox.SelectionLength = 0;
            this.usernameTextbox.SelectionStart = 0;
            this.usernameTextbox.Size = new System.Drawing.Size(210, 44);
            this.usernameTextbox.TabIndex = 20;
            this.usernameTextbox.TabStop = false;
            this.usernameTextbox.UseSystemPasswordChar = false;
            // 
            // confirmpassTextbox
            // 
            this.confirmpassTextbox.BackColor = System.Drawing.Color.White;
            this.confirmpassTextbox.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.confirmpassTextbox.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.confirmpassTextbox.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.confirmpassTextbox.Font = new System.Drawing.Font("FVF Fernando 08", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmpassTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.confirmpassTextbox.Hint = "";
            this.confirmpassTextbox.Location = new System.Drawing.Point(126, 313);
            this.confirmpassTextbox.MaxLength = 32767;
            this.confirmpassTextbox.Multiline = false;
            this.confirmpassTextbox.Name = "confirmpassTextbox";
            this.confirmpassTextbox.PasswordChar = '\0';
            this.confirmpassTextbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.confirmpassTextbox.SelectedText = "";
            this.confirmpassTextbox.SelectionLength = 0;
            this.confirmpassTextbox.SelectionStart = 0;
            this.confirmpassTextbox.Size = new System.Drawing.Size(210, 44);
            this.confirmpassTextbox.TabIndex = 23;
            this.confirmpassTextbox.TabStop = false;
            this.confirmpassTextbox.UseSystemPasswordChar = true;
            // 
            // passwordTextbox
            // 
            this.passwordTextbox.BackColor = System.Drawing.Color.White;
            this.passwordTextbox.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.passwordTextbox.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.passwordTextbox.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.passwordTextbox.Font = new System.Drawing.Font("FVF Fernando 08", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.passwordTextbox.Hint = "";
            this.passwordTextbox.Location = new System.Drawing.Point(126, 263);
            this.passwordTextbox.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.passwordTextbox.MaxLength = 32767;
            this.passwordTextbox.Multiline = false;
            this.passwordTextbox.Name = "passwordTextbox";
            this.passwordTextbox.PasswordChar = '\0';
            this.passwordTextbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.passwordTextbox.SelectedText = "";
            this.passwordTextbox.SelectionLength = 0;
            this.passwordTextbox.SelectionStart = 0;
            this.passwordTextbox.Size = new System.Drawing.Size(210, 44);
            this.passwordTextbox.TabIndex = 22;
            this.passwordTextbox.TabStop = false;
            this.passwordTextbox.UseSystemPasswordChar = true;
            // 
            // registerButton
            // 
            this.registerButton.BorderColor = System.Drawing.Color.Black;
            this.registerButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.registerButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.registerButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.registerButton.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.registerButton.Font = new System.Drawing.Font("Pixel Sans Serif Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.registerButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.registerButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.registerButton.Location = new System.Drawing.Point(197, 405);
            this.registerButton.Name = "registerButton";
            this.registerButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(168)))), ((int)(((byte)(117)))));
            this.registerButton.Size = new System.Drawing.Size(104, 36);
            this.registerButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.registerButton.TabIndex = 25;
            this.registerButton.Text = "register";
            this.registerButton.TextColor = System.Drawing.Color.White;
            this.registerButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click_1);
            // 
            // backButton
            // 
            this.backButton.BorderColor = System.Drawing.Color.Black;
            this.backButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.backButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.backButton.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.backButton.Font = new System.Drawing.Font("Pixel Sans Serif Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.backButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.backButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.backButton.Location = new System.Drawing.Point(48, 405);
            this.backButton.Name = "backButton";
            this.backButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(168)))), ((int)(((byte)(117)))));
            this.backButton.Size = new System.Drawing.Size(104, 36);
            this.backButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.backButton.TabIndex = 24;
            this.backButton.Text = "back";
            this.backButton.TextColor = System.Drawing.Color.White;
            this.backButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.backButton.Click += new System.EventHandler(this.backButton_Click_1);
            // 
            // showPwCheckBox
            // 
            this.showPwCheckBox.AutoSize = true;
            this.showPwCheckBox.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.showPwCheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showPwCheckBox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(168)))), ((int)(((byte)(117)))));
            this.showPwCheckBox.DisabledStringColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.showPwCheckBox.Enable = true;
            this.showPwCheckBox.EnabledCheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(107)))), ((int)(((byte)(111)))));
            this.showPwCheckBox.EnabledStringColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(107)))), ((int)(((byte)(111)))));
            this.showPwCheckBox.EnabledUncheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(168)))), ((int)(((byte)(117)))));
            this.showPwCheckBox.Font = new System.Drawing.Font("Pixel Sans Serif Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showPwCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.showPwCheckBox.Location = new System.Drawing.Point(126, 363);
            this.showPwCheckBox.Name = "showPwCheckBox";
            this.showPwCheckBox.Size = new System.Drawing.Size(174, 20);
            this.showPwCheckBox.TabIndex = 26;
            this.showPwCheckBox.Text = "show password";
            this.showPwCheckBox.UseVisualStyleBackColor = true;
            this.showPwCheckBox.CheckedChanged += new System.EventHandler(this.showPwCheckBox_CheckedChanged);
            // 
            // register
            // 
            this.register.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(211)))));
            this.register.ControlBoxColorH = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.register.ControlBoxColorHC = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.register.ControlBoxColorN = System.Drawing.Color.White;
            this.register.Cursor = System.Windows.Forms.Cursors.Default;
            this.register.Dock = System.Windows.Forms.DockStyle.Top;
            this.register.Font = new System.Drawing.Font("SVN-Retron 2000", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.register.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.register.Image = null;
            this.register.Location = new System.Drawing.Point(0, 0);
            this.register.Name = "register";
            this.register.Size = new System.Drawing.Size(348, 40);
            this.register.TabIndex = 28;
            this.register.Text = "Register";
            this.register.ThemeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(33, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(289, 97);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // Form_Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(211)))));
            this.ClientSize = new System.Drawing.Size(348, 453);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.register);
            this.Controls.Add(this.showPwCheckBox);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.confirmpassTextbox);
            this.Controls.Add(this.passwordTextbox);
            this.Controls.Add(this.emailTextbox);
            this.Controls.Add(this.usernameTextbox);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.confirmpassLabel);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(1920, 1032);
            this.MinimumSize = new System.Drawing.Size(190, 40);
            this.Name = "Form_Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label confirmpassLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label emailLabel;
        private ReaLTaiizor.Controls.HopeTextBox emailTextbox;
        private ReaLTaiizor.Controls.HopeTextBox usernameTextbox;
        private ReaLTaiizor.Controls.HopeTextBox confirmpassTextbox;
        private ReaLTaiizor.Controls.HopeTextBox passwordTextbox;
        private ReaLTaiizor.Controls.HopeButton registerButton;
        private ReaLTaiizor.Controls.HopeButton backButton;
        private ReaLTaiizor.Controls.HopeCheckBox showPwCheckBox;
        private ReaLTaiizor.Forms.HopeForm register;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}