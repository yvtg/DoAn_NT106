using System;
using System.Data;
using System.Data.SqlClient;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Models;

namespace Server.DataAccess
{
    public class DatabaseHelper
    {
        private readonly IMongoDatabase _database;
        // Constructor kết nối tới MongoDB và chọn database
        public DatabaseHelper(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        // Lấy một collection bất kỳ
        private IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }

        // Thêm một tài liệu mới vào collection
        public void InsertDocument<T>(string collectionName, T document)
        {
            var collection = GetCollection<T>(collectionName);
            collection.InsertOne(document);
        }

        // Lấy danh sách tất cả tài liệu từ collection
        public List<T> GetAllDocuments<T>(string collectionName)
        {
            var collection = GetCollection<T>(collectionName);
            return collection.Find(new BsonDocument()).ToList();
        }

        // Cập nhật tài liệu dựa trên điều kiện
        public void UpdateDocument<T>(string collectionName, FilterDefinition<T> filter, UpdateDefinition<T> update)
        {
            var collection = GetCollection<T>(collectionName);
            collection.UpdateOne(filter, update);
        }

        // Xóa tài liệu dựa trên điều kiện
        public void DeleteDocument<T>(string collectionName, FilterDefinition<T> filter)
        {
            var collection = GetCollection<T>(collectionName);
            collection.DeleteOne(filter);
        }

        // Hàm mã hóa mật khẩu (hashing)
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        // Kiểm tra mật khẩu có khớp với băm đã lưu trữ không
        public static bool VerifyPassword(string storedHash, string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, storedHash);
        }

        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }


        // Hàm đăng ký người dùng
        public bool RegisterUser(string username, string email, string password)
        {
            if (!IsValidEmail(email))
            {
                throw new ArgumentException("Email không hợp lệ.");
            }

            var collection = GetCollection<BsonDocument>("User");
            var existingUser = collection.Find(Builders<BsonDocument>.Filter.Eq("Email", email)).FirstOrDefault();

            // Kiểm tra xem tên người dùng đã tồn tại hay chưa
            var existingUsername = collection.Find(Builders<BsonDocument>.Filter.Eq("Username", username)).FirstOrDefault();
            if (existingUsername != null)
            {
                return false; // Tên người dùng đã tồn tại
            }

            if (existingUser != null)
            {
                return false; // Email đã tồn tại
            }
            if (UserExists(email))
            {
                return false; // Email đã tồn tại
            }

            string hashedPassword = HashPassword(password);
            var newUser = new BsonDocument
            {
                { "Username", username },
                { "Email", email },
                { "Password", hashedPassword },
                { "HighestScore", 0 },
                { "GamesPlayed", 0 }
            };

            collection.InsertOne(newUser);
            return true; // Đăng ký thành công
        }



        // Hàm đăng nhập người dùng
        public bool LoginUser(string username, string password)
        {
            var collection = GetCollection<BsonDocument>("User");

            // Tìm người dùng theo username
            var user = collection.Find(Builders<BsonDocument>.Filter.Eq("Username", username)).FirstOrDefault();
            if (user == null)
            {
                return false; // Người dùng không tồn tại
            }

            // Kiểm tra mật khẩu
            string storedHashedPassword = user["Password"].AsString;

            return VerifyPassword(storedHashedPassword, password); // So sánh mật khẩu đã mã hóa
        }


        public bool UpdatePassword(string email, string newPassword)
        {
            try
            {
                var collection = GetCollection<BsonDocument>("User");
                string hashedPassword = HashPassword(newPassword);

                var filter = Builders<BsonDocument>.Filter.Eq("Email", email);
                var update = Builders<BsonDocument>.Update.Set("Password", hashedPassword);

                var result = collection.UpdateOne(filter, update);
                return result.ModifiedCount > 0; // Kiểm tra xem có bản ghi nào được cập nhật
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật mật khẩu: {ex.Message}");
            }
        }
        public bool UserExists(string email)
        {
            var collection = GetCollection<BsonDocument>("User");
            var user = collection.Find(Builders<BsonDocument>.Filter.Eq("Email", email)).FirstOrDefault();
            return user != null;
        }

        public ProfileData GetProfileData(string username)
        {
            var collection = _database.GetCollection<ProfileData>("User");
            var filter = Builders<ProfileData>.Filter.Eq("Username", username);
            return collection.Find(filter).FirstOrDefault();
        }

        public bool UpdateProfileData(string username, int score)
        {
            try
            {
                var collection = GetCollection<BsonDocument>("User");

                // Tìm tài liệu dựa trên tên người dùng
                var filter = Builders<BsonDocument>.Filter.Eq("Username", username);

                // Lấy tài liệu hiện tại từ cơ sở dữ liệu
                var user = collection.Find(filter).FirstOrDefault();
                if (user == null)
                {
                    throw new Exception("Người dùng không tồn tại.");
                }

                // Lấy điểm cao nhất hiện tại và số lần chơi game
                int currentHighestScore = user.GetValue("HighestScore").AsInt32;
                int gamesPlayed = user.GetValue("GamesPlayed").AsInt32;

                // Xác định điểm cao nhất mới
                int newHighestScore = Math.Max(currentHighestScore, score);
                int newGamesPlayed = gamesPlayed + 1;

                // Tạo lệnh cập nhật
                var update = Builders<BsonDocument>.Update
                    .Set("HighestScore", newHighestScore)
                    .Set("GamesPlayed", newGamesPlayed);

                // Thực hiện cập nhật
                var result = collection.UpdateOne(filter, update);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật thông tin cá nhân: {ex.Message}");
            }
        }
    }
}