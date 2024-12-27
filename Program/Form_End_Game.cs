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
        public Form_End_Game(string username, int score)
        {
            InitializeComponent();
            this.username = username;
            this.client = Form_Input_ServerIP.client;
            client.ProfileReceived += OnProfileReceived;

            // cập nhật điểm cao nhất, số lượt chơi của người chơi này
            ProfileUpdatePacket profileUpdatePacket = new ProfileUpdatePacket($"{username};{score}");
            client.SendPacket(profileUpdatePacket);
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

        private void OnProfileReceived(ProfileResultPacket packet)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => OnProfileReceived(packet)));
                return;
            }
            ProfileData data = new ProfileData();
            data.username = packet.data1.username;
            data.highestscore = packet.data1.highestscore;
            data.gamesplayed = packet.data1.gamesplayed;

            Form_Profile profileform = new Form_Profile(data);
            profileform.StartPosition = FormStartPosition.Manual;
            profileform.Location = this.Location;
            this.Hide();
            profileform.ShowDialog();
        }

        private void homeButton_Click_1(object sender, EventArgs e)
        {

        }
    }
}
