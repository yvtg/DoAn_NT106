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
            this.rankListbox = new System.Windows.Forms.ListBox();
            this.profileButton = new ReaLTaiizor.Controls.HopeButton();
            this.homeButton = new ReaLTaiizor.Controls.HopeButton();
            this.board = new ReaLTaiizor.Forms.HopeForm();
            this.SuspendLayout();
            // 
            // rankListbox
            // 
            this.rankListbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(230)))));
            this.rankListbox.FormattingEnabled = true;
            this.rankListbox.Location = new System.Drawing.Point(38, 98);
            this.rankListbox.Margin = new System.Windows.Forms.Padding(2);
            this.rankListbox.Name = "rankListbox";
            this.rankListbox.Size = new System.Drawing.Size(282, 290);
            this.rankListbox.TabIndex = 0;
            // 
            // profileButton
            // 
            this.profileButton.BorderColor = System.Drawing.Color.Black;
            this.profileButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.profileButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.profileButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.profileButton.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.profileButton.Font = new System.Drawing.Font("Pixel Sans Serif Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.profileButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.profileButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.profileButton.Location = new System.Drawing.Point(12, 46);
            this.profileButton.Name = "profileButton";
            this.profileButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(168)))), ((int)(((byte)(117)))));
            this.profileButton.Size = new System.Drawing.Size(84, 41);
            this.profileButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.profileButton.TabIndex = 16;
            this.profileButton.Text = "profile";
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
            this.homeButton.Font = new System.Drawing.Font("Pixel Sans Serif Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homeButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.homeButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.homeButton.Location = new System.Drawing.Point(109, 408);
            this.homeButton.Name = "homeButton";
            this.homeButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(168)))), ((int)(((byte)(117)))));
            this.homeButton.Size = new System.Drawing.Size(130, 33);
            this.homeButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.homeButton.TabIndex = 17;
            this.homeButton.Text = "home";
            this.homeButton.TextColor = System.Drawing.Color.White;
            this.homeButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.homeButton.Click += new System.EventHandler(this.homeButton_Click_1);
            // 
            // board
            // 
            this.board.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(211)))));
            this.board.ControlBoxColorH = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.board.ControlBoxColorHC = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.board.ControlBoxColorN = System.Drawing.Color.White;
            this.board.Cursor = System.Windows.Forms.Cursors.Default;
            this.board.Dock = System.Windows.Forms.DockStyle.Top;
            this.board.Font = new System.Drawing.Font("SVN-Retron 2000", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.board.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.board.Image = null;
            this.board.Location = new System.Drawing.Point(0, 0);
            this.board.Name = "board";
            this.board.Size = new System.Drawing.Size(348, 40);
            this.board.TabIndex = 28;
            this.board.Text = "score board";
            this.board.ThemeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            // 
            // Form_End_Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(211)))));
            this.ClientSize = new System.Drawing.Size(348, 453);
            this.Controls.Add(this.board);
            this.Controls.Add(this.homeButton);
            this.Controls.Add(this.profileButton);
            this.Controls.Add(this.rankListbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private ReaLTaiizor.Controls.HopeButton profileButton;
        private ReaLTaiizor.Controls.HopeButton homeButton;
        private ReaLTaiizor.Forms.HopeForm board;
    }
}