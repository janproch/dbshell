using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.SqlServer
{
    public class SqlServerLiteralFormatter : LiteralFormatterBase
    {
        public SqlServerLiteralFormatter(IDatabaseFactory factory)
            : base(factory)
        {
        }
        public override void SetString(string value)
        {
            base.SetString(value);
            bool unicode = false;
            foreach (var ch in value)
            {
                if (ch >= 128) unicode = true;
            }
            if (unicode) m_text = "N" + m_text;
        }
        public override void SetDateTimeEx(DateTimeEx value)
        {
            m_text = "'" + value.ToString("yyyy-MM-ddTHH:mm:ss.fff", CultureInfo.InvariantCulture) + "'";
        }
        public override void SetDateTime(DateTime value)
        {
            m_text = "'" + StringTool.DateTimeToIsoStringExact(value) + "'";
        }
        public override void SetTimeEx(TimeEx value)
        {
            m_text = "'" + value.ToString("HH:mm:ss.fff", CultureInfo.InvariantCulture) + "'";
        }
    }
}
