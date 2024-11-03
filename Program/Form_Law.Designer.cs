namespace Program
{
    partial class Form_Law
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
            this.lawRichtextbox = new System.Windows.Forms.RichTextBox();
            this.backButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lawRichtextbox
            // 
            this.lawRichtextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lawRichtextbox.Location = new System.Drawing.Point(2, 77);
            this.lawRichtextbox.Name = "lawRichtextbox";
            this.lawRichtextbox.ReadOnly = true;
            this.lawRichtextbox.Size = new System.Drawing.Size(463, 418);
            this.lawRichtextbox.TabIndex = 0;
            this.lawRichtextbox.Text = "";
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(182, 501);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(129, 45);
            this.backButton.TabIndex = 1;
            this.backButton.Text = "Quay về";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // Form_Law
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 558);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.lawRichtextbox);
            this.Name = "Form_Law";
            this.Text = "Form_Law";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox lawRichtextbox;
        private System.Windows.Forms.Button backButton;
    }
}