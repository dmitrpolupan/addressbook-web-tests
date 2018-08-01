using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestClass]
    public class TestRemovalGroupClass : TestBase
    {
        [Test]
        public void TestRemovalGroup()
        {
            navigator.NavigateToPage("http://localhost/addressbook/");
            loginHelper.Login(new AccountName("admin", "secret"));
            navigator.NavigateToGroupPage();
            groupHelper.SelectGroup(1);
            groupHelper.DeleteGroup();
            navigator.GoBackToGroupPage();
        } 
    }
}
