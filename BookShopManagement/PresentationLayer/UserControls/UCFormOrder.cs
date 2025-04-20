using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferObject;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PresentationLayer.UserControls
{
    public partial class UCFormOrder : UserControl
    {
        private CartBL cartBL;
        private InfoBL infoBL;
        private OrderBL orderBL;
        private OrderDetailsBL orderDetailsBL;
        private StockBL stockBL;
        private BillBL billBL;

        private Info info;
        private string username;

        public Action OnBackToCartClick;
        public Action OnOrderSuccess;

        public UCFormOrder(string username, CartBL cartBL)
        {
            InitializeComponent();
            this.username = username;
            this.cartBL = cartBL;
            infoBL = new InfoBL();
            orderBL = new OrderBL();
            orderDetailsBL = new OrderDetailsBL();
            stockBL = new StockBL();
            billBL = new BillBL();
        }
        
        private void UCFormOrder_Load(object sender, EventArgs e)
        {
            LoadForm();
        }
        private void LoadForm()
        {
            info = infoBL.GetUserInfo(username);
            txtName.Text = username;
            txtAddress.Text = info.Address;
            txtNumber.Text = info.Phone;
            txtEmail.Text = info.Email;
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            try
            {
                // Bước 1: Tạo Order_ID mới
                string orderID = orderBL.GenerateOrderID();
                
                // Bước 2: Lưu thông tin Order vào bảng Orders
                string phone = info.Phone;
                DateTime orderDate = DateTime.Now;
                string status = "Chờ xác nhận";
                orderBL.SaveOrder(orderID, phone, null, orderDate, status);

                // Bước 3: Lấy danh sách sản phẩm trong giỏ hàng và lưu chi tiết đơn hàng
                List<CartItem> cartItems = cartBL.GetCartItems();
                orderDetailsBL.SaveOrderDetails(orderID, cartItems);
                foreach (var item in cartItems)
                {
                    stockBL.ReduceStockQuantity(item.StockID, item.Quantity);
                }

                // Bước 4: Tạo hóa đơn và lưu vào bảng Bill_Generate
                billBL.CreateBill(orderID);

                // Bước 5: Thông báo
                MessageBox.Show("Đặt hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Bước 6: Xóa giỏ hàng
                cartBL.ClearCart();

                // Bước 7: Chuyển đến giao diện danh sách đơn hàng
                OnOrderSuccess?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi đặt hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            OnBackToCartClick?.Invoke();
        }
    }
}
