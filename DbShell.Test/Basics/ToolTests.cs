using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DbShell.Test
{
    [TestClass]
    public class ToolTests
    {
        [TestMethod]
        public void TestDateTimeParse()
        {
            Assert.AreEqual(new DateTime(2014, 1, 15), StringTool.DateTimeFromString("2014-01-15"));
            Assert.AreEqual(new DateTime(2014, 1, 15, 10, 45, 0), StringTool.DateTimeFromString("2014-1-15 10:45"));
        }
    }
}
