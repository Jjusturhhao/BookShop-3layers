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
            LoadBooks();
            LoadDetails();
        }
        private void btnCustomer_Click(object sender, EventArgs e)
        {

        }
        
        private void LoadBooks()
        {
            DataTable books = CheckoutBL.GetBooks();

            flowLayoutPanelBooks.Controls.Clear();

            int panelWidth = this.flowLayoutPanelBooks.Width / 3 - 10;
            int panelHeight = this.flowLayoutPanelBooks.Height / 2 - 10;

            foreach (DataRow row in books.Rows)
            {
                string bookID = row["BookID"].ToString();
                string bookName = row["BookName"].ToString();
                int price = Convert.ToInt32(row["Price"]);
                int quantity = CheckoutBL.GetQuantity(bookID);
                string imageUrl = row["BookImage"].ToString();

                Panel panel = new Panel()
                {
                    Width = panelWidth,
                    Height = panelHeight,
                    Margin = new Padding(10),
                    BorderStyle = BorderStyle.None
                };

                PictureBox pictureBox = new PictureBox()
                {
                    Width = panelWidth - 10,
                    Height = panelHeight - 80,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Cursor = Cursors.Hand
                };

                pictureBox.Load(imageUrl);

                Label lblName = new Label()
                {
                    Text = row["BookName"].ToString(),
                    AutoSize = false,
                    Width = panelWidth - 10,
                    Height = 20,
                    Font = new Font("Arial", 10, FontStyle.Regular),
                    TextAlign = ContentAlignment.TopLeft

                };

                Label lblPrice = new Label()
                {
                    Text = Convert.ToDecimal(row["Price"]).ToString("#,##0") + " đ",
                    AutoSize = false,
                    Width = panelWidth - 10,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    ForeColor = Color.DarkRed,
                    TextAlign = ContentAlignment.MiddleLeft
                };

                Label lblQuantity = new Label()
                {
                    Text = $"Số lượng tồn: {quantity}",
                    AutoSize = false,
                    Width = panelWidth - 10,
                    Font = new Font("Arial", 10, FontStyle.Regular),
                    TextAlign = ContentAlignment.MiddleLeft
                };

                pictureBox.Click += (s, e) =>
                {
                    // Khoanh lại sách đã chọn
                    HighlightSelectedBook(panel, pictureBox, bookID, bookName, price);
                };

                panel.Controls.Add(pictureBox);
                panel.Controls.Add(lblName);
                panel.Controls.Add(lblPrice);
                panel.Controls.Add(lblQuantity);

                pictureBox.Location = new Point(10, 0);
                lblName.Location = new Point(10, pictureBox.Bottom + 5);
                lblPrice.Location = new Point(10, lblName.Bottom);
                lblQuantity.Location = new Point(10, lblPrice.Bottom);

                flowLayoutPanelBooks.Controls.Add(panel);
            }
        }
        private void HighlightSelectedBook(Panel panel, PictureBox pictureBox, string bookID, string bookName, int price)
        {
            // Nếu đã có sách được chọn, bỏ khoanh sách đó
            if (selectedPanel != null)
            {
                selectedPanel.BorderStyle = BorderStyle.None;
            }

            // Cập nhật sách đã chọn
            selectedPanel = panel;
            selectedBookID = bookID;
            selectedBookName = bookName;
            selectedPrice = price;

            // Thêm viền cho panel và pictureBox để khoanh lại sách đã chọn
            selectedPanel.BorderStyle = BorderStyle.FixedSingle; // Thêm viền cho panel

            // Nếu có NumericUpDown, bạn có thể tự động cập nhật số lượng theo sách đã chọn
            UpdateQuantitySelector(bookID);
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
            //dgvDetails.Columns.Clear(); 
            dgvDetails.Columns.Add("Tên sách", "Tên sách");
            dgvDetails.Columns.Add("Số lượng", "Số lượng");
            dgvDetails.Columns.Add("Đơn giá", "Đơn giá");
            dgvDetails.Columns.Add("Thành tiền", "Thành tiền");
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
    }
}