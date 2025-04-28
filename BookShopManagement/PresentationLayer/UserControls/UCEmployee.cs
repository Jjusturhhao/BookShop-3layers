using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferObject;

namespace PresentationLayer.UserControls
{
    public partial class UCEmployee : UserControl
    {
        private EmployeeBL employeeBL = new EmployeeBL();
        public UCEmployee()
        {
            InitializeComponent();
            LoadEmployees();
            SetPlaceholder();
            txtPassword.Enabled = true;
            CustomizeColumnHeaders();
        }

        private void LoadEmployees()
        {
            dgvEmployees.DataSource = employeeBL.GetEmployees();
            CustomizeColumnHeaders();
            HidePasswordInDGV();
        }

        private void CustomizeColumnHeaders()
        {
            if (dgvEmployees.Columns.Contains("ID"))
                dgvEmployees.Columns["ID"].HeaderText = "Mã NV";

            if (dgvEmployees.Columns.Contains("Name"))
                dgvEmployees.Columns["Name"].HeaderText = "Tên NV";

            if (dgvEmployees.Columns.Contains("Username"))
                dgvEmployees.Columns["Username"].HeaderText = "Tên đăng nhập";

            if (dgvEmployees.Columns.Contains("Password"))
                dgvEmployees.Columns["Password"].HeaderText = "Mật khẩu";

            if (dgvEmployees.Columns.Contains("Address"))
                dgvEmployees.Columns["Address"].HeaderText = "Địa chỉ";

            if (dgvEmployees.Columns.Contains("Phone"))
                dgvEmployees.Columns["Phone"].HeaderText = "Số điện thoại";
        }

        private void SetPlaceholder()
        {
            txtSearch.ForeColor = Color.Gray;
            txtSearch.Text = "Nhập Mã/Tên nhân viên cần tra cứu";
        }

        private void ClearForm()
        {
            txtID.Text = employeeBL.GenerateNextEmployeeID(); // Tự sinh ID mới mỗi lần clear
            txtName.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
        }

        private Employee GetEmployeeFromFields()
        {
            return new Employee(
                txtID.Text,
                txtName.Text,
                txtUsername.Text,
                txtPassword.Text,
                txtEmail.Text,
                txtAddress.Text,
                txtPhone.Text
            );
        }

        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvEmployees.Rows[e.RowIndex];
                txtID.Text = row.Cells["ID"].Value.ToString();
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtUsername.Text = row.Cells["Username"].Value.ToString();
                txtPassword.Text = row.Cells["Password"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtAddress.Text = row.Cells["Address"].Value.ToString();
                txtPhone.Text = row.Cells["Phone"].Value.ToString();
                txtPassword.Enabled = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Employee emp = GetEmployeeFromFields();

            // Luôn luôn tự generate ID, không lấy từ txtID
            emp.ID = employeeBL.GenerateNextEmployeeID();

            if (employeeBL.AddEmployee(emp))
            {
                MessageBox.Show($"Thêm nhân viên thành công! Mã nhân viên: {emp.ID}");
                LoadEmployees();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Thêm thất bại!");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Employee emp = GetEmployeeFromFields();
            if (employeeBL.UpdateEmployee(emp))
            {
                MessageBox.Show("Cập nhật thành công!");
                LoadEmployees();
                ClearForm();
            }
            else
                MessageBox.Show("Cập nhật thất bại!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            if (employeeBL.DeleteEmployee(id))
            {
                MessageBox.Show("Xóa thành công!");
                LoadEmployees();
                ClearForm();
            }
            else
                MessageBox.Show("Xóa thất bại!");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearForm();
            txtPassword.Enabled = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            // Nếu đang là placeholder thì bỏ qua không tìm kiếm
            if (keyword == "Nhập Mã/Tên nhân viên cần tra cứu")
            {
                return;
            }

            if (!string.IsNullOrEmpty(keyword))
            {
                dgvEmployees.DataSource = new EmployeeBL().SearchEmployees(keyword);
                HidePasswordInDGV();
            }
            else
            {
                // Nếu người dùng không nhập gì → load lại toàn bộ
                LoadEmployees();
            }
        }

        private void HidePasswordInDGV()
        {
            foreach (DataGridViewRow row in dgvEmployees.Rows)
            {
                if (row.Cells["Password"].Value != null)
                {
                    string realPass = row.Cells["Password"].Value.ToString();
                    row.Cells["Password"].Tag = realPass; // Lưu pass gốc
                    row.Cells["Password"].Value = new string('*', realPass.Length); // Hiện ***
                }
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Nhập Mã/Tên nhân viên cần tra cứu")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.ForeColor = Color.Gray;
                txtSearch.Text = "Nhập Mã/Tên nhân viên cần tra cứu";
            }
        }
    }
}
