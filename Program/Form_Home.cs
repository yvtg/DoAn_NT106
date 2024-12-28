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
            Application.Exit();
        }
        private void createButton_Click(object sender, EventArgs e)
        {
            Form_Create createform = new Form_Create(username);
            createform.StartPosition = FormStartPosition.Manual;
            int centerX = this.Location.X + (this.Width - createform.Width) / 2;
            int centerY = this.Location.Y + (this.Height - createform.Height) / 2;
            createform.Location = new Point(centerY, centerY);
            createform.Show();
        }

        private void joinButton_Click_1(object sender, EventArgs e)
        {
            Form_Join joinform = new Form_Join(username);
            joinform.StartPosition = FormStartPosition.Manual;
            int centerX = this.Location.X + (this.Width - joinform.Width) / 2;
            int centerY = this.Location.Y + (this.Height - joinform.Height) / 2;
            joinform.Location = new Point(centerY, centerY);
            joinform.Show();
        }

        private void OnReceiveRoomInfo(string roomId, string host, int maxPlayers)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => OnReceiveRoomInfo(roomId, host, maxPlayers)));
                return;
            }

            this.Hide();
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

            Form_Manager.RoomForm.FormClosing += (s, args) =>
            {
                if (this != null && !this.IsDisposed)
                    this.Show();
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

        #region dragging
        private bool dragging = false;
        private Point dragCursor;
        private Point dragForm;
        private void Home_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = true;
                dragCursor = Cursor.Position;
                dragForm = this.Location;
            }
        }

        private void Home_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point delta = new Point(Cursor.Position.X - dragCursor.X, Cursor.Position.Y - dragCursor.Y);
                this.Location = new Point(dragForm.X + delta.X, dragForm.Y + delta.Y);
            }
        }

        private void Home_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
        #endregion
    }
}