using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;
using NUnit.Framework;

namespace addressbook_web_tests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void AddingContactToGroupTest()
        {
            GroupData group = GroupData.GetAllFromDb()[0];

            List<ContactData> oldList = group.GetContacts();

            ContactData contactMit = ContactData.GetAllFromDb().Except(oldList).ElementAtOrDefault(129);
            ContactData contact = ContactData.GetAllFromDb().Except(oldList).First();

            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);

        }

    }
}
