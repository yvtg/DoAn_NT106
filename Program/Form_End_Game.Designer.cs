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
            this.ReturnButton = new ReaLTaiizor.Controls.HopeButton();
            this.board = new ReaLTaiizor.Forms.HopeForm();
            this.SuspendLayout();
            // 
            // rankListbox
            // 
            this.rankListbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(230)))));
            this.rankListbox.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rankListbox.FormattingEnabled = true;
            this.rankListbox.ItemHeight = 16;
            this.rankListbox.Location = new System.Drawing.Point(33, 102);
            this.rankListbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rankListbox.Name = "rankListbox";
            this.rankListbox.Size = new System.Drawing.Size(282, 276);
            this.rankListbox.TabIndex = 0;
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
            this.ReturnButton.Location = new System.Drawing.Point(112, 401);
            this.ReturnButton.Name = "ReturnButton";
            this.ReturnButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(168)))), ((int)(((byte)(117)))));
            this.ReturnButton.Size = new System.Drawing.Size(130, 33);
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
            this.board.Name = "board";
            this.board.Size = new System.Drawing.Size(348, 40);
            this.board.TabIndex = 28;
            this.board.Text = "Score Board";
            this.board.ThemeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            // 
            // Form_End_Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(211)))));
            this.ClientSize = new System.Drawing.Size(348, 453);
            this.Controls.Add(this.board);
            this.Controls.Add(this.ReturnButton);
            this.Controls.Add(this.rankListbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximumSize = new System.Drawing.Size(1920, 1032);
            this.MinimumSize = new System.Drawing.Size(190, 40);
            this.Name = "Form_End_Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Leader board";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox rankListbox;
        private ReaLTaiizor.Controls.HopeButton ReturnButton;
        private ReaLTaiizor.Forms.HopeForm board;
    }
}