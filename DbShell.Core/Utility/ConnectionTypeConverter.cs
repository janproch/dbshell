using System;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace DbShell.Core.Utility
{
    public class ConnectionTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof (string)) return true;
            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value == null) return null;
            if (value is string)
            {
                string s = (string) value;
                if (s.Contains("${")) return new DynamicConnectionProvider(s);
                var provider = ConnectionProvider.FromString(s);
                if (provider != null) return provider;
            }

            return base.ConvertFrom(context, culture, value);
        }
    }
}
