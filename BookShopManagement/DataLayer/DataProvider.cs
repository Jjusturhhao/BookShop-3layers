using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DataProvider
    {
        public SqlConnection cn;
        SqlCommand cmd;
        public DataProvider()
        {
            string cnStr = "Data Source=.;Initial Catalog=BookStoreManagement;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            cn = new SqlConnection(cnStr);
        }

        public void Connect()
        {
            try
            {
                if (cn != null && cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void DisConnect()
        {
            try
            {
                if (cn != null && cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        // cmd.ExecuteScalar
        public object MyExecuteScalar(string sql, CommandType type)
        {
            try
            {
                Connect();
                cmd = new SqlCommand(sql, cn);
                cmd.CommandType = type;

                return (cmd.ExecuteScalar());
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

        //Dùng bên Homepage
        public object MyExecuteScalar(SqlCommand cmd)
        {
            try
            {
                Connect();
                cmd.Connection = cn;
                return cmd.ExecuteScalar();
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

        public SqlDataReader MyExecuteReader(string sql, CommandType type)
        {
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.CommandType = type;
            try
            {
                return (cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
<<<<<<< HEAD
=======

>>>>>>> 37b1c8cac08c8331ca154c9259dd089cebecfeea
        public int MyExecuteNonQuery(string sql, CommandType type)
        {
            try
            {
                Connect();
<<<<<<< HEAD
                cmd = new SqlCommand(sql, cn);
                cmd.CommandType = type;

                return (cmd.ExecuteNonQuery());
            }
            catch (Exception ex)
=======
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.CommandType = type;
                return cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
>>>>>>> 37b1c8cac08c8331ca154c9259dd089cebecfeea
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }
        }
<<<<<<< HEAD
=======

        public int MyExecuteNonQuery(SqlCommand cmd)
        {
            try
            {
                Connect();
                cmd.Connection = cn;
                return cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }
        }


>>>>>>> 37b1c8cac08c8331ca154c9259dd089cebecfeea
    }
}
