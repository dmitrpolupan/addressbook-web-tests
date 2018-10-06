using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest_deleteElementFromOld()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Remove(0);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(0);
            
            Assert.AreEqual(oldGroups, newGroups);
            
        }

        [Test]
        public void GroupRemovalTest_checkThatNoDeletedById()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Remove(1);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            
            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.ID, oldGroups[1].ID);
            }
        }
    }
}
