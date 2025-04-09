using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class Supplier
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public Supplier(string id, string name, string address, string email, string phone)
        {
            ID = id;
            Name = name;
            Address = address;
            Email = email;
            Phone = phone;
        }
    }
}
