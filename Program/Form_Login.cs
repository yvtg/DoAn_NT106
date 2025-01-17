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
    public partial class Form_Login : Form
    {
        private Client client;
        public Form_Login()
        {
            InitializeComponent();
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
            client.LoginSuccessful += OnLoginSuccessful;
            client.RedirectReceived += RedirectInfo;
        }

        private void RedirectInfo(string ip, int port)
        {
            serverLabel.Text = $"Server: {ip}:{port}";
        }

        private async void loginButton_Click_1(object sender, EventArgs e)
        {
            string username = usernameTextbox.Text;
            string password = passTextbox.Text;

            if (username == "" || password == "")
            {
                ShowMessage("Vui lòng nhập đầy đủ thông tin");
                return;
            }

            try
            {
                // Gửi thông tin đăng nhập lên server
                LoginPacket packet = new LoginPacket($"{username};{password}");
                await client.SendPacket(packet);
            }
            catch (Exception ex)
            {
                ShowMessage($"Lỗi khi gửi thông tin đăng nhập: {ex.Message}");
            }
        }
        private void showPwCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showPwCheckBox.Checked)
            {
                passTextbox.UseSystemPasswordChar = false; // Hiển thị mật khẩu
            }
            else
            {
                passTextbox.UseSystemPasswordChar = true; // Ẩn mật khẩu
            }
        }

        private void OnLoginSuccessful()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(OnLoginSuccessful));
                return;
            }

            string username = usernameTextbox.Text;

            foreach (Form form in Application.OpenForms)
            {
                if (form is Form_Home)
                {
                    form.Hide(); 
                    break;
                }
            }
            this.Hide();

            Form_Home homeForm = new Form_Home(username);
            homeForm.StartPosition = FormStartPosition.Manual;
            homeForm.Location = this.Location;
            homeForm.Show();

            homeForm.FormClosed += (s, args) => this.Close();
        }



        private void lawBtn_Click(object sender, EventArgs e)
        {
            Form_Law lawForm = new Form_Law();
            this.Hide(); 
            lawForm.StartPosition = FormStartPosition.Manual;
            lawForm.Location = this.Location; // Đặt vị trí của Form_Home giống với Form_Background
            lawForm.Show();
            lawForm.FormClosed += (s, args) => this.Show();
        }


        private void regBtn_Click(object sender, EventArgs e)
        {
            Form_Register regForm = new Form_Register();
            this.Hide();
            regForm.StartPosition = FormStartPosition.Manual;
            regForm.Location = this.Location; // Đặt vị trí của Form_Home giống với Form_Background
            regForm.Show();
            regForm.FormClosed += (s, args) => this.Show();
        }

        private async void Form_Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (client.connectStatus)
            {
                DisconnectPacket disconnectPacket = new DisconnectPacket("");
                await client.SendPacket(disconnectPacket);
            }
            Application.Exit();
        }

        private void forgetLabel_Click(object sender, EventArgs e)
        {
            Form_Forget_Password forgetForm = new Form_Forget_Password();
            this.Hide();
            forgetForm.StartPosition = FormStartPosition.Manual;
            forgetForm.Location = this.Location;
            //forgetForm.FormClosed += (s, args) => this.Show(); // Hiển thị lại Form_Login khi ForgetForm đóng
            forgetForm.Show();
        }

        public void ShowMessage(string messsage)
        {
            Form_Message formmessage = new Form_Message(messsage);
            formmessage.StartPosition = FormStartPosition.Manual;
            int centerX = this.Location.X + (this.Width - formmessage.Width) / 2;
            int centerY = this.Location.Y + (this.Height - formmessage.Height) / 2;
            formmessage.Location = new Point(centerY, centerY);

            formmessage.Show();
        }



        #region dragging

        private bool dragging = false;
        private Point dragCursor;
        private Point dragForm;

        private void login_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = true;
                dragCursor = Cursor.Position;
                dragForm = this.Location;
            }
        }

        private void login_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point delta = new Point(Cursor.Position.X - dragCursor.X, Cursor.Position.Y - dragCursor.Y);
                this.Location = new Point(dragForm.X + delta.X, dragForm.Y + delta.Y);
            }
        }

        private void login_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
        #endregion
    }
}