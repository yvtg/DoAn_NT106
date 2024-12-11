using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Program
{
    public partial class Form_Room : Form
    {
        private string roomId;
        private string host;
        private string username;
        private int max_player;
        public Room room;
        private Client client;

        // Các thành phần liên quan đến tính năng vẽ
        private Bitmap drawingBitmap;
        private Graphics graphics;
        private Point previousPoint;
        private bool isDrawing = false;
        private bool isErasing = false; // Thêm biến để kiểm tra trạng thái xóa

        public Form_Room(string roomId, string host, int max_player, string username)
        {
            InitializeComponent();
            InitializeListView();

            this.client = Form_Input_ServerIP.client;

            this.roomId = roomId;
            this.host = host;
            this.max_player = max_player;
            this.username = username;

            roomIdText.Text += roomId;
            hostText.Text += host;

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

            // Sự kiện nhận được tin nhắn của người khác
            client.ReceiveMessage += OnReceivedMessage;

            // Cập nhật phòng
            client.ReceiveOtherInfo += OnRecivedOtherInfo;

            // chỉ chủ phòng mới có thể bắt đầu
            if (username != host)
                startButton.Hide();
        }

        private void InitializeListView()
        {
            userListView.View = View.Details;
            userListView.FullRowSelect = true;
            userListView.GridLines = true;

            // Thêm các cột vào ListView
            userListView.Columns.Add("username", 80);    
            userListView.Columns.Add("score", 41);   
            
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
                using (Pen pen = new Pen(isErasing ? Color.White : Color.Black, 2))
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

        private void OnReceivedMessage(string roomId, string sender, string message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => OnReceivedMessage(roomId, sender, message)));
                return;
            }

            if (roomId == this.roomId)
            {
                if (sender == username)
                {
                    chatRichtextbox.Text += $"You: {message}\n";
                }
                else
                {
                    chatRichtextbox.Text += $"{sender}: {message}\n";
                }
            }
        }

        private void OnRecivedOtherInfo(string roomId, string username, int Score, string status)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => OnRecivedOtherInfo(roomId, username, Score, status)));
                return;
            }

            if (roomId == this.roomId)
            {
                // khoi tao danh sach user
                if (status == "JOINING")
                {
                    ListViewItem item = new ListViewItem(username);
                    ListViewItem.ListViewSubItem score = new ListViewItem.ListViewSubItem(item, Score.ToString());
                    item.SubItems.Add(score);
                    userListView.Items.Add(item);
                }
                // khoi tao danh sach nhung nguoi choi da co san trong phong
                else if (status == "JOINED")
                {
                    ListViewItem item = new ListViewItem(username);
                    ListViewItem.ListViewSubItem score = new ListViewItem.ListViewSubItem(item, Score.ToString());
                    item.SubItems.Add(score);
                    userListView.Items.Add(item);
                }
                // cap nhat diem
                else if (status == "GUESS_RIGHT")
                {
                    foreach (ListViewItem item in userListView.Items)
                    {
                        if (item.Text == username)  // item.Text là phần tử đầu tiên, tức là username
                        {
                            // Tìm subitem chứa điểm (score) và thay đổi giá trị
                            item.SubItems[1].Text = Score.ToString(); // SubItem thứ 1 là score
                            break;
                        }
                    }
                }
                // xoa user
                else if (status == "LEAVE")
                {
                    foreach (ListViewItem item in userListView.Items)
                    {
                        // Kiểm tra nếu tên người chơi (username) trùng với item.Text
                        if (item.Text == username)
                        {
                            // Xóa item khỏi ListView
                            userListView.Items.Remove(item);
                            break; // Nếu đã tìm thấy, thoát vòng lặp
                        }
                    }
                }
                userListView.Refresh();
            }
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            string msg = sendTextBox.Text;
            if (!string.IsNullOrWhiteSpace(msg))
            {
                GuessPacket packet = new GuessPacket($"{roomId};{username};{msg}");
                client.SendPacket(packet);
                sendTextBox.Clear();
            }
        }

        private void leaveBtn_Click(object sender, EventArgs e)
        {
            LeaveRoomPacket packet = new LeaveRoomPacket($"{roomId};{username}");
            client.SendPacket(packet);
            this.Close();
        }
    }
}