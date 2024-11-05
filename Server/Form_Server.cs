using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Form_Server : Form
    {
        private Server server;

        public Form_Server()
        {
            InitializeComponent();
            server = new Server(UpdateLog);
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

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            server.StopServer();
            UpdateLog("Server has been stopped.");
            base.OnFormClosing(e); 
        }
    }
}
