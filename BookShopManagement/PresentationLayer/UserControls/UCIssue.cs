using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferObject;

namespace PresentationLayer.UserControls
{
    public partial class UCIssue: UserControl
    {
        public UCIssue()
        {
            InitializeComponent();
        }
        public UCIssue(Stock selectedStock) : this()
        {
            dgvxp.Rows.Clear();
            dgvxp.Rows.Add(
                selectedStock.StockID,
                selectedStock.BookID,
                selectedStock.BookName,
                selectedStock.CategoryID,
                selectedStock.Supplier_ID,
                selectedStock.ImportDate.ToShortDateString(),
                selectedStock.Quantity
            );
        }
        private void ShowUserControl(UCStock uCStock)
        {
            panel1.Controls.Clear();
            uCStock.Dock = DockStyle.Fill;
            panel1.Controls.Add(uCStock);
            uCStock.BringToFront();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UCStock());
        }
    }
}
