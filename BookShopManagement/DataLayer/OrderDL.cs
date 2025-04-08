using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataLayer
{
    public class OrderDL : DataProvider
    {
        public DataTable GetOrders()
        {
            DataTable dt = new DataTable();
            try
            {
                Connect();

                string sql = "SELECT o.Order_ID, u.Name AS Customer_Name, o.Employee_ID, o.Order_Date, o.Status, b.Total_Cost AS Total_Cost " +
                "FROM Orders o " +
                "LEFT JOIN Users u ON o.Customer_ID = u.User_ID " +
                "LEFT JOIN Bill_Generate b ON o.Order_ID = b.Order_ID ";
                SqlCommand cmd = new SqlCommand(sql, cn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }

            return dt;
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
