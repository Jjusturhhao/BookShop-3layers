using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class CheckoutBL
    {
        private CheckoutDL CheckoutDL;
        public CheckoutBL()
        {
            CheckoutDL = new CheckoutDL();
        }
        public DataTable GetBooks()
        {
            return CheckoutDL.GetBooks();
        }
        public DataTable GetBooksByName(string kw)
        {
            return CheckoutDL.GetBooksByName(kw);
        }
        public int GetQuantity(string bookID)
        {
            return CheckoutDL.GetQuantity(bookID);
        }
    }
}
