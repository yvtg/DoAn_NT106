using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class User
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public bool IsDrawing { get; set; }
        private TcpClient client;

        public User(TcpClient client, string name)
        {
            this.client = client;
            Name = name;
            Score = 0;
            IsDrawing = false;
        }

        public void SendPacket(Packet packet)
        {
            // Giả định rằng lớp Packet có phương thức để chuyển dữ liệu thành byte
        }
    }
}
