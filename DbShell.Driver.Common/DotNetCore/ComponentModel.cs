using System;
using System.Collections.Generic;
using System.Text;

#if NETSTANDARD2_0

namespace System.ComponentModel
{
    [AttributeUsage(AttributeTargets.All)]
    public class DescriptionAttribute : Attribute
    {
        public string Value;
        public DescriptionAttribute(string value)
        {
            Value = value;
        }
    }

    [AttributeUsage(AttributeTargets.All)]
    public class DisplayNameAttribute : Attribute
    {
        public string Value;
        public DisplayNameAttribute(string value)
        {
            Value = value;
        }
    }

    [AttributeUsage(AttributeTargets.All)]
    public class CategoryAttribute : Attribute
    {
        public string Value;
        public CategoryAttribute(string value)
        {
            Value = value;
        }
    }

    [AttributeUsage(AttributeTargets.All)]
    public class BrowsableAttribute : Attribute
    {
        public bool Value;
        public BrowsableAttribute(bool value)
        {
            Value = value;
        }
    }

}

#endif