namespace LoadBalancer
{
    partial class LB_Log
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LB_Log));
            this.serverForm = new ReaLTaiizor.Forms.HopeForm();
            this.logRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // serverForm
            // 
            this.serverForm.ControlBoxColorH = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.serverForm.ControlBoxColorHC = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.serverForm.ControlBoxColorN = System.Drawing.Color.White;
            this.serverForm.Cursor = System.Windows.Forms.Cursors.Default;
            this.serverForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.serverForm.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.serverForm.Image = null;
            this.serverForm.Location = new System.Drawing.Point(0, 0);
            this.serverForm.Name = "serverForm";
            this.serverForm.Size = new System.Drawing.Size(599, 40);
            this.serverForm.TabIndex = 23;
            this.serverForm.Text = "Load Balancer Log";
            this.serverForm.ThemeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            // 
            // logRichTextBox
            // 
            this.logRichTextBox.BackColor = System.Drawing.Color.White;
            this.logRichTextBox.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.logRichTextBox.Location = new System.Drawing.Point(12, 63);
            this.logRichTextBox.Name = "logRichTextBox";
            this.logRichTextBox.ReadOnly = true;
            this.logRichTextBox.Size = new System.Drawing.Size(575, 331);
            this.logRichTextBox.TabIndex = 27;
            this.logRichTextBox.Text = "";
            // 
            // LB_Log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(211)))));
            this.ClientSize = new System.Drawing.Size(599, 406);
            this.Controls.Add(this.logRichTextBox);
            this.Controls.Add(this.serverForm);
            this.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1920, 1032);
            this.MinimumSize = new System.Drawing.Size(190, 40);
            this.Name = "LB_Log";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LB_Log_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private ReaLTaiizor.Forms.HopeForm serverForm;
        private System.Windows.Forms.RichTextBox logRichTextBox;
    }
}

