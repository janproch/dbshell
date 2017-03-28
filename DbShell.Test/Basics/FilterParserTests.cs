using DbShell.Driver.Common.DmlFramework;
using DbShell.Driver.Common.Utility;
using DbShell.FilterParser.Antlr;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.Test.Basics
{
    [TestClass]
    public class FilterParserTests
    {
        private bool TestCondition(FilterParserTool.ExpressionType type, string condition, object testedValue)
        {
            var cond = FilterParserTool.ParseFilterExpression(type, new DmlfPlaceholderExpression(), condition);
            var ns = new DmlfSingleValueNamespace(testedValue);
            Assert.IsNotNull(cond, $"Error parsing condition {condition}");
            return cond.EvalCondition(ns);
        }

        private void StringTrue(string condition, string testedString)
        {
            Assert.IsTrue(TestCondition(FilterParserTool.ExpressionType.String, condition, testedString));
        }

        private void StringFalse(string condition, string testedString)
        {
            Assert.IsFalse(TestCondition(FilterParserTool.ExpressionType.String, condition, testedString));
        }

        private void NumberTrue(string condition, string testedString)
        {
            Assert.IsTrue(TestCondition(FilterParserTool.ExpressionType.Number, condition, testedString));
        }

        private void NumberFalse(string condition, string testedString)
        {
            Assert.IsFalse(TestCondition(FilterParserTool.ExpressionType.Number, condition, testedString));
        }

        private void DateTimeTrue(string condition, DateTime value, bool stringTest=true)
        {
            Assert.IsTrue(TestCondition(FilterParserTool.ExpressionType.DateTime, condition, value));
            if (stringTest)
            {
                Assert.IsTrue(TestCondition(FilterParserTool.ExpressionType.DateTime, condition, value.ToString("s")));
            }
        }

        private void DateTimeFalse(string condition, DateTime value, bool stringTest = true)
        {
            Assert.IsFalse(TestCondition(FilterParserTool.ExpressionType.DateTime, condition, value));
            if (stringTest)
            {
                Assert.IsFalse(TestCondition(FilterParserTool.ExpressionType.DateTime, condition, value.ToString("s")));
            }
        }

        private void LogicalTrue(string condition, string testedString)
        {
            Assert.IsTrue(TestCondition(FilterParserTool.ExpressionType.Logical, condition, testedString));
        }

        private void LogicalFalse(string condition, string testedString)
        {
            Assert.IsFalse(TestCondition(FilterParserTool.ExpressionType.Logical, condition, testedString));
        }

        [TestInitialize]
        public void Initialize()
        {
            //FilterParserAntlrCore.Initialize();
        }

        [TestMethod]
        public void TestStringFilter()
        {
            StringTrue("'val'", "val");
            StringTrue("'val'", "val1");

            StringTrue("=val", "val");
            StringFalse("=val", "val1");

            StringFalse("^1 $3", "124");
            StringTrue("^1 $3", "123");
            StringTrue("^1, $3", "124");

            StringTrue("EMPTY, NULL", "   ");
            StringFalse("NOT EMPTY", "   ");
        }

        [TestMethod]
        public void TestNumberFilter()
        {
            NumberTrue("='1'", "1");
            NumberTrue("=1", "1");
            NumberTrue("1", "1");
            NumberFalse("3", "1");

            NumberTrue(">=1 <=3", "2");
            NumberFalse(">=1 <=3", "4");

            NumberTrue("1-4", "4");
            NumberFalse("1-4", "5");

            NumberTrue("1,2,3", "3");
            NumberFalse("1,2,3", "4");

            NumberTrue("-5--1", "-3");
            NumberFalse("-5--1", "-6");
        }

        [TestMethod]
        public void TestDateTimeFilter()
        {
            DateTimeTrue("TODAY", DateTime.Now);
            DateTimeTrue("YESTERDAY", DateTime.Now.AddDays(-1));
            DateTimeTrue("TOMORROW", DateTime.Now.AddDays(1));

            DateTimeFalse("TODAY", DateTime.Now.AddDays(-1));
            DateTimeFalse("YESTERDAY", DateTime.Now.AddDays(1));
            DateTimeFalse("TOMORROW", DateTime.Now);

            DateTimeTrue("NEXT WEEK, TODAY", DateTime.Now.AddDays(7));
            DateTimeTrue("NEXT WEEK, TODAY", DateTime.Now);
            DateTimeFalse("NEXT WEEK, TODAY", DateTime.Now.AddDays(-1));

            DateTimeTrue("1.3.2016", new DateTime(2016, 3, 1));
            DateTimeTrue("2016-03-01", new DateTime(2016, 3, 1));
            DateTimeTrue("3/1/2016", new DateTime(2016, 3, 1));

            DateTimeTrue("1.3. 10:01", new DateTime(DateTime.Now.Year, 3, 1, 10, 1, 30));
            DateTimeFalse("1.3. 10:01", new DateTime(DateTime.Now.Year, 3, 1, 10, 0, 30));
            DateTimeTrue("1.3. 10:*", new DateTime(DateTime.Now.Year, 3, 1, 10, 25, 0));

            DateTimeTrue("MON", new DateTime(2017, 3, 27));
            DateTimeTrue("2017", new DateTime(2017, 3, 27));
            DateTimeTrue("MON 2017", new DateTime(2017, 3, 27));
            DateTimeFalse("MON 2017", new DateTime(2017, 3, 28));
            DateTimeTrue("2017 JAN", new DateTime(2017, 1, 28));

            DateTimeTrue("2016-03-05 15:23:33", new DateTime(2016, 3, 5, 15, 23, 33, 35));
            DateTimeTrue("2016-03-05 15:23:33.35", new DateTime(2016, 3, 5, 15, 23, 33, 350), false);
            DateTimeFalse("2016-03-05 15:23:33.35", new DateTime(2016, 3, 5, 15, 23, 33, 35));
            DateTimeTrue("2016-03-05 15:23", new DateTime(2016, 3, 5, 15, 23, 46));
            DateTimeFalse("2016-03-05 15:23", new DateTime(2016, 3, 5, 15, 24, 0));

            DateTimeTrue(">=2016-03-05 15:23", new DateTime(2016, 3, 5, 15, 23, 46));
            DateTimeFalse(">2016-03-05 15:23", new DateTime(2016, 3, 5, 15, 23, 46));
        }

        [TestMethod]
        public void TestLogicalFilter()
        {
            LogicalTrue("TRUE", "1");
            LogicalTrue("1", "1");
            LogicalTrue("FALSE", "0");
            LogicalTrue("0", "0");

            LogicalFalse("TRUE", "0");
        }

    }
}