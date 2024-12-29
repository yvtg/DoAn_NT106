using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DrawPacket
    {
        public string RoomId = "";  
        public string Username = "";
        public Color PenColor = Color.Black;
        public float PenWidth = 0;
        public List<Point> Points_1 = new List<Point>();
        public List<Point> Points_2 = new List<Point>();
        public float[] Position = new float[2];

        public string ToJson()
        {
            var jsonDrawPacket = Newtonsoft.Json.JsonConvert.SerializeObject(this);
            return jsonDrawPacket;
        }
    }
}
