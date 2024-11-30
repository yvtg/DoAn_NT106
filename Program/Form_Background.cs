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
            this.client = client;
            InitializeComponent();
        }

        private void logButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Login loginform = new Form_Login(client);
            loginform.StartPosition = FormStartPosition.Manual; // Đặt hiển thị theo tọa độ
            loginform.Location = this.Location; // Đặt vị trí của Form_Login giống với Form_Background
            loginform.Closed += (s, args) => this.Close();
            loginform.Show();

        }

        private void regButton_Click(object sender, EventArgs e)
        {
            Form_Register registerform = new Form_Register(client);
            registerform.StartPosition = FormStartPosition.Manual; // Đặt hiển thị theo tọa độ
            registerform.Location = this.Location; // Đặt vị trí của Form_Register giống với Form_Background
            registerform.Show();
            this.Hide();
        }

        private void lawButton_Click_1(object sender, EventArgs e)
        {
            Form_Law lawform = new Form_Law(client);
            lawform.StartPosition = FormStartPosition.Manual; // Đặt hiển thị theo tọa độ
            lawform.Location = this.Location; // Đặt vị trí của Form_Law giống với Form_Background
            lawform.Show();
            this.Hide();
        }
    }
}
