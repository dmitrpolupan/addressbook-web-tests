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
    public class TestBase
    {

        protected ApplicationManager app;

        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
            
        }



    }
}
