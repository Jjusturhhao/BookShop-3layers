using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace BusinessLayer
{
    public class CustomerBL
    {
        private CustomerDL customerDL;
        public CustomerBL()
        {
            customerDL = new CustomerDL();
        }
        public bool CheckCustomerExist(string phone)
        {
            return customerDL.CheckCustomerExist(phone);
        }
        public void SaveCustomer(string phone, string name)
        {
            customerDL.SaveCustomer(phone, name);
        }
        public Customer GetCustomerByPhone(string phone)
        {
            return customerDL.GetCustomerByPhone(phone);
        }
    }
}
