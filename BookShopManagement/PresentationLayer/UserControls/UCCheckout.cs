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
        private InfoBL infoBL;
        private OrderBL orderBL;
        private OrderDetailsBL orderDetailsBL;
        private StockBL stockBL;
        private BillBL billBL;
        private CustomerBL customerBL;
        private PaymentBL paymentBL;

        private string username;
        private Info info;
        private Panel selectedPanel = null;  // Biến lưu trữ panel của sách đã chọn
        
        private string selectedBookID = string.Empty; 
        private string selectedBookName = string.Empty; 
        private int selectedPrice = 0;

        public UCCheckout(string username)
        {
            InitializeComponent();
            CheckoutBL = new CheckoutBL();
            Load += UCCheckout_Load;

            infoBL = new InfoBL(); 
            orderBL = new OrderBL();
            orderDetailsBL = new OrderDetailsBL();
            stockBL = new StockBL();
            billBL = new BillBL();
            customerBL = new CustomerBL();
            paymentBL = new PaymentBL();
            this.username = username;
        }
        public void UCCheckout_Load(object sender, EventArgs e)
        {
            InitDgvBooks();
            LoadCategoriesToCBX();
            LoadBooks();
            LoadDetails();
            dgvBooks.CellClick += dgvBooks_CellClick; // Xử lý sự kiện nhấp chuột vào dòng sách
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
            dgvBooks.Rows.Clear(); 
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

            dgvDetails.Columns.Add("Mã sách", "Mã sách"); // Cột ẩn để lưu BookID
            dgvDetails.Columns["Mã sách"].Visible = false;  // Ẩn cột này đi
            
            dgvDetails.Columns.Add("Tên sách", "Tên sách");
            dgvDetails.Columns.Add("Số lượng", "Số lượng");
            dgvDetails.Columns.Add("Đơn giá", "Đơn giá");
            dgvDetails.Columns.Add("Thành tiền", "Thành tiền");

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            imageColumn.Width = 30;
            dgvDetails.Columns.Add(imageColumn);
            dgvDetails.Columns[dgvDetails.Columns.Count - 1].Name = "Xóa";

            dgvDetails.Columns["Số lượng"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
                if (dgvRow.Cells["Mã sách"].Value != null && dgvRow.Cells["Mã sách"].Value.ToString() == selectedBookID)
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

                newRow.Cells.Add(new DataGridViewTextBoxCell() { Value = selectedBookID });
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
            else if (rdByTransfer.Checked == true || rdByEWallet.Checked == true)
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
            //cbxCategories.SelectedIndex = -1;

            //dgvBooks.Rows.Clear(); 

            //string keyword = txtNameSearch.Text.Trim();

            //if (string.IsNullOrEmpty(keyword))
            //{
            //    MessageBox.Show("Vui lòng nhập tên sách cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //try
            //{
            //    var books = CheckoutBL.GetBooksByName(keyword);

            //    foreach (var book in books)
            //    {
            //        dgvBooks.Rows.Add(book.Bookid, book.Bookname, book.Price, book.Quantity);
            //    }


            //    dgvBooks.Columns["BookName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //    dgvBooks.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //    dgvBooks.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
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
       
        private void btnApply_Click(object sender, EventArgs e)
        {
            txtNameSearch.Text = String.Empty;
            LoadBooksByCate();
        }

        private void btnGenerateBill_Click(object sender, EventArgs e)
        {
            try
            {
                string cusname = txtCusName.Text.Trim();
                string cusphone = txtCusPhone.Text.Trim();

                if (string.IsNullOrEmpty(cusname) || string.IsNullOrEmpty(cusphone))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ tên và số điện thoại khách hàng.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Dừng lại, không tiếp tục thực hiện
                }

                // Kiểm tra xem khách hàng đã tồn tại trong bảng Customers chưa
                bool customerExists = customerBL.CheckCustomerExist(cusphone);
                if (!customerExists)
                {
                    customerBL.SaveCustomer(cusphone, cusname);
                }

                //Lấy StaffID
                info = infoBL.GetUserInfo(username);
                string staffID = info.User_ID;

                string staffName = info.Name;


                // Bước 1: Tạo Order_ID mới
                string orderID = orderBL.GenerateOrderID();

                // Bước 2: Lưu thông tin Order vào bảng Orders
                DateTime orderDate = DateTime.Now;
                string status = "Đã hoàn thành";

                orderBL.SaveOrder(orderID, cusphone, staffID, orderDate, status);

                // Bước 3: Lấy danh sách sản phẩm trong giỏ hàng và lưu chi tiết đơn hàng
                List<CartItem> cartItems = CheckoutBL.GetCartItemsFromDgv(dgvDetails);
                orderDetailsBL.SaveOrderDetails(orderID, cartItems);
                foreach (var item in cartItems)
                {
                    stockBL.ReduceStockQuantity(item.BookID, item.Quantity);
                }

                // Bước 4: Tạo hóa đơn và lưu vào bảng Bill_Generate
                string billID = billBL.GetBillID(orderID);
                billBL.CreateBill(billID, orderID);

                // Bước 5: Tạo phương thức thanh toán và lưu vào bảng Payments
                string paymentID = paymentBL.GetPaymentID();
                string paymentMethod = GetSelectedPaymentMethod();

                // 💥💥💥 THÊM SHOW FORM QR Ở ĐÂY:
                if (paymentMethod == "Chuyển khoản ngân hàng" || paymentMethod == "Ví điện tử")
                {
                    FormQR qrForm = new FormQR(paymentMethod);
                    qrForm.ShowDialog();

                    if (!qrForm.IsConfirmed)
                    {
                        MessageBox.Show("Bạn chưa xác nhận đã chuyển khoản. Đơn hàng chưa được tạo.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Không tiếp tục xử lý nữa
                    }
                }

                string transactionCode = GetTransactionCode(rdByCash.Checked, paymentID);
                DateTime? paymentDate = GetPaymentDate(rdByCash.Checked, transactionCode); //? kiểu nullable
                int totalCost = Convert.ToInt32(txtTotalBill.Text);
                paymentBL.AddPayment(paymentID, billID, cusphone, paymentMethod, transactionCode, paymentDate, totalCost);

                // Bước 6: Thông báo
                MessageBox.Show("Mua hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                List<(string bookName, int quantity, int price, int total)> books = new List<(string, int, int, int)>();

                foreach (DataGridViewRow row in dgvDetails.Rows)
                {
                    if (row.Cells["Tên sách"].Value != null &&
                        row.Cells["Số lượng"].Value != null &&
                        row.Cells["Đơn giá"].Value != null)
                    {
                        string bookName = row.Cells["Tên sách"].Value.ToString();
                        int quantity = Convert.ToInt32(row.Cells["Số lượng"].Value);
                        int price = Convert.ToInt32(row.Cells["Đơn giá"].Value);
                        int total = quantity * price;
                        books.Add((bookName, quantity, price, total));
                    }
                }

                //==

                int totalBill = 0;
                int totalPaid = 0;
                int change = 0;

                if (paymentMethod == "Tiền mặt")
                {
                    // Kiểm tra nếu totalBill và totalPaid là số hợp lệ
                    if (int.TryParse(txtTotalBill.Text, out totalBill) && int.TryParse(txtTotalPaid.Text, out totalPaid))
                    {
                        // Tính tiền thừa
                        change = CalculateChange(totalBill, totalPaid);
                        UCPrintBill inBill = new UCPrintBill(orderID, cusname, cusphone, totalBill, paymentMethod,
                                                       books, staffName, orderDate, change, totalPaid);
                        ShowUserControl(inBill);
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập đúng số tiền");
                    }
                }
                else
                {
                    // Nếu không phải thanh toán bằng tiền mặt, bỏ qua phần nhập liệu
                    totalBill = 0;  // Giá trị mặc định nếu không cần thiết
                    totalPaid = 0;  // Giá trị mặc định nếu không cần thiết
                    change = 0;     // Không cần tính tiền thừa

                    // Tạo đối tượng UCInBill mà không cần các giá trị tiền thừa
                    UCPrintBill inBill = new UCPrintBill(orderID, cusname, cusphone, totalCost, paymentMethod,
                                                   books, staffName, orderDate, change, totalPaid);
                    ShowUserControl(inBill);
                }
                // Bước 7: Load lại FORM
                LoadAfterCheckout();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        public void LoadAfterCheckout()
        {
            LoadBooks();
            LoadDetails();
            txtCusName.Clear();
            txtCusPhone.Clear();
            txtTotalBill.Clear();
            txtTotalPaid.Clear();
            txtChange.Clear();
            rdByCash.Checked = true;
        }
        private string GetSelectedPaymentMethod()
        {
            if (rdByCash.Checked) return "Tiền mặt";
            if (rdByTransfer.Checked) return "Chuyển khoản ngân hàng";
            if (rdByCard.Checked) return "Thẻ ghi nợ";
            if (rdByEWallet.Checked) return "Ví điện tử";
            return "Không xác định";
        }
        private string GetTransactionCode(bool isCash, string paymentID)
        {
            if (isCash)
                return null;
            else
                return paymentBL.GetTransactionCode(paymentID); 
        }
        private DateTime? GetPaymentDate(bool isCash, string transactionCode)
        {
            if (isCash || !string.IsNullOrEmpty(transactionCode))
            {
                return DateTime.Now;
            }
            return null;
        }
        private void UpdatePaymentControls()
        {
            bool isCash = rdByCash.Checked;

            txtTotalPaid.Enabled = isCash;
            txtChange.Enabled = isCash;
            btnChange.Enabled = isCash;

            if (!isCash)
            {
                txtTotalPaid.Text = "";
                txtChange.Text = "";
            }
        }

        private void rdByCash_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePaymentControls();
        }

        private void rdByTransfer_CheckedChanged(object sender, EventArgs e)
        {
            //if (rdByTransfer.Checked)
            //{
            //    FormQR formQR = new FormQR("Chuyển khoản");
            //    formQR.ShowDialog();
            //}
            UpdatePaymentControls();
        }

        private void rdByEWallet_CheckedChanged(object sender, EventArgs e)
        {
            //if (rdByEWallet.Checked)
            //{
            //    FormQR formQR = new FormQR("Ví điện tử");
            //    formQR.ShowDialog();
            //}
            UpdatePaymentControls();
        }

        private void rdByCard_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePaymentControls();
        }

        private void txtNameSearch_TextChanged(object sender, EventArgs e)
        {
            cbxCategories.SelectedIndex = -1;
            dgvBooks.Rows.Clear();

            string keyword = txtNameSearch.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
                return; // không cần tìm khi chưa nhập gì

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
        public void ShowUserControl(UserControl userControl)
        {
            this.Controls.Clear();
            userControl.Dock = DockStyle.Fill;
            this.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private int CalculateChange(int totalBill, int totalPaid)
        {
            if (totalPaid < totalBill)
            {
                MessageBox.Show("Số tiền khách đưa chưa đủ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;  // Nếu tiền khách trả chưa đủ, trả lại 0
            }
            return totalPaid - totalBill;  // Trả về tiền thừa
        }

        private void dgvDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvDetails.Columns["Xóa"].Index && e.RowIndex >= 0)
            {
                // Kiểm tra nếu không phải dòng mới
                if (!dgvDetails.Rows[e.RowIndex].IsNewRow)
                {
                    if (MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        dgvDetails.Rows.RemoveAt(e.RowIndex);
                        UpdateTotalBill();
                    }
                }
            }
        }
    }
}