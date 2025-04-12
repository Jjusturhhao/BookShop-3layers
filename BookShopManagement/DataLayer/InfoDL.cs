﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace DataLayer
{
    public class InfoDL:DataProvider
    {
        public Info GetUserInfo(string username)
        {
            Info userInfo = null;
            string sql = "SELECT * FROM Users WHERE Username = @Username";
            try
            {
                Connect(); // mở kết nối DB
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@Username", username);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string name = reader["Name"].ToString();
                    string pass = reader["Password"].ToString();
                    string address = reader["Address"].ToString();
                    string phone = reader["PhoneNumber"].ToString();
                    string email = reader["Email"].ToString();

                    userInfo = new Info(username, name, pass, address, phone, email);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                // Ghi log hoặc xử lý lỗi nếu cần
                Console.WriteLine("Lỗi khi lấy thông tin người dùng: " + ex.Message);
            }
            finally
            {
                DisConnect(); // đóng kết nối DB
            }
            return userInfo;
        }

        public bool UpdateUserInfo(Info info)
        {
            string sql = "UPDATE Users SET Address = @Address, Phone = @Phone, Email = @Email WHERE Username = @Username";

            SqlCommand cmd = new SqlCommand(sql);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Address", info.Address);
            cmd.Parameters.AddWithValue("@Phone", info.Phone);
            cmd.Parameters.AddWithValue("@Email", info.Email);
            cmd.Parameters.AddWithValue("@Username", info.Username);

            return MyExecuteNonQuery(cmd) > 0;
        }


    }
}
