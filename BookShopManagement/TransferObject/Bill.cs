using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class Bill
    {
        public string Bill_ID { get; set; }
        public string Order_ID { get; set; }
        public string Bill_Date { get; set; }
        public string Total_Cost { get; set; }
    }
}
