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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace PresentationLayer.UserControls
{
    public partial class UCCusOrderDetail : UserControl
    {
        private string orderID;
        private string username;
        private InfoBL infoBL;
        private OrderDetailsBL orderDetailsBL;
        private BillBL billBL;


        public Action OnBackClick;

        public UCCusOrderDetail(string orderID, string username)
        {
            InitializeComponent();
            orderDetailsBL = new OrderDetailsBL();
            billBL = new BillBL();
            infoBL = new InfoBL();
            this.orderID = orderID;
            this.username = username;
        }
        
        private void UCCusOrderDetail_Load(object sender, EventArgs e)
        {
            LoadOrderDetail(orderID, username);
        }
        private void LoadOrderDetail(string orderID, string username)
        {
            lbOrderID.Text = $"Đơn hàng: {orderID}";
            //lbPayment 

            Info info = infoBL.GetUserInfo(username);
            if (info != null)
            {
                lbInforCus.Text = $"Khách hàng: {info.Name} - SĐT: {info.Phone} " +
                    $"\nĐịa chỉ: {info.Address}";
            }
            else
            {
                lbInforCus.Text = "Không tìm thấy thông tin khách hàng.";
            }

            flpDetails.Controls.Clear(); 

            List<OrderDetails> details = orderDetailsBL.GetOrderDetails(orderID);

            Panel headerPanel = new Panel()
            {
                Width = flpDetails.Width * 2,
                Height = 50,
                Margin = new Padding(5),
                Padding = new Padding(5),
                BackColor = Color.Gainsboro
            };

            Label lbBookNameHeader = new Label()
            {
                Text = "Tên sách",
                Font = new Font("Arial", 14, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(60, 10),
                Width = (int)(headerPanel.Width * 0.6) - 50
            };

            
            Label lbQuantityHeader = new Label()
            {
                Text = "Số lượng",
                Font = new Font("Arial", 14, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(lbBookNameHeader.Right, 10),
                Width = (int)(headerPanel.Width * 0.2) - 50
            };

            Label lbPriceHeader = new Label()
            {
                Text = "Đơn giá",
                Font = new Font("Arial", 14, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(lbQuantityHeader.Right + 50, 10),
                Width = (int)(headerPanel.Width * 0.2) - 50
            };
            headerPanel.Controls.Add(lbBookNameHeader);
            headerPanel.Controls.Add(lbPriceHeader);
            headerPanel.Controls.Add(lbQuantityHeader);

            // Thêm header vào flpCart
            flpDetails.Controls.Add(headerPanel);

            foreach (OrderDetails detail in details)
            {
                Panel panel = new Panel()
                {
                    Width = flpDetails.Width * 2,
                    Height = 60,
                    Margin = new Padding(5),
                    Padding = new Padding(5)
                };

                Label lbBookName = new Label()
                {
                    Text = detail.BookName,
                    AutoSize = true,
                    Font = new Font("Arial", 16),
                    Location = new Point(10, 10),
                    Width = (int)(panel.Width * 0.6) - 50
                };
                
                Label lbQuantity = new Label()
                {
                    Font = new Font("Arial", 16),
                    Text = detail.QuantitySold.ToString(),
                    AutoSize = true,
                    Location = new Point(lbBookName.Right + 80, 10),
                    Width = (int)(panel.Width * 0.2) - 50
                };

                Label lbPrice = new Label()
                {
                    Font = new Font("Arial", 16),
                    Text = detail.UnitPrice.ToString("#,##0") + " đ",
                    AutoSize = true,
                    Location = new Point(lbQuantity.Right + 20, 10),
                    Width = (int)(panel.Width * 0.2) - 50
                };


                panel.Controls.Add(lbBookName);
                panel.Controls.Add(lbPrice);
                panel.Controls.Add(lbQuantity);

                flpDetails.Controls.Add(panel);
            }

            int totalCost = billBL.GetTotalCost(orderID);
            lbTotalCost.Text = $"Tổng cộng: {totalCost:#,##0} đ";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            OnBackClick?.Invoke();
        }
    }
}
