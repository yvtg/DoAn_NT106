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
            client.ProfileReceived += OnProfileReceived;

            // cập nhật điểm cao nhất, số lượt chơi của người chơi này
            ProfileUpdatePacket profileUpdatePacket = new ProfileUpdatePacket($"{username};{score}");
            client.SendPacket(profileUpdatePacket);

            // xếp hạng người chơi
            DisplayPlayerRanks();
        }

        private void DisplayPlayerRanks()
        {
            var sortedPlayers = playerScores.OrderByDescending(p => p.Value.score); // Sắp xếp theo điểm số giảm dần
            int rank = 1; // Thứ hạng bắt đầu
            int previousScore = -1; // Giá trị điểm số trước đó (khởi tạo bằng giá trị không hợp lệ)
            rankListbox.Items.Add($"BẢNG XẾP HẠNG");

            foreach (var player in sortedPlayers)
            {
                // Nếu điểm của người chơi hiện tại khác điểm trước đó, cập nhật thứ hạng
                if (player.Value.score != previousScore)
                {
                    rankListbox.Items.Add($"Top {rank}: {player.Value.name} {player.Value.score}");
                    previousScore = player.Value.score; // Cập nhật điểm số trước đó
                }
                else
                {
                    // Nếu điểm số bằng nhau, giữ nguyên thứ hạng
                    rankListbox.Items.Add($"Top {rank}: {player.Value.name} {player.Value.score}");
                }
            }
        }

        private void profileButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProfileRequest profile = new ProfileRequest(username);
            client.SendPacket(profile);
            this.Show();
            FormClosed += (s, args) => this.Close();
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
        }

        private void Returnbutton_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
