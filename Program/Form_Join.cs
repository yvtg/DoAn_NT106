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
            this.username = username;
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
                MessageBox.Show("Vui lòng nhập mã phòng.");
                return;
            }

            JoinRoomPacket joinRoomPacket = new JoinRoomPacket($"{roomId};{username}");
            client.SendPacket(joinRoomPacket);
            this.Close();
        }

        private void idTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                joinButton_Click(sender, e);
                e.Handled = true; e.SuppressKeyPress = true;
            }    
        }
    }
}
