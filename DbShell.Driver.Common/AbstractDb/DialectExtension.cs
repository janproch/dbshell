using System.Text;

namespace DbShell.Driver.Common.AbstractDb
{
    public static class DialectExtension
    {
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
    }
}