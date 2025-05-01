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
                //LoadBooksToDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Book emptyBook = bookBL.ResetBook();

            
                picBook.Image = Properties.Resources.bookdefault; // Đặt hình mặc định nếu không có hình
            
            picBook.SizeMode = PictureBoxSizeMode.Zoom;
            LoadCategoriesToComboBox();
            txtBookID.Text = bookBL.GenerateNextBookID(); // ID mới
            txtBookID.ReadOnly = true;

            txtBookName.Text = emptyBook.Bookname;
            cbxCategory.SelectedIndex = -1;
            txtAuthor.Text = emptyBook.Author;

            txtPrice.Text = emptyBook.Price.ToString();
            

            txtBookName.Focus();
            dgvBook.DataSource = bookBL.GetBooks(); // load lại danh sách


        }
       
        private void btnEntryBook_Click(object sender, EventArgs e)
        {
           
            string BookID = txtBookID.Text.Trim();
            string BookName = txtBookName.Text.Trim();
            string CategoryID = cbxCategory.SelectedValue?.ToString();
            string Author = txtAuthor.Text.Trim();

            // Lưu tên file hoặc đường dẫn hình ảnh từ PictureBox
            string Bookimage = picBook.Tag?.ToString() ?? ""; // Nếu không có hình ảnh, sử dụng hình mặc định
            

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

            // Tạo đối tượng Book mới
            Book book = new Book(BookID, BookName, CategoryID, Author, price, Bookimage);

            try
            {
                // Gọi phương thức Add để thêm sách vào cơ sở dữ liệu
                bookBL.Add(book);
                MessageBox.Show("Đã thêm sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cập nhật lại danh sách sách
                dgvBook.DataSource = bookBL.GetBooks();

                LoadCategoriesToComboBox(); // Tải lại danh mục
                

                // Reset form để chuẩn bị thêm sách mới
                btnRefresh.PerformClick();


            }
            catch (SqlException ex)
            {
                // Xử lý lỗi SQL: Lỗi trùng mã sách
                if (ex.Number == 2627)
                {
                    MessageBox.Show("Mã sách đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Lỗi cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            Bookimage = picBook.Tag?.ToString() ?? "";


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
                // Kiểm tra nếu dòng có dữ liệu (không phải là dòng trống)
                if (dgvBook.Rows.Count > e.RowIndex && dgvBook.Rows[e.RowIndex].Cells["BookID"].Value != null)
                {
                    DataGridViewRow row = dgvBook.Rows[e.RowIndex];
                    txtBookID.Text = row.Cells["BookID"].Value?.ToString();
                    txtBookName.Text = row.Cells["BookName"].Value?.ToString();
                    cbxCategory.Text = row.Cells["CategoryID"].Value?.ToString();
                    txtAuthor.Text = row.Cells["Author"].Value?.ToString();
                    txtPrice.Text = row.Cells["Price"].Value?.ToString();
                    
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

        
        private void dgvBook_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void btnUpload_Click_1(object sender, EventArgs e)
        {

            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;";
            //if (openFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    // Gán đường dẫn hình ảnh vào Tag và hiển thị hình ảnh
            //    picBook.Tag = openFileDialog.FileName;
            //    picBook.Image = Image.FromFile(picBook.Tag.ToString());
            //}
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


