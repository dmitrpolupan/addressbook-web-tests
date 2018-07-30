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
            NavigateToPage("http://localhost/addressbook/");
            Login(new AccountName("admin", "secret"));
            NavigateToGroupPage();
            InitGroupCreation();
            FillInNewGroup(new GroupData("with all", "header", "footer"));
            SubmitGroupCreation();
            GoBackToGroupPage();
        }

        [Test]
        public void TestContactCreation()
        {
            NavigateToPage("http://localhost/addressbook/");
            Login(new AccountName("admin", "secret"));
            NavigateToCreationContactPage();
            InitAddNewContact();
            FillInContactCreation(new ContactData("First", "Middle", "Last", "Nickname", "Title", "Company", "Address", new PhoneForContact("555", "666", "777", "123-456"), new SecondaryInfoForContact("address2", "number", "notes")));
            SubmitContactCreation();

        }
        
    }
}
