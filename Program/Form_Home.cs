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
using ReaLTaiizor.Forms;

namespace Program
{
    public partial class Form_Home : Form
    {
        private string username;
        public Form_Home(string username)
        {
            this.username = username;
            InitializeComponent();
        }
        #region ĐIỀU HƯỚNG

        private void profileButton_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form_Profile profileform = new Form_Profile(username);
            profileform.StartPosition = FormStartPosition.Manual;
            profileform.Location = this.Location;
            profileform.ShowDialog();
            this.Show();
            FormClosed += (s, args) => this.Close();
        }

        private void logoutBtn_Click_1(object sender, EventArgs e)
        {
            LogoutPacket logoutPacket = new LogoutPacket(username);
            WindowsFormsApp1.Program.client.SendData(logoutPacket);

            this.Close();
        }
        private void createButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Create createform = new Form_Create(username);
            createform.StartPosition = FormStartPosition.Manual;
            createform.Location = this.Location;
            createform.ShowDialog();
            this.Show();
        }

        private void joinButton_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form_Join joinform = new Form_Join(username);
            joinform.StartPosition = FormStartPosition.Manual;
            joinform.Location = this.Location;
            joinform.ShowDialog();
            this.Show();
        }
        #endregion

    }
}