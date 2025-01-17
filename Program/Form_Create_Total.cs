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

namespace Program
{
    public partial class Form_Create_Total : Form
    {
        public Form_Create_Total()
        {
            InitializeComponent();
        }

        // Lấy thư mục gốc của ứng dụng
        string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;

        private void FoodBtn_Click(object sender, EventArgs e)
        {
            // Lấy đường dẫn tuyệt đối của file Keyword.txt
            string filePath = Path.Combine(projectDirectory, @"..\..\Models\Keyword.txt");

            // Chuyển đường dẫn từ "..\.." thành đường dẫn tuyệt đối
            filePath = Path.GetFullPath(filePath);

            // Loại bỏ phần "Server" trong đường dẫn
            filePath = filePath.Replace(@"\Server", "");

            // Lấy đường dẫn tuyệt đối của file Food.txt
            string fileFood = Path.Combine(projectDirectory, @"..\..\Models\Food.txt");

            // Chuyển đường dẫn từ "..\.." thành đường dẫn tuyệt đối
            fileFood = Path.GetFullPath(fileFood);

            // Loại bỏ phần "Server" trong đường dẫn
            fileFood = fileFood.Replace(@"\Server", "");

            try
            {
                string content = File.ReadAllText(fileFood);
                File.WriteAllText(filePath, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Đã xảy ra lỗi: " + ex.Message);
            }
            FoodBtn.Enabled = false;
            AnimalBtn.Enabled = true;
            ActiveBtn.Enabled = true;
            SportBtn.Enabled = true;
        }

        private void AnimalBtn_Click(object sender, EventArgs e)
        {
            // Lấy đường dẫn tuyệt đối của file Keyword.txt
            string filePath = Path.Combine(projectDirectory, @"..\..\Models\Keyword.txt");

            // Chuyển đường dẫn từ "..\.." thành đường dẫn tuyệt đối
            filePath = Path.GetFullPath(filePath);

            // Loại bỏ phần "Server" trong đường dẫn
            filePath = filePath.Replace(@"\Server", "");

            // Lấy đường dẫn tuyệt đối của file Animal.txt
            string fileAnimal = Path.Combine(projectDirectory, @"..\..\Models\Animal.txt");

            // Chuyển đường dẫn từ "..\.." thành đường dẫn tuyệt đối
            fileAnimal = Path.GetFullPath(fileAnimal);

            // Loại bỏ phần "Server" trong đường dẫn
            fileAnimal = fileAnimal.Replace(@"\Server", "");

            try
            {
                string content = File.ReadAllText(fileAnimal);
                File.WriteAllText(filePath, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Đã xảy ra lỗi: " + ex.Message);
            }
            FoodBtn.Enabled = true;
            AnimalBtn.Enabled = false;
            ActiveBtn.Enabled = true;
            SportBtn.Enabled = true;

        }

        private void SportBtn_Click(object sender, EventArgs e)
        {
            // Lấy đường dẫn tuyệt đối của file Keyword.txt
            string filePath = Path.Combine(projectDirectory, @"..\..\Models\Keyword.txt");

            // Chuyển đường dẫn từ "..\.." thành đường dẫn tuyệt đối
            filePath = Path.GetFullPath(filePath);

            // Loại bỏ phần "Server" trong đường dẫn
            filePath = filePath.Replace(@"\Server", "");

            // Lấy đường dẫn tuyệt đối của file Sport.txt
            string fileSport = Path.Combine(projectDirectory, @"..\..\Models\Sport.txt");

            // Chuyển đường dẫn từ "..\.." thành đường dẫn tuyệt đối
            fileSport = Path.GetFullPath(fileSport);

            // Loại bỏ phần "Server" trong đường dẫn
            fileSport = fileSport.Replace(@"\Server", "");

            try
            {
                string content = File.ReadAllText(fileSport);
                File.WriteAllText(filePath, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Đã xảy ra lỗi: " + ex.Message);
            }
            FoodBtn.Enabled = true;
            AnimalBtn.Enabled = true;
            ActiveBtn.Enabled = true;
            SportBtn.Enabled = false;

        }

        private void ActiveBtn_Click(object sender, EventArgs e)
        {
            // Lấy đường dẫn tuyệt đối của file Keyword.txt
            string filePath = Path.Combine(projectDirectory, @"..\..\Models\Keyword.txt");

            // Chuyển đường dẫn từ "..\.." thành đường dẫn tuyệt đối
            filePath = Path.GetFullPath(filePath);

            // Loại bỏ phần "Server" trong đường dẫn
            filePath = filePath.Replace(@"\Server", "");

            // Lấy đường dẫn tuyệt đối của file Active.txt
            string fileActive = Path.Combine(projectDirectory, @"..\..\Models\Active.txt");

            // Chuyển đường dẫn từ "..\.." thành đường dẫn tuyệt đối
            fileActive = Path.GetFullPath(fileActive);

            // Loại bỏ phần "Server" trong đường dẫn
            fileActive = fileActive.Replace(@"\Server", "");

            try
            {
                string content = File.ReadAllText(fileActive);
                File.WriteAllText(filePath, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Đã xảy ra lỗi: " + ex.Message);
            }
            FoodBtn.Enabled = true;
            AnimalBtn.Enabled = true;
            ActiveBtn.Enabled = false;
            SportBtn.Enabled = true;
        }
    }
}
