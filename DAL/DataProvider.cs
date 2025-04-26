using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.Data.SqlClient; 
namespace DAL
{
    public class DataProvider
    {
        private static string connectionStr = "";

        private static string GetConnectionStr()
        {
            string connectionString = "";
            string configFilePath = "config.txt";

            if (File.Exists(configFilePath))
            {
                using (StreamReader reader = new StreamReader(configFilePath))
                {
                    string auth = CryptoHelper.DecryptString(reader.ReadLine());
                    string server = CryptoHelper.DecryptString(reader.ReadLine());
                    string database = CryptoHelper.DecryptString(reader.ReadLine());

                    if (auth == "window")
                    {
                        connectionString = $"Server={server};Database={database};Integrated Security=True;TrustServerCertificate=True;";
                    }
                    else
                    {
                        string uid = CryptoHelper.DecryptString(reader.ReadLine());
                        string password = CryptoHelper.DecryptString(reader.ReadLine());
                        connectionString = $"Server={server};User ID={uid};Password={password};TrustServerCertificate=True;";
                    }
                }
            }
            return connectionString;
        }

        private static void AddParameters(SqlCommand command, object[] parameters)
        {
            if (parameters == null) return;

            // Lấy ra tên các tham số trong câu lệnh
            string[] paramNames = command.CommandText
                            .Split(new char[] { ' ', ',', '(', ')', '=' }, StringSplitOptions.RemoveEmptyEntries) // tách chuỗi thành mảng các chuỗi con dựa vào các ký tự phân cách và lọc bỏ các chuỗi rỗng
                            .Where(part => part.StartsWith("@")) // lọc ra các chuỗi bắt đầu bằng @
                            .ToArray();
            int paramLength = paramNames.Length;

            // kiểm tra số lượng tham số
            if (paramLength == 0) return;
            if (parameters.Length != paramLength)
            {
                throw new ArgumentException($"Số lượng tham số không khớp!");
            }

            // thêm tham số vào command
            for (int i = 0; i < paramLength; i++)
            {
                command.Parameters.AddWithValue(paramNames[i], parameters[i]);
            }
        }


        public static DataTable ExecuteQuery(string query, object[] parameters = null)
        {
            // Nếu chưa có chuỗi kết nối thì lấy từ file config
            if (string.IsNullOrEmpty(connectionStr))
            {
                connectionStr = GetConnectionStr();
            }
           
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    AddParameters(command, parameters);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable data = new DataTable();
                        adapter.Fill(data);
                        return data;
                    }
                }
            }
        }

        public static int ExecuteNonQuery(string query, object[] parameters = null)
        {
            // Nếu chưa có chuỗi kết nối thì lấy từ file config
            if (string.IsNullOrEmpty(connectionStr))
            {
                connectionStr = GetConnectionStr();
            }
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    AddParameters(command, parameters);
                    return command.ExecuteNonQuery();
                }
            }
        }

        public static object ExecuteScalar(string query, object[] parameters = null)
        {
            // Nếu chưa có chuỗi kết nối thì lấy từ file config
            if (string.IsNullOrEmpty(connectionStr))
            {
                connectionStr = GetConnectionStr();
            }
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    AddParameters(command, parameters);
                    return command.ExecuteScalar();
                }
            }
        }
    }
}
