using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class Category
    {
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }

        public Category(string categoryID, string categoryName)
        {
            this.CategoryID = categoryID;
            this.CategoryName = categoryName;
        }
    }
}
