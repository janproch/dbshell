using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using DbShell.Common;
using DbShell.Driver.Common.Utility;

namespace DbShell.Core.Utility
{
    [AttributeUsage(AttributeTargets.Property)]
    public class XamlPropertyAttribute : Attribute
    {
    }


    public class XamlSerializer
    {
        private XmlDocument _doc;
        //private HashSet<object> _serialized = new HashSet<object>();

        public XamlSerializer()
        {
            _doc = new XmlDocument();
        }

        public static string GetXmlNs(string codeNs)
        {
            switch (codeNs)
            {
                case "DbShell.Core":
                    return "http://schemas.dbshell.com/core";
                case "DbShell.DataSet":
                    return "http://schemas.dbshell.com/dataset";
                case "DbMouse.Core.Xaml":
                    return "http://schemas.dbmouse.com/dbshell";
            }
            return "clr-namespace:" + codeNs;
        }


        private XmlNode SerializeCore(object o)
        {
            if (o == null) return null;
            //if (_serialized.Contains(o)) return null;
            //_serialized.Add(o);
            var type = o.GetType();
            if (type.IsGenericType) return null;
            if (type.IsArray) return null;
            if (type == typeof (string)) return _doc.CreateTextNode(o.ToString());
            if (type == typeof(char)) return _doc.CreateTextNode(o.ToString());
            if (type == typeof(bool)) return _doc.CreateTextNode((bool)o ? "True" : "False");
            if (type.IsEnum) return _doc.CreateTextNode(o.ToString());
            if (o is Encoding) return _doc.CreateTextNode(((Encoding)o).EncodingName);
            if (o is IConnectionProvider) return _doc.CreateTextNode(((IConnectionProvider)o).ProviderString);
            string name = type.FullName;
            int index = name.LastIndexOf('.');
            string ns = name.Substring(0, index);
            string tname = name.Substring(index + 1);
            string tns = GetXmlNs(ns);
            var root = _doc.CreateElement(tname, tns);

            foreach (PropertyInfo prop in type.GetProperties())
            {
                if (!prop.GetCustomAttributes(typeof(XamlPropertyAttribute), true).Any()) continue;
                object value = prop.CallGet(o);
                if (value == null) continue;
                var propElem = _doc.CreateElement(tname + "." + prop.Name, tns);
                root.AppendChild(propElem);
                if (!(value is string) && value is IEnumerable && !(value is DbShell.Common.IShellElement))
                {
                    foreach (var item in ((IEnumerable) value))
                    {
                        var obj = SerializeCore(item);
                        if (obj == null) continue;
                        propElem.AppendChild(obj);
                    }
                }
                else
                {
                    var valueSer = SerializeCore(value);
                    if (valueSer != null)
                    {
                        propElem.AppendChild(valueSer);
                    }
                }
            }

            return root;
        }

        public static string Serialize(object o)
        {
            var ser = new XamlSerializer();
            var root = ser.SerializeCore(o);
            ser._doc.AppendChild(root);
            var sw = new StringWriter();
            ser._doc.Save(sw);
            return sw.ToString();
        }
    }
}
