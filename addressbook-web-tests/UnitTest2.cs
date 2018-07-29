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
        public void FirstTest()
        {
            
            driver.Url = "http://localhost/addressbook/";
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys("admin");
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys("secret");
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            //wait.Until(ExpectedConditions.TitleIs("My Store"));
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
