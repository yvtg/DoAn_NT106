using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ReaLTaiizor.Util.RoundInt;

namespace Program
{
    public partial class Form_Message : Form
    {
        public string message;
        public int round;
        string username;
        public Form_Message(string username, string message)
        {
            InitializeComponent();
            this.message = message;
            Message.Text = message;
            this.username = username;
        }

        public Form_Message(string message)
        {
            InitializeComponent();
            this.message = message;
            Message.Text = message;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_Message_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.FromArgb(124, 63, 88), 3);

            // Vẽ viền xung quanh form
            e.Graphics.DrawRectangle(pen, 0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1);
        }
    }
}
