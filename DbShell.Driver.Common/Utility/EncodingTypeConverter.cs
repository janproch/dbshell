using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DbShell.Driver.Common.Utility
{
    public class EncodingTypeConverter : TypeConverter
    {
        private static Dictionary<string, Encoding> _encodingByName = new Dictionary<string, Encoding>();

        static EncodingTypeConverter()
        {
            foreach (EncodingInfo info in Encoding.GetEncodings())
            {
                Encoding enc;
                try
                {
                    enc = info.GetEncoding();
                }
                catch
                {
                    continue;
                }
                _encodingByName[enc.WebName] = enc;
                _encodingByName[enc.EncodingName] = enc;
            }
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof (string))
                return true;
            return base.CanConvertFrom(context, sourceType);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof (Encoding))
                return true;
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value != null)
            {
                if (_encodingByName.ContainsKey(value.ToString())) return _encodingByName[value.ToString()];
                return Encoding.UTF8;
            }
            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (value != null && value.GetType() == typeof (Encoding))
            {
                return ((Encoding) value).WebName;
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
