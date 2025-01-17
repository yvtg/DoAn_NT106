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
        }
        private void TotalBtn_Click(object sender, EventArgs e )
        {
            OpenChildForm(new Form_Create_Total());
        }

        private void DefaultBtn_Click(object sender, EventArgs e)
        {
            if (currentFormchild != null)
            {
                currentFormchild.Close();
            }
            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Lấy đường dẫn tuyệt đối của file Keyword.txt
            string filePath = Path.Combine(projectDirectory, @"..\..\Models\Keyword.txt");

            // Chuyển đường dẫn từ "..\.." thành đường dẫn tuyệt đối
            filePath = Path.GetFullPath(filePath);

            // Loại bỏ phần "Server" trong đường dẫn
            filePath = filePath.Replace(@"\Server", "");

            // Lấy đường dẫn tuyệt đối của file Keyword.txt
            string fileDefault = Path.Combine(projectDirectory, @"..\..\Models\Default.txt");

            // Chuyển đường dẫn từ "..\.." thành đường dẫn tuyệt đối
            fileDefault = Path.GetFullPath(fileDefault);

            // Loại bỏ phần "Server" trong đường dẫn
            fileDefault = fileDefault.Replace(@"\Server", "");

            try
            {
                string content = File.ReadAllText(fileDefault);
                File.WriteAllText(filePath, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Đã xảy ra lỗi: " + ex.Message);
            }
        }
    }
}
