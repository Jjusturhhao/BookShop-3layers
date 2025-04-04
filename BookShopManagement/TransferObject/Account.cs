using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class Account
    {
        private string user;
        private string pass;

        public string Username { get; set; }
        public string Password { get; set; }

        public Account(string user, string pass)
        {
            this.Username = user;
            this.Password = pass;
        }
    }
}
