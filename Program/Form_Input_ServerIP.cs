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

namespace Program
{
    public partial class Form_Input_ServerIP : Form
    {
        public static Client client;
        public Form_Input_ServerIP()
        {
            InitializeComponent();
        }

        private bool Connect(string serverIP)
        {
            try
            {
                client = new Client();
                client.Connect(serverIP);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kết nối: " + ex.Message);
                return false;
            }
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            string serverIP = serverIPTextBox.Text;
            bool isServerIPValid = System.Net.IPAddress.TryParse(serverIP, out _);
            if (isServerIPValid)
            {
                if (Connect(serverIP))
                {
                    this.Hide();  
                    Form_Login form_Login = new Form_Login();
                    form_Login.Show();  
                    return;  
                }
                else
                {
                    MessageBox.Show("Kết nối thất bại. Vui lòng kiểm tra lại.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập địa chỉ IP server hợp lệ!");
            }
        }

    }
}
