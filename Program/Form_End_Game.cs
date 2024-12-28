using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program
{
    public partial class Form_End_Game : Form
    {
        string username;
        Client client;
        int score;
        Dictionary<string, (string name, int score, int textcore)> playerScores = new Dictionary<string, (string, int, int)>();
        public Form_End_Game(string username, int score, Dictionary<string, (string name, int score, int textcore)> playerScores)
        {
            InitializeComponent();
            this.username = username;
            this.score = score;
            this.playerScores = playerScores;
            this.client = Form_Input_ServerIP.client;
            //client.ServerDisconnected += () =>
            //{
            //    if (this.InvokeRequired)
            //    {
            //        this.Invoke(new Action(() =>
            //        {
            //            this.Close(); // Đóng form trên luồng UI
            //        }));
            //    }
            //    else
            //    {
            //        this.Close();
            //    }
            //};

            // xếp hạng người chơi
            DisplayPlayerRanks();
        }

        private void DisplayPlayerRanks()
        {
            var sortedPlayers = playerScores.OrderByDescending(p => p.Value.score); // Sắp xếp theo điểm số giảm dần
            int previousScore = -1; // Giá trị điểm số trước đó (khởi tạo bằng giá trị không hợp lệ)
            int buttonIndex = 1; // Chỉ số để gán vào các nút
            top3Button.Visible = false;
            hopeRoundButton3.Visible = false;

            foreach (var player in sortedPlayers)
            {
                // Kiểm tra nếu điểm số của người chơi hiện tại khác với điểm số trước đó
                if (player.Value.score != previousScore)
                {
                    previousScore = player.Value.score; // Cập nhật điểm số trước đó
                }

                // Gán tên người chơi vào button tương ứng
                if (buttonIndex == 1)
                    top1Button.Text = player.Value.name;
                else if (buttonIndex == 2)
                    top2Button.Text = player.Value.name;
                else if (buttonIndex == 3)
                {
                    top3Button.Text = player.Value.name;
                    // Hiển thị nếu có hơn 3 người chơi
                    top3Button.Visible = true;
                    hopeRoundButton3.Visible = true;
                }

                buttonIndex++; // Tăng chỉ số cho button

                // Ngừng gán nếu đã đủ 3 người chơi
                if (buttonIndex > 3) break;
            }

            // Cập nhật điểm cao nhất và số lượt chơi của người chơi hiện tại
            ProfileUpdatePacket profileUpdatePacket = new ProfileUpdatePacket($"{username};{score}");
            client.SendPacket(profileUpdatePacket);
        }


        private void Returnbutton_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
