using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using BusinessLayer;
using TransferObject;

namespace PresentationLayer.UserControls
{
    public partial class UCHomepage : UserControl
    {
        private int currentPage = 1;
        private int pageSize = 8;
        private HomepageBL homepageBL;
        private string currentCategoryID = null;
        private UCCart ucCart;
        private CartBL cartBL;

        public UCHomepage(UCCart cart)
        {
            InitializeComponent();
            homepageBL = new HomepageBL();
            cartBL = new CartBL();
            ucCart = cart;
            Load += UCHomepage_Load;
        }

        private void UCHomepage_Load(object sender, EventArgs e)
        {
            LoadBooks(currentPage, currentCategoryID);
        }

        public void LoadBooks(int pageNumber, string categoryID)
        {
            DataTable books = string.IsNullOrEmpty(categoryID)
                ? homepageBL.GetBooks(pageNumber, pageSize)
                : homepageBL.GetBooksByCategory(pageNumber, pageSize, categoryID);

            flowLayoutPanelBooks.Controls.Clear();

            int screenWidth = this.flowLayoutPanelBooks.Width;
            int screenHeight = this.flowLayoutPanelBooks.Height;
            int panelWidth = screenWidth / 4 - 30;
            int panelHeight = screenHeight / 2 - 30;

            foreach (DataRow row in books.Rows)
            {
                Panel panel = new Panel()
                {
                    Width = panelWidth,
                    Height = panelHeight + 80,
                    Margin = new Padding(10)
                };

                PictureBox pictureBox = new PictureBox()
                {
                    Width = panelWidth - 20,
                    Height = panelHeight - 50,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Cursor = Cursors.Hand
                };

                string imageUrl = row["BookImage"].ToString();
                try
                {
                    using (WebClient webClient = new WebClient())
                    {
                        byte[] imageBytes = webClient.DownloadData(imageUrl);
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            pictureBox.Image = Image.FromStream(ms);
                        }
                    }
                }
                catch
                {
                    pictureBox.Image = Properties.Resources.bookdefault;
                }

                Label lblName = new Label()
                {
                    Text = row["BookName"].ToString(),
                    AutoSize = false,
                    Width = panelWidth - 20,
                    Height = 40,
                    Font = new Font("Arial", 12),
                    TextAlign = ContentAlignment.TopLeft
                };

                Label lblPrice = new Label()
                {
                    Text = Convert.ToDecimal(row["Price"]).ToString("#,##0") + " đ",
                    AutoSize = false,
                    Width = panelWidth - 20,
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    ForeColor = Color.DarkRed,
                    TextAlign = ContentAlignment.MiddleLeft
                };

                Button btnBuy = new Button()
                {
                    Text = "Thêm vào giỏ",
                    Width = panelWidth - 20,
                    Height = 40,
                    Font = new Font("Arial", 13),
                    BackColor = Color.LightSeaGreen,
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat
                };
                btnBuy.Click += (s, e) =>
                {
                    string bookID = row["BookID"].ToString();
                    
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
                };

                pictureBox.Click += (s, e) =>
                {
                    BookDetail bookDetail = new BookDetail();
                    bookDetail.Show();
                };

                panel.Controls.Add(pictureBox);
                panel.Controls.Add(lblName);
                panel.Controls.Add(lblPrice);
                panel.Controls.Add(btnBuy);

                pictureBox.Location = new Point(10, 10);
                lblName.Location = new Point(10, pictureBox.Bottom + 10);
                lblPrice.Location = new Point(10, lblName.Bottom + 5);
                btnBuy.Location = new Point(10, lblPrice.Bottom + 5);

                flowLayoutPanelBooks.Controls.Add(panel);
            }

            lbPage.Text = pageNumber.ToString();
            int totalRecords = homepageBL.GetTotalRecords(categoryID);
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            LoadPaginationControls(totalRecords, totalPages);
        }

        private void LoadPaginationControls(int totalRecords, int totalPages)
        {
            btnNext.Enabled = currentPage < totalPages;
            btnPrevious.Enabled = currentPage > 1;

            btnPrevious.Click += (s, e) =>
            {
                if (currentPage > 1)
                {
                    currentPage--;
                    LoadBooks(currentPage, currentCategoryID);
                }
            };

            btnNext.Click += (s, e) =>
            {
                if (currentPage < totalPages)
                {
                    currentPage++;
                    LoadBooks(currentPage, currentCategoryID);
                }
            };
        }
        private void AddToCart(string BookID)
        {

        }
    }
}
