using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace addressbook_web_tests
{
    [Table(Name = "group_list")]
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        /*private string name;
        private string header = "";
        private string footer = "";

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Header
        {
            get
            {
                return header;
            }
            set
            {
                header = value;
            }
        }
        public string Footer
        {
            get
            {
                return footer;
            }
            set
            {
                footer = value;
            }
        }*/
        [Column(Name= "group_name"), NotNull]
        public string Name { get; set; }

        [Column(Name = "group_header"), NotNull]
        public string Header { get; set; }

        [Column(Name = "group_footer"), NotNull]
        public string Footer { get; set; }

        [Column(Name = "group_id"), PrimaryKey, Identity, NotNull]
        public string ID { get; set; }

        public GroupData()
        {
            
        }

        public GroupData(string name)
        {
            Name = name;
        }
        public GroupData(string name, string header, string footer)
        {
            Name = name;
            Header = header;
            Footer = footer;
        }

        public bool Equals(GroupData other)
        {
            if(Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if(Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return "name=" + Name + "\n header= " + Header + "\n footer=" + Footer;
        }

        public int CompareTo(GroupData other)
        {
            if(Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }

        public static List<GroupData> GetAllFromDb()
        {
            AddressBookDB db = new AddressBookDB();
            List<GroupData> listFromDB = (from g in db.Groups select g).ToList();
            db.Close();
            return listFromDB;
        }

        public List<ContactData> GetContacts()
        {
            AddressBookDB db = new AddressBookDB();
            List<ContactData> contactsForGroup = (from c in db.Contacts
                                                    from gct in db.GroupContactRel.Where(p => p.GroupID == ID 
                                                        && p.ContactID == c.Id && c.Depricated == "0000-00-00 00:00:00")
                                                            select c).Distinct().ToList();
            db.Close();
            return contactsForGroup;
        }
      
    }
}
