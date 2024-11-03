namespace WindowsFormsApp1
{
    partial class Form_Background
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
            this.logButton = new System.Windows.Forms.Button();
            this.regButton = new System.Windows.Forms.Button();
            this.lawButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // logButton
            // 
            this.logButton.Location = new System.Drawing.Point(125, 311);
            this.logButton.Margin = new System.Windows.Forms.Padding(4);
            this.logButton.Name = "logButton";
            this.logButton.Size = new System.Drawing.Size(221, 60);
            this.logButton.TabIndex = 0;
            this.logButton.Text = "Đăng Nhập";
            this.logButton.UseVisualStyleBackColor = true;
            this.logButton.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // regButton
            // 
            this.regButton.Location = new System.Drawing.Point(125, 389);
            this.regButton.Margin = new System.Windows.Forms.Padding(4);
            this.regButton.Name = "regButton";
            this.regButton.Size = new System.Drawing.Size(221, 60);
            this.regButton.TabIndex = 1;
            this.regButton.Text = "Đăng Ký";
            this.regButton.UseVisualStyleBackColor = true;
            this.regButton.Click += new System.EventHandler(this.regButton_Click);
            // 
            // lawButton
            // 
            this.lawButton.Location = new System.Drawing.Point(125, 470);
            this.lawButton.Name = "lawButton";
            this.lawButton.Size = new System.Drawing.Size(221, 58);
            this.lawButton.TabIndex = 2;
            this.lawButton.Text = "Luật Chơi";
            this.lawButton.UseVisualStyleBackColor = true;
            this.lawButton.Click += new System.EventHandler(this.lawButton_Click);
            // 
            // Form_Background
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 558);
            this.Controls.Add(this.lawButton);
            this.Controls.Add(this.regButton);
            this.Controls.Add(this.logButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form_Background";
            this.Text = "Background";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button logButton;
        private System.Windows.Forms.Button regButton;
        private System.Windows.Forms.Button lawButton;
    }
}

