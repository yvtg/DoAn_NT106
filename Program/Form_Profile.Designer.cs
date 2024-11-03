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
            this.usernameLabel = new System.Windows.Forms.Label();
            this.maxscoreLabel = new System.Windows.Forms.Label();
            this.maxrankLabel = new System.Windows.Forms.Label();
            this.minrankLabel = new System.Windows.Forms.Label();
            this.countLabel = new System.Windows.Forms.Label();
            this.usernameTextbox = new System.Windows.Forms.TextBox();
            this.maxscoreTextbox = new System.Windows.Forms.TextBox();
            this.maxrankTextbox = new System.Windows.Forms.TextBox();
            this.minrankTextbox = new System.Windows.Forms.TextBox();
            this.countTextbox = new System.Windows.Forms.TextBox();
            this.backButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(16, 221);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(98, 16);
            this.usernameLabel.TabIndex = 0;
            this.usernameLabel.Text = "Tên đăng nhập";
            // 
            // maxscoreLabel
            // 
            this.maxscoreLabel.AutoSize = true;
            this.maxscoreLabel.Location = new System.Drawing.Point(16, 285);
            this.maxscoreLabel.Name = "maxscoreLabel";
            this.maxscoreLabel.Size = new System.Drawing.Size(92, 16);
            this.maxscoreLabel.TabIndex = 2;
            this.maxscoreLabel.Text = "Điểm cao nhất";
            // 
            // maxrankLabel
            // 
            this.maxrankLabel.AutoSize = true;
            this.maxrankLabel.Location = new System.Drawing.Point(16, 347);
            this.maxrankLabel.Name = "maxrankLabel";
            this.maxrankLabel.Size = new System.Drawing.Size(117, 16);
            this.maxrankLabel.TabIndex = 3;
            this.maxrankLabel.Text = "Thứ hạng cao nhất";
            // 
            // minrankLabel
            // 
            this.minrankLabel.AutoSize = true;
            this.minrankLabel.Location = new System.Drawing.Point(16, 411);
            this.minrankLabel.Name = "minrankLabel";
            this.minrankLabel.Size = new System.Drawing.Size(120, 16);
            this.minrankLabel.TabIndex = 4;
            this.minrankLabel.Text = "Thứ hạng thấp nhất";
            // 
            // countLabel
            // 
            this.countLabel.AutoSize = true;
            this.countLabel.Location = new System.Drawing.Point(16, 470);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(73, 16);
            this.countLabel.TabIndex = 5;
            this.countLabel.Text = "Số lần chơi";
            // 
            // usernameTextbox
            // 
            this.usernameTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usernameTextbox.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTextbox.Location = new System.Drawing.Point(142, 213);
            this.usernameTextbox.Name = "usernameTextbox";
            this.usernameTextbox.Size = new System.Drawing.Size(310, 31);
            this.usernameTextbox.TabIndex = 7;
            // 
            // maxscoreTextbox
            // 
            this.maxscoreTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maxscoreTextbox.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxscoreTextbox.Location = new System.Drawing.Point(142, 277);
            this.maxscoreTextbox.Name = "maxscoreTextbox";
            this.maxscoreTextbox.Size = new System.Drawing.Size(310, 31);
            this.maxscoreTextbox.TabIndex = 8;
            // 
            // maxrankTextbox
            // 
            this.maxrankTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maxrankTextbox.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxrankTextbox.Location = new System.Drawing.Point(142, 339);
            this.maxrankTextbox.Name = "maxrankTextbox";
            this.maxrankTextbox.Size = new System.Drawing.Size(310, 31);
            this.maxrankTextbox.TabIndex = 9;
            // 
            // minrankTextbox
            // 
            this.minrankTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.minrankTextbox.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minrankTextbox.Location = new System.Drawing.Point(142, 403);
            this.minrankTextbox.Name = "minrankTextbox";
            this.minrankTextbox.Size = new System.Drawing.Size(310, 31);
            this.minrankTextbox.TabIndex = 10;
            // 
            // countTextbox
            // 
            this.countTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.countTextbox.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countTextbox.Location = new System.Drawing.Point(142, 462);
            this.countTextbox.Name = "countTextbox";
            this.countTextbox.Size = new System.Drawing.Size(310, 31);
            this.countTextbox.TabIndex = 11;
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(172, 507);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(144, 39);
            this.backButton.TabIndex = 12;
            this.backButton.Text = "Quay về";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // Form_Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 558);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.countTextbox);
            this.Controls.Add(this.minrankTextbox);
            this.Controls.Add(this.maxrankTextbox);
            this.Controls.Add(this.maxscoreTextbox);
            this.Controls.Add(this.usernameTextbox);
            this.Controls.Add(this.countLabel);
            this.Controls.Add(this.minrankLabel);
            this.Controls.Add(this.maxrankLabel);
            this.Controls.Add(this.maxscoreLabel);
            this.Controls.Add(this.usernameLabel);
            this.Name = "Form_Profile";
            this.Text = "Form_Profile";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label maxscoreLabel;
        private System.Windows.Forms.Label maxrankLabel;
        private System.Windows.Forms.Label minrankLabel;
        private System.Windows.Forms.Label countLabel;
        private System.Windows.Forms.TextBox usernameTextbox;
        private System.Windows.Forms.TextBox maxscoreTextbox;
        private System.Windows.Forms.TextBox maxrankTextbox;
        private System.Windows.Forms.TextBox minrankTextbox;
        private System.Windows.Forms.TextBox countTextbox;
        private System.Windows.Forms.Button backButton;
    }
}