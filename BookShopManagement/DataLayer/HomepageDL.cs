using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class HomepageDL : DataProvider
    {
        public DataTable GetBooks(int pageNumber, int pageSize)
        {
            DataTable dt = new DataTable();

            try
            {
                Connect();
                string sql = "SELECT * " +
                    "FROM Book " +
                    "WHERE IsVisible = 1 AND Author IS NOT NULL AND Price IS NOT NULL AND BookImage IS NOT NULL " +
                    "ORDER BY BookID " +
                    "OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@Offset", (pageNumber - 1) * pageSize);
                cmd.Parameters.AddWithValue("@PageSize", pageSize);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }
            return dt;
        }

        public int GetTotalRecords()
        {
            try
            {
                string sql = "SELECT COUNT(*) " +
                    "FROM Book " +
                    "WHERE IsVisible = 1 " +
                    "AND Author IS NOT NULL " +
                    "AND Price IS NOT NULL " +
                    "AND BookImage IS NOT NULL ";
                object result = MyExecuteScalar(sql, CommandType.Text);
                return Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetCategories()
        {
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT CategoryID, CategoryName FROM BookCategory ";
                SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable GetBooksByCategory(int pageNumber, int pageSize, string categoryID)
        {
            DataTable dt = new DataTable();

            try
            {
                Connect();

                string sql = "SELECT * FROM Book " +
                    "WHERE CategoryID = @CategoryID " +
                        "AND IsVisible = 1 AND Author IS NOT NULL AND Price IS NOT NULL AND BookImage IS NOT NULL " +
                    "ORDER BY BookID " +
                    "OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@CategoryID", categoryID);
                cmd.Parameters.AddWithValue("@Offset", (pageNumber - 1) * pageSize);
                cmd.Parameters.AddWithValue("@PageSize", pageSize);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }
            return dt;
        }
        public int GetTotalRecordsByCategory(string categoryID)
        {
            try
            {
                string sql = "SELECT COUNT(*) " +
                    "FROM Book " +
                    "WHERE CategoryID = @CategoryID " +
                    "AND IsVisible = 1 AND Author IS NOT NULL AND Price IS NOT NULL AND BookImage IS NOT NULL ";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@CategoryID", categoryID);

                object result = MyExecuteScalar(cmd);
                return Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
