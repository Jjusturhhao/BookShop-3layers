using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class Info
    {
        private string user;
        private string name;
        private string pass;
        private string address;
        private string phone;
        private string email;

        public string Username { get; set; }
        public string Name { get; set; }
        public string Pass { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Info(string username, string name, string pass, string address, string phone, string email)
        {
            Username = username;
            Name = name;
            Pass = pass;
            Address = address;
            Phone = phone;
            Email = email;
        }
    }
}

