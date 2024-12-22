using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Interop;
using Amazon.Runtime.Internal.Util;
using Models;
using ReaLTaiizor.Controls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static ReaLTaiizor.Drawing.Poison.PoisonPaint;
using System.IdentityModel;
using static ReaLTaiizor.Util.RoundInt;
using System.Timers;

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
        Dictionary<string, (int score, int textcore)> playerScores = new Dictionary<string, (int, int)>();

        int Round;
        private int roundTime; // Thời gian của mỗi vòng chơi (tính bằng giây)
        private System.Timers.Timer roundTimer; // Timer đếm ngược cho mỗi vòng chơi
        int progressValue = 0;

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

            // Cài đặt bộ đếm thời gian cho vòng chơi
            roundTimer = new System.Timers.Timer();

            // chỉ chủ phòng mới có thể bắt đầu
            if (username != host)
                startButton.Hide();

            // khởi tạo time progress bar
            timeProgressBar.Maximum = 90;
            timeProgressBar.Value = 0;
        }

        #region TIMER
        public void StartTimer()
        {
            roundTimer.Interval = 1000; // Gửi thông báo mỗi giây
            roundTimer.AutoReset = true; // Lặp lại mỗi giây
            roundTime = 90; // 90 giây cho mỗi vòng chơi
            progressValue = 0;

            // Detach the event handler to prevent multiple subscriptions
            roundTimer.Elapsed -= RoundTimerElapsed;

            // Attach the event handler again
            roundTimer.Elapsed += RoundTimerElapsed;

            roundTimer.Start(); // Bắt đầu bộ đếm
        }

        private void RoundTimerElapsed(object sender, ElapsedEventArgs e)
        {
            roundTime--; // Giảm thời gian
            timeLabel.Text = $"Time: {roundTime}";
            progressValue++;
            timeProgressBar.Value = progressValue;
            // đổi màu progress bar
            if (roundTime > 60) // More than 60 seconds
            {
                timeProgressBar.ForeColor = Color.FromArgb(249, 168, 117); // Green when more than 60 seconds
            }
            else if (roundTime > 30) // Between 30 and 60 seconds
            {
                timeProgressBar.ForeColor = Color.FromArgb(235, 107, 111); // Yellow when between 30 and 60 seconds
            }
            else // Less than 30 seconds
            {
                timeProgressBar.ForeColor = Color.FromArgb(124, 63, 88); // Red when less than 30 seconds
            }

            // Khi hết giờ
            if (roundTime <= 0)
            {
                roundTimer.Stop();
                if (Round > 5)
                {
                    ShowMessage($"Trò chơi đã kết thúc! Hãy chuyển đến phần tổng kết.");
                }
                else
                {
                    ShowChatMessage("Vòng chơi kết thúc! Các bạn chưa đoán được từ khóa, hãy bắt đầu một vòng chơi mới.");
                    timeLabel.Text = $"Time: {roundTime}";
                    timeProgressBar.Value = 90-roundTime;
                    wordLabel.Text = "key word: ";
                    sendButton.Enabled = true;
                    startButton.Enabled = true;
                    ClearPictureBox();
                    pictureBox1.Enabled = true;
                }
            }
        }
        #endregion

        #region Danh sach user

        private void InitializeListView()
        {
            userListView.View = View.Details;
            userListView.FullRowSelect = true;
            userListView.GridLines = true;

            // Thêm các cột vào ListView
            userListView.Columns.Add("user", 85);
            userListView.Columns.Add("score", 70);

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

        private void ClearPictureBox()
        {
            // Xóa toàn bộ nội dung bằng cách vẽ hình chữ nhật màu trắng
            graphics.Clear(Color.White);
            // Làm mới lại PictureBox
            pictureBox1.Refresh();
        }
        #endregion

        private void startButton_Click(object sender, EventArgs e)
        {
            gameStart = true;
            StartPacket startPacket = new StartPacket(roomId);
            client.SendPacket(startPacket);
            startButton.Enabled = false;
        }
        #region chat


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

                        if (!playerScores.ContainsKey(username))
                        {
                            // Nếu người chơi chưa có trong danh sách, thêm vào với điểm khởi tạo
                            playerScores[username] = (score: Score, textcore: 0);
                        }
                        // Nếu người chơi đã có trong danh sách, cập nhật điểm
                        if (playerScores.ContainsKey(username))
                        {
                            playerScores[username] = (score: Score, textcore: playerScores[username].textcore);  // Cập nhật lại điểm Score
                        }
                        // Lấy thông tin hiện tại của người chơi
                        var playerData = playerScores[username];

                        if (playerData.textcore < playerData.score)
                        {
                            // Cập nhật textcore
                            playerData.textcore = playerData.score;

                            // Ghi lại cập nhật vào playerScores
                            playerScores[username] = playerData;
                            if (Round == 5)
                            {
                                ShowMessage("Trò chơi đã kết thúc! hãy chuyển đến phần tổng kết");
                            }
                            else
                            {
                                ShowChatMessage($"{username} đã đoán đúng từ khóa, được cộng 10 điểm");
                                roundTimer.Stop();
                                wordLabel.Text = "key word: ";
                                sendButton.Enabled = true;
                                startButton.Enabled = true;
                                ClearPictureBox();
                                pictureBox1.Enabled = true;
                            }

                        }
                        // cập nhật điểm
                        foreach (ListViewItem user in userListView.Items)
                        {
                            if (user.Text == username)
                            {
                                timeLabel.Text = $"Time: {roundTime}";
                                timeProgressBar.Value = 90-roundTime;
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

        #region chat
        private void AddMessage(string sender, string message)
        {
            // Tạo Label chứa tên người gửi
            Label senderLabel = new Label
            {
                AutoSize = true,
                Text = sender == username ? "You" : sender,
                ForeColor = sender == username ? Color.White : Color.FromArgb(124, 63, 88),
                BackColor = sender == username ? Color.FromArgb(249, 168, 117) : Color.White,
                Font = new Font("FVF Fernando 08", 8, FontStyle.Bold),
                Padding = new Padding(0, 0, 0, 0),
                TextAlign = sender == username ? ContentAlignment.MiddleRight : ContentAlignment.MiddleLeft,
                Margin = new Padding(0, 0, 0, 0),
                Dock = DockStyle.Top,
            };

            // Tạo Label chứa nội dung tin nhắn
            Label messageLabel = new Label
            {
                AutoSize = true,
                Text = message,
                Padding = new Padding(10), // Khoảng cách trong để không chạm viền
                BackColor = Color.Transparent,
                ForeColor = sender == username ? Color.FromArgb(124, 63, 88) : Color.White,
                Font = new Font("FVF Fernando 08", 8, FontStyle.Regular),
                MaximumSize = new Size(200, 0), // Giới hạn chiều rộng
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Fill,
            };

            // Tạo RoundedPanel chứa nội dung tin nhắn
            RoundedPanel messagePanel = new RoundedPanel
            {
                AutoSize = true,
                Padding = new Padding(5), // Khoảng cách giữa nội dung và viền
                BackColor = sender == username ? Color.White : Color.FromArgb(249, 168, 117),
                BorderRadius = 20, // Độ bo góc
                MaximumSize = new Size(218, 0),
            };
            messagePanel.Controls.Add(messageLabel);

            // Tạo Panel cha để chứa cả tên người gửi và tin nhắn
            System.Windows.Forms.Panel containerPanel = new System.Windows.Forms.Panel
            {
                AutoSize = true,
                MaximumSize = new Size(flowLayoutPanel.Width, 0),
                Margin = new Padding(3),
                BackColor = Color.Transparent,
            };

            // Thêm tên người gửi và nội dung tin nhắn vào Panel cha
            containerPanel.Controls.Add(senderLabel);
            containerPanel.Controls.Add(messagePanel);

            // Thêm Panel cha vào FlowLayoutPanel
            flowLayoutPanel.Controls.Add(containerPanel);

            // Cuộn xuống cuối cùng
            flowLayoutPanel.ScrollControlIntoView(containerPanel);
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
                if (!string.IsNullOrEmpty(message))
                {
                    if (message == "đã tham gia phòng" || message == "đã rời phòng")
                    {
                        ShowChatMessage($"{sender} {message}");
                    }
                    else
                    {
                        AddMessage(sender, message);
                    }
                }
            }
        }

        private void ShowChatMessage(string message)
        {
            Label contentLabel = new Label
            {
                AutoSize = true,
                Text = message,
                Font = new Font("FVF Fernando 08", 7, FontStyle.Bold),
                ForeColor = Color.FromArgb(235, 107, 111),
            };

            // Thêm Label vào Panel
            flowLayoutPanel.Controls.Add(contentLabel);

            // Cuộn xuống cuối cùng
            flowLayoutPanel.ScrollControlIntoView(contentLabel);
        }

        private void sendButton_Click(object sender, EventArgs e)
        {

            string msg = sendTextBox.Text;

            if (!string.IsNullOrEmpty(msg))
            {
                GuessPacket packet = new GuessPacket($"{roomId};{username};{msg}");
                client.SendPacket(packet);
                sendTextBox.Clear();
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
            gameStart = true;
            ClearPictureBox();
            StartTimer();
            Round = Round + 1;
            roundLabel.Text = $"round: {Round}";

            if (roundUpdatePacket.Name == username)
            {
                pictureBox1.Enabled = true;
                sendButton.Enabled = false;
                wordLabel.Text = $"key word: {roundUpdatePacket.Word}";
                ShowMessage($"Bạn là người vẽ! từ khóa là {roundUpdatePacket.Word}");

            }
            else
            {
                pictureBox1.Enabled = false;
                ShowChatMessage($"Người vẽ là {roundUpdatePacket.Name}. Trong 60s hãy đoán từ khóa!");
            }
            startButton.Enabled = false;

        }

        private void leaveBtn_Click(object sender, EventArgs e)
        {
            LeaveRoomPacket packet = new LeaveRoomPacket($"{roomId};{username}");
            client.SendPacket(packet);
            this.Close();
        }
        private void ShowMessage(string messsage)
        {
            Form_Message formmessage = new Form_Message(messsage, Round);
            formmessage.StartPosition = FormStartPosition.Manual;
            int centerX = this.Location.X + (this.Width - formmessage.Width) / 2;
            int centerY = this.Location.Y + (this.Height - formmessage.Height) / 2;
            formmessage.Location = new Point(centerX, centerY);

            formmessage.ShowDialog();
        }

    }


    public class RoundedPanel : System.Windows.Forms.Panel
    {
        public int BorderRadius { get; set; } = 15; // Độ bo góc

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, BorderRadius, BorderRadius, 180, 90); // Góc trên trái
                path.AddArc(Width - BorderRadius, 0, BorderRadius, BorderRadius, 270, 90); // Góc trên phải
                path.AddArc(Width - BorderRadius, Height - BorderRadius, BorderRadius, BorderRadius, 0, 90); // Góc dưới phải
                path.AddArc(0, Height - BorderRadius, BorderRadius, BorderRadius, 90, 90); // Góc dưới trái
                path.CloseFigure();

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.FillPath(new SolidBrush(BackColor), path); // Vẽ màu nền
            }
        }
    }
}