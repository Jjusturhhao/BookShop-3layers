using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace BusinessLayer
{
    public class InfoBL
    {
        private InfoDL infoDL;
        public InfoBL()
        {
            infoDL = new InfoDL();
        }

        public Info GetUserInfo(string username)
        {
            try
            {
                return infoDL.GetUserInfo(username);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateUserInfo(Info updatedInfo)
        {
            try
            {
                return infoDL.UpdateUserInfo(updatedInfo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckCurrentPassword(string username, string currentPassword)
        {
            try
            {
                Info user = infoDL.GetUserInfo(username);
                if (user != null)
                {
                    return user.Pass == currentPassword;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ChangePassword(string username, string newPassword)
        {
            try
            {
                return infoDL.ChangeUserPassword(username, newPassword);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Info GetUserInfoByPhone(string phone)
        {
            try
            {
                return infoDL.GetUserInfoByPhone(phone);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
