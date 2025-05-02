using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DataLayer;
using TransferObject;
using System.Windows.Documents;
using static Guna.UI2.Native.WinApi;
using System.Windows.Forms;

namespace BusinessLayer
{
    public class StockBL
    {
        private StockDL stockDL;
        private BookBL BookBL;

        public StockBL()
        {
            stockDL = new StockDL();
        }

        public List<Stock> GetStocks()
        {
            try
            {
                return stockDL.GetStocks();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string GenerateNextBookID()
        {
            return stockDL.GenerateNextBookID();
        }
        public Stock Refest()
        {
            return stockDL.Refest();
        }
        public List<BookCategoryStock> GetBookCategories()
        {
            try
            {
                return stockDL.bookCategoryStocks();
            }
            catch (Exception)
            {
                throw;
            }

        }
        public List<SupplierStock> GetSupplierStocks()
        {
            try
            {
                return stockDL.supplierStocks();
            }
            catch (Exception)
            {
                throw;
            }

        }
        public int Add(Stock stock)
        {
            // Thêm sách vào Book trước (nếu chưa tồn tại)
            BookBL bookBL = new BookBL();
            bookBL.AddBookFromStock(stock);

            // Thêm sách vào bảng Stock
            int result = stockDL.Add(stock);

            

            return result;
        }

        public int Update(Stock stock)
        {
            return stockDL.Update(stock);
        }
        public List<Stock> SearchStock(string keyword)
        {
            return stockDL.SearchStock(keyword);
        }


        public void ReduceStockQuantity(string bookID, int quantity)
        {
            stockDL.ReduceQuantity(bookID, quantity);
        }
        public int GetCurrentQuantity(string bookID)
        {
            return stockDL.GetCurrentQuantity(bookID);
        }
    }
}