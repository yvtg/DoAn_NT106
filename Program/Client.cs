using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using System.Net.Http;
using Models;
using Azure.Identity;
using System.IO;
using MongoDB.Bson.IO;
using SharpCompress.Writers;
using System.Messaging;
using Newtonsoft.Json;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Interop;


namespace Program
{
    public class Client
    {
        TcpClient tcpClient = new TcpClient();
        NetworkStream ns;
        StreamWriter sw;
        StreamReader sr;

        public static event Action RegisterSuccessful;
        public event Action LoginSuccessful;
        public event Action ResetPasswordSuccessful;
        public event Action<string, string, int> ReceiveRoomInfo;
        public event Action<string, string, string> ReceiveMessage;
        public event Action<string, string, int, string> ReceiveOtherInfo;
        public event Action<RoundUpdatePacket> RoundUpdateReceived;
        public event Action<SyncBitmapPacket> SyncBitmapReceived;
        public event Action<DrawPacket> DrawPacketReceived;


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

        // send draw packet
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
                    MessageBox.Show("Lỗi khi gửi dữ liệu: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Client không kết nối với server.");
            }
        }

        // send packet binh thuong
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
                    // Thông báo lỗi nếu có ngoại lệ xảy ra
                    MessageBox.Show("Lỗi khi gửi dữ liệu: " + ex.Message); // Error sending data
                }
            }
            else
            {
                // Thông báo lỗi nếu client không kết nối với server
                MessageBox.Show("Client không kết nối với server."); // Client is not connected to the server
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
                            MessageBox.Show("Lỗi khi nhận dữ liệu: " + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi nhận dữ liệu: " + ex.Message);
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
                        MessageBox.Show("Kiểm tra username hoặc mật khẩu và thử lại!");
                    }
                    break;
                case PacketType.REGISTER_RESULT:
                    RegisterResultPacket registerResultPacket = (RegisterResultPacket)packet;
                    if (registerResultPacket.result== "SUCCESS")
                    {
                        MessageBox.Show("Đăng ký thành công");
                        RegisterSuccessful?.Invoke();
                    }
                    else
                    {
                        MessageBox.Show("Username đã tồn tại!");
                    }
                    break;
                case PacketType.RESET_PASSWORD_RESULT:
                    ResetPasswordResultPacket resultPacket = (ResetPasswordResultPacket)packet;
                    if (resultPacket.Status == "success")
                    {
                        MessageBox.Show("Mật khẩu đã được thay đổi thành công.");
                        ResetPasswordSuccessful?.Invoke();
                    }
                    else
                    {
                        MessageBox.Show("Không thể thay đổi mật khẩu. Vui lòng thử lại.");
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
                            MessageBox.Show("Phòng không tồn tại!");
                            break;
                        case "PLAYING":
                            MessageBox.Show("Phòng đang chơi!");
                            break;
                        case "FULL":
                            MessageBox.Show("Phòng đã đầy!");
                            break;
                        case "FINISHED":
                            MessageBox.Show("Phòng đã kết thúc!");
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
