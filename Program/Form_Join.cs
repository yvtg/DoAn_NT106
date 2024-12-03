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
    public partial class Form_Join : Form
    {
        private Client client;
        private string username;
        public Form_Join(string username)
        {
            this.client = WindowsFormsApp1.Program.client;
            this.username = username;
            client.ReceiveRoomInfo += OnReceiveRoomInfo;
            InitializeComponent();
        }

        private void backButton_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form_Home homeForm = new Form_Home(username);
            homeForm.StartPosition = FormStartPosition.Manual;
            homeForm.Location = this.Location;
            homeForm.ShowDialog();
            this.Close();
        }

        private void joinButton_Click(object sender, EventArgs e)
        {
            string roomId = idTextbox.Text;
            if (roomId == "")
            {
                MessageBox.Show("Please enter the room ID.");
                return;
            }

            JoinRoomPacket joinRoomPacket = new JoinRoomPacket($"{username};{roomId}");
            client.SendData(joinRoomPacket);
        }

        private void OnReceiveRoomInfo(string roomId, string host, int MaxPlayers)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => OnReceiveRoomInfo(roomId, host, MaxPlayers)));
                return;
            }

            MessageBox.Show($"Room Info: {roomId} {host} {MaxPlayers}");
            this.Hide();

            Form_Room roomForm = new Form_Room(roomId, username, 4);
            roomForm.StartPosition = FormStartPosition.Manual;
            roomForm.Location = this.Location;
            roomForm.ShowDialog();
            this.Close();
        }
    }
}
