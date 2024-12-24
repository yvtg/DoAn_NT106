using System;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Windows.Forms;
using Models;
using System.IO;


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
        public event Action ResetPasswordSuccessful; // reset password thành công
        public event Action<string, string, int> ReceiveRoomInfo; // nhận thông tin phòng
        public event Action<string, string, string> ReceiveMessage; // nhận message trong phòng (guess)
        public event Action<string, string, int, string> ReceiveOtherInfo; // nhận thông tin của người chơi khác trong phòng
        public event Action<RoundUpdatePacket> RoundUpdateReceived; // round mới
        public event Action<DrawPacket> DrawPacketReceived; // nhận draw packet

        // kết nối tới server
        public bool Connect(string serverIP, int port)
        {
            try
            {
                IPAddress ipServer = IPAddress.Parse(serverIP);
                IPEndPoint ipEP = new IPEndPoint(ipServer, port); 
                tcpClient.Connect(ipEP);
                Task.Run(() => ReceiveData());
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
        public void SendPacket(Packet packet)
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

                    // Gửi dữ liệu
                    sw.WriteLine(packet.Type + ";" + packet.Payload);
                    Console.WriteLine(packet.Type + ";" + packet.Payload);
                    sw.Flush();
                }
                catch (Exception ex)
                {
                    // Lỗi gửi dữ liệu
                    ShowMessage("Lỗi khi gửi dữ liệu: " + ex.Message);
                }
            }
            else
            {
                // Thông báo lỗi nếu client không kết nối với server
                ShowMessage("Client không kết nối với server.");
            }
        }


        public void ReceiveData()
        {
            try
            {
                ns = tcpClient.GetStream();
                sw = new StreamWriter(ns);
                sr = new StreamReader(ns);

                // Đọc dữ liệu trong khi kết nối vẫn còn mở
                while (tcpClient.Connected)
                {
                    while (tcpClient.Available > 0)
                    {
                        string receivedData = "";
                        try
                        {
                            receivedData = sr.ReadLine();
                            Console.WriteLine(receivedData);
                            if (!string.IsNullOrEmpty(receivedData))
                            {
                                if (receivedData.StartsWith("{") && receivedData.EndsWith("}"))
                                {
                                    HandleDrawPacket(receivedData);
                                }
                                else
                                {
                                    Packet packet = ParsePacket(receivedData);
                                    AnalyzingPacket(packet);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            ShowMessage("Lỗi khi nhận dữ liệu: " + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessage("Lỗi khi nhận dữ liệu: " + ex.Message);
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
                    if (resultPacket.Status == "success")
                    {
                        ShowMessage("Mật khẩu đã được thay đổi thành công.");
                        ResetPasswordSuccessful?.Invoke();
                    }
                    else
                    {
                        ShowMessage("Không thể thay đổi mật khẩu. Vui lòng thử lại.");
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
                case PacketType.GUESS_RESULT:
                    break;
                case PacketType.LEADER_BOARD_INFO:
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
            formmessage.ShowDialog();
        }

    }
}
