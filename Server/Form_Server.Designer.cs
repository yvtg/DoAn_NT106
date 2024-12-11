namespace Server
{
    partial class Form_Server
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Server));
            this.logRichTextBox = new System.Windows.Forms.RichTextBox();
            this.startBtn = new ReaLTaiizor.Controls.HopeRoundButton();
            this.stopBtn = new ReaLTaiizor.Controls.HopeRoundButton();
            this.hopeForm2 = new ReaLTaiizor.Forms.HopeForm();
            this.label1 = new System.Windows.Forms.Label();
            this.clientListView = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.roomListView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // logRichTextBox
            // 
            this.logRichTextBox.Location = new System.Drawing.Point(28, 64);
            this.logRichTextBox.Name = "logRichTextBox";
            this.logRichTextBox.ReadOnly = true;
            this.logRichTextBox.Size = new System.Drawing.Size(515, 205);
            this.logRichTextBox.TabIndex = 0;
            this.logRichTextBox.Text = "";
            // 
            // startBtn
            // 
            this.startBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.startBtn.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.startBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startBtn.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.startBtn.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.startBtn.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.startBtn.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(131)))), ((int)(((byte)(146)))));
            this.startBtn.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.startBtn.Location = new System.Drawing.Point(564, 81);
            this.startBtn.Name = "startBtn";
            this.startBtn.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(226)))), ((int)(((byte)(167)))));
            this.startBtn.Size = new System.Drawing.Size(122, 37);
            this.startBtn.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.startBtn.TabIndex = 2;
            this.startBtn.Text = "Start";
            this.startBtn.TextColor = System.Drawing.Color.White;
            this.startBtn.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // stopBtn
            // 
            this.stopBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.stopBtn.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.stopBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stopBtn.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.stopBtn.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.stopBtn.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.stopBtn.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(226)))), ((int)(((byte)(167)))));
            this.stopBtn.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.stopBtn.Location = new System.Drawing.Point(564, 137);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(131)))), ((int)(((byte)(146)))));
            this.stopBtn.Size = new System.Drawing.Size(122, 37);
            this.stopBtn.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(131)))), ((int)(((byte)(146)))));
            this.stopBtn.TabIndex = 3;
            this.stopBtn.Text = "Stop";
            this.stopBtn.TextColor = System.Drawing.Color.White;
            this.stopBtn.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // hopeForm2
            // 
            this.hopeForm2.ControlBoxColorH = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.hopeForm2.ControlBoxColorHC = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.hopeForm2.ControlBoxColorN = System.Drawing.Color.White;
            this.hopeForm2.Cursor = System.Windows.Forms.Cursors.Default;
            this.hopeForm2.Dock = System.Windows.Forms.DockStyle.Top;
            this.hopeForm2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.hopeForm2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.hopeForm2.Image = ((System.Drawing.Image)(resources.GetObject("hopeForm2.Image")));
            this.hopeForm2.Location = new System.Drawing.Point(0, 0);
            this.hopeForm2.Name = "hopeForm2";
            this.hopeForm2.Size = new System.Drawing.Size(698, 40);
            this.hopeForm2.TabIndex = 14;
            this.hopeForm2.Text = "Server";
            this.hopeForm2.ThemeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(131)))), ((int)(((byte)(146)))));
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 286);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Danh sách client";
            // 
            // clientListView
            // 
            this.clientListView.HideSelection = false;
            this.clientListView.Location = new System.Drawing.Point(30, 308);
            this.clientListView.Name = "clientListView";
            this.clientListView.Size = new System.Drawing.Size(190, 147);
            this.clientListView.TabIndex = 16;
            this.clientListView.UseCompatibleStateImageBehavior = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(256, 286);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Danh sách phòng";
            // 
            // roomListView
            // 
            this.roomListView.HideSelection = false;
            this.roomListView.Location = new System.Drawing.Point(259, 308);
            this.roomListView.Name = "roomListView";
            this.roomListView.Size = new System.Drawing.Size(425, 147);
            this.roomListView.TabIndex = 18;
            this.roomListView.UseCompatibleStateImageBehavior = false;
            // 
            // Form_Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 467);
            this.Controls.Add(this.roomListView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.clientListView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hopeForm2);
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.logRichTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(1920, 1032);
            this.MinimumSize = new System.Drawing.Size(190, 40);
            this.Name = "Form_Server";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Server_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox logRichTextBox;
        private ReaLTaiizor.Controls.HopeRoundButton startBtn;
        private ReaLTaiizor.Controls.HopeRoundButton stopBtn;
        private ReaLTaiizor.Forms.HopeForm hopeForm2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView clientListView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView roomListView;
    }
}

