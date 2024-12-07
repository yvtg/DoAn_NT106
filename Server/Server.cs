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

namespace Server
{
    public class Server
    {
        public static Socket serverSocket;
        public static List<User> clients = new List<User>(); // danh sách client đang kết nối tới
        public List<Room> rooms = new List<Room>(); // danh sách phòng chơi đang có

        private CancellationTokenSource cancellationTokenSource;
        private static string connectionString = "mongodb+srv://admin1:5VGZBpaXfZC15LPN@cluster0.qq9lk.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
        DataAccess.DatabaseHelper db = new DataAccess.DatabaseHelper(connectionString, "Datagame");
        private bool isRunning;

        public event Action<string> UpdateLog; // cập nhật log trên UI

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
                const string SERVER_IPADDRESS = "127.0.0.1";
                const int SERVER_PORT = 8080;
                IPAddress ipAddr = IPAddress.Parse(SERVER_IPADDRESS);
                IPEndPoint ipEP = new IPEndPoint(ipAddr, SERVER_PORT);

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
                        HandleClientConnection(clientSocket);
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

        private void HandleClientConnection(Socket clientSocket)
        {
            var client = new User(clientSocket);
            if (client != null)
            {
                clients.Add(client);
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
                    while (client.IsConnected)
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
                    UpdateLog?.Invoke($"Client {client.UserSocket.RemoteEndPoint} đã ngắt kết nối.");
                    return null;
                }

            }
            catch (SocketException)
            {
                client.Stop();
                clients.Remove(client);
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
                        LoginResultPacket result = new LoginResultPacket("success");
                        sendPacket(client, result);
                        UpdateLog.Invoke($"{loginPacket.Username} đăng nhập thành công");
                        client.Name = loginPacket.Username;
                    }
                    else
                    {
                        LoginResultPacket result = new LoginResultPacket("fail");
                        sendPacket(client, result);
                        UpdateLog.Invoke($"{loginPacket.Username} đăng nhập thất bại");
                    }
                    break;
                case PacketType.REGISTER:
                    RegisterPacket registerPacket = (RegisterPacket)packet;
                    if (db.RegisterUser(registerPacket.Username, registerPacket.Email, registerPacket.Password))
                    {
                        RegisterResultPacket result = new RegisterResultPacket("success");
                        sendPacket(client, result);
                        UpdateLog.Invoke($"{registerPacket.Username} đăng ký tài khoản thành công");
                    }
                    else
                    {
                        RegisterResultPacket result = new RegisterResultPacket("fail");
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
                    room.players.Add(client);
                    rooms.Add(room);
                    int currentPlayers = room.players.Count;
                    int currentRound = 0;

                    RoomInfoPacket roomInfo = new RoomInfoPacket($"{roomId};{room.host};{room.status};{maxPlayers};{currentPlayers};{currentRound}");
                    sendPacket(client, roomInfo);

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

                    else if (join_result=="SUCCESS")
                    {
                        room.players.Add(client);
                        roomInfo = new RoomInfoPacket($"{roomIdToJoin};{room.host};{room.status};{room.maxPlayers};{room.players.Count};0");
                        sendPacket(client, roomInfo);
                        UpdateLog.Invoke($"{client.Name} đã tham gia phòng {roomIdToJoin}");
                    }

                    break;
                case PacketType.LEAVE_ROOM:
                    break;
                case PacketType.START:
                    break;
                case PacketType.DESCRIBE:
                    break;
                case PacketType.GUESS:
                    break;
                case PacketType.DISCONNECT:
                    UpdateLog?.Invoke($"Client {clientIP} đã ngắt kết nối.");
                    if (client.IsConnected)
                    {
                        client.Stop();
                        clients.Remove(client);
                    }
                    break;

                default:
                    break;
            }
        }
        #endregion

    }
}
