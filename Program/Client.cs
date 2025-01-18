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
using System.Collections.Specialized;


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
        public event Action<string, string, int, bool> ReceiveRoomInfo; // nhận thông tin phòng
        public event Action<string, string, string> ReceiveMessage; // nhận message trong phòng (guess)
        public event Action<string, string, int, string> ReceiveOtherInfo; // nhận thông tin của người chơi khác trong phòng
        public event Action<RoundUpdatePacket> RoundUpdateReceived; // round mới
        public event Action<DrawPacket> DrawPacketReceived; // nhận draw packet
        public event Action<string> EndGameReceived;
        public event Action<ProfileResultPacket> ProfileReceived; // nhận thông tin profile
        public event Action ServerDisconnected; // server ngắt kết nối
        public event Action<string> ResetPasswordResult;
        public event Action<string> HostChanged;
        public event Action<string, int> RedirectReceived;
        public static event Action ServerInvalid;
        CancellationTokenSource cancellationTokenSource;

        public bool connectStatus = false;

        public bool Connect(string serverIP, int port)
        {
            try
            {
                connectStatus = true;
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
                connectStatus = false;
                tcpClient.Close();
                Application.Exit();
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
                    string msg = packet.Type + ";" + packet.Payload;
                    byte[] encryptedBytes = AES.EncryptAES(msg);
                    string encryptedPayload = Convert.ToBase64String(encryptedBytes);

                    // Gửi dữ liệu đã mã hóa
                    sw.WriteLine(encryptedPayload);
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
                connectStatus = false;
                tcpClient.Close();
                Application.Exit();
            }
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

                    try
                    {

                        if (!string.IsNullOrEmpty(receivedData))
                        {
                            if (receivedData.StartsWith("{") && receivedData.EndsWith("}"))
                            {
                                HandleDrawPacket( receivedData); // Xử lý gói tin vẽ
                            }
                            else
                            {
                                string decryptedPayload = AES.DecryptAES(Convert.FromBase64String(receivedData));
                                Console.WriteLine($"Giải mã Payload: {decryptedPayload}");
                                Packet packet = ParsePacket(decryptedPayload); // Phân tích gói tin
                                AnalyzingPacket(packet);          // Xử lý gói tin
                            }
                        }
                        else break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Lỗi khi giải mã payload: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi khởi tạo luồng: {ex.Message}");
            }
        }

        private Packet ParsePacket(string msg)
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
                    case PacketType.CONNECT:
                        return new ConnectPacket(remainingMsg);
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
            bool isblindround = false;
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
                    if (registerResultPacket.result == "SUCCESS")
                    {
                        ShowMessage("Đăng ký thành công");
                        RegisterSuccessful?.Invoke();
                    }
                    else
                    {
                        ShowMessage("Username hoặc email đã tồn tại! (hoặc email không hợp lệ)");
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
                    isblindround = roomInfoPacket.isblindround;
                    if (roomInfoPacket.Status == "HOST_CHANGED")
                    {
                        HostChanged?.Invoke(roomInfoPacket.Host);
                    }
                    else ReceiveRoomInfo?.Invoke(roomId, host, maxPlayer,isblindround);
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
                    connectStatus = false;
                    ServerDisconnected?.Invoke();
                    tcpClient.Close();
                    Application.Exit();
                    break;
                case PacketType.CONNECT:
                    ConnectPacket redirectPacket = (ConnectPacket)packet;
                    string ip = redirectPacket.IP;
                    int port = redirectPacket.Port;
                    if (ip == "NULL")
                    {
                        ServerInvalid?.Invoke();
                        connectStatus = false;
                        tcpClient.Close();
                        Application.Exit();
                    }
                    else
                    {
                        RedirectReceived?.Invoke(ip, port);
                    }
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
            ResetPasswordPacket resetPacket = new ResetPasswordPacket(email, newPassword);
            SendPacket(resetPacket);
        }

    }
}
