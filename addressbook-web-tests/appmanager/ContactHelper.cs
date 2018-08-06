using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

namespace addressbook_web_tests
{
    public class ContactHelper : BaseHelper
    {

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.NavigateToCreationContactPage();

            InitAddNewContact();
            FillInContactCreation(contact);
            SubmitContactCreation();
            return this;
        }

        public ContactHelper Remove(int v)
        {
            manager.Navigator.NavigateToHomePage();

            SelectContact(v);
            //InitContactModification(v);
            DeleteContact();
            manager.Alerter.ClickOk();
            return this;
        }

        
        public ContactHelper InitAddNewContact()
        {
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            return this;
        }

        public ContactHelper FillInContactCreation(ContactData condata)
        {
            Type(By.Name("firstname"), condata.Firstname);
            Type(By.Name("middlename"), condata.Middlename);
            Type(By.Name("lastname"), condata.LastName);
            Type(By.Name("nickname"), condata.Nickname);
            Type(By.Name("title"), condata.Title);
            Type(By.Name("company"), condata.Company);
            Type(By.Name("address"), condata.Address);
            Type(By.Name("home"), condata.PhoneForContact.Phone_Home);
            Type(By.Name("mobile"), condata.PhoneForContact.Phone_Mobile);
            Type(By.Name("work"), condata.PhoneForContact.Phone_Work);
            Type(By.Name("fax"), condata.PhoneForContact.Fax);
            Type(By.Name("address2"), condata.SecondaryInfoForContact.Secondary_Address);
            Type(By.Name("phone2"), condata.SecondaryInfoForContact.Secondary_Phone_number);
            Type(By.Name("notes"), condata.SecondaryInfoForContact.Notes);
            
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("(//input[@value='DELETE'])")).Click();
            return this;
        }
        //не работает
        public ContactHelper InitContactModification(int v)
        {
            driver.FindElement(By.LinkText("edit.php?id=" + v)).Click();
            return this;
        }

        public ContactHelper SelectContact(int v)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + v + "]")).Click();
            return this;
        }
        
    }
}
