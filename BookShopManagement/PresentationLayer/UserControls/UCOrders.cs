using BusinessLayer;
using FontAwesome.Sharp;
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

namespace PresentationLayer.UserControls
{
    public partial class UCOrders : UserControl
    {
        private OrderBL orderBL;
        public UCOrders()
        {
            InitializeComponent();
            orderBL = new OrderBL();
        }
        private void UCOrders_Load(object sender, EventArgs e)
        {
            LoadOrders();
        }
        private void LoadOrders()
        {
            DataTable orders = orderBL.GetOrders();
            dgvOrders.DataSource = orders;
            if (dgvOrders.Columns.Contains("Total_Cost"))
            {
                dgvOrders.Columns["Total_Cost"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                // Định dạng số có dấu phẩy 
                dgvOrders.Columns["Total_Cost"].DefaultCellStyle.Format = "N0";
            }
            
        }
        private void ResetFormControls()
        {
            txtOrderID.Clear();
            txtCustomerName.Clear();
            txtEmployeeID.Clear();
            dateTimePickerOrderDate.Checked = false;
            cbxStatus.Text = "";
            txtTotal.Clear();
        }

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Xác định dòng người dùng vừa click
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvOrders.SelectedRows[0];

                txtOrderID.Text = row.Cells["Order_ID"].Value.ToString();
                txtCustomerName.Text = row.Cells["Customer_Name"].Value.ToString();
                txtEmployeeID.Text = row.Cells["Employee_ID"].Value.ToString();
                if (DateTime.TryParse(row.Cells["Order_Date"].Value.ToString(), out DateTime orderDate))
                {
                    dateTimePickerOrderDate.Value = orderDate;
                }
                cbxStatus.Text = row.Cells["Status"].Value.ToString();
                txtTotal.Text = row.Cells["Total_Cost"].Value.ToString();

                // Chỉ cho phép sửa Status
                txtOrderID.ReadOnly = true;
                txtCustomerName.ReadOnly = true;
                txtEmployeeID.ReadOnly = true;
                txtTotal.ReadOnly = true;
                dateTimePickerOrderDate.Enabled = false; 

                cbxStatus.Enabled = true; 
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetFormControls();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtOrderID.Text))
            {
                try
                {
                    orderBL.UpdateOrder(txtOrderID.Text, cbxStatus.Text);

                    MessageBox.Show("Trạng thái đơn hàng đã được cập nhật!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadOrders();
                    ResetFormControls();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn đơn hàng để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
