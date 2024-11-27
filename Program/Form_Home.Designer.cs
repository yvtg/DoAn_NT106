namespace Program
{
    partial class Form_Home
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
            this.joinButton = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.profileButton = new System.Windows.Forms.Button();
            this.logoutBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // joinButton
            // 
            this.joinButton.Location = new System.Drawing.Point(88, 218);
            this.joinButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.joinButton.Name = "joinButton";
            this.joinButton.Size = new System.Drawing.Size(176, 54);
            this.joinButton.TabIndex = 1;
            this.joinButton.Text = "Tham gia";
            this.joinButton.UseVisualStyleBackColor = true;
            this.joinButton.Click += new System.EventHandler(this.joinButton_Click);
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(88, 298);
            this.createButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(176, 54);
            this.createButton.TabIndex = 2;
            this.createButton.Text = "Tạo phòng";
            this.createButton.UseVisualStyleBackColor = true;
            // 
            // profileButton
            // 
            this.profileButton.Location = new System.Drawing.Point(7, 7);
            this.profileButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.profileButton.Name = "profileButton";
            this.profileButton.Size = new System.Drawing.Size(46, 41);
            this.profileButton.TabIndex = 3;
            this.profileButton.Text = "Profile";
            this.profileButton.UseVisualStyleBackColor = true;
            this.profileButton.Click += new System.EventHandler(this.profileButton_Click);
            // 
            // logoutBtn
            // 
            this.logoutBtn.Location = new System.Drawing.Point(88, 373);
            this.logoutBtn.Margin = new System.Windows.Forms.Padding(2);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(176, 54);
            this.logoutBtn.TabIndex = 4;
            this.logoutBtn.Text = "Thoát";
            this.logoutBtn.UseVisualStyleBackColor = true;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // Form_Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 453);
            this.Controls.Add(this.logoutBtn);
            this.Controls.Add(this.profileButton);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.joinButton);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form_Home";
            this.Text = "Home";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button joinButton;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button profileButton;
        private System.Windows.Forms.Button logoutBtn;
    }
}