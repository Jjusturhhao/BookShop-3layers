using BusinessLayer;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

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
            LoadEmployeeNamesToComboBox();
        }
        private void LoadOrders()
        {
            dgvOrders.DataSource = new OrderBL().GetOrders();

        }

        public void LoadEmployeeNamesToComboBox()
        {
            List<string> employeeNames = orderBL.GetEmployeeNames();  // Sử dụng orderBL đã khởi tạo sẵn
            cbxEmployeeName.DataSource = employeeNames;
        }

        private void ResetFormControls()
        {
            txtOrderID.Clear();
            txtCustomerName.Clear();
            cbxEmployeeName.Items.Clear();
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
                cbxEmployeeName.Text = row.Cells["Employee_Name"].Value.ToString();
                if (DateTime.TryParse(row.Cells["Order_Date"].Value.ToString(), out DateTime orderDate))
                {
                    dateTimePickerOrderDate.Value = orderDate;
                }
                cbxStatus.Text = row.Cells["Status"].Value.ToString();
                txtTotal.Text = row.Cells["Total_Cost"].Value.ToString();

                // Chỉ cho phép sửa Status
                txtOrderID.ReadOnly = true;
                txtCustomerName.ReadOnly = true;
                cbxEmployeeName.Enabled = false;
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

        private void dgvOrders_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvOrders.Columns[e.ColumnIndex].Name == "Total_Cost" && e.Value != null)
            {
                if (int.TryParse(e.Value.ToString(), out int cost))
                {
                    e.Value = cost.ToString("N0");
                    e.FormattingApplied = true;
                }
            }
        }
    }
}
