﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace DataLayer
{
    public class CheckoutDL : DataProvider
    {
        public DataTable GetBooks()
        {
            DataTable dt = new DataTable();

            try
            {
                Connect();

                string sql = "SELECT * FROM Book ORDER BY BookID";
                SqlCommand cmd = new SqlCommand(sql, cn);
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
        public DataTable GetBooksByName(string kw)
        {
            DataTable dt = new DataTable();

            try
            {
                Connect();

                string sql = "SELECT * " +
                    "FROM Book " +
                    "WHERE BookName LIKE @kw " +
                    "ORDER BY BookID ";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@kw", "%" + kw + "%");
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
        public int GetQuantity(string bookID)
        {
            
            try
            {
                Connect();

                string sql = "GetStockQuantity ";  // Tên của stored procedure
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.CommandType = CommandType.StoredProcedure;  
                cmd.Parameters.AddWithValue("@BookID", bookID);  

                object result = cmd.ExecuteScalar();
                return Convert.ToInt32(result);  
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
