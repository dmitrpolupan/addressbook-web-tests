using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

namespace addressbook_web_tests
{
    public class LoginHelper : BaseHelper
    {

        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void Login(AccountName account)
        {
            Type(By.Name("user"), account.Name);
            Type(By.Name("pass"), account.Password);
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }
    }
}
