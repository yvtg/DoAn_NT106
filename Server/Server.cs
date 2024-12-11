using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;
using Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MongoDB.Driver.Core.Authentication;

namespace Server
{
    public class Server
    {
        public static Socket serverSocket;
        public List<User> clients = new List<User>(); // danh sách client đang kết nối tới
        public List<Room> rooms = new List<Room>(); // danh sách phòng chơi đang có

        private CancellationTokenSource cancellationTokenSource;
        private static string connectionString = "mongodb+srv://admin1:5VGZBpaXfZC15LPN@cluster0.qq9lk.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
        DataAccess.DatabaseHelper db = new DataAccess.DatabaseHelper(connectionString, "Datagame");
        private bool isRunning;

        public event Action<string> UpdateLog; // cập nhật log trên UI
        public event Action UpdateRoomList; // cập nhật danh sách phòng trên UI
        public event Action UpdateClientList; // cập nhật danh sách client trên UI

        #region Connect
        public void StartServer()
        {
            if (isRunning) return;

            cancellationTokenSource = new CancellationTokenSource();
            isRunning = true;

            Task.Run(() => InitializeServer(cancellationTokenSource.Token));
        }

        private async Task InitializeServer(CancellationToken cancellationToken)
        {
            try
            {
                EndPoint ipEP = new IPEndPoint(IPAddress.Any, 8080);

                // Khởi tạo server
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                serverSocket.Bind(ipEP);
                serverSocket.Listen(10);

                UpdateLog?.Invoke($"Server đã khởi động trên {ipEP}. Đang chờ kết nối...");

                while (isRunning)
                {
                    // Kiểm tra xem có yêu cầu hủy bỏ việc chờ kết nối
                    if (cancellationToken.IsCancellationRequested) break;
                    try
                    {
                        // Kiểm tra trạng thái của serverSocket
                        if (serverSocket == null || !serverSocket.IsBound)
                        {
                            UpdateLog?.Invoke("Socket server đã bị đóng.");
                            break;
                        }

                        // Chờ kết nối từ client
                        Socket clientSocket = await serverSocket.AcceptAsync();
                        HandleClientConnection(clientSocket, cancellationToken);
                    }
                    catch (Exception ex)
                    {
                        UpdateLog?.Invoke($"Lỗi khi chấp nhận kết nối: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                UpdateLog?.Invoke("Lỗi khi khởi tạo server: " + ex.Message);
            }
            finally
            {
                StopServer();
            }
        }

        private void HandleClientConnection(Socket clientSocket, CancellationToken cancellationToken)
        {
            var client = new User(clientSocket);
            if (client != null)
            {
                clients.Add(client);
                UpdateClientList?.Invoke();
            }
            else
            {
                UpdateLog?.Invoke("Failed to create client object.");
            }
            UpdateLog?.Invoke($"Đã kết nối với {clientSocket.RemoteEndPoint}");

            Task.Run(async () =>
            {
                try
                {
                    while (client.IsConnected && !cancellationToken.IsCancellationRequested)
                    {
                        string msg = await ReceiveDataAsync(client);
                        if (msg != null)
                        {
                            UpdateLog?.Invoke($"{clientSocket.RemoteEndPoint}: {msg}");
                            Packet packet = ParsePacket(client, msg);
                            analyzingPacket(client, packet);
                        }
                        else break;
                    }
                }
                catch (Exception ex)
                {
                    UpdateLog?.Invoke($"Lỗi khi xử lý client {clientSocket.RemoteEndPoint}: {ex.Message}");
                }
                finally
                {
                    // đóng kết nối client
                    if (client != null)
                    {
                        client.Stop();
                        clients.Remove(client);
                        UpdateClientList?.Invoke();
                    }
                    UpdateLog?.Invoke($"Client đã ngắt kết nối: {clientSocket.RemoteEndPoint}");
                }
            });
        }

        public void StopServer()
        {
            if (!isRunning) return;
            isRunning = false;

            // Hủy bỏ việc chờ kết nối
            cancellationTokenSource?.Cancel();

            // Đóng socket server
            try
            {
                if (serverSocket != null && serverSocket.Connected)
                {
                    serverSocket.Close();
                }
            }
            catch (Exception ex)
            {
                UpdateLog?.Invoke($"Lỗi khi đóng socket server: {ex.Message}");
            } 
            finally 
            {
                serverSocket = null;
            }

            // Đóng tất cả kết nối client
            foreach (var client in clients.ToArray())
            {
                client.Stop();
            }

            clients.Clear();
            UpdateLog?.Invoke("Server đã ngừng hoạt động.");
        }
        #endregion

        #region Data
        private async Task<string> ReceiveDataAsync(User client)
        {
            try
            {
                byte[] buffer = new byte[1024];
                int receivedBytes = await Task.Run(() => client.UserSocket.Receive(buffer, SocketFlags.None));
                if (receivedBytes > 0)
                {
                    return Encoding.UTF8.GetString(buffer, 0, receivedBytes);
                }

                // client đóng socket
                if (receivedBytes == 0)
                {
                    client.Stop();
                    clients.Remove(client);
                    UpdateClientList?.Invoke();
                    UpdateLog?.Invoke($"Client {client.UserSocket.RemoteEndPoint} đã ngắt kết nối.");
                    return null;
                }

            }
            catch (SocketException)
            {
                client.Stop();
                clients.Remove(client);
                UpdateClientList?.Invoke();
                UpdateLog?.Invoke($"Client {client.UserSocket.RemoteEndPoint} đã ngắt kết nối.");
            }
            return null;
        }


        private void sendPacket(User client, Packet packet)
        {
            try
            {
                // Chuẩn bị dữ liệu để gửi
                client.SendPacket(packet);

                UpdateLog?.Invoke($"Đã gửi dữ liệu cho {client.UserSocket.RemoteEndPoint} {packet.Type};{packet.Payload}");
            }
            catch (SocketException ex)
            {
                UpdateLog?.Invoke("Socket exception: " + ex.Message);
                // Xử lý client bị mất kết nối
                client.Stop();
                clients.Remove(client);
                UpdateClientList?.Invoke();
            }
        }

        private void BroadcastPacket(Room room, Packet packet)
        {
            foreach (var client in room.players)
            {
                sendPacket(client, packet);
            }
        }

        private Packet ParsePacket(User client, string msg)
        {
            string[] payload = msg.Split(';');
            if (payload.Length == 0)
            {
                return null; // Không có dữ liệu
            }

            // Lấy phần còn lại của msg, bỏ payload[0] (command)
            string remainingMsg = string.Join(";", payload.Skip(1));

            // Xác định loại packet dựa trên phần tử đầu tiên
            PacketType packetType;
            if (Enum.TryParse(payload[0], out packetType))
            {
                switch (packetType)
                {
                    case PacketType.LOGIN:
                        return new LoginPacket(remainingMsg);
                    case PacketType.REGISTER:
                        return new RegisterPacket(remainingMsg);
                    case PacketType.LOGOUT:
                        return new LogoutPacket(remainingMsg);
                    case PacketType.CREATE_ROOM:
                        return new CreateRoomPacket(remainingMsg);
                    case PacketType.JOIN_ROOM:
                        return new JoinRoomPacket(remainingMsg);
                    case PacketType.LEAVE_ROOM:
                        return new LeaveRoomPacket(remainingMsg);
                    case PacketType.START:
                        return new StartPacket(remainingMsg);
                    case PacketType.DESCRIBE:
                        return new DescribePacket(remainingMsg);
                    case PacketType.GUESS:
                        return new GuessPacket(remainingMsg);
                    case PacketType.DISCONNECT:
                        return new DisconnectPacket(remainingMsg);
                    default:
                        return null; // Không biết loại packet
                }
            }
            return null; 
        }

        // tạo mã phòng random
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


        // xu ly sau khi nhan du lieu tu client
        private void analyzingPacket(User client, Packet packet)
        {
            string clientIP = client.UserSocket.RemoteEndPoint.ToString();
            switch (packet.Type)
            {
                case PacketType.LOGIN:
                    LoginPacket loginPacket = (LoginPacket)packet;
                    if (db.LoginUser(loginPacket.Username, loginPacket.Password))
                    {
                        LoginResultPacket result = new LoginResultPacket("SUCCESS");
                        sendPacket(client, result);
                        UpdateLog.Invoke($"{loginPacket.Username} đăng nhập thành công");
                        client.Name = loginPacket.Username;
                    }
                    else
                    {
                        LoginResultPacket result = new LoginResultPacket("FAIL");
                        sendPacket(client, result);
                        UpdateLog.Invoke($"{loginPacket.Username} đăng nhập thất bại");
                    }
                    UpdateClientList?.Invoke();
                    break;

                case PacketType.REGISTER:
                    RegisterPacket registerPacket = (RegisterPacket)packet;
                    if (db.RegisterUser(registerPacket.Username, registerPacket.Email, registerPacket.Password))
                    {
                        RegisterResultPacket result = new RegisterResultPacket("SUCCESS");
                        sendPacket(client, result);
                        UpdateLog.Invoke($"{registerPacket.Username} đăng ký tài khoản thành công");
                    }
                    else
                    {
                        RegisterResultPacket result = new RegisterResultPacket("FAIL");
                        sendPacket(client, result);
                        UpdateLog.Invoke($"{registerPacket.Username} đăng ký tài khoản thất bại");
                    }

                    break;

                case PacketType.LOGOUT:
                    LogoutPacket logoutPacket = (LogoutPacket)packet;
                    UpdateLog.Invoke($"{logoutPacket.Username} đã đăng xuất");

                    break;

                case PacketType.CREATE_ROOM:
                    CreateRoomPacket createRoomPacket = (CreateRoomPacket)packet;

                    client.Name = createRoomPacket.username;

                    // Create a new room
                    string roomId = GenerateRoomId();
                    int maxPlayers = createRoomPacket.Max_player;

                    Room room = new Room(roomId, client.Name, maxPlayers, client);
                    rooms.Add(room);

                    if (!room.players.Any(p => p.UserSocket.RemoteEndPoint.ToString() == client.UserSocket.RemoteEndPoint.ToString()))
                    {
                        room.players.Add(client);
                    }
                    else
                    {
                        UpdateLog.Invoke($"{client.Name} đã tồn tại trong phòng {roomId}.");
                    }

                    int currentPlayers = room.players.Count;
                    int currentRound = 0;

                    RoomInfoPacket roomInfo = new RoomInfoPacket($"{roomId};{room.host};{room.status};{maxPlayers};{currentPlayers};{currentRound}");
                    sendPacket(client, roomInfo);

                    //OtherInfoPacket otherInfoPacket = new OtherInfoPacket($"{roomId};{client.Name};{client.Score};JOINING");
                    //sendPacket(client, otherInfoPacket);
                    client.RoomId = roomId;
                    UpdateClientList?.Invoke();
                    UpdateRoomList?.Invoke();
                    UpdateLog.Invoke($"{client.Name} đã tạo phòng {roomId}");

                    break;

                case PacketType.JOIN_ROOM:
                    JoinRoomPacket joinRoomPacket = (JoinRoomPacket)packet;
                    string roomIdToJoin = joinRoomPacket.RoomId;
                    string ussername = joinRoomPacket.Username;
                    string join_result = "SUCCESS";

                    room = rooms.FirstOrDefault(r => r.RoomId == roomIdToJoin);
                    if (room == null)
                    {
                        join_result = "NOT_EXIST";
                        // Xử lý lỗi, không tiếp tục
                        sendPacket(client, new JoinResultPacket(join_result));
                        return;
                    }
                    // kiểm tra phòng đang chơi
                    else if (room.status == "playing")
                    {
                        join_result = "PLAYING";
                        sendPacket(client, new JoinResultPacket(join_result));
                        return;
                    }
                    // kiểm tra phòng đã kết thúc
                    else if (room.status == "finished")
                    {
                        join_result = "FINISHED";
                        sendPacket(client, new JoinResultPacket(join_result));
                        return;
                    }
                    // kiểm tra phòng đầy
                    else if (room.players.Count > room.maxPlayers)
                    {
                        join_result = "FULL";
                        sendPacket(client, new JoinResultPacket(join_result));
                        return;
                    }
                    // Kiểm tra xem client đã trong phòng hay chưa
                    else if (room.players.Any(p => p.UserSocket.RemoteEndPoint.ToString() == client.UserSocket.RemoteEndPoint.ToString()))
                    {
                        join_result = "ALREADY_JOINED";
                        sendPacket(client, new JoinResultPacket(join_result));
                        UpdateLog?.Invoke($"{client.Name} đã ở trong phòng {roomIdToJoin}.");
                        return;
                    }


                    else if (join_result=="SUCCESS")
                    {
                        room.players.Add(client);
                        client.RoomId = roomIdToJoin;
                        UpdateClientList?.Invoke();

                        // cap nhat thong tin phong
                        roomInfo = new RoomInfoPacket($"{roomIdToJoin};{room.host};{room.status};{room.maxPlayers};{room.players.Count};0");
                        sendPacket(client, roomInfo);

                        //cap nhat thong tin nhung nguoi co trong phong
                        foreach (var player in room.players)
                        {
                            if (player != null)
                            {
                                OtherInfoPacket otherInfo = new OtherInfoPacket($"{roomIdToJoin};{player.Name};{player.Score};JOINED");
                                sendPacket(client, otherInfo);
                            }
                        }

                        OtherInfoPacket otherInfoPacket = new OtherInfoPacket($"{roomIdToJoin};{client.Name};{client.Score};JOINING");
                        BroadcastPacket(room, otherInfoPacket);

                        UpdateRoomList?.Invoke();
                        UpdateLog.Invoke($"{client.Name} đã tham gia phòng {roomIdToJoin}");
                    }

                    break;
                case PacketType.LEAVE_ROOM:
                    LeaveRoomPacket leaveRoomPacket = (LeaveRoomPacket)packet;
                    roomId = leaveRoomPacket.RoomId;
                    room = rooms.FirstOrDefault(r => r.RoomId == roomId);
                    if (room != null)
                    {
                        room.players.Remove(client);
                        OtherInfoPacket otherInfo = new OtherInfoPacket($"{roomId};{client.Name};{client.Score};LEAVE");
                        BroadcastPacket(room, otherInfo);
                        if (room.players.Count == 0)
                        {
                            rooms.Remove(room);
                        }
                        UpdateRoomList?.Invoke();
                        UpdateLog.Invoke($"{client.Name} đã rời phòng {roomId}");
                    }

                    break;

                case PacketType.START:
                    break;
                case PacketType.DESCRIBE:
                    break;
                case PacketType.GUESS:
                    GuessPacket guessPacket = (GuessPacket)packet;
                    roomId = guessPacket.RoomId;
                    string username = guessPacket.playerName;
                    string msg = guessPacket.GuessMessage;

                    // gui message toi tat ca client trong phong
                    room = rooms.FirstOrDefault(r => r.RoomId == roomId);
                    if (room != null)
                    {
                        BroadcastPacket(room, guessPacket);
                        OtherInfoPacket otherInfo = new OtherInfoPacket($"{roomId};{username};{client.Score};GUESS");
                        BroadcastPacket(room, otherInfo);
                        UpdateLog.Invoke($"{username} đã đoán: {msg}");
                    }

                    // check coi ket qua dung ko
                    if (room.CheckAnswer(msg, client))
                    {
                        // gui diem cho client de cap nhat
                    }


                    break;
                case PacketType.DISCONNECT:
                    UpdateLog?.Invoke($"Client {clientIP} đã ngắt kết nối.");
                    if (client.IsConnected)
                    {
                        client.Stop();
                        clients.Remove(client);
                    }
                    cancellationTokenSource.Cancel();
                    break;
                default:
                    break;
            }
        }
        #endregion

    }
}
