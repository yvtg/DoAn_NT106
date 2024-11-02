namespace Program
{
    partial class Form_Create_Room
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
            this.idroomTextbox = new System.Windows.Forms.RichTextBox();
            this.nameroomTextbox = new System.Windows.Forms.RichTextBox();
            this.idroomLabel = new System.Windows.Forms.Label();
            this.nameroomLabel = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // idroomTextbox
            // 
            this.idroomTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.idroomTextbox.Location = new System.Drawing.Point(133, 98);
            this.idroomTextbox.Name = "idroomTextbox";
            this.idroomTextbox.Size = new System.Drawing.Size(290, 39);
            this.idroomTextbox.TabIndex = 21;
            this.idroomTextbox.Text = "";
            // 
            // nameroomTextbox
            // 
            this.nameroomTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameroomTextbox.Location = new System.Drawing.Point(133, 42);
            this.nameroomTextbox.Name = "nameroomTextbox";
            this.nameroomTextbox.Size = new System.Drawing.Size(290, 39);
            this.nameroomTextbox.TabIndex = 20;
            this.nameroomTextbox.Text = "";
            // 
            // idroomLabel
            // 
            this.idroomLabel.AutoSize = true;
            this.idroomLabel.Location = new System.Drawing.Point(14, 109);
            this.idroomLabel.Name = "idroomLabel";
            this.idroomLabel.Size = new System.Drawing.Size(67, 16);
            this.idroomLabel.TabIndex = 19;
            this.idroomLabel.Text = "Mã phòng";
            // 
            // nameroomLabel
            // 
            this.nameroomLabel.AutoSize = true;
            this.nameroomLabel.Location = new System.Drawing.Point(14, 56);
            this.nameroomLabel.Name = "nameroomLabel";
            this.nameroomLabel.Size = new System.Drawing.Size(72, 16);
            this.nameroomLabel.TabIndex = 18;
            this.nameroomLabel.Text = "Tên phòng";
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(55, 181);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(139, 44);
            this.backButton.TabIndex = 17;
            this.backButton.Text = "Quay về";
            this.backButton.UseVisualStyleBackColor = true;
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(235, 181);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(139, 44);
            this.createButton.TabIndex = 16;
            this.createButton.Text = "Tạo phòng";
            this.createButton.UseVisualStyleBackColor = true;
            // 
            // Form_Create_Room
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 266);
            this.Controls.Add(this.idroomTextbox);
            this.Controls.Add(this.nameroomTextbox);
            this.Controls.Add(this.idroomLabel);
            this.Controls.Add(this.nameroomLabel);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.createButton);
            this.Name = "Form_Create_Room";
            this.Text = "Create_Room";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox idroomTextbox;
        private System.Windows.Forms.RichTextBox nameroomTextbox;
        private System.Windows.Forms.Label idroomLabel;
        private System.Windows.Forms.Label nameroomLabel;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button createButton;
    }
}