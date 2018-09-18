using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class ContactData : IEquatable<ContactData>
    {
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public PhoneForContact PhoneForContact { get; set; }
        public SecondaryInfoForContact SecondaryInfoForContact { get; set; }

        public ContactData() { }

        //public ContactData (string firstname, string middlename, string lastname, string nickname, string title, 
          //  string company, string address, string home, string mobile, string work, string fax,
            //string secondary_address, string number, string notes)
        public ContactData(string firstname, string middlename, string lastname, string nickname, string title,
            string company, string address, PhoneForContact phoneForContact, SecondaryInfoForContact secondaryInfoForContact)
        {
            Firstname = firstname;
            Middlename = middlename;
            LastName = lastname;
            Nickname = nickname;
            Title = title;
            Company = company;
            Address = address;
            PhoneForContact = phoneForContact;
            SecondaryInfoForContact = secondaryInfoForContact;
            //phoneForContact = new PhoneForContact(home, mobile, work, fax);
            //secondaryInfoForContact = new SecondaryInfoForContact(secondary_address, number, notes);
        }

        public bool Equals(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            if(object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname == other.Firstname && LastName == other.LastName;
        }
        
    }
}
