using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    class SecondaryInfoForContact
    {
        public string Secondary_Address { get; set; }
        public string Secondary_Phone_number { get; set; }
        public string Notes { get; set; }

        public SecondaryInfoForContact(string address, string number, string notes)
        {
            Secondary_Address = address;
            Secondary_Phone_number = number;
            Notes = notes;
        }
    }
}
