using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace DataLayer
{
    public class StatisticsDL : DataProvider
    {
        /// Doanh thu theo tháng
        public DataTable GetMonthlyRevenue(int year)
        {
            try
            {
                string query = @"
                SELECT 
                    MONTH(b.Bill_Date) AS Month,
                    YEAR(b.Bill_Date) AS Year,
                    SUM(od.Qty_Sold * od.PriceAtOrderTime) AS TotalRevenue,
                    COUNT(DISTINCT b.Order_ID) AS OrderCount
                FROM 
                    Bill_Generate b
                    JOIN OrderDetails od ON od.Order_ID = b.Order_ID
                    JOIN Payments p ON b.Bill_ID = p.Bill_ID
                    JOIN Orders o ON o.Order_ID = b.Order_ID
                WHERE 
                    YEAR(b.Bill_Date) = @Year
                    AND o.Status = N'Đã hoàn thành'
                    
                GROUP BY 
                    MONTH(b.Bill_Date), YEAR(b.Bill_Date)
                ORDER BY 
                    MONTH(b.Bill_Date)";

                DataTable dt = new DataTable();

                Connect();
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@Year", year);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }

                return dt;
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

        ///  Top 5 đầu sách bán chạy
        public List<TopSellingBook> GetTopSellingBooks(int year, int? month = null)
        {
            List<TopSellingBook> books = new List<TopSellingBook>();

            string query = @"
            SELECT TOP 5 
                b.BookName, 
                SUM(od.Qty_Sold) AS TotalSold
            FROM 
                OrderDetails od
                JOIN Orders o ON od.Order_ID = o.Order_ID
                JOIN Book b ON od.BookID = b.BookID
            WHERE 
                YEAR(o.Order_Date) = @Year
                AND o.Status = N'Đã hoàn thành'";

            if (month.HasValue)
            {
                query += " AND MONTH(o.Order_Date) = @Month";
            }

            query += @"
            GROUP BY 
                b.BookName
            ORDER BY 
                TotalSold DESC";

            Connect();
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.AddWithValue("@Year", year);

                if (month.HasValue)
                {
                    cmd.Parameters.AddWithValue("@Month", month.Value);
                }

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new TopSellingBook
                        {
                            Title = reader.GetString(0),
                            TotalSold = reader.GetInt32(1)
                        });
                    }
                }
            }
            DisConnect();
            return books;
        }


        /// Doanh thu theo thể loại
        public DataTable GetCategoryRevenue(int year, int? month = null)
        {
            try
            {
                string query = @"
                SELECT 
                    bc.CategoryName,
                    SUM(od.Qty_Sold * od.PriceAtOrderTime) AS TotalRevenue,
                    COUNT(DISTINCT b.Order_ID) AS OrderCount
                FROM 
                    Bill_Generate b
                    JOIN Payments p ON b.Bill_ID = p.Bill_ID
                    JOIN Orders o ON o.Order_ID = b.Order_ID
                    JOIN OrderDetails od ON od.Order_ID = o.Order_ID
                    JOIN Stock s ON s.BookID = od.BookID
                    JOIN BookCategory bc ON bc.CategoryID = s.CategoryID
                WHERE 
                    YEAR(b.Bill_Date) = @Year
                    " + (month.HasValue ? "AND MONTH(b.Bill_Date) = @Month" : "") + @"
                    AND o.Status = N'Đã hoàn thành'
                GROUP BY 
                    bc.CategoryName
                ORDER BY 
                    bc.CategoryName";

                DataTable dt = new DataTable();

                Connect();
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@Year", year);
                    if (month.HasValue)
                        cmd.Parameters.AddWithValue("@Month", month.Value);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }

                return dt;
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

        /// Số đơn hàng bán ra
        public DataTable GetOrderQuantity(int year)
        {
            try
            {
                string query = @"
                SELECT 
                    MONTH(o.Order_Date) AS Month,
                    YEAR(o.Order_Date) AS Year,
                    COUNT(DISTINCT o.Order_ID) AS OrderCount
                FROM 
                    Orders o
                WHERE 
                    YEAR(o.Order_Date) = @Year
                    AND o.Status = N'Đã hoàn thành'
                    
                GROUP BY 
                    MONTH(o.Order_Date), YEAR(o.Order_Date)
                ORDER BY 
                    MONTH(o.Order_Date)";

                DataTable dt = new DataTable();

                Connect();
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@Year", year);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
                return dt;
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
