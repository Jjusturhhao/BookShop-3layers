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
        public UCBook()
        {
            InitializeComponent();
            bookBL = new BookBL();

        }

        private void LoadCategoriesToComboBox()
        {
            try
            {
                // Load danh sách Category
                cbxCategory.DataSource = bookBL.GetBookCategories();
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

            dgvBook.DataSource = bookBL.GetBooks();
            try
            {
                LoadCategoriesToComboBox(); // Gọi hàm load dữ liệu cho ComboBox

                if (dgvBook.Columns.Contains("BookImage"))
                {
                    DataGridViewImageColumn imgCol = (DataGridViewImageColumn)dgvBook.Columns["BookImage"];
                    imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    //dgvBook.CellFormatting += dgvBook_CellFormatting;
                }

                dgvBook.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            TransferObject.Book emptyBook = bookBL.ResetBook();
            txtBookID.Text = bookBL.GenerateNextBookID(); // ID mới
            txtBookID.ReadOnly = true;

            txtBookName.Text = emptyBook.Bookname;
            cbxCategory.SelectedIndex = -1;
            txtAuthor.Text = emptyBook.Author;

            txtPrice.Text = emptyBook.Price.ToString();
            picBook.Image = null;

            txtBookName.Focus();

        }
        private void btnEntryBook_Click(object sender, EventArgs e)
        {
            string BookID, BookName, CategoryID, Author, Bookimage;
            int price;
            BookID = txtBookID.Text;
            BookName = txtBookName.Text;
            CategoryID = cbxCategory.SelectedItem?.ToString();
            Author = txtAuthor.Text;
            Bookimage = picBook.ToString();
            if (!int.TryParse(txtPrice.Text.Trim(), out price))
            {
                MessageBox.Show("Giá sách không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            TransferObject.Book book = new TransferObject.Book(BookID, BookName, CategoryID, Author, price, Bookimage);
            try
            {
                bookBL.Add(book);
                MessageBox.Show("Đã thêm sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvBook.DataSource = bookBL.GetBooks();
                btnRefresh.PerformClick();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Sách đã tồn tại", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void dgvBook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo không bấm vào tiêu đề cột
            {
                DataGridViewRow row = dgvBook.Rows[e.RowIndex];
                txtBookID.Text = row.Cells["BookID"].Value?.ToString();
                txtBookName.Text = row.Cells["BookName"].Value?.ToString();
                cbxCategory.Text = row.Cells["CategoryID"].Value?.ToString();
                txtAuthor.Text = row.Cells["Author"].Value?.ToString();
                txtPrice.Text = row.Cells["Price"].Value?.ToString();
            }
        }
        private void btnDeleteBook_Click(object sender, EventArgs e)
        {
            string Bookid = txtBookID.Text;
            string Bookname = txtBookName.Text;
            string Categoryid = cbxCategory.SelectedValue?.ToString();
            string Author = txtAuthor.Text;
            int Price;
            string Bookimage = btnUpload.Text;
            if (!int.TryParse(txtPrice.Text, out Price))
            {
                MessageBox.Show("Giá không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Book book = new Book(Bookid, Bookname, Categoryid, Author, Price, Bookimage);
            TransferObject.Book book = new TransferObject.Book(Bookid, Bookname, Categoryid, Author, Price, Bookimage);

            try
            {
                bookBL.Delete(book);
                MessageBox.Show("Đã xóa sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgvBook.DataSource = bookBL.GetBooks();
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
            TransferObject.Book book = new TransferObject.Book(Bookid, Bookname, Categoryid, Author, price, Bookimage);
            try
            {
                bookBL.Update(book);
                dgvBook.DataSource = bookBL.GetBooks();
                btnRefresh.PerformClick();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
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

       
    }
}
