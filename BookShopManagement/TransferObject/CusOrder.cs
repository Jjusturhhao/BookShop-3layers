using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class CusOrder
    {
        public int Index { get; set; }
        public string Orderid { get; set; }
        public DateTime Orderdate { get; set; }
        public int Total { get; set; }
        public string Status { get; set; }

        public CusOrder(string orderid, DateTime orderdate, int total, string status)
        {
            Orderid = orderid;
            Orderdate = orderdate;
            Total = total;
            Status = status;
        }
    }
}
