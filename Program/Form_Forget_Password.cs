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

namespace Program
{
    public partial class Form_Forget_Password : Form
    {
        private Client client;
        public Form_Forget_Password()
        {
            InitializeComponent();
            this.client = Program.Form_Input_ServerIP.client;
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
            client.ResetPasswordResult += OnOTPRequestSuccessful;
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Kiểm tra độ dài email
                if (email.Length > 254)
                    return false;

                // Regex kiểm tra email
                string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                if (!Regex.IsMatch(email, emailPattern, RegexOptions.IgnoreCase))
                    return false;

                // Tạo đối tượng MailAddress để kiểm tra email hợp lệ
                var addr = new System.Net.Mail.MailAddress(email);

                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }


        private void sendButton_Click_1(object sender, EventArgs e)
        {
            string email = emailTextbox.Text.Trim();

            if (string.IsNullOrEmpty(email))
            {
                ShowMessage("Vui lòng nhập email.");

                return;
            }

            if (!IsValidEmail(emailTextbox.Text.Trim()))
            {
                ShowMessage("Email không hợp lệ. Vui lòng nhập lại.");
                return;
            }

            // Gửi yêu cầu OTP tới server
            client.SendResetPasswordRequest(email);
        }

        private void OnOTPRequestSuccessful( string status)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => OnOTPRequestSuccessful(status)));
                return;
            }

            if (status == "EMAIL_SENT")
            {
                string email = emailTextbox.Text.Trim();

                // Chuyển sang Form OTP
                Form_OTP otpForm = new Form_OTP(email);
                otpForm.StartPosition = FormStartPosition.Manual;
                otpForm.Location = this.Location;
                otpForm.Show();
                this.Hide();
                otpForm.FormClosed += (s, args) => this.Close();
            }
        }
        public void ShowMessage(string message)
        {
            using (Form_Message formMessage = new Form_Message(message))
            {
                formMessage.StartPosition = FormStartPosition.Manual;

                formMessage.Load += (s, e) =>
                {
                    int centerX = this.Location.X + (this.Width - formMessage.Width) / 2;
                    int centerY = this.Location.Y + (this.Height - formMessage.Height) / 2;
                    formMessage.Location = new Point(centerX, centerY);
                };

                formMessage.ShowDialog();
            }
        }
        private void backButton_Click_1(object sender, EventArgs e)
        {
            this.Hide(); // Ẩn form hiện tại
            Form_Login loginForm = new Form_Login(); // Mở lại form Login
            loginForm.StartPosition = FormStartPosition.Manual;
            loginForm.Location = this.Location;
            loginForm.Show();
        }
    }
}
