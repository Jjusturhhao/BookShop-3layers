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
    public partial class Books : Form
    {
        public string StockID;
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=BookStoreManagement;Integrated Security=True;TrustServerCertificate=True");

        public Books()
        {
            InitializeComponent();
        }

        private void Stock_Load(object sender, EventArgs e)
        {
            GetStockRecords();
            LoadSuppliers();
            LoadCategory();
            ResetFormControls();
        }
        private void LoadSuppliers()
        {
            SqlCommand cmd = new SqlCommand("SELECT Supplier_ID, Supplier_name FROM SuppliersTb", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBoxSupplier.DataSource = dt;
            comboBoxSupplier.DisplayMember = "Supplier_name";
            comboBoxSupplier.ValueMember = "Supplier_ID";
        }


        private void LoadCategory()
        {
            SqlCommand cmd = new SqlCommand("SELECT CategoryID, CategoryName FROM BookCategory", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBoxCategory.DataSource = dt;
            comboBoxCategory.DisplayMember = "CategoryName";
            comboBoxCategory.ValueMember = "CategoryID";
        }
        private void GetStockRecords()
        {
            SqlCommand cmd = new SqlCommand(
                "SELECT s.StockID, sup.Supplier_name, s.BookID, c.CategoryName, s.AuthorName, s.BookName, s.PublisherName, s.PublishedYear, s.Price " +
                "FROM StockTb s " +
                "JOIN SuppliersTb sup ON s.SupplierID = sup.Supplier_ID " +
                "JOIN BookCategory c ON s.CategoryID = c.CategoryID", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            StockRecordsDataGridView.DataSource = dt;
        }
        private void ResetFormControls()
        {
            StockID = string.Empty;
            textBox1.Text = GenerateNextStockID(); textBox1.ReadOnly = true;
            textBox3.Text = GenerateNextBookID(); textBox3.ReadOnly = true;
            txtAuthorName.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox1.Focus();
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            //if(IsValid())
            //{
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO StockTb (StockID, SupplierID, BookID, CategoryID, AuthorName,  BookName, PublisherName, PublishedYear, Price) VALUES (@StockID, @SupplierID, @BookID, @BookName, @PublisherName, @PublishedYear, @Price)", con);
                cmd.CommandType = CommandType.Text;
                string newStockID = GenerateNextStockID();
                cmd.Parameters.AddWithValue("@StockID", newStockID);
                cmd.Parameters.AddWithValue("@SupplierID", comboBoxSupplier.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@BookID", textBox3.Text);
                cmd.Parameters.AddWithValue("@CategoryID", comboBoxCategory.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@AuthorName", txtAuthorName.Text);
                cmd.Parameters.AddWithValue("@BookName", textBox5.Text);
                cmd.Parameters.AddWithValue("@PublisherName", textBox6.Text);
                cmd.Parameters.AddWithValue("@PublishedYear", textBox7.Text);
                cmd.Parameters.AddWithValue("@Price", textBox8.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("New Stock Sucessfully Saved In The Database", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetStockRecords();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            //}
        }
        //private bool IsValid()
        //{
        //    if(textBox2.Text == string.Empty)
        //    {
        //        MessageBox.Show("Stock ID Is Required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }
        //    return true;
        //}

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(StockID))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("UPDATE StockTb SET SupplierID = @SupplierID, BookID = @BookID, CategoryID = @CategoryID, AuthorName = @AuthorName,  BookName = @BookName, PublisherName = @PublisherName, PublishedYear = @PublishedYear, Price = @Price WHERE StockID = @ID", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@StockID", textBox1.Text);
                    cmd.Parameters.AddWithValue("@SupplierID", comboBoxSupplier.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@BookID", textBox3.Text);
                    cmd.Parameters.AddWithValue("@CategoryID", comboBoxCategory.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@AuthorName", txtAuthorName.Text);
                    cmd.Parameters.AddWithValue("@BookName", textBox5.Text);
                    cmd.Parameters.AddWithValue("@PublisherName", textBox6.Text);
                    cmd.Parameters.AddWithValue("@PublishedYear", textBox7.Text);
                    cmd.Parameters.AddWithValue("@Price", textBox8.Text);
                    cmd.Parameters.AddWithValue("@ID", this.StockID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Stock Updated Sucessfully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    GetStockRecords();
                    ResetFormControls();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please Select A Stock To Update Its Information.", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(StockID))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM StockTb WHERE StockID = @ID", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@ID", this.StockID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Stock Deleted Sucessfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetStockRecords();
                ResetFormControls();
            }
            else
            {
                MessageBox.Show("Please Select A Stock To Delete.", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetFormControls();
        }

        private void StockRecordsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // đảm bảo không bị lỗi click header
            {
                DataGridViewRow row = StockRecordsDataGridView.Rows[e.RowIndex];
                StockID = row.Cells[0].Value.ToString();
                textBox1.Text = StockID;
                comboBoxSupplier.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                comboBoxCategory.Text = row.Cells[3].Value.ToString();
                txtAuthorName.Text = row.Cells[4].Value.ToString();
                textBox5.Text = row.Cells[5].Value.ToString();
                textBox6.Text = row.Cells[6].Value.ToString();
                textBox7.Text = row.Cells[7].Value.ToString();
                textBox8.Text = row.Cells[8].Value.ToString();
            }
        }
        private string GenerateNextStockID()
        {
            string prefix = "STK";
            string nextID = prefix + "1"; // Mặc định nếu không có dữ liệu nào

            SqlCommand cmd = new SqlCommand("SELECT MAX(CAST(SUBSTRING(StockID, 4, LEN(StockID)) AS INT)) FROM StockTb", con);
            con.Open();
            object result = cmd.ExecuteScalar();
            con.Close();

            if (result != DBNull.Value && result != null)
            {
                int numberPart = Convert.ToInt32(result); // lấy số lớn nhất
                numberPart++; // tăng lên 1
                nextID = prefix + numberPart.ToString(); // ghép vào, không cần định dạng 0
            }

            return nextID;
        }
        private string GenerateNextBookID()
        {
            string prefix = "BOOK";
            string nextID = prefix + "1";

            SqlCommand cmd = new SqlCommand("SELECT MAX(CAST(SUBSTRING(BookID, 5, LEN(BookID)) AS INT)) FROM StockTb", con);
            con.Open();
            object result = cmd.ExecuteScalar();
            con.Close();

            if (result != DBNull.Value && result != null)
            {
                int number = Convert.ToInt32(result);
                number++;
                nextID = prefix + number.ToString();
            }

            return nextID;
        }

    }
}
