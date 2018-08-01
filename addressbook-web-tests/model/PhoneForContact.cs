using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class PhoneForContact
    {
        public string Phone_Home { get; set; }
        public string Phone_Mobile { get; set; }
        public string Phone_Work { get; set; }
        public string Fax { get; set; }

        public PhoneForContact (string home, string mobile, string work, string fax)
        {
            Phone_Home = home;
            Phone_Mobile = mobile;
            Phone_Work = work;
            Fax = fax;
        }
    }
}
