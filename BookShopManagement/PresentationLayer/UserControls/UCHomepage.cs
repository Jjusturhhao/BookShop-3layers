using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using BusinessLayer;
using TransferObject;
using static Guna.UI2.Native.WinApi;

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
        private Action<string> showBookDetailCallback;

        public UCHomepage(UCCart cart, Action<string> callback)
        {
            InitializeComponent();
            homepageBL = new HomepageBL();
            cartBL = new CartBL();
            ucCart = cart;
            Load += UCHomepage_Load;
            showBookDetailCallback = callback;
        }

        private void UCHomepage_Load(object sender, EventArgs e)
        {
            btnPrevious.Click -= btnPrevious_Click;
            btnPrevious.Click += btnPrevious_Click;

            btnNext.Click -= btnNext_Click;
            btnNext.Click += btnNext_Click;

            // Gọi sau cùng để đảm bảo các control đã render xong
            BeginInvoke(new Action(() => LoadBooks(currentPage, currentCategoryID)));
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

                string imageFileName = row["BookImage"].ToString();
                string imagePath = Path.Combine(Application.StartupPath, @"..\..\BookImage", imageFileName);
                try
                {
                    pictureBox.Image = Image.FromFile(imagePath);
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
                    string bookID = row["BookID"].ToString();
                    //showBookDetailCallback?.Invoke(bookID); // Gọi callback khi click
                    if (showBookDetailCallback == null)
                    {
                        MessageBox.Show("Callback không được gán.");
                    }
                    else
                    {
                        showBookDetailCallback(bookID);
                    }
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
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int totalRecords = homepageBL.GetTotalRecords(currentCategoryID);
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            if (currentPage < totalPages)
            {
                currentPage++;
                LoadBooks(currentPage, currentCategoryID);
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadBooks(currentPage, currentCategoryID);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                LoadBooks(currentPage, currentCategoryID);
                return;
            }

            try
            {
                DataTable allBooks = homepageBL.GetBooks(1, int.MaxValue);

                // Tạo bảng chứa sách tìm kiếm được
                DataTable searchResult = allBooks.Clone(); // Tạo structure y chang allBooks nhưng chưa có dữ liệu

                foreach (DataRow row in allBooks.Rows)
                {
                    if (row["BookName"].ToString().IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        searchResult.ImportRow(row);
                    }
                }

                flowLayoutPanelBooks.Controls.Clear();

                int screenWidth = this.flowLayoutPanelBooks.Width;
                int screenHeight = this.flowLayoutPanelBooks.Height;
                int panelWidth = screenWidth / 4 - 30;
                int panelHeight = screenHeight / 2 - 30;

                foreach (DataRow row in searchResult.Rows)
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

                    string imageFileName = row["BookImage"].ToString();
                    string imagePath = Path.Combine(Application.StartupPath, @"..\..\BookImage", imageFileName);
                    try
                    {
                        pictureBox.Image = Image.FromFile(imagePath);
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
                    btnBuy.Click += (s, ev) =>
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

                    pictureBox.Click += (s, ev) =>
                    {
                        string bookID = row["BookID"].ToString();
                        if (showBookDetailCallback == null)
                        {
                            MessageBox.Show("Callback không được gán.");
                        }
                        else
                        {
                            showBookDetailCallback(bookID);
                        }
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

                lbPage.Text = "1"; // Khi search thì về page 1
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}