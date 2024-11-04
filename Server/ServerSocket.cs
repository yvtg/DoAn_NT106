using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using Server;

namespace ServerApp
{
    public class ServerSocket
    {
        public static Socket serverSocket;
        public static List<Player> connectedPlayers = new List<Player>();
        public List<Room> rooms = new List<Room>();
        public Action<string> UpdateLog; // Delegate để cập nhật log trên UI

        public ServerSocket(Action<string> updateLog)
        {
            UpdateLog = updateLog;
            Thread serverThread = new Thread(initializeServer) { IsBackground = true };
            serverThread.Start();
        }

        private void initializeServer()
        {
            try
            {
                const string SERVER_IPADDRESS = "127.0.0.1";
                const int SERVER_PORT = 11000;
                IPAddress ipAddr = IPAddress.Parse(SERVER_IPADDRESS);
                IPEndPoint ipEP = new IPEndPoint(ipAddr, SERVER_PORT);

                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Bind(ipEP);
                serverSocket.Listen(10);

                UpdateLog?.Invoke("Chờ người chơi kết nối...");

                while (true)
                {
                    Socket client = serverSocket.Accept();
                    UpdateLog?.Invoke("Đã kết nối với người chơi " + client.RemoteEndPoint);
                    Thread clientThread = new Thread(() => receiveData(client)) { IsBackground = true };
                    clientThread.Start();
                }
            }
            catch (Exception ex)
            {
                UpdateLog?.Invoke("Lỗi khi khởi tạo server: " + ex.Message);
            }
        }

        private void receiveData(Socket client)
        {
            Player player = new Player { PlayerSocket = client };
            connectedPlayers.Add(player);

            try
            {
                byte[] buffer = new byte[1024];
                while (client.Connected)
                {
                    if (player.PlayerSocket.Available > 0)
                    {
                        string msg = "";
                        while (player.PlayerSocket.Available > 0)
                        {
                            int bytesReceived = player.PlayerSocket.Receive(buffer);
                            msg += Encoding.UTF8.GetString(buffer, 0, bytesReceived);
                        }
                        UpdateLog?.Invoke($"{player.PlayerSocket.RemoteEndPoint}: {msg}");
                        parseMessage(msg, player);
                    }
                }
            }
            catch (Exception ex)
            {
                UpdateLog?.Invoke($"Lỗi nhận dữ liệu từ {client.RemoteEndPoint}: {ex.Message}");
            }
            finally
            {
                connectedPlayers.Remove(player);
                client.Close();
            }
        }

        private void sendData(Player player, string msg)
        {
            if (msg == null) return; // Kiểm tra null

            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(msg);
                player.PlayerSocket.Send(buffer);
            }
            catch (Exception ex)
            {
                UpdateLog?.Invoke($"Lỗi khi gửi dữ liệu tới {player.PlayerSocket.RemoteEndPoint}: {ex.Message}");
            }
        }

        private string GenerateRoomCode()
        {
            int length = 4; // Độ dài mã phòng
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"; // Các ký tự cho mã phòng
            Random random = new Random();
            char[] roomCode = new char[length];

            for (int i = 0; i < length; i++)
            {
                roomCode[i] = chars[random.Next(chars.Length)];
            }

            return new string(roomCode);
        }

        private void parseMessage(string msg, Player player)
        {
            string[] payload = msg.Split(';');
            string sendingMsg = "";
            Room room = null; // Khởi tạo room

            switch (payload[0])
            {
                case "LOGIN":
                    // Xử lý yêu cầu đăng nhập
                    break;
                case "REGISTER":
                    // Xử lý yêu cầu đăng ký
                    break;
                case "LOGOUT":
                    UpdateLog?.Invoke($"{player.Name} đã đăng xuất.");
                    break;
                case "JOIN_ROOM":
                    string playerName = payload[1].Trim();
                    player.Name = playerName;
                    player.Turn = room.players.Count;

                    // tìm room theo mã phòng
                    room = rooms.Find(r => r.RoomId == payload[2].Trim());
                    if (room != null)
                    {
                        room.players.Add(player);
                        player.Turn = room.players.Count;
                        player.IsHost = false;
                        sendingMsg = $"ROOMINFO;{player.Name};{room.RoomId};{player.Turn};{room.players.Count};{player.IsHost}";
                        foreach (var p in room.players)
                        {
                            sendData(p, sendingMsg);
                        }
                    }
                    break;
                case "CREATE_ROOM":
                    room = new Room();

                    rooms.Add(room);
                    room.players.Add(player);
                    player.IsHost = true;
                    player.Turn = 1;
                    sendingMsg = $"ROOMINFO;{player.Name};{room.RoomId};{player.Turn};{room.players.Count};{player.IsHost}";

                    sendData(player, sendingMsg);
                    UpdateLog?.Invoke($"{player.Name} đã tạo phòng {room.RoomId}.");
                    break;
                case "START":
                    // Xử lý yêu cầu bắt đầu game
                    break;
                case "DESCRIBE":
                    // Xử lý yêu cầu mô tả
                    break;
                case "GUESS":
                    // Xử lý yêu cầu đoán
                    break;
                case "LEADER_BOARD":
                    // Xử lý yêu cầu xem bảng xếp hạng
                    break;
                case "NEW_ROUND":
                    // Xử lý yêu cầu bắt đầu vòng mới
                    break;
                case "LEAVE_ROOM":
                    if (room != null)
                    {
                        room.players.Remove(player);
                        if (player.IsHost && room.players.Count > 0)
                        {
                            room.players[0].IsHost = true;
                        }

                        // thông báo tới tất cả người chơi về tình hình phòng
                        foreach (var p in room.players)
                        {
                            sendingMsg = $"ROOMINFO;{p.Name};{room.RoomId};{p.Turn};{room.players.Count};{p.IsHost}";
                            sendData(p, sendingMsg);
                        }

                        // xóa phòng nếu không còn ai
                        if (room.players.Count == 0)
                        {
                            rooms.Remove(room);
                            UpdateLog?.Invoke($"Phòng {room.RoomId} đã bị xóa vì không còn người chơi.");
                        }
                    }
                    UpdateLog?.Invoke($"{player.Name} đã rời phòng {room.RoomId}.");
                    break;
                case "UPDATE_SCORE":
                    // Xử lý yêu cầu cập nhật điểm
                    break;
                default:
                    UpdateLog?.Invoke("Yêu cầu không xác định: " + payload[0]);
                    break;
            }
        }


        public void StopServer()
        {
            serverSocket.Close();
            foreach (var player in connectedPlayers)
            {
                player.PlayerSocket.Close();
            }
        }
    }
}
