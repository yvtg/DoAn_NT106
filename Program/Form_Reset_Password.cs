using Microsoft.IdentityModel.Tokens;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            client.ServerDisconnected += () =>
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        this.Close(); // Đóng form trên luồng UI
                    }));
                }
                else
                {
                    this.Close();
                }
            };

            // Đăng ký sự kiện khi nhận kết quả đặt lại mật khẩu
            client.ResetPasswordResult += OnPasswordResetSuccessful;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            string password = passwordTextbox.Text.Trim();
            string confirmpw = confirmpassTextbox.Text.Trim();

            // Kiểm tra thông tin
            if (password.IsNullOrEmpty() || confirmpw.IsNullOrEmpty())
            {
                ShowMessage("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            // Kiểm tra độ mạnh mật khẩu
            if (password.Length < 8)
            {
                ShowMessage("Mật khẩu phải có ít nhất 8 ký tự.");
                return;
            }

            if (!Regex.IsMatch(password, @"[a-z]"))
            {
                ShowMessage("Mật khẩu phải chứa ít nhất một chữ cái viết thường.");
                return;
            }

            if (!Regex.IsMatch(password, @"[A-Z]"))
            {
                ShowMessage("Mật khẩu phải chứa ít nhất một chữ cái viết hoa.");
                return;
            }

            if (!Regex.IsMatch(password, @"\d"))
            {
                ShowMessage("Mật khẩu phải chứa ít nhất một chữ số.");
                return;
            }

            if (!Regex.IsMatch(password, @"[!@#$%^&*(),.?""':{}|<>]"))
            {
                ShowMessage("Mật khẩu phải chứa ít nhất một ký tự đặc biệt.");
                return;
            }

            if (password != confirmpw)
            {
                ShowMessage("Mật khẩu không khớp.");
                return;
            }


            // Gửi yêu cầu đặt lại mật khẩu đến server
            client.SendResetPassword(email, password);
        }

        private void OnPasswordResetSuccessful(string status)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => OnPasswordResetSuccessful(status)));
                return;
            }

            if (status == "SUCCESS")
            {
                foreach (Form form in Application.OpenForms)
                {
                    if (form is Form_Home)
                    {
                        form.Hide(); 
                        break;
                    }
                }

                Form_Login loginForm = new Form_Login();
                loginForm.StartPosition = FormStartPosition.Manual;
                loginForm.Location = this.Location;
                loginForm.Show();

                this.Close();
            }
        }
        public void ShowMessage(string messsage)
        {
            Form_Message formmessage = new Form_Message(messsage);
            formmessage.StartPosition = FormStartPosition.Manual;
            int centerX = this.Location.X + (this.Width - formmessage.Width) / 2;
            int centerY = this.Location.Y + (this.Height - formmessage.Height) / 2;
            formmessage.Location = new Point(centerX, centerY);
            formmessage.ShowDialog();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Form_Forget_Password forgetpasswordForm = new Form_Forget_Password();
            forgetpasswordForm.StartPosition = FormStartPosition.Manual;
            forgetpasswordForm.Location = this.Location;
            forgetpasswordForm.Show();
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
