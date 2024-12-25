namespace Program
{
    partial class Form_Join
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Join));
            this.idLabel = new System.Windows.Forms.Label();
            this.idTextbox = new ReaLTaiizor.Controls.HopeTextBox();
            this.joinButton = new ReaLTaiizor.Controls.HopeButton();
            this.join = new ReaLTaiizor.Forms.HopeForm();
            this.SuspendLayout();
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.idLabel.Location = new System.Drawing.Point(15, 85);
            this.idLabel.Name = "idLabel";
            this.idLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.idLabel.Size = new System.Drawing.Size(98, 23);
            this.idLabel.TabIndex = 0;
            this.idLabel.Text = "Room ID";
            // 
            // idTextbox
            // 
            this.idTextbox.BackColor = System.Drawing.Color.White;
            this.idTextbox.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.idTextbox.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.idTextbox.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.idTextbox.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.idTextbox.Hint = "";
            this.idTextbox.Location = new System.Drawing.Point(143, 80);
            this.idTextbox.Margin = new System.Windows.Forms.Padding(0, 4, 4, 4);
            this.idTextbox.MaxLength = 32767;
            this.idTextbox.Multiline = false;
            this.idTextbox.Name = "idTextbox";
            this.idTextbox.PasswordChar = '\0';
            this.idTextbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.idTextbox.SelectedText = "";
            this.idTextbox.SelectionLength = 0;
            this.idTextbox.SelectionStart = 0;
            this.idTextbox.Size = new System.Drawing.Size(200, 40);
            this.idTextbox.TabIndex = 16;
            this.idTextbox.TabStop = false;
            this.idTextbox.UseSystemPasswordChar = false;
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
            this.joinButton.Location = new System.Drawing.Point(108, 142);
            this.joinButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.joinButton.Name = "joinButton";
            this.joinButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(107)))), ((int)(((byte)(111)))));
            this.joinButton.Size = new System.Drawing.Size(139, 44);
            this.joinButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.joinButton.TabIndex = 18;
            this.joinButton.Text = "Join";
            this.joinButton.TextColor = System.Drawing.Color.White;
            this.joinButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.joinButton.Click += new System.EventHandler(this.joinButton_Click);
            // 
            // join
            // 
            this.join.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(211)))));
            this.join.ControlBoxColorH = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.join.ControlBoxColorHC = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.join.ControlBoxColorN = System.Drawing.Color.White;
            this.join.Cursor = System.Windows.Forms.Cursors.Default;
            this.join.Dock = System.Windows.Forms.DockStyle.Top;
            this.join.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.join.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.join.Image = null;
            this.join.Location = new System.Drawing.Point(0, 0);
            this.join.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.join.Name = "join";
            this.join.Size = new System.Drawing.Size(359, 40);
            this.join.TabIndex = 28;
            this.join.Text = "Join Room";
            this.join.ThemeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            // 
            // Form_Join
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(211)))));
            this.ClientSize = new System.Drawing.Size(359, 208);
            this.Controls.Add(this.join);
            this.Controls.Add(this.joinButton);
            this.Controls.Add(this.idTextbox);
            this.Controls.Add(this.idLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(2560, 1270);
            this.MinimumSize = new System.Drawing.Size(190, 40);
            this.Name = "Form_Join";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Join";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label idLabel;
        private ReaLTaiizor.Controls.HopeTextBox idTextbox;
        private ReaLTaiizor.Controls.HopeButton joinButton;
        private ReaLTaiizor.Forms.HopeForm join;
    }
}