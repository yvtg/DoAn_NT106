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
        public void StartServer()
        {
            if (isRunning) return;

            isRunning = true;

            Task.Run(() => InitializeServer());
        }

        private async Task InitializeServer()
        {
            EndPoint ipEP = new IPEndPoint(IPAddress.Any, 8080);

            // Khởi tạo server
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
            serverSocket.Bind(ipEP);
            serverSocket.Listen(10);

            UpdateLog?.Invoke($"Server đã khởi động trên {ipEP}. Đang chờ kết nối...");

            while (isRunning)
            {
                // Kiểm tra trạng thái của serverSocket
                if (serverSocket == null || !serverSocket.IsBound)
                {
                    UpdateLog?.Invoke("Socket server đã bị đóng.");
                    break;
                }

                // Chờ kết nối từ client
                Socket clientSocket = await serverSocket.AcceptAsync();
                TcpClient tcpClient = new TcpClient { Client = clientSocket };
                HandleClientConnection(tcpClient);
            }
        }

        private void HandleClientConnection(TcpClient tcpClient)
        {
            Models.User client = new Models.User(tcpClient);

            if (client != null)
            {
                clients.Add(client);
                UpdateClientList?.Invoke();
            }
            UpdateLog?.Invoke($"Đã kết nối với {tcpClient.Client.RemoteEndPoint}");

            Task.Run(() =>
            {
                try
                {
                    while (client.IsConnected)
                    {
                        if (serverSocket == null || !serverSocket.IsBound)
                        {
                            UpdateLog?.Invoke("Socket server đã bị đóng.");
                            break;
                        }

                        string msg = client.sr.ReadLine(); // Đọc dữ liệu mã hóa từ client

                        if (!string.IsNullOrEmpty(msg))
                        {
                            UpdateLog?.Invoke($"{tcpClient.Client.RemoteEndPoint}: {msg}");

                            try
                            {
                                UpdateLog?.Invoke($"{tcpClient.Client.RemoteEndPoint}: {msg}");

                                if (msg.StartsWith("{") && msg.EndsWith("}"))
                                {
                                    HandleDrawPacket(client, msg); // Xử lý gói tin vẽ
                                }
                                else
                                {
                                    Packet packet = ParsePacket(client, msg); // Phân tích gói tin
                                    analyzingPacket(client, packet);          // Xử lý gói tin
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
                    UpdateLog?.Invoke($"Client đã ngắt kết nối: {client.tcpClient.Client.RemoteEndPoint}");
                }
            });
        }


        public void StopServer()
        {
            if (!isRunning) return;
            isRunning = false;

            // Đóng tất cả kết nối client
            foreach (var client in clients.ToArray())
            {
                // gửi thông báo đóng kết nối đến client
                sendPacket(client, new DisconnectPacket(""));
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

        private void sendPacket(Models.User client, Packet packet)
        {
            try
            {
                // Kiểm tra loại gói tin và tạo gói tin thích hợp
                if (packet is VerifyOTPRequestPacket verifyPacket)
                {
                    // Gửi gói tin VerifyOTPRequestPacket
                    client.SendPacket(verifyPacket);
                }
                else if (packet is LoginPacket loginPacket)
                {
                    // Gửi gói tin LoginPacket
                    client.SendPacket(loginPacket);
                }
                // Bạn có thể thêm các loại packet khác ở đây nếu cần
                else
                {
                    // Kiểm tra loại packet và gửi gói tin thích hợp
                    string encryptedPayload = Convert.ToBase64String(AES.EncryptAES(packet.Payload));

                    switch (packet.Type)
                    {
                        case PacketType.CREATE_ROOM:
                            client.SendPacket(new CreateRoomPacket(encryptedPayload)); // Tạo gói tin CreateRoomPacket
                            break;
                        case PacketType.JOIN_ROOM:
                            client.SendPacket(new JoinRoomPacket(encryptedPayload)); // Tạo gói tin JoinRoomPacket
                            break;
                        case PacketType.START:
                            client.SendPacket(new StartPacket(encryptedPayload)); // Tạo gói tin StartPacket
                            break;
                        // Thêm các loại packet khác nếu cần
                        default:
                            // Nếu không phải các loại đã kiểm tra, gửi gói tin mặc định
                            client.SendPacket(new GenericPacket(packet.Type, encryptedPayload)); // Gửi gói tin mặc định
                            break;
                    }
                }

                UpdateLog?.Invoke($"Đã gửi Packet cho {client.tcpClient.Client.RemoteEndPoint}");
            }
            catch (SocketException ex)
            {
                UpdateLog?.Invoke("Socket exception: " + ex.Message);

                // Xử lý client bị mất kết nối
                clients.Remove(client);
                client.Stop();
                client.sr?.Close();
                client.sw?.Close();
                UpdateClientList?.Invoke();
            }
        }


        private void sendPacket(Models.User client, DrawPacket drawPacket)
        {
            try
            {
                // Chuẩn bị dữ liệu để gửi
                client.SendPacket(drawPacket);

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

        private void BroadcastPacket(Room room, Packet packet)
        {
            foreach (var client in room.players)
            {
                sendPacket(client, packet);
            }
        }

        private void BroadcastPacket(Room room, DrawPacket drawPacket)
        {
            foreach (var client in room.players)
            {
                try
                {
                    string encryptedPayload = Convert.ToBase64String(AES.EncryptAES(Newtonsoft.Json.JsonConvert.SerializeObject(drawPacket)));
                    sendPacket(client, new DescribePacket(encryptedPayload));
                }
                catch (Exception ex)
                {
                    UpdateLog?.Invoke($"Lỗi khi broadcast DrawPacket: {ex.Message}");
                }
            }
        }


        private Packet ParsePacket(Models.User client, string msg)
        {
            string[] parts = msg.Split(new[] { ';' }, 2, StringSplitOptions.None);
            if (parts.Length < 2) return null;

            string packetType = parts[0];
            string encryptedPayload = parts[1];

            // Giải mã payload
            string decryptedPayload = AES.DecryptAES(Convert.FromBase64String(encryptedPayload));
            UpdateLog?.Invoke($"Payload sau khi giải mã: {decryptedPayload}");

            // Tạo packet từ dữ liệu đã giải mã
            if (Enum.TryParse(packetType, out PacketType type))
            {
                switch (type)
                {
                    case PacketType.LOGIN:
                        return new LoginPacket(decryptedPayload);
                    case PacketType.REGISTER:
                        return new RegisterPacket(decryptedPayload);
                    case PacketType.LOGOUT:
                        return new LogoutPacket(decryptedPayload);
                    case PacketType.RESET_PASSWORD_REQUEST:
                        return new ResetPasswordRequestPacket(decryptedPayload);
                    case PacketType.VERIFY_OTP:
                        // Tách decryptedPayload thành email và otp
                        var payloadParts = decryptedPayload.Split(';');
                        if (payloadParts.Length == 2)
                        {
                            return new VerifyOTPRequestPacket(payloadParts[0], payloadParts[1]); // Chuyển đổi thành hai tham số
                        }
                        return null;
                    case PacketType.RESET_PASSWORD:
                        var resetPasswordParts = decryptedPayload.Split(';');
                        if (resetPasswordParts.Length == 2)
                        {
                            return new ResetPasswordPacket(resetPasswordParts[0], resetPasswordParts[1]);
                        }
                        return null;
                    case PacketType.CREATE_ROOM:
                        return new CreateRoomPacket(decryptedPayload);
                    case PacketType.JOIN_ROOM:
                        return new JoinRoomPacket(decryptedPayload);
                    case PacketType.LEAVE_ROOM:
                        return new LeaveRoomPacket(decryptedPayload);
                    case PacketType.START:
                        return new StartPacket(decryptedPayload);
                    case PacketType.DESCRIBE:
                        return new DescribePacket(decryptedPayload);
                    case PacketType.GUESS:
                        return new GuessPacket(decryptedPayload);
                    case PacketType.DISCONNECT:
                        return new DisconnectPacket(decryptedPayload);
                    case PacketType.PROFILE_REQUEST:
                        return new ProfileRequest(decryptedPayload);
                    case PacketType.PROFILE_UPDATE:
                        return new ProfileUpdatePacket(decryptedPayload);
                    case PacketType.END_GAME:
                        return new EndGamePacket(decryptedPayload);
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
        private void analyzingPacket(Models.User client, Packet packet)
        {
            string clientIP = client.tcpClient.Client.RemoteEndPoint.ToString();
            switch (packet.Type)
            {
                case PacketType.LOGIN:
                    LoginPacket loginPacket = (LoginPacket)packet;
                    if (db.LoginUser(loginPacket.Username, loginPacket.Password))
                    {
                        LoginResultPacket result = new LoginResultPacket("SUCCESS");
                        sendPacket(client, result);
                        UpdateLog?.Invoke($"{loginPacket.Username} đăng nhập thành công");
                        client.Name = loginPacket.Username;
                    }
                    else
                    {
                        LoginResultPacket result = new LoginResultPacket("FAIL");
                        sendPacket(client, result);
                        UpdateLog?.Invoke($"{loginPacket.Username} đăng nhập thất bại");
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
                case PacketType.RESET_PASSWORD_REQUEST:
                    HandleResetPasswordRequest(client, (ResetPasswordRequestPacket)packet);
                    break;

                case PacketType.VERIFY_OTP:
                    HandleVerifyOTP(client, (VerifyOTPRequestPacket)packet);
                    break;

                case PacketType.RESET_PASSWORD:
                    HandleResetPassword(client, (ResetPasswordPacket)packet);
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

                    int currentPlayers = room.players.Count;
                    int currentRound = 0;

                    RoomInfoPacket roomInfo = new RoomInfoPacket($"{roomId};{room.host};{room.status};{maxPlayers};{currentPlayers};{currentRound}");
                    sendPacket(client, roomInfo);

                    OtherInfoPacket otherInfoPacket = new OtherInfoPacket($"{roomId};{client.Name};{client.Score};JOINING");
                    sendPacket(client, otherInfoPacket);

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
                    else if (room.status == "PLAYING")
                    {
                        join_result = "PLAYING";
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
                    else if (room.players.Any(p => p.tcpClient.Client.RemoteEndPoint.ToString() == client.tcpClient.Client.RemoteEndPoint.ToString()))
                    {
                        join_result = "ALREADY_JOINED";
                        sendPacket(client, new JoinResultPacket(join_result));
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
                        roomInfo = new RoomInfoPacket($"{roomIdToJoin};{room.host};{room.status};{room.maxPlayers};{room.players.Count};0");
                        sendPacket(client, roomInfo);

                        //cap nhat thong tin nhung nguoi co trong phong
                        foreach (var player in room.players)
                        {
                            if (player != null && player != client)
                            {
                                OtherInfoPacket otherInfo = new OtherInfoPacket($"{roomIdToJoin};{player.Name};{player.Score};JOINED");
                                sendPacket(client, otherInfo);
                            }
                        }

                        otherInfoPacket = new OtherInfoPacket($"{roomIdToJoin};{client.Name};{client.Score};JOINING");
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
                        client.Score = 0;
                        client.RoomId = "";
                        OtherInfoPacket otherInfo = new OtherInfoPacket($"{roomId};{client.Name};{client.Score};LEAVE");
                        BroadcastPacket(room, otherInfo);
                        if (room.players.Count == 0)
                        {
                            rooms.Remove(room);
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
                        // Gửi thông báo về người vẽ cho tất cả người chơi trong phòng
                        foreach (var user in room.players)
                        {
                            RoundUpdatePacket RoundUpdate = new RoundUpdatePacket($"{roomId};{name};{isdraw};{word};{currentRound}");
                            user.SendPacket( RoundUpdate);
                        }

                        UpdateLog.Invoke($"Phòng {roomId}: Trò chơi bắt đầu. Người vẽ là {room.currentDrawer.Name} và từ khóa là {room.currentKeyword}");
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
                        BroadcastPacket(room, guessPacket);
                        OtherInfoPacket otherInfo = new OtherInfoPacket($"{roomId};{username};{client.Score};GUESS");
                        BroadcastPacket(room, otherInfo);
                        UpdateLog.Invoke($"{username} đã đoán: {msg}");
                    }

                    // check coi ket qua dung ko
                    if (room.CheckAnswer(msg, client))
                    {
                        // gui diem cho client de cap nhat
                        OtherInfoPacket otherInfo = new OtherInfoPacket($"{roomId};{username};{client.Score};GUESS");
                        BroadcastPacket(room, otherInfo);
                    }
                    break;
                case PacketType.END_GAME:
                    EndGamePacket endGamePacket = (EndGamePacket)packet;
                    roomId = endGamePacket.RoomId;
                    room = rooms.FirstOrDefault(r => r.RoomId == roomId);
                    if (room != null)
                    {
                        room.status = "WAITING";
                        UpdateRoomList?.Invoke();
                        BroadcastPacket(room, endGamePacket);
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
                        sendPacket(client, profileResultPacket);
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

        private void HandleDrawPacket(Models.User client, string msg)
        {
            try
            {
                string decryptedMsg = AES.DecryptAES(Convert.FromBase64String(msg));
                DrawPacket drawPacket = Newtonsoft.Json.JsonConvert.DeserializeObject<DrawPacket>(decryptedMsg);

                string roomId = drawPacket.RoomId;
                Room room = rooms.FirstOrDefault(r => r.RoomId == roomId);
                if (room != null)
                {
                    BroadcastPacket(room, drawPacket);
                }
            }
            catch (Exception ex)
            {
                UpdateLog?.Invoke($"Lỗi khi xử lý DrawPacket: {ex.Message}");
            }
        }
        #endregion

        #region fotgot password
        private void HandleResetPassword(Models.User client, ResetPasswordPacket packet)
        {
            string email = packet.Email;
            string newPassword = packet.NewPassword;

            // Mã hóa mật khẩu mới
            string encryptedPassword = Convert.ToBase64String(AES.EncryptAES(newPassword));

            if (db.UpdatePassword(email, encryptedPassword))
            {
                sendPacket(client, new ResetPasswordResultPacket("SUCCESS"));
            }
            else
            {
                sendPacket(client, new ResetPasswordResultPacket("FAIL"));
            }
        }


        private void HandleResetPasswordRequest(Models.User client, ResetPasswordRequestPacket packet)
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
                    sendPacket(client, new ResetPasswordResultPacket("EMAIL_SENT"));
                }
                catch (Exception)
                {
                    sendPacket(client, new ResetPasswordResultPacket("EMAIL_FAIL"));
                }
            }
            else
            {
                sendPacket(client, new ResetPasswordResultPacket("NOT_FOUND"));
            }
        }


        private void HandleVerifyOTP(Models.User client, VerifyOTPRequestPacket packet)
        {
            try
            {
                string email = packet.Email;
                string otp = packet.OTP;

                if (otpStorage.TryGetValue(email, out var storedOtp) && storedOtp == otp)
                {
                    otpStorage.Remove(email); // Xóa OTP sau khi sử dụng

                    // Gửi phản hồi đã mã hóa
                    string responsePayload = Convert.ToBase64String(AES.EncryptAES("OTP_VERIFIED"));
                    sendPacket(client, new ResetPasswordResultPacket(responsePayload));
                }
                else
                {
                    string responsePayload = Convert.ToBase64String(AES.EncryptAES("OTP_FAIL"));
                    sendPacket(client, new ResetPasswordResultPacket(responsePayload));
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
