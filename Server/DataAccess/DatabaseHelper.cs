using System;
using System.Data;
using System.Data.SqlClient;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;

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
