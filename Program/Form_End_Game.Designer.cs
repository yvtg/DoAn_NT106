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
            this.SuspendLayout();
            // 
            // rankListbox
            // 
            this.rankListbox.FormattingEnabled = true;
            this.rankListbox.ItemHeight = 16;
            this.rankListbox.Location = new System.Drawing.Point(53, 41);
            this.rankListbox.Name = "rankListbox";
            this.rankListbox.Size = new System.Drawing.Size(301, 340);
            this.rankListbox.TabIndex = 0;
            // 
            // Form_End_Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 415);
            this.Controls.Add(this.rankListbox);
            this.Name = "Form_End_Game";
            this.Text = "End_Game";
            this.Load += new System.EventHandler(this.Form_End_Game_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox rankListbox;
    }
}