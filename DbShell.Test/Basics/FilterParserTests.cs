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

        [TestInitialize]
        public void Initialize()
        {
            FilterParserAntlrCore.Initialize();
        }

        [TestMethod]
        public void TestStringFilter()
        {
            StringTrue("'val'", "val");
            StringTrue("'val'", "val1");

            StringTrue("=val", "val");
            StringFalse("=val", "val1");
        }
    }
}
