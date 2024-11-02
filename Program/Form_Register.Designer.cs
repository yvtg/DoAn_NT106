namespace Program
{
    partial class Form2
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
            this.registerButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.passTextbox = new System.Windows.Forms.RichTextBox();
            this.usernameTextbox = new System.Windows.Forms.RichTextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.confirmpassTextbox = new System.Windows.Forms.RichTextBox();
            this.confirmpassLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // registerButton
            // 
            this.registerButton.Location = new System.Drawing.Point(244, 235);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(139, 44);
            this.registerButton.TabIndex = 11;
            this.registerButton.Text = "Đăng kí";
            this.registerButton.UseVisualStyleBackColor = true;
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(52, 235);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(139, 44);
            this.backButton.TabIndex = 10;
            this.backButton.Text = "Quay về";
            this.backButton.UseVisualStyleBackColor = true;
            // 
            // passTextbox
            // 
            this.passTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passTextbox.Location = new System.Drawing.Point(131, 108);
            this.passTextbox.Name = "passTextbox";
            this.passTextbox.Size = new System.Drawing.Size(290, 39);
            this.passTextbox.TabIndex = 9;
            this.passTextbox.Text = "";
            // 
            // usernameTextbox
            // 
            this.usernameTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usernameTextbox.Location = new System.Drawing.Point(131, 52);
            this.usernameTextbox.Name = "usernameTextbox";
            this.usernameTextbox.Size = new System.Drawing.Size(290, 39);
            this.usernameTextbox.TabIndex = 8;
            this.usernameTextbox.Text = "";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(12, 119);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(61, 16);
            this.passwordLabel.TabIndex = 7;
            this.passwordLabel.Text = "Mật khẩu";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(12, 66);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(78, 16);
            this.usernameLabel.TabIndex = 6;
            this.usernameLabel.Text = "Tên đăng kí";
            // 
            // confirmpassTextbox
            // 
            this.confirmpassTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.confirmpassTextbox.Location = new System.Drawing.Point(131, 164);
            this.confirmpassTextbox.Name = "confirmpassTextbox";
            this.confirmpassTextbox.Size = new System.Drawing.Size(290, 39);
            this.confirmpassTextbox.TabIndex = 13;
            this.confirmpassTextbox.Text = "";
            // 
            // confirmpassLabel
            // 
            this.confirmpassLabel.AutoSize = true;
            this.confirmpassLabel.Location = new System.Drawing.Point(10, 176);
            this.confirmpassLabel.Name = "confirmpassLabel";
            this.confirmpassLabel.Size = new System.Drawing.Size(114, 16);
            this.confirmpassLabel.TabIndex = 12;
            this.confirmpassLabel.Text = "Nhập lại mật khẩu";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 309);
            this.Controls.Add(this.confirmpassTextbox);
            this.Controls.Add(this.confirmpassLabel);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.passTextbox);
            this.Controls.Add(this.usernameTextbox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameLabel);
            this.Name = "Form2";
            this.Text = "Register";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.RichTextBox passTextbox;
        private System.Windows.Forms.RichTextBox usernameTextbox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.RichTextBox confirmpassTextbox;
        private System.Windows.Forms.Label confirmpassLabel;
    }
}