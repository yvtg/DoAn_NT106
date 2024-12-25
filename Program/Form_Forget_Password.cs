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

namespace Program
{
    public partial class Form_Forget_Password : Form
    {
        private Client client;
        public Form_Forget_Password()
        {
            InitializeComponent();
            this.client = Program.Form_Input_ServerIP.client;
            client.ResetPasswordSuccessful += OnOTPRequestSuccessful;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            string email = emailTextbox.Text.Trim();

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng nhập email.");
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Email không hợp lệ. Vui lòng nhập lại.");
                return;
            }

            // Gửi yêu cầu OTP tới server
            client.SendResetPasswordRequest(email);

            // Thông báo gửi yêu cầu
            MessageBox.Show("Đang xử lý yêu cầu, vui lòng đợi...");
        }

        private void OnOTPRequestSuccessful()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(OnOTPRequestSuccessful));
                return;
            }

            MessageBox.Show("Mã OTP đã được gửi đến email của bạn.");
            string email = emailTextbox.Text.Trim();
            string otp = ""; // OTP sẽ được lấy từ phản hồi của server nếu cần

            // Chuyển sang Form OTP
            Form_OTP otpForm = new Form_OTP(email, otp);
            otpForm.StartPosition = FormStartPosition.Manual;
            otpForm.Location = this.Location;
            otpForm.Show();
            this.Hide();
            otpForm.FormClosed += (s, args) => this.Close();
        }
        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
