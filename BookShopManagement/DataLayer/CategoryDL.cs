using Microsoft.ReportingServices.Diagnostics.Internal;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;
using System.Data;

namespace DataLayer
{
    public class CategoryDL : DataProvider
    {
        public List<BookCategoryStock> GetAll()
        {
            List<BookCategoryStock> list = new List<BookCategoryStock>();
            string sql = "SELECT * FROM BookCategory";

            SqlCommand cmd = new SqlCommand(sql, cn);
            Connect();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string id = reader["CategoryID"].ToString();
                string name = reader["CategoryName"].ToString();
                list.Add(new BookCategoryStock(id, name));
            }

            reader.Close();
            DisConnect();
            return list;
        }

        // Thêm danh mục mới
        public int Add(BookCategoryStock bookCategoryStock)
        {
            string sql = "INSERT INTO BookCategory (CategoryID, CategoryName) VALUES (@id, @name)";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@id", bookCategoryStock.CategoryID);
            cmd.Parameters.AddWithValue("@name", bookCategoryStock.CategoryName);

            Connect();
            int result = cmd.ExecuteNonQuery();
            DisConnect();
            return result;
        }

        // Cập nhật danh mục
        public int Update(BookCategoryStock bookCategoryStock)
        {
            string sql = "UPDATE BookCategory SET CategoryName = @name WHERE CategoryID = @id";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@id", bookCategoryStock.CategoryID);
            cmd.Parameters.AddWithValue("@name", bookCategoryStock.CategoryName);

            Connect();
            int result = cmd.ExecuteNonQuery();
            DisConnect();
            return result;
        }

        // Xóa danh mục
        public bool Delete(string id)
        {
            string sql = "DELETE FROM BookCategory WHERE CategoryID = @id";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@id", id);
            return MyExecuteNonQuery(cmd) > 0;
        }

        public List<BookCategoryStock> Search(string keyword)
        {
            List<BookCategoryStock> list = new List<BookCategoryStock>();

            if (string.IsNullOrWhiteSpace(keyword))
                return list;

            string sanitizedKeyword = keyword.Trim().ToLower();
            string keywordForName = "%" + string.Join("%", sanitizedKeyword.Split(' ')) + "%";

            string sql;
            SqlCommand cmd;

            Connect();

            if (sanitizedKeyword.Length <= 3)
            {
                sql = @"
                SELECT * FROM BookCategory 
                WHERE LOWER(CategoryID) LIKE @kw 
                OR CategoryName COLLATE Vietnamese_CI_AI LIKE @kwName";
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@kw", sanitizedKeyword + "%");
                cmd.Parameters.AddWithValue("@kwName", keywordForName);
            }
            else
            {
                sql = @"
                SELECT * FROM BookCategory 
                WHERE LOWER(CategoryID) = @kw 
                OR CategoryName COLLATE Vietnamese_CI_AI LIKE @kwName";
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@kw", sanitizedKeyword);
                cmd.Parameters.AddWithValue("@kwName", keywordForName);
            }

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string categoryID = reader["CategoryID"].ToString();
                string categoryName = reader["CategoryName"].ToString();
                list.Add(new BookCategoryStock(categoryID, categoryName));
            }
            reader.Close();
            DisConnect();
            return list;
        }

        public string GenerateNewCategoryID()
        {
            string sql = "SELECT CategoryID FROM BookCategory";
            List<int> existingNumbers = new List<int>();

            Connect();
            SqlCommand cmd = new SqlCommand(sql, cn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string id = reader["CategoryID"].ToString().ToUpper().Trim();
                if (id.StartsWith("CAT"))
                {
                    string numberPart = id.Substring(3);
                    if (int.TryParse(numberPart, out int num))
                    {
                        existingNumbers.Add(num);
                    }
                }
            }
            reader.Close();
            DisConnect();

            int nextNumber = 1;
            while (existingNumbers.Contains(nextNumber))
            {
                nextNumber++;
            }
            return "CAT" + nextNumber;
        }
    }
}
