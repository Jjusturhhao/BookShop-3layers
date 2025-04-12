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
    }
}
