using Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public class ForgetPassword
    {
        private static string connectionString = "mongodb+srv://admin1:5VGZBpaXfZC15LPN@cluster0.qq9lk.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
        DataAccess.DatabaseHelper db = new DataAccess.DatabaseHelper(connectionString, "Datagame");
        public static string GenerateOTP()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString(); // Tạo mã OTP 6 chữ số
        }

        public static void SendEmail(string email, string otp)
        {
            try
            {
                string fromEmail = ConfigurationManager.AppSettings["Email"];
                string password = ConfigurationManager.AppSettings["EmailPassword"];

                // Kiểm tra định dạng email hợp lệ
                try
                {
                    var mailAddress = new MailAddress(email); // Sử dụng email
                }
                catch (FormatException)
                {
                    MessageBox.Show("Địa chỉ email nhận không hợp lệ.");
                    return;
                }

                // Tạo email
                MailMessage mm = new MailMessage
                {
                    From = new MailAddress(fromEmail),
                    Subject = "[Sketch&Guess] Please reset your password",
                    Body = $"Mã OTP của bạn là: {otp}",
                    IsBodyHtml = false
                };

                mm.To.Add(email); // Sử dụng email

                // Tạo đối tượng SMTP Client
                SmtpClient sc = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new System.Net.NetworkCredential(fromEmail, password),
                    EnableSsl = true
                };

                // Gửi email
                sc.Send(mm);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gửi email: {ex.Message}");
            }
        }

        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
