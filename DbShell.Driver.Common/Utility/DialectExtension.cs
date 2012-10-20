using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.AbstractDb;
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
    }
}
