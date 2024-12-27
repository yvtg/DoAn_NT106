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
        private Client client;
        public Form_Home(string username)
        {
            InitializeComponent();
            this.username = username;
            this.client = Form_Input_ServerIP.client;
            client.ReceiveRoomInfo += OnReceiveRoomInfo;
            client.ProfileReceived += OnProfileReceived;
        }

        #region ĐIỀU HƯỚNG

        private void profileButton_Click_1(object sender, EventArgs e)
        {
            ProfileRequest profile = new ProfileRequest(username);
            client.SendPacket(profile);
        }

        private void logoutBtn_Click_1(object sender, EventArgs e)
        {
            LogoutPacket logoutPacket = new LogoutPacket(username);
            client.SendPacket(logoutPacket);
            this.Close();
        
        }
        private void createButton_Click(object sender, EventArgs e)
        {
            Form_Create createform = new Form_Create(username);
            createform.ShowDialog();
        }

        private void joinButton_Click_1(object sender, EventArgs e)
        {
            Form_Join joinform = new Form_Join(username);
            joinform.ShowDialog();
        }

        private void OnReceiveRoomInfo(string roomId, string host, int maxPlayers)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => OnReceiveRoomInfo(roomId, host, maxPlayers)));
                return;
            }

            // Kiểm tra nếu Form_Room đã tồn tại
            if (Form_Manager.RoomForm != null && !Form_Manager.RoomForm.IsDisposed)
            {
                Form_Manager.RoomForm.Focus(); 
                return;
            }

            Form_Manager.HomeForm?.Hide();

            Form_Manager.RoomForm = new Form_Room(roomId, host, maxPlayers, username);
            Form_Manager.RoomForm.StartPosition = FormStartPosition.Manual;
            Form_Manager.RoomForm.Location = Form_Manager.HomeForm?.Location ?? new Point(100, 100);
            Form_Manager.RoomForm.Show();

            // Khi Form_Room đóng
            Form_Manager.RoomForm.FormClosed += (s, args) =>
            {
                Form_Manager.RoomForm = null; 
                Form_Manager.HomeForm?.Show(); 
            };
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
            this.Show();
        }
        #endregion

    }
}