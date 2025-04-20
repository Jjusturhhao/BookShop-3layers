using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;
using System.Data.SqlClient;
using System.Data;
using DataLayer;
using System.Linq.Expressions;
namespace BusinessLayer
{
    public class BookBL
    {
        private BookDL bookDL;
        public BookBL()
        {
            bookDL = new BookDL();
        }
        public List<Book> GetBooks()
        {
           try
            {
                return bookDL.GetBooks();
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
        public string GenerateNextBookID()
        {
            return bookDL.GenerateNextBookID();
        }

        public List<BookCategoryStock> GetBookCategories()
        {
            try
            {
                return bookDL.bookCategoryStocks();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public int Add(Book book)
        {
            return bookDL.Add(book);
        }
        public int Delete(Book book)
        {
            return bookDL.Delete(book);
        }
        public int Update(Book book)
        {
            return bookDL.Update(book);
        }
        public List<Book> SearchBook(string keyword)
        {
            return bookDL.SearchBook(keyword);
        }

        public Book ResetBook()
        {
            return bookDL.Reset();
        }
    }

}
