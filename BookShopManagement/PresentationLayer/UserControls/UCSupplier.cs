using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace PresentationLayer.UserControls
{
    public partial class UCSupplier : UserControl
    {
        public UCSupplier()
        {
            InitializeComponent();
        }

        private void UCSupplier_Load(object sender, EventArgs e)
        {
            dgvSupplier.DataSource = new SupplierBL().GetSuppliers();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           
        }

 

      
    }
}
