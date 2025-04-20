using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;
using System.Net;
using DataLayer;
using System.Diagnostics;
using System.Data.Common;

namespace DataLayer
{
    public class BookDL:DataProvider
    {
        public List<Book> GetBooks()
        {
            List<Book> books = new List<Book>();
            string sql = "SELECT * FROM Book";

            try
            {
                Connect();
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);

                using (WebClient client = new WebClient())
                {
                    while (reader.Read())
                    {
                        string bookid = reader["BookID"].ToString();
                        string bookName = reader["BookName"].ToString();
                        string categoryID = reader["CategoryID"].ToString();
                        string author = reader["Author"].ToString();
                        int price = Convert.ToInt32(reader["Price"]);
                        string bookImageUrl = reader["BookImage"].ToString();

                        //byte[] imageBytes = null;
                        //if (!string.IsNullOrEmpty(bookImageUrl))
                        //{
                        //    try
                        //    {
                        //        imageBytes = client.DownloadData(bookImageUrl);
                        //    }
                        //    catch
                        //    {
                        //        imageBytes = null;
                        //    }
                        //}

                        Book book = new Book(bookid, bookName, categoryID, author, price, bookImageUrl);
                        books.Add(book);
                    }
                }

                reader.Close();
                return books;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }
        }
        public string GenerateNextBookID()
        {
            List<Book> books = new List<Book>();

            int maxID = 0;
            foreach (var book in books)
            {
                if (book.Bookid.StartsWith("BOOK"))
                {
                    string numberPart = book.Bookid.Substring(4);
                    if (int.TryParse(numberPart, out int idNum))
                    {
                        if (idNum > maxID)
                            maxID = idNum;
                    }
                }
            }

            int nextID = maxID + 1;
            return $"BOOK{nextID:D1}";
        }

        public Book GetEmptyBook()
        {
            return new Book("", "", "", "", 0, null);
        }
        public Book GetBookByID(string bookID)
        {
            Book book = null;
            string sql = "SELECT b.BookID, b.BookName, b.CategoryID, c.CategoryName, b.Author, b.Price, b.BookImage " +
                "FROM Book b " +
                "JOIN BookCategory c ON b.CategoryID = c.CategoryID " +
                "WHERE BookID = @BookID";
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@BookID", bookID);

                SqlDataReader reader = cmd.ExecuteReader();
                string bookName = "", categoryID = "", categoryName = "", author = "", bookImageUrl = "";
                int price = 0;
                if (reader.Read())
                {
                    bookName = reader["BookName"].ToString();
                    categoryID = reader["CategoryID"].ToString();
                    categoryName = reader["CategoryName"].ToString();
                    author = reader["Author"].ToString();
                    price = Convert.ToInt32(reader["Price"]);
                    bookImageUrl = reader["BookImage"].ToString();
                }
                reader.Close();

                int quantity = GetQuantity(bookID);
                book = new Book(bookID, bookName, categoryID, author, price, bookImageUrl);
                book.Categoryname = categoryName;
                book.Quantity = quantity;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }
            return book;
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
            finally
            {
                DisConnect();
            }
        }
        //=====================
        public List<Book> GetBooks1()
        {
            string bookid, bookname, categoryid, author, bookImageUrl;
            int price;

            List<Book> books = new List<Book>();
            string sql = "SELECT b.BookID,b.BookName, c.CategoryName, b.Author, b.Price, b.BookImage " +
                "FROM Book b " + "JOIN BookCategory c ON b.CategoryID = c.CategoryID";
            
            try
            {
                Connect();
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    bookid = reader["BookID"].ToString();
                    bookname = reader["BookName"].ToString();
                    categoryid = reader["CategoryName"].ToString();
                    author = reader["Author"].ToString();
                    price = Convert.ToInt32(reader["Price"]);
                    bookImageUrl = reader["BookImage"].ToString();

                    Book book = new Book(bookid,bookname,categoryid,author,price, bookImageUrl);
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
        public Book Refest1()
        {
            return new Book("","","","",0,null);
        }
        public List<BookCategoryStock> bookCategoryStocks1()
        {
            string CategoryID, Categoryname;
            List<BookCategoryStock> bookCategoryStocks = new List<BookCategoryStock>();
            string sql = "SELECT * FROM BookCategory";
            try
            {
                Connect();
                SqlDataReader reader1 = MyExecuteReader(sql, CommandType.Text);
                while (reader1.Read())
                {
                    CategoryID = reader1["CategoryID"].ToString();
                    Categoryname = reader1["CategoryName"].ToString();
                    BookCategoryStock bookCategoryStock = new BookCategoryStock(CategoryID, Categoryname);
                    bookCategoryStocks.Add(bookCategoryStock);
                }
                reader1.Close();
                return bookCategoryStocks;
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
        public string GenerateNextBookID1()
        {
            List<Book> books1 = GetBooks1();

            int maxID = 0;
            foreach (var book in books1)
            {
                if (book.Bookid.StartsWith("BOOK"))
                {
                    string numberPart = book.Bookid.Substring(4);
                    if (int.TryParse(numberPart, out int idNum))
                    {
                        if (idNum > maxID)
                            maxID = idNum;
                    }
                }
            }

            int nextID = maxID + 1;
            return $"BOOK{nextID:D1}";
        }
    }
}
