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
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            AddCategory addCategory = new AddCategory();
            if (addCategory.ShowDialog() == DialogResult.OK)
            {
                LoadCategoriesToComboBox();
            }
        }
        private void UCBook_Load(object sender, EventArgs e)
        {
            try
            {
                LoadCategoriesToComboBox(); // Tải lại ComboBox khi form được mở lại
                dgvBook.DataSource = bookBL.GetBooks(); // Cập nhật DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
         
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Book emptyBook = bookBL.ResetBook();
            LoadCategoriesToComboBox();
            txtBookID.Text = bookBL.GenerateNextBookID(); // ID mới
            txtBookID.ReadOnly = true;

            txtBookName.Text = emptyBook.Bookname;
            cbxCategory.SelectedIndex = -1;
            txtAuthor.Text = emptyBook.Author;

            txtPrice.Text = emptyBook.Price.ToString();
            picBook.Image = null;

            txtBookName.Focus();
            LoadBooksToDataGridView();

        }
        private void LoadBooksToDataGridView()
        {
            dgvBook.DataSource = bookBL.GetBooks(); // lấy danh sách từ DB
        }
        private void btnEntryBook_Click(object sender, EventArgs e)
        {
            string BookID = txtBookID.Text.Trim();
            string BookName = txtBookName.Text.Trim();
            string CategoryID = cbxCategory.SelectedValue?.ToString();

            string Author = txtAuthor.Text.Trim();
            string Bookimage = picBook.ImageLocation ?? ""; // lấy đường dẫn ảnh

            if (string.IsNullOrEmpty(BookID) || string.IsNullOrEmpty(BookName) || string.IsNullOrEmpty(CategoryID) || string.IsNullOrEmpty(Author))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtPrice.Text.Trim(), out int price))
            {
                MessageBox.Show("Giá sách không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Book book = new Book(BookID, BookName, CategoryID, Author, price, Bookimage);

            try
            {
                bookBL.Add(book); // gọi phương thức thêm từ BusinessLayer
                MessageBox.Show("Đã thêm sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvBook.DataSource = bookBL.GetBooks(); // load lại danh sách
                LoadCategoriesToComboBox(); // Tải lại danh mục
                btnRefresh.PerformClick(); // reset form
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Lỗi trùng khóa chính (BookID)
                {
                    MessageBox.Show("Mã sách đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Lỗi cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        
        
       
        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn Ảnh";
            openFileDialog.Filter = "Image Files(*.gif;*.jpg;*.jpeg;*.bmp;*.wmf;*.png)|*.gif;*.jpg;*.jpeg;*.bmp;*.wmf;png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                picBook.ImageLocation = openFileDialog.FileName;
            }
        }

        private void btnDeleteBook_Click_1(object sender, EventArgs e)
        {
            string BookID, BookName, CategoryID, Author;
            int Price;

            // Lấy giá trị từ các TextBox và ComboBox
            BookID = txtBookID.Text;
            CategoryID = cbxCategory.SelectedValue?.ToString();
            BookName = txtBookName.Text;
            Author = txtAuthor.Text;
            Price = !int.TryParse(txtPrice.Text, out Price) ? 0 : Price;


            // Nếu không có trong đơn hàng, tiến hành xóa sách trong kho và danh sách sách
            Book book = new Book(BookID, BookName, CategoryID, Author, Price, string.Empty);  // Không cần BookImage khi xóa
            try
            {
                // Xóa sách trong Stock
                bookBL.Delete(book);

                // Cập nhật lại DataGrid
                LoadCategoriesToComboBox();  // Đảm bảo cập nhật ComboBox
                dgvBook.DataSource = bookBL.GetBooks();
                // Thông báo xóa thành công
                MessageBox.Show("Đã xóa sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset form hoặc các điều khiển khác nếu cần
                btnRefresh.PerformClick();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi khi xóa sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateBook_Click(object sender, EventArgs e)
        {
            string Bookid, Bookname, Categoryid, Author, Bookimage;
            int price;
            Bookid = txtBookID.Text;
            Bookname = txtBookName.Text;

            Categoryid = cbxCategory.SelectedValue?.ToString();
            Author = txtAuthor.Text;
            price = Convert.ToInt32(txtPrice.Text);
            Bookimage = btnUpload.Text;
            Book book = new Book(Bookid, Bookname, Categoryid, Author, price, Bookimage);
            try
            {
                bookBL.Update(book);
                LoadCategoriesToComboBox();  // Đảm bảo cập nhật ComboBox
                dgvBook.DataSource = bookBL.GetBooks();
                btnRefresh.PerformClick();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvBook_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
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
                DataGridViewRow row = dgvBook.Rows[e.RowIndex];
                txtBookID.Text = row.Cells["BookID"].Value?.ToString();
                txtBookName.Text = row.Cells["BookName"].Value?.ToString();
                //cbxCategory.SelectedValue = row.Cells["CategoryID"].Value?.ToString();
                cbxCategory.Text = row.Cells["CategoryID"].Value?.ToString();
                txtAuthor.Text = row.Cells["Author"].Value?.ToString();
                txtPrice.Text = row.Cells["Price"].Value?.ToString();
            }
        }
    }
}
