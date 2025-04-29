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
    public class BookDL : DataProvider
    {
        public List<Book> GetBooks()
        {
            List<Book> books = new List<Book>();
            string sql = "SELECT * FROM Book";
            try
            {
                Connect();
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                {
                    while (reader.Read())
                    {
                        string bookid = reader["BookID"].ToString();
                        string bookName = reader["BookName"].ToString();
                        string categoryID = reader["CategoryID"].ToString();
                        string author = reader["Author"].ToString();
                        int price = Convert.ToInt32(reader["Price"]);
                        string bookiamge = reader["BookImage"].ToString();
                        Book book = new Book(bookid, bookName, categoryID, author, price, bookiamge);
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

        public Book Reset()
        {
            return new Book("", "", "", "", 0, null);
        }
        public List<BookCategoryStock> bookCategoryStocks()
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

        public int Add(Book book)
        {
            string sql = "INSERT INTO Book (BookID, CategoryID, BookName, Author, Price, Bookimage) " +
                         "VALUES('" + book.Bookid + "', '" + book.Categoryid + "', '" + book.Bookname + "', '" + book.Author + "', " + book.Price + ", '" + book.Bookimage + "')";
            try
            {
                return MyExecuteNonQuery(sql, CommandType.Text);
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

        public int Delete(Book book)
        {
            string sql = "DELETE FROM Book WHERE 1=1";
            sql += " AND CategoryID = '" + book.Categoryid + "'";
            if (!string.IsNullOrEmpty(book.Bookname))
                sql += " AND BookName = '" + book.Bookname.Replace("'", "''") + "'";
            if (!string.IsNullOrEmpty(book.Author))
                sql += " AND Author = '" + book.Author.Replace("'", "''") + "'";
            if (book.Price != 0)
                sql += " AND Price = " + book.Price;
            try
            {
                return MyExecuteNonQuery(sql, CommandType.Text);
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

        public int Update(Book book)
        {
            string sql = "UPDATE Book SET ";

            List<string> updates = new List<string>();

            updates.Add("CategoryID = '" + book.Categoryid + "'");
            if (!string.IsNullOrEmpty(book.Bookname))
                updates.Add("BookName = '" + book.Bookname.Replace("'", "''") + "'");
            if (!string.IsNullOrEmpty(book.Author))
                updates.Add("Author = '" + book.Author.Replace("'", "''") + "'");
            if (book.Price != 0)
                updates.Add("Price = " + book.Price);
            if (!string.IsNullOrEmpty(book.Bookimage))
                updates.Add("Bookimage = '" + book.Bookimage + "'");
            if (updates.Count == 0)
                throw new Exception("Không có thông tin nào để cập nhật.");

            sql += string.Join(", ", updates);
            sql += " WHERE BookID = '" + book.Bookid + "'";

            try
            {
                return MyExecuteNonQuery(sql, CommandType.Text);
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

        public List<Book> SearchBook(string keyword)
        {
            string bookID, categoryID, bookName, author;

            List<Book> books = new List<Book>();
            string sql = "SELECT b.BookID, sl.Supplier_name, b.CategoryID, c.CategoryName, b.BookName, b.Author, b.Price, b.Bookimage" +
                         "FROM Book b " +
                         "JOIN BookCategory c ON b.CategoryID = c.CategoryID " +
                         "JOIN Suppliers sl ON b.SupplierID = sl.Supplier_ID " +
                         "WHERE b.BookID LIKE N'%" + keyword + "%' OR " +
                         "sl.Supplier_name LIKE N'%" + keyword + "%' OR " +
                         "b.CategoryID LIKE N'%" + keyword + "%' OR " +
                         "c.CategoryName LIKE N'%" + keyword + "%' OR " +
                         "b.BookName LIKE N'%" + keyword + "%' OR " +
                         "b.Author LIKE N'%" + keyword + "%' OR " +
                         "CONVERT(NVARCHAR, b.Price) LIKE N'%" + keyword + "%' OR ";
            try
            {
                Connect();
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    bookID = reader["BookID"].ToString();
                    string supplierID = reader["Supplier_name"].ToString();
                    categoryID = reader["CategoryName"].ToString();
                    bookName = reader["BookName"].ToString();
                    author = reader["Author"].ToString();
                    int price = reader["Price"] != DBNull.Value ? Convert.ToInt32(reader["Price"]) : 0;
                    string bookImage = reader["Bookimage"].ToString();
                    Book book = new Book(bookID, bookName, categoryID, author, price, bookImage);
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
        public Book GetBookByID(string id)
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
                cmd.Parameters.AddWithValue("@BookID", id);

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

                int quantity = GetQuantity(id);
                book = new Book(id, bookName, categoryID, author, price, bookImageUrl);

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
        public int GetQuantity(string id)
        {
            try
            {
                Connect();
                string sql = "GetStockQuantity "; //stored procedure
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookID", id);

                object result = cmd.ExecuteScalar();
                return Convert.ToInt32(result);
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
    }
}
