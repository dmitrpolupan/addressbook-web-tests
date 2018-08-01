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
        protected IWebDriver driver;
        protected WebDriverWait wait;

        protected LoginHelper loginHelper;
        protected NavigateHelper navigator;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;


        [SetUp]
        public void start()
        {
            ChromeOptions options = new ChromeOptions();
            //options.AddArguments("start-fullscreen");
            driver = new ChromeDriver(options);
            Console.WriteLine(((IHasCapabilities)driver).Capabilities);
            //driver = new InternetExplorerDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Manage().Cookies.DeleteAllCookies();

            loginHelper = new LoginHelper(driver);
            navigator = new NavigateHelper(driver);
            groupHelper = new GroupHelper(driver);
            contactHelper = new ContactHelper(driver);
            
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
        
    }
}
