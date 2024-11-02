namespace Program
{
    partial class Form_Profile
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
            this.label1 = new System.Windows.Forms.Label();
            this.nameTextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.scoreTextbox = new System.Windows.Forms.TextBox();
            this.maxrankTextbox = new System.Windows.Forms.TextBox();
            this.minrankTextbox = new System.Windows.Forms.TextBox();
            this.countTextbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên đăng nhập";
            // 
            // nameTextbox
            // 
            this.nameTextbox.Location = new System.Drawing.Point(143, 155);
            this.nameTextbox.Name = "nameTextbox";
            this.nameTextbox.Size = new System.Drawing.Size(223, 22);
            this.nameTextbox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Điểm cao nhất";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Thứ hạng cao nhất";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 285);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Thứ hạng thấp nhất";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 324);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Số lần chơi";
            // 
            // scoreTextbox
            // 
            this.scoreTextbox.Location = new System.Drawing.Point(143, 197);
            this.scoreTextbox.Name = "scoreTextbox";
            this.scoreTextbox.Size = new System.Drawing.Size(223, 22);
            this.scoreTextbox.TabIndex = 8;
            // 
            // maxrankTextbox
            // 
            this.maxrankTextbox.Location = new System.Drawing.Point(143, 237);
            this.maxrankTextbox.Name = "maxrankTextbox";
            this.maxrankTextbox.Size = new System.Drawing.Size(223, 22);
            this.maxrankTextbox.TabIndex = 9;
            // 
            // minrankTextbox
            // 
            this.minrankTextbox.Location = new System.Drawing.Point(143, 279);
            this.minrankTextbox.Name = "minrankTextbox";
            this.minrankTextbox.Size = new System.Drawing.Size(223, 22);
            this.minrankTextbox.TabIndex = 10;
            // 
            // countTextbox
            // 
            this.countTextbox.Location = new System.Drawing.Point(143, 318);
            this.countTextbox.Name = "countTextbox";
            this.countTextbox.Size = new System.Drawing.Size(223, 22);
            this.countTextbox.TabIndex = 11;
            // 
            // Form_Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 362);
            this.Controls.Add(this.countTextbox);
            this.Controls.Add(this.minrankTextbox);
            this.Controls.Add(this.maxrankTextbox);
            this.Controls.Add(this.scoreTextbox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameTextbox);
            this.Controls.Add(this.label1);
            this.Name = "Form_Profile";
            this.Text = "Form_Profile";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameTextbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox scoreTextbox;
        private System.Windows.Forms.TextBox maxrankTextbox;
        private System.Windows.Forms.TextBox minrankTextbox;
        private System.Windows.Forms.TextBox countTextbox;
    }
}