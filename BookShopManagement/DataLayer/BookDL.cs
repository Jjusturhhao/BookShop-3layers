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
        public List<Book> GetBooks()
        {
            List<Book> books = new List<Book>();
            string sql = "SELECT b.BookID, b.BookName, c.CategoryName, b.Author, b.Price, b.BookImage " +
             "FROM Book b " +
             "JOIN BookCategory c ON b.CategoryID = c.CategoryID " +
             "ORDER BY CAST(SUBSTRING(b.BookID, 5, LEN(b.BookID)) AS INT)";

            try
            {
                Connect();
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                {
                    while (reader.Read())
                    {
                        string bookid = reader["BookID"].ToString();
                        string bookName = reader["BookName"].ToString();
                        string categoryID = reader["CategoryName"].ToString();
                        string author = reader["Author"].ToString();
                        int price = Convert.ToInt32(reader["Price"]);
                        string bookiamge = reader["BookImage"].ToString();
                       // string imagePath = Path.Combine(Application.StartupPath, "BookImage", bookImage);
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

        //public List<Book> GetBooks()
        //{
        //    List<Book> books = new List<Book>();
        //    string sql = "SELECT b.BookID, b.BookName, c.CategoryName, b.Author, b.Price, b.BookImage " +
        //                 "FROM Book b " +
        //                 "JOIN BookCategory c ON b.CategoryID = c.CategoryID " +
        //                 "ORDER BY CAST(SUBSTRING(b.BookID, 5, LEN(b.BookID)) AS INT)";

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
        //                string bookImage = reader["BookImage"].ToString(); // Tên tệp hình ảnh từ cơ sở dữ liệu

        //                // Tạo đường dẫn đầy đủ đến thư mục lưu trữ hình ảnh
        //                string imagePath = Path.Combine(Application.StartupPath, "BookImage", bookImage);

        //                // Kiểm tra sự tồn tại của tệp hình ảnh và hiển thị nó
        //                try
        //                {
        //                    // Tạo đối tượng Book và thêm vào danh sách
        //                    Book book = new Book(bookid, bookName, categoryID, author, price, bookImage);

        //                    // Nếu tệp hình ảnh tồn tại, hiển thị hình ảnh
        //                    if (File.Exists(imagePath))
        //                    {
        //                        pictureBox.Image = Image.FromFile(imagePath);  // Hiển thị hình ảnh
        //                    }
        //                    else
        //                    {
        //                        pictureBox.Image = Properties.Resources.bookdefault;  // Hình ảnh mặc định nếu không tìm thấy
        //                    }
        //                }
        //                catch
        //                {
        //                    pictureBox.Image = Properties.Resources.bookdefault;  // Nếu có lỗi, hiển thị hình ảnh mặc định
        //                }

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
            //string sql = "INSERT INTO Book (BookID, CategoryID, BookName, Author, Price, Bookimage) " +
            // "VALUES(N'" + book.Bookid + "', N'" + book.Categoryid + "', N'" + book.Bookname + "', N'" + book.Author + "', " + book.Price + ", '" + book.Bookimage + "')";
            string sql = "INSERT INTO Book (BookID, CategoryID, BookName, Author, Price) " +
              "VALUES (N'" + book.Bookid + "', N'" + book.Categoryid + "', N'" + book.Bookname + "', N'" + book.Author + "', " + book.Price + ")";


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
            if (string.IsNullOrEmpty(book.Bookid))
                throw new Exception("BookID không được để trống.");

            string sql = "DELETE FROM Book WHERE BookID = '" + book.Bookid.Replace("'", "''") + "'";


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
                updates.Add("Bookimage = N'" + book.Bookimage.Replace("'", "''") + "'");

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
                throw;
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

            // Kiểm tra keyword có phải định dạng BookID chuẩn (BOOK + số)
            bool isBookIdExact = Regex.IsMatch(keyword.Trim(), @"^BOOK\d+$", RegexOptions.IgnoreCase);

            string sql;
            if (isBookIdExact)
            {
                sql = @"
        SELECT b.BookID, b.CategoryID, c.CategoryName, b.BookName, b.Author, b.Price, b.Bookimage 
        FROM Book b
        JOIN BookCategory c ON b.CategoryID = c.CategoryID
        WHERE b.BookID COLLATE Latin1_General_CI_AI = @ExactID";
            }
            else
            {
                sql = @"
        SELECT b.BookID, b.CategoryID, c.CategoryName, b.BookName, b.Author, b.Price, b.Bookimage 
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
                            categoryID = reader["CategoryName"].ToString();  // Bạn chỉ dùng tên loại
                            bookName = reader["BookName"].ToString();
                            author = reader["Author"].ToString();
                            int price = reader["Price"] != DBNull.Value ? Convert.ToInt32(reader["Price"]) : 0;
                            string bookImage = reader["Bookimage"].ToString();
                            Book book = new Book(bookID, bookName, categoryID, author, price, bookImage);
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

        public Book GetBookByID(string id)
        {
            Book book = null;
            string sql = "SELECT * FROM Book WHERE BookID = @BookID";
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@BookID", id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string bookid = reader["BookID"].ToString();
                    string bookName = reader["BookName"].ToString();
                    string categoryID = reader["CategoryID"].ToString();
                    string author = reader["Author"].ToString();
                    int price = Convert.ToInt32(reader["Price"]);
                    string bookiamge = reader["BookImage"].ToString();
                    book = new Book(bookid, bookName, categoryID, author, price, bookiamge);
                }
                reader.Close();
                return book;
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
        public bool IsBookInOrder(string Bookid)
        {
            string sql = "SELECT COUNT(*) FROM OrderDetails WHERE BookID = @BookID";

            try
            {
                // Kết nối đã được mở sẵn từ DataProvider
                Connect(); // Mở kết nối nếu chưa mở

                SqlCommand cmd = new SqlCommand(sql, cn);
                {
                    // Thêm tham số cho câu lệnh SQL
                    cmd.Parameters.AddWithValue("@BookID", Bookid);

                    // Thực thi câu lệnh và trả về kết quả
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (SqlException ex)
            {
                // Xử lý lỗi và ném lại thông báo lỗi
                throw new Exception("Lỗi khi kiểm tra sách trong đơn hàng: " + ex.Message, ex);
            }
            finally
            {
                // Đảm bảo đóng kết nối
                DisConnect();
            }
        }

    }
}
