using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

namespace addressbook_web_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        protected string baseURL;

        protected LoginHelper loginHelper;
        protected NavigateHelper navigator;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;
        protected AlertHelper alerter;

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            ChromeOptions options = new ChromeOptions();
            ////options.AddArguments("start-fullscreen");
            driver = new ChromeDriver(options);
            Console.WriteLine(((IHasCapabilities)driver).Capabilities);
            ////driver = new InternetExplorerDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Manage().Cookies.DeleteAllCookies();

            baseURL = "http://localhost";

            loginHelper = new LoginHelper(this);
            navigator = new NavigateHelper(this, baseURL);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
            alerter = new AlertHelper(this);
        }

        ~ApplicationManager()
        {
            driver.Quit();
            driver = null;
        }

        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigator.NavigateToPage();
                //newInstance.Navigator.NavigateToPage1("http://localhost/addressbook/");
                app.Value = newInstance;
                
            }
            return app.Value;
        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }



        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }
        }

        public NavigateHelper Navigator
        {
            get
            {
                return navigator;
            }
        }

        public GroupHelper Groups
        {
            get
            {
                return groupHelper;
            }
        }

        public ContactHelper Contacts
        {
            get
            {
                return contactHelper;
            }
        }

        public AlertHelper Alerter
        {
            get
            {
                return alerter;
            }
        }

    }
}
