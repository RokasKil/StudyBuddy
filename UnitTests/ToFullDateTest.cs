using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyBuddyShared.Utility.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class ToFullDateTest
    {
        [TestMethod]
        public void DateTest()
        {
            var dateTime = DateTime.Now;
            Assert.AreEqual(dateTime.ToString("yyyy-MM-dd HH:mm:ss"), dateTime.ToFullDate());
        }
    }
}
