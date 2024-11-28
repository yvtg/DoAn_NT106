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

namespace Program
{
    public partial class Form_Register : Form
    {
        private Client client;
        public Form_Register(Client client)
        {
            InitializeComponent();
            Client.RegisterSuccessful += OnRegisterSuccessful;

            this.client = client;
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
            client.SendData(packet);
        }

        private void OnRegisterSuccessful()
        {
            Form_Background form_Background = new Form_Background(client);
            form_Background.StartPosition = FormStartPosition.Manual; // Đặt hiển thị theo tọa độ
            form_Background.Location = this.Location; // Đặt vị trí của Form_Law giống với Form_Background
            this.Hide();
            form_Background.ShowDialog();
        }

        private void backButton_Click_1(object sender, EventArgs e)
        {
            Form_Background form_Background = new Form_Background(client);
            form_Background.StartPosition = FormStartPosition.Manual; // Đặt hiển thị theo tọa độ
            form_Background.Location = this.Location; // Đặt vị trí của Form_Law giống với Form_Background
            this.Hide();
            form_Background.ShowDialog();
        }
    }
}
