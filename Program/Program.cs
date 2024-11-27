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

            Application.Run(new Form_Background(client));
        }
    }
}
