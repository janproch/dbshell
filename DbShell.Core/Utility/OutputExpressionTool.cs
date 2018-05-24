using DbShell.Driver.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbShell.Core.Utility
{
    public static class OutputExpressionTool
    {
        public static IColumnMapping ParseOutputExpression(string expression, string name)
        {
            if (string.IsNullOrEmpty(expression))
            {
                return null;
            }

            if (expression.StartsWith("'") && expression.EndsWith("'"))
            {
                return new MapValue
                {
                    Name = name,
                    Value = expression.Substring(1, expression.Length - 2),
                };
            }

            if (expression == "(NULL)")
            {
                return new MapNull
                {
                    Name = name,
                };
            }

            if (expression == "(SKIP)")
            {
                return null;
            }

            if (expression.StartsWith("#>"))
            {
                return new MapRowNumber
                {
                    Name = name,
                    StartFrom = int.Parse(expression.Substring(2)),
                };
            }

            if (expression.StartsWith("[") && expression.EndsWith("]"))
            {
                return new MapColumn
                {
                    OutputName = name,
                    Name = expression.Substring(1, expression.Length - 2),
                };
            }

            return null;
            //return new MapColumn
            //{
            //    Name = expression,
            //    OutputName = name,
            //};
        }

        public static string FromColumn(string column)
        {
            return $"[{column}]";
        }

        public static string FromSkip()
        {
            return "(SKIP)";
        }
    }
}
