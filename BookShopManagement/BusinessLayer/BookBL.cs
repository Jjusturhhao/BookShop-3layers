using System;
using System.Collections.Generic;
using TransferObject;
using DataLayer;

namespace BusinessLayer
{
    public class BookBL
    {
        BookDL bookDL = new BookDL();

        public List<Book> GetBooks()
        {
            return bookDL.GetBooks();
        }

        public Book GetBookByID(string id)
        {
            return bookDL.GetBookByID(id);
        }

        public int Add(Book book)
        {
            return bookDL.Add(book);
        }

        public int Update(Book book)
        {
            return bookDL.Update(book);
        }


        public string GenerateNextBookID()
        {
            return bookDL.GenerateNextBookID();
        }

      

        public List<Book> SearchBook(string keyword)
        {
            return bookDL.SearchBook(keyword);
        }

        public void AddBookFromStock(Stock stock)
        {
            BookDL bookDL = new BookDL();
            if (!bookDL.Exists(stock.BookID))
            {
                Book book = new Book()
                {
                    Bookid = stock.BookID,
                    Bookname = stock.BookName,
                    Categoryid = stock.CategoryID,
                    Author = null,
                    Price = 0,
                    Bookimage = null,
                    Note = null
                };
                bookDL.AddBookFromStock(book);
            }
        }
    }
}
