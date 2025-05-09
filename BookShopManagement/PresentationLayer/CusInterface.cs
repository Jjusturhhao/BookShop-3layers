﻿using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BusinessLayer;
using PresentationLayer.UserControls;
using TransferObject;

namespace PresentationLayer
{
    public partial class CusInterface : Form
    {
        private string username;
        private string phone;

        private HomepageBL homepageBL;
        private BookBL bookBL;
        private CartBL cartBL;
        private InfoBL infoBL;
        private UCHomepage ucHomepage;
        private UCCart ucCart;
        private UCCusOrders ucCusOrders;
        private UCCusOrderDetail ucCusOrderDetail;
        private UCInfo ucInfo; 
        private ContextMenuStrip accountMenu;
        private UCBookDetail ucBookDetail;
        private UCFormOrder uCFormOrder;
        
        public CusInterface(string username)
        {
            InitializeComponent();
            this.username = username;

            homepageBL = new HomepageBL();
            bookBL = new BookBL();
            cartBL = new CartBL();
            infoBL = new InfoBL();

            LoadCustomerInfo();

            // Lưu tham chiếu đến picBanner
            picBanner = this.picBanner;

            uCFormOrder = new UCFormOrder(username, cartBL); //cartBL dùng chung
            uCFormOrder.Dock = DockStyle.Fill;

            ucCart = new UCCart(cartBL); //cartBL dùng chung
            ucCart.Dock = DockStyle.Fill;

            // Khởi tạo tất cả UserControl một lần duy nhất
            ucHomepage = new UCHomepage(ucCart, ShowBookDetail); //chia sẻ cùng giỏ hàng dùng chung
            ucHomepage.Dock = DockStyle.Fill;

            ucCusOrders = new UCCusOrders(username, phone);
            ucCusOrders.Dock = DockStyle.Fill;

            ucInfo = new UCInfo(username);
            ucInfo.Dock = DockStyle.Fill;

            // Thêm tất cả UserControl vào panelContainer
            panelContainer.Controls.Add(ucHomepage);
            panelContainer.Controls.Add(ucCart);
            panelContainer.Controls.Add(ucCusOrders);
            panelContainer.Controls.Add(ucInfo);
            panelContainer.Controls.Add(uCFormOrder);

            // Hiển thị trang chủ mặc định và ẩn các UC khác
            ucHomepage.Visible = false; ;
            ucCart.Visible = false;
            ucCusOrders.Visible = false;
            ucInfo.Visible = false;

            // Đảm bảo picBanner hiển thị trên cùng ban đầu
            if (picBanner != null)
            {
                picBanner.Visible = true;
                picBanner.BringToFront();
            }
        }
        private void LoadCustomerInfo()
        {
            Info userInfo = infoBL.GetUserInfo(username);
            if (userInfo != null)
            {
                phone = userInfo.Phone;
            }
        }

        private void Homepage_Load(object sender, EventArgs e)
        {
            LoadButtons();
            //ucHomepage.LoadBooks(1, null); // Hiện tất cả sách từ trang 1
            SetupAccountDropdown();

            // Chỉ hiển thị banner khi form load
            if (picBanner != null)
            {
                picBanner.Visible = true;
                picBanner.BringToFront();
            }
        }

        private void LoadButtons()
        {
            DataTable categories = homepageBL.GetCategories();
            // Nút "Tất cả"
            Button btnAll = CreateCategoryButton("Tất cả", null);
            flowLayoutPanelButtons.Controls.Add(btnAll);
            // Các nút danh mục từ CSDL
            foreach (DataRow row in categories.Rows)
            {
                string categoryName = row["categoryName"].ToString();
                string categoryID = row["categoryID"].ToString();
                Button btnCategory = CreateCategoryButton(categoryName, categoryID);
                flowLayoutPanelButtons.Controls.Add(btnCategory);
            }
        }

        private Button CreateCategoryButton(string text, string categoryID)
        {
            Button button = new Button()
            {
                Text = text,
                AutoSize = true,
                Font = new Font("Arial", 13, FontStyle.Bold),
                TextAlign = ContentAlignment.TopLeft,
                BackColor = Color.FromArgb(255, 192, 192),
                ForeColor = Color.DimGray,
                FlatStyle = FlatStyle.Popup,
                Margin = new Padding(5)
            };

            button.Click += (s, e) =>
            {
                // Ẩn banner khi nhấn nút danh mục
                if (picBanner != null)
                {
                    picBanner.Visible = false;
                }

                // Hiển thị trang sách và ẩn các UC khác
                ShowHomepage();
                ucHomepage.LoadBooks(1, categoryID);
            };
            return button;
        }

        // Phương thức mới để hiển thị trang chủ và ẩn các UC khác
        private void ShowHomepage()
        {
            ucHomepage.Visible = true;
            ucCart.Visible = false;
            ucCusOrders.Visible = false;
            ucInfo.Visible = false;
            ucHomepage.BringToFront();
        }

        // Phương thức mới để ẩn tất cả UserControl
        private void HideAllUserControls()
        {
            ucHomepage.Visible = false;
            ucCart.Visible = false;
            ucCusOrders.Visible = false;
            ucInfo.Visible = false;

            // Ẩn banner khi hiển thị các UC khác
            if (picBanner != null)
            {
                picBanner.Visible = false;
            }
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            HideAllUserControls();
            ucCart.Visible = true;
            ucCart.BringToFront();

            ucCart.LoadCartItems();

            ucCart.OnOrderClick = () => ShowOrderForm(); //truyền delegate
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            //HideAllUserControls();
            //ucCusOrders.Visible = true;
            //ucCusOrders.BringToFront();

            //ucCusOrders.OnOrderDetailClick = (orderID, phone) =>
            //{
            //    ShowOrderDetail(orderID, phone);
            //};

            HideAllUserControls();
            ucCusOrders.LoadOrders(); // Tải lại dữ liệu mỗi khi hiển thị màn hình đơn hàng
            ucCusOrders.Visible = true;
            ucCusOrders.BringToFront();

            ucCusOrders.OnOrderDetailClick = (orderID, phone) =>
            {
                ShowOrderDetail(orderID, phone);
            };
        }

        private void SetupAccountDropdown()
        {
            accountMenu = new ContextMenuStrip();

            ToolStripMenuItem itemProfile = new ToolStripMenuItem("Đổi thông tin");
            ToolStripMenuItem itemLogout = new ToolStripMenuItem("Đăng xuất");

            // Gắn sự kiện
            itemProfile.Click += (s, e) =>
            {
                HideAllUserControls();
                ucInfo.Visible = true;
                ucInfo.BringToFront();
            };

            itemLogout.Click += (s, e) =>
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    this.Hide();
                    Application.Restart() ; 
                }
            };

            accountMenu.Items.Add(itemProfile);
            accountMenu.Items.Add(itemLogout);

            // Gắn cho nút icon
            btnAccount.Click += (s, e) =>
            {
                accountMenu.Show(btnAccount, new Point(0, btnAccount.Height)); // Show menu ngay dưới nút
            };
        }

        private void ShowBookDetail(string bookID)
        {
            if (ucBookDetail != null)
            {
                panelContainer.Controls.Remove(ucBookDetail);
                ucBookDetail.Dispose();
            }
            ucBookDetail = new UCBookDetail(bookID, ucCart, cartBL);
            ucBookDetail.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(ucBookDetail);
            HideAllUserControls();
            ucBookDetail.Visible = true;
            ucBookDetail.BringToFront();

            ucBookDetail.OnBuyClick = () =>
            {
                HideAllUserControls();
                ucCart.Visible = true;
                ucCart.BringToFront();
                ucCart.LoadCartItems();
            };

            ucBookDetail.OnBackClick = () =>
            {
                HideAllUserControls();
                ucHomepage.Visible = true;
                ucHomepage.BringToFront();
            };
        }
        private void ShowOrderForm()
        {
            HideAllUserControls();
            uCFormOrder.Visible = true;
            uCFormOrder.BringToFront();

            uCFormOrder.OnBackToCartClick = () =>
            {
                HideAllUserControls();
                ucCart.Visible = true;
                ucCart.BringToFront();
                ucCart.LoadCartItems(); // Tải lại giỏ hàng sau khi quay về
            };
            uCFormOrder.OnOrderSuccess = () =>
            {
                HideAllUserControls();
                ucCusOrders.LoadOrders(); // Load lại dữ liệu mới nhất trước khi hiện
                ucCusOrders.Visible = true;
                ucCusOrders.BringToFront();

                ucCusOrders.OnOrderDetailClick = (orderID, phone) =>
                {
                    ShowOrderDetail(orderID, phone);
                };
            };
        }
        private void ShowOrderDetail(string orderID, string phone)
        {
            if (ucCusOrderDetail != null)
            {
                panelContainer.Controls.Remove(ucCusOrderDetail);
                ucCusOrderDetail.Dispose();
            }

            ucCusOrderDetail = new UCCusOrderDetail(orderID, null, phone);
            ucCusOrderDetail.Dock = DockStyle.Fill;

            // Quan trọng: Đăng ký sự kiện OnBackClick trước khi thêm vào controls
            ucCusOrderDetail.OnBackClick = () =>
            {
                HideAllUserControls();

                // Quan trọng: Tải lại dữ liệu trước khi hiển thị
                ucCusOrders.LoadOrders();

                ucCusOrders.Visible = true;
                ucCusOrders.BringToFront();
            };

            panelContainer.Controls.Add(ucCusOrderDetail);
            HideAllUserControls();
            ucCusOrderDetail.Visible = true;
            ucCusOrderDetail.BringToFront();
        }
    }
}