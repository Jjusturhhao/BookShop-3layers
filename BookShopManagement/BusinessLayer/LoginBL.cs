using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using TransferObject;
using System.Data.SqlClient;

namespace BusinessLayer
{
    public class LoginBL
    {
        private LoginDL loginDL;
        public LoginBL()
        {
            loginDL = new LoginDL();
        }

        public string GetUserRole(Account account)
        {
            try
            {
                return loginDL.GetUserRole(account);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
