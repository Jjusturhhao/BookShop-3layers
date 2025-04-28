using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using PresentationLayer.UserControls;
using ZXing;



namespace PresentationLayer.UserControls
{
    public partial class InBill: UserControl
    {
        
        private CheckoutBL CheckoutBL;
      
        public InBill(string orderID, string cusname, string cusphone, double totalBill, string paymentMethod,
    List<(string bookName, int quantity, int price, int total)> books, string employeeName, DateTime orderDate, int change, int totalPaid)
        {
            //string orderID, string cusname, string cusphone, double totalAmount, string paymentMethod, List<(string bookName, int quantity, int price, int total)> books, string employeeName, DateTime orderDate, double amountPaid
            InitializeComponent();
            lblOrderID.Text = "Mã Đơn Hàng: " + orderID;
            lblEmployeeName.Text = "Nhân Viên: " + employeeName;
            lblCustomerName.Text = "Tên Khách hàng: " + cusname;
            lblCustomerPhone.Text = "Số điện thoại: " + cusphone;
            lblPaymentMethod.Text = "Phương thức thanh toán: " + paymentMethod;
            lblTotalAmount.Text = "Tổng tiền: " + totalBill.ToString("N0") + "đ";
            lblOrderDate.Text = "Ngày lập hóa đơn: " + orderDate.ToString("dd/MM/yyyy HH:mm:ss");
            
            if (paymentMethod != "Tiền mặt")
            {
                // Ẩn các trường nhập liệu liên quan đến tiền mặt nếu không phải thanh toán bằng tiền mặt
                lblAmountPaid.Visible = false;
                lblChange.Visible = false;
            }
            else
            {
                // Hiển thị các trường nhập liệu liên quan đến tiền mặt
                lblAmountPaid.Visible = true;
                lblChange.Visible = true;
                lblAmountPaid.Text = "Tiền khách trả: " + totalPaid.ToString("N0") + "đ";
            double changeAmount = totalPaid - totalBill;
            lblChange.Text = "Tiền thừa: " + (changeAmount > 0 ? changeAmount.ToString("N0") + "đ" : "0đ");
            }
            SetupDataGridView();
            PopulateBooks(books);
            GenerateBarcode(orderID);
        }

        private void GenerateBarcode(string orderID)
        {
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            barcodeWriter.Format = BarcodeFormat.CODE_128;  // Loại mã vạch (có thể thay đổi)
            barcodeWriter.Options = new ZXing.Common.EncodingOptions
            {
                Height = 50,  // Chiều cao của mã vạch
                Width = 20,    // Chiều rộng của mã vạch
                Margin = 0,
                PureBarcode = true
            };

            // Tạo hình ảnh mã vạch từ chuỗi mã hóa đơn
            var barcodeImage = barcodeWriter.Write(orderID);

            // Hiển thị mã vạch trong PictureBox

            picBarcode.Image = barcodeImage;
            
        }
        private void SetupDataGridView()
        {
            // Kiểm tra nếu chưa có cột nào thì thêm các cột
            if (dgvBook.Columns.Count == 0)
            {
                dgvBook.Columns.Add("index", "STT");
                dgvBook.Columns["index"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvBook.Columns["index"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvBook.Columns.Add("bookName", "Tên Sách");
                dgvBook.Columns["bookName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvBook.Columns["bookName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvBook.Columns.Add("quantity", "Số Lượng");
                dgvBook.Columns["quantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvBook.Columns["quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvBook.Columns.Add("price", "Đơn Giá");
                dgvBook.Columns["price"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvBook.Columns["price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvBook.Columns.Add("total", "Thành Tiền");
                dgvBook.Columns["total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvBook.Columns["total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvBook.ColumnHeadersDefaultCellStyle.Font = new Font(dgvBook.Font, FontStyle.Bold);
                dgvBook.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvBook.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
        }

        private void PopulateBooks(List<(string bookName, int quantity, int price, int total)> books)
        {
            dgvBook.Rows.Clear();  

            foreach (var book in books)
            {
                var row = new object[]
                {
                    dgvBook.Rows.Count + 1,  // Số thứ tự tự động
                    book.bookName,
                    book.quantity,
                    book.price.ToString("N0") + "đ",
                    book.total.ToString("N0") + "đ"
                };

                dgvBook.Rows.Add(row);
            }
        }


        private void text_Load(object sender, EventArgs e)
        {
      
            
            
        }

        private void lblCustomerPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
    }
}

