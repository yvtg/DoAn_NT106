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
            this.profileButton = new ReaLTaiizor.Controls.HopeButton();
            this.ReturnButton = new ReaLTaiizor.Controls.HopeButton();
            this.board = new ReaLTaiizor.Forms.HopeForm();
            this.SuspendLayout();
            // 
            // rankListbox
            // 
            this.rankListbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(230)))));
            this.rankListbox.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rankListbox.FormattingEnabled = true;
            this.rankListbox.ItemHeight = 20;
            this.rankListbox.Location = new System.Drawing.Point(44, 125);
            this.rankListbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rankListbox.Name = "rankListbox";
            this.rankListbox.Size = new System.Drawing.Size(375, 344);
            this.rankListbox.TabIndex = 0;
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
            this.profileButton.Location = new System.Drawing.Point(16, 57);
            this.profileButton.Margin = new System.Windows.Forms.Padding(4);
            this.profileButton.Name = "profileButton";
            this.profileButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(168)))), ((int)(((byte)(117)))));
            this.profileButton.Size = new System.Drawing.Size(112, 50);
            this.profileButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.profileButton.TabIndex = 16;
            this.profileButton.Text = "Profile";
            this.profileButton.TextColor = System.Drawing.Color.White;
            this.profileButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.profileButton.Click += new System.EventHandler(this.profileButton_Click);
            // 
            // ReturnButton
            // 
            this.ReturnButton.BorderColor = System.Drawing.Color.Black;
            this.ReturnButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.ReturnButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReturnButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.ReturnButton.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ReturnButton.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReturnButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.ReturnButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.ReturnButton.Location = new System.Drawing.Point(149, 494);
            this.ReturnButton.Margin = new System.Windows.Forms.Padding(4);
            this.ReturnButton.Name = "ReturnButton";
            this.ReturnButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(168)))), ((int)(((byte)(117)))));
            this.ReturnButton.Size = new System.Drawing.Size(173, 41);
            this.ReturnButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.ReturnButton.TabIndex = 17;
            this.ReturnButton.Text = "Return";
            this.ReturnButton.TextColor = System.Drawing.Color.White;
            this.ReturnButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.ReturnButton.Click += new System.EventHandler(this.Returnbutton_Click_1);
            // 
            // board
            // 
            this.board.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(211)))));
            this.board.ControlBoxColorH = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.board.ControlBoxColorHC = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.board.ControlBoxColorN = System.Drawing.Color.White;
            this.board.Cursor = System.Windows.Forms.Cursors.Default;
            this.board.Dock = System.Windows.Forms.DockStyle.Top;
            this.board.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.board.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.board.Image = null;
            this.board.Location = new System.Drawing.Point(0, 0);
            this.board.Margin = new System.Windows.Forms.Padding(4);
            this.board.Name = "board";
            this.board.Size = new System.Drawing.Size(464, 40);
            this.board.TabIndex = 28;
            this.board.Text = "Score Board";
            this.board.ThemeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            // 
            // Form_End_Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(211)))));
            this.ClientSize = new System.Drawing.Size(464, 558);
            this.Controls.Add(this.board);
            this.Controls.Add(this.ReturnButton);
            this.Controls.Add(this.profileButton);
            this.Controls.Add(this.rankListbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(2560, 1270);
            this.MinimumSize = new System.Drawing.Size(190, 40);
            this.Name = "Form_End_Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Leader board";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox rankListbox;
        private ReaLTaiizor.Controls.HopeButton profileButton;
        private ReaLTaiizor.Controls.HopeButton ReturnButton;
        private ReaLTaiizor.Forms.HopeForm board;
    }
}