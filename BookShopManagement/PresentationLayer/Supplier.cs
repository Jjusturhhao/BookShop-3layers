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
    public partial class Supplier : Form
    {
        public string SupplierID;
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=BookStoreManagement;Integrated Security=True;TrustServerCertificate=True");

        public Supplier()
        {
            InitializeComponent();
        }

        private void Supplier_Load(object sender, EventArgs e)
        {
            GetSupplierRecords();
            ResetFormControls();
        }
        private void ResetFormControls()
        {
            SupplierID = null;
            textBox2.Text = GenerateNextSupplierID();
            textBox2.ReadOnly = true;
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();
            textBox8.Clear();
            textBox2.Focus();
        }

        private void GetSupplierRecords()
        {
            SqlCommand cmd = new SqlCommand("Select * from SuppliersTb", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            SuppliersRecordsDataGridView.DataSource = dt;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO SuppliersTb VALUES (@SupplierID, @Supplier_name, @Supplier_City, @Supplier_email, @Supplier_phone)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@SupplierID", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Supplier_name", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Supplier_City", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Supplier_email", textBox6.Text);
                    cmd.Parameters.AddWithValue("@Supplier_phone", textBox8.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("New Supplier Record Sucessfully Saved In The Database", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetSupplierRecords();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }
        private bool IsValid()
        {
            if (textBox2.Text == string.Empty)
            {
                MessageBox.Show("Supplier ID Is Required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(SupplierID))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("UPDATE SuppliersTb SET Supplier_ID = @SupplierID, Supplier_name = @SupplierName , Supplier_city = @SupplierCity, Supplier_email = @SupplierEmail, Supplier_phone = @SupplierPhone WHERE Supplier_ID = @ID", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@SupplierID", textBox2.Text);
                    cmd.Parameters.AddWithValue("@SupplierName", textBox3.Text);
                    cmd.Parameters.AddWithValue("@SupplierCity", textBox4.Text);
                    cmd.Parameters.AddWithValue("@SupplierEmail", textBox6.Text);
                    cmd.Parameters.AddWithValue("@SupplierPhone", textBox8.Text);
                    cmd.Parameters.AddWithValue("@ID", this.SupplierID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Supplier  Updated Sucessfully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetSupplierRecords();
                    ResetFormControls();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please Select A Supplier  To Update Its Information.", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(SupplierID))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM SuppliersTb WHERE Supplier_ID = @ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", this.SupplierID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Supplier Record Deleted Sucessfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetSupplierRecords();
                ResetFormControls();
            }
            else
            {
                MessageBox.Show("Please Select A Supplier Record To Delete.", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetFormControls();
        }

        private void SuppliersRecordsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = SuppliersRecordsDataGridView.Rows[e.RowIndex];

                SupplierID = row.Cells[0].Value?.ToString(); // Lấy mã ID thật sự (VD: SUP1)

                textBox2.Text = SupplierID;
                textBox3.Text = row.Cells[1].Value?.ToString();
                textBox4.Text = row.Cells[2].Value?.ToString();
                textBox6.Text = row.Cells[3].Value?.ToString();
                textBox8.Text = row.Cells[4].Value?.ToString();
            }
        }
        private string GenerateNextSupplierID()
        {
            string prefix = "SUP";
            string nextID = prefix + "1";

            SqlCommand cmd = new SqlCommand("SELECT MAX(CAST(SUBSTRING(Supplier_ID, 4, LEN(Supplier_ID)) AS INT)) FROM SuppliersTb", con);
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
