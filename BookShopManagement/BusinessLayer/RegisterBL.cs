using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using TransferObject;

namespace BusinessLayer
{
    public class RegisterBL
    {
        private RegisterDL registerDL;

        public RegisterBL()
        {
            registerDL = new RegisterDL();
        }

        public bool IsUsernameExist(string username)
        {
            return registerDL.IsUsernameExist(username);
        }

        public bool IsEmailExist(string email)
        {
            return registerDL.IsEmailExist(email);
        }

        public bool IsPhoneExist(string phoneNumber)
        {
            return registerDL.IsPhoneExist(phoneNumber);
        }

        public string GenerateUserId()
        {
            return registerDL.GetNextUserId();
        }

        public bool RegisterNewUser(Info info)
        {
            return registerDL.InsertNewUser(info);
        }
    }
}
