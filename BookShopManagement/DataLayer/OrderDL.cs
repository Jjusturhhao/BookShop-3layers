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
            string sql = "SELECT o.Order_ID, u.Name AS Customer_Name, o.Employee_ID, o.Order_Date, o.Status, b.Total_Cost AS Total_Cost " +
                "FROM Orders o " +
                "LEFT JOIN Users u ON o.Customer_ID = u.User_ID " +
                "LEFT JOIN Bill_Generate b ON o.Order_ID = b.Order_ID ";
            
            List<Order> orders = new List<Order>();

            try
            {
                Connect();
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    string orderId = reader["Order_ID"].ToString();
                    string cusName = reader["Customer_Name"].ToString();
                    string empId = reader["Employee_ID"].ToString();
                    DateTime orderDate = Convert.ToDateTime(reader["Order_Date"]);
                    string status = reader["Status"].ToString();
                    int totalCost = Convert.ToInt32(reader["Total_Cost"]);

                    Order order = new Order(orderId, cusName, empId, orderDate, status, totalCost);
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
        
        
    }
}
