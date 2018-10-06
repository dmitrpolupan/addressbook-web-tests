using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class AccountName
    {
        
        public string Name { get; set; }
        
        public string Password { get; set; }


        public AccountName(string name, string password)
        {
            Name = name;
            Password = password;
        }

    }
}
