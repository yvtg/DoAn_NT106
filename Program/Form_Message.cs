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
        public Form_Message(string message, int round)
        {
            InitializeComponent();
            this.message = message;
            Message.Text = message;
        }


        private void okBtn_Click(object sender, EventArgs e)
        {
            if(round == 5)
            {
                Form_End_Game formendgame = new Form_End_Game();
                formendgame.StartPosition = FormStartPosition.Manual;
                int centerX = this.Location.X + (this.Width - formendgame.Width) / 2;
                int centerY = this.Location.Y + (this.Height - formendgame.Height) / 2;
                formendgame.Location = new Point(centerX, centerY);

                formendgame.ShowDialog();
                this.Close();
            }
            else
            {
                this.Close();
            }
        }
    }
}
