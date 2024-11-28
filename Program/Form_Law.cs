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
    public partial class Form_Law : Form
    {
        private Client client;
        public Form_Law(Client client)
        {
            InitializeComponent();
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
    }
}
