using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PresentationLayer.UserControls;

namespace PresentationLayer
{
    public partial class Main : Form
    {
        public Panel PanelContainer
        {
            get { return panelContainer; }
        }
        public Main()
        {
            InitializeComponent();
            ShowUserControl(new UCWelcome());
        }

        // Hàm dùng để hiển thị UserControl trong panelContainer
        private void ShowUserControl(UserControl userControl)
        {
            // Hiển thị UserControl trong panelContainer
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }

        // Sự kiện click của btnStaffInterface
        private void btnStaffInterface_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UCStaffInterface());
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UCCheckout());
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UCBook());
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UCStock());
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UCOrders());
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UCAccount());
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UCSupplier());
        }
    }
}
