using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class CartItem
    {
        public string BookID { get; set; }
        public string BookName { get; set; }
        public string StockID { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }

        public int TotalPrice
        {
            get
            {
                return UnitPrice * Quantity;
            }
        }
        public CartItem(string bookID, string bookName, int price, int quantity)
        {
            BookID = bookID;
            BookName = bookName;
            UnitPrice = price;
            Quantity = quantity;
        }
    }
}
