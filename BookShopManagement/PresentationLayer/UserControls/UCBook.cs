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

        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            AddCategory addCategory = new AddCategory();
            if (addCategory.ShowDialog() == DialogResult.OK) 
            {
                //Sau khi thêm xong thì reload combobox
                LoadCategoriesToComboBox();
            }
        }

        private void dgvBook_Click(object sender, EventArgs e)
        {
            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UCBook_Load(object sender, EventArgs e)
        {
            try
            {
                dgvBook.DataSource = bookBL.GetBooks();

                if (dgvBook.Columns.Contains("Bookimage"))
                {
                    DataGridViewImageColumn imgCol = (DataGridViewImageColumn)dgvBook.Columns["Bookimage"];
                    imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;

                    // Xử lý hiển thị hình ảnh an toàn
                    dgvBook.CellFormatting += dgvBook_CellFormatting;
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

            TransferObject.Book emptyBook = bookBL.GetEmptyBook();
            
            txtBookID.Text = bookBL.GenerateNextBookID(); // ID mới
            txtBookID.ReadOnly = true;

            txtBookName.Text = emptyBook.Bookname;
            cbxCategory.SelectedIndex = -1;
            txtAuthor.Text = emptyBook.Author;
            cbxSupplier.SelectedIndex = -1;
            txtPrice.Text = emptyBook.Price.ToString();
            picBook.Image = null;

            txtBookName.Focus();

        }

        private void btnEntryBook_Click(object sender, EventArgs e)
        {
            string BookID, picBook, BookName, Category, Author, Supplier, Price;
            BookID = txtBookID.Text;
            BookName = txtBookName.Text;
            Category = cbxCategory.SelectedItem?.ToString(); 
            Supplier = cbxSupplier.SelectedItem?.ToString();  
            Price = txtPrice.Text;

        }

        private void dgvBook_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Kiểm tra nếu là cột hình ảnh và giá trị không null
            if (dgvBook.Columns[e.ColumnIndex].Name == "Bookimage" && e.Value != null)
            {
                try
                {
                    // Nếu e.Value là byte array
                    if (e.Value is byte[] imageData)
                    {
                        if (imageData.Length > 0)
                        {
                            try
                            {
                                using (MemoryStream ms = new MemoryStream(imageData))
                                {
                                    // Kiểm tra tính hợp lệ của hình ảnh trước khi chuyển đổi
                                    System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
                                    e.Value = img;
                                }
                            }
                            catch
                            {
                                // Nếu không thể tạo hình ảnh, hiển thị hình ảnh mặc định
                                e.Value = Properties.Resources.bookdefault;
                            }
                        }
                        else
                        {
                            e.Value = Properties.Resources.bookdefault;
                        }
                    }
                }
                catch
                {
                    e.Value = Properties.Resources.bookdefault;
                }
            }
        }
    }
}
