﻿using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace Program
{
    public partial class Form_OTP : Form
    {
        private Client client;
        private string email;
        private int timeLeft = 60;
     
        public Form_OTP(string email)
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

            // Đăng ký sự kiện khi nhận kết quả xác thực OTP
            client.ResetPasswordResult += OnReceiveOTP;

            otpTimer.Interval = 1000;
            otpTimer.Start();
        }

        private void otpTimer_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft--;
                timerLabel.Text = $"Thời gian còn lại: {timeLeft}s";
            }
            else
            {
                otpTimer.Stop();
                ShowMessage("Vui lòng nhập mã OTP.");
                BackToPreviousForm();
            }
        }
        private async void confirmButton_Click_1(object sender, EventArgs e)
        {
            string userOtp = otpTextbox.Text.Trim();

            if (string.IsNullOrEmpty(userOtp))
            {
                ShowMessage("Vui lòng nhập mã OTP.");
                return;
            }

            // Gửi yêu cầu xác thực OTP đến server
            await client.SendVerifyOTPRequest(email, userOtp);
        }
        private void OnReceiveOTP(string status)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => OnReceiveOTP(status)));
                return;
            }

            Console.WriteLine($"Nhận được trạng thái OTP: {status}"); // Debugging
            if (status == "OTP_VERIFIED")
            {
                otpTimer.Stop();
                ShowMessage("Mã OTP hợp lệ! Chuyển đến form đặt lại mật khẩu.");
                Form_Reset_Password resetPasswordForm = new Form_Reset_Password(email);
                resetPasswordForm.StartPosition = FormStartPosition.Manual;
                resetPasswordForm.Location = this.Location;
                resetPasswordForm.Show();
                this.Close();
            }
            else if (status == "OTP_FAIL")
            {
                ShowMessage("Mã OTP không hợp lệ.");
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
        private void BackToPreviousForm()
        {
            otpTimer.Stop();

            Form_Forget_Password forgetPasswordForm = new Form_Forget_Password();
            forgetPasswordForm.StartPosition = FormStartPosition.Manual;
            forgetPasswordForm.Location = this.Location;
            forgetPasswordForm.Show();
            this.Close();
        }

        private void backButton_Click_1(object sender, EventArgs e)
        {
            Form_Forget_Password forgetpasswordForm = new Form_Forget_Password();
            forgetpasswordForm.StartPosition = FormStartPosition.Manual;
            forgetpasswordForm.Location = this.Location;
            forgetpasswordForm.Show();
            otpTimer.Stop();
            this.Close();
        }
        private void Form_OTP_FormClosing(object sender, FormClosingEventArgs e)
        {
            otpTimer.Stop();
        }

       
    }
}
