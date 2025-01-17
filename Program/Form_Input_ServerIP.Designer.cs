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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.portTextBox = new ReaLTaiizor.Controls.HopeTextBox();
            this.SuspendLayout();
            // 
            // inputServerIP
            // 
            this.inputServerIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(211)))));
            this.inputServerIP.ControlBoxColorH = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.inputServerIP.ControlBoxColorHC = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.inputServerIP.ControlBoxColorN = System.Drawing.Color.White;
            this.inputServerIP.Cursor = System.Windows.Forms.Cursors.Default;
            this.inputServerIP.Dock = System.Windows.Forms.DockStyle.Top;
            this.inputServerIP.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputServerIP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.inputServerIP.Image = null;
            this.inputServerIP.Location = new System.Drawing.Point(0, 0);
            this.inputServerIP.Name = "inputServerIP";
            this.inputServerIP.Size = new System.Drawing.Size(278, 40);
            this.inputServerIP.TabIndex = 22;
            this.inputServerIP.Text = "Input Server IP";
            this.inputServerIP.ThemeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.inputServerIP.MouseDown += new System.Windows.Forms.MouseEventHandler(this.inputServerIP_MouseDown);
            this.inputServerIP.MouseMove += new System.Windows.Forms.MouseEventHandler(this.inputServerIP_MouseMove);
            this.inputServerIP.MouseUp += new System.Windows.Forms.MouseEventHandler(this.inputServerIP_MouseUp);
            // 
            // connectBtn
            // 
            this.connectBtn.BorderColor = System.Drawing.Color.Black;
            this.connectBtn.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.connectBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.connectBtn.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(168)))), ((int)(((byte)(117)))));
            this.connectBtn.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.connectBtn.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectBtn.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.connectBtn.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.connectBtn.Location = new System.Drawing.Point(85, 204);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(107)))), ((int)(((byte)(111)))));
            this.connectBtn.Size = new System.Drawing.Size(115, 36);
            this.connectBtn.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.connectBtn.TabIndex = 2;
            this.connectBtn.Text = "Connect";
            this.connectBtn.TextColor = System.Drawing.Color.White;
            this.connectBtn.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // serverIPTextBox
            // 
            this.serverIPTextBox.BackColor = System.Drawing.Color.White;
            this.serverIPTextBox.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.serverIPTextBox.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.serverIPTextBox.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.serverIPTextBox.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverIPTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.serverIPTextBox.Hint = "";
            this.serverIPTextBox.Location = new System.Drawing.Point(85, 92);
            this.serverIPTextBox.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.serverIPTextBox.MaxLength = 32767;
            this.serverIPTextBox.Multiline = false;
            this.serverIPTextBox.Name = "serverIPTextBox";
            this.serverIPTextBox.PasswordChar = '\0';
            this.serverIPTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.serverIPTextBox.SelectedText = "";
            this.serverIPTextBox.SelectionLength = 0;
            this.serverIPTextBox.SelectionStart = 0;
            this.serverIPTextBox.Size = new System.Drawing.Size(177, 35);
            this.serverIPTextBox.TabIndex = 0;
            this.serverIPTextBox.TabStop = false;
            this.serverIPTextBox.UseSystemPasswordChar = false;
            this.serverIPTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.serverIPTextBox_KeyDown);
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.idLabel.Location = new System.Drawing.Point(20, 63);
            this.idLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.idLabel.Name = "idLabel";
            this.idLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.idLabel.Size = new System.Drawing.Size(153, 19);
            this.idLabel.TabIndex = 23;
            this.idLabel.Text = "Connect to server";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.label1.Location = new System.Drawing.Point(20, 106);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(27, 19);
            this.label1.TabIndex = 26;
            this.label1.Text = "IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.label2.Location = new System.Drawing.Point(20, 162);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(46, 19);
            this.label2.TabIndex = 27;
            this.label2.Text = "Port";
            // 
            // portTextBox
            // 
            this.portTextBox.BackColor = System.Drawing.Color.White;
            this.portTextBox.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.portTextBox.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.portTextBox.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.portTextBox.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.portTextBox.Hint = "";
            this.portTextBox.Location = new System.Drawing.Point(85, 148);
            this.portTextBox.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.portTextBox.MaxLength = 32767;
            this.portTextBox.Multiline = false;
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.PasswordChar = '\0';
            this.portTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.portTextBox.SelectedText = "";
            this.portTextBox.SelectionLength = 0;
            this.portTextBox.SelectionStart = 0;
            this.portTextBox.Size = new System.Drawing.Size(177, 35);
            this.portTextBox.TabIndex = 1;
            this.portTextBox.TabStop = false;
            this.portTextBox.UseSystemPasswordChar = false;
            this.portTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.portTextBox_KeyDown);
            // 
            // Form_Input_ServerIP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(211)))));
            this.ClientSize = new System.Drawing.Size(278, 264);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.serverIPTextBox);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.inputServerIP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ReaLTaiizor.Controls.HopeTextBox portTextBox;
    }
}