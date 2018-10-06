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

            if (isLoggedIn())
            {
                if (isLoggedIn(account))
                {
                    return;
                }

                Logout();
            }
            Type(By.Name("user"), account.Name);
            Type(By.Name("pass"), account.Password);
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

        public void Logout()
        {
            if (isLoggedIn())
            {
                driver.FindElement(By.LinkText("LOGOUT")).Click();
            }
            
        }

        public bool isLoggedIn()
        {
            return isElementPresent(By.Name("logout"));
        }

        public bool isLoggedIn(AccountName account)
        {
            //return isLoggedIn() && driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text 
                //== "(" + account.Name + ")";
            return isLoggedIn() && GetLoggedUserName() == account.Name;
        }

        public string GetLoggedUserName()
        {
            string text = driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text;
            return text.Substring(1, text.Length - 2);
        }
    }
}
