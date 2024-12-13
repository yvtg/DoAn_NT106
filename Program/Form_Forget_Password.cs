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
    public partial class Form_Forget_Password : Form
    {
        private Client client;
        public Form_Forget_Password()
        {
            InitializeComponent();
            this.client = Program.Form_Input_ServerIP.client;
            client.LoginSuccessful += OnResetPasswordSuccessful;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            string email = emailTextbox.Text;
            string newPassword = passwordTextbox.Text;
            string confirmPassword = confirmpassTextbox.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không khớp.");
                return;
            }

            try
            {
                // Gửi yêu cầu reset mật khẩu lên server
                //ResetPasswordPacket packet = new ResetPasswordPacket($"{email};{newPassword}");
                //client.SendPacket(packet);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gửi thông tin reset mật khẩu: {ex.Message}");
            }
        }
        private void OnResetPasswordSuccessful()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(OnResetPasswordSuccessful));
                return;
            }

            string username = emailTextbox.Text; 
            Form_Home homeForm = new Form_Home(username);

            homeForm.StartPosition = FormStartPosition.Manual;
            homeForm.Location = this.Location;
            homeForm.Show();
            this.Hide(); 
            homeForm.FormClosed += (s, args) => this.Close(); 
        }
    }
}
