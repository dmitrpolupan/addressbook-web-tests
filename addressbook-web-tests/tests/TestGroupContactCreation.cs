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
            app.Navigator.NavigateToPage("http://localhost/addressbook/");
            app.Auth.Login(new AccountName("admin", "secret"));
            app.Navigator.NavigateToGroupPage();
            app.Groups.InitGroupCreation();
            app.Groups.FillInNewGroup(new GroupData("with all", "header", "footer"));
            app.Groups.SubmitGroupCreation();
            app.Groups.GoBackToGroupPage();
        }

        [Test]
        public void TestContactCreation()
        {
            app.Navigator.NavigateToPage("http://localhost/addressbook/");
            app.Auth.Login(new AccountName("admin", "secret"));
            app.Navigator.NavigateToCreationContactPage();
            app.Contacts.InitAddNewContact();
            app.Contacts.FillInContactCreation(new ContactData("First", "Middle", "Last", "Nickname", "Title", "Company", "Address", new PhoneForContact("555", "666", "777", "123-456"), new SecondaryInfoForContact("address2", "number", "notes")));
            app.Contacts.SubmitContactCreation();

        }
        
    }
}
