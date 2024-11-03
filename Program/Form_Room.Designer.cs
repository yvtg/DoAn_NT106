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
            this.answerTextbox = new System.Windows.Forms.RichTextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.descriptionRichtextbox = new System.Windows.Forms.RichTextBox();
            this.playerDatagridview = new System.Windows.Forms.DataGridView();
            this.timeLabel = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.wordTextbox = new System.Windows.Forms.TextBox();
            this.chatRichtextbox = new System.Windows.Forms.RichTextBox();
            this.chatTextbox = new System.Windows.Forms.TextBox();
            this.chatButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.playerDatagridview)).BeginInit();
            this.SuspendLayout();
            // 
            // answerTextbox
            // 
            this.answerTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.answerTextbox.Location = new System.Drawing.Point(166, 352);
            this.answerTextbox.Name = "answerTextbox";
            this.answerTextbox.Size = new System.Drawing.Size(428, 34);
            this.answerTextbox.TabIndex = 0;
            this.answerTextbox.Text = "";
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(589, 352);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(93, 34);
            this.sendButton.TabIndex = 1;
            this.sendButton.Text = "Gửi";
            this.sendButton.UseVisualStyleBackColor = true;
            // 
            // descriptionRichtextbox
            // 
            this.descriptionRichtextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.descriptionRichtextbox.Location = new System.Drawing.Point(166, 50);
            this.descriptionRichtextbox.Name = "descriptionRichtextbox";
            this.descriptionRichtextbox.Size = new System.Drawing.Size(516, 280);
            this.descriptionRichtextbox.TabIndex = 2;
            this.descriptionRichtextbox.Text = "";
            // 
            // playerDatagridview
            // 
            this.playerDatagridview.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.playerDatagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.playerDatagridview.Location = new System.Drawing.Point(3, 0);
            this.playerDatagridview.Name = "playerDatagridview";
            this.playerDatagridview.RowHeadersWidth = 51;
            this.playerDatagridview.RowTemplate.Height = 24;
            this.playerDatagridview.Size = new System.Drawing.Size(142, 418);
            this.playerDatagridview.TabIndex = 3;
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.Location = new System.Drawing.Point(634, 13);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.timeLabel.Size = new System.Drawing.Size(48, 25);
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
            this.wordTextbox.Location = new System.Drawing.Point(323, 13);
            this.wordTextbox.Name = "wordTextbox";
            this.wordTextbox.Size = new System.Drawing.Size(201, 22);
            this.wordTextbox.TabIndex = 5;
            // 
            // chatRichtextbox
            // 
            this.chatRichtextbox.BackColor = System.Drawing.SystemColors.Window;
            this.chatRichtextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chatRichtextbox.Location = new System.Drawing.Point(703, 52);
            this.chatRichtextbox.Name = "chatRichtextbox";
            this.chatRichtextbox.Size = new System.Drawing.Size(148, 278);
            this.chatRichtextbox.TabIndex = 6;
            this.chatRichtextbox.Text = "";
            // 
            // chatTextbox
            // 
            this.chatTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chatTextbox.Location = new System.Drawing.Point(703, 358);
            this.chatTextbox.Name = "chatTextbox";
            this.chatTextbox.Size = new System.Drawing.Size(100, 22);
            this.chatTextbox.TabIndex = 7;
            // 
            // chatButton
            // 
            this.chatButton.Location = new System.Drawing.Point(809, 356);
            this.chatButton.Name = "chatButton";
            this.chatButton.Size = new System.Drawing.Size(43, 27);
            this.chatButton.TabIndex = 8;
            this.chatButton.Text = "Chat";
            this.chatButton.UseVisualStyleBackColor = true;
            // 
            // Form_Room
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 419);
            this.Controls.Add(this.chatButton);
            this.Controls.Add(this.chatTextbox);
            this.Controls.Add(this.chatRichtextbox);
            this.Controls.Add(this.wordTextbox);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.playerDatagridview);
            this.Controls.Add(this.descriptionRichtextbox);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.answerTextbox);
            this.Name = "Form_Room";
            this.Text = "Room";
            this.Load += new System.EventHandler(this.Form_Room_Load);
            ((System.ComponentModel.ISupportInitialize)(this.playerDatagridview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox answerTextbox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.RichTextBox descriptionRichtextbox;
        private System.Windows.Forms.DataGridView playerDatagridview;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.TextBox wordTextbox;
        private System.Windows.Forms.RichTextBox chatRichtextbox;
        private System.Windows.Forms.TextBox chatTextbox;
        private System.Windows.Forms.Button chatButton;
    }
}