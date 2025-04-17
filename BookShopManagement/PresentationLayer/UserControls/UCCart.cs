using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferObject;

namespace PresentationLayer.UserControls
{
    public partial class UCCart : UserControl
    {
        private CartBL cartBL;
        public Action OnOrderClick;

        public UCCart(CartBL cartBL)
        {
            InitializeComponent();
            this.cartBL = cartBL;
            Load += UCCart_Load;
        }

        private void UCCart_Load(object sender, EventArgs e)
        {
            LoadCartItems();
        }
        
        public void LoadCartItems()
        {

            List<CartItem> cartItems = cartBL.GetCartItems();

            flpCart.Controls.Clear();

            Panel headerPanel = new Panel()
            {
                Width = flpCart.Width - 20,
                Height = 60,
                Margin = new Padding(5),
                Padding = new Padding(5),
                BackColor = Color.LightGray 
            };

            Label lblBookNameHeader = new Label()
            {
                Text = "Tên sách",
                Font = new Font("Arial", 14, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(10, 10),
                Width = (int)(headerPanel.Width * 0.4) - 20
            };

            Label lblPriceHeader = new Label()
            {
                Text = "Đơn giá",
                Font = new Font("Arial", 14, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(lblBookNameHeader.Right + 20, 10),
                Width = (int)(headerPanel.Width * 0.15) - 20
            };

            Label lblQuantityHeader = new Label()
            {
                Text = "Số lượng",
                Font = new Font("Arial", 14, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(lblPriceHeader.Right + 20, 10),
                Width = (int)(headerPanel.Width * 0.15) - 20
            };

            Label lblTotalPriceHeader = new Label()
            {
                Text = "Thành tiền",
                Font = new Font("Arial", 14, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(lblQuantityHeader.Right + 20, 10),
                Width = (int)(headerPanel.Width * 0.2)
            };

            headerPanel.Controls.Add(lblBookNameHeader);
            headerPanel.Controls.Add(lblPriceHeader);
            headerPanel.Controls.Add(lblQuantityHeader);
            headerPanel.Controls.Add(lblTotalPriceHeader);

            // Thêm header vào flpCart
            flpCart.Controls.Add(headerPanel);

            foreach (CartItem item in cartItems)
            {
                Panel panel = new Panel()
                {
                    Width = flpCart.Width - 20,
                    Height = 60,
                    Margin = new Padding(5),
                    Padding = new Padding(5)
                };

                Label lblBookName = new Label()
                {
                    Text = item.BookName,
                    AutoSize = true,
                    Font = new Font("Arial", 14),
                    Location = new Point(10, 10),
                    Width = (int)(panel.Width * 0.4) - 20 
                };

                Label lblPrice = new Label()
                {
                    Font = new Font("Arial", 14, FontStyle.Bold),
                    Text = item.UnitPrice.ToString("#,##0") + " đ",
                    AutoSize = true,
                    Location = new Point(lblBookName.Right + 20, 10),
                    Width = (int)(panel.Width * 0.15) - 20
                };

                NumericUpDown numQuantity = new NumericUpDown()
                {
                    Font = new Font("Arial", 14),
                    Value = item.Quantity,
                    Minimum = 1,
                    Maximum = 100,
                    Size = new Size(60, 30),
                    Location = new Point(lblPrice.Right + 30, 10),
                    Width = (int)(panel.Width * 0.13) - 60,
                    Tag = item // Lưu đối tượng CartItem vào Tag để có thể tham chiếu khi cần
                };
                numQuantity.ValueChanged += (sender, e) =>
                {
                    item.Quantity = (int)numQuantity.Value;
                    
                    LoadCartItems(); 
                };

                Label lblTotalPrice = new Label()
                {
                    Font = new Font("Arial", 14, FontStyle.Bold),
                    ForeColor = Color.Red,
                    Text = (item.Quantity * item.UnitPrice).ToString("#,##0") + " đ", 
                    AutoSize = true,
                    Location = new Point(numQuantity.Right + 80, 10),
                    Width = (int)(panel.Width * 0.2)
                };

                Button btnDelete = new Button()
                {
                    Text = "Xóa",
                    Font = new Font("Arial", 14),
                    Size = new Size(70, 30),
                    Location = new Point(lblTotalPrice.Right, 10),
                    BackColor = Color.LightCoral,
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat
                };
                btnDelete.Click += (s, ev) =>
                {
                    cartBL.RemoveFromCart(item.BookID); 
                    LoadCartItems();
                };

                panel.Controls.Add(lblBookName);
                panel.Controls.Add(lblPrice);
                panel.Controls.Add(numQuantity);
                panel.Controls.Add(lblTotalPrice);
                panel.Controls.Add(btnDelete);

                flpCart.Controls.Add(panel);
            }

            if (cartItems.Count == 0)
            {
                Label lblEmpty = new Label()
                {
                    Text = "Giỏ hàng của bạn trống!",
                    Font = new Font("Arial", 16),
                    AutoSize = true,
                    Location = new Point(10, 10)
                };
                btnOrder.Enabled = false;
                flpCart.Controls.Add(lblEmpty);
            }
            lbTotalCost.Text = $"Tổng cộng: {cartBL.GetTotalAmount():#,##0} đ";
            lbQuantity.Text = $"{cartBL.GetTotalQuantity()} sản phẩm";

            // Bật / Tắt nút đặt hàng
            btnOrder.Enabled = cartItems.Count > 0;
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (OnOrderClick != null)
                OnOrderClick.Invoke();
        }
    }
}
