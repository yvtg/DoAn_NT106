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
using ReaLTaiizor.Forms;

namespace Program
{
    public partial class Form_Create : Form
    {
        private string username;
        private Client client;
        public Form_Create(string username)
        {
            InitializeComponent();
            this.client = WindowsFormsApp1.Program.client;
            client.ReceiveRoomInfo += OnReceiveRoomInfo;
            this.username = username;
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int maxPlayers = (int)numeric.ValueNumber;
                CreateRoomPacket createRoomPacket = new CreateRoomPacket($"{username};{maxPlayers}");
                WindowsFormsApp1.Program.client.SendData(createRoomPacket);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while creating the room.");
            }

        }

        private void OnReceiveRoomInfo(string roomId, string host, int maxPlayers)
        {
            this.Invoke((MethodInvoker)(()=>
            {
                //this.Hide();
                //MessageBox.Show($"Room Info: {roomId} {username} {maxPlayers}");
                //Form_Room roomForm = new Form_Room(roomId, username, maxPlayers);
                //roomForm.StartPosition = FormStartPosition.Manual;
                //roomForm.Location = this.Location;
                //roomForm.ShowDialog();
                //this.Close();
                MessageBox.Show("Room created successfully.");
            }
            ));
        }



        private void Form_Create_Load(object sender, EventArgs e)
        {
            numeric.MinNum = 1;
            numeric.MaxNum = 5;
            numeric.ValueNumber = 2;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Home homeForm = new Form_Home(username);
            homeForm.StartPosition = FormStartPosition.Manual;
            homeForm.Location = this.Location;
            homeForm.ShowDialog();
            this.Close();
        }
    }
}
