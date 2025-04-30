using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferObject;
using BusinessLayer;
using PresentationLayer.UserControls;

namespace PresentationLayer
{
    public partial class AddCategory : Form
    {
        

        private CategoryBL categoryBL;
        public AddCategory()
        {
            categoryBL = new CategoryBL();
            InitializeComponent();
        }
        private void LoadCategories()
        {
            try
            {
                List<BookCategoryStock> categories = categoryBL.GetAllCategories();
                dgvCategory.DataSource = categories;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu danh mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtCatID.Clear();
            txtCatName.Clear();
            txtCatID.Text = categoryBL.GetNewCategoryID();
            txtCatName.Focus();
            LoadCategories();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string categoryID = txtCatID.Text;
            string categoryName = txtCatName.Text;

            if (string.IsNullOrEmpty(categoryID) || string.IsNullOrEmpty(categoryName))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                BookCategoryStock newCategory = new BookCategoryStock(categoryID, categoryName);
                categoryBL.AddCategory(newCategory);
                MessageBox.Show("Đã thêm danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm danh mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpate_Click(object sender, EventArgs e)
        {
            string categoryID = txtCatID.Text;
            string categoryName = txtCatName.Text;

            if (string.IsNullOrEmpty(categoryID) || string.IsNullOrEmpty(categoryName))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                BookCategoryStock updatedCategory = new BookCategoryStock(categoryID, categoryName);
                categoryBL.UpdateCategory(updatedCategory);
                MessageBox.Show("Đã cập nhật danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật danh mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string categoryID = txtCatID.Text;

            if (string.IsNullOrEmpty(categoryID))
            {
                MessageBox.Show("Vui lòng chọn danh mục để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                categoryBL.DeleteCategory(categoryID);
                MessageBox.Show("Đã xóa danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa danh mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                List<BookCategoryStock> searchResults = categoryBL.SearchCategory(keyword);
                dgvCategory.DataSource = searchResults;

                if (searchResults.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm danh mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCategory.Rows[e.RowIndex];
                txtCatID.Text = row.Cells["CategoryID"].Value.ToString();
                txtCatName.Text = row.Cells["CategoryName"].Value.ToString();
            }
        }

        private void AddCategory_Load(object sender, EventArgs e)
        {
            LoadCategories();
            
            
           
        }

        private void AddCategory_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
