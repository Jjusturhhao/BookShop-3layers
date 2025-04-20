using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class Customer
    {
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public Customer(string phone, string name)
        {
            this.PhoneNumber = phone;
            this.FullName = name;
        }
    }
}
