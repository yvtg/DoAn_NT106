using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;

namespace Program
{
    public partial class Form_Room : Form
    {
        private Client client;
        private string username;
        private int max_player;
        public Room room;

        // Các thành phần liên quan đến tính năng vẽ
        private Bitmap drawingBitmap;
        private Graphics graphics;
        private Point previousPoint;
        private bool isDrawing = false;
        private bool isErasing = false; // Thêm biến để kiểm tra trạng thái xóa
        private int eraseWidth = 10; // Kích thước bút khi xóa

        public Form_Room(Client client, string username, int max_player)
        {
            InitializeComponent();

            this.client = client;
            this.username = username;
            this.max_player = max_player;
            room = new Room("1", max_player);

            // Kiểm tra điều kiện và bật/tắt nút startButton
            startButton.Enabled = max_player >= 2;

            // Khởi tạo Bitmap và Graphics
            drawingBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(drawingBitmap);
            graphics.Clear(Color.White);

            // Liên kết Bitmap với pictureBox1
            pictureBox1.Image = drawingBitmap;

            // Gắn sự kiện chuột cho pictureBox1
            pictureBox1.MouseDown += PictureBox_MouseDown;
            pictureBox1.MouseMove += PictureBox_MouseMove;
            pictureBox1.MouseUp += PictureBox_MouseUp;
        }

        // Bắt đầu vẽ khi nhấn chuột
        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = true;
                previousPoint = e.Location;
            }
        }

        // Rê chuột để vẽ hoặc xóa
        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                using (Pen pen = new Pen(isErasing ? Color.White : Color.Black, isErasing ? eraseWidth : 2))
                {
                    graphics.DrawLine(pen, previousPoint, e.Location);
                }
                previousPoint = e.Location;
                pictureBox1.Invalidate();
            }
        }

        // Dừng vẽ khi nhả chuột
        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = false;
            }
        }

        // Sự kiện khi nhấn vào hình cái bút
        private void PencilPictureBox_Click(object sender, EventArgs e)
        {
            isErasing = false;
        }

        // Sự kiện khi nhấn vào hình cái cục gôm
        private void EraserPictureBox_Click(object sender, EventArgs e)
        {
            isErasing = true;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            room.StartNewRound();
            wordTextbox.Text = room.currentKeyword;
        }
    }
}
