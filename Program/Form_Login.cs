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
        public Form_Login()
        {
            InitializeComponent();
            this.client = WindowsFormsApp1.Program.client;
            client.LoginSuccessful += OnLoginSuccessful;
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

            try
            {
                // Gửi thông tin đăng nhập lên server
                LoginPacket packet = new LoginPacket($"{username};{password}");
                client.SendData(packet);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gửi thông tin đăng nhập: {ex.Message}");
            }
        }
        private void OnLoginSuccessful()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(OnLoginSuccessful));
                return;
            }

            string username = usernameTextbox.Text;
            Form_Home homeForm = new Form_Home(username);
            homeForm.StartPosition = FormStartPosition.Manual; // Đặt hiển thị theo tọa độ
            homeForm.Location = this.Location; // Đặt vị trí của Form_Home giống với Form_Background
            this.Hide();
            homeForm.ShowDialog();
            this.Close();
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

        private void lawBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Law lawForm = new Form_Law();
            lawForm.StartPosition = FormStartPosition.Manual;
            lawForm.Location = this.Location;
            lawForm.ShowDialog();
            this.Close();
        }

        private void regBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Register regForm = new Form_Register();
            regForm.StartPosition = FormStartPosition.Manual;
            regForm.Location = this.Location;
            regForm.ShowDialog();
            this.Close();
        }
    }
}