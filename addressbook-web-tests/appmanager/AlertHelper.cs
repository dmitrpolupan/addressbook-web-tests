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
    public class AlertHelper : BaseHelper
    {

        public AlertHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void ClickOk()
        {
            driver.SwitchTo().Alert().Accept();
        }
    }
}

