using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;

namespace Program
{
    public partial class Form_Create : Form
    {
        private Client client;
        private string username;
        public Form_Create(Client client, string username)
        {
            InitializeComponent();
            this.client = client;
            this.username = username;
            Client.ReceiveRoomInfo += OnReceiveRoomInfo;

            numeric.MinNum = 1;
            numeric.MaxNum = 5;
            numeric.ValueNumber = 2;

        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int maxPlayers = (int)numeric.ValueNumber;
                CreateRoomPacket createRoomPacket = new CreateRoomPacket($"{username};{maxPlayers}");
                client.SendData(createRoomPacket);
            }
            catch (Exception ex)
            {
                // Log the exception for further investigation
                Console.WriteLine(ex.Message);
                MessageBox.Show("An error occurred while creating the room.");
            }

        }

        private void OnReceiveRoomInfo(string roomId, string host, int MaxPlayers)
        {
            MessageBox.Show($"Room Info: {roomId} {host} {MaxPlayers}");
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    Form_Room roomForm = new Form_Room(client, roomId, username, MaxPlayers);
                    roomForm.Show();
                    this.Hide();
                }));
            }
            else
            {
                Form_Room roomForm = new Form_Room(client, roomId, username, MaxPlayers);
                roomForm.Show();
                this.Hide();
            }
        }

    }
}
