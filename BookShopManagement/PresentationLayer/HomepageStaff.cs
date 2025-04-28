using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using PresentationLayer.UserControls;
using TransferObject;

namespace PresentationLayer
{
    public partial class HomepageStaff : Form
    {
        private ContextMenuStrip accountMenu;
        private UCInfo ucInfo;

        public Panel PanelContainer
        {
            get { return panelContainer; }
        }

        private string username;

        public HomepageStaff(string username)
        {
            InitializeComponent();
            this.username = username;
            SetupAccountDropdown();
            ShowUserControl(new UCWelcome());
        }

        // Hàm dùng để hiển thị UserControl trong panelContainer
        private void ShowUserControl(UserControl userControl)
        {
            panelContainer.Controls.Clear(); // Clear hết các UC cũ
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UCCheckout(username));
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UCBook());
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UCStock());
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            HandleOrderButtonClick();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UCSupplier());
        }

        private void SetupAccountDropdown()
        {
            accountMenu = new ContextMenuStrip();

            ToolStripMenuItem itemProfile = new ToolStripMenuItem("Đổi thông tin");
            ToolStripMenuItem itemLogout = new ToolStripMenuItem("Đăng xuất");

            itemProfile.Click += (s, e) =>
            {
                if (ucInfo == null)
                {
                    ucInfo = new UCInfo(username);
                }

                ShowUserControl(ucInfo);
            };

            itemLogout.Click += (s, e) =>
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    this.Hide();
                    new Login().Show();
                }
            };

            accountMenu.Items.Add(itemProfile);
            accountMenu.Items.Add(itemLogout);

            btnInfo.Click += (s, e) =>
            {
                accountMenu.Show(btnInfo, new Point(0, btnInfo.Height));
            };
        }
        private void HandleOrderButtonClick()
        {
            UCOrders ucOrders = new UCOrders();
            ucOrders.OnOrderDetailClick = (orderID, phone) =>
            {
                ShowOrderDetail(orderID, phone);
            };
            ShowUserControl(ucOrders);
        }
        private void ShowOrderDetail(string orderID, string phone)
        {
            UCCusOrderDetail ucOrderDetail = new UCCusOrderDetail(orderID, null, phone);
            ShowUserControl(ucOrderDetail);
            ucOrderDetail.OnBackClick = () =>
            {
                HandleOrderButtonClick();
            };
        }

    }
}
