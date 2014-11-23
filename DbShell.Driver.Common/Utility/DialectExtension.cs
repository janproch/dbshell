using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Sql;
using DbShell.Driver.Common.Structure;

namespace DbShell.Driver.Common.Utility
{
    public static class DialectExtension
    {
        public static string QuoteFullName(this ISqlDialect dialect, NameWithSchema name)
        {
            if (name.Schema != null)
            {
                if (name.Schema.ToUpper() == "INFORMATION_SCHEMA") return String.Format("{0}.{1}", name.Schema, name.Name);
                return String.Format("{0}.{1}", dialect.QuoteIdentifier(name.Schema), dialect.QuoteIdentifier(name.Name));
            }
            return dialect.QuoteIdentifier(name.Name);
        }

        public static void EscapeString(this ISqlDialect dialect, string value, StringBuilder sb)
        {
            char esc = dialect.StringEscapeChar;
            foreach (var ch in value)
            {
                if (ch == '\'' || ch == esc)
                {
                    sb.Append(esc);
                    sb.Append(ch);
                }
                else
                {
                    sb.Append(ch);
                }
            }
        }

        public static string EscapeString(this ISqlDialect dialect, string value)
        {
            var sb = new StringBuilder();
            dialect.EscapeString(value, sb);
            return sb.ToString();
        }

        public static string GenerateScript(this IDatabaseFactory factory, Action<ISqlDumper> script)
        {
            return factory.GenerateScript(script, SqlFormatProperties.Default);
        }

        public static string GenerateScript(this IDatabaseFactory factory, Action<ISqlDumper> script, SqlFormatProperties props)
        {
            StringWriter sw = new StringWriter();
            ISqlDumper dmp;
            var so = new SqlOutputStream(factory.CreateDialect(), sw, props);
            dmp = factory.CreateDumper(so, props);
            script(dmp);
            return sw.ToString();
        }
    }
}
