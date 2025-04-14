using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace BusinessLayer
{
    public class OrderBL
    {
        private OrderDL OrderDL;

        public OrderBL()
        {
            OrderDL = new OrderDL();
        }
        public List<Order> GetOrders()
        {
            try
            {
                return (OrderDL.GetOrders());
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public void UpdateOrder(string orderID, string newStatus)
        {
            try
            {
                OrderDL.UpdateOrderStatus(orderID, newStatus);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        

    }
}
