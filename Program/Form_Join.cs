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
    public partial class Form_Join : Form
    {
        public Form_Join()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void joinButton_Click(object sender, EventArgs e)
        {
            Form_Room roomform = new Form_Room();
            roomform.StartPosition = FormStartPosition.Manual; // Đặt hiển thị theo tọa độ
            roomform.Location = this.Location; // Đặt vị trí của Form_Room giống với Form_Background
            this.Hide();
            roomform.ShowDialog();
            this.Show();
        }
    }
}
