using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class OrderBL
    {
        private OrderDL OrderDL;
        public OrderBL()
        {
            OrderDL = new OrderDL();
        }
        public DataTable GetOrders()
        {
            return OrderDL.GetOrders();
        }
        public void UpdateOrder(string orderID, string newStatus)
        {
            OrderDL.UpdateOrderStatus(orderID, newStatus);
        }
    }
}
