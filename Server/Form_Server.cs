using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Form_Server : Form
    {
        private Server server;
        private bool isServerStopping = false;

        public Form_Server()
        {
            InitializeComponent();
            InitializeClientList();
            InitializeRoomList();
            
            server = new Server();
            server.UpdateLog += UpdateLog;
            server.UpdateClientList += UpdateClientListView;
            server.UpdateRoomList += UpdateRoomListView;
            
        }

        private void UpdateLog(string message)
        {
            if (logRichTextBox.InvokeRequired)
            {
                logRichTextBox.Invoke(new Action(() => UpdateLog(message)));
            }
            else
            {
                logRichTextBox.AppendText($"{DateTime.Now}: {message}\r\n");
                logRichTextBox.SelectionStart = logRichTextBox.Text.Length; // Scroll to the bottom
                logRichTextBox.ScrollToCaret();
            }
        }

        private void InitializeClientList()
        {
            clientListView.View = View.Details;
            clientListView.FullRowSelect = true;
            clientListView.GridLines = true;

            // Thêm các cột vào ListView
            clientListView.Columns.Add("username", 95);
            clientListView.Columns.Add("room", 95);
        }

        private void InitializeRoomList()
        {
            roomListView.View = View.Details;
            roomListView.FullRowSelect = true;
            roomListView.GridLines = true;

            // Thêm các cột vào ListView
            roomListView.Columns.Add("Room ID", 85);
            roomListView.Columns.Add("Host", 85);
            roomListView.Columns.Add("Status", 85);
            roomListView.Columns.Add("Current Players", 85);
            roomListView.Columns.Add("Max Players", 85);
        }


        private void startBtn_Click(object sender, EventArgs e)
        {
            isServerStopping = false;
            server.StartServer();
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            server.StopServer();
        }

        private void Form_Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Nếu server đã dừng hoặc đang dừng, không thực hiện gì thêm
            if (isServerStopping)
            {
                return;
            }

            // Đánh dấu server đang dừng
            isServerStopping = true;

            // Dừng server
            server.StopServer();

            base.OnFormClosing(e);

        }

        #region LIST VIEW
        private void UpdateClientListView()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => UpdateClientListView()));
            }
            else
            {
                clientListView.Items.Clear();
                foreach (var client in server.clients)
                {
                    ListViewItem item = new ListViewItem(client.Name);
                    item.SubItems.Add(client.RoomId);
                    clientListView.Items.Add(item);
                }
            }
        }

        private void UpdateRoomListView()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => UpdateRoomListView()));
            }
            else
            {
                roomListView.Items.Clear();
                foreach (var room in server.rooms)
                {
                    ListViewItem item = new ListViewItem(room.RoomId);
                    item.SubItems.Add(room.host);
                    item.SubItems.Add(room.status);
                    item.SubItems.Add(room.players.Count.ToString());
                    item.SubItems.Add(room.maxPlayers.ToString());
                    roomListView.Items.Add(item);
                }
            }
        }
        #endregion

    }
}
