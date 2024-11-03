namespace Program
{
    partial class Form_End_Game
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
            this.rankListbox = new System.Windows.Forms.ListBox();
            this.homeButton = new System.Windows.Forms.Button();
            this.profileButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rankListbox
            // 
            this.rankListbox.FormattingEnabled = true;
            this.rankListbox.ItemHeight = 16;
            this.rankListbox.Location = new System.Drawing.Point(50, 88);
            this.rankListbox.Name = "rankListbox";
            this.rankListbox.Size = new System.Drawing.Size(375, 388);
            this.rankListbox.TabIndex = 0;
            // 
            // homeButton
            // 
            this.homeButton.Location = new System.Drawing.Point(157, 493);
            this.homeButton.Name = "homeButton";
            this.homeButton.Size = new System.Drawing.Size(174, 40);
            this.homeButton.TabIndex = 1;
            this.homeButton.Text = "Home";
            this.homeButton.UseVisualStyleBackColor = true;
            this.homeButton.Click += new System.EventHandler(this.homeButton_Click);
            // 
            // profileButton
            // 
            this.profileButton.Location = new System.Drawing.Point(12, 12);
            this.profileButton.Name = "profileButton";
            this.profileButton.Size = new System.Drawing.Size(61, 50);
            this.profileButton.TabIndex = 4;
            this.profileButton.Text = "Profile";
            this.profileButton.UseVisualStyleBackColor = true;
            // 
            // Form_End_Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 558);
            this.Controls.Add(this.profileButton);
            this.Controls.Add(this.homeButton);
            this.Controls.Add(this.rankListbox);
            this.Name = "Form_End_Game";
            this.Text = "End_Game";
            this.Load += new System.EventHandler(this.Form_End_Game_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox rankListbox;
        private System.Windows.Forms.Button homeButton;
        private System.Windows.Forms.Button profileButton;
    }
}