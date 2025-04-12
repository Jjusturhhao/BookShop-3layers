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
        public BookBL ()
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


        public Book GetEmptyBook()
        {
            return bookDL.GetEmptyBook();
        }


    }

}
