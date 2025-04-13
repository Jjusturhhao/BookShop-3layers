using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using TransferObject;

namespace DataLayer
{
    public class CheckoutDL : DataProvider
    {
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

        public List<Category> LoadCategories()
        {
            List<Category> categories = new List<Category>();

            try
            {
                Connect();

                string sql = "SELECT * FROM BookCategory";
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    string categoryID = reader["CategoryID"].ToString();
                    string categoryName = reader["CategoryName"].ToString();

                    categories.Add(new Category(categoryID, categoryName));
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
    }
}
