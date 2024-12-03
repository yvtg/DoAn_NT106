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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Create));
            this.createBtn = new ReaLTaiizor.Controls.HopeButton();
            this.label1 = new System.Windows.Forms.Label();
            this.numeric = new ReaLTaiizor.Controls.HopeNumeric();
            this.hopeForm1 = new ReaLTaiizor.Forms.HopeForm();
            this.backButton = new ReaLTaiizor.Controls.HopeButton();
            this.SuspendLayout();
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
            this.createBtn.Location = new System.Drawing.Point(84, 250);
            this.createBtn.Name = "createBtn";
            this.createBtn.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(226)))), ((int)(((byte)(167)))));
            this.createBtn.Size = new System.Drawing.Size(169, 36);
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
            this.label1.Location = new System.Drawing.Point(21, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "Nhập số lượng người chơi (từ 1->5)";
            // 
            // numeric
            // 
            this.numeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(230)))));
            this.numeric.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(226)))), ((int)(((byte)(167)))));
            this.numeric.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(226)))), ((int)(((byte)(167)))));
            this.numeric.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(226)))), ((int)(((byte)(167)))));
            this.numeric.BorderHoverColorA = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.numeric.ButtonTextColorA = System.Drawing.Color.Black;
            this.numeric.ButtonTextColorB = System.Drawing.Color.Black;
            this.numeric.Cursor = System.Windows.Forms.Cursors.Hand;
            this.numeric.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.numeric.ForeColor = System.Drawing.Color.Black;
            this.numeric.HoverButtonTextColorA = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(230)))));
            this.numeric.HoverButtonTextColorB = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(230)))));
            this.numeric.Location = new System.Drawing.Point(109, 196);
            this.numeric.MaxNum = 10F;
            this.numeric.MinNum = 0F;
            this.numeric.Name = "numeric";
            this.numeric.Precision = 0;
            this.numeric.Size = new System.Drawing.Size(121, 32);
            this.numeric.Step = 1F;
            this.numeric.Style = ReaLTaiizor.Controls.HopeNumeric.NumericStyle.LeftRight;
            this.numeric.TabIndex = 20;
            this.numeric.Text = "hopeNumeric1";
            this.numeric.ValueNumber = 0F;
            // 
            // hopeForm1
            // 
            this.hopeForm1.ControlBoxColorH = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.hopeForm1.ControlBoxColorHC = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.hopeForm1.ControlBoxColorN = System.Drawing.Color.White;
            this.hopeForm1.Cursor = System.Windows.Forms.Cursors.Default;
            this.hopeForm1.Dock = System.Windows.Forms.DockStyle.Top;
            this.hopeForm1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.hopeForm1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.hopeForm1.Image = ((System.Drawing.Image)(resources.GetObject("hopeForm1.Image")));
            this.hopeForm1.Location = new System.Drawing.Point(0, 0);
            this.hopeForm1.Name = "hopeForm1";
            this.hopeForm1.Size = new System.Drawing.Size(348, 40);
            this.hopeForm1.TabIndex = 21;
            this.hopeForm1.Text = "Home";
            this.hopeForm1.ThemeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(131)))), ((int)(((byte)(146)))));
            // 
            // backButton
            // 
            this.backButton.BorderColor = System.Drawing.Color.Black;
            this.backButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.backButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.backButton.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.backButton.Font = new System.Drawing.Font("Roboto Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(131)))), ((int)(((byte)(146)))));
            this.backButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.backButton.Location = new System.Drawing.Point(84, 312);
            this.backButton.Name = "backButton";
            this.backButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(226)))), ((int)(((byte)(167)))));
            this.backButton.Size = new System.Drawing.Size(169, 36);
            this.backButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.backButton.TabIndex = 26;
            this.backButton.Text = "Quay về";
            this.backButton.TextColor = System.Drawing.Color.White;
            this.backButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // Form_Create
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(348, 453);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.hopeForm1);
            this.Controls.Add(this.numeric);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.createBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1920, 1032);
            this.MinimumSize = new System.Drawing.Size(190, 40);
            this.Name = "Form_Create";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form_Create_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ReaLTaiizor.Controls.HopeButton createBtn;
        private System.Windows.Forms.Label label1;
        private ReaLTaiizor.Controls.HopeNumeric numeric;
        private ReaLTaiizor.Forms.HopeForm hopeForm1;
        private ReaLTaiizor.Controls.HopeButton backButton;
    }
}