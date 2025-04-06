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
        public UCStaffInterface()
        {
            InitializeComponent();
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            // Tìm form Main chứa
            Main mainForm = this.ParentForm as Main;

            if (mainForm != null)
            {
                // Tạo và hiển thị UCCheckout trong panelContainer của Main
                UCCheckout checkout = new UCCheckout();
                mainForm.PanelContainer.Controls.Clear();
                checkout.Dock = DockStyle.Fill;
                mainForm.PanelContainer.Controls.Add(checkout);
            }
        }
    }
}
