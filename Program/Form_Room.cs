using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
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
        private bool isErasing = false;
        private int penSize = 3;
        private Color penColor = Color.Black;

        private bool gameStart = false;

        private DateTime lastSentTime = DateTime.MinValue;
        private TimeSpan sendInterval = TimeSpan.FromMilliseconds(100);

        public Form_Room(string roomId, string host, int max_player, string username)
        {
            InitializeComponent();
            InitializeListView();

            this.client = Form_Input_ServerIP.client;

            this.roomId = roomId;
            this.host = host;
            this.max_player = max_player;
            this.username = username;

            roomForm.Text += roomId;
            usernamText.Text += username;
            hostText.Text += host;
            maxText.Text += max_player;

            // khởi tạo track bar kích thước bút
            sizeTrackBar.Minimum = 1;
            sizeTrackBar.Maximum = 20;
            sizeTrackBar.Value = penSize;

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

            // Cập nhật danh sách người chơi
            client.ReceiveOtherInfo += OnRecivedOtherInfo;

            // Đăng ký event để lắng nghe gói tin ROUND_UPDATE
            client.RoundUpdateReceived += OnReceivedRoundUpdate;

            // sự kiện nhận được nhận gói tin SyncBitmap
            client.SyncBitmapReceived += OnReceivedSyncBitmap;



            // chỉ chủ phòng mới có thể bắt đầu
            if (username != host)
                startButton.Hide();
        }

        #region Danh sach user

        private void InitializeListView()
        {
            userListView.View = View.Details;
            userListView.FullRowSelect = true;
            userListView.GridLines = true;

            // Thêm các cột vào ListView
            userListView.Columns.Add("username", 80);    
            userListView.Columns.Add("score", 41);   
            
        }

        #endregion

        #region ve
        private void sizeTrackBar_ValueChanged()
        {
            penSize = sizeTrackBar.Value;
        }
        private void chooseColorBtn_Click(object sender, EventArgs e)
        {
            // mở color dialog để chọn màu
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    penColor = colorDialog.Color;
                    chooseColorBtn.PrimaryColor = penColor;
                }
            }
        }

        // Bắt đầu vẽ khi nhấn chuột
        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && gameStart)
            {
                isDrawing = true;
                previousPoint = e.Location;
            }
        }

        // Rê chuột để vẽ hoặc xóa
        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing && gameStart)
            {
                Pen pen = new Pen(isErasing ? Color.White : penColor, penSize);
                graphics.DrawLine(pen, previousPoint, e.Location);
                pictureBox1.Refresh();

                // cập nhật điểm trước
                previousPoint = e.Location;
            }
        }

        // Dừng vẽ khi nhả chuột
        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && gameStart)
            {
                isDrawing = false;

                string bitmapData = BitmapToString(drawingBitmap);
                if (!string.IsNullOrEmpty(bitmapData))
                {
                    SyncBitmapPacket syncPacket = new SyncBitmapPacket($"{roomId};{bitmapData}");
                    Console.WriteLine(syncPacket.Payload);
                    client.SendPacket(syncPacket);
                }
            }
        }

        // chuyển bitmap thành string
        private string BitmapToString(Bitmap bitmap)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] bytes = ms.ToArray();
                    return Convert.ToBase64String(bytes);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in BitmapToString: {ex.Message}");
                return null;
            }
        }

        // chuyển string thành bitmap
        private Bitmap StringToBitmap(string bitmapString)
        {
            try
            {
                byte[] bytes = Convert.FromBase64String(bitmapString);
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    return new Bitmap(ms);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        private void OnReceivedSyncBitmap(SyncBitmapPacket syncBitmapPacket)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => OnReceivedSyncBitmap(syncBitmapPacket)));
                return;
            }

            if (syncBitmapPacket.RoomId == roomId)
            {
                Bitmap newBitmap = StringToBitmap(syncBitmapPacket.BitmapData);
                if (newBitmap != null)
                {
                    drawingBitmap.Dispose(); // Giải phóng bitmap cũ
                    drawingBitmap = newBitmap;

                    //// Tạo lại Graphics từ bitmap mới
                    graphics.Dispose();
                    graphics = Graphics.FromImage(newBitmap);


                    pictureBox1.Image = newBitmap;
                    pictureBox1.Refresh();
                }
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
        #endregion

        private void startButton_Click(object sender, EventArgs e)
        {
            gameStart = true;
            StartPacket startPacket = new StartPacket(roomId); 
            client.SendPacket(startPacket);
        }
        #region chat

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

                switch (status)
                {
                    case "JOINED":
                    case "JOINING":
                        // thêm user vô danh sách
                        ListViewItem item = new ListViewItem(new[] { username, Score.ToString() });
                        userListView.Items.Add(item);
                        break;

                    case "GUESS":
                        // cập nhật điểm
                        foreach (ListViewItem user in userListView.Items)
                        {
                            if (user.Text == username)
                            {
                                user.SubItems[1].Text = Score.ToString(); // Update score
                                break;
                            }
                        }
                        break;

                    case "LEAVE":
                        // xóa user khỏi danh sách
                        foreach (ListViewItem user in userListView.Items)
                        {
                            if (user.Text == username)
                            {
                                userListView.Items.Remove(user);
                                break;
                            }
                        }
                        break;

                    default:
                        break;
                }
                // Kiểm tra điều kiện và bật/tắt nút startButton
                startButton.Enabled = userListView.Items.Count >= 2;

                userListView.Refresh();
            }
        }
        #endregion

        private void OnReceivedRoundUpdate(RoundUpdatePacket roundUpdatePacket)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => OnReceivedRoundUpdate(roundUpdatePacket)));
                return;
            }

            if (roundUpdatePacket.Name == username )
            {
                pictureBox1.Enabled = true;
                wordTextbox.Text += roundUpdatePacket.Word;
                Form_Message formmessage = new Form_Message($"Bạn là người vẽ! từ khóa là {roundUpdatePacket.Word}");
                formmessage.StartPosition = FormStartPosition.Manual;
                int centerX = this.Location.X + (this.Width - formmessage.Width) / 2;
                int centerY = this.Location.Y + (this.Height - formmessage.Height) / 2;
                formmessage.Location = new Point(centerX, centerY);

                formmessage.Show();

            }
            else
            {
                pictureBox1.Enabled = false;
                Form_Message formmessage = new Form_Message($"Người vẽ là {roundUpdatePacket.Name}. Trong 60s hãy đoán từ khóa!");
                formmessage.StartPosition = FormStartPosition.Manual;
                int centerX = this.Location.X + (this.Width - formmessage.Width) / 2;
                int centerY = this.Location.Y + (this.Height - formmessage.Height) / 2;
                formmessage.Location = new Point(centerX, centerY);

                formmessage.Show();

            }
            startButton.Enabled = false;
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