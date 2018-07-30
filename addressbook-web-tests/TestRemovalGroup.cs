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
            NavigateToPage("http://localhost/addressbook/");
            Login(new AccountName("admin", "secret"));
            NavigateToGroupPage();
            SelectGroup(1);
            DeleteGroup();
            GoBackToGroupPage();
        } 
    }
}
