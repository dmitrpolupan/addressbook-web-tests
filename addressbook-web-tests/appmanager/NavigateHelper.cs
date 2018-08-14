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
            if(driver.Url == baseURL + "/addressbook/")
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "/addressbook/");
        }
        public void NavigateToPage1(string baseurl)
        {
            driver.Navigate().GoToUrl(baseurl);
        }

        public void NavigateToGroupPage()
        {
            if(driver.Url == baseURL + "/addressbook/group.php" && isElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("GROUPS")).Click();
        }
        
        public void NavigateToCreationContactPage()
        {
            driver.FindElement(By.LinkText("ADD_NEW")).Click();
        }

        public void NavigateToHomePage()
        {
            driver.FindElement(By.LinkText("HOME")).Click();
        }
    }
}
