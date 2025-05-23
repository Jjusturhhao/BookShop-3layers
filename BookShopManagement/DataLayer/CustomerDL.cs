﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace DataLayer
{
    public class CustomerDL : DataProvider
    {
        public bool CheckCustomerExist(string phone)
        {
            string sql = "SELECT COUNT(*) FROM Customers WHERE PhoneNumber = @Phone";
            try
            {
                Connect();
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@Phone", phone);

                    // Thực thi truy vấn và lấy kết quả
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    // Kiểm tra nếu có khách hàng với số điện thoại này
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }
        }

        public void SaveCustomer(string phone, string name)
        {
            string sql = "INSERT INTO Customers (PhoneNumber, FullName) VALUES (@Phone, @Name)";
            try
            {
                Connect();
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@Name", name);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }
        }
        public Customer GetCustomerByPhone(string phone)
        {
            Customer customer = null;
            string sql = "SELECT * FROM Customers WHERE PhoneNumber = @PhoneNumber";
            try
            {
                Connect(); // mở kết nối DB
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@PhoneNumber", phone);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string name = reader["FullName"].ToString();

                    customer = new Customer(phone, name);
                }   
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy thông tin người dùng: " + ex.Message);
            }
            finally
            {
                DisConnect();
            }
            return customer;
        }
    }
}
