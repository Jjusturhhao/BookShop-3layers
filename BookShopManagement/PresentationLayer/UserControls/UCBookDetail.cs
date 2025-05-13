using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TransferObject;
using System.Windows.Forms;

namespace PresentationLayer.UserControls
{
    public partial class UCBookDetail : UserControl
    {
        private Book book;
        private UCCart ucCart;
        private BookBL bookBL;
        private CartBL cartBL;

        public Action OnBuyClick { get; set; }
        public Action OnBackClick { get; set; }

        public UCBookDetail(string bookID, UCCart ucCart, CartBL cartBL)
        {
            InitializeComponent();
            bookBL = new BookBL();
            book = bookBL.GetBookByID(bookID);
            this.cartBL = cartBL;
            this.ucCart = ucCart;

            LoadBookDetails();
        }
        private void LoadBookDetails()
        {
            if (book != null)
            {
                // Hiển thị thông tin cơ bản
                lbName.Text = book.Bookname;
                lbAuthor.Text = "Tác giả: " + book.Author;
                lbCategory.Text = "Thể loại: " + book.Categoryname;
                lbQuantity.Text = "Số lượng còn: " + book.Quantity; 
                lbPrice.Text = book.Price.ToString("#,##0") + " đ";

                // Hiển thị ảnh bìa sách
                try
                {
                    string imageFileName = book.Bookimage;
                    string imagePath = Path.Combine(Application.StartupPath, @"..\..\BookImage", imageFileName);
                    try
                    {
                        pictureBoxImage.Image = Image.FromFile(imagePath);
                    }
                    catch
                    {
                        pictureBoxImage.Image = Properties.Resources.bookdefault;
                    }
                }
                catch
                {
                    pictureBoxImage.Image = Properties.Resources.bookdefault;
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin sách.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddCart_Click(object sender, EventArgs e)
        {
            string bookID = book.Bookid;
            cartBL.AddToCart(bookID);

            if (ucCart == null)
            {
                MessageBox.Show("Giỏ hàng chưa được truyền từ Homepage.");
            }
            else
            {
                ucCart.LoadCartItems();
            }
            MessageBox.Show("Sản phẩm đã được thêm vào giỏ hàng của bạn!");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            OnBackClick?.Invoke();
        }
    }
}
