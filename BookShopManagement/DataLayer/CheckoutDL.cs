using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using TransferObject;
using System.Windows.Forms;
using System.Diagnostics;

namespace DataLayer
{
    public class CheckoutDL : DataProvider
    {
        private OrderDL orderDL;
        
        public List<Book> GetBooks()
        {
            string sql = "SELECT b.BookID, b.BookName, b.Price, s.Quantity " +
                "FROM Book b " +
                "LEFT JOIN Stock s ON b.BookID = s.BookID " +
                "ORDER BY b.BookID";

            List<Book> books = new List<Book>();

            try
            {
                Connect();
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    string bookID = reader["BookID"].ToString();
                    string bookName = reader["BookName"].ToString();
                    int price = Convert.ToInt32(reader["Price"]);
                    int quantity = Convert.ToInt32(reader["Quantity"]);

                    Book book = new Book(bookID, bookName, price, quantity);
                    books.Add(book);
                }
                reader.Close();
                return books;
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
        public List<Book> GetBooksByName(string kw)
        {
            string sql = "SELECT b.BookID, b.BookName, b.Price, s.quantity " +
                     "FROM Book b " +
                     "LEFT JOIN Stock s ON b.BookID = s.BookID " + 
                     "WHERE b.BookName LIKE @kw " +
                     "ORDER BY b.BookID ";

            List<Book> booksByKw = new List<Book>();

            try
            {
                Connect();

                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@kw", "%" + kw + "%");
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string bookID = reader["BookID"].ToString();
                    string bookName = reader["BookName"].ToString();
                    int price = Convert.ToInt32(reader["Price"]);
                    int quantity = Convert.ToInt32(reader["Quantity"]);

                    Book book = new Book(bookID, bookName, price, quantity);
                    booksByKw.Add(book);
                }
                reader.Close();
                return booksByKw;
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
        public List<Book> GetBooksByCategory(string category)
        {
            string sql = "SELECT b.BookID, b.BookName, b.Price, s.quantity " +
                     "FROM Book b " +
                     "LEFT JOIN Stock s ON b.BookID = s.BookID " +
                     "WHERE b.CategoryID = @category " +
                     "ORDER BY b.BookID ";

            List<Book> booksByCate = new List<Book>();

            try
            {
                Connect();

                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@category", category);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string bookID = reader["BookID"].ToString();
                    string bookName = reader["BookName"].ToString();
                    int price = Convert.ToInt32(reader["Price"]);
                    int quantity = Convert.ToInt32(reader["Quantity"]);

                    Book book = new Book(bookID, bookName, price, quantity);
                    booksByCate.Add(book);
                }
                reader.Close();
                return booksByCate;
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
        public List<CartItem> GetCartItemsFromDgv(DataGridView dgvDetails)
        {
            List<CartItem> cartItems = new List<CartItem>();

            foreach (DataGridViewRow row in dgvDetails.Rows)
            {
                // Kiểm tra xem row có dữ liệu hợp lệ không
                if (row.Cells["Tên sách"].Value != null && row.Cells["Số lượng"].Value != null && row.Cells["Đơn giá"].Value != null)
                {
                    string stockID = row.Cells["Mã kho"].Value.ToString();
                    string bookID = row.Cells["Mã sách"].Value.ToString();
                    string bookName = row.Cells["Tên sách"].Value.ToString();
                    int quantity = Convert.ToInt32(row.Cells["Số lượng"].Value);
                    int unitPrice = Convert.ToInt32(row.Cells["Đơn giá"].Value);

                    CartItem item = new CartItem(bookID, bookName, unitPrice, quantity);
                    item.StockID = stockID;
                    cartItems.Add(item);
                }
            }
            return cartItems;
        }
        public List<BookCategoryStock> LoadCategories()
        {
            List<BookCategoryStock> categories = new List<BookCategoryStock>();

            try
            {
                cn.Open();

                string sql = "SELECT * FROM BookCategory";
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    string categoryID = reader["CategoryID"].ToString();
                    string categoryName = reader["CategoryName"].ToString();

                    categories.Add(new BookCategoryStock(categoryID, categoryName));
                }
                reader.Close();
                return categories;
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
        public int GetQuantity(string bookID)
        {
            try
            {
                Connect();

                string sql = "GetStockQuantity ";  // Tên của stored procedure
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.CommandType = CommandType.StoredProcedure;  
                cmd.Parameters.AddWithValue("@BookID", bookID);  

                object result = cmd.ExecuteScalar();
                return Convert.ToInt32(result);  
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GetStockID(string bookID)
        {
            try
            {
                Connect();

                string sql = "SELECT StockID FROM Stock WHERE BookID = @bookID"; 
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@BookID", bookID);

                    object result = cmd.ExecuteScalar();
                    return result.ToString();
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
    }
}
