namespace Program
{
    partial class Form_Room
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Room));
            this.descriptionRichtextbox = new System.Windows.Forms.RichTextBox();
            this.playerDatagridview = new System.Windows.Forms.DataGridView();
            this.timeLabel = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.wordTextbox = new System.Windows.Forms.TextBox();
            this.chatRichtextbox = new System.Windows.Forms.RichTextBox();
            this.Room = new ReaLTaiizor.Forms.HopeForm();
            this.sendButton = new ReaLTaiizor.Controls.HopeButton();
            this.hopeTextBox1 = new ReaLTaiizor.Controls.HopeTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.playerDatagridview)).BeginInit();
            this.SuspendLayout();
            // 
            // descriptionRichtextbox
            // 
            this.descriptionRichtextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.descriptionRichtextbox.Location = new System.Drawing.Point(139, 109);
            this.descriptionRichtextbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.descriptionRichtextbox.Name = "descriptionRichtextbox";
            this.descriptionRichtextbox.Size = new System.Drawing.Size(388, 256);
            this.descriptionRichtextbox.TabIndex = 2;
            this.descriptionRichtextbox.Text = "";
            // 
            // playerDatagridview
            // 
            this.playerDatagridview.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.playerDatagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.playerDatagridview.Location = new System.Drawing.Point(11, 109);
            this.playerDatagridview.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.playerDatagridview.Name = "playerDatagridview";
            this.playerDatagridview.RowHeadersWidth = 51;
            this.playerDatagridview.RowTemplate.Height = 24;
            this.playerDatagridview.Size = new System.Drawing.Size(106, 340);
            this.playerDatagridview.TabIndex = 3;
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.Location = new System.Drawing.Point(571, 70);
            this.timeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.timeLabel.Size = new System.Drawing.Size(39, 20);
            this.timeLabel.TabIndex = 4;
            this.timeLabel.Text = "time";
            this.timeLabel.Click += new System.EventHandler(this.timeLabel_Click);
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 1000;
            // 
            // wordTextbox
            // 
            this.wordTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wordTextbox.Location = new System.Drawing.Point(244, 70);
            this.wordTextbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.wordTextbox.Name = "wordTextbox";
            this.wordTextbox.Size = new System.Drawing.Size(182, 20);
            this.wordTextbox.TabIndex = 5;
            // 
            // chatRichtextbox
            // 
            this.chatRichtextbox.BackColor = System.Drawing.SystemColors.Window;
            this.chatRichtextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chatRichtextbox.Location = new System.Drawing.Point(569, 109);
            this.chatRichtextbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chatRichtextbox.Name = "chatRichtextbox";
            this.chatRichtextbox.Size = new System.Drawing.Size(110, 273);
            this.chatRichtextbox.TabIndex = 6;
            this.chatRichtextbox.Text = "";
            // 
            // Room
            // 
            this.Room.ControlBoxColorH = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.Room.ControlBoxColorHC = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.Room.ControlBoxColorN = System.Drawing.Color.White;
            this.Room.Cursor = System.Windows.Forms.Cursors.Default;
            this.Room.Dock = System.Windows.Forms.DockStyle.Top;
            this.Room.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.Room.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.Room.Image = ((System.Drawing.Image)(resources.GetObject("Room.Image")));
            this.Room.Location = new System.Drawing.Point(0, 0);
            this.Room.Name = "Room";
            this.Room.Size = new System.Drawing.Size(710, 40);
            this.Room.TabIndex = 20;
            this.Room.Text = "Register";
            this.Room.ThemeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(131)))), ((int)(((byte)(146)))));
            // 
            // sendButton
            // 
            this.sendButton.BorderColor = System.Drawing.Color.Black;
            this.sendButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.sendButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sendButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.sendButton.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sendButton.Font = new System.Drawing.Font("Roboto Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(131)))), ((int)(((byte)(146)))));
            this.sendButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.sendButton.Location = new System.Drawing.Point(575, 413);
            this.sendButton.Name = "sendButton";
            this.sendButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(226)))), ((int)(((byte)(167)))));
            this.sendButton.Size = new System.Drawing.Size(104, 36);
            this.sendButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.sendButton.TabIndex = 26;
            this.sendButton.Text = "Gửi";
            this.sendButton.TextColor = System.Drawing.Color.White;
            this.sendButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            // 
            // hopeTextBox1
            // 
            this.hopeTextBox1.BackColor = System.Drawing.Color.White;
            this.hopeTextBox1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(226)))), ((int)(((byte)(167)))));
            this.hopeTextBox1.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(226)))), ((int)(((byte)(167)))));
            this.hopeTextBox1.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(226)))), ((int)(((byte)(167)))));
            this.hopeTextBox1.Font = new System.Drawing.Font("Roboto Mono", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hopeTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.hopeTextBox1.Hint = "";
            this.hopeTextBox1.Location = new System.Drawing.Point(139, 413);
            this.hopeTextBox1.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.hopeTextBox1.MaxLength = 32767;
            this.hopeTextBox1.Multiline = false;
            this.hopeTextBox1.Name = "hopeTextBox1";
            this.hopeTextBox1.PasswordChar = '\0';
            this.hopeTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.hopeTextBox1.SelectedText = "";
            this.hopeTextBox1.SelectionLength = 0;
            this.hopeTextBox1.SelectionStart = 0;
            this.hopeTextBox1.Size = new System.Drawing.Size(400, 36);
            this.hopeTextBox1.TabIndex = 27;
            this.hopeTextBox1.TabStop = false;
            this.hopeTextBox1.UseSystemPasswordChar = false;
            // 
            // Form_Room
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(710, 467);
            this.Controls.Add(this.hopeTextBox1);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.Room);
            this.Controls.Add(this.chatRichtextbox);
            this.Controls.Add(this.wordTextbox);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.playerDatagridview);
            this.Controls.Add(this.descriptionRichtextbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximumSize = new System.Drawing.Size(1920, 1032);
            this.MinimumSize = new System.Drawing.Size(190, 40);
            this.Name = "Form_Room";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Room";
            this.Load += new System.EventHandler(this.Form_Room_Load);
            ((System.ComponentModel.ISupportInitialize)(this.playerDatagridview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox descriptionRichtextbox;
        private System.Windows.Forms.DataGridView playerDatagridview;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.TextBox wordTextbox;
        private System.Windows.Forms.RichTextBox chatRichtextbox;
        private ReaLTaiizor.Forms.HopeForm Room;
        private ReaLTaiizor.Controls.HopeButton sendButton;
        private ReaLTaiizor.Controls.HopeTextBox hopeTextBox1;
    }
}