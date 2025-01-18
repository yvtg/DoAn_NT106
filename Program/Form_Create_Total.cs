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
using SharpCompress.Common;

namespace Program
{
    public partial class Form_Create_Total : Form
    {
        public Form_Create_Total()
        {
            InitializeComponent();
        }

        private void FoodBtn_Click(object sender, EventArgs e)
        {
            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sourcePath = Path.Combine(projectDirectory, @"..\\..\\Models\\Food.txt");
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
            FoodBtn.Enabled = false;
            AnimalBtn.Enabled = true;
            ActiveBtn.Enabled = true;
            SportBtn.Enabled = true;
        }

        private void AnimalBtn_Click(object sender, EventArgs e)
        {
            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sourcePath = Path.Combine(projectDirectory, @"..\\..\\Models\\Animal.txt");
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
            FoodBtn.Enabled = true;
            AnimalBtn.Enabled = false;
            ActiveBtn.Enabled = true;
            SportBtn.Enabled = true;

        }

        private void SportBtn_Click(object sender, EventArgs e)
        {
            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sourcePath = Path.Combine(projectDirectory, @"..\\..\\Models\\Sport.txt");
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
            FoodBtn.Enabled = true;
            AnimalBtn.Enabled = true;
            ActiveBtn.Enabled = true;
            SportBtn.Enabled = false;

        }

        private void ActiveBtn_Click(object sender, EventArgs e)
        {
            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sourcePath = Path.Combine(projectDirectory, @"..\\..\\Models\\Active.txt");
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
            FoodBtn.Enabled = true;
            AnimalBtn.Enabled = true;
            ActiveBtn.Enabled = false;
            SportBtn.Enabled = true;
        }
    }
}
