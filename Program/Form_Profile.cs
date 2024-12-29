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
    public partial class Form_Profile : Form
    {
        ProfileData data = new ProfileData();
        private Client client;
        public Form_Profile(ProfileData username)
        {
            InitializeComponent();
            this.client = Form_Input_ServerIP.client;
            client.ServerDisconnected += () =>
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        this.Close(); // Đóng form trên luồng UI
                    }));
                }
                else
                {
                    this.Close();
                }
            };
            usernameTextbox.Text = username.username;
            emailTextBox.Text = username.email;
            maxscoreTextbox.Text = username.highestscore.ToString();
            countTextbox.Text = username.gamesplayed.ToString();
        }
        #region UI
        private void backButton_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
