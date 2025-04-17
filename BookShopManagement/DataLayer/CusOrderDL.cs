using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;
using System.Data.SqlTypes;

namespace DataLayer
{
    public class CusOrderDL:DataProvider
    {
        public List<CusOrder> GetCusOrdersByUsername(string username)
        {
            string sql = @"
            SELECT 
                o.Order_ID, 
                o.Order_Date, 
                o.Status, 
                ISNULL(SUM(od.Qty_sold * od.PriceAtOrderTime), 0) AS Total
            FROM Orders o
            JOIN Users u ON o.Customer_ID = u.User_ID
            LEFT JOIN OrderDetails od ON o.Order_ID = od.Order_ID
            WHERE u.Username = @Username
            GROUP BY o.Order_ID, o.Order_Date, o.Status
            ORDER BY o.Order_Date ASC";


            List<CusOrder> orders = new List<CusOrder>();

            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@Username", username);
                SqlDataReader reader = cmd.ExecuteReader();

                int index = 1;
                while (reader.Read())
                {
                    string orderId = reader["Order_ID"].ToString();
                    DateTime orderDate = Convert.ToDateTime(reader["Order_Date"]);
                    string status = reader["Status"].ToString();
                    int total = reader["Total"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Total"]);

                    CusOrder order = new CusOrder(orderId, orderDate, total, status)
                    {
                        Index = index++
                    };
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
    }
}
