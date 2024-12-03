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
        public Form_Law()
        {
            this.client = WindowsFormsApp1.Program.client;
            InitializeComponent();
        }

        private void backButton_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form_Login LoginForm = new Form_Login();
            LoginForm.StartPosition = FormStartPosition.Manual;
            LoginForm.Location = this.Location;
            LoginForm.ShowDialog();
            this.Close();
        }
    }
}
