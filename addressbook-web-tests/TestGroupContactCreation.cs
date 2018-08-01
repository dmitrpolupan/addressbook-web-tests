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
            navigator.NavigateToPage("http://localhost/addressbook/");
            loginHelper.Login(new AccountName("admin", "secret"));
            navigator.NavigateToGroupPage();
            groupHelper.InitGroupCreation();
            groupHelper.FillInNewGroup(new GroupData("with all", "header", "footer"));
            groupHelper.SubmitGroupCreation();
            navigator.GoBackToGroupPage();
        }

        [Test]
        public void TestContactCreation()
        {
            navigator.NavigateToPage("http://localhost/addressbook/");
            loginHelper.Login(new AccountName("admin", "secret"));
            navigator.NavigateToCreationContactPage();
            contactHelper.InitAddNewContact();
            contactHelper.FillInContactCreation(new ContactData("First", "Middle", "Last", "Nickname", "Title", "Company", "Address", new PhoneForContact("555", "666", "777", "123-456"), new SecondaryInfoForContact("address2", "number", "notes")));
            contactHelper.SubmitContactCreation();

        }
        
    }
}
