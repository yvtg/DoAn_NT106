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
    public partial class Form_Login : Form
    {
        public Form_Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            //Kiểm tra tài khoản đăng nhập
            Form_Home homeform = new Form_Home();
            homeform.StartPosition = FormStartPosition.Manual; // Đặt hiển thị theo tọa độ
            homeform.Location = this.Location; // Đặt vị trí của Form_Home giống với Form_Background
            this.Hide();
            homeform.ShowDialog();
            this.Show();

        }
    }
}
