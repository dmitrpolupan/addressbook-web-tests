using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class LoginTestscs : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            app.Auth.Logout();

            AccountName account = new AccountName("admin", "secret");
            app.Auth.Login(account);

            Assert.IsTrue(app.Auth.isLoggedIn(account));
        }

        [Test]
        public void LoginWithInvalidCredentials()
        {
            app.Auth.Logout();

            AccountName account = new AccountName("admin", "12345");
            app.Auth.Login(account);

            Assert.IsFalse(app.Auth.isLoggedIn(account));
        }
    }
}
