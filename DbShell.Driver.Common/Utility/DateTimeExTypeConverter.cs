#if !NETSTANDARD2_0

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.CommonDataLayer;

namespace DbShell.Driver.Common.Utility
{
    public class DateTimeExTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof (string))
                return true;
            return base.CanConvertFrom(context, sourceType);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(DateTimeEx))
                return true;
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value != null)
            {
                return DateTimeEx.ParseNormalized(value.ToString());
            }
            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (value != null && value.GetType() == typeof (DateTimeEx))
            {
                return ((DateTimeEx)value).ToStringNormalized();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}

#endif