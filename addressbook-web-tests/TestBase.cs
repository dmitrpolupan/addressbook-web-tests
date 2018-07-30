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

        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }

        protected void NavigateToPage(string uri)
        {
            driver.Url = uri;
        }

        protected void Login(AccountName account)
        {
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(account.Name);
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

        protected void NavigateToGroupPage()
        {
            driver.FindElement(By.LinkText("GROUPS")).Click();
        }

        protected void InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
        }

        protected void FillInNewGroup(GroupData group)
        {
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
        }

        protected void SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
        }

        protected void GoBackToGroupPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }

        protected void DeleteGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
        }

        protected void SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
        }

        protected void InitAddNewContact()
        {
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

        protected void NavigateToCreationContactPage()
        {
            driver.FindElement(By.LinkText("ADD_NEW")).Click();
        }

        protected void FillInContactCreation(ContactData condata)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(condata.Firstname);
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(condata.Middlename);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(condata.LastName);
            driver.FindElement(By.Name("nickname")).Clear();
            driver.FindElement(By.Name("nickname")).SendKeys(condata.Nickname);
            driver.FindElement(By.Name("title")).Clear();
            driver.FindElement(By.Name("title")).SendKeys(condata.Title);
            driver.FindElement(By.Name("company")).Clear();
            driver.FindElement(By.Name("company")).SendKeys(condata.Company);
            driver.FindElement(By.Name("address")).Clear();
            driver.FindElement(By.Name("address")).SendKeys(condata.Address);
            driver.FindElement(By.Name("home")).Clear();
            driver.FindElement(By.Name("home")).SendKeys(condata.PhoneForContact.Phone_Home);
            driver.FindElement(By.Name("mobile")).Clear();
            driver.FindElement(By.Name("mobile")).SendKeys(condata.PhoneForContact.Phone_Mobile);
            driver.FindElement(By.Name("work")).Clear();
            driver.FindElement(By.Name("work")).SendKeys(condata.PhoneForContact.Phone_Work);
            driver.FindElement(By.Name("fax")).Clear();
            driver.FindElement(By.Name("fax")).SendKeys(condata.PhoneForContact.Fax);
            driver.FindElement(By.Name("address2")).Clear();
            driver.FindElement(By.Name("address2")).SendKeys(condata.SecondaryInfoForContact.Secondary_Address);
            driver.FindElement(By.Name("phone2")).Clear();
            driver.FindElement(By.Name("phone2")).SendKeys(condata.SecondaryInfoForContact.Secondary_Phone_number);
            driver.FindElement(By.Name("notes")).Clear();
            driver.FindElement(By.Name("notes")).SendKeys(condata.SecondaryInfoForContact.Notes);
        }

        protected void SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
        }
    }
}
