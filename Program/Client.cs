using System;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Windows.Forms;
using Models;
using System.IO;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


namespace Program
{
    public class Client
    {
        TcpClient tcpClient = new TcpClient();
        NetworkStream ns;
        StreamWriter sw;
        StreamReader sr;

        public static event Action RegisterSuccessful; // đăng kí thành công
        public event Action LoginSuccessful; // đăng nhập thành công
        public event Action<string, string, int> ReceiveRoomInfo; // nhận thông tin phòng
        public event Action<string, string, string> ReceiveMessage; // nhận message trong phòng (guess)
        public event Action<string, string, int, string> ReceiveOtherInfo; // nhận thông tin của người chơi khác trong phòng
        public event Action<RoundUpdatePacket> RoundUpdateReceived; // round mới
        public event Action<DrawPacket> DrawPacketReceived; // nhận draw packet
        public event Action<string> EndGameReceived;
        public event Action<ProfileResultPacket> ProfileReceived; // nhận thông tin profile
        public event Action ServerDisconnected; // server ngắt kết nối
        public event Action<string> ResetPasswordResult;
        CancellationTokenSource cancellationTokenSource;

        public bool Connect(string serverIP, int port)
        {
            try
            {
                IPAddress ipServer = IPAddress.Parse(serverIP);
                IPEndPoint ipEP = new IPEndPoint(ipServer, port); 
                tcpClient.Connect(ipEP);
                cancellationTokenSource = new CancellationTokenSource();
                var token = cancellationTokenSource.Token;
                Task.Run(() =>
                {
                    while (!token.IsCancellationRequested)
                    {
                        ReceiveData();
                    }
                }, token);
                return true;
            }
            catch (Exception ex)
            {
                ShowMessage("Lỗi khi kết nối: " + ex.Message);
                return false;
            }
        }


        // gửi draw packet ( dạng json )
        public void SendDrawPacket(DrawPacket drawPacket)
        {
            if (tcpClient != null && tcpClient.Connected)
            {
                try
                {
                    // Nếu NetworkStream chưa được khởi tạo, hãy khởi tạo
                    if (ns == null)
                    {
                        ns = tcpClient.GetStream();
                        sw = new StreamWriter(ns);
                    }

                    string jsonPacket = Newtonsoft.Json.JsonConvert.SerializeObject(drawPacket);

                    // gửi dữ liệu
                    sw.WriteLine(jsonPacket);
                    Console.WriteLine(jsonPacket);
                    sw.Flush();
                }
                catch (Exception ex)
                {
                    ShowMessage("Lỗi khi gửi dữ liệu: " + ex.Message);
                }
            }
            else
            {
                ShowMessage("Client không kết nối với server.");
            }
        }

        // send packet bình thường
        // Ví dụ về gửi một gói dữ liệu
        public void SendPacket(Packet packet)
        {
            if (tcpClient != null && tcpClient.Connected)
            {
                try
                {
                    if (sw == null)
                    {
                        ns = tcpClient.GetStream();
                        sw = new StreamWriter(ns);
                    }

                    // Mã hóa payload
                    byte[] encryptedBytes = AES.EncryptAES(packet.Payload);
                    string encryptedPayload = Convert.ToBase64String(encryptedBytes);
                    encryptedPayload = EnsureValidBase64Padding(encryptedPayload);

                    string encryptedPacket = packet.Type + ";" + encryptedPayload;

                    Console.WriteLine($"Gửi Packet (mã hóa): {encryptedPacket}");

                    // Gửi dữ liệu đã mã hóa
                    sw.WriteLine(encryptedPacket);
                    sw.Flush();
                }
                catch (Exception ex)
                {
                    ShowMessage("Lỗi khi gửi dữ liệu: " + ex.Message);
                }
            }
            else
            {
                ShowMessage("Client không kết nối với server.");
            }
        }

        private string EnsureValidBase64Padding(string str)
        {
            int padding = str.Length % 4;
            if (padding == 2)
            {
                str += "==";
            }
            else if (padding == 3)
            {
                str += "=";
            }
            return str;
        }

        public void ReceiveData()
        {
            try
            {
                ns = tcpClient.GetStream();
                sr = new StreamReader(ns);

                while (tcpClient.Connected)
                {
                    string receivedData = sr.ReadLine();
                    Console.WriteLine($"Nhận Packet (mã hóa): {receivedData}");

                    if (!string.IsNullOrEmpty(receivedData))
                    {
                        string[] parts = receivedData.Split(new[] { ';' }, 2, StringSplitOptions.None);
                        if (parts.Length < 2) continue;

                        string packetType = parts[0];
                        string encryptedPayload = parts[1];

                        // Kiểm tra Base64 trước khi giải mã
                        if (IsBase64String(encryptedPayload))
                        {
                            encryptedPayload = EnsureValidBase64Padding(encryptedPayload);

                            try
                            {
                                string decryptedPayload = AES.DecryptAES(Convert.FromBase64String(encryptedPayload));
                                Console.WriteLine($"Giải mã Payload: {decryptedPayload}");

                                Packet packet = ParsePacket(packetType + ";" + decryptedPayload);
                                if (packet != null)
                                {
                                    AnalyzingPacket(packet);
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Lỗi khi giải mã payload: {ex.Message}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Payload không phải Base64 hợp lệ.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi khởi tạo luồng: {ex.Message}");
            }
        }


        private bool IsBase64String(string str)
        {
            try
            {
                str = str.Replace("\n", "").Replace("\r", "").Trim();
                Convert.FromBase64String(str);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private Packet ParsePacket(string msg)
        {
            string[] payload = msg.Split(new[] { ';' }, 2, StringSplitOptions.None);
            if (payload.Length < 2) return null;

            string packetType = payload[0];
            string remainingMsg = payload[1];

            if (Enum.TryParse(packetType, out PacketType type))
            {
                switch (type)
                {
                    case PacketType.LOGIN_RESULT:
                        return new LoginResultPacket(remainingMsg);
                    case PacketType.REGISTER_RESULT:
                        return new RegisterResultPacket(remainingMsg);
                    case PacketType.RESET_PASSWORD_RESULT:
                        return new ResetPasswordResultPacket(remainingMsg);
                    case PacketType.ROOM_INFO:
                        return new RoomInfoPacket(remainingMsg);
                    case PacketType.OTHER_INFO:
                        return new OtherInfoPacket(remainingMsg);
                    case PacketType.ROUND_UPDATE:
                        return new RoundUpdatePacket(remainingMsg);
                    case PacketType.GUESS_RESULT:
                        return new GuessResultPacket(remainingMsg);
                    case PacketType.LEADER_BOARD_INFO:
                        return new LeaderBoardInfoPacket(remainingMsg);
                    case PacketType.JOIN_RESULT:
                        return new JoinResultPacket(remainingMsg);
                    case PacketType.GUESS:
                        return new GuessPacket(remainingMsg);
                    case PacketType.PROFILE_RESULT:
                        return new ProfileResultPacket(remainingMsg);
                    case PacketType.DISCONNECT:
                        return new DisconnectPacket(remainingMsg);
                    case PacketType.END_GAME:
                        return new EndGamePacket(remainingMsg);
                    default:
                        HandleDrawPacket(msg);
                        break;
                }
            }

            return null;
        }


        private void AnalyzingPacket(Packet packet)
        {
            string roomId, host, status = "";
            int playerCount, maxPlayer, score = 0;
            switch (packet.Type)
            {
                case PacketType.LOGIN_RESULT:
                    LoginResultPacket loginResultPacket = (LoginResultPacket)packet;
                    if (loginResultPacket.result == "SUCCESS")
                    {
                        LoginSuccessful?.Invoke();
                    }
                    else
                    {
                        ShowMessage("Kiểm tra username hoặc mật khẩu và thử lại!");
                    }
                    break;
                case PacketType.REGISTER_RESULT:
                    RegisterResultPacket registerResultPacket = (RegisterResultPacket)packet;
                    if (registerResultPacket.result== "SUCCESS")
                    {
                        ShowMessage("Đăng ký thành công");
                        RegisterSuccessful?.Invoke();
                    }
                    else
                    {
                        ShowMessage("Username đã tồn tại!");
                    }
                    break;
                case PacketType.RESET_PASSWORD_RESULT:
                    ResetPasswordResultPacket resultPacket = (ResetPasswordResultPacket)packet;
                    switch (resultPacket.Status)
                    {
                        case "EMAIL_SENT":
                            ShowMessage("Mã OTP đã được gửi tới email của bạn!");
                            ResetPasswordResult.Invoke("EMAIL_SENT");
                            break;
                        case "EMAIL_FAIL":
                            ShowMessage("Lỗi khi gửi email!");
                            break;
                        case "NOT_FOUND":
                            ShowMessage("Email không tồn tại!");
                            break;
                        case "OTP_VERIFIED":
                            ResetPasswordResult?.Invoke("OTP_VERIFIED");
                            break;
                        case "OTP_FAIL":
                            ShowMessage("Mã OTP không chính xác! Vui lòng thử lại");
                            break;
                        case "SUCCESS":
                            ShowMessage("Đặt lại mật khẩu thành công!");
                            ResetPasswordResult?.Invoke("SUCCESS");
                            break;
                        case "FAIL":
                            ShowMessage("Lỗi khi đặt lại mật khẩu!");
                            break;
                    }
                    break;
                case PacketType.ROOM_INFO:
                    RoomInfoPacket roomInfoPacket = (RoomInfoPacket)packet;
                    roomId = roomInfoPacket.RoomId;
                    host = roomInfoPacket.Host;
                    status = roomInfoPacket.Status;
                    playerCount = roomInfoPacket.CurrentPlayers;
                    maxPlayer = roomInfoPacket.MaxPlayers;
                    ReceiveRoomInfo?.Invoke(roomId, host, maxPlayer);
                    break;
                case PacketType.JOIN_RESULT:
                    JoinResultPacket joinResultPacket = (JoinResultPacket)packet;
                    string result = joinResultPacket.result;
                    switch (result)
                    {
                        case "NOT_EXIST":
                            ShowMessage("Phòng không tồn tại!");
                            break;
                        case "PLAYING":
                            ShowMessage("Phòng đang chơi!");
                            break;
                        case "FULL":
                            ShowMessage("Phòng đã đầy!");
                            break;
                        case "FINISHED":
                            ShowMessage("Phòng đã kết thúc!");
                            break;
                    }
                    break;
                case PacketType.OTHER_INFO:
                    OtherInfoPacket otherInfoPacket = (OtherInfoPacket)packet;
                    roomId = otherInfoPacket.RoomId;
                    string username = otherInfoPacket.playerName;
                    score = otherInfoPacket.Score;
                    status = otherInfoPacket.Status;

                    if (status == "JOINING" || status == "JOINED")
                    {
                        ReceiveMessage?.Invoke(roomId, username, "đã tham gia phòng");
                    }
                    else if (status == "LEAVE")
                    {
                        ReceiveMessage?.Invoke(roomId, username, "đã rời phòng");
                    }   

                    ReceiveOtherInfo?.Invoke(roomId, username, score, status);
                    break;
                case PacketType.ROUND_UPDATE:
                     RoundUpdatePacket roundUpdatePacket = (RoundUpdatePacket)packet;
                     RoundUpdateReceived?.Invoke(roundUpdatePacket);
                    break;
                case PacketType.GUESS:
                    GuessPacket guessPacket = (GuessPacket)packet;
                    roomId = guessPacket.RoomId;
                    username = guessPacket.playerName;
                    string guess = guessPacket.GuessMessage;
                    ReceiveMessage?.Invoke(roomId, username, guess);
                    break;
                case PacketType.END_GAME:
                    EndGamePacket endGamePacket = (EndGamePacket)packet;
                    roomId = endGamePacket.RoomId;
                    EndGameReceived?.Invoke(roomId);
                    break;
                case PacketType.PROFILE_RESULT:
                    ProfileResultPacket profileResult = (ProfileResultPacket)packet;
                    ProfileReceived?.Invoke(profileResult);
                    break;
                case PacketType.DISCONNECT:
                    ShowMessage("Server đã đóng kết nối!");
                    ServerDisconnected?.Invoke();
                    tcpClient.Close();
                    Application.Exit();
                    break;
                default:
                    break;
            }
        }

        private void HandleDrawPacket(string msg)
        {
            DrawPacket drawPacket = Newtonsoft.Json.JsonConvert.DeserializeObject<DrawPacket>(msg);
            DrawPacketReceived?.Invoke(drawPacket);
        }

        public void ShowMessage(string messsage)
        {
            Form_Message formmessage = new Form_Message(messsage);
            formmessage.StartPosition = FormStartPosition.Manual;
            formmessage.BringToFront();
            formmessage.ShowDialog();
        }
        public void HandleMessageReceived(string encryptedMessage)
        {
            try
            {
                // Giải mã tin nhắn
                string decryptedMessage = AES.DecryptAES(Convert.FromBase64String(encryptedMessage));
                Console.WriteLine($"Tin nhắn giải mã: {decryptedMessage}");

                string[] messageParts = decryptedMessage.Split(';');

                if (messageParts.Length >= 3)
                {
                    string roomId = messageParts[0];
                    string username = messageParts[1];
                    string message = messageParts[2];

                    // Thực hiện các hành động với tin nhắn đã giải mã
                    ReceiveMessage?.Invoke(roomId, username, message);
                }
                else
                {
                    Console.WriteLine("Tin nhắn không hợp lệ.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi giải mã tin nhắn: {ex.Message}");
            }
        }



        // Gửi yêu cầu mã OTP
        public void SendResetPasswordRequest(string email)
        {
            ResetPasswordRequestPacket requestPacket = new ResetPasswordRequestPacket(email);
            SendPacket(requestPacket);
        }

        // Gửi yêu cầu xác thực OTP
        public void SendVerifyOTPRequest(string email, string otp)
        {
            VerifyOTPRequestPacket otpPacket = new VerifyOTPRequestPacket(email, otp);
            SendPacket(otpPacket);
        }

        // Gửi yêu cầu đặt lại mật khẩu
        public void SendResetPassword(string email, string newPassword)
        {
            string encryptedPassword = Convert.ToBase64String(AES.EncryptAES(newPassword));

            ResetPasswordPacket resetPacket = new ResetPasswordPacket(email, encryptedPassword);
            SendPacket(resetPacket);
        }
        public void HandleOTPResponse(string encryptedPayload, string email)
        {
            try
            {
                // Giải mã payload từ server
                string decryptedPayload = AES.DecryptAES(Convert.FromBase64String(encryptedPayload));
                Console.WriteLine($"Kết quả từ server: {decryptedPayload}");

                if (decryptedPayload == "OTP_VERIFIED")
                {
                    Console.WriteLine("OTP đã được xác thực thành công.");

                    // Gọi form reset mật khẩu
                    ShowResetPasswordForm(email);
                }
                else if (decryptedPayload == "OTP_FAIL")
                {
                    Console.WriteLine("OTP không hợp lệ.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi xử lý phản hồi OTP: {ex.Message}");
            }
        }


        private void ShowResetPasswordForm(string email)
        {
            Form_Reset_Password resetPasswordForm = new Form_Reset_Password(email); // Sử dụng this.email
            resetPasswordForm.ShowDialog();
        }

        public void SendLoginRequest(string username, string password)
        {
            // Mã hóa mật khẩu
            string payload = $"{username};{password}";

            // Tạo đối tượng LoginPacket với payload
            LoginPacket loginRequestPacket = new LoginPacket(payload);

            // Gửi packet
            SendPacket(loginRequestPacket);
        }
        public void SendRegisterRequest(string username, string password, string email)
        {
            // Mã hóa mật khẩu
            string encryptedPassword = Convert.ToBase64String(AES.EncryptAES(password));

            // Tạo payload theo định dạng: username;email;encryptedPassword
            string payload = $"{username};{email};{encryptedPassword}";

            // Tạo đối tượng RegisterPacket với payload
            RegisterPacket registerRequestPacket = new RegisterPacket(payload);

            // Gửi packet
            SendPacket(registerRequestPacket);
        }



    }
}
