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
        public int Turn { get; set; }
        public Socket UserSocket;

        public User(Socket UserSocket)
        {
            this.Name = "";
            this.Score = 0;
            this.IsDrawing = false;
            this.UserSocket = UserSocket;
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
    }
}
