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
            this.idLabel = new System.Windows.Forms.Label();
            this.idTextbox = new System.Windows.Forms.RichTextBox();
            this.backButton = new System.Windows.Forms.Button();
            this.joinButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(12, 88);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(103, 16);
            this.idLabel.TabIndex = 0;
            this.idLabel.Text = "Nhập mã phòng";
            // 
            // idTextbox
            // 
            this.idTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.idTextbox.Location = new System.Drawing.Point(130, 72);
            this.idTextbox.Name = "idTextbox";
            this.idTextbox.Size = new System.Drawing.Size(276, 48);
            this.idTextbox.TabIndex = 1;
            this.idTextbox.Text = "";
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(42, 168);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(153, 54);
            this.backButton.TabIndex = 2;
            this.backButton.Text = "Quay về";
            this.backButton.UseVisualStyleBackColor = true;
            // 
            // joinButton
            // 
            this.joinButton.Location = new System.Drawing.Point(236, 168);
            this.joinButton.Name = "joinButton";
            this.joinButton.Size = new System.Drawing.Size(153, 54);
            this.joinButton.TabIndex = 3;
            this.joinButton.Text = "Tham gia";
            this.joinButton.UseVisualStyleBackColor = true;
            // 
            // Form_Join
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 266);
            this.Controls.Add(this.joinButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.idTextbox);
            this.Controls.Add(this.idLabel);
            this.Name = "Form_Join";
            this.Text = "Join";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.RichTextBox idTextbox;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button joinButton;
    }
}