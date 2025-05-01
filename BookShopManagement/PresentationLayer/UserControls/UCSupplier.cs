using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using BusinessLayer;
using TransferObject;

namespace PresentationLayer.UserControls
{
    public partial class UCSupplier : UserControl
    {
        private SupplierBL supplierBL = new SupplierBL();

        public UCSupplier()
        {
            InitializeComponent();
            SetPlaceholder();
        }

        private void UCSupplier_Load(object sender, EventArgs e)
        {
            dgvSupplier.DataSource = new SupplierBL().GetSuppliers();
            CustomizeColumnHeaders();
        }

        private void LoadSuppliers()
        {
            dgvSupplier.DataSource = supplierBL.GetSuppliers();
            CustomizeColumnHeaders();
        }

        private void CustomizeColumnHeaders()
        {
            if (dgvSupplier.Columns.Contains("ID"))
                dgvSupplier.Columns["ID"].HeaderText = "Mã NCC";

            if (dgvSupplier.Columns.Contains("Name"))
                dgvSupplier.Columns["Name"].HeaderText = "Tên NCC";

            if (dgvSupplier.Columns.Contains("Address"))
                dgvSupplier.Columns["Address"].HeaderText = "Địa chỉ";

            if (dgvSupplier.Columns.Contains("Phone"))
                dgvSupplier.Columns["Phone"].HeaderText = "Số điện thoại";
        }

        private void SetPlaceholder()
        {
            txtSearch.ForeColor = Color.Gray;
            txtSearch.Text = "Nhập Mã/Tên NCC cần tra cứu";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Supplier s = GetSupplierFromForm();

            // Luôn luôn tự generate ID, không lấy từ txtID
            s.ID = supplierBL.GenerateNextSupplierID();

            if (supplierBL.AddSupplier(s))
            {
                MessageBox.Show($"Thêm nhà cung cấp thành công! Mã nhà cung cấp: {s.ID}");
                LoadSuppliers();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Thêm thất bại!");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Supplier s = GetSupplierFromForm();

            if (supplierBL.UpdateSupplier(s))
            {
                MessageBox.Show("Cập nhật nhà cung cấp thành công!");
                LoadSuppliers();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtID.Text.Trim();
            if (supplierBL.DeleteSupplier(id))
            {
                MessageBox.Show("Xoá thành công!");
                LoadSuppliers();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Xoá thất bại!");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearForm();    
        }

        private void ClearForm()
        {
            txtID.Text = supplierBL.GenerateNextSupplierID(); // Tự sinh ID mới mỗi lần clear
            txtName.Clear();
            txtAddress.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
        }

        private Supplier GetSupplierFromForm()
        {
            return new Supplier(
                txtID.Text.Trim(),
                txtName.Text.Trim(),
                txtAddress.Text.Trim(),
                txtEmail.Text.Trim(),
                txtPhone.Text.Trim()
            );
        }

        private void dgvSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtID.Text = dgvSupplier.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                txtName.Text = dgvSupplier.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                txtAddress.Text = dgvSupplier.Rows[e.RowIndex].Cells["Address"].Value.ToString();
                txtEmail.Text = dgvSupplier.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                txtPhone.Text = dgvSupplier.Rows[e.RowIndex].Cells["Phone"].Value.ToString();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //string keyword = txtSearch.Text.Trim();
            //if (!string.IsNullOrEmpty(keyword))
            //{
            //    dgvSupplier.DataSource = new SupplierBL().SearchSuppliers(keyword);
            //}
            //else
            //{
            //    // Nếu người dùng không nhập gì → load lại toàn bộ
            //    LoadSuppliers();
            //}
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            // Nếu đang là placeholder thì bỏ qua không tìm kiếm
            if (keyword == "Nhập Mã/Tên NCC cần tra cứu")
            {
                return;
            }

            if (!string.IsNullOrEmpty(keyword))
            {
                dgvSupplier.DataSource = new SupplierBL().SearchSuppliers(keyword);
            }
            else
            {
                // Nếu người dùng không nhập gì → load lại toàn bộ
                LoadSuppliers();
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Nhập Mã/Tên NCC cần tra cứu")
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
                txtSearch.Text = "Nhập Mã/Tên NCC cần tra cứu";
            }
        }
    }
}
