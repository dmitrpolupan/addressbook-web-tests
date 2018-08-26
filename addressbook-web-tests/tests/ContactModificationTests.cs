using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newContact = new ContactData("Up_First", "Up_Middle", "Up_Last", "Up_Nickname", "Up_Title", "Up_Company", "Up_Address", new PhoneForContact("00555", "00666", "00777", "00123-456"), new SecondaryInfoForContact("Up_address2", "Up_number", "Up_notes"));

            app.Contacts.Modify(1, newContact);
        }
    }
}