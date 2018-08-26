using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("First", "Middle", "Last", "Nickname", "Title", "Company", "Address", new PhoneForContact("555", "666", "777", "123-456"), new SecondaryInfoForContact("address2", "number", "notes"));

            app.Contacts.Create(contact);
        }
    }
}
