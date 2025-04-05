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
    public partial class StaffInterface : Form
    {
        private int currentPage = 1;
        private int pageSize = 8;
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=BookStoreManagement;Integrated Security=True;TrustServerCertificate=True");

        public StaffInterface()
        {
            InitializeComponent();
        }

        private void StaffInterface_Load(object sender, EventArgs e)
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

            int panelWidth = this.flowLayoutPanelBooks.Width / 4 - 30;
            int panelHeight = this.flowLayoutPanelBooks.Height / 2 - 20;

            foreach (DataRow row in books.Rows)
            {
                Panel panel = new Panel()
                {
                    Width = panelWidth,
                    Height = panelHeight + 20,
                    Margin = new Padding(10)
                };

                PictureBox pictureBox = new PictureBox()
                {
                    Width = panelWidth - 20,
                    Height = panelHeight - 80,
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
                    pictureBox.Image = Properties.Resources.bookdefault; // Load ảnh mặc định nếu có lỗi
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

                Label lblQuantity = new Label()
                {
                    Text = "Số lượng tồn: ",
                    AutoSize = false,
                    Width = panelWidth - 20,
                    Font = new Font("Arial", 12, FontStyle.Regular),
                    TextAlign = ContentAlignment.MiddleLeft
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

                pictureBox.Click += (s, e) =>
                {
                    //MessageBox.Show("Bạn đã chọn: " + row["BookName"].ToString());
                };

                panel.Controls.Add(pictureBox);
                panel.Controls.Add(lblName);
                panel.Controls.Add(lblPrice);
                panel.Controls.Add(lblQuantity);

                pictureBox.Location = new Point(10, 5);
                lblName.Location = new Point(10, pictureBox.Bottom + 5);
                lblPrice.Location = new Point(10, lblName.Bottom);
                lblQuantity.Location = new Point(10, lblPrice.Bottom);

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

        private void btnStaffInterface_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Checkout checkout = new Checkout();
            checkout.Show();
            this.Hide();
        }

        private void btnBookManage_Click(object sender, EventArgs e)
        {
            BookManagement bookManagement = new BookManagement();
            bookManagement.Show();
            this.Hide();
        }

        private void btnCustomerManage_Click(object sender, EventArgs e)
        {

        }

        private void btnAccout_Click(object sender, EventArgs e)
        {

        }
    }
}
