using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TransferObject;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace PresentationLayer.UserControls
{
    public partial class UCCusOrders : UserControl
    {
        private CusOrderBL cusOrderBL;
        private string currentUsername;
        private string phone;
       // private UCCusOrderDetail currentDetailForm = null;

        public Action RefreshOrders { get; set; }


        //Tạo delegate để báo cho Homepage biết khi cần mở chi tiết đơn hàng
        public Action<string, string> OnOrderDetailClick { get; set; } //// orderID, phone


        public UCCusOrders(string currentUsername, string phone)
        {
            InitializeComponent();
            cusOrderBL = new CusOrderBL();
            this.currentUsername = currentUsername;
            this.phone = phone;
        }

        private void UCCusOrders_Load(object sender, EventArgs e)
        {
            LoadCustomerOrders();
            CustomizeGrid();
        }

        // ✅ Public method để Homepage.cs có thể gọi khi cần reload
        public void LoadOrders()
        {
            LoadCustomerOrders();
        }

        private void LoadCustomerOrders()
        {
            try
            {
                List<CusOrder> orders = cusOrderBL.GetCusOrdersByUsername(currentUsername);
                dgvOrders.DataSource = orders;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải đơn hàng: " + ex.Message);
            }
        }

        private void CustomizeGrid()
        {
            dgvOrders.AutoGenerateColumns = false;
            dgvOrders.Columns.Clear();

            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "STT",
                DataPropertyName = "Index",
            });
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Orderid",
                HeaderText = "Mã đơn",
                DataPropertyName = "Orderid",
            });
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Ngày đặt",
                DataPropertyName = "Orderdate",
            });
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tổng tiền",
                DataPropertyName = "Total",
            });
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Trạng thái",
                DataPropertyName = "Status",
            });

            // Cột nút "Xem chi tiết"
            DataGridViewButtonColumn btnDetail = new DataGridViewButtonColumn();
            btnDetail.HeaderText = "";
            btnDetail.Text = "Xem chi tiết";
            btnDetail.UseColumnTextForButtonValue = true;
            btnDetail.Width = 100;
            dgvOrders.Columns.Add(btnDetail);
        }

        private void dgvOrders_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvOrders.Columns[e.ColumnIndex].DataPropertyName == "Total" && e.Value != null)
            {
                if (int.TryParse(e.Value.ToString(), out int total))
                {
                    e.Value = total.ToString("#,##0").Replace(",", ".");
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
                    buttonCell.Style.Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold);
                }
            }
        }

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvOrders.Columns.Count - 1)
            {
                // Lấy orderID từ dòng được chọn
                string orderId = dgvOrders.Rows[e.RowIndex].Cells["Orderid"].Value.ToString();
        OnOrderDetailClick?.Invoke(orderId, phone);
                UCCusOrderDetail detail = new UCCusOrderDetail(orderId,null ,phone);
                detail.ShowButtons();

               // OnOrderDetailClick?.Invoke(orderId, phone);
                ReloadData();
            }
}

        private void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void ReloadData()
        {
            LoadOrders();  // Làm mới lại danh sách đơn hàng
        }
        
    }
}
