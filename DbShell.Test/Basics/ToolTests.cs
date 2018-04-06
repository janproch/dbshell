using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Utility;
using Xunit;

namespace DbShell.Test
{
    public class ToolTests
    {
        [Fact]
        public void TestDateTimeParse()
        {
            Assert.Equal(new DateTime(2014, 1, 15), StringTool.DateTimeFromString("2014-01-15"));
            Assert.Equal(new DateTime(2014, 1, 15, 10, 45, 0), StringTool.DateTimeFromString("2014-1-15 10:45"));
        }
    }
}
