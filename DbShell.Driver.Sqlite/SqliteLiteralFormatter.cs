using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Sqlite
{
    public class SqliteLiteralFormatter : LiteralFormatterBase
    {
        public SqliteLiteralFormatter(IDatabaseFactory factory)
            : base(factory)
        {
        }

        public override void SetByteArray(byte[] value)
        {
            m_text = "X'" + StringTool.EncodeHex(value) + "'";
        }
    }
}
