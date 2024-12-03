using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program
{
    public partial class Form_Room : Form
    {
        private string roomId;
        private string username;
        private int max_player;
        public Form_Room(string roomId, string username, int max_player)
        {
            InitializeComponent();

            this.roomId = roomId;
            this.username = username;
            this.max_player = max_player;
            try
            {
                roomIdLabel.Text += roomId;
                userLabel.Text += username;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in Form_Room constructor: {ex.Message}");
            }
        }

        private void sendButton_Click(object sender, EventArgs e)
        {

        }
    }
}
