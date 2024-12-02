using Program;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal static class Program
    {
        public static Client client;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()  // Thêm phương thức Main tĩnh
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            client = new Client();
            client.Connect();

            Client clientInstance = new Client(); // Tạo đối tượng Client
            string roomName = "Room1";            // Một chuỗi tùy ý
            int max_player = 3;

            Application.Run(new Form_Room(clientInstance, roomName, max_player));
        }
    }
}
