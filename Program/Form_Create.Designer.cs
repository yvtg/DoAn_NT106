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
            this.create = new ReaLTaiizor.Forms.HopeForm();
            this.panelBody = new ReaLTaiizor.Controls.Panel();
            this.DefaultBtn = new ReaLTaiizor.Controls.HopeButton();
            this.TotalBtn = new ReaLTaiizor.Controls.HopeButton();
            this.UpfileBtn = new ReaLTaiizor.Controls.HopeButton();
            this.SuspendLayout();
            // 
            // createBtn
            // 
            this.createBtn.BorderColor = System.Drawing.Color.Black;
            this.createBtn.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.createBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.createBtn.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.createBtn.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.createBtn.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createBtn.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.createBtn.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.createBtn.Location = new System.Drawing.Point(346, 257);
            this.createBtn.Name = "createBtn";
            this.createBtn.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(107)))), ((int)(((byte)(111)))));
            this.createBtn.Size = new System.Drawing.Size(97, 54);
            this.createBtn.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.createBtn.TabIndex = 18;
            this.createBtn.Text = "Create";
            this.createBtn.TextColor = System.Drawing.Color.White;
            this.createBtn.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.label1.Location = new System.Drawing.Point(191, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 19);
            this.label1.TabIndex = 19;
            this.label1.Text = "Player Number ";
            // 
            // numeric
            // 
            this.numeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(230)))));
            this.numeric.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(168)))), ((int)(((byte)(117)))));
            this.numeric.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(168)))), ((int)(((byte)(117)))));
            this.numeric.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(168)))), ((int)(((byte)(117)))));
            this.numeric.BorderHoverColorA = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.numeric.ButtonTextColorA = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.numeric.ButtonTextColorB = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.numeric.Cursor = System.Windows.Forms.Cursors.Hand;
            this.numeric.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeric.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.numeric.HoverButtonTextColorA = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(230)))));
            this.numeric.HoverButtonTextColorB = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(230)))));
            this.numeric.Location = new System.Drawing.Point(194, 285);
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
            // create
            // 
            this.create.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(211)))));
            this.create.ControlBoxColorH = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.create.ControlBoxColorHC = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.create.ControlBoxColorN = System.Drawing.Color.White;
            this.create.Cursor = System.Windows.Forms.Cursors.Default;
            this.create.Dock = System.Windows.Forms.DockStyle.Top;
            this.create.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.create.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.create.Image = null;
            this.create.Location = new System.Drawing.Point(0, 0);
            this.create.Name = "create";
            this.create.Size = new System.Drawing.Size(632, 40);
            this.create.TabIndex = 28;
            this.create.Text = "Create Room";
            this.create.ThemeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            // 
            // panelBody
            // 
            this.panelBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(211)))));
            this.panelBody.EdgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(41)))), ((int)(((byte)(50)))));
            this.panelBody.Location = new System.Drawing.Point(12, 82);
            this.panelBody.Name = "panelBody";
            this.panelBody.Padding = new System.Windows.Forms.Padding(5);
            this.panelBody.Size = new System.Drawing.Size(608, 160);
            this.panelBody.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.panelBody.TabIndex = 29;
            this.panelBody.Text = "panel1";
            // 
            // DefaultBtn
            // 
            this.DefaultBtn.BorderColor = System.Drawing.Color.Black;
            this.DefaultBtn.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.DefaultBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DefaultBtn.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.DefaultBtn.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DefaultBtn.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DefaultBtn.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.DefaultBtn.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.DefaultBtn.Location = new System.Drawing.Point(12, 46);
            this.DefaultBtn.Name = "DefaultBtn";
            this.DefaultBtn.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(107)))), ((int)(((byte)(111)))));
            this.DefaultBtn.Size = new System.Drawing.Size(202, 30);
            this.DefaultBtn.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.DefaultBtn.TabIndex = 18;
            this.DefaultBtn.Text = "Default";
            this.DefaultBtn.TextColor = System.Drawing.Color.White;
            this.DefaultBtn.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.DefaultBtn.Click += new System.EventHandler(this.DefaultBtn_Click);
            // 
            // TotalBtn
            // 
            this.TotalBtn.BorderColor = System.Drawing.Color.Black;
            this.TotalBtn.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.TotalBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TotalBtn.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.TotalBtn.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TotalBtn.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalBtn.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.TotalBtn.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.TotalBtn.Location = new System.Drawing.Point(215, 46);
            this.TotalBtn.Name = "TotalBtn";
            this.TotalBtn.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(107)))), ((int)(((byte)(111)))));
            this.TotalBtn.Size = new System.Drawing.Size(202, 30);
            this.TotalBtn.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.TotalBtn.TabIndex = 18;
            this.TotalBtn.Text = "Total";
            this.TotalBtn.TextColor = System.Drawing.Color.White;
            this.TotalBtn.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.TotalBtn.Click += new System.EventHandler(this.TotalBtn_Click);
            // 
            // UpfileBtn
            // 
            this.UpfileBtn.BorderColor = System.Drawing.Color.Black;
            this.UpfileBtn.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.UpfileBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UpfileBtn.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.UpfileBtn.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.UpfileBtn.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpfileBtn.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(63)))), ((int)(((byte)(88)))));
            this.UpfileBtn.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.UpfileBtn.Location = new System.Drawing.Point(418, 46);
            this.UpfileBtn.Name = "UpfileBtn";
            this.UpfileBtn.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(107)))), ((int)(((byte)(111)))));
            this.UpfileBtn.Size = new System.Drawing.Size(202, 30);
            this.UpfileBtn.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.UpfileBtn.TabIndex = 18;
            this.UpfileBtn.Text = "Your File";
            this.UpfileBtn.TextColor = System.Drawing.Color.White;
            this.UpfileBtn.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.UpfileBtn.Click += new System.EventHandler(this.UpfileBtn_Click);
            // 
            // Form_Create
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(211)))));
            this.ClientSize = new System.Drawing.Size(632, 344);
            this.Controls.Add(this.TotalBtn);
            this.Controls.Add(this.UpfileBtn);
            this.Controls.Add(this.panelBody);
            this.Controls.Add(this.DefaultBtn);
            this.Controls.Add(this.create);
            this.Controls.Add(this.numeric);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.createBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1920, 1032);
            this.MinimumSize = new System.Drawing.Size(190, 40);
            this.Name = "Form_Create";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Room";
            this.Load += new System.EventHandler(this.Form_Create_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ReaLTaiizor.Controls.HopeButton createBtn;
        private System.Windows.Forms.Label label1;
        private ReaLTaiizor.Controls.HopeNumeric numeric;
        private ReaLTaiizor.Forms.HopeForm create;
        private ReaLTaiizor.Controls.Panel panelBody;
        private ReaLTaiizor.Controls.HopeButton DefaultBtn;
        private ReaLTaiizor.Controls.HopeButton TotalBtn;
        private ReaLTaiizor.Controls.HopeButton UpfileBtn;
    }
}