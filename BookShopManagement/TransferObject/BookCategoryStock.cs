using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class BookCategoryStock
    {

        public string CategoryID { get; set; }
        public string CategoryName { get; set; }

        public BookCategoryStock(string categoryID, string categoryName)
        {
            CategoryID = categoryID;
            CategoryName = categoryName;
        }
    }
}
