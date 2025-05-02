using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferObject;

namespace DataLayer
{
    public class OrderDetailsDL : DataProvider
    {
        public List<OrderDetails> GetOrderDetails(string orderID)
        {
            List<OrderDetails> detailsList = new List<OrderDetails>();

            string sql = @"
                SELECT 
                    s.BookID AS BookID,
                    s.BookName AS BookName,
                    od.Qty_sold AS QuantitySold,
                    od.PriceAtOrderTime AS UnitPrice,
                    (od.Qty_sold * od.PriceAtOrderTime) AS TotalCost
                FROM OrderDetails od
                INNER JOIN Stock s ON od.BookID = s.BookID
                WHERE od.Order_ID = @OrderID";
            try
            {
                Connect();
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@OrderID", orderID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            OrderDetails detail = new OrderDetails
                            {
                                BookID = reader["BookID"].ToString(),
                                BookName = reader["BookName"].ToString(),
                                QuantitySold = Convert.ToInt32(reader["QuantitySold"]),
                                UnitPrice = Convert.ToInt32(reader["UnitPrice"]),
                            };

                            detailsList.Add(detail);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra khi lấy chi tiết đơn hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DisConnect();
            }
            return detailsList;
        }
        public void SaveOrderDetail(string orderID, List<CartItem> cartItems)
        {
            string insertOrderDetailQuery = "INSERT INTO OrderDetails (Order_ID, BookID, Qty_sold, PriceAtOrderTime) " +
                                            "VALUES (@Order_ID, @BookID, @Qty_sold, @PriceAtOrderTime)";

            try
            {
                Connect();

                // Lặp qua từng sản phẩm trong giỏ hàng và lưu vào OrderDetails
                foreach (CartItem cartItem in cartItems)
                {
                    SqlCommand cmd = new SqlCommand(insertOrderDetailQuery, cn);
                    cmd.Parameters.AddWithValue("@Order_ID", orderID);
                    cmd.Parameters.AddWithValue("@BookID", cartItem.BookID);
                    cmd.Parameters.AddWithValue("@Qty_sold", cartItem.Quantity);
                    cmd.Parameters.AddWithValue("@PriceAtOrderTime", cartItem.UnitPrice);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lưu chi tiết đơn hàng: {ex.Message}");
            }
            finally
            {
                DisConnect();
            }
        }
    }
}
