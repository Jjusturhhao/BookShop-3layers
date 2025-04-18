using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class OrderDetails
    {
        public string OrderID { get; set; }
        public string BookID { get; set; }
        public string BookName { get; set; }
        public int QuantitySold { get; set; }
        public int UnitPrice { get; set; }

        
    }
}
