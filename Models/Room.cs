using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Timers;

namespace Models
{
    public class Room
    {
        // Thuộc tính
        public string RoomId; // ID của phòng gồm 4 ký tự số và chữ in hoa
        public List<User> players;  // Danh sách người chơi trong phòng
        public string currentKeyword; // Từ khóa hiện tại
        public int roundTime = 60; // Thời gian của mỗi vòng chơi (tính bằng giây)
        public System.Timers.Timer roundTimer; // Timer đếm ngược cho mỗi vòng chơi
        public bool roomActive = false; // Trạng thái phòng (đang hoạt động hay không)
        public bool IsGameStarted = false; // Trạng thái vòng chơi (đang diễn ra hay không)
        public int maxPlayers; // Số lượng người chơi tối đa trong phòng
        public Random random;
        public User host; // chủ phòng

        public User currentDrawer; // Người chơi hiện đang vẽ
        public int currentDrawerIndex; // Vị trí của người vẽ hiện tại trong danh sách người chơi


        public Room(string RoomId, int maxPlayers)
        {
            players = new List<User>();
            random = new Random();
            currentDrawerIndex = -1;
            this.RoomId = RoomId;
            this.maxPlayers = maxPlayers;
            roomActive = true;
            // Cài đặt bộ đếm thời gian cho vòng chơi (60 giây)
            roundTimer = new System.Timers.Timer(roundTime * 1000);
            roundTimer.Elapsed += OnRoundTimeElapsed;
            roundTimer.AutoReset = false;
        }

        // Bắt đầu vòng chơi mới
        public void StartNewRound()
        {
            IsGameStarted = true;
            // Dừng bộ đếm thời gian hiện tại (nếu có)
            roundTimer.Stop();

            if (players.Count > 2)
            {
                currentDrawerIndex = (currentDrawerIndex + 1) % players.Count;
                currentDrawer = players[currentDrawerIndex];
                currentDrawer.IsDrawing = true;

                currentKeyword = GenerateRandomKeyword();

                BroadcastNewRoundInfo();

                roundTimer.Start();
            }
        }

        // Sự kiện khi hết thời gian của vòng chơi
        public void OnRoundTimeElapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Time is up! Moving to the next round.");
            StartNewRound();
        }


        // Sinh từ khóa ngẫu nhiên từ file Keywords.txt
        public string GenerateRandomKeyword()
        {
            List<string> keywords = new List<string>();
            string filePath = "Server/Keyword.txt";

            if (File.Exists(filePath))
            {
                keywords.AddRange(File.ReadAllLines(filePath));
            }
            else
            {
                Console.WriteLine("File Keyword.txt không tồn tại.");
                return "default";
            }

            if (keywords.Count == 0)
            {
                Console.WriteLine("File Keyword.txt không có từ khóa nào.");
                return "default";
            }

            return keywords[random.Next(keywords.Count)];
        }

        // Kiểm tra đáp án của người chơi
        public bool CheckAnswer(string guess, User player)
        {
            if (guess.Equals(currentKeyword, StringComparison.OrdinalIgnoreCase))
            {

                player.Score += 10;
                if (currentDrawer != null)
                {
                    currentDrawer.Score += 5;
                }

                BroadcastMessage($"{player.Name} đã đoán đúng từ khóa và nhận được 10 điểm! và {currentDrawer.Name} được cộng 5 điểm!");

                roundTimer.Stop();

                StartNewRound();
                return true;
            }
            return false;
        }

        // Gửi tin nhắn đến tất cả người chơi trong phòng
        public void BroadcastMessage(string message)
        {
            string roundInfo = $"Người vẽ hiện tại: {currentDrawer.Name}, Từ khóa: {currentKeyword}";
            foreach (var player in players)
            {
                Packet newRoundPacket = new DescribePacket($"{RoomId};System;{roundInfo}");
                player.SendPacket(newRoundPacket);
            }
        }

        // Gửi thông tin vòng chơi mới
        public void BroadcastNewRoundInfo()
        {
            string roundInfo = $"Người vẽ hiện tại: {currentDrawer.Name}, Từ khóa: {currentKeyword}";
            foreach (var player in players)
            {
                Packet newRoundPacket = new DescribePacket($"{RoomId};System;{roundInfo}");
                player.SendPacket(newRoundPacket);
            }
        }

        // Lấy danh sách điểm của các người chơi dưới dạng chuỗi
        public string GetScores()
        {
            List<string> scores = new List<string>();
            foreach (var player in players)
            {
                scores.Add($"{player.Name}: {player.Score}");
            }
            return string.Join(", ", scores);
        }
    }
}
