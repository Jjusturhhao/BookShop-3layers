using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class Stock
    {

        public string BookID { get; set; }
        public string SupplierID { get; set; }
        public string CategoryID { get; set; }
        public string BookName { get; set; }
        public DateTime ImportDate { get; set; }
        public int Quantity { get; set; }

        public Stock(string bookID, string supplierID, string categoryID, string bookName, DateTime importDate, int quantity)
        {
            BookID = bookID;
            SupplierID = supplierID;
            CategoryID = categoryID;
            BookName = bookName;
            ImportDate = importDate;
            Quantity = quantity;
        }
    }
}

