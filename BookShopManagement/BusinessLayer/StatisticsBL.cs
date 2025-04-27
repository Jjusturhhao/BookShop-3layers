using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace BusinessLayer
{
    public class StatisticsBL
    {
        private StatisticsDL statisticsDL;

        public StatisticsBL()
        {
            statisticsDL = new StatisticsDL();
        }

        public List<MonthlyRevenue> GetMonthlyRevenueByYear(int year)
        {
            List<MonthlyRevenue> result = new List<MonthlyRevenue>();
            DataTable dt = statisticsDL.GetMonthlyRevenue(year);

            foreach (DataRow row in dt.Rows)
            {
                result.Add(new MonthlyRevenue
                {
                    Month = Convert.ToInt32(row["Month"]),
                    Year = Convert.ToInt32(row["Year"]),
                    TotalRevenue = Convert.ToDecimal(row["TotalRevenue"]),
                    //OrderCount = Convert.ToInt32(row["OrderCount"])
                });
            }
            return result;
        }

        public List<TopSellingBook> GetTopSellingBooksByMonth(int year, int? month = null)
        {
            return statisticsDL.GetTopSellingBooks(year, month);
        }

        public List<CategoryRevenue> GetCategoryRevenueByMonth(int year, int? month = null)
        {
            DataTable dt = statisticsDL.GetCategoryRevenue(year, month);
            List<CategoryRevenue> list = new List<CategoryRevenue>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new CategoryRevenue
                {
                    CategoryName = row["CategoryName"].ToString(),

                    // Đọc TotalRevenue an toàn
                    TotalRevenue = row["TotalRevenue"] != DBNull.Value
                                   ? Convert.ToDecimal(row["TotalRevenue"])
                                   : 0,

                    // Đọc OrderCount an toàn
                    OrderCount = row["OrderCount"] != DBNull.Value
                                 ? Convert.ToInt32(row["OrderCount"])
                                 : 0,

                    Month = month ?? 0,
                    Year = year
                });
            }
            return list;
        }

        public List<OrderQuantity> GetOrderQuantityByYear(int year)
        {
            List<OrderQuantity> result = new List<OrderQuantity>();
            DataTable dt = statisticsDL.GetOrderQuantity(year);

            foreach (DataRow row in dt.Rows)
            {
                result.Add(new OrderQuantity
                {
                    Month = Convert.ToInt32(row["Month"]),
                    Year = Convert.ToInt32(row["Year"]),
                    OrderCount = Convert.ToInt32(row["OrderCount"])
                });
            }
            return result;
        }

    }
}
