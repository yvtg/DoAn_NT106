using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Form_Server : Form
    {
        private Server server;
        private bool isServerStopping = false;

        public Form_Server()
        {
            InitializeComponent();
            server = new Server();
            server.UpdateLog += UpdateLog;
        }

        private void UpdateLog(string message)
        {
            if (logRichTextBox.InvokeRequired)
            {
                logRichTextBox.Invoke(new Action(() => UpdateLog(message)));
            }
            else
            {
                logRichTextBox.AppendText($"{DateTime.Now}: {message}\r\n");
                logRichTextBox.SelectionStart = logRichTextBox.Text.Length; // Scroll to the bottom
                logRichTextBox.ScrollToCaret();
            }
        }


        private void startBtn_Click(object sender, EventArgs e)
        {
            isServerStopping = false;
            server.StartServer();
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            server.StopServer();
        }

        private void Form_Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Nếu server đã dừng hoặc đang dừng, không thực hiện gì thêm
            if (isServerStopping)
            {
                return;
            }

            // Đánh dấu server đang dừng
            isServerStopping = true;

            // Dừng server
            server.StopServer();

            base.OnFormClosing(e);
        }
    }
}
