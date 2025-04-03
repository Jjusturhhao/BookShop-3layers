using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class Homepage : Form
    {
        private int currentPage = 1;
        private int pageSize = 8;
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=BookStoreManagement;Integrated Security=True;TrustServerCertificate=True");

        public Homepage()
        {
            InitializeComponent();
        }

        private void Homepage_Load(object sender, EventArgs e)
        {
            LoadBooks(currentPage);
        }
        private DataTable GetBooks(int pageNumber, int pageSize)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Book ORDER BY BookID OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY", con);
            cmd.Parameters.AddWithValue("@Offset", (pageNumber - 1) * pageSize);
            cmd.Parameters.AddWithValue("@PageSize", pageSize);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        private void LoadBooks(int pageNumber)
        {
            DataTable books = GetBooks(pageNumber, pageSize);
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
                pictureBox.Load(imageUrl);
                //try
                //{
                //    pictureBox.Load(imageUrl);
                //}
                //catch (Exception)
                //{
                //    pictureBox.Image = Properties.Resources.default_image; // Ảnh mặc định nếu có lỗi
                //}

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
            int totalRecords = GetTotalRecords();
            LoadPaginationControls(totalRecords);
        }

        private void LoadPaginationControls(int totalRecords)
        {
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            btnPrevious.Click += (s, e) =>
            {
                if (currentPage > 1)
                {
                    currentPage--;
                    LoadBooks(currentPage);
                }
            };

            btnNext.Click += (s, e) =>
            {
                if (currentPage < totalPages)
                {
                    currentPage++;
                    LoadBooks(currentPage);
                }
            };
        }

        private int GetTotalRecords()
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Book", con);
            con.Open();
            int totalRecords = (int)cmd.ExecuteScalar();
            con.Close();
            return totalRecords;
        }
    }
}
