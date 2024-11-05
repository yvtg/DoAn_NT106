using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class Server
    {
        public static Socket serverSocket;
        public static List<Socket> connectedClients = new List<Socket>();
        public static List<User> connectedUsers = new List<User>();
        public List<Room> rooms = new List<Room>();
        public Action<string> UpdateLog; // Delegate để cập nhật log trên UI
        private bool isRunning;

        public Server(Action<string> updateLog)
        {
            UpdateLog = updateLog;
            Thread serverThread = new Thread(StartServer) { IsBackground = true };
            serverThread.Start();
        }

        private void StartServer()
        {
            try
            {
                const string SERVER_IPADDRESS = "127.0.0.1";
                const int SERVER_PORT = 11000;
                IPAddress ipAddr = IPAddress.Parse(SERVER_IPADDRESS);
                IPEndPoint ipEP = new IPEndPoint(ipAddr, SERVER_PORT);

                //khoi tao server
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Bind(ipEP);
                serverSocket.Listen(10);
                isRunning = true;

                UpdateLog?.Invoke("Chờ người chơi kết nối...");

                //chap nhan ket noi client trong luong rieng
                Thread acceptThread = new Thread(AcceptClient);
                acceptThread.Start();
            }
            catch (Exception ex)
            {
                UpdateLog?.Invoke("Lỗi khi khởi tạo server: " + ex.Message);
            }
        }

        private void AcceptClient()
        {
            while (isRunning)
            {
                try
                {
                    // them vao danh sach client da ket noi toi server
                    var clientSocket = serverSocket.Accept();
                    connectedClients.Add(clientSocket);

                    UpdateLog?.Invoke("Đã kết nối với client: " + clientSocket.RemoteEndPoint);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi kết nối với client: " + ex.Message);
                }
            }
        }

        private void receiveData(Socket client)
        {
            try
            {
                User player = new User(client);
                connectedUsers.Add(player);
                byte[] buffer = new byte[1024];

                while (player.UserSocket.Connected)
                {
                    int receivedBytes = player.UserSocket.Receive(buffer);
                    if (receivedBytes > 0)
                    {
                        // Chuyển đổi dữ liệu nhận được thành chuỗi
                        string msg = Encoding.UTF8.GetString(buffer, 0, receivedBytes);
                        UpdateLog?.Invoke($"Nhận dữ liệu từ {client.RemoteEndPoint}: {msg}");

                        // Phân tích cú pháp packet từ chuỗi nhận được
                        Packet packet = ParsePacket(msg);
                        if (packet != null)
                        {
                            analyzingPacket(packet, player);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                UpdateLog?.Invoke($"Lỗi nhận dữ liệu từ {client.RemoteEndPoint}: {ex.Message}");
            }
            finally
            {
                connectedClients.Remove(client);
                client.Close();
                UpdateLog?.Invoke($"Đã ngắt kết nối với {client.RemoteEndPoint}");
            }
        }


        private void sendData(Socket client, Packet packet)
        {
            if (packet == null) return; 

            try
            {
                byte[] buffer = packet.ToBytes();
                client.Send(buffer);
            }
            catch (Exception ex)
            {
                UpdateLog?.Invoke($"Lỗi khi gửi dữ liệu tới {client.RemoteEndPoint}: {ex.Message}");
            }
        }

        private Packet ParsePacket(string msg)
        {
            string[] payload = msg.Split(';');
            if (payload.Length == 0)
            {
                return null; // Không có dữ liệu
            }

            // Xác định loại packet dựa trên phần tử đầu tiên
            PacketType packetType;
            if (Enum.TryParse(payload[0], out packetType))
            {
                switch (packetType)
                {
                    case PacketType.LOGIN:
                        return new LoginPacket(msg);
                    case PacketType.REGISTER:
                        return new RegisterPacket(msg);
                    case PacketType.LOGOUT:
                        return new LogoutPacket(msg);
                    case PacketType.CREATE_ROOM:
                        return new CreateRoomPacket(msg);
                    case PacketType.JOIN_ROOM:
                        return new JoinRoomPacket(msg);
                    case PacketType.LEAVE_ROOM:
                        return new LeaveRoomPacket(msg);
                    case PacketType.START:
                        return new StartPacket(msg);
                    case PacketType.DESCRIBE:
                        return new DescribePacket(msg);
                    case PacketType.GUESS:
                        return new GuessPacket(msg);
                    default:
                        return null; // Không biết loại packet
                }
            }
            return null; 
        }


        // xu ly sau khi nhan du lieu tu client
        private void analyzingPacket(Packet packet, User player)
        {
            switch (packet.Type)
            {
                case PacketType.LOGIN:
                    break;
                case PacketType.REGISTER:
                   
                    break;
                case PacketType.LOGOUT:
                    
                    break;
                case PacketType.CREATE_ROOM:
                    break;
                case PacketType.JOIN_ROOM:
                    break;
                case PacketType.LEAVE_ROOM:
                    break;
                case PacketType.START:
                    break;
                case PacketType.DESCRIBE:
                    break;
                case PacketType.GUESS:
                    break;
                default:
                    break;
            }
        }




        public void StopServer()
        {
            serverSocket.Close();
            foreach (var client in connectedClients)
            {
                client.Close();
            }
        }

    }
}
