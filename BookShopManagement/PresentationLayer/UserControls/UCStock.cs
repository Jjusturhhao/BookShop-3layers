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
using BusinessLayer;
using PresentationLayer;
using TransferObject;


namespace PresentationLayer.UserControls
{
    public partial class UCStock : UserControl
    {
        private readonly StockBL stockBL = new StockBL();
        private readonly RuleBL ruleBL = new RuleBL();
        private readonly List<Stock> addedStocks = new List<Stock>();

        public UCStock()
        {
            InitializeComponent();
        }

        private void UCStock_Load(object sender, EventArgs e)
        {
            LoadStock();
            LoadComboBoxes();
        }

        private void LoadStock()
        {
            try
            {
                dgvStock.DataSource = stockBL.GetStocks();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách kho: " + ex.Message);
            }
        }

        private void LoadComboBoxes()
        {
            try
            {
                cbxCategory.DataSource = stockBL.GetBookCategories();
                cbxCategory.DisplayMember = "CategoryName";
                cbxCategory.ValueMember = "CategoryID";
                cbxCategory.SelectedIndex = -1;

                cbxSupplier.DataSource = stockBL.GetSupplierStocks();
                cbxSupplier.DisplayMember = "Supplier_name";
                cbxSupplier.ValueMember = "Supplier_ID";
                cbxSupplier.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách thể loại/nhà cung cấp: " + ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtBookName.ReadOnly = false;
            cbxCategory.Enabled = true;
            dtpk.Enabled = true;
            cbxSupplier.Enabled = true;
            txtQuantity.Enabled = true; 
            ResetForm();
        }

        private void ResetForm()
        {
            txtBookID.Text = stockBL.GenerateNextBookID();
            txtBookID.ReadOnly = true;

            txtBookName.Clear();
            txtQuantity.Clear();
            txtQuantity.ReadOnly = false;

            cbxCategory.SelectedIndex = -1;
            cbxSupplier.SelectedIndex = -1;
            dtpk.Value = DateTime.Now;

            txtSL.Visible = false;
            label2.Visible = false;

            LoadStock();
        }

        private void dgvStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvStock.Rows[e.RowIndex];
            txtBookID.Text = row.Cells["BookID"].Value?.ToString();
            txtBookName.Text = row.Cells["BookName"].Value?.ToString();
            cbxCategory.Text = row.Cells["CategoryID"].Value?.ToString();
            cbxSupplier.Text = row.Cells["SupplierID"].Value?.ToString();
            txtQuantity.Text = row.Cells["Quantity"].Value?.ToString();

            txtSL.Text = "0";
            txtSL.Visible = true;
            label2.Visible = true;
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            string bookID = txtBookID.Text;
            string bookName = txtBookName.Text;
            string supplierID = cbxSupplier.SelectedValue?.ToString();
            string categoryID = cbxCategory.SelectedValue?.ToString();
            DateTime importDate = dtpk.Value;

            if (string.IsNullOrWhiteSpace(bookID) || string.IsNullOrWhiteSpace(bookName)
                || string.IsNullOrWhiteSpace(supplierID) || string.IsNullOrWhiteSpace(categoryID))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sách.", "Thiếu thông tin");
                return;
            }

            if (!int.TryParse(txtQuantity.Text, out int quantity))
            {
                MessageBox.Show("Số lượng không hợp lệ.");
                return;
            }

            int.TryParse(ruleBL.GetRuleValue("Nhập tối thiểu"), out int minQty);
            if (quantity < minQty)
            {
                MessageBox.Show($"Số lượng nhập tối thiểu là {minQty}.");
                return;
            }

            Stock stock = new Stock(bookID, supplierID, categoryID, bookName, importDate, quantity);
            try
            {
                stockBL.Add(stock);
                addedStocks.Add(stock);
                MessageBox.Show("Thêm sách thành công!");
                ResetForm();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi SQL: " + ex.Message);
            }
        }

        private void btnUpdateBook_Click(object sender, EventArgs e)
        {
            string bookID = txtBookID.Text.Trim();
            if (!int.TryParse(txtSL.Text.Trim(), out int quantityToAdd))
            {
                MessageBox.Show("Vui lòng nhập số lượng hợp lệ để nhập thêm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy rule ngưỡng tồn kho (VD: 300)
            int.TryParse(ruleBL.GetRuleValue("Chỉ nhập khi số lượng sách trong kho dưới"), out int maxAllowedStock);

            // Lấy số lượng tồn kho hiện tại
            int currentQty = stockBL.GetCurrentQuantity(bookID);

            // Kiểm tra nếu tồn kho hiện tại đã vượt mức cho phép thì không cho nhập nữa
            if (currentQty > maxAllowedStock)
            {
                MessageBox.Show($"Chỉ được nhập thêm nếu số sách trong kho ít hơn {maxAllowedStock} cuốn.");
                return;
            }

            // Lấy số lượng tối thiểu cần nhập
            int.TryParse(ruleBL.GetRuleValue("Nhập tối thiểu"), out int minQty);
            if (quantityToAdd < minQty)
            {
                MessageBox.Show($"Phải nhập tối thiểu {minQty} cuốn.");
                return;
            }

            try
            {
                Stock stock = new Stock(
                    bookID,
                    cbxSupplier.SelectedValue.ToString(),
                    cbxCategory.SelectedValue.ToString(),
                    txtBookName.Text,
                    DateTime.Now,
                    quantityToAdd
                );
                int result = stockBL.Update(stock);
                if (result > 0)
                {
                    // Thêm vào danh sách addedStocks để xuất phiếu
                    addedStocks.Add(stock);

                    MessageBox.Show("Cập nhật kho thành công!");
                    LoadStock();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnDeleteBook_Click(object sender, EventArgs e)
        {
            try
            {
                string bookID = txtBookID.Text;
                string supplierID = cbxSupplier.SelectedValue?.ToString();
                string categoryID = cbxCategory.SelectedValue?.ToString();
                string bookName = txtBookName.Text;
                DateTime importDate = dtpk.Value;

                int quantity;
                if (!int.TryParse(txtQuantity.Text, out quantity))
                {
                    MessageBox.Show("Số lượng không hợp lệ.");
                    return;
                }

                Stock stock = new Stock(bookID, supplierID, categoryID, bookName, importDate, quantity);
                stockBL.Delete(stock);

                MessageBox.Show("Xóa sách khỏi kho thành công.");
                btnReset.PerformClick(); // hoặc gọi ResetForm() nếu em có hàm riêng
                dgvStock.DataSource = stockBL.GetStocks(); // Load lại danh sách
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi SQL: " + ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            dgvStock.DataSource = string.IsNullOrEmpty(keyword)
                ? stockBL.GetStocks()
                : stockBL.SearchStock(keyword);
        }

        private void btnGIN_Click(object sender, EventArgs e)
        {
            if (addedStocks.Count == 0)
            {
                MessageBox.Show("Chưa có sách nào được thêm vào.");
                return;
            }

            var uCIssue = new UCIssue();
            uCIssue.SetDate(DateTime.Now);
            uCIssue.SetStockList(addedStocks);
            ShowUserControl(uCIssue);
        }

        public void ShowUserControl(UserControl userControl)
        {
            Controls.Clear();
            userControl.Dock = DockStyle.Fill;
            Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {

        }
    }
}