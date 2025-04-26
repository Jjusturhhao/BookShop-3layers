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
            CustomizeGrid();
        }
        private void UCOrders_Load(object sender, EventArgs e)
        {
            LoadOrders();
            LoadEmployeeNamesToComboBox();
            cbxStatus.Items.Clear();
            cbxStatus.Items.AddRange(new string[] {
                                    "Chờ xác nhận",
                                    "Đã vận chuyển",
                                    "Đã hoàn thành",
                                    "Đã hủy"
            });
            cbxStatus.SelectedIndex = -1; // Không chọn gì khi khởi động
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
            txtPhone.Clear();
            
            dateTimePickerOrderDate.Checked = false;
            cbxStatus.SelectedIndex = -1;
            txtTotal.Clear();
        }

        private void CustomizeGrid()
        {
            dgvOrders.AutoGenerateColumns = false;
            dgvOrders.Columns.Clear();

            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Order_ID",
                HeaderText = "Mã đơn",
                DataPropertyName = "Order_ID"
            });

            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PhoneNumber",
                HeaderText = "Số điện thoại",
                DataPropertyName = "PhoneNumber"
            });

            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Employee_Name",
                HeaderText = "Nhân viên phụ trách",
                DataPropertyName = "Employee_Name"
            });

            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Order_Date",
                HeaderText = "Ngày đặt",
                DataPropertyName = "Order_Date"
            });

            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Status",
                HeaderText = "Trạng thái",
                DataPropertyName = "Status"
            });

            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Total_Cost",
                HeaderText = "Tổng tiền",
                DataPropertyName = "Total_Cost"
            });

            // Nút "Xem chi tiết"
            DataGridViewButtonColumn btnDetail = new DataGridViewButtonColumn
            {
                Name = "btnDetail",
                HeaderText = "",
                Text = "Xem chi tiết",
                UseColumnTextForButtonValue = true,
                Width = 100
            };
            dgvOrders.Columns.Add(btnDetail);
        }

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Xác định dòng người dùng vừa click
            if (e.RowIndex >= 0)
            {
                //DataGridViewRow row = dgvOrders.SelectedRows[0];

                txtOrderID.Text = dgvOrders.Rows[e.RowIndex].Cells["Order_ID"].Value.ToString();
                txtPhone.Text = dgvOrders.Rows[e.RowIndex].Cells["PhoneNumber"].Value.ToString();
                //txtPhone.Text = row.Cells["PhoneNumber"].Value.ToString();
                cbxEmployeeName.Text = dgvOrders.Rows[e.RowIndex].Cells["Employee_Name"].Value.ToString();
                //cbxEmployeeName.Text = row.Cells["Employee_Name"].Value.ToString();
                if (DateTime.TryParse(dgvOrders.Rows[e.RowIndex].Cells["Order_Date"].Value.ToString(), out DateTime orderDate))
                {
                    dateTimePickerOrderDate.Value = orderDate;
                }
                cbxStatus.Text = dgvOrders.Rows[e.RowIndex].Cells["Status"].Value.ToString();
                //cbxStatus.Text = row.Cells["Status"].Value.ToString();
                txtTotal.Text = dgvOrders.Rows[e.RowIndex].Cells["Total_Cost"].Value.ToString();
                //txtTotal.Text = row.Cells["Total_Cost"].Value.ToString();

                // Chỉ cho phép sửa Status
                txtOrderID.ReadOnly = true;
                txtPhone.ReadOnly = true;
                cbxEmployeeName.Enabled = false;
                txtTotal.ReadOnly = true;
                dateTimePickerOrderDate.Enabled = false; 

                cbxStatus.Enabled = true; 
            }
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
            if (dgvOrders.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                DataGridViewButtonCell buttonCell = dgvOrders.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewButtonCell;
                if (buttonCell != null)
                {
                    buttonCell.Style.BackColor = System.Drawing.Color.MediumSeaGreen;   // Màu nền nút
                    buttonCell.Style.ForeColor = System.Drawing.Color.White;            // Màu chữ nút
                    buttonCell.Style.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            
            
        }
    }
}
