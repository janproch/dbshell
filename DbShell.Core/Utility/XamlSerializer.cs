using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using DbShell.Common;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Utility;

namespace DbShell.Core.Utility
{
    [AttributeUsage(AttributeTargets.Class)]
    public class XamlUnfriendlyAttribute : Attribute
    {
    }

    public class XamlSerializer
    {
        private XmlDocument _doc;
        private bool _isUnfriendly;
        //private HashSet<object> _serialized = new HashSet<object>();

        public XamlSerializer()
        {
            _doc = new XmlDocument();
            _isUnfriendly = false;
        }

        public static string GetXmlNs(string codeNs)
        {
            switch (codeNs)
            {
                case "DbShell.Core":
                    return "http://schemas.dbshell.com/core";
                case "DbShell.DataSet":
                    return "http://schemas.dbshell.com/dataset";
                case "DbShell.Dbf":
                    return "http://schemas.dbshell.com/dbf";
                case "DbShell.Excel":
                    return "http://schemas.dbshell.com/excel";
                case "DbMouse.Core.Xaml":
                    return "http://schemas.dbmouse.com/dbshell";
                case "DbShell.Driver.Common.CommonDataLayer":
                    return "http://schemas.dbshell.com/cdl";
            }
            return "clr-namespace:" + codeNs;
        }


        private object SerializeCore(object o)
        {
            if (o == null) return null;
            //if (_serialized.Contains(o)) return null;
            //_serialized.Add(o);
            var type = o.GetType();
            if (type.GetCustomAttributes(typeof(XamlUnfriendlyAttribute), true).Any())
            {
                _isUnfriendly = true;
                return null;
            }
            if (type.IsGenericType) return null;
            if (type.IsArray) return null;
            if (type == typeof (string)) return o.ToString();
            if (type == typeof(char)) return o.ToString();
            if (type == typeof(bool)) return (bool)o ? "True" : "False";

            if (type == typeof(sbyte)) return o.ToString();
            if (type == typeof(short)) return o.ToString();
            if (type == typeof(int)) return o.ToString();
            if (type == typeof(long)) return o.ToString();
            if (type == typeof(byte)) return o.ToString();
            if (type == typeof(ushort)) return o.ToString();
            if (type == typeof(uint)) return o.ToString();
            if (type == typeof(ulong)) return o.ToString();
            if (type == typeof(DateTimeEx)) return ((DateTimeEx) o).ToStringNormalized();

            if (type.IsEnum) return o.ToString();
            if (o is Encoding) return ((Encoding)o).WebName;
            if (o is IConnectionProvider)
            {
                return ((IConnectionProvider)o).ProviderString;
            }
            string name = type.FullName;
            int index = name.LastIndexOf('.');
            string ns = name.Substring(0, index);
            string tname = name.Substring(index + 1);
            string tns = GetXmlNs(ns);
            var root = _doc.CreateElement(tname, tns);

            foreach (PropertyInfo prop in type.GetProperties())
            {
                if (!prop.GetCustomAttributes(typeof (XamlPropertyAttribute), true).Any()) continue;
                object value = prop.CallGet(o);
                if (value == null) continue;
                if (!(value is string) && value is IEnumerable && !(value is DbShell.Core.Utility.ElementBase))
                {
                    if (value.GetType().GetCustomAttributes(typeof(XamlUnfriendlyAttribute), true).Any())
                    {
                        _isUnfriendly = true;
                        continue;
                    }
                    var propElem = _doc.CreateElement(tname + "." + prop.Name, tns);
                    root.AppendChild(propElem);

                    foreach (var item in ((IEnumerable) value))
                    {
                        var obj = SerializeCore(item);
                        if (obj == null) continue;
                        if (obj is XmlNode)
                        {
                            propElem.AppendChild((XmlNode) obj);
                        }
                        else
                        {
                            propElem.AppendChild(_doc.CreateTextNode(obj.ToString()));
                        }
                    }
                }
                else
                {
                    var valueSer = SerializeCore(value);
                    if (valueSer != null)
                    {
                        if (valueSer is XmlNode)
                        {
                            var propElem = _doc.CreateElement(tname + "." + prop.Name, tns);
                            root.AppendChild(propElem);
                            propElem.AppendChild((XmlNode)valueSer);
                        }
                        else
                        {
                            root.SetAttribute(prop.Name, valueSer.ToString());
                        }
                    }
                }
            }

            return root;
        }

        private static void RemoveConnectionTag(XmlElement xml, string contextConnection)
        {
            if (!String.IsNullOrEmpty(contextConnection) && xml.GetAttribute("Connection") == contextConnection)
            {
                xml.RemoveAttribute("Connection");
            }
            string current = xml.GetAttribute("Connection");
            if (String.IsNullOrEmpty(current)) current = contextConnection;
            foreach (var child in xml.ChildNodes)
            {
                var elem = child as XmlElement;
                if (elem == null) continue;
                RemoveConnectionTag(elem, current);
            }
        }

        public static string Serialize(object o, string rootConnection = null, bool allowUnfriendly = true)
        {
            var ser = new XamlSerializer();
            var root = ser.SerializeCore(o);
            if (!allowUnfriendly && ser._isUnfriendly) return null;
            if (root is XmlElement)
            {
                RemoveConnectionTag((XmlElement) root, rootConnection);
                ser._doc.AppendChild((XmlNode) root);
            }
            var sw = new StringWriter();
            ser._doc.Save(sw);
            return sw.ToString();
        }
    }
}
