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
    public class GroupHelper : BaseHelper
    {
        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }
        
        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.NavigateToGroupPage();

            InitGroupCreation();
            FillInNewGroup(group);
            SubmitGroupCreation();
            GoBackToGroupPage();
            return this;
        }
        
        public List<GroupData> GetGroupList()
        {
            List<GroupData> groups = new List<GroupData>();

            manager.Navigator.NavigateToGroupPage();

            ICollection<IWebElement> elements = driver.FindElements(By.XPath("//input[@name='selected[]']"));
            foreach (IWebElement element in elements)
            {
                GroupData group = new GroupData(element.Text);
                groups.Add(group);
            }

            return groups;
        }

        public GroupHelper Modify(int v, GroupData newGroup)
        {
            manager.Navigator.NavigateToGroupPage();
            if (!isElementPresent(By.XPath("(//input[@name='selected[]'])[1]")))
            {
                GroupData group = new GroupData("any", "test", "todel");
                Create(group);
            }
            SelectGroup(v);
            InitGroupModification();
            FillInNewGroup(newGroup);
            SubmitGroupUpdating();
            GoBackToGroupPage();
            return this;
        }

        public GroupHelper Remove(int v)
        {
            manager.Navigator.NavigateToGroupPage();

            if (!isElementPresent(By.XPath("(//input[@name='selected[]'])[1]")))
            {
                GroupData group = new GroupData("any", "test", "todel");
                Create(group);
            }
            
            SelectGroup(v);
            DeleteGroup();
            GoBackToGroupPage();
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper FillInNewGroup(GroupData group)
        {
            
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper DeleteGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        public GroupHelper GoBackToGroupPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper SubmitGroupUpdating()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
    }
}
