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
using TransferObject;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;


namespace PresentationLayer.UserControls
{
    public partial class UCOrders : UserControl
    {
        private OrderBL orderBL;
        public bool IsEmployee { get; set; }
        public Action<string, string, string> OnOrderDetailClick { get; set; } //orderid, employee, phone

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
            SetPlaceholder();
            // Set danh sách trạng thái cố định
            cbxStatus.DataSource = new List<string> { "Chờ xác nhận", "Đang vận chuyển" };
            cbxStatus.SelectedIndex = -1; // Không chọn gì khi khởi động
        }

        private void SetPlaceholder()
        {
            txtSearch.ForeColor = Color.Gray;
            txtSearch.Text = "Nhập số điện thoại cần tra cứu";
        }

        private void LoadOrders()
        {
            dgvOrders.DataSource = orderBL.GetOrders();
        }

        public void LoadEmployeeNamesToComboBox()
        {
            List<string> employeeNames = orderBL.GetEmployeeNames();  // Sử dụng orderBL đã khởi tạo sẵn
            cbxEmployeeName.DataSource = employeeNames;
        }

        //public void LoadStatusToComboBox()
        //{
        //    List<string> status = orderBL.GetOrderStatus();  // Sử dụng orderBL đã khởi tạo sẵn
        //    cbxStatus.DataSource = status;
        //}

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

            //if (e.RowIndex >= 0)
            //{
            //    //DataGridViewRow row = dgvOrders.SelectedRows[0];
            //    if (e.ColumnIndex >= 0 && dgvOrders.Columns[e.ColumnIndex].Name == "btnDetail")
            //    {
            //        string orderId = dgvOrders.Rows[e.RowIndex].Cells["Order_ID"].Value.ToString();
            //        string employee = dgvOrders.Rows[e.RowIndex].Cells["Employee_Name"].Value.ToString();
            //        string phone = dgvOrders.Rows[e.RowIndex].Cells["PhoneNumber"].Value.ToString();
            //        if (!string.IsNullOrEmpty(orderId))
            //        {
            //            OnOrderDetailClick?.Invoke(orderId, employee, phone);
            //        }
            //        if (!string.IsNullOrEmpty(orderId))
            //        {
            //            UCCusOrderDetail detail = new UCCusOrderDetail(orderId, employee, phone, true);

            //            detail.OnBackClick = () =>
            //            {
            //                this.Controls.Remove(detail);
            //                LoadOrders();
            //            };
            //            this.Controls.Add(detail);
            //            detail.BringToFront();

            //        }

            //    }
            if (e.RowIndex < 0)
                return;

            // Nếu click vào nút "Xem chi tiết"
            if (e.ColumnIndex >= 0 && dgvOrders.Columns[e.ColumnIndex].Name == "btnDetail")
            {
                string orderId = dgvOrders.Rows[e.RowIndex].Cells["Order_ID"].Value.ToString();
                string employee = dgvOrders.Rows[e.RowIndex].Cells["Employee_Name"].Value.ToString();
                string phone = dgvOrders.Rows[e.RowIndex].Cells["PhoneNumber"].Value.ToString();

                if (!string.IsNullOrEmpty(orderId))
                {
                    OnOrderDetailClick?.Invoke(orderId, employee, phone);

                    UCCusOrderDetail detail = new UCCusOrderDetail(orderId, employee, phone);
                    detail.OnBackClick = () =>
                    {
                        this.Controls.Remove(detail);
                        LoadOrders();
                    };
                    this.Controls.Add(detail);
                    detail.BringToFront();
                }

                return; 
            }

            // Nếu click vào dòng dữ liệu, hiển thị thông tin
            txtOrderID.Text = dgvOrders.Rows[e.RowIndex].Cells["Order_ID"].Value.ToString();
            txtPhone.Text = dgvOrders.Rows[e.RowIndex].Cells["PhoneNumber"].Value.ToString();
            cbxEmployeeName.Text = dgvOrders.Rows[e.RowIndex].Cells["Employee_Name"].Value.ToString();
            if (DateTime.TryParse(dgvOrders.Rows[e.RowIndex].Cells["Order_Date"].Value.ToString(), out DateTime orderDate))
            {
                dateTimePickerOrderDate.Value = orderDate;
            }
            cbxStatus.Text = dgvOrders.Rows[e.RowIndex].Cells["Status"].Value.ToString();
            txtTotal.Text = dgvOrders.Rows[e.RowIndex].Cells["Total_Cost"].Value.ToString();

            txtOrderID.ReadOnly = true;
            txtPhone.ReadOnly = true;
            cbxEmployeeName.Enabled = false;
            txtTotal.ReadOnly = true;
            dateTimePickerOrderDate.Enabled = false;

            cbxStatus.Enabled = true;
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
            string keyword = txtSearch.Text.Trim();

            // Nếu đang là placeholder thì bỏ qua không tìm kiếm
            if (keyword == "Nhập số điện thoại cần tra cứu")
            {
                return;
            }

            if (string.IsNullOrEmpty(keyword))
            {
                // Nếu không có từ khóa, tải lại toàn bộ danh sách đơn hàng
                LoadOrders();
                return;
            }

            try
            {
                // Lấy danh sách đơn hàng từ Business Layer
                var orders = orderBL.GetOrders();

                // Tạo DataTable mới để chứa đơn hàng lọc theo số điện thoại
                DataTable searchResult = new DataTable();
                searchResult.Columns.Add("Order_ID");
                searchResult.Columns.Add("PhoneNumber");
                searchResult.Columns.Add("Employee_Name");
                searchResult.Columns.Add("Order_Date", typeof(DateTime));
                searchResult.Columns.Add("Status");
                searchResult.Columns.Add("Total_Cost", typeof(int));

                foreach (var order in orders)
                {
                    if (order.PhoneNumber.Contains(keyword))
                    {
                        searchResult.Rows.Add(order.Order_ID, order.PhoneNumber, order.Employee_Name, order.Order_Date, order.Status, order.Total_Cost);
                    }
                }
                dgvOrders.DataSource = searchResult;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Nhập số điện thoại cần tra cứu")
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
                txtSearch.Text = "Nhập số điện thoại cần tra cứu";
            }
        }
    }
}
