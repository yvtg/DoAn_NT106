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
        public Socket UserSocket;
        public NetworkStream ns;

        public User(Socket UserSocket, NetworkStream ns)
        {
            this.Name = "";
            this.Score = 0;
            this.RoomId = "";
            this.IsDrawing = false;
            this.UserSocket = UserSocket;
            this.ns = ns;
        }
        public void SendPacket(Packet packet)
        {
            byte[] data = packet.ToBytes();
            UserSocket.Send(data);
        }

        public void Stop(bool abortThread = false)
        {
            UserSocket.Close();
        }

        public bool IsConnected
        {
            get
            {
                try
                {
                    // Kiểm tra kết nối bằng cách gọi UserSocket.Connected
                    return UserSocket.Connected;
                }
                catch (Exception)
                {
                    return false; // Trả về false nếu có lỗi (chẳng hạn socket đã bị đóng)
                }
            }
        }
    }
}
