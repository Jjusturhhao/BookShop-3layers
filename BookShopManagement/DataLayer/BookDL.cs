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
using System.Collections;
using System.Text.RegularExpressions;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;


namespace DataLayer
{
    public class BookDL : DataProvider
    {
        //public List<Book> GetBooks()
        //{
        //    List<Book> books = new List<Book>();
        //    string sql = "SELECT b.BookID, b.BookName, c.CategoryName, b.Author, b.Price, b.BookImage " +
        //     "FROM Book b " +
        //     "JOIN BookCategory c ON b.CategoryID = c.CategoryID " +
        //     "ORDER BY CAST(SUBSTRING(b.BookID, 5, LEN(b.BookID)) AS INT)";

        //    try
        //    {
        //        Connect();
        //        SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
        //        {
        //            while (reader.Read())
        //            {
        //                string bookid = reader["BookID"].ToString();
        //                string bookName = reader["BookName"].ToString();
        //                string categoryID = reader["CategoryName"].ToString();
        //                string author = reader["Author"].ToString();
        //                int price = Convert.ToInt32(reader["Price"]);
        //                string bookiamge = reader["BookImage"].ToString();
        //                // string imagePath = Path.Combine(Application.StartupPath, "BookImage", bookImage);
        //                Book book = new Book(bookid, bookName, categoryID, author, price, bookiamge);
        //                books.Add(book);
        //            }
        //        }
        //        reader.Close();
        //        return books;
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        DisConnect();
        //    }
        //}

        public List<Book> GetBooks()
        {
            List<Book> books = new List<Book>();
            string sql = @"
        SELECT b.BookID, b.BookName, c.CategoryName, b.Author, b.Price, b.BookImage, b.IsVisible, b.Note
        FROM Book b
        JOIN BookCategory c ON b.CategoryID = c.CategoryID
        ORDER BY CAST(SUBSTRING(b.BookID, 5, LEN(b.BookID)) AS INT)";
            try
            {
                Connect();
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    string bookid = reader["BookID"].ToString();
                    string bookName = reader["BookName"].ToString();
                    string categoryName = reader["CategoryName"].ToString();
                    string author = reader["Author"]?.ToString();
                    int price = reader["Price"] != DBNull.Value ? Convert.ToInt32(reader["Price"]) : 0;
                    string bookImage = reader["BookImage"]?.ToString();
                    bool isVisible = reader["IsVisible"] != DBNull.Value && Convert.ToBoolean(reader["IsVisible"]);
                    string note = reader["Note"]?.ToString();

                    // Tạo đường dẫn hình ảnh trong thư mục bin/Debug/BookImage
                    string imagePath = Path.Combine(System.Windows.Forms.Application.StartupPath, "BookImage", bookImage);


                    // Kiểm tra nếu hình ảnh tồn tại, nếu không, sử dụng hình ảnh mặc định
                    if (!File.Exists(imagePath))
                    {
                        imagePath = Path.Combine(System.Windows.Forms.Application.StartupPath, "BookImage", "bookdefault.jpg"); // Sử dụng hình ảnh mặc định từ thư mục
                    }

                    // Tạo đối tượng Book
                    Book book = new Book(bookid, bookName, categoryName, author, price, imagePath);
                    book.IsVisible = isVisible;
                    book.Note = note;

                    books.Add(book);
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

        public Book GetBookByID(string id)
        {
            Book book = null;
            string sql = "SELECT b.BookID, b.BookName, b.CategoryID, c.CategoryName, b.Author, b.Price, b.BookImage, b.Note " +
                         "FROM Book b " +
                         "JOIN BookCategory c ON b.CategoryID = c.CategoryID " +
                         "WHERE BookID = @BookID";
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@BookID", id);
                SqlDataReader reader = cmd.ExecuteReader();
                string bookName = "", categoryID = "", categoryName = "", author = "", bookImageUrl = "", note = "";
                int price = 0;
                if (reader.Read())
                {
                    bookName = reader["BookName"].ToString();
                    categoryID = reader["CategoryID"].ToString();
                    categoryName = reader["CategoryName"].ToString();
                    author = reader["Author"] != DBNull.Value ? reader["Author"].ToString() : "";
                    price = reader["Price"] != DBNull.Value ? Convert.ToInt32(reader["Price"]) : 0;
                    bookImageUrl = reader["BookImage"] != DBNull.Value ? reader["BookImage"].ToString() : "bookdefault.jpg";
                    note = reader["Note"] != DBNull.Value ? reader["Note"].ToString() : "";
                }
                reader.Close();

                int quantity = GetQuantity(id);
                book = new Book(id, bookName, categoryID, author, price, bookImageUrl, note)
                {
                    Categoryname = categoryName,
                    Quantity = quantity
                };
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

        public List<Book> SearchBook(string keyword)
        {
            string bookID, categoryID, bookName, author;
            List<Book> books = new List<Book>();

            bool isBookIdExact = Regex.IsMatch(keyword.Trim(), @"^BOOK\d+$", RegexOptions.IgnoreCase);

            string sql;
            if (isBookIdExact)
            {
                sql = @"
                SELECT b.BookID, b.CategoryID, c.CategoryName, b.BookName, b.Author, b.Price, b.Bookimage, b.Note 
                FROM Book b
                JOIN BookCategory c ON b.CategoryID = c.CategoryID
                WHERE b.BookID COLLATE Latin1_General_CI_AI = @ExactID";
            }
            else
            {
                sql = @"
                SELECT b.BookID, b.CategoryID, c.CategoryName, b.BookName, b.Author, b.Price, b.Bookimage, b.Note 
                FROM Book b
                JOIN BookCategory c ON b.CategoryID = c.CategoryID
                WHERE 
                    b.BookID COLLATE Latin1_General_CI_AI LIKE @Keyword OR
                    b.CategoryID COLLATE Latin1_General_CI_AI LIKE @Keyword OR 
                    c.CategoryName COLLATE Latin1_General_CI_AI LIKE @Keyword OR 
                    b.BookName COLLATE Latin1_General_CI_AI LIKE @Keyword OR 
                    b.Author COLLATE Latin1_General_CI_AI LIKE @Keyword OR 
                    CONVERT(NVARCHAR, b.Price) COLLATE Latin1_General_CI_AI LIKE @Keyword";
            }

            try
            {
                Connect();
                using (var cmd = new SqlCommand(sql, cn))
                {
                    if (isBookIdExact)
                        cmd.Parameters.AddWithValue("@ExactID", keyword.Trim());
                    else
                        cmd.Parameters.AddWithValue("@Keyword", "%" + keyword.Trim() + "%");

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            bookID = reader["BookID"].ToString();
                            categoryID = reader["CategoryName"].ToString();
                            bookName = reader["BookName"].ToString();
                            author = reader["Author"] != DBNull.Value ? reader["Author"].ToString() : "";
                            int price = reader["Price"] != DBNull.Value ? Convert.ToInt32(reader["Price"]) : 0;
                            string bookImage = reader["Bookimage"] != DBNull.Value ? reader["Bookimage"].ToString() : "bookdefault.jpg";
                            string note = reader["Note"] != DBNull.Value ? reader["Note"].ToString() : "";

                            Book book = new Book(bookID, bookName, categoryID, author, price, bookImage, note);
                            books.Add(book);
                        }
                    }
                }
                return books;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while searching book: " + ex.Message);
            }
            finally
            {
                DisConnect();
            }
        }

        public int GetQuantity(string id)
        {
            try
            {
                Connect();
                string sql = "GetStockQuantity";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookID", id);

                object result = cmd.ExecuteScalar();
                return result != DBNull.Value ? Convert.ToInt32(result) : 0;
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
            List<Book> books = GetBooks();

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

        public int Add(Book book)
        {
            string sql = "INSERT INTO Book (BookID, CategoryID, BookName, Author, Price, Bookimage) " +
                         "VALUES (N'" + book.Bookid + "', N'" + book.Categoryid + "', N'" + book.Bookname + "', N'" + book.Author + "', " + book.Price + ", N'" + book.Bookimage + "')";

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

            if (!string.IsNullOrEmpty(book.Categoryid))
                updates.Add("CategoryID = N'" + book.Categoryid.Replace("'", "''") + "'");

            if (!string.IsNullOrEmpty(book.Bookname))
                updates.Add("BookName = N'" + book.Bookname.Replace("'", "''") + "'");

            if (!string.IsNullOrEmpty(book.Author))
                updates.Add("Author = N'" + book.Author.Replace("'", "''") + "'");

            if (book.Price != 0)
                updates.Add("Price = " + book.Price);

            if (!string.IsNullOrEmpty(book.Bookimage))
                updates.Add("BookImage = N'" + book.Bookimage.Replace("'", "''") + "'");

            updates.Add("IsVisible = " + (book.IsVisible ? 1 : 0)); // Cập nhật trạng thái hiển thị

            if (!string.IsNullOrEmpty(book.Note))
                updates.Add("Note = N'" + book.Note.Replace("'", "''") + "'");
            else
                updates.Add("Note = NULL");

            if (updates.Count == 0)
                throw new Exception("Không có thông tin nào để cập nhật.");

            sql += string.Join(", ", updates);
            sql += " WHERE BookID = N'" + book.Bookid.Replace("'", "''") + "'";

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



        public bool Exists(string bookID)
        {
            string sql = "SELECT COUNT(*) FROM Book WHERE BookID = @BookID";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@BookID", bookID);

            try
            {
                object result = MyExecuteScalar(cmd); // Gọi hàm đúng overload
                int count = Convert.ToInt32(result);
                return count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi kiểm tra tồn tại BookID: " + ex.Message);
            }
        }

        public int AddBookFromStock(Book book)
        {
            string sql = "INSERT INTO Book (BookID, BookName, CategoryID, Author, Price, BookImage, IsVisible) " +
                         "VALUES (@BookID, @BookName, @CategoryID, NULL, NULL, NULL, 0)";
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql))
                {
                    cmd.Parameters.AddWithValue("@BookID", book.Bookid);
                    cmd.Parameters.AddWithValue("@BookName", book.Bookname);
                    cmd.Parameters.AddWithValue("@CategoryID", book.Categoryid);
                    return MyExecuteNonQuery(cmd);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm sách từ kho: " + ex.Message);
            }
        }
    }
}
