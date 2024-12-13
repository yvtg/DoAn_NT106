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

            if (username == "" || password == "" || email == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }

            if (password != confirmpw)
            {
                MessageBox.Show("Mật khẩu không khớp");
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