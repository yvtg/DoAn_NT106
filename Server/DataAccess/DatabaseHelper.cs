using System;
using System.Data;
using System.Data.SqlClient;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

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

        // Hàm đăng ký người dùng
        public bool RegisterUser(string username, string email, string password)
        {
            var collection = GetCollection<BsonDocument>("User");

            // Kiểm tra nếu người dùng đã tồn tại (theo email)
            var existingUser = collection.Find(Builders<BsonDocument>.Filter.Eq("Username", username)).FirstOrDefault();
            if (existingUser != null)
            {
                return false; // Người dùng đã tồn tại
            }

            // Mã hóa mật khẩu
            string hashedPassword = HashPassword(password);

            // Tạo document người dùng mới
            var newUser = new BsonDocument
            {
                { "Username", username },
                { "Email", email },
                { "Password", hashedPassword },
                { "HighestScore", 0 },
                { "HighestRank", 0 },
                { "LowestRank", 0 },
                { "GamesPlayed", 0 }
            };

            // Thêm người dùng vào database
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


        ////Cách dùng:
        //string connectionString = "mongodb://localhost:27017";//gắn link mongodb vào
        //string databaseName = "MyDatabase";

        //// Khởi tạo DatabaseHelper
        //DatabaseHelper dbHelper = new DatabaseHelper(connectionString, databaseName);

        //// Tên collection
        //string collectionName = "Users";

        //// Thêm một tài liệu (document) mới
        //var newUser = new BsonDocument
        //{
        //    { "Name", "Alice" },
        //    { "Age", 25 },
        //    { "Email", "alice@example.com" }
        //};
        //dbHelper.InsertDocument(collectionName, newUser);
        //Console.WriteLine("Thêm người dùng mới thành công.");

        /*
        private readonly string _connectionString;

        // Khởi tạo DatabaseHelper với chuỗi kết nối
        public DatabaseHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Phương thức kết nối cơ sở dữ liệu và thực hiện truy vấn
        public DataTable ExecuteQuery(string query)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        return table;
                    }
                }
            }
        }

        // Phương thức thực hiện các truy vấn không trả về dữ liệu (INSERT, UPDATE, DELETE)
        public int ExecuteNonQuery(string query)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        */
    }
}
