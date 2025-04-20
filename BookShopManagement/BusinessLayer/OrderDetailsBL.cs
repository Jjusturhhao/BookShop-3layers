using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferObject;

namespace BusinessLayer
{
    public class OrderDetailsBL
    {
        private OrderDetailsDL orderDetailsDL;
        private static List<OrderDetails> orderDetails;
        public OrderDetailsBL() 
        {
            orderDetailsDL = new OrderDetailsDL(); 
        }
        public List<OrderDetails> GetOrderDetails(string orderID)
        {
            return orderDetailsDL.GetOrderDetails(orderID);
        }
        public void SaveOrderDetails(string orderID, List<CartItem> cartItems)
        {
            try
            {
                orderDetailsDL.SaveOrderDetail(orderID, cartItems);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
