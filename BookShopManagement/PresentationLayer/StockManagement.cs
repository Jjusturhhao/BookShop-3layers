using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class StockManagement : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=BookStoreManagement;Integrated Security=True;TrustServerCertificate=True");

        public StockManagement()
        {
            InitializeComponent();
        }

        private void StockManagement_Load(object sender, EventArgs e)
        {
            GetStockRecords();
            FormatDataGridView();
        }
        private void GetStockRecords()
        {
            SqlCommand cmd = new SqlCommand(
                "SELECT s.StockID, b.BookID, b.BookName, b.CategoryID, b.Author, b.Price, s.Quantity " +
                "FROM Book b " +
                "JOIN Stock s ON b.BookID = s.BookID " +
                "ORDER BY CAST(SUBSTRING(s.StockID, 4, LEN(s.StockID) - 3) AS INT)", con);

            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            dataGridViewBooks.DataSource = dt;
        }

        private void FormatDataGridView()
        {
            dataGridViewBooks.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewBooks.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Giảm kích thước các cột ID
            dataGridViewBooks.Columns["StockID"].Width = 60;
            dataGridViewBooks.Columns["BookID"].Width = 60;
            dataGridViewBooks.Columns["CategoryID"].Width = 60;

            // Tự động co giãn tên sách và tác giả để tối ưu không gian
            dataGridViewBooks.Columns["BookName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewBooks.Columns["Author"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnStaffInterface_Click(object sender, EventArgs e)
        {
            StaffInterface staffInterface = new StaffInterface();
            staffInterface.Show();
            this.Hide();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Checkout checkout = new Checkout();
            checkout.Show();
            this.Hide();
        }

        private void btnBookManage_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void btnCustomerManage_Click(object sender, EventArgs e)
        {

        }

        private void btnAccout_Click(object sender, EventArgs e)
        {

        }
    }
}
