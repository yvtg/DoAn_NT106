using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Program
{
    public partial class Form_Reset_Password : Form
    {
        private Client client;
        private string email;
        public Form_Reset_Password(string email)
        {
            InitializeComponent();
            this.email = email;
            client = Form_Input_ServerIP.client;

            // Đăng ký sự kiện khi nhận kết quả đặt lại mật khẩu
            client.ResetPasswordResult += OnPasswordResetSuccessful;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            string newPassword = passwordTextbox.Text.Trim();
            string confirmPassword = confirmpassTextbox.Text.Trim();

            if (string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp.");
                return;
            }

            // Gửi yêu cầu đặt lại mật khẩu đến server
            client.SendResetPassword(email, newPassword);
        }

        private void OnPasswordResetSuccessful(string status)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(()=>OnPasswordResetSuccessful(status)));
                return;
            }

            if (status== "SUCCESS")
            {
                MessageBox.Show("Đặt lại mật khẩu thành công.");
                this.Close();
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void showPwCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showPwCheckBox.Checked)
            {
                // Hiển thị mật khẩu
                passwordTextbox.UseSystemPasswordChar = false;
                confirmpassTextbox.UseSystemPasswordChar = false;
            }
            else
            {
                // Ẩn mật khẩu
                passwordTextbox.UseSystemPasswordChar = true;
                confirmpassTextbox.UseSystemPasswordChar = true;
            }
        }
    }
}
