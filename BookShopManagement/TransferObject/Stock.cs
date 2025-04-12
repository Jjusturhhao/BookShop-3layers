using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class Stock
    {
        public string StockID { get; set; }
        public string Supplier_ID { get; set; }
        public string BookID { get; set; }
        public string CategoryID { get; set; }
        public string BookName { get; set; }
        public DateTime ImportDate { get; set; }
        public int Quantity { get; set; }

        public Stock(string stockID, string supplier_ID, string bookID, string categoryID, string bookName, DateTime importDate, int quantity)
        {
            StockID = stockID;
            Supplier_ID = supplier_ID;
            BookID = bookID;
            CategoryID = categoryID;
            BookName = bookName;
            ImportDate = importDate;
            Quantity = quantity;
        }
    }
}
