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

        private List<GroupData> groupCash = null;

        public List<GroupData> GetGroupList()
        {
            if (groupCash == null)
            {
                groupCash = new List<GroupData>();
                manager.Navigator.NavigateToGroupPage();

                //ICollection<IWebElement> elements = driver.FindElements(By.XPath("//input[@name='selected[]']"));
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//input[@type='checkbox']"));
                //ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("div#content br"));
                foreach (IWebElement element in elements)
                {
                    groupCash.Add(new GroupData(element.Text)
                    {
                        ID = element.GetAttribute("value")
                    });


                }
            }
            
            return new List<GroupData>(groupCash);
        }

        public List<GroupData> GetGroupListFROMVIDEO_neSovsemRabotaet()
        {
            if (groupCash == null)
            {
                groupCash = new List<GroupData>();
                manager.Navigator.NavigateToGroupPage();

                //ICollection<IWebElement> elements = driver.FindElements(By.XPath("//input[@name='selected[]']"));
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//input[@type='checkbox']"));
                //ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("div#content br"));
                //ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("div#content input"));
                foreach (IWebElement element in elements)
                {
                    // groupCash.Add(new GroupData(element.Text)
                    groupCash.Add(new GroupData(null)
                    {
                        ID = driver.FindElement(By.XPath("//input[@type='checkbox']")).GetAttribute("value")
                    });

                    string allGroupNames = driver.FindElement(By.CssSelector("div#content form")).Text;
                    string[] res = allGroupNames.Split('\n');

                    int shift = groupCash.Count - res.Length;

                    for (int i = 0; i < res.Length - 1; i++)
                    {
                        if (i > shift)
                        {
                            res[i] = res[i].Substring(0, res[i].Length - 1);
                        }

                    }

                    for (int i = 0; i < groupCash.Count; i++)
                    {
                        if (i < shift)
                        {
                            groupCash[i].Name = "";
                        }
                        else
                        {
                            groupCash[i].Name = res[i];
                        }

                    }

                }
            }

            return new List<GroupData>(groupCash);
        }


        public int GetGroupCount()
        {
            return driver.FindElements(By.XPath("//input[@type='checkbox']")).Count;
            //return driver.FindElements(By.CssSelector("div#content br")).Count;
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

            if (!isElementPresent(By.XPath("(//input[@name='selected[]'])[" + (v+1) + "]")))
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
            groupCash = null;
            return this;
        }

        public GroupHelper DeleteGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCash = null;
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
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
            groupCash = null;
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
    }
}
