using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver driver;
        private WebDriverWait wait;


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

        [Test]
        public void TestGroupCreation()
        {
            NavigateToPage("http://localhost/addressbook/");
            Login(new AccountName("admin", "secret"));
            GoToGroupPage();
            InitGroupCreation();
            FillInNewGroup(new GroupData("with all", "header", "footer"));
            SubmitGroupCreation();
            ReturnToGroupPage();
        }

        [Test]
        public void TestContactCreation()
        {
            NavigateToPage("http://localhost/addressbook/");
            Login(new AccountName("admin", "secret"));
            driver.FindElement(By.LinkText("ADD_NEW")).Click();
            InitAddNewContact();
            //--FillInContactCreation(new ContactData("First", "Middle", "Last", "Nickname", "Title", "Company", "Address", new PhoneForContact("555", "666", "777", "123-456"), new SecondaryInfoForContact("address2", "number", "notes")));
            //FillInContactCreation(new ContactData("First", "Middle", "Last", "Nickname", "Title", "Company", "Address", "555", "666", "777", "123-456", "address2", "number", "notes"));
            SubmitContactCreation();

        }

        private void FillInContactCreation(ContactData condata)
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

        private void SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
        }

        private void InitAddNewContact()
        {
            driver.FindElement(By.Name("quickadd")).Click();
        }

        private void ReturnToGroupPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }

        private void SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
        }

        private void FillInNewGroup(GroupData group)
        {
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
        }

        private void InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
        }

        private void GoToGroupPage()
        {
            driver.FindElement(By.LinkText("GROUPS")).Click();
        }

        private void Login(AccountName account)
        {
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(account.Name);
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

        private void NavigateToPage(string uri)
        {
            driver.Url = uri;
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
