using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Server
{
    public class UserServer
    {
        private Dictionary<string, string> otpStorage = new Dictionary<string, string>(); // Email -> OTP mapping
        public static Socket serverSocket;
        public List<Models.User> clients = new List<Models.User>(); // danh sách client đang kết nối tới
        public List<Room> rooms = new List<Room>(); // danh sách phòng chơi đang có

        private static string connectionString = "mongodb+srv://admin1:5VGZBpaXfZC15LPN@cluster0.qq9lk.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
        DataAccess.DatabaseHelper db = new DataAccess.DatabaseHelper(connectionString, "Datagame");

        private bool isRunning;

        public event Action<string> UpdateLog; // cập nhật log trên UI
        public event Action UpdateClientList; // cập nhật danh sách client trên UI

        #region CONNECT
        public void StartServer()
        {
            if (isRunning) return;

            isRunning = true;

            EndPoint UserServerEP1 = new IPEndPoint(IPAddress.Any, 8081);
            Task.Run(() => InitializeServer(UserServerEP1));

            EndPoint UserServerEP2 = new IPEndPoint(IPAddress.Any, 8082);
            Task.Run(() => InitializeServer(UserServerEP2));
        }

        private async Task InitializeServer(EndPoint ipEP)
        {

            // Khởi tạo server
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
            serverSocket.Bind(ipEP);
            serverSocket.Listen(100);

            UpdateLog?.Invoke($"Server đã khởi động trên {ipEP}. Đang chờ kết nối...");

            while (isRunning)
            {
                // Kiểm tra trạng thái của serverSocket
                if (serverSocket == null || !serverSocket.IsBound)
                {
                    UpdateLog?.Invoke("Socket server đã bị đóng.");
                    break;
                }

                // Chờ kết nối từ server chính
                Socket mainServer = serverSocket;
                HandleServerConnection(mainServer);
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

                        string msg = client.sr.ReadLine(); // Đọc dữ liệu từ client

                        if (!string.IsNullOrEmpty(msg))
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
                        else break;
                    }
                }
                catch (OperationCanceledException)
                {
                    // Task bị hủy - không cần làm gì thêm
                }
                finally
                {
                    // đóng kết nối client
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

    }
}
