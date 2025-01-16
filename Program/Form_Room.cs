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
using System.Runtime.Remoting.Contexts;
using System.Threading;

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
        private bool isDrawing = false;
        private bool isErasing = false;
        private int penSize;
        private Color penColor;
        private Pen cursorPen = new Pen(Color.Black, 2);
        private int cursorX = -1;
        private int cursorY = -1;
        private Point point = new Point();
        // List của 2 point truyền vào graphics.DrawLine()
        static List<Point> points_1 = new List<Point>();
        static List<Point> points_2 = new List<Point>();
        private SynchronizationContext context = SynchronizationContext.Current ?? new SynchronizationContext();

        private int currentRound = 0;
        private int SelectRound;

        private bool gameStart = false;
        Dictionary<string, (string name, int score, int textcore)> playerScores = new Dictionary<string, (string, int, int)>();
        private int userScore = 0;

        private int roundTime; // Thời gian của mỗi vòng chơi (tính bằng giây)
        private System.Timers.Timer roundTimer; // Timer đếm ngược cho mỗi vòng chơi
        int progressValue = 0;
        private Form_Message activeMessageForm = null;

        private string fullKeyword;
        private string revealedKeyword;
        private System.Timers.Timer hintTimer;
        private int hintStep;
        private bool isDrawer;

        private void InitializeHintSystem(string keyword)
        {
            fullKeyword = keyword;
            revealedKeyword = ""; // Từ khóa đã được tiết lộ
            foreach (char c in fullKeyword)
            {
                if (c == ' ')
                    revealedKeyword += " "; // Giữ nguyên khoảng trắng
                else
                    revealedKeyword += "_"; // Thay thế ký tự khác bằng _
            }
            hintStep = 0;

            hintTimer = new System.Timers.Timer(1000); // Set interval to 1 second
            hintTimer.Elapsed += OnHintTimerElapsed;
            hintTimer.Start();
        }

        private void OnHintTimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (!gameStart || isDrawer) return; // Skip hint logic for the drawer

            hintStep++;

            switch (hintStep)
            {
                case 45:
                    RevealKeywordCharacters(2);
                    break;
                case 60:
                    RevealKeywordCharacters(2);
                    break;
                case 75:
                    RevealKeywordCharacters(2);
                    break;
                case 80:
                    RevealKeywordCharacters(2);
                    break;
                case 85:
                    RevealKeywordCharacters(2);
                    hintTimer.Stop(); // Stop the timer after the last hint
                    break;
            }
        }

        private void RevealKeywordCharacters(int count)
        {
            int revealedCount = revealedKeyword.Count(c => c != '_');
            char[] revealedArray = revealedKeyword.ToCharArray();

            for (int i = revealedCount; i < revealedCount + count && i < fullKeyword.Length; i++)
            {
                revealedArray[i] = fullKeyword[i];
            }

            revealedKeyword = new string(revealedArray);

            context.Post(_ =>
            {
                wordLabel.Text = $"KEY WORD: {revealedKeyword}";
            }, null);
        }

        private void StartNewRound(string keyword, bool isDrawer)
        {
            this.isDrawer = isDrawer;

            if (isDrawer)
            {
                wordLabel.Text = $"KEY WORD: {keyword}"; // Show full keyword to the drawer
            }
            else
            {
                InitializeHintSystem(keyword);
                wordLabel.Text = $"KEY WORD: {new string('_', keyword.Length)}"; // Show hidden keyword to guessers
            }
        }

        public Form_Room(string roomId, string host, int max_player, string username)
        {
            InitializeComponent();
            InitializeListView();

            this.client = Form_Input_ServerIP.client;
            client.ServerDisconnected += () =>
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        this.Close();
                    }));
                }
            };

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

            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pictureBox1.Image = drawingBitmap;
            penColor = Color.Black;
            penSize = 2;
            cursorPen = new Pen(penColor, penSize);

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
            //client.SyncBitmapReceived += OnReceivedSyncBitmap;

            // sự kiện nhận được gói tin DrawPacket
            client.DrawPacketReceived += OnReceivedDrawPacket;

            // nhận tín hiệu kết thúc game
            client.EndGameReceived += EndGame;

            // cập nhật thông tin phòng
            client.HostChanged += HostChanged;

            // Cài đặt bộ đếm thời gian cho vòng chơi
            roundTimer = new System.Timers.Timer();

            // chỉ chủ phòng mới có thể bắt đầu
            if (username != host)
                startButton.Hide();
            if (username != host)
                roundComboBox.Hide();

            // khởi tạo time progress bar
            timeProgressBar.Maximum = 90;
            timeProgressBar.Value = 0;

            // khởi tạo round combo box
            for (int i = 2; i <= 10; i++)
            {
                roundComboBox.Items.Add(i);
            }
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
            if (timeLabel.InvokeRequired)
            {
                timeLabel.Invoke(new Action(() =>
                {
                    timeLabel.Text = $"Time: {roundTime}";
                }));
            }
            else
            {
                timeLabel.Text = $"Time: {roundTime}";
            }

            progressValue++;
            timeProgressBar.Value = progressValue;

            // Khi hết giờ
            if (roundTime == 0)
            {
                roundTimer.Stop();
                currentRound++;

                if (currentRound > SelectRound)
                {
                    if (username == host)
                    {
                        EndGamePacket endgamePacket = new EndGamePacket($"{roomId}");
                        client.SendPacket(endgamePacket);
                    }
                    return;
                }
                else
                {
                    // Hiển thị thông báo kết thúc vòng
                    if (timeLabel.InvokeRequired)
                    {
                        timeLabel.Invoke(new Action(() =>
                        {
                            ShowChatMessage("Vòng chơi kết thúc! Các bạn chưa đoán được từ khóa, hãy bắt đầu một vòng chơi mới.");
                        }));
                    }
                    else
                    {
                        ShowChatMessage("Vòng chơi kết thúc! Các bạn chưa đoán được từ khóa, hãy bắt đầu một vòng chơi mới.");
                    }

                    if (this.username == host)
                    {
                        StartPacket startPacket = new StartPacket($"{roomId};{currentRound}");
                        client.SendPacket(startPacket);
                    }

                    timeLabel.Text = $"Time: {roundTime}";
                    timeProgressBar.Value = 90 - roundTime;
                    wordLabel.Text = "KEY WORD: ";

                    sendButton.Enabled = true;
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
            userListView.Columns.Add("score", 75);

        }

        #endregion

        #region ve
        private void sizeTrackBar_ValueChanged()
        {
            penSize = sizeTrackBar.Value;
            cursorPen.Width = penSize;
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
                    cursorPen.Color = penColor;
                }
            }
        }

        // Bắt đầu vẽ khi nhấn chuột
        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && gameStart)
            {
                isDrawing = true;
                cursorX = e.X;
                cursorY = e.Y;
            }
        }

        // Rê chuột để vẽ hoặc xóa
        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isErasing == true) // Nếu đang chọn chức năng xóa
            {
                cursorPen.Color = Color.White;
            }
            else
            {
                cursorPen.Color = penColor;
            }
            if (cursorX != -1 && cursorY != -1 && isDrawing == true && gameStart)
            {
                point = e.Location;

                points_1.Add(new Point(cursorX, cursorY));
                points_2.Add(point);

                graphics.DrawLine(cursorPen, new Point(cursorX, cursorY), point);

                cursorX = e.X;
                cursorY = e.Y;
            }
            context.Send(s =>
            {
                pictureBox1.Refresh();
            }, null);
        }

        // Dừng vẽ khi nhả chuột
        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && gameStart)
            {
                float w = e.Location.X - cursorX;
                float h = e.Location.Y - cursorY;
                graphics.DrawLine(cursorPen, cursorX, cursorY, w + cursorX, h + cursorY);
                context.Send(s =>
                {
                    pictureBox1.Refresh();
                }, null);


                float[] pos = new float[] { cursorX, cursorY, w, h };

                DrawPacket packet = new DrawPacket
                {
                    Username = this.username,
                    RoomId = this.roomId,
                    PenColor = cursorPen.Color,
                    PenWidth = cursorPen.Width,
                    Points_1 = points_1,
                    Points_2 = points_2,
                    Position = pos
                };

                client.SendDrawPacket(packet);

                isDrawing = false;
                cursorX = -1;
                cursorY = -1;
                points_1.Clear();
                points_2.Clear();
            }
        }

        private void OnReceivedDrawPacket(DrawPacket drawPacket)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => OnReceivedDrawPacket(drawPacket)));
                return;
            }

            if (drawPacket.RoomId == roomId)
            {
                Pen pen = new Pen(drawPacket.PenColor, drawPacket.PenWidth);
                int cursorX = 0, cursorY = 0;
                float w = 0, h = 0;
                int length = drawPacket.Points_1.Count;
                for (int i = 0; i < length; i++)
                {
                    if (i == 0)
                    {
                        cursorX = drawPacket.Points_1[i].X;
                        cursorY = drawPacket.Points_1[i].Y;
                    }
                    else
                    {
                        w = drawPacket.Points_2[i].X - cursorX;
                        h = drawPacket.Points_2[i].Y - cursorY;
                        graphics.DrawLine(pen, cursorX, cursorY, w + cursorX, h + cursorY);
                        cursorX = drawPacket.Points_2[i].X;
                        cursorY = drawPacket.Points_2[i].Y;
                    }
                }
                context.Send(s =>
                {
                    pictureBox1.Refresh();
                }, null);
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
            if (roundComboBox.SelectedItem != null)
            {
                gameStart = true;
                SelectRound = Int32.Parse(roundComboBox.SelectedItem.ToString());

                if (username == host)
                {
                    currentRound++;
                    StartPacket startPacket = new StartPacket($"{roomId};{currentRound}");
                    client.SendPacket(startPacket);
                }

                startButton.Enabled = false;
                roundComboBox.Hide();
            }
            else
            {
                ShowMessage("Vui lòng chọn số vòng chơi!");
            }
        }
        #region thong tin danh sach user


        private void OnRecivedOtherInfo(string roomId, string username, int Score, string status)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => OnRecivedOtherInfo(roomId, username, Score, status)));
                return;
            }

            // lay diem hien tai cua nguoi choi
            if (username == this.username)
            {
                userScore = Score;
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

                    case "GUESS_RIGHT":

                        if (!playerScores.ContainsKey(username))
                        {
                            // Nếu người chơi chưa có trong danh sách, thêm vào với điểm khởi tạo
                            playerScores[username] = (name: username, score: Score, textcore: 0);
                        }
                        // Nếu người chơi đã có trong danh sách, cập nhật điểm
                        if (playerScores.ContainsKey(username))
                        {
                            playerScores[username] = (name: username, score: Score, textcore: playerScores[username].textcore);  // Cập nhật lại điểm Score
                        }
                        // Lấy thông tin hiện tại của người chơi
                        var playerData = playerScores[username];

                        if (playerData.textcore < playerData.score)
                        {
                            // Cập nhật textcore
                            playerData.textcore = playerData.score;

                            // Ghi lại cập nhật vào playerScores
                            playerScores[username] = playerData;
                            if (currentRound == SelectRound)
                            {
                                if (this.username == host)
                                {
                                    EndGamePacket endgamePacket = new EndGamePacket($"{roomId}");
                                    client.SendPacket(endgamePacket);
                                }
                            }
                            else
                            {
                                ShowChatMessage($"{username} đã đoán đúng từ khóa, được cộng 10 điểm");

                                if (this.username == host)
                                {
                                    currentRound++;
                                    StartPacket startPacket = new StartPacket($"{roomId};{currentRound}");
                                    client.SendPacket(startPacket);
                                }

                                roundTimer.Stop();
                                wordLabel.Text = "KEY WORD: ";
                                sendButton.Enabled = true;
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
                                timeProgressBar.Value = 90 - roundTime;
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
        // nhận thông tin phòng (đổi host)
        private void HostChanged(string host)
        {
            if (hostText.InvokeRequired)
            {
                hostText.Invoke(new Action(() => HostChanged(host)));
            }
            else
            {
                this.host = host;
                hostText.Text = "Host: " + host;

                if (username == host)
                {
                    startButton.Show();
                    roundComboBox.Show();
                }
            }
        }


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
            currentRound = roundUpdatePacket.Round;
            roundLabel.Text = $"Round: {currentRound}";

            if (roundUpdatePacket.Name == username)
            {
                pictureBox1.Enabled = true;
                sendButton.Enabled = false;
                wordLabel.Text = $"KEY WORD: {roundUpdatePacket.Word}";
                ShowMessage($"Bạn là người vẽ! từ khóa là {roundUpdatePacket.Word}");

                StartNewRound(roundUpdatePacket.Word, true); // The drawer sees the full keyword
            }
            else
            {
                pictureBox1.Enabled = false;
                sendButton.Enabled = true;
                ShowChatMessage($"Người vẽ là {roundUpdatePacket.Name}. Trong 60s hãy đoán từ khóa!");

                StartNewRound(roundUpdatePacket.Word, false); // Guessers see the hidden keyword with hints
            }

            startButton.Enabled = false;
        }


        private void EndGame(string roomID)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => EndGame(roomID)));
                return;
            }
            if (roomID == this.roomId)
            {

                // Đặt lại điểm của tất cả người chơi về 0
                foreach (var key in playerScores.Keys.ToList())
                {
                    var playerData = playerScores[key];
                    playerScores[key] = (name: playerData.name, score: 0, textcore: 0); // Reset điểm
                }

                // Cập nhật lại danh sách điểm trên userListView
                foreach (ListViewItem user in userListView.Items)
                {
                    user.SubItems[1].Text = "0"; // Reset điểm hiển thị
                }
                if (username == host)
                {
                    startButton.Enabled = true;
                    roundComboBox.Show();
                    roundComboBox.SelectedIndex = -1;
                    roundLabel.Text = "Round: ";
                }
                timeLabel.Text = $"Time: ";
                timeProgressBar.Value = 0;
                wordLabel.Text = "key word: ";
                roundLabel.Text = "Round: ";
                SelectRound = -1;
                sendButton.Enabled = true;
                ClearPictureBox();
                pictureBox1.Enabled = true;
                currentRound = 0;
                gameStart = false;
                roundTimer.Stop();

                Form_End_Game formendgame = new Form_End_Game(username, userScore, playerScores);
                formendgame.StartPosition = FormStartPosition.Manual;
                int centerX = this.Location.X + (this.Width - formendgame.Width) / 2;
                int centerY = this.Location.Y + (this.Height - formendgame.Height) / 2;
                formendgame.Location = new Point(centerX, centerY);
                formendgame.Show();
                this.Hide();

                formendgame.FormClosed += (s, e) =>
                {
                    this.Show();
                };
            }
        }

        private void leaveBtn_Click(object sender, EventArgs e)
        {
            LeaveRoomPacket packet = new LeaveRoomPacket($"{roomId};{username}");
            client.SendPacket(packet);

            // Hủy đăng ký sự kiện
            client.RoundUpdateReceived -= OnReceivedRoundUpdate;
            client.EndGameReceived -= EndGame;

            this.Close();
        }

        public void ShowMessage(string message)
        {
            // Kiểm tra nếu đã có form thông báo đang hiển thị
            if (activeMessageForm != null && !activeMessageForm.IsDisposed)
            {
                return;
            }

            activeMessageForm = new Form_Message(username, message);
            activeMessageForm.StartPosition = FormStartPosition.Manual;

            int centerX = this.Location.X + (this.Width - activeMessageForm.Width) / 2;
            int centerY = this.Location.Y + (this.Height - activeMessageForm.Height) / 2;
            activeMessageForm.Location = new Point(centerX, centerY);

            activeMessageForm.FormClosed += (s, e) => { activeMessageForm = null; };

            activeMessageForm.Show();
        }
        #region dragging

        private bool dragging = false;
        private Point dragCursor;
        private Point dragForm;

        private void roomForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = true;
                dragCursor = System.Windows.Forms.Cursor.Position;
                dragForm = this.Location;
            }
        }

        private void roomForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point delta = new Point(System.Windows.Forms.Cursor.Position.X - dragCursor.X, System.Windows.Forms.Cursor.Position.Y - dragCursor.Y);
                this.Location = new Point(dragForm.X + delta.X, dragForm.Y + delta.Y);
            }
        }

        private void roomForm_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        #endregion
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