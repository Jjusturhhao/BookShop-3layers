using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace BusinessLayer
{
    public class PaymentBL
    {
        private PaymentDL paymentDL;
        public PaymentBL()
        {
            paymentDL = new PaymentDL();
        }
        public bool AddPayment(string paymentID, string billID, string cusphone, string paymentMethod, string transactionCode, DateTime? paymentDate, int totalCost)
        {
            return paymentDL.InsertPayment(paymentID, billID, cusphone, paymentMethod, transactionCode, paymentDate, totalCost);
        }
        public string GetPaymentID()
        {
            return paymentDL.GeneratePaymentID();
        }
        public string GetTransactionCode(string paymentID)
        {
            string id = paymentID.Substring(3);

            // Tạo TransactionCode với "TXN" + số đó, đảm bảo có 3 chữ số
            string transactionCode = "TXN" + int.Parse(id).ToString("D3");
            return transactionCode;
        }
        public Payment GetPayments(string billIF)
        {
            return paymentDL.GetPaymentByBillID(billIF);
        }
    }
}
