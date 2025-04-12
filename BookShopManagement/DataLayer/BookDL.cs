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
using static Guna.UI2.Native.WinApi;


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
                        string bookID = reader["BookID"].ToString();
                        string bookName = reader["BookName"].ToString();
                        string categoryID = reader["CategoryID"].ToString();
                        string author = reader["Author"].ToString();
                        string price = reader["Price"].ToString();
                        string bookImageUrl = reader["BookImage"].ToString();

                        byte[] imageBytes = null;
                        if (!string.IsNullOrEmpty(bookImageUrl))
                        {
                            try
                            {
                                imageBytes = client.DownloadData(bookImageUrl);
                            }
                            catch
                            {
                                imageBytes = null;
                            }
                        }

                        Book book = new Book(bookID, bookName, categoryID, author, price, imageBytes);
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
            return new Book("", "", "", "", "", null);
        }



    }
}
