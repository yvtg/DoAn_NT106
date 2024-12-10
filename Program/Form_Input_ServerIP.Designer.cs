namespace Program
{
    partial class Form_Input_ServerIP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Input_ServerIP));
            this.sqlCommandBuilder1 = new Microsoft.Data.SqlClient.SqlCommandBuilder();
            this.inputServerIP = new ReaLTaiizor.Forms.HopeForm();
            this.connectBtn = new ReaLTaiizor.Controls.HopeButton();
            this.serverIPTextBox = new ReaLTaiizor.Controls.HopeTextBox();
            this.idLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // inputServerIP
            // 
            this.inputServerIP.ControlBoxColorH = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.inputServerIP.ControlBoxColorHC = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.inputServerIP.ControlBoxColorN = System.Drawing.Color.White;
            this.inputServerIP.Cursor = System.Windows.Forms.Cursors.Default;
            this.inputServerIP.Dock = System.Windows.Forms.DockStyle.Top;
            this.inputServerIP.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.inputServerIP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.inputServerIP.Image = ((System.Drawing.Image)(resources.GetObject("inputServerIP.Image")));
            this.inputServerIP.Location = new System.Drawing.Point(0, 0);
            this.inputServerIP.Name = "inputServerIP";
            this.inputServerIP.Size = new System.Drawing.Size(453, 40);
            this.inputServerIP.TabIndex = 22;
            this.inputServerIP.Text = "Input Server IP";
            this.inputServerIP.ThemeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(131)))), ((int)(((byte)(146)))));
            // 
            // connectBtn
            // 
            this.connectBtn.BorderColor = System.Drawing.Color.Black;
            this.connectBtn.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.connectBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.connectBtn.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.connectBtn.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.connectBtn.Font = new System.Drawing.Font("Roboto Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectBtn.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(131)))), ((int)(((byte)(146)))));
            this.connectBtn.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.connectBtn.Location = new System.Drawing.Point(318, 91);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(226)))), ((int)(((byte)(167)))));
            this.connectBtn.Size = new System.Drawing.Size(104, 36);
            this.connectBtn.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.connectBtn.TabIndex = 25;
            this.connectBtn.Text = "Connect";
            this.connectBtn.TextColor = System.Drawing.Color.White;
            this.connectBtn.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // serverIPTextBox
            // 
            this.serverIPTextBox.BackColor = System.Drawing.Color.White;
            this.serverIPTextBox.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(226)))), ((int)(((byte)(167)))));
            this.serverIPTextBox.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(226)))), ((int)(((byte)(167)))));
            this.serverIPTextBox.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(226)))), ((int)(((byte)(167)))));
            this.serverIPTextBox.Font = new System.Drawing.Font("Roboto Mono", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverIPTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.serverIPTextBox.Hint = "";
            this.serverIPTextBox.Location = new System.Drawing.Point(32, 91);
            this.serverIPTextBox.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.serverIPTextBox.MaxLength = 32767;
            this.serverIPTextBox.Multiline = false;
            this.serverIPTextBox.Name = "serverIPTextBox";
            this.serverIPTextBox.PasswordChar = '\0';
            this.serverIPTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.serverIPTextBox.SelectedText = "";
            this.serverIPTextBox.SelectionLength = 0;
            this.serverIPTextBox.SelectionStart = 0;
            this.serverIPTextBox.Size = new System.Drawing.Size(253, 36);
            this.serverIPTextBox.TabIndex = 24;
            this.serverIPTextBox.TabStop = false;
            this.serverIPTextBox.UseSystemPasswordChar = false;
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Font = new System.Drawing.Font("Roboto Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idLabel.Location = new System.Drawing.Point(67, 55);
            this.idLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.idLabel.Name = "idLabel";
            this.idLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.idLabel.Size = new System.Drawing.Size(270, 21);
            this.idLabel.TabIndex = 23;
            this.idLabel.Text = "Nhập địa chỉ IP của server\r\n";
            // 
            // Form_Input_ServerIP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 158);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.serverIPTextBox);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.inputServerIP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1920, 1032);
            this.MinimumSize = new System.Drawing.Size(190, 40);
            this.Name = "Form_Input_ServerIP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Input_ServerIP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Data.SqlClient.SqlCommandBuilder sqlCommandBuilder1;
        private ReaLTaiizor.Forms.HopeForm inputServerIP;
        private ReaLTaiizor.Controls.HopeTextBox serverIPTextBox;
        private System.Windows.Forms.Label idLabel;
        private ReaLTaiizor.Controls.HopeButton connectBtn;
    }
}