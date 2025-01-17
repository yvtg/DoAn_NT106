using System;
using System.IO;
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
    public partial class Form_Create_File : Form
    {
        public Form_Create_File()
        {
            InitializeComponent();
        }

        private void Browserbtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = "Your File: " + openFileDialog.FileName;

                    // Lấy thư mục gốc của ứng dụng
                    string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;

                    // Lấy đường dẫn tuyệt đối của file Keyword.txt
                    string filePath = Path.Combine(projectDirectory, @"..\..\Models\Keyword.txt");

                    // Chuyển đường dẫn từ "..\.." thành đường dẫn tuyệt đối
                    filePath = Path.GetFullPath(filePath);

                    // Loại bỏ phần "Server" trong đường dẫn
                    filePath = filePath.Replace(@"\Server", "");

                    string destinationPath = openFileDialog.FileName;

                    try
                    {
                        string content = File.ReadAllText(destinationPath);
                        File.WriteAllText(filePath, content);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Đã xảy ra lỗi: " + ex.Message);
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}