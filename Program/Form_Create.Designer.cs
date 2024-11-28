namespace Program
{
    partial class Form_Create
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
            this.maxTextbox = new ReaLTaiizor.Controls.HopeTextBox();
            this.createBtn = new ReaLTaiizor.Controls.HopeButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // maxTextbox
            // 
            this.maxTextbox.BackColor = System.Drawing.Color.White;
            this.maxTextbox.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(226)))), ((int)(((byte)(167)))));
            this.maxTextbox.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(226)))), ((int)(((byte)(167)))));
            this.maxTextbox.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(226)))), ((int)(((byte)(167)))));
            this.maxTextbox.Font = new System.Drawing.Font("Roboto Mono", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.maxTextbox.Hint = "";
            this.maxTextbox.Location = new System.Drawing.Point(19, 71);
            this.maxTextbox.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.maxTextbox.MaxLength = 32767;
            this.maxTextbox.Multiline = false;
            this.maxTextbox.Name = "maxTextbox";
            this.maxTextbox.PasswordChar = '\0';
            this.maxTextbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.maxTextbox.SelectedText = "";
            this.maxTextbox.SelectionLength = 0;
            this.maxTextbox.SelectionStart = 0;
            this.maxTextbox.Size = new System.Drawing.Size(171, 36);
            this.maxTextbox.TabIndex = 17;
            this.maxTextbox.TabStop = false;
            this.maxTextbox.UseSystemPasswordChar = false;
            // 
            // createBtn
            // 
            this.createBtn.BorderColor = System.Drawing.Color.Black;
            this.createBtn.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.createBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.createBtn.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.createBtn.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.createBtn.Font = new System.Drawing.Font("Roboto Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createBtn.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(131)))), ((int)(((byte)(146)))));
            this.createBtn.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.createBtn.Location = new System.Drawing.Point(213, 71);
            this.createBtn.Name = "createBtn";
            this.createBtn.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(226)))), ((int)(((byte)(167)))));
            this.createBtn.Size = new System.Drawing.Size(117, 36);
            this.createBtn.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.createBtn.TabIndex = 18;
            this.createBtn.Text = "Tạo phòng";
            this.createBtn.TextColor = System.Drawing.Color.White;
            this.createBtn.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto Mono", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "Nhập số lượng người chơi (từ 1->5)";
            // 
            // Form_Create
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 150);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.createBtn);
            this.Controls.Add(this.maxTextbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1920, 1032);
            this.MinimumSize = new System.Drawing.Size(190, 40);
            this.Name = "Form_Create";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ReaLTaiizor.Controls.HopeTextBox maxTextbox;
        private ReaLTaiizor.Controls.HopeButton createBtn;
        private System.Windows.Forms.Label label1;
    }
}