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
            this.timeLabel = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.wordTextbox = new System.Windows.Forms.TextBox();
            this.sendButton = new ReaLTaiizor.Controls.HopeButton();
            this.sendTextBox = new ReaLTaiizor.Controls.HopeTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.startButton = new ReaLTaiizor.Controls.HopeButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chooseColorBtn = new ReaLTaiizor.Controls.HopeRoundButton();
            this.sizeTrackBar = new ReaLTaiizor.Controls.DungeonTrackBar();
            this.EraserPictureBox = new System.Windows.Forms.PictureBox();
            this.PencilPictureBox = new System.Windows.Forms.PictureBox();
            this.usernamText = new System.Windows.Forms.Label();
            this.hostText = new System.Windows.Forms.Label();
            this.userListView = new System.Windows.Forms.ListView();
            this.maxText = new System.Windows.Forms.Label();
            this.roomForm = new ReaLTaiizor.Forms.HopeForm();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.leaveBtn = new ReaLTaiizor.Controls.HopeButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EraserPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PencilPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("Pixel Sans Serif Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.timeLabel.Location = new System.Drawing.Point(261, 50);
            this.timeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.timeLabel.Size = new System.Drawing.Size(50, 21);
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
            this.wordTextbox.Font = new System.Drawing.Font("FVF Fernando 08", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.wordTextbox.Location = new System.Drawing.Point(317, 97);
            this.wordTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.wordTextbox.Name = "wordTextbox";
            this.wordTextbox.Size = new System.Drawing.Size(215, 35);
            this.wordTextbox.TabIndex = 5;
            // sendButton
            // 
            this.sendButton.BorderColor = System.Drawing.Color.Black;
            this.sendButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.sendButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sendButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.sendButton.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sendButton.Font = new System.Drawing.Font("Pixel Sans Serif Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.sendButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.sendButton.Location = new System.Drawing.Point(578, 448);
            this.sendButton.Name = "sendButton";
            this.sendButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(168)))), ((int)(((byte)(117)))));
            this.sendButton.Size = new System.Drawing.Size(220, 44);
            this.sendButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.sendButton.TabIndex = 26;
            this.sendButton.Text = "send";
            this.sendButton.TextColor = System.Drawing.Color.White;
            this.sendButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // sendTextBox
            // 
            this.sendTextBox.BackColor = System.Drawing.Color.White;
            this.sendTextBox.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.sendTextBox.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.sendTextBox.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.sendTextBox.Font = new System.Drawing.Font("FVF Fernando 08", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.sendTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.sendTextBox.Hint = "";
            this.sendTextBox.Location = new System.Drawing.Point(172, 448);
            this.sendTextBox.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.sendTextBox.MaxLength = 32767;
            this.sendTextBox.Multiline = false;
            this.sendTextBox.Name = "sendTextBox";
            this.sendTextBox.PasswordChar = '\0';
            this.sendTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.sendTextBox.SelectedText = "";
            this.sendTextBox.SelectionLength = 0;
            this.sendTextBox.SelectionStart = 0;
            this.sendTextBox.Size = new System.Drawing.Size(400, 44);
            this.sendTextBox.TabIndex = 27;
            this.sendTextBox.TabStop = false;
            this.sendTextBox.UseSystemPasswordChar = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Pixel Sans Serif Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.label2.Location = new System.Drawing.Point(584, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(92, 21);
            this.label2.TabIndex = 30;
            this.label2.Text = "chatBox:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Pixel Sans Serif Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.label3.Location = new System.Drawing.Point(202, 104);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(97, 21);
            this.label3.TabIndex = 31;
            this.label3.Text = "key word:";
            // 
            // startButton
            // 
            this.startButton.BorderColor = System.Drawing.Color.Black;
            this.startButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.startButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.startButton.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.startButton.Font = new System.Drawing.Font("Pixel Sans Serif Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.startButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.startButton.Location = new System.Drawing.Point(12, 448);
            this.startButton.Name = "startButton";
            this.startButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(168)))), ((int)(((byte)(117)))));
            this.startButton.Size = new System.Drawing.Size(155, 36);
            this.startButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.startButton.TabIndex = 32;
            this.startButton.Text = "start";
            this.startButton.TextColor = System.Drawing.Color.White;
            this.startButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Snow;
            this.panel1.Controls.Add(this.chooseColorBtn);
            this.panel1.Controls.Add(this.sizeTrackBar);
            this.panel1.Controls.Add(this.EraserPictureBox);
            this.panel1.Controls.Add(this.PencilPictureBox);
            this.panel1.Location = new System.Drawing.Point(172, 385);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 50);
            this.panel1.TabIndex = 34;
            // 
            // chooseColorBtn
            // 
            this.chooseColorBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.chooseColorBtn.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.chooseColorBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chooseColorBtn.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.chooseColorBtn.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.chooseColorBtn.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.chooseColorBtn.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.chooseColorBtn.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.chooseColorBtn.Location = new System.Drawing.Point(351, 5);
            this.chooseColorBtn.Name = "chooseColorBtn";
            this.chooseColorBtn.PrimaryColor = System.Drawing.Color.Black;
            this.chooseColorBtn.Size = new System.Drawing.Size(41, 41);
            this.chooseColorBtn.SuccessColor = System.Drawing.Color.White;
            this.chooseColorBtn.TabIndex = 40;
            this.chooseColorBtn.TextColor = System.Drawing.Color.White;
            this.chooseColorBtn.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.chooseColorBtn.Click += new System.EventHandler(this.chooseColorBtn_Click);
            // 
            // sizeTrackBar
            // 
            this.sizeTrackBar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.sizeTrackBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sizeTrackBar.DrawValueString = false;
            this.sizeTrackBar.EmptyBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.sizeTrackBar.FillBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(168)))), ((int)(((byte)(117)))));
            this.sizeTrackBar.JumpToMouse = false;
            this.sizeTrackBar.Location = new System.Drawing.Point(123, 15);
            this.sizeTrackBar.Maximum = 10;
            this.sizeTrackBar.Minimum = 0;
            this.sizeTrackBar.MinimumSize = new System.Drawing.Size(47, 22);
            this.sizeTrackBar.Name = "sizeTrackBar";
            this.sizeTrackBar.Size = new System.Drawing.Size(220, 22);
            this.sizeTrackBar.TabIndex = 39;
            this.sizeTrackBar.Text = "dungeonTrackBar1";
            this.sizeTrackBar.ThumbBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.sizeTrackBar.ThumbBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(168)))), ((int)(((byte)(117)))));
            this.sizeTrackBar.Value = 0;
            this.sizeTrackBar.ValueDivison = ReaLTaiizor.Controls.DungeonTrackBar.ValueDivisor.By1;
            this.sizeTrackBar.ValueToSet = 0F;
            this.sizeTrackBar.ValueChanged += new ReaLTaiizor.Controls.DungeonTrackBar.ValueChangedEventHandler(this.sizeTrackBar_ValueChanged);
            // 
            // EraserPictureBox
            // 
            this.EraserPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EraserPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("EraserPictureBox.Image")));
            this.EraserPictureBox.Location = new System.Drawing.Point(73, 4);
            this.EraserPictureBox.Margin = new System.Windows.Forms.Padding(2);
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
            this.PencilPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PencilPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("PencilPictureBox.Image")));
            this.PencilPictureBox.Location = new System.Drawing.Point(12, 4);
            this.PencilPictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.PencilPictureBox.Name = "PencilPictureBox";
            this.PencilPictureBox.Size = new System.Drawing.Size(38, 41);
            this.PencilPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PencilPictureBox.TabIndex = 35;
            this.PencilPictureBox.TabStop = false;
            this.PencilPictureBox.Tag = "";
            this.PencilPictureBox.Click += new System.EventHandler(this.PencilPictureBox_Click);
            // 
            // usernamText
            // 
            this.usernamText.AutoSize = true;
            this.usernamText.Font = new System.Drawing.Font("Pixel Sans Serif Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernamText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.usernamText.Location = new System.Drawing.Point(4, 50);
            this.usernamText.Name = "usernamText";
            this.usernamText.Size = new System.Drawing.Size(111, 21);
            this.usernamText.TabIndex = 35;
            this.usernamText.Text = "username:  ";
            // 
            // hostText
            // 
            this.hostText.AutoSize = true;
            this.hostText.Font = new System.Drawing.Font("Pixel Sans Serif Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hostText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.hostText.Location = new System.Drawing.Point(4, 80);
            this.hostText.Name = "hostText";
            this.hostText.Size = new System.Drawing.Size(62, 21);
            this.hostText.TabIndex = 36;
            this.hostText.Text = "host: ";
            // 
            // userListView
            // 
            this.userListView.Font = new System.Drawing.Font("FVF Fernando 08", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.userListView.HideSelection = false;
            this.userListView.Location = new System.Drawing.Point(12, 144);
            this.userListView.Name = "userListView";
            this.userListView.Size = new System.Drawing.Size(155, 295);
            this.userListView.TabIndex = 38;
            this.userListView.UseCompatibleStateImageBehavior = false;
            // 
            // maxText
            // 
            this.maxText.AutoSize = true;
            this.maxText.Font = new System.Drawing.Font("Pixel Sans Serif Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.maxText.Location = new System.Drawing.Point(6, 111);
            this.maxText.Name = "maxText";
            this.maxText.Size = new System.Drawing.Size(53, 21);
            this.maxText.TabIndex = 39;
            this.maxText.Text = "max: ";
            // 
            // roomForm
            // 
            this.roomForm.ControlBoxColorH = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.roomForm.ControlBoxColorHC = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.roomForm.ControlBoxColorN = System.Drawing.Color.White;
            this.roomForm.Cursor = System.Windows.Forms.Cursors.Default;
            this.roomForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.roomForm.Font = new System.Drawing.Font("SVN-Retron 2000", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.roomForm.Image = null;
            this.roomForm.Location = new System.Drawing.Point(0, 0);
            this.roomForm.Name = "roomForm";
            this.roomForm.Size = new System.Drawing.Size(810, 40);
            this.roomForm.TabIndex = 20;
            this.roomForm.Text = "Room - ";
            this.roomForm.ThemeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            // 
            // leaveBtn
            // 
            this.leaveBtn.BackgroundImage = global::Program.Properties.Resources.leave_icon;
            this.leaveBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.leaveBtn.BorderColor = System.Drawing.Color.Black;
            this.leaveBtn.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.leaveBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.leaveBtn.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.leaveBtn.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.leaveBtn.Font = new System.Drawing.Font("Pixel Sans Serif Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leaveBtn.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.leaveBtn.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.leaveBtn.Location = new System.Drawing.Point(695, 46);
            this.leaveBtn.Name = "leaveBtn";
            this.leaveBtn.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(168)))), ((int)(((byte)(117)))));
            this.leaveBtn.Size = new System.Drawing.Size(104, 36);
            this.leaveBtn.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.leaveBtn.TabIndex = 37;
            this.leaveBtn.Text = "leave";
            this.leaveBtn.TextColor = System.Drawing.Color.White;
            this.leaveBtn.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.leaveBtn.Click += new System.EventHandler(this.leaveBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(172, 144);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 244);
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.Location = new System.Drawing.Point(577, 104);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(222, 339);
            this.flowLayoutPanel.TabIndex = 40;
            // 
            // Form_Room
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(211)))));
            this.ClientSize = new System.Drawing.Size(810, 496);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.maxText);
            this.Controls.Add(this.userListView);
            this.Controls.Add(this.leaveBtn);
            this.Controls.Add(this.hostText);
            this.Controls.Add(this.usernamText);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.sendTextBox);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.roomForm);
            this.Controls.Add(this.wordTextbox);
            this.Controls.Add(this.timeLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(1920, 1032);
            this.MinimumSize = new System.Drawing.Size(190, 40);
            this.Name = "Form_Room";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Room";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EraserPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PencilPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.TextBox wordTextbox;
        private ReaLTaiizor.Forms.HopeForm roomForm;
        private ReaLTaiizor.Controls.HopeButton sendButton;
        private ReaLTaiizor.Controls.HopeTextBox sendTextBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private ReaLTaiizor.Controls.HopeButton startButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox PencilPictureBox;
        private System.Windows.Forms.PictureBox EraserPictureBox;
        private System.Windows.Forms.Label usernamText;
        private System.Windows.Forms.Label hostText;
        private ReaLTaiizor.Controls.HopeButton leaveBtn;
        private System.Windows.Forms.ListView userListView;
        private System.Windows.Forms.Label maxText;
        private ReaLTaiizor.Controls.DungeonTrackBar sizeTrackBar;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private ReaLTaiizor.Controls.HopeRoundButton chooseColorBtn;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
    }
}