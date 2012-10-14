using System;
using System.Globalization;

namespace DbShell.Driver.Common.Utility
{
    public static class ObjectExtension
    {
        public static string SafeToString(this object o)
        {
            if (o == null) return null;
            if (o is byte[])
            {
                try
                {
                    return System.Text.Encoding.UTF8.GetString((byte[])o);
                }
                catch
                {
                    return null;
                }
            }
            return Convert.ToString(o, CultureInfo.InvariantCulture);
        }

        public static string ToString(this object o, string format)
        {
            if (o == null) return "";
            return String.Format("{0:" + format + "}", o);
        }

        public static bool IsNullOrDbNull(this object o)
        {
            return o == null || o == DBNull.Value;
        }
    }
}
