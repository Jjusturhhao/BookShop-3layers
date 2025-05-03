using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using TransferObject;
using PresentationLayer;
using System.CodeDom.Compiler;
using System.Drawing.Imaging;


namespace PresentationLayer.UserControls
{
    public partial class UCBook : UserControl
    {
        private BookBL bookBL;
        private CategoryBL categoryBL;
        public UCBook()
        {
            InitializeComponent();
            bookBL = new BookBL();
            categoryBL = new CategoryBL();
            LoadCategoriesToComboBox();
        }

        public void LoadCategoriesToComboBox()
        {
            try
            {
                cbxCategory.DataSource = categoryBL.GetAllCategories();
                cbxCategory.DisplayMember = "CategoryName";
                cbxCategory.ValueMember = "CategoryID";

                cbxCategory.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load ComboBox: " + ex.Message);
            }
        }
     
        private void UCBook_Load(object sender, EventArgs e)
        {
            try
            {
                LoadCategoriesToComboBox(); // Tải lại ComboBox khi form được mở lại
                dgvBook.DataSource = bookBL.GetBooks(); // Cập nhật DataGridView
                //LoadBooksToDataGridView();
                //if (dgvBook.Columns.Contains("IsVisible"))
                //{
                //    dgvBook.Columns["IsVisible"].Visible = false;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdateBook_Click(object sender, EventArgs e)
        {
            string Bookid = txtBookID.Text;
            string Bookname = txtBookName.Text;
            string Categoryid = cbxCategory.SelectedValue?.ToString();
            string Author = txtAuthor.Text;
            string Bookimage = picBook.Tag?.ToString() ?? "";
            string Note = txtNote.Text;


            // ✅ Kiểm tra thông tin bắt buộc trước khi cho phép hiển thị
            if (ckbShowBook.Checked)
            {
                if (string.IsNullOrWhiteSpace(Bookname) ||
                    string.IsNullOrWhiteSpace(Author) ||
                    string.IsNullOrWhiteSpace(Categoryid))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ Tên sách, Thể loại, Tác giả và Giá trước khi hiển thị sách!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ckbShowBook.Checked = false;
                    return; // ⛔ Không cập nhật nếu thiếu thông tin
                }
            }
            // ✅ Kiểm tra Price trước khi chuyển đổi
            if (!int.TryParse(txtPrice.Text, out int Price) || Price <= 0)
            {
                MessageBox.Show("Giá sách phải là số nguyên dương!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            bool isVisible = ckbShowBook.Checked;

            Book book = new Book(Bookid, Bookname, Categoryid, Author, Price, Bookimage, Note)
            {
                IsVisible = isVisible
            };

            try
            {
                bookBL.Update(book);
                dgvBook.DataSource = bookBL.GetBooks();
                MessageBox.Show("Cập nhật thành công!");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi SQL: " + ex.Message);
            }
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            if (!string.IsNullOrEmpty(keyword))
            {
                dgvBook.DataSource = bookBL.SearchBook(keyword);
            }
            else
            {
                dgvBook.DataSource = bookBL.GetBooks();
            }
        }

        private void dgvBook_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0) // Đảm bảo không bấm vào tiêu đề cột
            {
                // Kiểm tra nếu dòng có dữ liệu (không phải là dòng trống)
                if (dgvBook.Rows.Count > e.RowIndex && dgvBook.Rows[e.RowIndex].Cells["BookID"].Value != null)
                {
                    DataGridViewRow row = dgvBook.Rows[e.RowIndex];
                    txtBookID.Text = row.Cells["BookID"].Value?.ToString();
                    txtBookName.Text = row.Cells["BookName"].Value?.ToString();
                    cbxCategory.Text = row.Cells["CategoryID"].Value?.ToString();
                    txtAuthor.Text = row.Cells["Author"].Value?.ToString();
                    txtPrice.Text = row.Cells["Price"].Value?.ToString();
                    txtNote.Text = row.Cells["Note"].Value?.ToString() ?? "";

                    // Hiển thị trạng thái checkbox nếu có cột IsVisible
                    if (row.Cells["IsVisible"].Value != null && row.Cells["IsVisible"].Value != DBNull.Value)
                    {
                        bool isVisible = Convert.ToBoolean(row.Cells["IsVisible"].Value);
                        ckbShowBook.Checked = isVisible;
                    }
                    else
                    {
                        ckbShowBook.Checked = false;
                    }

                    if (row.Cells["BookImage"] != null && row.Cells["BookImage"].Value != null)
                    {
                        string imagePath = row.Cells["BookImage"].Value.ToString();
                        if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                        {
                            picBook.ImageLocation = imagePath;
                        }
                        else
                        {
                            picBook.Image = Properties.Resources.bookdefault; // hoặc null nếu muốn xóa hình
                        }
                        picBook.SizeMode = PictureBoxSizeMode.Zoom;

                    }

                }
            }
        }

        private void btnUpload_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                picBook.Image = Image.FromFile(openFileDialog.FileName);
                picBook.Tag = openFileDialog.FileName;  // Lưu đường dẫn hình vào Tag
            }
        }
        private void dgvBook_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvBook.Columns[e.ColumnIndex].Name == "BookImage" && e.Value != null)
            {
                string imagePath = e.Value.ToString(); // Đường dẫn hoặc tên file hình ảnh
                if (File.Exists(imagePath)) // Kiểm tra xem file có tồn tại không
                {
                    e.Value = Image.FromFile(imagePath); // Chuyển đổi thành Image
                }
                else
                {
                    e.Value = Image.FromFile("default_image.jpg"); // Hiển thị hình mặc định nếu không có hình ảnh
                }
            }
        }
    }
}