using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class User
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public bool IsDrawing { get; set; }


        public void SendPacket(Packet packet)
        {
            // Giả định rằng lớp Packet có phương thức để chuyển dữ liệu thành byte
        }
    }
}
