using System;
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

            app.Groups.Modify(1, newGroup);

        }
    }
}
