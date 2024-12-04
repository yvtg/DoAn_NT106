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
            this.hopeForm1 = new ReaLTaiizor.Forms.HopeForm();
            this.emailTextbox = new ReaLTaiizor.Controls.HopeTextBox();
            this.usernameTextbox = new ReaLTaiizor.Controls.HopeTextBox();
            this.confirmpassTextbox = new ReaLTaiizor.Controls.HopeTextBox();
            this.passwordTextbox = new ReaLTaiizor.Controls.HopeTextBox();
            this.registerButton = new ReaLTaiizor.Controls.HopeButton();
            this.backButton = new ReaLTaiizor.Controls.HopeButton();
            this.showPwCheckBox = new ReaLTaiizor.Controls.HopeCheckBox();
            this.SuspendLayout();
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Roboto Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLabel.Location = new System.Drawing.Point(9, 237);
            this.passwordLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(72, 18);
            this.passwordLabel.TabIndex = 7;
            this.passwordLabel.Text = "Mật khẩu";
            // 
            // confirmpassLabel
            // 
            this.confirmpassLabel.AutoSize = true;
            this.confirmpassLabel.Font = new System.Drawing.Font("Roboto Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmpassLabel.Location = new System.Drawing.Point(9, 286);
            this.confirmpassLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.confirmpassLabel.Name = "confirmpassLabel";
            this.confirmpassLabel.Size = new System.Drawing.Size(144, 18);
            this.confirmpassLabel.TabIndex = 12;
            this.confirmpassLabel.Text = "Nhập lại mật khẩu";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Roboto Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.Location = new System.Drawing.Point(9, 148);
            this.usernameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(96, 18);
            this.usernameLabel.TabIndex = 6;
            this.usernameLabel.Text = "Tên đăng kí";
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("Roboto Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLabel.Location = new System.Drawing.Point(9, 193);
            this.emailLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(48, 18);
            this.emailLabel.TabIndex = 14;
            this.emailLabel.Text = "Email";
            // 
            // hopeForm1
            // 
            this.hopeForm1.ControlBoxColorH = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.hopeForm1.ControlBoxColorHC = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.hopeForm1.ControlBoxColorN = System.Drawing.Color.White;
            this.hopeForm1.Cursor = System.Windows.Forms.Cursors.Default;
            this.hopeForm1.Dock = System.Windows.Forms.DockStyle.Top;
            this.hopeForm1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.hopeForm1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.hopeForm1.Image = ((System.Drawing.Image)(resources.GetObject("hopeForm1.Image")));
            this.hopeForm1.Location = new System.Drawing.Point(0, 0);
            this.hopeForm1.Name = "hopeForm1";
            this.hopeForm1.Size = new System.Drawing.Size(348, 40);
            this.hopeForm1.TabIndex = 19;
            this.hopeForm1.Text = "Register";
            this.hopeForm1.ThemeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(131)))), ((int)(((byte)(146)))));
            // 
            // emailTextbox
            // 
            this.emailTextbox.BackColor = System.Drawing.Color.White;
            this.emailTextbox.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(226)))), ((int)(((byte)(167)))));
            this.emailTextbox.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(226)))), ((int)(((byte)(167)))));
            this.emailTextbox.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(226)))), ((int)(((byte)(167)))));
            this.emailTextbox.Font = new System.Drawing.Font("Roboto Mono", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.emailTextbox.Hint = "";
            this.emailTextbox.Location = new System.Drawing.Point(151, 183);
            this.emailTextbox.MaxLength = 32767;
            this.emailTextbox.Multiline = false;
            this.emailTextbox.Name = "emailTextbox";
            this.emailTextbox.PasswordChar = '\0';
            this.emailTextbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.emailTextbox.SelectedText = "";
            this.emailTextbox.SelectionLength = 0;
            this.emailTextbox.SelectionStart = 0;
            this.emailTextbox.Size = new System.Drawing.Size(185, 36);
            this.emailTextbox.TabIndex = 21;
            this.emailTextbox.TabStop = false;
            this.emailTextbox.UseSystemPasswordChar = false;
            // 
            // usernameTextbox
            // 
            this.usernameTextbox.BackColor = System.Drawing.Color.White;
            this.usernameTextbox.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(226)))), ((int)(((byte)(167)))));
            this.usernameTextbox.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(226)))), ((int)(((byte)(167)))));
            this.usernameTextbox.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(226)))), ((int)(((byte)(167)))));
            this.usernameTextbox.Font = new System.Drawing.Font("Roboto Mono", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.usernameTextbox.Hint = "";
            this.usernameTextbox.Location = new System.Drawing.Point(151, 139);
            this.usernameTextbox.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.usernameTextbox.MaxLength = 32767;
            this.usernameTextbox.Multiline = false;
            this.usernameTextbox.Name = "usernameTextbox";
            this.usernameTextbox.PasswordChar = '\0';
            this.usernameTextbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.usernameTextbox.SelectedText = "";
            this.usernameTextbox.SelectionLength = 0;
            this.usernameTextbox.SelectionStart = 0;
            this.usernameTextbox.Size = new System.Drawing.Size(185, 36);
            this.usernameTextbox.TabIndex = 20;
            this.usernameTextbox.TabStop = false;
            this.usernameTextbox.UseSystemPasswordChar = false;
            // 
            // confirmpassTextbox
            // 
            this.confirmpassTextbox.BackColor = System.Drawing.Color.White;
            this.confirmpassTextbox.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(226)))), ((int)(((byte)(167)))));
            this.confirmpassTextbox.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(226)))), ((int)(((byte)(167)))));
            this.confirmpassTextbox.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(226)))), ((int)(((byte)(167)))));
            this.confirmpassTextbox.Font = new System.Drawing.Font("Roboto Mono", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmpassTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.confirmpassTextbox.Hint = "";
            this.confirmpassTextbox.Location = new System.Drawing.Point(151, 270);
            this.confirmpassTextbox.MaxLength = 32767;
            this.confirmpassTextbox.Multiline = false;
            this.confirmpassTextbox.Name = "confirmpassTextbox";
            this.confirmpassTextbox.PasswordChar = '\0';
            this.confirmpassTextbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.confirmpassTextbox.SelectedText = "";
            this.confirmpassTextbox.SelectionLength = 0;
            this.confirmpassTextbox.SelectionStart = 0;
            this.confirmpassTextbox.Size = new System.Drawing.Size(185, 36);
            this.confirmpassTextbox.TabIndex = 23;
            this.confirmpassTextbox.TabStop = false;
            this.confirmpassTextbox.UseSystemPasswordChar = true;
            // 
            // passwordTextbox
            // 
            this.passwordTextbox.BackColor = System.Drawing.Color.White;
            this.passwordTextbox.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(226)))), ((int)(((byte)(167)))));
            this.passwordTextbox.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(226)))), ((int)(((byte)(167)))));
            this.passwordTextbox.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(226)))), ((int)(((byte)(167)))));
            this.passwordTextbox.Font = new System.Drawing.Font("Roboto Mono", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.passwordTextbox.Hint = "";
            this.passwordTextbox.Location = new System.Drawing.Point(151, 225);
            this.passwordTextbox.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.passwordTextbox.MaxLength = 32767;
            this.passwordTextbox.Multiline = false;
            this.passwordTextbox.Name = "passwordTextbox";
            this.passwordTextbox.PasswordChar = '\0';
            this.passwordTextbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.passwordTextbox.SelectedText = "";
            this.passwordTextbox.SelectionLength = 0;
            this.passwordTextbox.SelectionStart = 0;
            this.passwordTextbox.Size = new System.Drawing.Size(185, 36);
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
            this.registerButton.Font = new System.Drawing.Font("Roboto Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(131)))), ((int)(((byte)(146)))));
            this.registerButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.registerButton.Location = new System.Drawing.Point(187, 369);
            this.registerButton.Name = "registerButton";
            this.registerButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(226)))), ((int)(((byte)(167)))));
            this.registerButton.Size = new System.Drawing.Size(104, 36);
            this.registerButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.registerButton.TabIndex = 25;
            this.registerButton.Text = "Đăng ký";
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
            this.backButton.Font = new System.Drawing.Font("Roboto Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(131)))), ((int)(((byte)(146)))));
            this.backButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.backButton.Location = new System.Drawing.Point(48, 369);
            this.backButton.Name = "backButton";
            this.backButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(226)))), ((int)(((byte)(167)))));
            this.backButton.Size = new System.Drawing.Size(104, 36);
            this.backButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.backButton.TabIndex = 24;
            this.backButton.Text = "Quay về";
            this.backButton.TextColor = System.Drawing.Color.White;
            this.backButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.backButton.Click += new System.EventHandler(this.backButton_Click_1);
            // 
            // showPwCheckBox
            // 
            this.showPwCheckBox.AutoSize = true;
            this.showPwCheckBox.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(131)))), ((int)(((byte)(146)))));
            this.showPwCheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showPwCheckBox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(198)))), ((int)(((byte)(202)))));
            this.showPwCheckBox.DisabledStringColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(187)))), ((int)(((byte)(189)))));
            this.showPwCheckBox.Enable = true;
            this.showPwCheckBox.EnabledCheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(131)))), ((int)(((byte)(146)))));
            this.showPwCheckBox.EnabledStringColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.showPwCheckBox.EnabledUncheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(158)))), ((int)(((byte)(161)))));
            this.showPwCheckBox.Font = new System.Drawing.Font("Roboto Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showPwCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.showPwCheckBox.Location = new System.Drawing.Point(151, 323);
            this.showPwCheckBox.Name = "showPwCheckBox";
            this.showPwCheckBox.Size = new System.Drawing.Size(165, 20);
            this.showPwCheckBox.TabIndex = 26;
            this.showPwCheckBox.Text = "Hiện mật khẩu";
            this.showPwCheckBox.UseVisualStyleBackColor = true;
            this.showPwCheckBox.CheckedChanged += new System.EventHandler(this.showPwCheckBox_CheckedChanged);
            // 
            // Form_Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(348, 453);
            this.Controls.Add(this.showPwCheckBox);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.confirmpassTextbox);
            this.Controls.Add(this.passwordTextbox);
            this.Controls.Add(this.emailTextbox);
            this.Controls.Add(this.usernameTextbox);
            this.Controls.Add(this.hopeForm1);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.confirmpassLabel);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(1920, 1032);
            this.MinimumSize = new System.Drawing.Size(190, 40);
            this.Name = "Form_Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label confirmpassLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label emailLabel;
        private ReaLTaiizor.Forms.HopeForm hopeForm1;
        private ReaLTaiizor.Controls.HopeTextBox emailTextbox;
        private ReaLTaiizor.Controls.HopeTextBox usernameTextbox;
        private ReaLTaiizor.Controls.HopeTextBox confirmpassTextbox;
        private ReaLTaiizor.Controls.HopeTextBox passwordTextbox;
        private ReaLTaiizor.Controls.HopeButton registerButton;
        private ReaLTaiizor.Controls.HopeButton backButton;
        private ReaLTaiizor.Controls.HopeCheckBox showPwCheckBox;
    }
}