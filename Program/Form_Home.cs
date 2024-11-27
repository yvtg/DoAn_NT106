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
    public partial class Form_Home : Form
    {
        private Client client;
        private string username;
        public Form_Home(Client client, string username)
        {
            InitializeComponent();
            this.client = client;
            this.username = username;
        }

        private void joinButton_Click(object sender, EventArgs e)
        {
            Form_Join joinform = new Form_Join();
            joinform.StartPosition = FormStartPosition.Manual; // Đặt hiển thị theo tọa độ
            joinform.Location = this.Location; // Đặt vị trí của Form_Join giống với Form_Background
            joinform.ShowDialog();
        }

        private void profileButton_Click(object sender, EventArgs e)
        {
            Form_Profile profileform = new Form_Profile();
            profileform.StartPosition = FormStartPosition.Manual; // Đặt hiển thị theo tọa độ
            profileform.Location = this.Location; // Đặt vị trí của Form_Profile giống với Form_Background
            this.Hide();
            profileform.ShowDialog();
            this.Show();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            LogoutPacket logoutPacket = new LogoutPacket(username);
            client.SendData(logoutPacket);

            Form_Background backgroundform = new Form_Background(client);
            backgroundform.StartPosition = FormStartPosition.Manual; // Đặt hiển thị theo tọa độ
            backgroundform.Location = this.Location; // Đặt vị trí của Form_Background giống với Form_Home
            this.Hide();
            backgroundform.ShowDialog();
            this.Show();
        }
    }
}
