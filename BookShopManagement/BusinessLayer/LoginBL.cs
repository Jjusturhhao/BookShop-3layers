using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using TransferObject;
using System.Data.SqlClient;
using System.Security.Principal;

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

        

        public string GetName(string username)
        {
            try
            {
                return loginDL.GetName(username);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsAccountDeactivated(string username)
        {
            try
            {
                return loginDL.IsAccountDeactivated(username);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
