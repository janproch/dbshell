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
using System.Windows.Markup;

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
            //var nsmgr = new XmlNamespaceManager(_doc.NameTable);
            //nsmgr.AddNamespace("ds", "http://schemas.dbshell.com/dataset");
            //nsmgr.AddNamespace("dbf", "http://schemas.dbshell.com/dbf");
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
                case "DbShell.RelatedDataSync":
                    return "http://schemas.dbshell.com/datasync";
            }
            return "clr-namespace:" + codeNs;
        }

        public static string GetNsShortVariant(string nsUrl)
        {
            switch (nsUrl)
            {
                case "http://schemas.dbshell.com/core":
                    return "";
                case "http://schemas.dbshell.com/dataset":
                    return "ds";
                case "http://schemas.dbshell.com/dbf":
                    return "dbf";
                case "http://schemas.dbshell.com/excel":
                    return "excel";
                case "http://schemas.dbmouse.com/dbshell":
                    return "dbmouse";
                case "http://schemas.dbshell.com/cdl":
                    return "cdl";
                case "http://schemas.dbshell.com/datasync":
                    return "rds";
            }
            return null;

        }

        private XmlElement CreateElement(string name, string ns)
        {
            string nsShort = GetNsShortVariant(ns);
            if (String.IsNullOrEmpty(nsShort)) return _doc.CreateElement(name, ns);
            return _doc.CreateElement(nsShort, name, ns);
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
            string contentProperty = null;
            foreach (ContentPropertyAttribute contentProp in type.GetCustomAttributes(typeof(ContentPropertyAttribute), true))
            {
                contentProperty = contentProp.Name;
            }
            if (type.IsGenericType) return null;
            if (type.IsArray) return null;
            if (type == typeof(string)) return o.ToString();
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
            if (type == typeof(DateTimeEx)) return ((DateTimeEx)o).ToStringNormalized();
            var shellElem = o as ElementBase;
            string xamlExtension = shellElem?.ToXamlExtension();
            if (xamlExtension != null) return xamlExtension;

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
            var root = CreateElement(tname, tns);

            XmlElement contentPropertyElement = null;
            foreach (PropertyInfo prop in type.GetProperties())
            {
                if (!prop.GetCustomAttributes(typeof(XamlPropertyAttribute), true).Any()) continue;
                object value = prop.CallGet(o);
                if (value == null) continue;
                if (value is string[])
                {
                    var propElem = CreateElement(tname + "." + prop.Name, tns);
                    root.AppendChild(propElem);
                    //var arrayElem = _doc.CreateElement("Array", "http://schemas.microsoft.com/winfx/2006/xaml");
                    //propElem.AppendChild(arrayElem);
                    foreach (string item in (string[])value)
                    {
                        var itemElem = CreateElement("String", "clr-namespace:System;assembly=mscorlib");
                        itemElem.InnerText = item;
                        propElem.AppendChild(itemElem);
                    }
                    if (prop.Name == contentProperty) contentPropertyElement = propElem;
                }
                else if (!(value is string) && value is IEnumerable && !(value is DbShell.Core.Utility.ElementBase))
                {
                    if (value.GetType().GetCustomAttributes(typeof(XamlUnfriendlyAttribute), true).Any())
                    {
                        _isUnfriendly = true;
                        continue;
                    }
                    var propElem = CreateElement(tname + "." + prop.Name, tns);
                    root.AppendChild(propElem);

                    foreach (var item in ((IEnumerable)value))
                    {
                        var obj = SerializeCore(item);
                        if (obj == null) continue;
                        if (obj is XmlNode)
                        {
                            propElem.AppendChild((XmlNode)obj);
                        }
                        else
                        {
                            propElem.AppendChild(_doc.CreateTextNode(obj.ToString()));
                        }
                    }
                    if (prop.Name == contentProperty) contentPropertyElement = propElem;
                }
                else
                {
                    var valueSer = SerializeCore(value);
                    if (valueSer != null)
                    {
                        if (valueSer is XmlNode)
                        {
                            var propElem = CreateElement(tname + "." + prop.Name, tns);
                            root.AppendChild(propElem);
                            propElem.AppendChild((XmlNode)valueSer);
                            if (prop.Name == contentProperty) contentPropertyElement = propElem;
                        }
                        else
                        {
                            root.SetAttribute(prop.Name, valueSer.ToString());
                        }
                    }
                }
            }

            if (contentPropertyElement != null)
            {
                var elements = new List<XmlElement>();
                foreach (var x in root.ChildNodes)
                {
                    if (x is XmlElement) elements.Add((XmlElement)x);
                }
                if (elements.Count == 1 && elements[0] == contentPropertyElement)
                {
                    root.RemoveChild(contentPropertyElement);
                    var childs = new List<XmlElement>();
                    foreach (var x in contentPropertyElement.ChildNodes)
                    {
                        if (x is XmlElement) childs.Add((XmlElement)x);
                    }
                    foreach(var x in childs)
                    {
                        root.AppendChild(x);
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

        private static string GetXmlNsAttribute(string nsShort)
        {
            if (nsShort != "") return "xmlns:" + nsShort;
            return "xmlns";
        }

        private static void ReplaceNamespaces(XmlElement element, XmlElement root, XmlNamespaceManager nsmgr)
        {
            string nsShort = GetNsShortVariant(element.NamespaceURI);
            if (nsShort != null && String.IsNullOrEmpty(root.GetAttribute(GetXmlNsAttribute(nsShort))))
            {
                root.SetAttribute(GetXmlNsAttribute(nsShort), element.NamespaceURI);
                if (nsShort != "")
                {
                    nsmgr.AddNamespace(nsShort, element.NamespaceURI);
                }
            }

            foreach (var child in element.ChildNodes)
            {
                var childElem = child as XmlElement;
                if (childElem == null) continue;
                ReplaceNamespaces(childElem, root, nsmgr);
            }
        }

        public static string Serialize(object o, string rootConnection = null, bool allowUnfriendly = true)
        {
            var ser = new XamlSerializer();
            var root = ser.SerializeCore(o);
            if (!allowUnfriendly && ser._isUnfriendly) return null;

            if (root is XmlElement)
            {
                RemoveConnectionTag((XmlElement)root, rootConnection);
                ser._doc.AppendChild((XmlNode)root);
                var nsmgr = new XmlNamespaceManager(ser._doc.NameTable);
                ReplaceNamespaces((XmlElement)root, (XmlElement)root, nsmgr);
            }
            var sw = new StringWriter();
            ser._doc.Save(sw);
            return sw.ToString();
        }
    }
}
