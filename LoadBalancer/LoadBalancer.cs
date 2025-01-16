using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace LoadBalancer
{
    class LoadBalancer
    {
        public event Action<string> UpdateLog; // cập nhật log trên UI
        private List<TcpClient> clients = new List<TcpClient>();
        private bool isRunning;
        public Socket loadBalancerSocket;
        int MaxLoad = 3;
        private (string IP, int Port) targetServer = (null, 0);
        private int currentServerIndex = 0; // Biến giữ trạng thái server hiện tại

        private (string IP, int Port, int currentLoad)[] Servers = {
            ("127.0.0.1", 8081, 0),
            ("192.168.220.119", 8081, 0)
          
        };

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

            loadBalancerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            loadBalancerSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
            loadBalancerSocket.Bind(ipEP);
            loadBalancerSocket.Listen(10);

            UpdateLog?.Invoke($"Load balancer đã khởi động trên port {port}. Đang chờ kết nối...");
            CheckServerStatus();

            while (isRunning)
            {
                if (loadBalancerSocket == null || !loadBalancerSocket.IsBound)
                {
                    UpdateLog?.Invoke("Socket server đã bị đóng.");
                    break;
                }

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
                if (!client.Connected)
                {
                    UpdateLog?.Invoke("Client không kết nối.");
                    return;
                }

                clients.Add(client);

                targetServer = GetNextAvailableServer();

                if (targetServer.IP == "NULL")
                {
                    // gửi thông tin đến client
                    string serverIP = targetServer.IP;
                    int serverPort = targetServer.Port;
                    string redirectPacket = $"CONNECT;NULL;0";
                    byte[] encryptedBytes = AES.EncryptAES(redirectPacket);
                    string encryptedPayload = Convert.ToBase64String(encryptedBytes);
                    NetworkStream clientStream = client.GetStream();
                    StreamWriter writer = new StreamWriter(clientStream, Encoding.UTF8) { AutoFlush = true };
                    await writer.WriteLineAsync(encryptedPayload);
                    return;
                }

                IncreaseServerLoad(targetServer.IP, targetServer.Port, 1);

                UpdateLog?.Invoke($"Client {client.Client.RemoteEndPoint} được chuyển tới server: {targetServer.IP}:{targetServer.Port}");

                CheckServerStatus(); // Cập nhật trạng thái server sau khi thêm client mới

                using (TcpClient server = new TcpClient(targetServer.IP, targetServer.Port))
                {
                    NetworkStream clientStream = client.GetStream();
                    NetworkStream serverStream = server.GetStream();

                    // gửi thông tin server hiện tại đến client
                    string serverIP = targetServer.IP;
                    int serverPort = targetServer.Port;
                    string redirectPacket = $"CONNECT;{serverIP};{serverPort}";
                    byte[] encryptedBytes = AES.EncryptAES(redirectPacket);
                    string encryptedPayload = Convert.ToBase64String(encryptedBytes);
                    StreamWriter writer = new StreamWriter(clientStream, Encoding.UTF8) { AutoFlush = true };
                    await writer.WriteLineAsync(encryptedPayload);

                    var clientToServer = ForwardData(clientStream, serverStream);
                    var serverToClient = ForwardData(serverStream, clientStream);

                    await Task.WhenAll(clientToServer, serverToClient);
                }
            }
            catch (Exception ex)
            {
                UpdateLog?.Invoke($"Error: {ex.Message}");
            }
            finally
            {
                try
                {
                    clients.Remove(client);
                    if (client.Connected) client.Close();

                    if (targetServer.IP != null)
                        DecreaseServerLoad(targetServer.IP, targetServer.Port, 1);

                    UpdateLog?.Invoke($"Client {client.Client.RemoteEndPoint} đã ngắt kết nối khỏi server {targetServer.IP}:{targetServer.Port}");

                    CheckServerStatus(); // Cập nhật trạng thái server sau khi client ngắt kết nối
                }
                catch (Exception ex)
                {
                    UpdateLog?.Invoke($"Lỗi khi đóng kết nối {ex.Message}");
                }
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
                        await writer.WriteLineAsync(line);
                    }
                }
            }
            catch (ObjectDisposedException)
            {
                UpdateLog?.Invoke("Luồng đã đóng.");
            }
            catch (IOException ex)
            {
                UpdateLog?.Invoke($"IO Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                UpdateLog?.Invoke($"Unexpected error: {ex.Message}");
            }
        }

        private (string IP, int Port) GetNextAvailableServer()
        {
            // Chỉ thay đổi server khi server hiện tại đã đầy
            //var currentServer = Servers[currentServerIndex];
            //if (currentServer.currentLoad < MaxLoad)
            //{
            //    return (currentServer.IP, currentServer.Port);
            //}

            // Tìm server khác trong danh sách
            for (int i = 1; i <= Servers.Length; i++)
            {
                int index = (currentServerIndex + i) % Servers.Length;
                var server = Servers[index];

                if (server.currentLoad < MaxLoad && IsServerActive(server.IP, server.Port))
                {
                    currentServerIndex = index; // Cập nhật chỉ số server hiện tại
                    return (server.IP, server.Port);
                }
            }

            UpdateLog?.Invoke("Tất cả server đều đã đầy hoặc không hoạt động.");
            return ("NULL",0);
        }

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

        private void DecreaseServerLoad(string IP, int Port, int load)
        {
            for (int i = 0; i < Servers.Length; i++)
            {
                if (Servers[i].IP == IP && Servers[i].Port == Port)
                {
                    Servers[i].currentLoad -= load;
                    if (Servers[i].currentLoad < 0) Servers[i].currentLoad = 0;
                    break;
                }
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
                if (IsServerActive(server.IP, server.Port))
                {
                    UpdateLog?.Invoke($"Server {server.IP}:{server.Port} - Đang hoạt động");
                    UpdateLog?.Invoke($"Server {server.IP}:{server.Port} - Load: {server.currentLoad}/{MaxLoad}");
                }
                else
                {
                    UpdateLog?.Invoke($"Server {server.IP}:{server.Port} - Không hoạt động");
                }
            }
        }

        public void StopLB()
        {
            Console.WriteLine("Stopping Load Balancer...");
            isRunning = false;

            try
            {
                loadBalancerSocket.Close();
                UpdateLog?.Invoke("Load Balancer đã dừng.");
            }
            catch (Exception ex)
            {
                UpdateLog?.Invoke($"Lỗi khi dừng Load Balancer: {ex.Message}");
            }
        }
    }
}
