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
    public partial class Customers_Details : Form
    {
        public string CustomerID = "";
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=BookStoreManagement;Integrated Security=True;TrustServerCertificate=True");

        public Customers_Details()
        {
            InitializeComponent();
        }

        private void Customers_Details_Load(object sender, EventArgs e)
        {
            GetCustomersRecords();
            ResetFormControls();
        }
        private void ResetFormControls()
        {
            txtID.Clear();
            txtName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtAddress.Clear();
            txtID.Focus();
        }
        private void GetCustomersRecords()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE Role = 'Customer'", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();

            CustomersRecordsDataGridView.DataSource = dt;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Users (User_ID, Name, PhoneNumber, Email, Username, Password, Address) VALUES (@User_ID, @Name, @PhoneNumber, @Email, @Username, @Password, @Address)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@User_ID", txtID.Text);
                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@PhoneNumber", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Thêm khách hàng mới thành công!", "Đã lưu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetCustomersRecords();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(txtID.Text) ||
                string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Hãy điền đầy đủ thông tin nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CustomerID))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Users SET Name = @Name, Username = @Username, Password = @Password, Email = @Email, Address = @Address, PhoneNumber = @PhoneNumber WHERE User_ID = @ID AND Role = 'Customer'", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@PhoneNumber", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@ID", this.CustomerID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Cập nhật thành công", "Đã cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    GetCustomersRecords();
                    ResetFormControls();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn nhân viên cần cập nhật thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CustomerID))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Users WHERE User_ID = @ID AND Role = 'Customer'", con);
                cmd.CommandType = CommandType.Text;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", this.CustomerID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Đã xóa 1 khách hàng", "Đã xóa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetCustomersRecords();
                ResetFormControls();
            }
            else
            {
                MessageBox.Show("Hãy chọn khách hàng cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetFormControls();
        }

        private void CustomersRecordsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu e.RowIndex hợp lệ
            if (e.RowIndex >= 0)
            {
                // Lấy dữ liệu hàng được chọn
                DataGridViewRow selectedRow = CustomersRecordsDataGridView.Rows[e.RowIndex];

                // Kiểm tra hàng có dữ liệu hay không (tránh lỗi khi bấm vào hàng trống)
                if (selectedRow.Cells["User_ID"].Value != null &&
                    !string.IsNullOrWhiteSpace(selectedRow.Cells["User_ID"].Value.ToString()))
                {
                    // Gán dữ liệu vào các ô nhập
                    CustomerID = selectedRow.Cells["User_ID"].Value.ToString();
                    txtID.Text = CustomerID;
                    txtName.Text = selectedRow.Cells["Name"].Value?.ToString() ?? "";
                    txtPhone.Text = selectedRow.Cells["PhoneNumber"].Value?.ToString() ?? "";
                    txtEmail.Text = selectedRow.Cells["Email"].Value?.ToString() ?? "";
                    txtUsername.Text = selectedRow.Cells["Username"].Value?.ToString() ?? "";
                    txtPassword.Text = selectedRow.Cells["Password"].Value?.ToString() ?? "";
                    txtAddress.Text = selectedRow.Cells["Address"].Value?.ToString() ?? "";

                    // Khóa txtID vì đang chọn khách hàng cũ
                    txtID.Enabled = false;
                }
                else
                {
                    // Nếu chọn hàng rỗng, reset form để nhập mới
                    ResetFormControls();

                    // Mở khóa txtID để nhập ID mới
                    txtID.Enabled = true;
                    txtID.Focus();
                }
            }
        }
    }
}
