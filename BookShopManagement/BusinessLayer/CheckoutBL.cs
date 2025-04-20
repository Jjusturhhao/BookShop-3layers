using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferObject;

namespace BusinessLayer
{
    public class CheckoutBL
    {
        private CheckoutDL CheckoutDL;
        public CheckoutBL()
        {
            CheckoutDL = new CheckoutDL();
        }
        public List<Book> GetBooks()
        {
            return CheckoutDL.GetBooks();
        }
        public List<Book> GetBooksByName(string kw)
        {
            return CheckoutDL.GetBooksByName(kw);
        }
        public List<Book> GetBooksByCategory(string cate)
        {
            return CheckoutDL.GetBooksByCategory(cate);
        }
        public List<BookCategoryStock> GetCategories()
        {
            return CheckoutDL.LoadCategories();
        }
        public int GetQuantity(string bookID)
        {
            return CheckoutDL.GetQuantity(bookID);
        }
        public string GetStockID(string bookID)
        {
            return CheckoutDL.GetStockID(bookID);
        }
        public List<CartItem> GetCartItemsFromDgv(DataGridView dgvDetails)
        {
            return CheckoutDL.GetCartItemsFromDgv(dgvDetails);
        }
    }
}
