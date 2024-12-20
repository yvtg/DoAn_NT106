namespace Program
{
    partial class Form_Profile
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
            this.usernameLabel = new System.Windows.Forms.Label();
            this.maxscoreLabel = new System.Windows.Forms.Label();
            this.countLabel = new System.Windows.Forms.Label();
            this.maxscoreTextbox = new ReaLTaiizor.Controls.HopeTextBox();
            this.usernameTextbox = new ReaLTaiizor.Controls.HopeTextBox();
            this.countTextbox = new ReaLTaiizor.Controls.HopeTextBox();
            this.backButton = new ReaLTaiizor.Controls.HopeButton();
            this.profile = new ReaLTaiizor.Forms.HopeForm();
            this.SuspendLayout();
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Pixel Sans Serif Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.usernameLabel.Location = new System.Drawing.Point(4, 146);
            this.usernameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(100, 21);
            this.usernameLabel.TabIndex = 0;
            this.usernameLabel.Text = "username";
            // 
            // maxscoreLabel
            // 
            this.maxscoreLabel.AutoSize = true;
            this.maxscoreLabel.Font = new System.Drawing.Font("Pixel Sans Serif Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxscoreLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.maxscoreLabel.Location = new System.Drawing.Point(4, 207);
            this.maxscoreLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.maxscoreLabel.Name = "maxscoreLabel";
            this.maxscoreLabel.Size = new System.Drawing.Size(139, 21);
            this.maxscoreLabel.TabIndex = 2;
            this.maxscoreLabel.Text = "highest score";
            // 
            // countLabel
            // 
            this.countLabel.AutoSize = true;
            this.countLabel.Font = new System.Drawing.Font("Pixel Sans Serif Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.countLabel.Location = new System.Drawing.Point(4, 260);
            this.countLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(103, 21);
            this.countLabel.TabIndex = 5;
            this.countLabel.Text = "play times";
            // 
            // maxscoreTextbox
            // 
            this.maxscoreTextbox.BackColor = System.Drawing.Color.White;
            this.maxscoreTextbox.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.maxscoreTextbox.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.maxscoreTextbox.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.maxscoreTextbox.Font = new System.Drawing.Font("FVF Fernando 08", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxscoreTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.maxscoreTextbox.Hint = "";
            this.maxscoreTextbox.Location = new System.Drawing.Point(151, 198);
            this.maxscoreTextbox.MaxLength = 32767;
            this.maxscoreTextbox.Multiline = false;
            this.maxscoreTextbox.Name = "maxscoreTextbox";
            this.maxscoreTextbox.PasswordChar = '\0';
            this.maxscoreTextbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.maxscoreTextbox.SelectedText = "";
            this.maxscoreTextbox.SelectionLength = 0;
            this.maxscoreTextbox.SelectionStart = 0;
            this.maxscoreTextbox.Size = new System.Drawing.Size(185, 44);
            this.maxscoreTextbox.TabIndex = 25;
            this.maxscoreTextbox.TabStop = false;
            this.maxscoreTextbox.UseSystemPasswordChar = false;
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
            this.usernameTextbox.Location = new System.Drawing.Point(151, 134);
            this.usernameTextbox.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.usernameTextbox.MaxLength = 32767;
            this.usernameTextbox.Multiline = false;
            this.usernameTextbox.Name = "usernameTextbox";
            this.usernameTextbox.PasswordChar = '\0';
            this.usernameTextbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.usernameTextbox.SelectedText = "";
            this.usernameTextbox.SelectionLength = 0;
            this.usernameTextbox.SelectionStart = 0;
            this.usernameTextbox.Size = new System.Drawing.Size(185, 44);
            this.usernameTextbox.TabIndex = 24;
            this.usernameTextbox.TabStop = false;
            this.usernameTextbox.UseSystemPasswordChar = false;
            // 
            // countTextbox
            // 
            this.countTextbox.BackColor = System.Drawing.Color.White;
            this.countTextbox.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.countTextbox.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.countTextbox.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.countTextbox.Font = new System.Drawing.Font("FVF Fernando 08", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.countTextbox.Hint = "";
            this.countTextbox.Location = new System.Drawing.Point(151, 260);
            this.countTextbox.MaxLength = 32767;
            this.countTextbox.Multiline = false;
            this.countTextbox.Name = "countTextbox";
            this.countTextbox.PasswordChar = '\0';
            this.countTextbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.countTextbox.SelectedText = "";
            this.countTextbox.SelectionLength = 0;
            this.countTextbox.SelectionStart = 0;
            this.countTextbox.Size = new System.Drawing.Size(185, 44);
            this.countTextbox.TabIndex = 28;
            this.countTextbox.TabStop = false;
            this.countTextbox.UseSystemPasswordChar = false;
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
            this.backButton.Location = new System.Drawing.Point(119, 349);
            this.backButton.Name = "backButton";
            this.backButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(168)))), ((int)(((byte)(117)))));
            this.backButton.Size = new System.Drawing.Size(104, 36);
            this.backButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.backButton.TabIndex = 29;
            this.backButton.Text = "Quay về";
            this.backButton.TextColor = System.Drawing.Color.White;
            this.backButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.backButton.Click += new System.EventHandler(this.backButton_Click_1);
            // 
            // profile
            // 
            this.profile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(211)))));
            this.profile.ControlBoxColorH = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.profile.ControlBoxColorHC = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.profile.ControlBoxColorN = System.Drawing.Color.White;
            this.profile.Cursor = System.Windows.Forms.Cursors.Default;
            this.profile.Dock = System.Windows.Forms.DockStyle.Top;
            this.profile.Font = new System.Drawing.Font("SVN-Retron 2000", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.profile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.profile.Image = null;
            this.profile.Location = new System.Drawing.Point(0, 0);
            this.profile.Name = "profile";
            this.profile.Size = new System.Drawing.Size(348, 40);
            this.profile.TabIndex = 30;
            this.profile.Text = "Profile";
            this.profile.ThemeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            // 
            // Form_Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(230)))));
            this.BackgroundImage = global::Program.Properties.Resources.background2;
            this.ClientSize = new System.Drawing.Size(348, 453);
            this.Controls.Add(this.profile);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.countTextbox);
            this.Controls.Add(this.maxscoreTextbox);
            this.Controls.Add(this.usernameTextbox);
            this.Controls.Add(this.countLabel);
            this.Controls.Add(this.maxscoreLabel);
            this.Controls.Add(this.usernameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(1920, 1032);
            this.MinimumSize = new System.Drawing.Size(190, 40);
            this.Name = "Form_Profile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Profile";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label maxscoreLabel;
        private System.Windows.Forms.Label countLabel;
        private ReaLTaiizor.Controls.HopeTextBox maxscoreTextbox;
        private ReaLTaiizor.Controls.HopeTextBox usernameTextbox;
        private ReaLTaiizor.Controls.HopeTextBox countTextbox;
        private ReaLTaiizor.Controls.HopeButton backButton;
        private ReaLTaiizor.Forms.HopeForm profile;
    }
}