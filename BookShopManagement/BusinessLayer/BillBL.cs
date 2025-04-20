using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BillBL
    {
        private BillDL billDL;
        public BillBL()
        {
            billDL = new BillDL();
        }
        public void CreateBill(string billID, string orderID)
        {
            try
            {
                int totalCost = GetTotalCost(orderID);

                // Lưu thông tin hóa đơn vào bảng Bill_Generate
                billDL.SaveBill(billID, orderID, totalCost);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GetBillID(string orderID)
        {
            return billDL.GenerateBillID(orderID);
        }
        public int GetTotalCost(string orderID)
        {
            return billDL.CalculateTotalCost(orderID);
        }
        public string GetBillIDByOrderID(string orderID)
        {
            return billDL.GetBillIDByOrderID(orderID);
        }
        
    }
}

