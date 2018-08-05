using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestClass]
    public class TestGroupContactCreation : TestBase
    {
        [Test]
        public void TestGroupCreation()
        {
            GroupData group = new GroupData("with al", "header", "footer");

            app.Groups.Create(group);
                
        }

        [Test]
        public void EmptyTestGroupCreation()
        {
            GroupData group = new GroupData("", "", "");
            
            app.Groups.Create(group);
        }

        [Test]
        public void TestContactCreation()
        {
            app.Navigator.NavigateToCreationContactPage();
            app.Contacts.InitAddNewContact();
            app.Contacts.FillInContactCreation(new ContactData("First", "Middle", "Last", "Nickname", "Title", "Company", "Address", new PhoneForContact("555", "666", "777", "123-456"), new SecondaryInfoForContact("address2", "number", "notes")));
            app.Contacts.SubmitContactCreation();

        }
        
    }
}
