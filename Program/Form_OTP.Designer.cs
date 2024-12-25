namespace Program
{
    partial class Form_OTP
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
            this.timerLabel = new System.Windows.Forms.Label();
            this.confirmButton = new System.Windows.Forms.Button();
            this.otpTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.otpTimer = new System.Windows.Forms.Timer(this.components);
            this.backButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.Location = new System.Drawing.Point(286, 123);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(42, 16);
            this.timerLabel.TabIndex = 9;
            this.timerLabel.Text = "Timer";
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(179, 261);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(105, 49);
            this.confirmButton.TabIndex = 8;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // otpTextbox
            // 
            this.otpTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.otpTextbox.Location = new System.Drawing.Point(92, 173);
            this.otpTextbox.Multiline = true;
            this.otpTextbox.Name = "otpTextbox";
            this.otpTextbox.Size = new System.Drawing.Size(300, 42);
            this.otpTextbox.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nhập mã OTP:";
            // 
            // otpTimer
            // 
            this.otpTimer.Tick += new System.EventHandler(this.otpTimer_Tick);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(179, 337);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(105, 52);
            this.backButton.TabIndex = 11;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // Form_OTP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 511);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.otpTextbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.backButton);
            this.Name = "Form_OTP";
            this.Text = "Form_OTP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_OTP_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.TextBox otpTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer otpTimer;
        private System.Windows.Forms.Button backButton;
    }
}