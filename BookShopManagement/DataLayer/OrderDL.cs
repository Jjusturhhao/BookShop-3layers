﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferObject;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DataLayer
{
    public class OrderDL : DataProvider
    {
        public List<Order> GetOrders()
        {
            string sql = "SELECT o.Order_ID, o.PhoneNumber, e.Name AS Employee_Name, o.Order_Date, o.Status, b.Total_Cost AS Total_Cost " +
             "FROM Orders o " +
             "LEFT JOIN Bill_Generate b ON o.Order_ID = b.Order_ID " +
             "LEFT JOIN Users e ON o.Employee_ID = e.User_ID " +
             "ORDER BY CAST(SUBSTRING(o.Order_ID, 4, LEN(o.Order_ID) - 3) AS INT)";

            List<Order> orders = new List<Order>();

            try
            {
                Connect();
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    string orderId = reader["Order_ID"].ToString();
                    string phone = reader["PhoneNumber"].ToString();
                    string empName = reader["Employee_Name"] == DBNull.Value ? "Online" : reader["Employee_Name"].ToString();
                    DateTime orderDate = Convert.ToDateTime(reader["Order_Date"]);
                    string status = reader["Status"].ToString();
                    int totalCost = reader["Total_Cost"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Total_Cost"]);
                    
                    Order order = new Order(orderId, phone, empName, orderDate, status, totalCost);  // Cập nhật constructor Order
                    orders.Add(order);
                }
                reader.Close();
                return orders;
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

        public void UpdateOrderStatus(string orderID, string newStatus)
        {
            try
            {
                Connect();

                string sql = "UPDATE Orders SET Status = @Status WHERE Order_ID = @Order_ID";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@Order_ID", orderID);
                cmd.Parameters.AddWithValue("@Status", newStatus);

                cmd.ExecuteNonQuery();
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

        public List<string> GetEmployeeNames()
        {
            string sql = "SELECT Name FROM Users WHERE User_ID LIKE 'S%'"; 
            List<string> employeeNames = new List<string>();

            try
            {
                Connect();  // Kết nối đến cơ sở dữ liệu
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text); 

                while (reader.Read())
                {
                    string employeeName = reader["Name"].ToString();
                    employeeNames.Add(employeeName);
                }

                reader.Close();
                return employeeNames;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách tên nhân viên: " + ex.Message);
            }
            finally
            {
                DisConnect();  // Ngắt kết nối
            }
        }
        public string GenerateOrderID()
        {
            string newOrderID = string.Empty;
            string sql = "SELECT MAX(CAST(SUBSTRING(Order_ID, 4, LEN(Order_ID) - 3) AS INT)) FROM Orders ";
            int nextOrderId = 1; // Mặc định nếu chưa có Order nào
            try
            {
                Connect();
                using (SqlCommand getMaxOrderIDCmd = new SqlCommand(sql, cn))
                {
                    object maxIdObj = getMaxOrderIDCmd.ExecuteScalar();
                    if (maxIdObj != DBNull.Value) // Nếu có dữ liệu trong DB
                    {
                        nextOrderId = Convert.ToInt32(maxIdObj) + 1; // Lấy số lớn nhất + 1
                    }
                }
                newOrderID = "ORD" + nextOrderId;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DisConnect();  
            }
            return newOrderID;
        }
        
        public void SaveOrder(string orderID, string phone, string employeeID, DateTime orderDate, string status)
        {
            string insertOrderQuery = "INSERT INTO Orders (Order_ID, PhoneNumber, Employee_ID, Order_Date, Status) " +
                                      "VALUES (@Order_ID, @PhoneNumber, @Employee_ID, @Order_Date, @Status)";

            try
            {
                Connect();
                using (SqlCommand cmd = new SqlCommand(insertOrderQuery, cn))
                {
                    cmd.Parameters.AddWithValue("@Order_ID", orderID);
                    cmd.Parameters.AddWithValue("@PhoneNumber", phone);
                    cmd.Parameters.AddWithValue("@Employee_ID", string.IsNullOrEmpty(employeeID) ? (object)DBNull.Value : employeeID);
                    cmd.Parameters.AddWithValue("@Order_Date", orderDate);
                    cmd.Parameters.AddWithValue("@Status", status);

                    cmd.ExecuteNonQuery(); // Thực thi câu lệnh insert
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine($"SQL Error: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error: {ex.Message}");
            }
            finally
            {
                DisConnect();
            }
        }

        //==
        public bool OrderStatus(string orderID, string newStatus)
        {
            string sql = "UPDATE Orders SET Status = @Status WHERE Order_ID = @OrderID";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Status", newStatus);
            cmd.Parameters.AddWithValue("@OrderID", orderID);

            DataProvider dataProvider = new DataProvider();
            int rows = dataProvider.MyExecuteNonQuery(cmd);

            return rows > 0;
        }
        public static string GetOrderStatus(string orderID)
        {
            string status = string.Empty;
            string sql = "SELECT Status FROM Orders WHERE Order_ID = @OrderID";

            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@OrderID", orderID);

            DataProvider dataProvider = new DataProvider();
            SqlDataReader reader = null;

            try
            {
                reader = dataProvider.MyExecuteReader(cmd); // Trả về SqlDataReader

                if (reader != null && reader.Read())
                {
                    status = reader["Status"].ToString(); // Lấy giá trị trạng thái
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // Đảm bảo đóng SqlDataReader và ngắt kết nối
                reader?.Close();
                dataProvider.DisConnect(); // Đảm bảo ngắt kết nối
            }

            return status;
        }
        //==
    }
}
