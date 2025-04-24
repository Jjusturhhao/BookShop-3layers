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
    public class RegisterDL : DataProvider
    {
        public bool IsUsernameExist(string username)
        {
            string sql = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
            try
            {
                Connect();
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
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

        public bool IsEmailExist(string email)
        {
            string sql = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
            try
            {
                Connect();
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
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

        public bool IsPhoneExist(string phoneNumber)
        {
            string sql = "SELECT COUNT(*) FROM Users WHERE PhoneNumber = @PhoneNumber";
            try
            {
                Connect();
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
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

        public string GetNextUserId()
        {
            string sql = "SELECT MAX(CAST(SUBSTRING(User_ID, 2, LEN(User_ID) - 1) AS INT)) FROM Users WHERE User_ID LIKE 'C%'";
            try
            {
                Connect();
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    object result = cmd.ExecuteScalar();
                    int nextId = (result != DBNull.Value) ? Convert.ToInt32(result) + 1 : 1;
                    return "C" + nextId;
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

        public bool InsertNewUser(Info info)
        {
            string sql = "INSERT INTO Users (User_ID, Name, Username, Password, Email, Address, PhoneNumber, Role) " +
                         "VALUES (@User_ID, @Name, @Username, @Password, @Email, @Address, @PhoneNumber, 'Customer')";
            try
            {
                Connect();
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@User_ID", info.User_ID);
                    cmd.Parameters.AddWithValue("@Name", info.Name);
                    cmd.Parameters.AddWithValue("@Username", info.Username);
                    cmd.Parameters.AddWithValue("@Password", info.Pass);
                    cmd.Parameters.AddWithValue("@Email", info.Email);
                    cmd.Parameters.AddWithValue("@Address", info.Address);
                    cmd.Parameters.AddWithValue("@PhoneNumber", info.Phone);

                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
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
