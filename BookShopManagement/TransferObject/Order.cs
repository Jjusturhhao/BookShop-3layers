using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class Order
    {
        public string Order_ID { get; set; }
        public string Customer_ID { get; set; }
        public string Customer_Name { get; set; }
        public string Employee_Name { get; set; }
        public DateTime Order_Date { get; set; }
        public string Status { get; set; }
        public int Total_Cost { get; set; }

        public Order(string orderid, string cusname, string empname, DateTime date, string status, int cost)
        {
            this.Order_ID = orderid;
            this.Customer_Name = cusname;
            this.Employee_Name = empname;
            this.Order_Date = date;
            this.Status = status;
            this.Total_Cost = cost;
        }
    }
}
