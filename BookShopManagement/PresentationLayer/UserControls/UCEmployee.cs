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
            txtPassword.Enabled = true;
        }

        private void LoadEmployees()
        {
            dgvEmployees.DataSource = employeeBL.GetEmployees();
            HidePasswordInDGV();
        }

        private void ClearFields()
        {
            txtID.Clear();
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
            if (employeeBL.AddEmployee(emp))
            {
                MessageBox.Show("Thêm nhân viên thành công!");
                LoadEmployees();
                ClearFields();
            }
            else
                MessageBox.Show("Thêm thất bại!");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Employee emp = GetEmployeeFromFields();
            if (employeeBL.UpdateEmployee(emp))
            {
                MessageBox.Show("Cập nhật thành công!");
                LoadEmployees();
                ClearFields();
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
                ClearFields();
            }
            else
                MessageBox.Show("Xóa thất bại!");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearFields();
            txtPassword.Enabled = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
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

    }
}
