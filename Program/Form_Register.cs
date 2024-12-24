using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;
using Models;
using System.Text.RegularExpressions;
using Microsoft.IdentityModel.Tokens;

namespace Program
{
    public partial class Form_Register : Form
    {
        private Client client;
        public Form_Register()
        {
            Client.RegisterSuccessful += OnRegisterSuccessful;

            this.client = Form_Input_ServerIP.client;
            InitializeComponent();
        }

        private void registerButton_Click_1(object sender, EventArgs e)
        {
            string username = usernameTextbox.Text;
            string password = passwordTextbox.Text;
            string email = emailTextbox.Text;
            string confirmpw = confirmpassTextbox.Text;

            // check thông tin
            if (username.IsNullOrEmpty() || password.IsNullOrEmpty() || email.IsNullOrEmpty() || confirmpw.IsNullOrEmpty())
            {
                ShowMessage("Vui lòng nhập đầy đủ thông tin");
                return;
            }

            //check email
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                ShowMessage("Email không hợp lệ");
                return;
            }

            // check độ mạnh mật khẩu
            if (password.Length < 8)
            {
                ShowMessage("Mật khẩu phải có ít nhất 8 ký tự.");
                return;
            }

            // Kiểm tra chữ thường
            if (!Regex.IsMatch(password, @"[a-z]"))
            {
                ShowMessage("Mật khẩu phải chứa ít nhất một chữ cái viết thường.");
                return;
            }

            // Kiểm tra chữ hoa
            if (!Regex.IsMatch(password, @"[A-Z]"))
            {
                ShowMessage("Mật khẩu phải chứa ít nhất một chữ cái viết hoa.");
                return;
            }

            // Kiểm tra số
            if (!Regex.IsMatch(password, @"\d"))
            {
                ShowMessage("Yếu: Mật khẩu phải chứa ít nhất một chữ số.");
                return;
            }

            // check mật khẩu không trùng 
            if (password != confirmpw)
            {
                ShowMessage("Mật khẩu không khớp");
                return;
            }


            // Gửi thông tin đăng ký lên server
            RegisterPacket packet = new RegisterPacket($"{username};{email};{password}");
            client.SendPacket(packet);
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

        public void ShowMessage(string messsage)
        {
            Form_Message formmessage = new Form_Message(messsage);
            formmessage.StartPosition = FormStartPosition.Manual;
            int centerX = this.Location.X + (this.Width - formmessage.Width) / 2;
            int centerY = this.Location.Y + (this.Height - formmessage.Height) / 2;
            formmessage.Location = new Point(centerX, centerY);

            formmessage.ShowDialog();
        }


        #region điều hướng
        private void OnRegisterSuccessful()
        {
            navigateToLoginForm();
        }

        private void backButton_Click_1(object sender, EventArgs e)
        {
            navigateToLoginForm();
        }

        private void navigateToLoginForm()
        {
            this.Close();
        }
        #endregion
    }
}