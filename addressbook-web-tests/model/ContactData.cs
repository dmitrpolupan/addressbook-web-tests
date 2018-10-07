using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace addressbook_web_tests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        [Column(Name = "id"), PrimaryKey]
        public string Id { get; set; }

        [Column(Name = "firstname"), NotNull]
        public string Firstname { get; set; }

        [Column(Name = "middlename"), NotNull]
        public string Middlename { get; set; }

        [Column(Name = "lastname"), NotNull]
        public string LastName { get; set; }

        [Column(Name = "nickname"), NotNull]
        public string Nickname { get; set; }

        [Column(Name = "deprecated")]
        public string Depricated { get; set; }

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

        public override string ToString()
        {
            return "ID=" + Id + ", Firstname=" + Firstname + ", Middlename=" + Middlename + ", Lastname=" + LastName + ", Nickname=" + Nickname;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Id.CompareTo(other.Id);
        }

        public static List<ContactData> GetAllFromDb()
        {
            AddressBookDB db = new AddressBookDB();
            List<ContactData> listFromDB = (from c in db.Contacts.Where(x => x.Depricated == "0000-00-00 00:00:00") select c).ToList();
            db.Close();
            return listFromDB;
        }

    }
}
