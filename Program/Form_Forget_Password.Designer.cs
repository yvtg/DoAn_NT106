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
            this.backButton = new System.Windows.Forms.Button();
            this.sendButton = new System.Windows.Forms.Button();
            this.emailTextbox = new ReaLTaiizor.Controls.HopeTextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.apppassTextbox = new ReaLTaiizor.Controls.HopeTextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.ForgetPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForgetPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.ForgetPassword.Image = null;
            this.ForgetPassword.Location = new System.Drawing.Point(0, 0);
            this.ForgetPassword.Margin = new System.Windows.Forms.Padding(4);
            this.ForgetPassword.Name = "ForgetPassword";
            this.ForgetPassword.Size = new System.Drawing.Size(464, 40);
            this.ForgetPassword.TabIndex = 59;
            this.ForgetPassword.Text = "Forget Password";
            this.ForgetPassword.ThemeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(168, 420);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(129, 50);
            this.backButton.TabIndex = 62;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(167, 352);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(131, 47);
            this.sendButton.TabIndex = 61;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // emailTextbox
            // 
            this.emailTextbox.BackColor = System.Drawing.Color.White;
            this.emailTextbox.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.emailTextbox.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.emailTextbox.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.emailTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.emailTextbox.Hint = "";
            this.emailTextbox.Location = new System.Drawing.Point(152, 245);
            this.emailTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.emailTextbox.MaxLength = 32767;
            this.emailTextbox.Multiline = false;
            this.emailTextbox.Name = "emailTextbox";
            this.emailTextbox.PasswordChar = '\0';
            this.emailTextbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.emailTextbox.SelectedText = "";
            this.emailTextbox.SelectionLength = 0;
            this.emailTextbox.SelectionStart = 0;
            this.emailTextbox.Size = new System.Drawing.Size(292, 35);
            this.emailTextbox.TabIndex = 60;
            this.emailTextbox.TabStop = false;
            this.emailTextbox.UseSystemPasswordChar = false;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.emailLabel.Location = new System.Drawing.Point(12, 245);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(49, 20);
            this.emailLabel.TabIndex = 59;
            this.emailLabel.Text = "email";
            // 
            // apppassTextbox
            // 
            this.apppassTextbox.BackColor = System.Drawing.Color.White;
            this.apppassTextbox.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.apppassTextbox.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.apppassTextbox.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.apppassTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apppassTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.apppassTextbox.Hint = "";
            this.apppassTextbox.Location = new System.Drawing.Point(159, 288);
            this.apppassTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.apppassTextbox.MaxLength = 32767;
            this.apppassTextbox.Multiline = false;
            this.apppassTextbox.Name = "apppassTextbox";
            this.apppassTextbox.PasswordChar = '\0';
            this.apppassTextbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.apppassTextbox.SelectedText = "";
            this.apppassTextbox.SelectionLength = 0;
            this.apppassTextbox.SelectionStart = 0;
            this.apppassTextbox.Size = new System.Drawing.Size(292, 35);
            this.apppassTextbox.TabIndex = 64;
            this.apppassTextbox.TabStop = false;
            this.apppassTextbox.UseSystemPasswordChar = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.label1.Location = new System.Drawing.Point(19, 288);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 20);
            this.label1.TabIndex = 63;
            this.label1.Text = "app password";
            // 
            // Form_Forget_Password
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(211)))));
            this.ClientSize = new System.Drawing.Size(464, 558);
            this.Controls.Add(this.apppassTextbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.ForgetPassword);
            this.Controls.Add(this.emailTextbox);
            this.Controls.Add(this.emailLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(1920, 1020);
            this.MinimumSize = new System.Drawing.Size(190, 40);
            this.Name = "Form_Forget_Password";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Forget_Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ReaLTaiizor.Forms.HopeForm ForgetPassword;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button sendButton;
        private ReaLTaiizor.Controls.HopeTextBox emailTextbox;
        private System.Windows.Forms.Label emailLabel;
        private ReaLTaiizor.Controls.HopeTextBox apppassTextbox;
        private System.Windows.Forms.Label label1;
    }
}