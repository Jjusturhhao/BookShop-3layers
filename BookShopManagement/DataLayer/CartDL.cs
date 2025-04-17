using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferObject;

namespace DataLayer
{
    public class CartDL : DataProvider
    {
        public CartItem GetBookByID(string bookID)
        {
            CartItem item = null;
            string sql = "SELECT s.StockID, s.BookID, s.BookName, b.Price "+
                "FROM Stock s "+
                "INNER JOIN Book b ON s.BookID = b.BookID "+
                "WHERE s.BookID = @BookID";
            try
            {
                Connect();

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.Add("@BookID", System.Data.SqlDbType.VarChar).Value = bookID;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Chỉ cần đọc 1 bản ghi
                        if (reader.Read())
                        {
                            string stockID = reader["StockID"].ToString();  
                            string bookName = reader["BookName"].ToString();
                            int unitPrice = Convert.ToInt32(reader["Price"]);
                            int quantity = 1;

                            item = new CartItem(bookID, bookName, unitPrice, quantity);
                            item.StockID = stockID;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra khi lấy thông tin sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DisConnect();
            }
            return item;
        }
        
    }
}
