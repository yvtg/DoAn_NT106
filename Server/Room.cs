using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Timers;

namespace Server
{
    public class Room
    {
        // Thuộc tính
        public string RoomId; // ID của phòng gồm 4 ký tự số và chữ in hoa
        public List<User> players;  // Danh sách người chơi trong phòng
        public User currentDrawer; // Người chơi hiện đang vẽ
        public string currentKeyword; // Từ khóa hiện tại
        public int roundTime = 60; // Thời gian của mỗi vòng chơi (tính bằng giây)
        public Timer roundTimer; // Timer đếm ngược cho mỗi vòng chơi
        public bool gameActive = false; // Trạng thái game
        public int maxPlayers; // Số lượng người chơi tối đa trong phòng
        public Random random;
        public int currentDrawerIndex; // Vị trí của người vẽ hiện tại trong danh sách người chơi

        private string GenerateRoomId()
        {
            int length = 4; // Độ dài mã phòng
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"; // Các ký tự cho mã phòng
            Random random = new Random();
            char[] RoomID = new char[length];

            for (int i = 0; i < length; i++)
            {
                RoomID[i] = chars[random.Next(chars.Length)];
            }

            return new string(RoomID);
        }

        public Room()
        {
            players = new List<User>();
            random = new Random();
            currentDrawerIndex = -1;
            RoomId = GenerateRoomId();

            // Cài đặt bộ đếm thời gian cho vòng chơi (60 giây)
            roundTimer = new Timer(roundTime * 1000); // roundTime * 1000 ms = 60 seconds
            roundTimer.Elapsed += OnRoundTimeElapsed;
            roundTimer.AutoReset = false;
        }

        // Bắt đầu vòng chơi mới
        public void StartNewRound()
        {
            // Dừng bộ đếm thời gian hiện tại (nếu có)
            roundTimer.Stop();

            if (players.Count > 2)
            {
                // Chọn người vẽ tiếp theo trong danh sách
                currentDrawerIndex = (currentDrawerIndex + 1) % players.Count;
                currentDrawer = players[currentDrawerIndex];
                currentDrawer.IsDrawing = true;

                // Chọn từ khóa ngẫu nhiên cho người vẽ
                currentKeyword = GenerateRandomKeyword();

                // Gửi thông tin vòng chơi mới
                BroadcastNewRoundInfo();

                // Bắt đầu bộ đếm thời gian cho vòng chơi
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
                // Nếu đoán đúng, cập nhật điểm cho người đoán và người vẽ
                player.Score += 10;
                if (currentDrawer != null)
                {
                    currentDrawer.Score += 5;
                }

                // Cập nhật trạng thái game cho tất cả người chơi
                BroadcastMessage($"{player.Name} đã đoán đúng từ khóa và nhận được 10 điểm! và {currentDrawer.Name} được cộng 5 điểm!");

                // Dừng vòng chơi hiện tại và bắt đầu vòng chơi mới
                roundTimer.Stop();
                StartNewRound();

                return true;
            }
            return false;
        }

        // Gửi tin nhắn đến tất cả người chơi trong phòng
        public void BroadcastMessage(string message)
        {
            // cần xây dựng class Packet trước
        }

        // Gửi thông tin vòng chơi mới
        public void BroadcastNewRoundInfo()
        {
            // cần xây dựng class Packet trước
        }

        // Gửi tin nhắn đến tất cả người chơi trong phòng

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
