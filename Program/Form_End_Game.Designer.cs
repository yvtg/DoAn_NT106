namespace Program
{
    partial class Form_End_Game
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_End_Game));
            this.rankListbox = new System.Windows.Forms.ListBox();
            this.hopeForm1 = new ReaLTaiizor.Forms.HopeForm();
            this.profileButton = new ReaLTaiizor.Controls.HopeButton();
            this.homeButton = new ReaLTaiizor.Controls.HopeButton();
            this.SuspendLayout();
            // 
            // rankListbox
            // 
            this.rankListbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(230)))));
            this.rankListbox.FormattingEnabled = true;
            this.rankListbox.Location = new System.Drawing.Point(38, 98);
            this.rankListbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rankListbox.Name = "rankListbox";
            this.rankListbox.Size = new System.Drawing.Size(282, 290);
            this.rankListbox.TabIndex = 0;
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
            this.hopeForm1.TabIndex = 15;
            this.hopeForm1.Text = "Home";
            this.hopeForm1.ThemeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(131)))), ((int)(((byte)(146)))));
            // 
            // profileButton
            // 
            this.profileButton.BorderColor = System.Drawing.Color.Black;
            this.profileButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.profileButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.profileButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.profileButton.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.profileButton.Font = new System.Drawing.Font("Roboto Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.profileButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(131)))), ((int)(((byte)(146)))));
            this.profileButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.profileButton.Location = new System.Drawing.Point(12, 46);
            this.profileButton.Name = "profileButton";
            this.profileButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(226)))), ((int)(((byte)(167)))));
            this.profileButton.Size = new System.Drawing.Size(65, 41);
            this.profileButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.profileButton.TabIndex = 16;
            this.profileButton.Text = "Profile";
            this.profileButton.TextColor = System.Drawing.Color.White;
            this.profileButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.profileButton.Click += new System.EventHandler(this.profileButton_Click);
            // 
            // homeButton
            // 
            this.homeButton.BorderColor = System.Drawing.Color.Black;
            this.homeButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.homeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.homeButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.homeButton.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.homeButton.Font = new System.Drawing.Font("Roboto Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homeButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(131)))), ((int)(((byte)(146)))));
            this.homeButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.homeButton.Location = new System.Drawing.Point(109, 408);
            this.homeButton.Name = "homeButton";
            this.homeButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(226)))), ((int)(((byte)(167)))));
            this.homeButton.Size = new System.Drawing.Size(130, 33);
            this.homeButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.homeButton.TabIndex = 17;
            this.homeButton.Text = "Home";
            this.homeButton.TextColor = System.Drawing.Color.White;
            this.homeButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            // 
            // Form_End_Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(348, 453);
            this.Controls.Add(this.homeButton);
            this.Controls.Add(this.profileButton);
            this.Controls.Add(this.hopeForm1);
            this.Controls.Add(this.rankListbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximumSize = new System.Drawing.Size(1920, 1032);
            this.MinimumSize = new System.Drawing.Size(190, 40);
            this.Name = "Form_End_Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Leader board";
            this.Load += new System.EventHandler(this.Form_End_Game_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox rankListbox;
        private ReaLTaiizor.Forms.HopeForm hopeForm1;
        private ReaLTaiizor.Controls.HopeButton profileButton;
        private ReaLTaiizor.Controls.HopeButton homeButton;
    }
}