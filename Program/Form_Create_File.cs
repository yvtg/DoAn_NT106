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
using Models;
using SharpCompress.Common;

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

                    string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    string sourcePath = openFileDialog.FileName;
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
                }
            }
        }
    }
}