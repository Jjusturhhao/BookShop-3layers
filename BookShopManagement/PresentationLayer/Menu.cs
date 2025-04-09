using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            Book f1 = new Book();
            f1.Show();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            Categories categories = new Categories();
            categories.Show();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            Employees e1 = new Employees();
            e1.Show();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            Customers_Details c1 = new Customers_Details();
            c1.Show();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            Orders o1 = new Orders();
            o1.Show();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            Payments p1 = new Payments();
            p1.Show();
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            Bill b1 = new Bill();
            b1.Show();
        }
    }
}
