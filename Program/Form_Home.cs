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
        private Form_Create createForm;
        private Form_Join joinForm;

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

        private async void profileButton_Click_1(object sender, EventArgs e)
        {
            ProfileRequest profile = new ProfileRequest(username);
            await client.SendPacket(profile);
        }

        private async void logoutBtn_Click_1(object sender, EventArgs e)
        {
            LogoutPacket logoutPacket = new LogoutPacket(username);
            await client.SendPacket(logoutPacket);
            Application.Exit();
        }
        private void createButton_Click(object sender, EventArgs e)
        {
            if (createForm != null && !createForm.IsDisposed)
            {
                createForm.BringToFront(); 
                return;
            }

            createForm = new Form_Create(username);
            createForm.StartPosition = FormStartPosition.Manual;

            CenterChildForm(createForm);
            createForm.FormClosed += (s, args) => { createForm = null; };

            createForm.Show();
        }

        private void joinButton_Click_1(object sender, EventArgs e)
        {
            if (joinForm != null && !joinForm.IsDisposed)
            {
                joinForm.BringToFront(); // Nếu form đã mở, đưa lên trước
                return;
            }
            joinForm = new Form_Join(username);
            joinForm.StartPosition = FormStartPosition.Manual;

            CenterChildForm(joinForm);
            joinForm.FormClosed += (s, args) => { joinForm = null; }; // Xóa tham chiếu khi form đóng
            joinForm.Show();
        }

        private void CenterChildForm(Form childForm)
        {
            int centerX = this.Left + (this.Width - childForm.Width) / 2;
            int centerY = this.Top + (this.Height - childForm.Height) / 2;
            childForm.Location = new Point(centerX, centerY);
        }

        private void OnReceiveRoomInfo(string roomId, string host, int maxPlayers, bool isblindround)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => OnReceiveRoomInfo(roomId, host, maxPlayers, isblindround)));
                return;
            }

            this.Hide();
            Form_Room formRoom = new Form_Room(roomId, host, maxPlayers, username, isblindround);
            formRoom.StartPosition = FormStartPosition.Manual;
            formRoom.Location = this.Location;
            formRoom.Show();
            formRoom.FormClosed += (s, args) =>
            {
                this.Show();
            };

            //// Kiểm tra nếu Form_Room đã tồn tại
            //if (Form_Manager.RoomForm != null && !Form_Manager.RoomForm.IsDisposed)
            //{
            //    Form_Manager.RoomForm.Focus(); 
            //    return;
            //}
            //Form_Manager.HomeForm?.Hide();

            //Form_Manager.RoomForm = new Form_Room(roomId, host, maxPlayers, username);
            //Form_Manager.RoomForm.StartPosition = FormStartPosition.Manual;
            //Form_Manager.RoomForm.Location = Form_Manager.HomeForm?.Location ?? this.Location;
            //Form_Manager.RoomForm.Show();

            //Form_Manager.RoomForm.LeaveRoom += () =>
            //{
            //    this.Show();
            //};

            //// Khi Form_Room đóng
            //Form_Manager.RoomForm.FormClosed += (s, args) =>
            //{
            //    Form_Manager.RoomForm = null; 
            //    Form_Manager.HomeForm?.Show(); 
            //};

            //Form_Manager.RoomForm.FormClosing += (s, args) =>
            //{
            //    if (this != null && !this.IsDisposed)
            //        this.Show();
            //};
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
            data.email = packet.data1.email;
            data.highestscore = packet.data1.highestscore;
            data.gamesplayed = packet.data1.gamesplayed;

            Form_Profile profileform = new Form_Profile(data);
            profileform.StartPosition = FormStartPosition.Manual;
            profileform.Location = this.Location;
            this.Hide();
            profileform.Show();
            profileform.FormClosed += (s, args) =>
            {
                this.Show();
            };
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

        private void Form_Home_Load(object sender, EventArgs e)
        {
            this.LocationChanged += (s, args) =>
            {
                if (createForm != null && !createForm.IsDisposed)
                {
                    CenterChildForm(createForm);
                }
                if (joinForm != null && !joinForm.IsDisposed)
                {
                    CenterChildForm(joinForm);
                }
            };
        }
    }
}