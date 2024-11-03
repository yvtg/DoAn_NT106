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
            this.backButton = new System.Windows.Forms.Button();
            this.joinButton = new System.Windows.Forms.Button();
            this.idTextbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(12, 229);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(103, 16);
            this.idLabel.TabIndex = 0;
            this.idLabel.Text = "Nhập mã phòng";
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(60, 293);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(153, 54);
            this.backButton.TabIndex = 2;
            this.backButton.Text = "Quay về";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // joinButton
            // 
            this.joinButton.Location = new System.Drawing.Point(244, 293);
            this.joinButton.Name = "joinButton";
            this.joinButton.Size = new System.Drawing.Size(153, 54);
            this.joinButton.TabIndex = 3;
            this.joinButton.Text = "Tham gia";
            this.joinButton.UseVisualStyleBackColor = true;
            this.joinButton.Click += new System.EventHandler(this.joinButton_Click);
            // 
            // idTextbox
            // 
            this.idTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.idTextbox.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idTextbox.Location = new System.Drawing.Point(130, 221);
            this.idTextbox.Name = "idTextbox";
            this.idTextbox.Size = new System.Drawing.Size(322, 31);
            this.idTextbox.TabIndex = 7;
            // 
            // Form_Join
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 558);
            this.Controls.Add(this.idTextbox);
            this.Controls.Add(this.joinButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.idLabel);
            this.Name = "Form_Join";
            this.Text = "Join";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button joinButton;
        private System.Windows.Forms.TextBox idTextbox;
    }
}