using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("with2", "header", "footer");

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups.Count, newGroups.Count);
                
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("", "", "");

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups.Count, newGroups.Count);
        }

        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData("a'a", "header", "footer");

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}
