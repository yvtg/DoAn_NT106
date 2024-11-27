using Program;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form_Background : Form
    {
        private Client client;
        public Form_Background(Client client)
        {
            InitializeComponent();
            this.client = client;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            Form_Login loginform = new Form_Login(client);
            loginform.StartPosition = FormStartPosition.Manual; // Đặt hiển thị theo tọa độ
            loginform.Location = this.Location; // Đặt vị trí của Form_Login giống với Form_Background
            this.Hide();
            loginform.ShowDialog();
            this.Show();
        }

        private void regButton_Click(object sender, EventArgs e)
        {
            Form_Register registerform = new Form_Register(client);
            registerform.StartPosition = FormStartPosition.Manual; // Đặt hiển thị theo tọa độ
            registerform.Location = this.Location; // Đặt vị trí của Form_Register giống với Form_Background
            this.Hide();
            registerform.ShowDialog();
            this.Show();
        }

        private void lawButton_Click(object sender, EventArgs e)
        {
            Form_Law lawform = new Form_Law();
            lawform.StartPosition = FormStartPosition.Manual; // Đặt hiển thị theo tọa độ
            lawform.Location = this.Location; // Đặt vị trí của Form_Law giống với Form_Background
            this.Hide();
            lawform.ShowDialog();
            this.Show();
        }
    }
}
