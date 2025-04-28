using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;
using System.Net;
using System.Data.Common;
using Microsoft.Reporting.Map.WebForms.BingMaps;

namespace DataLayer
{
    public class StockDL : DataProvider
    {

        public List<Stock> GetStocks()
        {
            string supplierID, bookID, categoryID, bookName;

            List<Stock> stocks = new List<Stock>();
            string sql = "SELECT s.BookID,sl.Supplier_name, c.CategoryName, s.BookName, s.ImportDate, s.Quantity " +
                "FROM Stock s JOIN BookCategory c ON s.CategoryID = c.CategoryID " + 
                "JOIN Suppliers sl ON s.SupplierID = sl.Supplier_ID " + 
                "ORDER BY CAST(SUBSTRING(s.BookID, 5, LEN(s.BookID)) AS INT)";
            try
            {
                Connect();
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    bookID = reader["BookID"].ToString();
                    supplierID = reader["Supplier_name"].ToString();
                    categoryID = reader["CategoryName"].ToString();
                    bookName = reader["BookName"].ToString();
                    DateTime importDate = reader["ImportDate"] != DBNull.Value ? Convert.ToDateTime(reader["ImportDate"]) : DateTime.MinValue;
                    int quantity = reader["Quantity"] != DBNull.Value ? Convert.ToInt32(reader["Quantity"]) : 0;

                    Stock stock = new Stock(bookID, supplierID, categoryID, bookName, importDate, quantity);
                    stocks.Add(stock);
                }
                reader.Close();
                return stocks;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }
        }

        public string GenerateNextBookID()
        {
            List<Stock> stocks = GetStocks();

            int maxID = 0;
            foreach (var stock in stocks)
            {
                if (stock.BookID.StartsWith("BOOK"))
                {
                    string numberPart = stock.BookID.Substring(4);
                    if (int.TryParse(numberPart, out int idNum))
                    {
                        if (idNum > maxID)
                            maxID = idNum;
                    }
                }
            }

            int nextID = maxID + 1;
            return $"BOOK{nextID:D1}";
        }
        public Stock Refest()
        {
            return new Stock("", "", "", "", DateTime.Now, 150);
        }
        public List<BookCategoryStock> bookCategoryStocks()
        {
            string CategoryID, Categoryname;
            List<BookCategoryStock> bookCategoryStocks = new List<BookCategoryStock>();
            string sql = "SELECT * FROM BookCategory";
            try
            {
                Connect();
                SqlDataReader reader1 = MyExecuteReader(sql, CommandType.Text);
                while (reader1.Read())
                {
                    CategoryID = reader1["CategoryID"].ToString();
                    Categoryname = reader1["CategoryName"].ToString();
                    BookCategoryStock bookCategoryStock = new BookCategoryStock(CategoryID, Categoryname);
                    bookCategoryStocks.Add(bookCategoryStock);
                }
                reader1.Close();
                return bookCategoryStocks;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }
        }
        public List<SupplierStock> supplierStocks()
        {
            string SupplierID, Supplier_name;
            List<SupplierStock> supplierStocks = new List<SupplierStock>();
            string sql = "SELECT * FROM Suppliers";
            try
            {
                Connect();
                SqlDataReader reader2 = MyExecuteReader(sql, CommandType.Text);
                while (reader2.Read())
                {
                    SupplierID = reader2["Supplier_ID"].ToString();
                    Supplier_name = reader2["Supplier_name"].ToString();

                    SupplierStock supplierStock = new SupplierStock(SupplierID, Supplier_name);
                    supplierStocks.Add(supplierStock);
                }
                reader2.Close();
                return supplierStocks;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }
        }
        public int Add(Stock stock)
        {
            string sql = "INSERT INTO Stock (BookID, SupplierID, CategoryID, BookName, ImportDate, Quantity) " +
             "VALUES ('" + stock.BookID + "', '" + stock.SupplierID + "', '" + stock.CategoryID + "', '" +
             stock.BookName + "', '" + stock.ImportDate.ToString("yyyy-MM-dd") + "', " + stock.Quantity + ")";


            try
            {
                return MyExecuteNonQuery(sql, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }
        }
        public int Delete(Stock stock)
        {


            string sql = "DELETE FROM Stock WHERE 1=1";
            if (!string.IsNullOrEmpty(stock.BookID))
                sql += " AND BookID = '" + stock.BookID.Replace("'", "''") + "'";
            sql += " AND CategoryID = '" + stock.CategoryID + "'";
            if (!string.IsNullOrEmpty(stock.BookName))
                sql += " AND BookName = '" + stock.BookName.Replace("'", "''") + "'";
            if (stock.ImportDate != DateTime.MinValue)
                sql += " AND ImportDate = '" + stock.ImportDate.ToString("yyyy-MM-dd") + "'";
            if (stock.Quantity != 0)
                sql += " AND Quantity = " + stock.Quantity;


            try
            {
                return MyExecuteNonQuery(sql, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }
        }
        public int Update(Stock stock)
        {
            string sql = "UPDATE Stock SET ";

            List<string> updates = new List<string>();

            updates.Add("CategoryID = '" + stock.CategoryID + "'");
            if (!string.IsNullOrEmpty(stock.BookName))
                updates.Add("BookName = '" + stock.BookName.Replace("'", "''") + "'");
            if (stock.ImportDate != DateTime.MinValue)
                updates.Add("ImportDate = '" + stock.ImportDate.ToString("yyyy-MM-dd") + "'");
            int currentQuantity = GetCurrentQuantity(stock.BookID);

            if (stock.Quantity < 150)
            {
                throw new Exception("Vui lòng nhập ít nhất 150 sách.");
            }


            int newQuantity = currentQuantity + stock.Quantity;

            updates.Add("Quantity = " + newQuantity);

            if (updates.Count == 0)
                throw new Exception("Không có thông tin nào để cập nhật.");

            sql += string.Join(", ", updates);
            sql += " WHERE BookID = '" + stock.BookID + "'";

            try
            {
                return MyExecuteNonQuery(sql, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }
        }
        public List<Stock> SearchStock(string keyword)
        {
            string supplierID, bookID, categoryID, bookName;

            List<Stock> stocks = new List<Stock>();
            string sql = "SELECT s.BookID, sl.Supplier_name, c.CategoryName, s.BookName, s.ImportDate, s.Quantity " +
    "FROM Stock s " +
    "JOIN BookCategory c ON s.CategoryID = c.CategoryID " +
    "JOIN Suppliers sl ON s.SupplierID = sl.Supplier_ID " +
    "WHERE sl.Supplier_name LIKE N'%" + keyword + "%' OR " +
    "s.BookID LIKE N'%" + keyword + "%' OR " +
    "c.CategoryName LIKE N'%" + keyword + "%' OR " +
    "s.BookName LIKE N'%" + keyword + "%' OR " +
    "CONVERT(NVARCHAR, s.ImportDate, 120) LIKE N'%" + keyword + "%' OR " +
    "CONVERT(NVARCHAR, s.Quantity) LIKE N'%" + keyword + "%'";
            try
            {
                Connect();
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    bookID = reader["BookID"].ToString();
                    supplierID = reader["Supplier_name"].ToString();
                    categoryID = reader["CategoryName"].ToString();
                    bookName = reader["BookName"].ToString();
                    DateTime importDate = reader["ImportDate"] != DBNull.Value ? Convert.ToDateTime(reader["ImportDate"]) : DateTime.MinValue;
                    int quantity = reader["Quantity"] != DBNull.Value ? Convert.ToInt32(reader["Quantity"]) : 0;

                    Stock stock = new Stock(bookID, supplierID, categoryID, bookName, importDate, quantity);
                    stocks.Add(stock);
                }
                reader.Close();
                return stocks;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }
        }

        public void ReduceQuantity(string bookID, int quantity)
        {
            string sql = "UPDATE Stock " +
                           "SET Quantity = Quantity - @quantity " +
                           "WHERE BookID = @bookID AND Quantity >= @quantity ";
            try
            {
                Connect();
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@bookID", bookID);
                    cmd.Parameters.AddWithValue("@quantity", quantity);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }
        }
        public int GetCurrentQuantity(string bookID)
        {
            string sql = "SELECT Quantity FROM Stock WHERE bookID = @bookID";
            try
            {
                Connect();
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@bookID", bookID);
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        return Convert.ToInt32(result);
                    }
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }
        }
    }
}

