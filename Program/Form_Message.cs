﻿using System;
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
    public partial class Form_Message : Form
    {
        public string message;
        public Form_Message(string message)
        {
            InitializeComponent();
            this.message = message;
            Message.Text = message;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}