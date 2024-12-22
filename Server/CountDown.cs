using System;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class CountdownHandler
    {
        private CancellationTokenSource _cts;

        public async Task CountDownAsync()
        {
            _cts = new CancellationTokenSource();
            CancellationToken token = _cts.Token;

            try
            {
                for (int i = 60; i > 0; i--)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("Countdown was restarted!");
                        return;
                    }

                    Console.WriteLine($"Time remaining: {i}s");
                    await Task.Delay(1000, token); // Đợi 1 giây hoặc hủy nếu cần
                }
                Console.WriteLine("Countdown complete!");
            }
            catch (TaskCanceledException)
            {
                Console.WriteLine("Countdown was canceled!");
            }
        }

        public void RestartCountdown()
        {
            // Hủy quá trình hiện tại nếu đang chạy
            if (_cts != null)
            {
                _cts.Cancel();
            }

            // Bắt đầu lại đếm ngược
            _ = CountDownAsync(); // Bỏ qua kết quả (không đợi)
        }
    }
}
