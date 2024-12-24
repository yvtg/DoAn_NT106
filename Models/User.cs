using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class User
    {
        public string Name { get; set; }
        public string RoomId { get; set; }

        public int Score { get; set; }
        public bool IsDrawing { get; set; }
        public TcpClient tcpClient;
        public StreamReader sr;
        public StreamWriter sw;

        public User(TcpClient tcpClient)
        {
            this.Name = "";
            this.Score = 0;
            this.RoomId = "";
            this.IsDrawing = false;
            this.tcpClient = tcpClient;
            NetworkStream stream = tcpClient.GetStream();
            this.sr = new StreamReader(stream);
            this.sw = new StreamWriter(stream);
        }
        public void SendPacket(Packet packet)
        {
            this.sw.WriteLine(packet.Type+";"+packet.Payload);
            this.sw.Flush();
        }

        public void SendPacket(DrawPacket drawPacket)
        {
            var jsonDrawPacket = drawPacket.ToJson();
            this.sw.WriteLine(jsonDrawPacket);
            this.sw.Flush();
        }

        public void Stop(bool abortThread = false)
        {
            tcpClient.Close();
        }

        public bool IsConnected
        {
            get
            {
                try
                {
                    // Kiểm tra kết nối bằng cách gọi UserSocket.Connected
                    return tcpClient.Connected;
                }
                catch (Exception)
                {
                    return false; // Trả về false nếu có lỗi (chẳng hạn socket đã bị đóng)
                }
            }
        }
    }
}
