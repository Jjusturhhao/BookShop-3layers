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
                string customerID = info.User_ID;
                DateTime orderDate = DateTime.Now;
                string status = "Chờ xác nhận";

                orderBL.SaveOrder(orderID, customerID, null, orderDate, status);

                // Bước 3: Lấy danh sách sản phẩm trong giỏ hàng và lưu chi tiết đơn hàng
                List<CartItem> cartItems = cartBL.GetCartItems();
                orderBL.SaveOrderDetails(orderID, cartItems);

                // Bước 4: Thông báo
                MessageBox.Show("Đặt hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Bước 5: Xóa giỏ hàng
                cartBL.ClearCart();

                // Bước 6: Chuyển đến giao diện danh sách đơn hàng
                OnOrderSuccess?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            OnBackToCartClick?.Invoke();
        }
    }
}
