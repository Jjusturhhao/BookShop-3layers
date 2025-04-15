using System;
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
            string sql = "SELECT o.Order_ID, u.Name AS Customer_Name, e.Name AS Employee_Name, o.Order_Date, o.Status, b.Total_Cost AS Total_Cost " +
                         "FROM Orders o " +
                         "LEFT JOIN Users u ON o.Customer_ID = u.User_ID " +
                         "LEFT JOIN Bill_Generate b ON o.Order_ID = b.Order_ID " +
                         "LEFT JOIN Users e ON o.Employee_ID = e.User_ID";

            List<Order> orders = new List<Order>();

            try
            {
                Connect();
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    string orderId = reader["Order_ID"].ToString();
                    string cusName = reader["Customer_Name"].ToString();
                    string empName = reader["Employee_Name"].ToString();  
                    DateTime orderDate = Convert.ToDateTime(reader["Order_Date"]);
                    string status = reader["Status"].ToString();
                    int totalCost = Convert.ToInt32(reader["Total_Cost"]);

                    Order order = new Order(orderId, cusName, empName, orderDate, status, totalCost);  // Cập nhật constructor Order
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
                throw;
            }
            finally
            {
                DisConnect();
            }
        }

        public List<string> GetEmployeeNames()
        {
            string sql = "SELECT Name FROM Users WHERE User_ID LIKE 'S%'"; // Truy vấn để lấy tên nhân viên có ID bắt đầu bằng 'S'

            List<string> employeeNames = new List<string>();

            try
            {
                Connect();  // Kết nối đến cơ sở dữ liệu
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);  // Thực thi truy vấn

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

    }
}
