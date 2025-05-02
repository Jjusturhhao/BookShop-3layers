using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using TransferObject;
using System.Windows.Forms;

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
                         "WHERE b.IsVisible = 1 " +
                         "ORDER BY CAST(SUBSTRING(b.BookID, 5, LEN(b.BookID)) AS INT)";

            List<Book> books = new List<Book>();

            try
            {
                Connect();
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    string bookID = reader["BookID"].ToString();
                    string bookName = reader["BookName"].ToString();
                    int price = reader["Price"] != DBNull.Value ? Convert.ToInt32(reader["Price"]) : 0;
                    int quantity = reader["Quantity"] != DBNull.Value ? Convert.ToInt32(reader["Quantity"]) : 0;

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
            string sql = "SELECT b.BookID, b.BookName, b.Price, s.Quantity " +
                         "FROM Book b " +
                         "LEFT JOIN Stock s ON b.BookID = s.BookID " +
                         "WHERE b.BookName LIKE @kw AND b.IsVisible = 1 " +
                         "ORDER BY CAST(SUBSTRING(b.BookID, 5, LEN(b.BookID)) AS INT)";

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
                    int price = reader["Price"] != DBNull.Value ? Convert.ToInt32(reader["Price"]) : 0;
                    int quantity = reader["Quantity"] != DBNull.Value ? Convert.ToInt32(reader["Quantity"]) : 0;

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
            string sql = "SELECT b.BookID, b.BookName, b.Price, s.Quantity " +
                         "FROM Book b " +
                         "LEFT JOIN Stock s ON b.BookID = s.BookID " +
                         "WHERE b.CategoryID = @category AND b.IsVisible = 1 " +
                         "ORDER BY CAST(SUBSTRING(b.BookID, 5, LEN(b.BookID)) AS INT)";

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
                    int price = reader["Price"] != DBNull.Value ? Convert.ToInt32(reader["Price"]) : 0;
                    int quantity = reader["Quantity"] != DBNull.Value ? Convert.ToInt32(reader["Quantity"]) : 0;

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
                if (row.Cells["Tên sách"].Value != null && row.Cells["Số lượng"].Value != null && row.Cells["Đơn giá"].Value != null)
                {
                    string bookID = row.Cells["Mã sách"].Value.ToString();
                    string bookName = row.Cells["Tên sách"].Value.ToString();
                    int quantity = Convert.ToInt32(row.Cells["Số lượng"].Value);
                    int unitPrice = Convert.ToInt32(row.Cells["Đơn giá"].Value);

                    CartItem item = new CartItem(bookID, bookName, unitPrice, quantity);
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
                Connect();

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

                string sql = "GetStockQuantity";  // stored procedure
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookID", bookID);

                object result = cmd.ExecuteScalar();
                return result != DBNull.Value ? Convert.ToInt32(result) : 0;
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
