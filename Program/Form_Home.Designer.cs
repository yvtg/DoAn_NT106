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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Home));
            this.profileButton = new ReaLTaiizor.Controls.HopeButton();
            this.createButton = new ReaLTaiizor.Controls.HopeButton();
            this.joinButton = new ReaLTaiizor.Controls.HopeButton();
            this.logoutBtn = new ReaLTaiizor.Controls.HopeButton();
            this.Home = new ReaLTaiizor.Forms.HopeForm();
            this.SuspendLayout();
            // 
            // profileButton
            // 
            this.profileButton.BorderColor = System.Drawing.Color.Black;
            this.profileButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.profileButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.profileButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.profileButton.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.profileButton.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.profileButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.profileButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.profileButton.Location = new System.Drawing.Point(344, 71);
            this.profileButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.profileButton.Name = "profileButton";
            this.profileButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(107)))), ((int)(((byte)(111)))));
            this.profileButton.Size = new System.Drawing.Size(104, 50);
            this.profileButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.profileButton.TabIndex = 15;
            this.profileButton.Text = "Profile";
            this.profileButton.TextColor = System.Drawing.Color.White;
            this.profileButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.profileButton.Click += new System.EventHandler(this.profileButton_Click_1);
            // 
            // createButton
            // 
            this.createButton.BorderColor = System.Drawing.Color.Black;
            this.createButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.createButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.createButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.createButton.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.createButton.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.createButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.createButton.Location = new System.Drawing.Point(116, 186);
            this.createButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.createButton.Name = "createButton";
            this.createButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(168)))), ((int)(((byte)(117)))));
            this.createButton.Size = new System.Drawing.Size(235, 66);
            this.createButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.createButton.TabIndex = 16;
            this.createButton.Text = "Create Room";
            this.createButton.TextColor = System.Drawing.Color.White;
            this.createButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // joinButton
            // 
            this.joinButton.BorderColor = System.Drawing.Color.Black;
            this.joinButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.joinButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.joinButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.joinButton.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.joinButton.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.joinButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.joinButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.joinButton.Location = new System.Drawing.Point(116, 293);
            this.joinButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.joinButton.Name = "joinButton";
            this.joinButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(168)))), ((int)(((byte)(117)))));
            this.joinButton.Size = new System.Drawing.Size(235, 66);
            this.joinButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.joinButton.TabIndex = 17;
            this.joinButton.Text = "Join Room";
            this.joinButton.TextColor = System.Drawing.Color.White;
            this.joinButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.joinButton.Click += new System.EventHandler(this.joinButton_Click_1);
            // 
            // logoutBtn
            // 
            this.logoutBtn.BorderColor = System.Drawing.Color.Black;
            this.logoutBtn.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.logoutBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logoutBtn.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.logoutBtn.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.logoutBtn.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutBtn.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.logoutBtn.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.logoutBtn.Location = new System.Drawing.Point(116, 399);
            this.logoutBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(168)))), ((int)(((byte)(117)))));
            this.logoutBtn.Size = new System.Drawing.Size(235, 66);
            this.logoutBtn.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.logoutBtn.TabIndex = 18;
            this.logoutBtn.Text = "Log Out";
            this.logoutBtn.TextColor = System.Drawing.Color.White;
            this.logoutBtn.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click_1);
            // 
            // Home
            // 
            this.Home.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(211)))));
            this.Home.ControlBoxColorH = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.Home.ControlBoxColorHC = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.Home.ControlBoxColorN = System.Drawing.Color.White;
            this.Home.Cursor = System.Windows.Forms.Cursors.Default;
            this.Home.Dock = System.Windows.Forms.DockStyle.Top;
            this.Home.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Home.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.Home.Image = null;
            this.Home.Location = new System.Drawing.Point(0, 0);
            this.Home.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Home.Name = "Home";
            this.Home.Size = new System.Drawing.Size(464, 40);
            this.Home.TabIndex = 28;
            this.Home.Text = "Home";
            this.Home.ThemeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            // 
            // Form_Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(230)))));
            this.BackgroundImage = global::Program.Properties.Resources.background2;
            this.ClientSize = new System.Drawing.Size(464, 558);
            this.Controls.Add(this.Home);
            this.Controls.Add(this.logoutBtn);
            this.Controls.Add(this.joinButton);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.profileButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(2560, 1270);
            this.MinimumSize = new System.Drawing.Size(190, 40);
            this.Name = "Form_Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.ResumeLayout(false);

        }

        #endregion
        private ReaLTaiizor.Controls.HopeButton profileButton;
        private ReaLTaiizor.Controls.HopeButton createButton;
        private ReaLTaiizor.Controls.HopeButton joinButton;
        private ReaLTaiizor.Controls.HopeButton logoutBtn;
        private ReaLTaiizor.Forms.HopeForm Home;
    }
}