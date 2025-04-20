using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class Employee
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public Employee(string iD, string name, string username, string password, string email, string address, string phone)
        {
            ID = iD;
            Name = name;
            Username = username;
            Password = password;
            Email = email;
            Address = address;
            Phone = phone;
        }
    }
}
