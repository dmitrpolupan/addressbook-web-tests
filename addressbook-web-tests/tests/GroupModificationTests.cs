using System;
using System.Collections.Generic;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newGroup = new GroupData("updated_new", null, null);
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Modify(0, newGroup);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newGroup.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups.Count, newGroups.Count);

        }
    }
}
