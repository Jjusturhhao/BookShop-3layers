using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace PresentationLayer.UserControls
{
    public partial class UCCheckout : UserControl
    {
        private CheckoutBL CheckoutBL;
        private Panel selectedPanel = null;  // Biến lưu trữ panel của sách đã chọn
        private string selectedBookID = string.Empty; 
        private string selectedBookName = string.Empty; 
        private int selectedPrice = 0;
        public UCCheckout()
        {
            InitializeComponent();
            CheckoutBL = new CheckoutBL();
            Load += UCCheckout_Load;
        }
        public void UCCheckout_Load(object sender, EventArgs e)
        {
            InitDgvBooks();
            LoadBooks();
            LoadDetails();
            dgvBooks.CellClick += dgvBooks_CellClick; // Xử lý sự kiện nhấp chuột vào dòng sách
        }
        private void btnCustomer_Click(object sender, EventArgs e)
        {

        }
        private void InitDgvBooks()
        {
            dgvBooks.Columns.Clear(); // Đảm bảo không bị lặp cột

            dgvBooks.Columns.Add("BookID", "Mã sách");
            dgvBooks.Columns.Add("BookName", "Tên sách");
            dgvBooks.Columns.Add("Price", "Đơn giá");
            dgvBooks.Columns.Add("Quantity", "Tồn kho");

            dgvBooks.Columns["BookName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvBooks.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvBooks.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void LoadBooks()
        {
            dgvBooks.Rows.Clear();

            DataTable books = CheckoutBL.GetBooks();

            foreach (DataRow row in books.Rows)
            {
                string bookID = row["BookID"].ToString();
                string bookName = row["BookName"].ToString();
                int price = Convert.ToInt32(row["Price"]);
                int quantity = CheckoutBL.GetQuantity(bookID);

                dgvBooks.Rows.Add(bookID, bookName, price.ToString(), quantity);
            }

            dgvBooks.Columns["BookName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvBooks.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvBooks.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }


        private void dgvBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo chỉ xử lý khi nhấp vào một dòng hợp lệ
            {
                // Lưu thông tin sách được chọn
                selectedBookID = dgvBooks.Rows[e.RowIndex].Cells["BookID"].Value.ToString();
                selectedBookName = dgvBooks.Rows[e.RowIndex].Cells["BookName"].Value.ToString();
                selectedPrice = Convert.ToInt32(dgvBooks.Rows[e.RowIndex].Cells["Price"].Value.ToString().Replace(",", ""));

                // Debug kiểm tra
                Console.WriteLine($"Đã chọn sách: {selectedBookName}");

                // Cập nhật số lượng tồn vào NumericUpDown
                UpdateQuantitySelector(selectedBookID);
            }
        }

        private void UpdateQuantitySelector(string bookID)
        {
            // Lấy số lượng từ cơ sở dữ liệu và cập nhật NumericUpDown
            int quantity = CheckoutBL.GetQuantity(bookID);
            numericUpDownQuantity.Value = 1; // Mặc định chọn 1 nếu chưa có gì
            numericUpDownQuantity.Maximum = quantity; // Giới hạn số lượng theo tồn kho
        }

        private void LoadDetails()
        {
            dgvDetails.Columns.Clear(); 
            dgvDetails.Columns.Add("Tên sách", "Tên sách");
            dgvDetails.Columns.Add("Số lượng", "Số lượng");
            dgvDetails.Columns.Add("Đơn giá", "Đơn giá");
            dgvDetails.Columns.Add("Thành tiền", "Thành tiền");
            dgvDetails.Columns["Đơn giá"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetails.Columns["Thành tiền"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedBookID))
            {
                MessageBox.Show("Vui lòng chọn sách trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy thông tin từ các điều khiển
            int quantity = (int)numericUpDownQuantity.Value; 
            int unitPrice = selectedPrice;
            int totalPrice = unitPrice * quantity;

            //bool bookExists = false;

            //foreach (DataGridViewRow row in dgvDetails.Rows)
            //{
            //    if (row.Cells["Tên sách"].Value.ToString() == selectedBookName)
            //    {
            //        // Cập nhật số lượng và thành tiền6
            //        int existingQuantity = Convert.ToInt32(row.Cells["Số lượng"].Value);
            //        row.Cells["Số lượng"].Value = existingQuantity + quantity;
            //        row.Cells["Thành tiền"].Value = (existingQuantity + quantity) * unitPrice;
            //        bookExists = true;
            //        break;
            //    }
            //}

            //// Nếu sách chưa có, thêm mới dòng
            //if (!bookExists)
            //{
            //    DataGridViewRow row = new DataGridViewRow();
            //    row.Cells.Add(new DataGridViewTextBoxCell() { Value = selectedBookName });
            //    row.Cells.Add(new DataGridViewTextBoxCell() { Value = quantity });
            //    row.Cells.Add(new DataGridViewTextBoxCell() { Value = unitPrice.ToString("#,##0") });
            //    row.Cells.Add(new DataGridViewTextBoxCell() { Value = totalPrice.ToString("#,##0") });

            //    dgvDetails.Rows.Add(row);
            //}

            DataGridViewRow row = new DataGridViewRow();
            row.Cells.Add(new DataGridViewTextBoxCell() { Value = selectedBookName });
            row.Cells.Add(new DataGridViewTextBoxCell() { Value = quantity });
            row.Cells.Add(new DataGridViewTextBoxCell() { Value = unitPrice.ToString() });
            row.Cells.Add(new DataGridViewTextBoxCell() { Value = totalPrice.ToString() });

            dgvDetails.Rows.Add(row);

            UpdateTotalBill();
        }
        private void UpdateTotalBill()
        {
            int totalBill = 0;

            foreach (DataGridViewRow row in dgvDetails.Rows)
            {
                // Kiểm tra để tránh lỗi khi có dòng trống
                if (row.Cells["Thành tiền"].Value != null)
                {
                    totalBill += Convert.ToInt32(row.Cells["Thành tiền"].Value);
                }
            }

            txtTotalBill.Text = totalBill.ToString();
        }

        private void CalculateChange()
        {
            int totalBill = Convert.ToInt32(txtTotalBill.Text);
            int totalPaid = Convert.ToInt32(txtTotalPaid.Text);

            if (totalPaid < totalBill)
            {
                MessageBox.Show("Số tiền khách đưa chưa đủ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int change = totalPaid - totalBill;
            txtChange.Text = change.ToString(); 
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            CalculateChange();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvBooks.Rows.Clear(); 

            string keyword = txtNameSearch.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập tên sách cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Lấy kết quả tìm kiếm
                DataTable result = CheckoutBL.GetBooksByName(keyword);

                foreach (DataRow row in result.Rows)
                {
                    string bookID = row["BookID"].ToString();
                    string bookName = row["BookName"].ToString();
                    int price = Convert.ToInt32(row["Price"]);
                    int quantity = CheckoutBL.GetQuantity(bookID);

                    // Thêm từng dòng vào dgvBooks
                    dgvBooks.Rows.Add(bookID, bookName, price.ToString(), quantity);
                }

                // Đảm bảo cột "Tên sách" tự động điều chỉnh kích thước
                dgvBooks.Columns["BookName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvBooks.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvBooks.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                if (result.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy sách nào phù hợp.", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadBooks();
            txtNameSearch.Text = String.Empty;

        }
    }
}