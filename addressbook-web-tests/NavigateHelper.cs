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
    public class NavigateHelper
    {
        public IWebDriver driver;

        public NavigateHelper(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void NavigateToPage(string uri)
        {
            driver.Url = uri;
        }

        public void NavigateToGroupPage()
        {
            driver.FindElement(By.LinkText("GROUPS")).Click();
        }
        
        public void NavigateToCreationContactPage()
        {
            driver.FindElement(By.LinkText("ADD_NEW")).Click();
        }
    }
}
