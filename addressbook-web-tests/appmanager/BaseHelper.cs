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
    public class BaseHelper
    {
        protected IWebDriver driver;
        protected ApplicationManager manager;

        public BaseHelper(ApplicationManager manager)
        {
            this.manager = manager;
            driver = manager.Driver;
        }
    }
}