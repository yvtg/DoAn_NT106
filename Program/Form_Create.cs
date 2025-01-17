using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using ReaLTaiizor.Forms;

namespace Program
{
    public partial class Form_Create : Form
    {
        private string username;
        private Client client;
        public Form_Create(string username)
        {
            InitializeComponent();
            this.client = Form_Input_ServerIP.client;
            client.ServerDisconnected += () =>
            {
                if (this.InvokeRequired) 
                {
                    this.Invoke(new Action(() =>
                    {
                        this.Close(); // Đóng form trên luồng UI
                    }));
                }
                else
                {
                    this.Close(); 
                }
            };
            this.username = username;
        }

        private void createBtn_Click(object sender, EventArgs e)
        {

            int maxPlayers = (int)numeric.ValueNumber;
            CreateRoomPacket createRoomPacket = new CreateRoomPacket($"{username};{maxPlayers}");
            client.SendPacket(createRoomPacket);

            this.Close();

        }

        private void Form_Create_Load(object sender, EventArgs e)
        {
            numeric.MinNum = 2;
            numeric.MaxNum = 10;
            numeric.ValueNumber = 2;
        }

        private Form currentFormchild;
        private void OpenChildForm(Form childForm)
        {
            if(currentFormchild != null)
            {
                currentFormchild.Close();
            }    
            currentFormchild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelBody.Controls.Add(childForm);
            panelBody.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void UpfileBtn_Click( object sender, EventArgs e )
        {
            OpenChildForm(new Form_Create_File());
            UpfileBtn.Enabled = false;
            TotalBtn.Enabled = true;
            DefaultBtn.Enabled = true;
        }
        private void TotalBtn_Click(object sender, EventArgs e )
        {
            OpenChildForm(new Form_Create_Total());
            UpfileBtn.Enabled = true;
            TotalBtn.Enabled = false;
            DefaultBtn.Enabled = true;
        }

        private void DefaultBtn_Click(object sender, EventArgs e)
        {
            if (currentFormchild != null)
            {
                currentFormchild.Close();
            }
            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sourcePath = Path.Combine(projectDirectory, @"..\\..\\Models\\Default.txt");
            string destinationPath = Path.Combine(projectDirectory, @"..\\..\\Models\\Keyword.txt");

            sourcePath = Path.GetFullPath(sourcePath);
            destinationPath = Path.GetFullPath(destinationPath);
            sourcePath = sourcePath.Replace(@"\Program", "");
            destinationPath = destinationPath.Replace(@"\Program", "");

            try
            {
                // Đọc nội dung từ Sport.txt
                string content = File.ReadAllText(sourcePath);

                // Ghi đè dữ liệu vào Keyword.txt
                File.WriteAllText(destinationPath, content);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi");
            }
            UpfileBtn.Enabled = true;
            TotalBtn.Enabled = true;
            DefaultBtn.Enabled = false;
        }
    }
}
