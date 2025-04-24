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
            string sql = "SELECT Role FROM Users WHERE Username = @Username AND Password = @Password";

            try
            {
                Connect();
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@Username", account.Username);
                    cmd.Parameters.AddWithValue("@Password", account.Password);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        role = result.ToString();
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
            return role;
        }
    }
}
