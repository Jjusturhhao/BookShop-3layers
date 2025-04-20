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
        }

        private void UCSupplier_Load(object sender, EventArgs e)
        {
            dgvSupplier.DataSource = new SupplierBL().GetSuppliers();
        }

        private void LoadSuppliers()
        {
            dgvSupplier.DataSource = supplierBL.GetSuppliers();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Supplier s = GetSupplierFromForm();
            if (supplierBL.AddSupplier(s))
            {
                MessageBox.Show("Thêm nhà cung cấp thành công!");
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
                MessageBox.Show("Cập nhật thành công!");
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
            txtID.Clear();
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

        
    }
}
