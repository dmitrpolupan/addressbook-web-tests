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
            app.Navigator.NavigateToPage("http://localhost/addressbook/");
            app.Auth.Login(new AccountName("admin", "secret"));
            app.Navigator.NavigateToGroupPage();
            app.Groups.SelectGroup(1);
            app.Groups.DeleteGroup();
            app.Groups.GoBackToGroupPage();
        } 
    }
}
