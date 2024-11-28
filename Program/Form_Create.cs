using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;

namespace Program
{
    public partial class Form_Create : Form
    {
        private Client client;
        private string username;
        public Form_Create(Client client, string username)
        {
            InitializeComponent();
            this.client = client;
            this.username = username;
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            this.Close();

            Form homeform = Application.OpenForms["Form_Home"];
            if (homeform != null)
            {
                homeform.Close();
            }

            // tạo phòng mới
            int max_player = Int32.Parse(maxTextbox.Text);
            CreateRoomPacket packet = new CreateRoomPacket($"{username};{max_player}");
            client.SendData(packet);

            Form_Room roomform = new Form_Room(client,username,max_player);

        }
    }
}
