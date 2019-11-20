using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyBuddyShared.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class EnumTest
    {
        public enum enum1 
        { 
            Success,
            Failure,
            Unknown
        }

        public enum enum2
        {
            Success,
            Failure,
            Unknown,
            Feilas
        }
        [TestMethod]
        public void ConvertEnumTest()
        {
            Assert.AreEqual(EnumConverter.Convert<enum2>(enum1.Unknown), enum2.Unknown);
            Assert.AreNotEqual(EnumConverter.Convert<enum1>(enum1.Unknown), enum2.Unknown);
        }
    }
}
