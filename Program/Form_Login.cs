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
    public partial class Form_Login : Form
    {
        private Client client;
        public Form_Login(Client client)
        {
            InitializeComponent();
            Client.LoginSuccessful += OnLoginSuccessful;
            this.client = client;
        }

        private void backButton_Click_1(object sender, EventArgs e)
        {
            Form_Background form_Background = new Form_Background(client);
            form_Background.StartPosition = FormStartPosition.Manual; // Đặt hiển thị theo tọa độ
            form_Background.Location = this.Location; // Đặt vị trí của Form_Law giống với Form_Background
            this.Hide();
            form_Background.ShowDialog();
        }

        private void loginButton_Click_1(object sender, EventArgs e)
        {
            string username = usernameTextbox.Text;
            string password = passTextbox.Text;

            if (username == "" || password == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }

            // Gửi thông tin đăng nhập lên server
            LoginPacket packet = new LoginPacket($"{username};{password}");
            client.SendData(packet);
        }
        private void OnLoginSuccessful()
        {
            string username = usernameTextbox.Text;
            Form_Home homeform = new Form_Home(client, username);
            homeform.StartPosition = FormStartPosition.Manual; // Đặt hiển thị theo tọa độ
            homeform.Location = this.Location; // Đặt vị trí của Form_Home giống với Form_Background
            this.Hide();
            homeform.ShowDialog();
        }

        private void showPwCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showPwCheckBox.Checked)
            {
                passTextbox.PasswordChar = '\0'; // Hiển thị mật khẩu
            }
            else
            {
                passTextbox.PasswordChar = '*'; // Ẩn mật khẩu
            }
        }
    }
}
