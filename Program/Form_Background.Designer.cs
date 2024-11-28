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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Background));
            this.Background = new ReaLTaiizor.Forms.HopeForm();
            this.logButton = new ReaLTaiizor.Controls.HopeButton();
            this.regButton = new ReaLTaiizor.Controls.HopeButton();
            this.lawButton = new ReaLTaiizor.Controls.HopeButton();
            this.SuspendLayout();
            // 
            // Background
            // 
            this.Background.ControlBoxColorH = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(230)))));
            this.Background.ControlBoxColorHC = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.Background.ControlBoxColorN = System.Drawing.Color.White;
            this.Background.Cursor = System.Windows.Forms.Cursors.Default;
            this.Background.Dock = System.Windows.Forms.DockStyle.Top;
            this.Background.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.Background.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.Background.Image = ((System.Drawing.Image)(resources.GetObject("Background.Image")));
            this.Background.Location = new System.Drawing.Point(0, 0);
            this.Background.Name = "Background";
            this.Background.Size = new System.Drawing.Size(348, 40);
            this.Background.TabIndex = 3;
            this.Background.Text = "Background";
            this.Background.ThemeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(131)))), ((int)(((byte)(146)))));
            // 
            // logButton
            // 
            this.logButton.BorderColor = System.Drawing.Color.Black;
            this.logButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.logButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.logButton.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.logButton.Font = new System.Drawing.Font("Roboto Mono Medium", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(131)))), ((int)(((byte)(146)))));
            this.logButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.logButton.Location = new System.Drawing.Point(98, 251);
            this.logButton.Name = "logButton";
            this.logButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(226)))), ((int)(((byte)(167)))));
            this.logButton.Size = new System.Drawing.Size(162, 46);
            this.logButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.logButton.TabIndex = 4;
            this.logButton.Text = "Đăng nhập";
            this.logButton.TextColor = System.Drawing.Color.White;
            this.logButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.logButton.Click += new System.EventHandler(this.logButton_Click);
            // 
            // regButton
            // 
            this.regButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.regButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.regButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.regButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.regButton.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.regButton.Font = new System.Drawing.Font("Roboto Mono Medium", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(131)))), ((int)(((byte)(146)))));
            this.regButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.regButton.Location = new System.Drawing.Point(98, 318);
            this.regButton.Name = "regButton";
            this.regButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(226)))), ((int)(((byte)(167)))));
            this.regButton.Size = new System.Drawing.Size(162, 46);
            this.regButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.regButton.TabIndex = 5;
            this.regButton.Text = "Đăng ký";
            this.regButton.TextColor = System.Drawing.Color.White;
            this.regButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.regButton.Click += new System.EventHandler(this.regButton_Click);
            // 
            // lawButton
            // 
            this.lawButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.lawButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.lawButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lawButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.lawButton.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lawButton.Font = new System.Drawing.Font("Roboto Mono Medium", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lawButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(131)))), ((int)(((byte)(146)))));
            this.lawButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.lawButton.Location = new System.Drawing.Point(98, 383);
            this.lawButton.Name = "lawButton";
            this.lawButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(226)))), ((int)(((byte)(167)))));
            this.lawButton.Size = new System.Drawing.Size(162, 46);
            this.lawButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.lawButton.TabIndex = 6;
            this.lawButton.Text = "Luật chơi";
            this.lawButton.TextColor = System.Drawing.Color.White;
            this.lawButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.lawButton.Click += new System.EventHandler(this.lawButton_Click_1);
            // 
            // Form_Background
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(348, 453);
            this.Controls.Add(this.lawButton);
            this.Controls.Add(this.regButton);
            this.Controls.Add(this.logButton);
            this.Controls.Add(this.Background);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1920, 1032);
            this.MinimumSize = new System.Drawing.Size(190, 40);
            this.Name = "Form_Background";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Background";
            this.ResumeLayout(false);

        }

        #endregion
        private ReaLTaiizor.Forms.HopeForm Background;
        private ReaLTaiizor.Controls.HopeButton logButton;
        private ReaLTaiizor.Controls.HopeButton regButton;
        private ReaLTaiizor.Controls.HopeButton lawButton;
    }
}

