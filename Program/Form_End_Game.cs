using Models;
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
    public partial class Form_End_Game : Form
    {
        string username;
        Client client;
        public Form_End_Game(string username)
        {
            InitializeComponent();
            this.username = username;
            this.client = Form_Input_ServerIP.client;
        }

        private void Form_End_Game_Load(object sender, EventArgs e)
        {

        }

        private void homeButton_Click(object sender, EventArgs e)
        {

        }

        private void profileButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProfileRequest profile = new ProfileRequest(username);
            client.SendPacket(profile);
            this.Show();
            FormClosed += (s, args) => this.Close();
        }

        private void homeButton_Click_1(object sender, EventArgs e)
        {

        }
    }
}
