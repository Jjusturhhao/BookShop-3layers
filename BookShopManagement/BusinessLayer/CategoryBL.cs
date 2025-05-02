using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DataLayer;
using TransferObject;
using static Guna.UI2.Native.WinApi;

namespace BusinessLayer
{
    
    public class CategoryBL 
    {
        private CategoryDL categoryDL;
        public CategoryBL()
        {
            categoryDL = new CategoryDL();
        }
        public List<BookCategoryStock> GetAllCategories()
        {
            try
            {
                return categoryDL.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Thêm danh mục mới
        public void AddCategory(BookCategoryStock category)
        {
            try
            {
                if (string.IsNullOrEmpty(category.CategoryID) || string.IsNullOrEmpty(category.CategoryName))
                {
                    throw new Exception("CategoryID và CategoryName không được để trống.");
                }

                int result = categoryDL.Add(category);
                if (result <= 0)
                {
                    throw new Exception("Không thể thêm danh mục vào cơ sở dữ liệu.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm danh mục: " + ex.Message);
            }
        }

        // Cập nhật danh mục
        public void UpdateCategory(BookCategoryStock category)
        {
            try
            {
                if (string.IsNullOrEmpty(category.CategoryID) || string.IsNullOrEmpty(category.CategoryName))
                {
                    throw new Exception("CategoryID và CategoryName không được để trống.");
                }

                int result = categoryDL.Update(category);
                if (result <= 0)
                {
                    throw new Exception("Không thể cập nhật danh mục vào cơ sở dữ liệu.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật danh mục: " + ex.Message);
            }
        }

        // Xóa danh mục
        public void DeleteCategory(string categoryID)
        {
            try
            {
                if (string.IsNullOrEmpty(categoryID))
                {
                    throw new Exception("CategoryID không được để trống.");
                }

                int result = categoryDL.Delete(categoryID);
                if (result <= 0)
                {
                    throw new Exception("Không thể xóa danh mục khỏi cơ sở dữ liệu.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa danh mục: " + ex.Message);
            }
        }

        // Tìm kiếm danh mục theo từ khóa
        public List<BookCategoryStock> SearchCategory(string keyword)
        {
            try
            {
                return categoryDL.Search(keyword);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm danh mục: " + ex.Message);
            }
        }
        public string GetNewCategoryID()
        {
            return categoryDL.GenerateNewCategoryID();
        }
    }
}

