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


namespace Program
{
    public class Client
    {
        TcpClient tcpClient = new TcpClient();
        NetworkStream ns;

        public static event Action RegisterSuccessful;
        public event Action LoginSuccessful;
        public event Action<string, string, int> ReceiveRoomInfo;

        public void Connect()
        {
            try
            {
                IPAddress ipServer = IPAddress.Parse("127.0.0.1");
                IPEndPoint ipEP = new IPEndPoint(ipServer, 8080);
                tcpClient.Connect(ipEP);
                Task.Run(() => ReceiveData());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kết nối: " + ex.Message);
            }
        }

        public void Stop()
        {
            if (tcpClient != null && tcpClient.Connected)
            {
                try
                {
                    tcpClient.Client.Shutdown(SocketShutdown.Both); // Ngắt kết nối
                    tcpClient.Close(); // Giải phóng tài nguyên
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi đóng kết nối socket: {ex.Message}");
                }
                finally
                {
                    tcpClient = null;
                }
            }
        }

        public void SendPacket(Packet packet)
        {
            if (tcpClient != null && tcpClient.Connected)
            {
                try
                {
                    ns = tcpClient.GetStream();
                    byte[] byteData = packet.ToBytes();
                    ns.Write(byteData, 0, byteData.Length);
                    ns.Flush(); // Ensure all data is sent
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi gửi dữ liệu: " + ex.Message); // Error sending data
                }
            }
            else
            {
                MessageBox.Show("Client không kết nối với server."); // Client is not connected to the server
            }
        }


        public void ReceiveData()
        {
            try
            {
                ns = tcpClient.GetStream();
                byte[] byteData = new byte[1024];
                int byteRec;

                while ((byteRec = ns.Read(byteData, 0, byteData.Length)) != 0)
                {
                    string data = Encoding.ASCII.GetString(byteData, 0, byteRec);
                    Packet packet = ParsePacket(data);
                    AnalyzingPacket(packet);
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
                    default:
                        return null; // Không biết loại packet
                }
            }
            return null;
        }

        private void AnalyzingPacket(Packet packet)
        {
            switch (packet.Type)
            {
                case PacketType.LOGIN_RESULT:
                    LoginResultPacket loginResultPacket = (LoginResultPacket)packet;
                    if (loginResultPacket.result == "success")
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
                    if (registerResultPacket.result== "success")
                    {
                        MessageBox.Show("Đăng ký thành công");
                        RegisterSuccessful?.Invoke();
                    }
                    else
                    {
                        MessageBox.Show("Username đã tồn tại!");
                    }
                    break;
                case PacketType.ROOM_INFO:
                    RoomInfoPacket roomInfoPacket = (RoomInfoPacket)packet;
                    string roomId = roomInfoPacket.RoomId;
                    string host = roomInfoPacket.Host;
                    string status = roomInfoPacket.Status;
                    int playerCount = roomInfoPacket.CurrentPlayers;
                    int maxPlayer = roomInfoPacket.MaxPlayers;
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
                    break;
                case PacketType.ROUND_UPDATE:
                    break;
                case PacketType.GUESS_RESULT:
                    break;
                case PacketType.LEADER_BOARD_INFO:
                    break;
                default:
                    break;
            }
        }

    }
}
