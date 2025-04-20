using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class Payment
    {
        public string Payment_ID { get; set; }
        public string Bill_ID { get; set; }
        public string PhoneNumber { get; set; }
        public string Payment_Method { get; set; }
        public string Transaction_Code { get; set; }
        public DateTime? Payment_Date { get; set; }
        public int Total_Cost { get; set; }
        public Payment(string paymentID, string billID, string phone, string method, string code, DateTime? date, int total)
        {
            this.Payment_ID = paymentID;
            this.Bill_ID = billID;
            this.PhoneNumber = phone;
            this.Payment_Method = method;
            this.Transaction_Code = code;
            this.Payment_Date = date;
            this.Total_Cost = total;
        }
    }
}
