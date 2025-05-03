using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;
using System.Data.SqlClient;

namespace DataLayer
{
    public class LoginDL:DataProvider
    {
        public string GetUserRole(Account account)
        {
            string role = null;
            string sql = @"SELECT Role 
                   FROM Users 
                   WHERE Username = @Username 
                     AND Password = @Password 
                     AND IsActive = 1";

            try
            {
                Connect();
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@Username", account.Username);
                    cmd.Parameters.AddWithValue("@Password", account.Password);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                        role = result.ToString();
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
            return role;
        }

        public bool IsAccountDeactivated(string username)
        {
            string sql = "SELECT IsActive FROM Users WHERE Username = @username";
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@username", username);

                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToInt32(result) == 0; // IsActive = 0 nghĩa là bị vô hiệu hóa
                }
                return false; // Nếu không tìm thấy thì coi như không bị vô hiệu hóa
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


        public string GetName(string username)
        {
            string name = null;
            string sql = "SELECT Name FROM Users WHERE Username = @Username";

            try
            {
                Connect();
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        name = result.ToString();
                    }
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
            return name;
        }
    }
}
