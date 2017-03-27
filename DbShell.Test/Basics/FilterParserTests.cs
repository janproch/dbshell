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
        private bool TestCondition(FilterParserTool.ExpressionType type, string condition, string testedString)
        {
            var cond = FilterParserTool.ParseFilterExpression(type, new DmlfPlaceholderExpression(), condition);
            var ns = new DmlfSingleValueNamespace(testedString);
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
    }
}
