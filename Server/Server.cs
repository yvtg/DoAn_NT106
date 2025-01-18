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
using System.Xml.Linq;
using System.Drawing;
using System.IO;
using Microsoft.VisualBasic.ApplicationServices;
using System.Net.Mail;
using MongoDB.Bson;

namespace Server
{
    public class Server
    {
        private Dictionary<string, string> otpStorage = new Dictionary<string, string>(); // Email -> OTP mapping
        public static Socket serverSocket;
        public List<Models.User> clients = new List<Models.User>(); // danh sách client đang kết nối tới
        public List<Room> rooms = new List<Room>(); // danh sách phòng chơi đang có

        private static string connectionString = "mongodb+srv://admin1:5VGZBpaXfZC15LPN@cluster0.qq9lk.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
        DataAccess.DatabaseHelper db = new DataAccess.DatabaseHelper(connectionString, "Datagame");
        private bool isRunning;

        public event Action<string> UpdateLog; // cập nhật log trên UI
        public event Action UpdateRoomList; // cập nhật danh sách phòng trên UI
        public event Action UpdateClientList; // cập nhật danh sách client trên UI



        #region Connect
        public void StartServer(int port)
        {
            if (isRunning) return;

            isRunning = true;

            Task.Run(() => InitializeServer(port));
        }

        private async Task InitializeServer(int port)
        {
            EndPoint ipEP = new IPEndPoint(IPAddress.Any, port);

            // Khởi tạo server
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
            serverSocket.Bind(ipEP);
            serverSocket.Listen(10);

            UpdateLog?.Invoke($"Server đã khởi động trên port {port}. Đang chờ kết nối...");

            while (isRunning)
            {
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
                    UpdateLog?.Invoke($"Đã kết nối với {clientSocket.RemoteEndPoint}");

                    // Tạo TcpClient và xử lý kết nối trong một Task riêng
                    TcpClient tcpClient = new TcpClient { Client = clientSocket };
                    _ = Task.Run(() => HandleClientConnection(tcpClient)); // Chạy không chặn
                }
                catch (Exception ex)
                {
                    UpdateLog?.Invoke($"Lỗi khi chấp nhận kết nối: {ex.Message}");
                }
            }
        }


        // Xử lý kết nối client
        private async Task HandleClientConnection(TcpClient tcpClient)
        {
            Models.User client = new Models.User(tcpClient);

            if (client != null)
            {
                clients.Add(client);
                UpdateClientList?.Invoke();
            }

            try
            {
                while (client.IsConnected)
                {
                    if (serverSocket == null || !serverSocket.IsBound)
                    {
                        UpdateLog?.Invoke("Socket server đã bị đóng.");
                        break;
                    }

                    string encryptedMsg = await client.sr.ReadLineAsync(); // Đọc dữ liệu mã hóa từ client

                    if (!string.IsNullOrEmpty(encryptedMsg))
                    {
                        try
                        {
                            if (encryptedMsg.StartsWith("{") && encryptedMsg.EndsWith("}"))
                            {
                                UpdateLog?.Invoke($"{tcpClient.Client.RemoteEndPoint}: {encryptedMsg}");
                                await HandleDrawPacket(client, encryptedMsg); // Xử lý gói tin vẽ
                            }
                            else
                            {
                                string msg = AES.DecryptAES(Convert.FromBase64String(encryptedMsg));
                                UpdateLog?.Invoke($"{tcpClient.Client.RemoteEndPoint}: {msg}");
                                Packet packet = ParsePacket(client, msg); // Phân tích gói tin
                                await analyzingPacket(client, packet);          // Xử lý gói tin
                            }
                        }
                        catch (Exception ex)
                        {
                            UpdateLog?.Invoke($"Lỗi giải mã từ client: {ex.Message}");
                        }
                    }
                    else break;
                }
            }
            catch (OperationCanceledException)
            {
                // Task bị hủy - không cần làm gì thêm
            }
            finally
            {
                // Đóng kết nối client
                if (client != null)
                {
                    clients.Remove(client);
                    client.Stop(true);
                    UpdateClientList?.Invoke();
                }
                UpdateLog?.Invoke($"{client.tcpClient.Client.RemoteEndPoint} đã ngắt kết nối");
            }
        }


        public async Task StopServer()
        {
            if (!isRunning) return;
            isRunning = false;

            // Đóng tất cả kết nối client
            foreach (var client in clients.ToArray())
            {
                // gửi thông báo đóng kết nối đến client
                await sendPacket(client, new DisconnectPacket(""));
                client.Stop();
                client.sr.Close();
                client.sw.Close();
            }

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
                if (serverSocket != null)
                {
                    serverSocket.Close();
                    serverSocket = null;
                }
            }


            clients.Clear();
            UpdateLog?.Invoke("Server đã ngừng hoạt động.");
        }
        #endregion

        #region Data

        // Gửi gói tin
        private async Task sendPacket(Models.User client, Packet packet)
        {
            try
            {
                // Chuẩn bị dữ liệu để gửi
                await client.SendPacket(packet);

                UpdateLog?.Invoke($"Đã gửi dữ liệu cho {client.tcpClient.Client.RemoteEndPoint} {packet.Type};{packet.Payload}");
            }
            catch (SocketException ex)
            {
                UpdateLog?.Invoke("Socket exception: " + ex.Message);
                // Xử lý client bị mất kết nối
                clients.Remove(client);
                client.Stop();
                client.sr.Close();
                client.sw.Close();
                UpdateClientList?.Invoke();
            }
        }

        // Gửi gói tin vẽ
        private async Task SendDrawPacket(Models.User client, DrawPacket drawPacket)
        {
            try
            {
                // Chuẩn bị dữ liệu để gửi
                await client.SendPacket(drawPacket);

                UpdateLog?.Invoke($"Đã gửi dữ liệu cho {client.tcpClient.Client.RemoteEndPoint}");
            }
            catch (SocketException ex)
            {
                UpdateLog?.Invoke("Socket exception: " + ex.Message);
                // Xử lý client bị mất kết nối
                clients.Remove(client);
                client.Stop();
                client.sr.Close();
                client.sw.Close();
                UpdateClientList?.Invoke();
            }
        }

        private async Task BroadcastPacket(Room room, Packet packet)
        {
            foreach (var client in room.players)
            {
                await sendPacket(client, packet);
            }
        }

        private async Task BroadcastPacket(Room room, DrawPacket drawPacket)
        {
            foreach (var client in room.players)
            {
                await SendDrawPacket(client, drawPacket);
            }
        }


        private Packet ParsePacket(Models.User client, string msg)
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
                    case PacketType.RESET_PASSWORD_REQUEST:
                        return new ResetPasswordRequestPacket(remainingMsg);
                    case PacketType.VERIFY_OTP:
                        return new VerifyOTPRequestPacket(payload[1], payload[2]);
                    case PacketType.RESET_PASSWORD:
                        return new ResetPasswordPacket(payload[1], payload[2]);
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
                    case PacketType.PROFILE_REQUEST:
                        return new ProfileRequest(remainingMsg);
                    case PacketType.PROFILE_UPDATE:
                        return new ProfileUpdatePacket(remainingMsg);
                    case PacketType.END_GAME:
                        return new EndGamePacket(remainingMsg);
                    default:
                        return null;
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
        private async Task analyzingPacket(Models.User client, Packet packet)
        {
            string clientIP = client.tcpClient.Client.RemoteEndPoint.ToString();
            switch (packet.Type)
            {
                case PacketType.LOGIN:
                    LoginPacket loginPacket = (LoginPacket)packet;
                    if (db.LoginUser(loginPacket.Username, loginPacket.Password))
                    {
                        LoginResultPacket result = new LoginResultPacket("SUCCESS");
                        await sendPacket(client, result);
                        UpdateLog?.Invoke($"{loginPacket.Username} đăng nhập thành công");
                        client.Name = loginPacket.Username;
                    }
                    else
                    {
                        LoginResultPacket result = new LoginResultPacket("FAIL");
                        await sendPacket(client, result);
                        UpdateLog?.Invoke($"{loginPacket.Username} đăng nhập thất bại");
                    }
                    UpdateClientList?.Invoke();
                    break;

                case PacketType.REGISTER:
                    RegisterPacket registerPacket = (RegisterPacket)packet;
                    if (db.RegisterUser(registerPacket.Username, registerPacket.Email, registerPacket.Password))
                    {
                        RegisterResultPacket result = new RegisterResultPacket("SUCCESS");
                        await sendPacket(client, result);
                        UpdateLog.Invoke($"{registerPacket.Username} đăng ký tài khoản thành công");
                    }
                    else
                    {
                        RegisterResultPacket result = new RegisterResultPacket("FAIL");
                        await sendPacket(client, result);
                        UpdateLog.Invoke($"{registerPacket.Username} đăng ký tài khoản thất bại");
                    }

                    break;

                case PacketType.LOGOUT:
                    LogoutPacket logoutPacket = (LogoutPacket)packet;
                    UpdateLog.Invoke($"{logoutPacket.Username} đã đăng xuất");

                    break;
                case PacketType.RESET_PASSWORD_REQUEST:
                    await HandleResetPasswordRequest(client, (ResetPasswordRequestPacket)packet);
                    break;

                case PacketType.VERIFY_OTP:
                    await HandleVerifyOTP(client, (VerifyOTPRequestPacket)packet);
                    break;

                case PacketType.RESET_PASSWORD:
                    await HandleResetPassword(client, (ResetPasswordPacket)packet);
                    break;
                case PacketType.CREATE_ROOM:
                    CreateRoomPacket createRoomPacket = (CreateRoomPacket)packet;

                    client.Name = createRoomPacket.username;

                    // Create a new room
                    string roomId = GenerateRoomId();
                    int maxPlayers = createRoomPacket.Max_player;
                    

                    Room room = new Room(roomId, client.Name, maxPlayers, client);
                    rooms.Add(room);

                    client.RoomId = roomId;
                    client.Score = 0;
                    room.players.Add(client);
                    room.isblindround = createRoomPacket.isblindround;

                    int currentPlayers = room.players.Count;
                    int currentRound = 0;

                    RoomInfoPacket roomInfo = new RoomInfoPacket($"{roomId};{room.host};{room.status};{maxPlayers};{currentPlayers};{currentRound};{room.isblindround}");
                    await sendPacket(client, roomInfo);

                    OtherInfoPacket otherInfoPacket = new OtherInfoPacket($"{roomId};{client.Name};{client.Score};JOINING");
                    await sendPacket(client, otherInfoPacket);

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
                        await sendPacket(client, new JoinResultPacket(join_result));
                        return;
                    }
                    // kiểm tra phòng đang chơi
                    else if (room.status == "PLAYING")
                    {
                        join_result = "PLAYING";
                        await sendPacket(client, new JoinResultPacket(join_result));
                        return;
                    }
                    // kiểm tra phòng đầy
                    else if (room.players.Count > room.maxPlayers)
                    {
                        join_result = "FULL";
                        await sendPacket(client, new JoinResultPacket(join_result));
                        return;
                    }
                    // Kiểm tra xem client đã trong phòng hay chưa
                    else if (room.players.Any(p => p.tcpClient.Client.RemoteEndPoint.ToString() == client.tcpClient.Client.RemoteEndPoint.ToString()))
                    {
                        join_result = "ALREADY_JOINED";
                        await sendPacket(client, new JoinResultPacket(join_result));
                        UpdateLog?.Invoke($"{client.Name} đã ở trong phòng {roomIdToJoin}.");
                        return;
                    }


                    else if (join_result == "SUCCESS")
                    {
                        room.players.Add(client);
                        if (room.maxPlayers == room.players.Count)
                        {
                            room.status = "FULL";
                        }

                        client.RoomId = roomIdToJoin;
                        UpdateClientList?.Invoke();

                        // cap nhat thong tin phong
                        roomInfo = new RoomInfoPacket($"{roomIdToJoin};{room.host};{room.status};{room.maxPlayers};{room.players.Count};0;{room.isblindround}");
                        await sendPacket(client, roomInfo);

                        //cap nhat thong tin nhung nguoi co trong phong
                        foreach (var player in room.players)
                        {
                            if (player != null && player != client)
                            {
                                OtherInfoPacket otherInfo = new OtherInfoPacket($"{roomIdToJoin};{player.Name};{player.Score};JOINED");
                                await sendPacket(client, otherInfo);
                            }
                        }

                        otherInfoPacket = new OtherInfoPacket($"{roomIdToJoin};{client.Name};{client.Score};JOINING");
                        await BroadcastPacket(room, otherInfoPacket);

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
                        client.Score = 0;
                        client.RoomId = "";
                        OtherInfoPacket otherInfo = new OtherInfoPacket($"{roomId};{client.Name};{client.Score};LEAVE");
                        await BroadcastPacket(room, otherInfo);
                        if (room.players.Count == 0)
                        {
                            rooms.Remove(room);
                        }
                        else if (client.Name == room.host)
                        {
                            room.host = room.players[0].Name;
                            // cap nhat thong tin phong
                            roomInfo = new RoomInfoPacket($"{roomId};{room.host};HOST_CHANGED;{room.maxPlayers};{room.players.Count};{room.currentRound}");
                            await BroadcastPacket(room, roomInfo);
                        }
                        UpdateClientList?.Invoke();
                        UpdateRoomList?.Invoke();
                        UpdateLog.Invoke($"{client.Name} đã rời phòng {roomId}");
                    }

                    break;

                case PacketType.START:
                    // Phân tích gói tin StartPacket
                    StartPacket startPacket = (StartPacket)packet;
                    roomId = startPacket.RoomId;
                    currentRound = startPacket.Round;
                    room = rooms.FirstOrDefault(r => r.RoomId == roomId);

                    // Kiểm tra phòng có tồn tại hay không
                    if (room != null)
                    {
                        // Chọn người vẽ ngẫu nhiên
                        room.StartNewRound();
                        room.status = "PLAYING";
                        string isdraw = room.currentDrawer.IsDrawing.ToString();
                        string name = room.currentDrawer.Name;
                        string word = room.currentKeyword;
                        Random random = new Random();

                        // cập nhật phòng
                        room.currentRound = currentRound;

                        // Gửi thông báo về người vẽ cho tất cả người chơi trong phòng
                        foreach (var user in room.players)
                        {
                            RoundUpdatePacket RoundUpdate = new RoundUpdatePacket($"{roomId};{name};{isdraw};{word};{currentRound}");
                            await user.SendPacket(RoundUpdate);
                        }

                        UpdateLog.Invoke($"Phòng {roomId}: Trò chơi bắt đầu. Người vẽ là {room.currentDrawer.Name} và từ khóa là {room.currentKeyword}");
                        UpdateRoomList?.Invoke();
                    }
                    else
                    {
                        Console.WriteLine($"Phòng {roomId} không tồn tại.");
                    }
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
                        await BroadcastPacket(room, guessPacket);
                        OtherInfoPacket otherInfo = new OtherInfoPacket($"{roomId};{username};{client.Score};GUESS");
                        await BroadcastPacket(room, otherInfo);
                        UpdateLog.Invoke($"{username} đã đoán: {msg}");
                    }

                    // check coi ket qua dung ko
                    if (room.CheckAnswer(msg, client))
                    {
                        // gui diem cho client de cap nhat
                        OtherInfoPacket otherInfo = new OtherInfoPacket($"{roomId};{username};{client.Score};GUESS_RIGHT");
                        await BroadcastPacket(room, otherInfo);
                    }
                    break;
                case PacketType.END_GAME:
                    EndGamePacket endGamePacket = (EndGamePacket)packet;
                    roomId = endGamePacket.RoomId;
                    room = rooms.FirstOrDefault(r => r.RoomId == roomId);
                    if (room != null)
                    {
                        client.Score = 0;
                        room.Clear();
                        UpdateRoomList?.Invoke();
                        await BroadcastPacket(room, endGamePacket);
                    }
                    break;
                case PacketType.DISCONNECT:
                    UpdateLog?.Invoke($"Client {clientIP} đã ngắt kết nối.");

                    if (client.IsConnected)
                    {
                        try
                        {
                            // Dừng client và giải phóng tài nguyên
                            client.Stop();
                        }
                        catch (Exception ex)
                        {
                            UpdateLog?.Invoke($"Lỗi khi ngắt kết nối client {clientIP}: {ex.Message}");
                        }
                        finally
                        {
                            // Loại bỏ client khỏi danh sách
                            clients.Remove(client);
                            UpdateClientList?.Invoke(); // Cập nhật danh sách client
                        }
                    }
                    else
                    {
                        UpdateLog?.Invoke($"Client {clientIP} đã ngắt kết nối trước đó.");
                    }
                    break;
                case PacketType.PROFILE_REQUEST:
                    ProfileRequest profileRequest = (ProfileRequest)packet;
                    var profileData = db.GetProfileData(profileRequest.Username);

                    // Gán dữ liệu vào các biến hoặc controls
                    if (profileData != null)
                    {
                        ProfileResultPacket profileResultPacket = new ProfileResultPacket($"{profileData.username};{profileData.email};{profileData.highestscore};{profileData.gamesplayed}");
                        await sendPacket(client, profileResultPacket);
                    }
                    break;
                case PacketType.PROFILE_UPDATE:
                    ProfileUpdatePacket profileUpdatePacket = (ProfileUpdatePacket)packet;
                    username = profileUpdatePacket.username;
                    int score = profileUpdatePacket.score;

                    // Cập nhật dữ liệu vào database
                    if (db.UpdateProfileData(username, score))
                    {
                        UpdateLog?.Invoke($"Cập nhật thông tin người dùng {username} thành công.");
                    }
                    else
                    {
                        UpdateLog?.Invoke($"Cập nhật thông tin người dùng {username} thất bại.");
                    }
                    break;
                default:
                    break;
            }
        }

        private async Task HandleDrawPacket(Models.User client, string msg)
        {
            DrawPacket drawPacket = Newtonsoft.Json.JsonConvert.DeserializeObject<DrawPacket>(msg);
            string roomId = drawPacket.RoomId;
            Room room = rooms.FirstOrDefault(r => r.RoomId == roomId);
            if (room != null)
            {
                await BroadcastPacket(room, drawPacket);
            }
        }
        #endregion

        #region fotgot password
        private async Task HandleResetPassword(Models.User client, ResetPasswordPacket packet)
        {
            string email = packet.Email;
            string newPassword = packet.NewPassword;

            if (db.UpdatePassword(email, newPassword))
            {
                await sendPacket(client, new ResetPasswordResultPacket("SUCCESS"));
            }
            else
            {
                await sendPacket(client, new ResetPasswordResultPacket("FAIL"));
            }
        }


        private async Task HandleResetPasswordRequest(Models.User client, ResetPasswordRequestPacket packet)
        {
            string email = packet.Email.Trim();

            var user = db.GetAllDocuments<BsonDocument>("User")
                         .FirstOrDefault(u => u["Email"].AsString == email);

            if (user != null)
            {
                try
                {
                    string otp = ForgetPassword.GenerateOTP();
                    otpStorage[email] = otp; // Lưu OTP

                    ForgetPassword.SendEmail(email, otp);
                    await sendPacket(client, new ResetPasswordResultPacket("EMAIL_SENT"));
                }
                catch (Exception)
                {
                    await sendPacket(client, new ResetPasswordResultPacket("EMAIL_FAIL"));
                }
            }
            else
            {
                await sendPacket(client, new ResetPasswordResultPacket("NOT_FOUND"));
            }
        }


        private async Task HandleVerifyOTP(Models.User client, VerifyOTPRequestPacket packet)
        {
            try
            {
                string email = packet.Email;
                string otp = packet.OTP;

                if (otpStorage.TryGetValue(email, out var storedOtp) && storedOtp == otp)
                {
                    otpStorage.Remove(email); // Xóa OTP sau khi sử dụng

                    // Gửi phản hồi đã mã hóa
                    await sendPacket(client, new ResetPasswordResultPacket("OTP_VERIFIED"));
                }
                else
                {
                    await sendPacket(client, new ResetPasswordResultPacket("OTP_FAIL"));
                }
            }
            catch (Exception ex)
            {
                UpdateLog?.Invoke($"Lỗi trong HandleVerifyOTP: {ex.Message}");
            }
        }

        #endregion
    }
}
