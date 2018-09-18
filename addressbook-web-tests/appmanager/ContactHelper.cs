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
            SubmitContactCreating();
            return this;
        }

        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();

            ICollection<IWebElement> elements = driver.FindElements(By.XPath("(//tr[@name='entry'])"));

            foreach(IWebElement element in elements)
            {
                string stroka = element.Text;
                string[] words = stroka.Split(new char[] { ' ' });
                
                ContactData contact = new ContactData();
                contact.Firstname = words[2];
                contact.LastName = words[1];
                contacts.Add(contact);
            }

            return contacts;
        }

        internal ContactHelper Modify(int v, ContactData newContact)
        {
            manager.Navigator.NavigateToHomePage();
            if (!isElementPresent(By.XPath("(//input[@name='selected[]'])[1]")))
            {
                ContactData cont = new ContactData("t1", "t1", "t1", "t1", "t1", "t1", "t1", new PhoneForContact("t1", "t1", "t1", "t1"), new SecondaryInfoForContact("t1", "t1", "t1"));
                Create(cont);
            }
            InitContactModification(v);
            FillInContactCreation(newContact);
            SubmitContactUpdating();
            return this;
        }
        

        public ContactHelper Remove(int v)
        {
            manager.Navigator.NavigateToHomePage();
            if (!isElementPresent(By.XPath("(//input[@name='selected[]'])[1]")))
            {
                ContactData cont = new ContactData("t1", "t1", "t1", "t1", "t1", "t1", "t1", new PhoneForContact("t1", "t1", "t1", "t1"), new SecondaryInfoForContact("t1", "t1", "t1"));
                Create(cont);
            }
            SelectContact(v);
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

        public ContactHelper SubmitContactCreating()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("(//input[@value='DELETE'])")).Click();
            return this;
        }
        
        public ContactHelper InitContactModification(int v)
        {
            int a = v + 1;
            driver.FindElement(By.XPath("(//table[@id='maintable']//tr[" + a + "]/td[8]/a)")).Click();
            return this;
        }

        public ContactHelper SelectContact(int v)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (v+1) + "]")).Click();
            return this;
        }

        private ContactHelper SubmitContactUpdating()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

    }
}
