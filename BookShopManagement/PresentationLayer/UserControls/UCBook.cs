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
using static Guna.UI2.Native.WinApi;
using PresentationLayer;


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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (dgvBook.Columns.Contains("Bookimage"))
            {
                DataGridViewImageColumn imgCol = (DataGridViewImageColumn)dgvBook.Columns["Bookimage"];
                imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;

            }
            dgvBook.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
          
        }

        private void button1_Click(object sender, EventArgs e)
        {

            TransferObject.Book emptyBook = bookBL.GetEmptyBook();
            
            txtBookID.Text = bookBL.GenerateNextBookID(); // ID mới
            txtBookID.ReadOnly = true;

            txtBookName.Text = emptyBook.Bookname;
            cbxCategory.SelectedIndex = -1;
            txtAuthor.Text = emptyBook.Author;
            cbxSupplier.SelectedIndex = -1;
            txtPrice.Text = emptyBook.Price;
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
    }
}
