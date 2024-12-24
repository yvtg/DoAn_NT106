using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static ReaLTaiizor.Util.RoundInt;

namespace Program
{
    public partial class Form_Input_ServerIP : Form
    {
        public static Client client;
        public Form_Input_ServerIP()
        {
            InitializeComponent();
        }

        private bool Connect(string serverIP, int port)
        {
            client = new Client();
            bool isConnected = client.Connect(serverIP, port);
            return isConnected;
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            int port;
            string serverIP = serverIPTextBox.Text;
            bool isPortValid = Int32.TryParse(portTextBox.Text, out port);
            bool isServerIPValid = System.Net.IPAddress.TryParse(serverIP, out _);
            if (isServerIPValid && isPortValid)
            {
                if (Connect(serverIP, port))
                {
                    this.Hide();
                    Form_Login form_Login = new Form_Login();
                    form_Login.Show();
                    form_Login.Location = new Point(this.Location.X, this.Location.Y);
                }
            }
            else
            {
                ShowMessage("server không hợp lệ.");
            }
        }

        public void ShowMessage(string messsage)
        {
            Form_Message formmessage = new Form_Message(messsage);
            formmessage.StartPosition = FormStartPosition.Manual;
            int centerX = this.Location.X + (this.Width - formmessage.Width) / 2;
            int centerY = this.Location.Y + (this.Height - formmessage.Height) / 2;
            formmessage.Location = new Point(centerX, centerY);

            formmessage.ShowDialog();
        }

        #region dragging

        private bool dragging = false;
        private Point dragCursor;
        private Point dragForm;

        private void inputServerIP_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursor = Cursor.Position;
            dragForm = this.Location;
        }

        private void inputServerIP_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point delta = new Point(Cursor.Position.X - dragCursor.X, Cursor.Position.Y - dragCursor.Y);
                this.Location = new Point(dragForm.X + delta.X, dragForm.Y + delta.Y);
            }
        }

        private void inputServerIP_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
        #endregion
    }
}
