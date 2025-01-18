using Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Numerics;
using System.Timers;

namespace Models
{
    public class Room
    {
        // Thuộc tính
        public string RoomId; // ID của phòng gồm 4 ký tự số và chữ in hoa
        public List<User> players;  // Danh sách người chơi trong phòng
        public string currentKeyword; // Từ khóa hiện tại
        public string status; // waiting, playing, finished
        public bool IsGameStarted = false; // Trạng thái vòng chơi (đang diễn ra hay không)
        public int maxPlayers; // Số lượng người chơi tối đa trong phòng
        public Random random;
        public string host;
        public int currentRound;
        public bool isblindround;

        public User? currentDrawer; // Người chơi hiện đang vẽ
        public int currentDrawerIndex; // Vị trí của người vẽ hiện tại trong danh sách người chơi


        public Room(string RoomId, string host, int maxPlayers, User player)
        {
            players = new List<User>();
            random = new Random();
            currentDrawerIndex = -1;
            this.RoomId = RoomId;
            this.maxPlayers = maxPlayers;
            this.status = "WAITING";
            this.host = host;
            this.currentKeyword = "";
            currentDrawer = player;
            currentRound = 0;
            isblindround = false;
        }

        // reset lai phong choi
        public void Clear()
        {
            currentDrawerIndex = -1;
            currentDrawer = null;
            currentKeyword = "";
            status = "WAITING";
            IsGameStarted = false;
        }

        // Bắt đầu vòng chơi mới
        public void StartNewRound()
        {
            IsGameStarted = true;
            // Dừng bộ đếm thời gian hiện tại (nếu có)

            currentDrawerIndex = (currentDrawerIndex + 1) % players.Count;
            currentDrawer = players[currentDrawerIndex];
            currentDrawer.IsDrawing = true;

            currentKeyword = GenerateRandomKeyword();


        }


        // Sinh từ khóa ngẫu nhiên từ file Keywords.txt
        public string GenerateRandomKeyword()
        {
            List<string> keywords = new List<string>();

            // Lấy thư mục gốc của ứng dụng
            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Lấy đường dẫn tuyệt đối của file Keyword.txt
            string filePath = Path.Combine(projectDirectory, @"..\..\Models\Keyword.txt");

            // Chuyển đường dẫn từ "..\.." thành đường dẫn tuyệt đối
            filePath = Path.GetFullPath(filePath);

            // Loại bỏ phần "Server" trong đường dẫn
            filePath = filePath.Replace(@"\Server", "");

            keywords.AddRange(File.ReadAllLines(filePath));

            if (keywords.Count == 0)
            {
                Console.WriteLine("File Keyword.txt không có từ khóa nào.");
                return "default2";
            }

            return keywords[random.Next(keywords.Count)];
        }

        // Kiểm tra đáp án của người chơi
        public bool CheckAnswer(string guess, User player)
        {
            if (guess.Equals(currentKeyword, StringComparison.OrdinalIgnoreCase) && IsGameStarted)
            {
                player.Score += 10;
                return true;
            }
            return false;
        }

    }
}