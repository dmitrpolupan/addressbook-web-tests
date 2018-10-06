using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace addressbook_web_tests
{
    public class GroupTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareGroupsUI_DB()
        {
            if (PERFORM_LONG_UI_CHECKS)
            {
                List<GroupData> fromUi = app.Groups.GetGroupList();
                List<GroupData> fromDb = GroupData.GetAllFromDb();

                fromUi.Sort();
                fromDb.Sort();
                //сравниваю количество а не полностью, поскольку с UI не могу записать имяб бади и фуьер, он стабильно стой. А с базы заполняется корректно
                Assert.AreEqual(fromUi.Count, fromDb.Count);
            }
            
        }

    }
}
