using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class SupplierStock
    {

        public string Supplier_ID { get; set; }
        public string Supplier_name { get; set; }

        public SupplierStock(string supplier_ID, string supplier_name)
        {
            Supplier_ID = supplier_ID;
            Supplier_name = supplier_name;
        }
    }
}
