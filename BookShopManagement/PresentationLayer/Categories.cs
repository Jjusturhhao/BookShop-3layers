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
    public partial class Categories : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=BookStoreManagement;Integrated Security=True;TrustServerCertificate=True");
        public string CategoryID;

        public Categories()
        {
            InitializeComponent();
        }

        private void Categories_Load(object sender, EventArgs e)
        {
            GetCategoryRecords();
            ResetFormControls();
        }
        private void GetCategoryRecords()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM BookCategory", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            CategoriesRecordsDataGridView.DataSource = dt;
        }
        private void ResetFormControls()
        {
            CategoryID = string.Empty;
            txtCateID.Text = GenerateNextCategoryID();
            txtCateID.ReadOnly = true;
            txtCateName.Clear();
            txtCateID.Enabled = true;
        }

        private void CategoriesRecordsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = CategoriesRecordsDataGridView.Rows[e.RowIndex];
                CategoryID = row.Cells[0].Value.ToString();
                txtCateID.Text = CategoryID;
                txtCateName.Text = row.Cells[1].Value.ToString();
                txtCateID.Enabled = false;
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO BookCategory (CategoryID, CategoryName) VALUES (@ID, @Name)", con);
            cmd.Parameters.AddWithValue("@ID", txtCateID.Text.Trim());
            cmd.Parameters.AddWithValue("@Name", txtCateName.Text.Trim());
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Category added successfully.");
            GetCategoryRecords();
            ResetFormControls();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CategoryID))
            {
                SqlCommand cmd = new SqlCommand("UPDATE BookCategory SET CategoryName = @Name WHERE CategoryID = @ID", con);
                cmd.Parameters.AddWithValue("@ID", CategoryID);
                cmd.Parameters.AddWithValue("@Name", txtCateName.Text.Trim());
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Category updated successfully.");
                GetCategoryRecords();
                ResetFormControls();
            }
            else
            {
                MessageBox.Show("Please Select A Category Record To Update.", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (CategoryID == "")
            {
                MessageBox.Show("Please select a Category Record to delete.");
                return;
            }

            SqlCommand cmd = new SqlCommand("DELETE FROM BookCategory WHERE CategoryID = @ID", con);
            cmd.Parameters.AddWithValue("@ID", CategoryID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Category Record Deleted Sucessfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GetCategoryRecords();
            ResetFormControls();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetFormControls();
        }
        private string GenerateNextCategoryID()
        {
            string prefix = "CAT";
            string nextID = prefix + "1";

            SqlCommand cmd = new SqlCommand("SELECT MAX(CAST(SUBSTRING(CategoryID, 4, LEN(CategoryID)) AS INT)) FROM BookCategory", con);
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
