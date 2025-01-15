using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LoadBalancer
{
    class LoadBalancer
    {
        public event Action<string> UpdateLog; // cập nhật log trên UI
        private List<TcpClient> clients = new List<TcpClient>();
        private bool isRunning;
        public Socket loadBalancerSocket;
        int MaxLoad = 3;
        private Dictionary<(string, int), bool> serverStatuses = new Dictionary<(string, int), bool>();


        private (string IP, int Port, int currentLoad)[] Servers = {
            ("127.0.0.1", 8081, 0),
            ("127.0.0.1", 8082, 0)
        };
        private static int currentServerIndex = 0;

        public void StartLB()
        {
            if (isRunning) return;

            isRunning = true;
            Task.Run(() => InitializeLoadBalancer());
        }

        private async void InitializeLoadBalancer()
        {
            int port = 8080;
            EndPoint ipEP = new IPEndPoint(IPAddress.Any, 8080);

            // Khởi tạo load balancer
            loadBalancerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            loadBalancerSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
            loadBalancerSocket.Bind(ipEP);
            loadBalancerSocket.Listen(10);

            UpdateLog?.Invoke($"Load balancer đã khởi động trên port {port}. Đang chờ kết nối...");
            CheckServerStatus(); 

            while (isRunning)
            {
                // Kiểm tra trạng thái
                if (loadBalancerSocket == null || !loadBalancerSocket.IsBound)
                {
                    UpdateLog?.Invoke("Socket server đã bị đóng.");
                    break;
                }

                // Chờ kết nối từ client
                Socket clientSocket = await loadBalancerSocket.AcceptAsync();
                UpdateLog?.Invoke($"Đã kết nối với {clientSocket.RemoteEndPoint}");
                TcpClient tcpClient = new TcpClient { Client = clientSocket };
                HandleClient(tcpClient);
            }
        }

        private async void HandleClient(TcpClient client)
        {
            try
            {
                clients.Add(client);

                // Lấy server mục tiêu theo Round Robin
                var targetServer = GetNextServer();

                // Tăng tải cho server mục tiêu
                IncreaseServerLoad(targetServer.IP, targetServer.Port, 1);

                UpdateLog?.Invoke($"Chuyển tiếp tới server: {targetServer.IP}:{targetServer.Port}");

                // Kết nối tới server mục tiêu
                using (TcpClient server = new TcpClient(targetServer.IP, targetServer.Port))
                {
                    // Lấy streams cho client và server
                    NetworkStream clientStream = client.GetStream();
                    NetworkStream serverStream = server.GetStream();

                    // Chuyển tiếp dữ liệu giữa client và server
                    var clientToServer = ForwardData(clientStream, serverStream); // Client → Server
                    var serverToClient = ForwardData(serverStream, clientStream); // Server → Client

                    await Task.WhenAll(clientToServer, serverToClient); // Bất đồng bộ
                }

                // Giảm tải sau khi xử lý xong client
                DecreaseServerLoad(targetServer.IP, targetServer.Port, 1);
            }
            catch (Exception ex)
            {
                UpdateLog?.Invoke($"Error: {ex.Message}");
            }
            finally
            {
                clients.Remove(client); // Loại bỏ client
                client.Close();
                UpdateLog?.Invoke("Client disconnected.");
            }
        }



        private async Task ForwardData(Stream input, Stream output)
        {
            try
            {
                using (var reader = new StreamReader(input, Encoding.UTF8))
                using (var writer = new StreamWriter(output, Encoding.UTF8) { AutoFlush = true })
                {
                    string line;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        // Ghi dữ liệu từ client/server vào luồng đích
                        await writer.WriteLineAsync(line);
                    }
                }
            }
            catch (Exception ex)
            {
                UpdateLog?.Invoke($"Error: {ex.Message}");
            }
        }
        public bool IsServerActive(string IP, int Port)
        {
            try
            {
                using (var tcpClient = new TcpClient())
                {
                    // Cố gắng kết nối tới server trong khoảng thời gian timeout (e.g., 1000ms)
                    var result = tcpClient.BeginConnect(IP, Port, null, null);
                    bool success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromMilliseconds(1000));

                    if (success)
                    {
                        tcpClient.EndConnect(result);
                        return true; // Server hoạt động
                    }
                    return false; // Kết nối không thành công
                }
            }
            catch
            {
                return false; // Server không hoạt động hoặc không thể kết nối
            }
        }
        private void CheckServerStatus()
        {
            foreach (var server in Servers)
            {
                bool isActive = IsServerActive(server.IP, server.Port);
                UpdateLog?.Invoke($"Server {server.IP}:{server.Port} - {(isActive ? "Active" : "Inactive")}");
            }
        }

        // Phương pháp chọn server theo Round Robin
        private (string IP, int Port) GetNextServer()
        {
            int startIndex = currentServerIndex;

            do
            {
                var server = Servers[currentServerIndex];

                // Nếu tải server chưa đạt mức tối đa, chọn server đó
                if (server.currentLoad < MaxLoad && IsServerActive(server.IP,server.Port))
                {
                    currentServerIndex = (currentServerIndex + 1) % Servers.Length;
                    return (server.IP, server.Port);
                }

                // Chuyển sang server tiếp theo
                currentServerIndex = (currentServerIndex + 1) % Servers.Length;

            } while (currentServerIndex != startIndex); // Nếu vòng lặp trở về vị trí ban đầu

            throw new InvalidOperationException("Tất cả server đều đã đầy.");
        }

        // Tăng tải cho server
        private void IncreaseServerLoad(string IP, int Port, int load)
        {
            for (int i = 0; i < Servers.Length; i++)
            {
                if (Servers[i].IP == IP && Servers[i].Port == Port)
                {
                    Servers[i].currentLoad += load;
                    if (Servers[i].currentLoad == MaxLoad)
                        UpdateLog?.Invoke($"Server {IP}:{Port} đã đầy.");
                    break;
                }
            }
        }

        // Giảm tải cho server
        private void DecreaseServerLoad(string IP, int Port, int load)
        {
            for (int i = 0; i < Servers.Length; i++)
            {
                if (Servers[i].IP == IP && Servers[i].Port == Port)
                {
                    Servers[i].currentLoad -= load;
                    if (Servers[i].currentLoad < 0) Servers[i].currentLoad = 0; // Không để tải âm
                    break;
                }
            }
        }

        public void StopLB()
        {
            Console.WriteLine("Stopping Load Balancer...");
            isRunning = false;

            try
            {
                loadBalancerSocket.Close(); // Giải phóng tài nguyên
                UpdateLog?.Invoke("Load Balancer đã dừng.");
            }
            catch (Exception ex)
            {
                UpdateLog?.Invoke($"Lỗi khi dừng Load Balancer: {ex.Message}");
            }
        }
    }
}

