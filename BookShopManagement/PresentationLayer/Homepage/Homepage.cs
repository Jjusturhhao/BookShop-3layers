using BusinessLayer;
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

namespace PresentationLayer
{
    public partial class Homepage : Form
    {
        private int currentPage = 1;
        private int pageSize = 8;
        private HomepageBL HomepageBL;
        private string currentCategoryID = null;

        public Homepage()
        {
            InitializeComponent();
            HomepageBL = new HomepageBL();
        }

        private void Homepage_Load(object sender, EventArgs e)
        {
            LoadButtons();
            LoadBooks(currentPage, currentCategoryID);
        }
        private void LoadButtons()
        {
            DataTable categories = HomepageBL.GetCategories();

            Button btnAll = new Button()
            {
                Text = "Tất cả",
                AutoSize = true,
                Font = new Font("Arial", 13, FontStyle.Bold),
                TextAlign = ContentAlignment.TopLeft,
                BackColor = Color.Black,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup
            };
            btnAll.Click += (s, e) =>
            {
                currentCategoryID = null;
                currentPage = 1;
                LoadBooks(currentPage, currentCategoryID);
            };
            
            flowLayoutPanelButtons.Controls.Add(btnAll);

            foreach (DataRow row in categories.Rows)
            {
                Button btnCategory = new Button()
                {
                    Text = row["categoryName"].ToString(),
                    AutoSize = true,
                    Font =  new Font("Arial", 13, FontStyle.Bold),
                    TextAlign = ContentAlignment.TopLeft,
                    BackColor = Color.Black,
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Popup
                };

                string categoryID = row["categoryID"].ToString();
                btnCategory.Click += (s, e) =>
                {
                    currentCategoryID = categoryID;  // Cập nhật thể loại đã chọn
                    currentPage = 1;  // Khi thay đổi thể loại, quay lại trang 1
                    LoadBooks(currentPage, currentCategoryID);
                };
                flowLayoutPanelButtons.Controls.Add(btnCategory); 
            }
        }
        
        private void LoadBooks(int pageNumber, string categoryID)
        {
            DataTable books;
            if (string.IsNullOrEmpty(categoryID))  // Nếu categoryID là null hoặc empty thì lấy tất cả sách
            {
                books = HomepageBL.GetBooks(pageNumber, pageSize);
            }
            else  
            {
                books = HomepageBL.GetBooksByCategory(pageNumber, pageSize, categoryID);
            }

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
                catch (Exception)
                {
                    pictureBox.Image = Properties.Resources.bookdefault; 
                }

                Label lblName = new Label()
                {
                    Text = row["BookName"].ToString(),
                    AutoSize = false,
                    Width = panelWidth - 20,
                    Height = 40,
                    Font = new Font("Arial", 12, FontStyle.Regular),
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
                    Font = new Font("Arial", 13, FontStyle.Regular),
                    BackColor = Color.LightSeaGreen,
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat
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
            int totalRecords = HomepageBL.GetTotalRecords(currentCategoryID);
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            LoadPaginationControls(totalRecords, totalPages);
        }

        private void LoadPaginationControls(int totalRecords, int totalPages)
        { 
            if (currentPage >= totalPages)
            {
                btnNext.Enabled = false;
            }
            else
            {
                btnNext.Enabled = true;
            }
            if (currentPage == 1)
            {
                btnPrevious.Enabled = false;
            }
            else
            {
                btnPrevious.Enabled = true;
            }
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

        
    }
}
