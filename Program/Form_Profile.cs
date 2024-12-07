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
    public partial class Form_Profile : Form
    {
        string username;
        public Form_Profile(string username)
        {
            InitializeComponent();
            this.username = username;
        }
        #region UI
        private void backButton_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
