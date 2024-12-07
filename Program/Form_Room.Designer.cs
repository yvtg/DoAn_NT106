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
            this.playerDatagridview = new System.Windows.Forms.DataGridView();
            this.timeLabel = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.wordTextbox = new System.Windows.Forms.TextBox();
            this.chatRichtextbox = new System.Windows.Forms.RichTextBox();
            this.Room = new ReaLTaiizor.Forms.HopeForm();
            this.sendButton = new ReaLTaiizor.Controls.HopeButton();
            this.hopeTextBox1 = new ReaLTaiizor.Controls.HopeTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.startButton = new ReaLTaiizor.Controls.HopeButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.EraserPictureBox = new System.Windows.Forms.PictureBox();
            this.PencilPictureBox = new System.Windows.Forms.PictureBox();
            this.roomIdText = new System.Windows.Forms.Label();
            this.usernameText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.playerDatagridview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EraserPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PencilPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // playerDatagridview
            // 
            this.playerDatagridview.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.playerDatagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.playerDatagridview.Location = new System.Drawing.Point(9, 163);
            this.playerDatagridview.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.playerDatagridview.Name = "playerDatagridview";
            this.playerDatagridview.RowHeadersWidth = 51;
            this.playerDatagridview.RowTemplate.Height = 24;
            this.playerDatagridview.Size = new System.Drawing.Size(106, 240);
            this.playerDatagridview.TabIndex = 3;
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.Location = new System.Drawing.Point(198, 46);
            this.timeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.timeLabel.Size = new System.Drawing.Size(39, 20);
            this.timeLabel.TabIndex = 4;
            this.timeLabel.Text = "time";
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 1000;
            // 
            // wordTextbox
            // 
            this.wordTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wordTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wordTextbox.Location = new System.Drawing.Point(270, 63);
            this.wordTextbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.wordTextbox.Name = "wordTextbox";
            this.wordTextbox.Size = new System.Drawing.Size(182, 26);
            this.wordTextbox.TabIndex = 5;
            // 
            // chatRichtextbox
            // 
            this.chatRichtextbox.BackColor = System.Drawing.SystemColors.Window;
            this.chatRichtextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chatRichtextbox.Location = new System.Drawing.Point(570, 116);
            this.chatRichtextbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chatRichtextbox.Name = "chatRichtextbox";
            this.chatRichtextbox.Size = new System.Drawing.Size(178, 273);
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
            this.Room.Size = new System.Drawing.Size(765, 40);
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
            this.sendButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(131)))), ((int)(((byte)(146)))));
            this.sendButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.sendButton.Location = new System.Drawing.Point(578, 408);
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
            this.hopeTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.hopeTextBox1.Size = new System.Drawing.Size(400, 33);
            this.hopeTextBox1.TabIndex = 27;
            this.hopeTextBox1.TabStop = false;
            this.hopeTextBox1.UseSystemPasswordChar = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(139, 116);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 244);
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(566, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 30;
            this.label2.Text = "ChatBox:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(182, 66);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 31;
            this.label3.Text = "Key World:";
            // 
            // startButton
            // 
            this.startButton.BorderColor = System.Drawing.Color.Black;
            this.startButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.startButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.startButton.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(131)))), ((int)(((byte)(146)))));
            this.startButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.startButton.Location = new System.Drawing.Point(11, 408);
            this.startButton.Name = "startButton";
            this.startButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(226)))), ((int)(((byte)(167)))));
            this.startButton.Size = new System.Drawing.Size(104, 36);
            this.startButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.startButton.TabIndex = 32;
            this.startButton.Text = "Bắt Đầu";
            this.startButton.TextColor = System.Drawing.Color.White;
            this.startButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(9, 133);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(106, 26);
            this.textBox1.TabIndex = 33;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.EraserPictureBox);
            this.panel1.Controls.Add(this.PencilPictureBox);
            this.panel1.Location = new System.Drawing.Point(139, 357);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 50);
            this.panel1.TabIndex = 34;
            // 
            // EraserPictureBox
            // 
            this.EraserPictureBox.Image = global::Program.Properties.Resources.Screenshot_2024_12_03_023500;
            this.EraserPictureBox.Location = new System.Drawing.Point(63, 7);
            this.EraserPictureBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.EraserPictureBox.Name = "EraserPictureBox";
            this.EraserPictureBox.Size = new System.Drawing.Size(38, 41);
            this.EraserPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.EraserPictureBox.TabIndex = 36;
            this.EraserPictureBox.TabStop = false;
            this.EraserPictureBox.Tag = "";
            this.EraserPictureBox.Click += new System.EventHandler(this.EraserPictureBox_Click);
            // 
            // PencilPictureBox
            // 
            this.PencilPictureBox.Image = global::Program.Properties.Resources.Screenshot_2024_12_03_023531;
            this.PencilPictureBox.Location = new System.Drawing.Point(11, 7);
            this.PencilPictureBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PencilPictureBox.Name = "PencilPictureBox";
            this.PencilPictureBox.Size = new System.Drawing.Size(38, 41);
            this.PencilPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PencilPictureBox.TabIndex = 35;
            this.PencilPictureBox.TabStop = false;
            this.PencilPictureBox.Tag = "";
            this.PencilPictureBox.Click += new System.EventHandler(this.PencilPictureBox_Click);
            // 
            // roomIdText
            // 
            this.roomIdText.AutoSize = true;
            this.roomIdText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomIdText.Location = new System.Drawing.Point(6, 52);
            this.roomIdText.Name = "roomIdText";
            this.roomIdText.Size = new System.Drawing.Size(65, 15);
            this.roomIdText.TabIndex = 35;
            this.roomIdText.Text = "Room id:";
            // 
            // usernameText
            // 
            this.usernameText.AutoSize = true;
            this.usernameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameText.Location = new System.Drawing.Point(6, 87);
            this.usernameText.Name = "usernameText";
            this.usernameText.Size = new System.Drawing.Size(77, 15);
            this.usernameText.TabIndex = 36;
            this.usernameText.Text = "Username:";
            // 
            // Form_Room
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(765, 467);
            this.Controls.Add(this.usernameText);
            this.Controls.Add(this.roomIdText);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.hopeTextBox1);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.Room);
            this.Controls.Add(this.chatRichtextbox);
            this.Controls.Add(this.wordTextbox);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.playerDatagridview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximumSize = new System.Drawing.Size(1920, 1032);
            this.MinimumSize = new System.Drawing.Size(190, 40);
            this.Name = "Form_Room";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Room";
            ((System.ComponentModel.ISupportInitialize)(this.playerDatagridview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EraserPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PencilPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView playerDatagridview;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.TextBox wordTextbox;
        private System.Windows.Forms.RichTextBox chatRichtextbox;
        private ReaLTaiizor.Forms.HopeForm Room;
        private ReaLTaiizor.Controls.HopeButton sendButton;
        private ReaLTaiizor.Controls.HopeTextBox hopeTextBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private ReaLTaiizor.Controls.HopeButton startButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox PencilPictureBox;
        private System.Windows.Forms.PictureBox EraserPictureBox;
        private System.Windows.Forms.Label roomIdText;
        private System.Windows.Forms.Label usernameText;
    }
}