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
    public class RoomServer
    {
        public static Socket serverSocket;
        private bool isRunning;
        public event Action<string> UpdateLog;

        #region CONNECT
        public void StartServer()
        {
            if (isRunning) return;
            isRunning = true;

            // Lắng nghe trên cổng 8083
            EndPoint roomServerEP1 = new IPEndPoint(IPAddress.Any, 8083);
            Task.Run(() => InitializeServer(roomServerEP1));

            // Lắng nghe trên cổng 8084
            EndPoint roomServerEP2 = new IPEndPoint(IPAddress.Any, 8084);
            Task.Run(() => InitializeServer(roomServerEP2));

        }

        private async Task InitializeServer(EndPoint ipEP)
        {
            // Khởi tạo socket server
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
            serverSocket.Bind(ipEP);
            serverSocket.Listen(100);

            UpdateLog?.Invoke($"RoomServer đã khởi động trên {ipEP}. Đang chờ kết nối từ Server chính...");

            while (isRunning)
            {
                // Kiểm tra trạng thái của serverSocket
                if (serverSocket == null || !serverSocket.IsBound)
                {
                    UpdateLog?.Invoke("Socket server đã bị đóng.");
                    break;
                }
                // Chờ kết nối từ server chính
                Socket mainServerSocket = await serverSocket.AcceptAsync();
                UpdateLog?.Invoke($"Đã có kết nối từ Server chính: {mainServerSocket.RemoteEndPoint}");

                // Xử lý kết nối từ server chính
                HandleMainServerConnection(mainServerSocket);
            }
        }

        // Xử lý kết nối từ Server chính
        private void HandleMainServerConnection(Socket mainServerSocket)
        {
            Task.Run(() =>
            {
                try
                {
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(new NetworkStream(mainServerSocket)))
                    {
                        while (isRunning && mainServerSocket.Connected)
                        {
                            string messageFromMainServer = sr.ReadLine();
                            if (string.IsNullOrEmpty(messageFromMainServer))
                            {
                                UpdateLog?.Invoke($"Kết nối từ Server chính đã bị đóng. {mainServerSocket.RemoteEndPoint}");
                                break;
                            }
                            UpdateLog?.Invoke($"Server chính gửi: {messageFromMainServer}");
                        }
                    }
                }
                catch (System.IO.IOException ex)
                {
                    UpdateLog?.Invoke($"Lỗi I/O với Server chính: {ex.Message}");
                }
                catch (Exception ex)
                {
                    UpdateLog?.Invoke($"Lỗi khi xử lý kết nối từ Server chính: {ex.Message}");
                }
                finally
                {
                    mainServerSocket.Close();
                    UpdateLog?.Invoke($"Đã đóng kết nối với Server chính.");
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

            UpdateLog?.Invoke("RoomServer đã ngừng hoạt động.");
        }
        #endregion
    }
}