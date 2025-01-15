using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoadBalancer
{
    public partial class LB_Log : Form
    {
        private LoadBalancer lb;
        private bool isStopping = false;
        private (string IP, int Port, int currentLoad)[] Servers = {
            ("127.0.0.1", 8081, 0),
            ("127.0.0.1", 8082, 0)
        };

        public LB_Log()
        {
            InitializeComponent();
            lb = new LoadBalancer();
            lb.StartLB();
            lb.UpdateLog += UpdateLog;
        }
        private void UpdateLog(string msg)
        {
            if (logRichTextBox.InvokeRequired)
            {
                logRichTextBox.Invoke(new Action(() => UpdateLog(msg)));
            }
            else
            {
                logRichTextBox.AppendText($"{DateTime.Now}: {msg}\r\n");
                logRichTextBox.SelectionStart = logRichTextBox.Text.Length; // Scroll to the bottom
                logRichTextBox.ScrollToCaret();
            }
        }

        private void LB_Log_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Nếu đã dừng hoặc đang dừng, không thực hiện gì thêm
            if (isStopping)
            {
                return;
            }

            // Đánh dấuđang dừng
            isStopping = true;

            // Dừng server
            lb.StopLB();

            base.OnFormClosing(e);
        }
    }
}
