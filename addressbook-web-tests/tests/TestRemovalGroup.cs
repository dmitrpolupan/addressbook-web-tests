using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestClass]
    public class TestRemovalGroupClass : TestBase
    {
        [Test]
        public void TestRemovalGroup()
        {
            app.Groups.Remove(2);
       } 
    }
}
