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
using System.Windows.Input;
using TransferObject;

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
            LoadCategoriesToCBX();
            LoadBooks();
            LoadDetails();
            dgvBooks.CellClick += dgvBooks_CellClick; // Xử lý sự kiện nhấp chuột vào dòng sách
        }
        private void btnCustomer_Click(object sender, EventArgs e)
        {

        }
        private void LoadCategoriesToCBX()
        {
            List<BookCategoryStock> categories = CheckoutBL.GetCategories();

            // Đổ dữ liệu vào ComboBox
            cbxCategories.DataSource = categories;
            cbxCategories.DisplayMember = "CategoryName";  // Hiển thị tên danh mục trong ComboBox
            cbxCategories.ValueMember = "CategoryID";
            cbxCategories.SelectedIndex = -1;
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
            var books = CheckoutBL.GetBooks();

            foreach (var book in books)
            {
                dgvBooks.Rows.Add(book.Bookid, book.Bookname, book.Price, book.Quantity);
            }

            dgvBooks.Columns["BookName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvBooks.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvBooks.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        private void LoadBooksByCate()
        {
            if (cbxCategories.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn danh mục!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string categoryID = cbxCategories.SelectedValue.ToString();
            var books = CheckoutBL.GetBooksByCategory(categoryID);

            dgvBooks.Rows.Clear(); 

            foreach (var book in books)
            {
                dgvBooks.Rows.Add(book.Bookid, book.Bookname, book.Price, book.Quantity);
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

            bool bookExists = false;

            foreach (DataGridViewRow dgvRow in dgvDetails.Rows)
            {
                if (dgvRow.Cells["Tên sách"].Value != null && dgvRow.Cells["Tên sách"].Value.ToString() == selectedBookName)
                {
                    // Cập nhật số lượng và thành tiền
                    int existingQuantity = Convert.ToInt32(dgvRow.Cells["Số lượng"].Value);
                    dgvRow.Cells["Số lượng"].Value = existingQuantity + quantity;
                    dgvRow.Cells["Thành tiền"].Value = (existingQuantity + quantity) * unitPrice;
                    bookExists = true;
                    break;
                }
            }

            // Nếu sách chưa có, thêm mới dòng
            if (!bookExists)
            {
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.Cells.Add(new DataGridViewTextBoxCell() { Value = selectedBookName });
                newRow.Cells.Add(new DataGridViewTextBoxCell() { Value = quantity });
                newRow.Cells.Add(new DataGridViewTextBoxCell() { Value = unitPrice });
                newRow.Cells.Add(new DataGridViewTextBoxCell() { Value = totalPrice });

                dgvDetails.Rows.Add(newRow);
            }

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
            if (rdByCash.Checked == true)
            {
                int totalBill = Convert.ToInt32(txtTotalBill.Text);
                if (string.IsNullOrEmpty(txtTotalPaid.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int totalPaid = Convert.ToInt32(txtTotalPaid.Text);

                if (totalPaid < totalBill)
                {
                    MessageBox.Show("Số tiền khách đưa chưa đủ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int change = totalPaid - totalBill;
                txtChange.Text = change.ToString();
            }
            else if (rdByTransfer.Checked == true || rdByMomo.Checked == true)
            {
                txtTotalPaid.ReadOnly = true;
                txtChange.ReadOnly = true;
                btnChange.Enabled = false;
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            CalculateChange();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            cbxCategories.SelectedIndex = -1;

            dgvBooks.Rows.Clear(); 

            string keyword = txtNameSearch.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập tên sách cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var books = CheckoutBL.GetBooksByName(keyword);

                foreach (var book in books)
                {
                    dgvBooks.Rows.Add(book.Bookid, book.Bookname, book.Price, book.Quantity);
                }

                dgvBooks.Columns["BookName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvBooks.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvBooks.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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
            cbxCategories.SelectedIndex = -1;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetFormDetail();
        }

        private void ResetFormDetail()
        {
            dgvDetails.Rows.Clear();

            txtTotalBill.Text = null; 
            txtTotalPaid.Text = null; 
            txtChange.Text = null;
            numericUpDownQuantity.Value = 1;
        }

        private void btnGenerateBill_Click(object sender, EventArgs e)
        {
            MessageBox.Show("MÌNH CHƯA CÓ LÀM: ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            SaveBill();
        }
        private void SaveBill()
        {
             
        }
        private void btnApply_Click(object sender, EventArgs e)
        {
            txtNameSearch.Text = String.Empty;
            LoadBooksByCate();
        }
    }
}