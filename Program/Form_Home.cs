﻿using System;
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
        }
        #region ĐIỀU HƯỚNG

        private void profileButton_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            ProfileRequest profile = new ProfileRequest(username);
            client.SendPacket(profile);
            this.Show();
            FormClosed += (s, args) => this.Close();
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
                this.Invoke(new Action(()=>OnReceiveRoomInfo(roomId,host,maxPlayers)));
                return;
            }
            Form_Room roomForm = new Form_Room(roomId, host, maxPlayers,username);
            roomForm.StartPosition = FormStartPosition.Manual;
            roomForm.Location = this.Location;
            roomForm.Show();
            this.Hide();
            roomForm.FormClosed += (s, args) => this.Show();
        }
        #endregion

    }
}