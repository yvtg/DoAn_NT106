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
        public static Socket serverSocket;
        private bool isRunning;

        public event Action<string> UpdateLog; // cập nhật log trên UI

        #region CONNECT
        public void StartServer()
        {
            if (isRunning) return;

            isRunning = true;

            // Lắng nghe trên cổng 8081
            EndPoint UserServerEP1 = new IPEndPoint(IPAddress.Any, 8081);
            Task.Run(() => InitializeServer(UserServerEP1));

            // Lắng nghe trên cổng 8082
            EndPoint UserServerEP2 = new IPEndPoint(IPAddress.Any, 8082);
            Task.Run(() => InitializeServer(UserServerEP2));
        }

        private async Task InitializeServer(EndPoint ipEP)
        {
            // Khởi tạo socket server
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
            serverSocket.Bind(ipEP);
            serverSocket.Listen(100); // Số lượng kết nối tối đa có thể chờ

            UpdateLog?.Invoke($"UserServer đã khởi động trên {ipEP}. Đang chờ kết nối...");

            // Vòng lặp chấp nhận kết nối liên tục
            while (isRunning)
            {
                // Kiểm tra trạng thái của serverSocket
                if (serverSocket == null || !serverSocket.IsBound)
                {
                    UpdateLog?.Invoke("Socket server đã bị đóng.");
                    break;
                }

                // Chờ kết nối từ client (chính là Server.cs)
                Socket clientSocket = await serverSocket.AcceptAsync();
                UpdateLog?.Invoke($"Đã có kết nối từ {clientSocket.RemoteEndPoint}");

                // Tạo TcpClient từ Socket
                TcpClient tcpClient = new TcpClient { Client = clientSocket };

                // Xử lý kết nối từ client
                HandleClientConnection(tcpClient);
            }
        }


        private void HandleClientConnection(TcpClient tcpClient)
        {
            Task.Run(() =>
            {
                try
                {
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(tcpClient.GetStream()))
                    {
                        while (isRunning && tcpClient.Connected)
                        {
                            string msg = sr.ReadLine();
                            if (!string.IsNullOrEmpty(msg))
                            {
                                UpdateLog?.Invoke($"{tcpClient.Client.RemoteEndPoint}: {msg}");
                            }
                            else break;
                        }
                    }

                }
                catch (OperationCanceledException)
                {
                    // Task bị hủy - không cần làm gì thêm
                }
                finally
                {
                    UpdateLog?.Invoke($"Client đã ngắt kết nối: {tcpClient.Client.RemoteEndPoint}");
                    tcpClient.Close();
                }
            });
        }
        public void StopServer()
        {
            if (!isRunning) return;
            isRunning = false;

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

            UpdateLog?.Invoke("Server đã ngừng hoạt động.");
        }
        #endregion
    }
}