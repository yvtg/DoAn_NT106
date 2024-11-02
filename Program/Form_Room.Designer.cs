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
            this.answerTextbox = new System.Windows.Forms.RichTextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.descriptionTextbox = new System.Windows.Forms.RichTextBox();
            this.playerDatagridview = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.playerDatagridview)).BeginInit();
            this.SuspendLayout();
            // 
            // answerTextbox
            // 
            this.answerTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.answerTextbox.Location = new System.Drawing.Point(22, 345);
            this.answerTextbox.Name = "answerTextbox";
            this.answerTextbox.Size = new System.Drawing.Size(503, 34);
            this.answerTextbox.TabIndex = 0;
            this.answerTextbox.Text = "";
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(552, 345);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(103, 34);
            this.sendButton.TabIndex = 1;
            this.sendButton.Text = "Gửi";
            this.sendButton.UseVisualStyleBackColor = true;
            // 
            // descriptionTextbox
            // 
            this.descriptionTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.descriptionTextbox.Location = new System.Drawing.Point(22, 28);
            this.descriptionTextbox.Name = "descriptionTextbox";
            this.descriptionTextbox.Size = new System.Drawing.Size(503, 283);
            this.descriptionTextbox.TabIndex = 2;
            this.descriptionTextbox.Text = "";
            // 
            // playerDatagridview
            // 
            this.playerDatagridview.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.playerDatagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.playerDatagridview.Location = new System.Drawing.Point(540, 27);
            this.playerDatagridview.Name = "playerDatagridview";
            this.playerDatagridview.RowHeadersWidth = 51;
            this.playerDatagridview.RowTemplate.Height = 24;
            this.playerDatagridview.Size = new System.Drawing.Size(132, 180);
            this.playerDatagridview.TabIndex = 3;
            // 
            // Form_Room
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 419);
            this.Controls.Add(this.playerDatagridview);
            this.Controls.Add(this.descriptionTextbox);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.answerTextbox);
            this.Name = "Form_Room";
            this.Text = "Room";
            ((System.ComponentModel.ISupportInitialize)(this.playerDatagridview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox answerTextbox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.RichTextBox descriptionTextbox;
        private System.Windows.Forms.DataGridView playerDatagridview;
    }
}