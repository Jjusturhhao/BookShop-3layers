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
        private StockBL stockBL;
     
        public UCStock()
        {
            InitializeComponent();
            stockBL = new StockBL();
        }
            private void LoadComboBoxes()
        {
            try
            {
                // Load danh sách Category
                cbxCategory.DataSource = stockBL.GetBookCategories();
                cbxCategory.DisplayMember = "CategoryName";
                cbxCategory.ValueMember = "CategoryID";

                cbxCategory.SelectedIndex = -1;

                //Load danh sách Supplier
                cbxSupplier.DataSource = stockBL.GetSupplierStocks();
                cbxSupplier.DisplayMember = "Supplier_name"; 
                cbxSupplier.ValueMember = "Supplier_ID";
                cbxSupplier.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load ComboBox: " + ex.Message);
            }
        }
        

        private void UCStock_Load(object sender, EventArgs e)
        {
            try
            {
                dgvStock.DataSource = stockBL.GetStocks(); 
                try
                {
                    LoadComboBoxes(); // Gọi hàm load dữ liệu cho ComboBox
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

            Stock emptyStock = stockBL.GetEmptyStock();

            string newStockID = stockBL.GenerateNextStockID();
            string newBookID = stockBL.GenerateNextBookID(); 
          
            txtStockID.Text = newStockID;
            txtStockID.ReadOnly = true;

            txtBookID.Text = newBookID;
            txtBookID.ReadOnly = true;

            txtBookName.Text = emptyStock.BookName;
            cbxCategory.SelectedIndex = -1;
            cbxSupplier.SelectedIndex = -1;
            txtQuantity.Text = emptyStock.Quantity.ToString();
            dtpk.Value = emptyStock.ImportDate;
         
            txtBookName.Focus();
            dgvStock.DataSource = stockBL.GetStocks();
            

        }

        private void dgvStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // đảm bảo không bấm vào tiêu đề cột
            {
                DataGridViewRow row = dgvStock.Rows[e.RowIndex];

                txtStockID.Text = row.Cells["StockID"].Value?.ToString();
                txtBookID.Text = row.Cells["BookID"].Value?.ToString();
                txtBookName.Text = row.Cells["BookName"].Value?.ToString();
                
                cbxCategory.Text = row.Cells["CategoryID"].Value?.ToString();
                cbxSupplier.Text = row.Cells["Supplier_ID"].Value?.ToString();
                txtQuantity.Text = row.Cells["Quantity"].Value?.ToString();
                
            }
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            string StockID, supplier_ID, BookID, CategoryID, BookName;
            DateTime importDate;
            int quantity;
            StockID = txtStockID.Text;
            supplier_ID = cbxSupplier.SelectedValue?.ToString();
            BookID = txtBookID.Text;
            CategoryID = cbxCategory.SelectedValue?.ToString();
            BookName = txtBookName.Text;
            importDate = dtpk.Value;

            if (!int.TryParse(txtQuantity.Text, out quantity))
            {
                MessageBox.Show("Số lượng không hợp lệ. Vui lòng nhập một số nguyên.");
                return;
            }

            Stock stock = new Stock(StockID, supplier_ID, BookID, CategoryID, BookName,importDate, quantity);
            try
            {
                stockBL.Add(stock);
                dgvStock.DataSource = stockBL.GetStocks();
                btnReset.PerformClick();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteBook_Click(object sender, EventArgs e)
        {
            string StockID, supplier_ID, BookID, CategoryID, BookName;
            DateTime importDate;
            int quantity;
            StockID = txtStockID.Text;
            supplier_ID = cbxSupplier.SelectedValue?.ToString();
            BookID = txtBookID.Text;
            CategoryID = cbxCategory.SelectedValue?.ToString();
            BookName = txtBookName.Text;
            importDate = dtpk.Value;

            quantity = Convert.ToInt32(txtQuantity.Text);

            Stock stock = new Stock(StockID, supplier_ID, BookID, CategoryID, BookName, importDate, quantity);
            try
            {
                stockBL.Delete(stock);
                dgvStock.DataSource = stockBL.GetStocks();
                btnReset.PerformClick();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdateBook_Click(object sender, EventArgs e)
        {
            string StockID, supplier_ID, BookID, CategoryID, BookName;
            DateTime importDate;
            int quantity;
            StockID = txtStockID.Text;
            supplier_ID = cbxSupplier.SelectedValue?.ToString();
            BookID = txtBookID.Text;
            CategoryID = cbxCategory.SelectedValue?.ToString();
            BookName = txtBookName.Text;
            importDate = dtpk.Value;

            quantity = Convert.ToInt32(txtQuantity.Text);



            Stock stock = new Stock(StockID, supplier_ID, BookID, CategoryID, BookName, importDate, quantity);
            try
            {
                stockBL.Update(stock);
                dgvStock.DataSource = stockBL.GetStocks();
                btnReset.PerformClick();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            if (!string.IsNullOrEmpty(keyword))
            {
                dgvStock.DataSource = stockBL.SearchStock(keyword);
            }
            else
            {
                dgvStock.DataSource = stockBL.GetStocks();
            }

        }

        private void AddForm (Form form)
        {
            form.TopLevel = false;
            panel6.Controls.Clear();
            panel6.Controls.Add(form);

            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Show();
        }

        private void btnGIN_Click(object sender, EventArgs e)
        {
            AddForm(new UCGoods_Issue_Note());
        }
    }
}
