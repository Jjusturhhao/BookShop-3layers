using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Caching;
using System.Windows.Forms;
using TransferObject;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace PresentationLayer.UserControls
{
    public partial class UCCusOrderDetail : UserControl
    {
        private string orderID;
        private string phone;
        private string employee;
        private InfoBL infoBL;
        private CustomerBL customerBL;
        private OrderDetailsBL orderDetailsBL;
        private BillBL billBL;
        private PaymentBL paymentBL;
        private OrderBL OrderBL;
        public Action OnBackClick;
     
        public Action OnStatusChanged;
        private bool showButtons;
        private CusOrderBL CusOrderBL;
        private EmployeeBL EmployeeBL;

        public UCCusOrderDetail(string orderID, string employee = null, string phone = null)
        {
            InitializeComponent();
            customerBL = new CustomerBL();
            orderDetailsBL = new OrderDetailsBL();
            billBL = new BillBL();
            infoBL = new InfoBL();
            paymentBL = new PaymentBL();
            OrderBL = new OrderBL();
            customerBL = new CustomerBL();
            EmployeeBL = new EmployeeBL();

            this.orderID = orderID;
            this.phone = phone;
            this.employee = employee;
        }

        public void HideButtons()
        {
            btnCancel.Visible = false;
            btnDone.Visible = false;
        }

        // Hiển thị các nút khi quay lại
        public void ShowButtons()
        {
            btnCancel.Visible = true;
            btnDone.Visible = true;
        }

        private void UCCusOrderDetail_Load(object sender, EventArgs e)
        {
            LoadOrderDetail(orderID);
        }

        private void UpdateButtonsBasedOnStatus(string status, bool isEmployee)
        {
            // Nếu là nhân viên, ẩn cả hai nút
            if (isEmployee)
            {
                btnCancel.Visible = false;
                btnDone.Visible = false;
            }
            else
            {
                // Nếu không phải là nhân viên, kiểm tra trạng thái để quyết định nút nào hiển thị
                if (status == "Chờ xác nhận")
                {
                    btnDone.Visible = false;  // Ẩn nút hoàn thành
                    btnCancel.Visible = true;      // Hiển thị nút hủy
                }
                else if (status == "Đang vận chuyển")
                {
                    btnCancel.Visible = false;     // Ẩn nút hủy
                    btnDone.Visible = true;   // Hiển thị nút hoàn thành
                }
                else if (status == "Đã hủy" || status == "Đã hoàn thành")
                {
                    btnDone.Visible = false;  // Ẩn nút hoàn thành
                    btnCancel.Visible = false;     // Ẩn nút hủy
                }
            }
        }
        private void LoadOrderDetail(string orderID)
        {
            lbOrderID.Text = $"Đơn hàng: {orderID}";
            //==
            string status = OrderBL.GetOrderStatus(orderID);


            // Cập nhật trạng thái lên nhãn
            lbStatus.Text = $"Trạng thái đơn hàng: {status}";
            bool isEmployee = (employee != null && (employee == "Online"));

            UpdateButtonsBasedOnStatus(status, isEmployee);

            //==
            string billID = billBL.GetBillIDByOrderID(orderID);
            Payment payment = paymentBL.GetPayments(billID);
            lbPayment.Text = $"Phương thức thanh toán: {payment.Payment_Method}";

            if (employee == "Online") // Online
            {
                Info info = infoBL.GetUserInfoByPhone(phone);
                if (info != null)
                {
                    lbInforCus.Text = $"Khách hàng: {info.Name}  -  SĐT: {phone}\nĐịa chỉ: {info.Address}";
                }
                else
                {
                    lbInforCus.Text = "Không tìm thấy thông tin khách hàng.";
                }
            }
            else // Offline
            {
                Customer customer = customerBL.GetCustomerByPhone(phone);
                if (customer != null)
                {
                    lbInforCus.Text = $"Khách hàng: {customer.FullName}\nSĐT: {customer.PhoneNumber}";
                }
                else
                {
                    lbInforCus.Text = "Không tìm thấy thông tin khách hàng.";
                }
            }
            //if (employee == "Online") // Online
            //{
            //    Info info = infoBL.GetUserInfoByPhone(phone);  // Lấy thông tin khách hàng từ số điện thoại
            //    if (info != null)  // Kiểm tra xem có thông tin khách hàng không
            //    {
            //        lbInforCus.Text = $"Khách hàng: {info.Name}  -  SĐT: {phone}\nĐịa chỉ: {info.Address}"; // Hiển thị thông tin khách hàng
            //    }
            //    else
            //    {
            //        lbInforCus.Text = "Không tìm thấy thông tin khách hàng."; // Nếu không tìm thấy thông tin, hiển thị thông báo lỗi
            //    }
            //}
            //else if (employee == "Offine") // Offline
            //{
            //    Customer customer = customerBL.GetCustomerByPhone(phone);  // Lấy thông tin khách hàng từ số điện thoại
            //    if (customer != null)  // Kiểm tra xem có thông tin khách hàng không
            //    {
            //        lbInforCus.Text = $"Khách hàng: {customer.FullName}\nSĐT: {customer.PhoneNumber}"; // Hiển thị thông tin khách hàng
            //    }
            //    else
            //    {
            //        lbInforCus.Text = "Không tìm thấy thông tin khách hàng."; // Nếu không tìm thấy thông tin, hiển thị thông báo lỗi
            //    }
            //}


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
                Width = (int)(headerPanel.Width * 0.45) - 50
            };

            Label lbQuantityHeader = new Label()
            {
                Text = "Số lượng",
                Font = new Font("Arial", 14, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(lbBookNameHeader.Right, 10),
                Width = (int)(headerPanel.Width * 0.15) - 50
            };

            Label lbPriceHeader = new Label()
            {
                Text = "Đơn giá",
                Font = new Font("Arial", 14, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(lbQuantityHeader.Right + 50, 10),
                Width = (int)(headerPanel.Width * 0.2) - 50
            };

            Label lbTotalPriceHeader = new Label()
            {
                Text = "Thành tiền",
                Font = new Font("Arial", 14, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(lbPriceHeader.Right + 19, 10),
                Width = (int)(headerPanel.Width * 0.2) - 50
            };
            headerPanel.Controls.Add(lbBookNameHeader);
            headerPanel.Controls.Add(lbQuantityHeader);
            headerPanel.Controls.Add(lbPriceHeader);
            headerPanel.Controls.Add(lbTotalPriceHeader);


            //Thêm header vào flpCart
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
                    Width = (int)(panel.Width * 0.45) - 50
                };

                Label lbQuantity = new Label()
                {
                    Font = new Font("Arial", 16),
                    Text = detail.QuantitySold.ToString(),
                    AutoSize = true,
                    Location = new Point(lbBookName.Right + 80, 10),
                    Width = (int)(panel.Width * 0.15) - 50
                };

                Label lbPrice = new Label()
                {
                    Font = new Font("Arial", 16),
                    Text = detail.UnitPrice.ToString("#,##0") + " đ",
                    AutoSize = true,
                    Location = new Point(lbQuantity.Right + 20, 10),
                    Width = (int)(panel.Width * 0.2) - 50
                };

                Label lbTotalPrice = new Label()
                {
                    Font = new Font("Arial", 16),
                    Text = (detail.UnitPrice * detail.QuantitySold).ToString("#,##0") + " đ",
                    AutoSize = true,
                    Location = new Point(lbPrice.Right + 20, 10),
                    Width = (int)(panel.Width * 0.2) - 50
                };

                panel.Controls.Add(lbBookName);
                panel.Controls.Add(lbQuantity);
                panel.Controls.Add(lbPrice);
                panel.Controls.Add(lbTotalPrice);

                flpDetails.Controls.Add(panel);
            }

            int totalCost = billBL.GetTotalCost(orderID);
            lbTotalCost.Text = $"Tổng cộng: {totalCost:#,##0} đ";
        }
        
        private void btnBack_Click(object sender, EventArgs e)
        {
            OnBackClick?.Invoke();
        }

        //==
        private void btnCancle_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Bạn chắc chắn muốn hủy đơn sao? 😢", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                bool result = OrderBL.OrderStatus(orderID, "Đã hủy");

                if (result)
                {
                    MessageBox.Show("Huhu, đơn hàng đã bay màu 🥲 Lần sau cho Tiko cơ hội phục vụ bạn nha!", "Thông báo");

                    // Cập nhật lại trạng thái mới trên giao diện
                    string status = OrderBL.GetOrderStatus(orderID);
                    lbStatus.Text = $"Trạng thái đơn hàng: {status}";

                    // Ẩn và khóa các nút
                    HideButtons();

                    // Quan trọng: Quay về màn hình danh sách đơn hàng
                    OnBackClick?.Invoke();
                }
                else
                {
                    MessageBox.Show("Hủy đơn hàng thất bại.", "Lỗi");
                }
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Bạn đã nhận được hàng chưa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                bool result = OrderBL.OrderStatus(orderID, "Đã hoàn thành");

                if (result)
                {
                    MessageBox.Show("Yayyy! Tiko vui quá bạn đã nhận được đơn hàng. Hi vọng những cuốn sách sẽ mang lại niềm vui cho bạn! 🛍️✨", "Hoàn tất đơn hàng");

                    // Cập nhật trạng thái mới trên giao diện
                    string status = OrderBL.GetOrderStatus(orderID);
                    lbStatus.Text = $"Trạng thái đơn hàng: {status}";

                    // Ẩn các nút
                    HideButtons();

                    // Quan trọng: Quay về màn hình danh sách đơn hàng
                    OnBackClick?.Invoke();
                }
                else
                {
                    MessageBox.Show("Hoàn thành đơn hàng thất bại.", "Lỗi");
                }
            }
        }
    }
}

   
