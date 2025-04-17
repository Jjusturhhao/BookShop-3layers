using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        public List<string> GetEmployeeNames()
        {
            try
            {
                return OrderDL.GetEmployeeNames();
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

        public string GenerateOrderID()
        {
            string newOrderID = OrderDL.GenerateOrderID();
            return newOrderID;
        }
        public void SaveOrder(string orderID, string customerID, string employeeID, DateTime orderDate, string status)
        {
            try
            {
                OrderDL.SaveOrder(orderID, customerID, employeeID, orderDate, status);
            }
            catch (Exception ex)
            {
                // Ném lại lỗi để catch ở form
                throw new Exception("Lỗi khi lưu đơn hàng: " + ex.Message);
            }
        }
        public void SaveOrderDetails(string orderID, List<CartItem> cartItems)
        {
            try
            {
                OrderDL.SaveOrderDetail(orderID, cartItems);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
