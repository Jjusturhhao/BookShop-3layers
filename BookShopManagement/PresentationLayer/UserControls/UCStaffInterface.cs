using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.UserControls
{
    public partial class UCStaffInterface : UserControl
    {
        private string username;

        public UCStaffInterface(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            // Tìm form Main chứa
            Main mainForm = this.ParentForm as Main;

            if (mainForm != null)
            {
                // Tạo và hiển thị UCCheckout trong panelContainer của Main
                UCCheckout checkout = new UCCheckout(username);
                mainForm.PanelContainer.Controls.Clear();
                checkout.Dock = DockStyle.Fill;
                mainForm.PanelContainer.Controls.Add(checkout);
            }
        }
    }
}
