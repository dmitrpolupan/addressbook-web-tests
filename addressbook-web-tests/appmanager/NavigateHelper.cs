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
    public class NavigateHelper : BaseHelper
    {
        private string baseURL;
        
        public NavigateHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void NavigateToPage()
        {
            driver.Navigate().GoToUrl(baseURL + "/addressbook/");
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
