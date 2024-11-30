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
        public Form_Join(Client client, string username)
        {
            this.client = client;
            this.username = username;
            Client.ReceiveRoomInfo += OnReceiveRoomInfo;
            InitializeComponent();
        }

        private void backButton_Click_1(object sender, EventArgs e)
        {
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
            Form_Room roomform = new Form_Room(client, roomId, username, MaxPlayers);
            roomform.StartPosition = FormStartPosition.Manual; // Đặt hiển thị theo tọa độ
            roomform.Location = this.Location; // Đặt vị trí của Form_Room giống với Form_Background
            this.Hide();
            roomform.ShowDialog();
        }
    }
}
