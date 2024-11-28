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
        private Client client;
        private string username;
        private int max_player;
        public Form_Room(Client client, string username, int max_player)
        {
            InitializeComponent();
            this.client = client;
            this.username = username;
            this.max_player = max_player;
        }

        private void timeLabel_Click(object sender, EventArgs e)
        {

        }

        private void Form_Room_Load(object sender, EventArgs e)
        {

        }
    }
}
