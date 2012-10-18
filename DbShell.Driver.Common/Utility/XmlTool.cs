using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Reflection;
using System.Globalization;
using System.Drawing;
using System.Collections;
using System.Text.RegularExpressions;
using DbShell.Driver.Common.Structure;

namespace DbShell.Driver.Common.Utility
{
    [AttributeUsage(AttributeTargets.Property)]
    public class XmlAttribAttribute : Attribute
    {
        public readonly string Name;
        public readonly object DefaultValue;
        public XmlAttribAttribute(string name, object defvalue) { Name = name; DefaultValue = defvalue; }
        public XmlAttribAttribute(string name) { Name = name; }
        public XmlAttribAttribute() { }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class XmlElemAttribute : Attribute
    {
        public readonly string Name;
        public readonly object DefaultValue;
        public bool Encrypt;
        public XmlElemAttribute(string name) { Name = name; }
        public XmlElemAttribute(string name, object defvalue) { Name = name; DefaultValue = defvalue; }
        public XmlElemAttribute() { }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class XmlSubElemAttribute : Attribute
    {
        public readonly string Name;
        public XmlSubElemAttribute(string name) { Name = name; }
        public XmlSubElemAttribute() { }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class XmlThisAttribute : Attribute
    {
    }

       
    [AttributeUsage(AttributeTargets.Property)]
    public class XmlCollectionAttribute : Attribute
    {
        public readonly string ElemName;
        public readonly Type ElemType;
        public XmlCollectionAttribute(Type elemType, string name)
        {
            ElemType = elemType;
            ElemName = name;
        }
        public XmlCollectionAttribute(Type elemType)
        {
            ElemType = elemType;
        }

        public string GetElemName(PropertyInfo prop)
        {
            string name = ElemName;
            if (name == null)
            {
                name = prop.Name;
                if (name.EndsWith("s")) name = name.Substring(0, name.Length - 1);
            }
            return name;
        }
    }

    public interface IExplicitXmlPersistent
    {
        void SaveToXml(XmlElement xml);
        void LoadFromXml(XmlElement xml);
    }

    public static class XmlTool
    {
        public static void SerializeObject(XmlWriter xw, object o)
        {
            XmlSerializer ser = new XmlSerializer(o.GetType());
            xw.WriteStartElement("Object");
            xw.WriteAttributeString("type", o.GetType().AssemblyQualifiedName);
            ser.Serialize(xw, o);
            xw.WriteEndElement();
        }

        public static void SerializeObject(Stream fw, object o)
        {
            using (XmlWriter xw = new XmlTextWriter(fw, Encoding.UTF8))
            {
                SerializeObject(xw, o);
            }
        }

        public static void SerializeObject(string filename, object o)
        {
            using (FileStream fw = new FileStream(filename, FileMode.Create))
            {
                SerializeObject(fw, o);
            }
        }

        public static object DeserializeObject(string filename)
        {
            using (FileStream fr = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                return DeserializeObject(fr);
            }
        }

        public static object DeserializeObject(XmlElement elem)
        {
            string typename = elem.GetAttribute("type");
            Type type = Type.GetType(typename);
            XmlSerializer ser = new XmlSerializer(type);
            using (XmlNodeReader xr = new XmlNodeReader(elem.LastChild))
            {
                return ser.Deserialize(xr);
            }
        }

        public static object DeserializeObject(XmlDocument doc)
        {
            return DeserializeObject(doc.DocumentElement);
        }

        public static object DeserializeObject(Stream fr)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fr);
            return DeserializeObject(doc);
        }

        public static object StringToObject_DataXml(Type type, string value)
        {
            if (type == null) return value;

            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Boolean: return XmlConvert.ToBoolean(value);
                case TypeCode.Byte: return XmlConvert.ToByte(value);
                case TypeCode.Char: return (char)XmlConvert.ToInt32(value);
                case TypeCode.DateTime: return DateTime.Parse(value);
				//case TypeCode.DateTime: return XmlConvert.ToDateTime (value, XmlDateTimeSerializationMode.Unspecified);
                case TypeCode.Decimal: return XmlConvert.ToDecimal(value);
                case TypeCode.Double: return XmlConvert.ToDouble(value);
                case TypeCode.Int16: return XmlConvert.ToInt16(value);
                case TypeCode.Int32: return XmlConvert.ToInt32(value);
                case TypeCode.Int64: return XmlConvert.ToInt64(value);
                case TypeCode.SByte: return XmlConvert.ToSByte(value);
                case TypeCode.Single: return XmlConvert.ToSingle(value);
                case TypeCode.UInt16: return XmlConvert.ToUInt16(value);
                case TypeCode.UInt32: return XmlConvert.ToUInt32(value);
                case TypeCode.UInt64: return XmlConvert.ToUInt64(value);
            }

            if (type == typeof(TimeSpan)) return XmlConvert.ToTimeSpan(value);
            if (type == typeof(Guid)) return XmlConvert.ToGuid(value);
            if (type == typeof(byte[])) return Convert.FromBase64String(value);
            if (type == typeof(System.Type)) return System.Type.GetType(value);

            return Convert.ChangeType(value, type);
        }

        public static bool IsNumberType(this Type type)
        {
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Byte:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.SByte:
                case TypeCode.Single:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return true;
                default:
                    return false;
            }
        }

        public static string ObjectToString(object o)
        {
            switch (Type.GetTypeCode(o.GetType()))
            {
                case TypeCode.Boolean:
                    return XmlConvert.ToString((Boolean)o);
                case TypeCode.Byte:
                    return XmlConvert.ToString((Byte)o);
                case TypeCode.Char:
                    return XmlConvert.ToString((Char)o);
                case TypeCode.DateTime:
                    //return ((DateTime)o).ToString("s");
					return XmlConvert.ToString ((DateTime) o, XmlDateTimeSerializationMode.Unspecified);
                case TypeCode.Decimal:
                    return XmlConvert.ToString((Decimal)o);
                case TypeCode.Double:
                    return XmlConvert.ToString((Double)o);
                case TypeCode.Int16:
                    return XmlConvert.ToString((Int16)o);
                case TypeCode.Int32:
                    return XmlConvert.ToString((Int32)o);
                case TypeCode.Int64:
                    return XmlConvert.ToString((Int64)o);
                case TypeCode.SByte:
                    return XmlConvert.ToString((SByte)o);
                case TypeCode.Single:
                    return XmlConvert.ToString((Single)o);
                case TypeCode.UInt16:
                    return XmlConvert.ToString((UInt16)o);
                case TypeCode.UInt32:
                    return XmlConvert.ToString((UInt32)o);
                case TypeCode.UInt64:
                    return XmlConvert.ToString((UInt64)o);
            }
            if (o is TimeSpan) return XmlConvert.ToString((TimeSpan)o);
            if (o is Guid) return XmlConvert.ToString((Guid)o);
            if (o is byte[]) return Convert.ToBase64String((byte[])o);
            return o.ToString();
        }

        public static string QuoteEntities(string s)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in s)
            {
                switch (c)
                {
                    case '\'':
                        sb.Append("&apos;");
                        break;
                    case '<':
                        sb.Append("&lt;");
                        break;
                    case '>':
                        sb.Append("&gt;");
                        break;
                    case '\"':
                        sb.Append("&quot;");
                        break;
                    case '&':
                        sb.Append("&amp;");
                        break;
                    default:
                        sb.Append(c);
                        break;
                }
            }
            return sb.ToString();
        }

        public static string NormalizeIdentifier(string id)
        {
            StringBuilder bld = new StringBuilder();
            foreach (char ch in id)
            {
                if (Char.IsLetterOrDigit(ch) || ch == '_' || ch == '-' || ch == '.') bld.Append(ch);
                else if (ch == ' ') bld.Append('_');
                else bld.Append("_" + ((int)ch).ToString() + "_");
            }
            return bld.ToString();
        }

        private static byte[] XORS = new byte[] { 0xf2, 0x50, 0xd3, 0x41, 0x08, 0xc3 };

        private static void XorUpdateBuffer(byte[] buf, byte[] key)
        {
            if (key == null) key = XORS;
            unchecked
            {
                for (int i = 0; i < buf.Length; i++)
                {
                    buf[i] = (byte)(buf[i] ^ key[i % key.Length]);
                }
            }
        }

        public static string SafeEncodeString(string s)
        {
            return SafeEncodeString(s, null);
        }

        public static string SafeEncodeString(string s, string key)
        {
            if (s == null) return null;
            byte[] buf = Encoding.UTF8.GetBytes(s);
            XorUpdateBuffer(buf, key == null ? null : Encoding.UTF8.GetBytes(key));
            return Convert.ToBase64String(buf);
        }

        public static string SafeDecodeString(string s)
        {
            return SafeDecodeString(s, null);
        }

        public static string SafeDecodeString(string s, string key)
        {
            if (s == null) return null;
            byte[] buf = Convert.FromBase64String(s);
            XorUpdateBuffer(buf, key == null ? null : Encoding.UTF8.GetBytes(key));
            try
            {
                return Encoding.UTF8.GetString(buf);
            }
            catch
            {
                return "";
            }
        }

        public static XmlElement AddChild(this XmlElement xml, string elemName)
        {
            XmlElement child = xml.OwnerDocument.CreateElement(elemName);
            xml.AppendChild(child);
            return child;
        }

        public static XmlDocument CreateDocument(string rootElement)
        {
            XmlDocument res = new XmlDocument();
            res.AppendChild(res.CreateElement(rootElement));
            return res;
        }

        public static string PropertyToString(PropertyInfo prop, object val)
        {
            if (val == null) return null;
            return ValueToString(prop.PropertyType, val);
        }

        public static string ValueToString(Type type, object val)
        {
            if (val == null) return null;
            string res;
            if (val is bool)
            {
                if ((bool)val) return "1";
                return "0";
            }
            else if (val.GetType().IsEnum)
            {
                return val.ToString().ToLower();
            }
            else if (val is Color)
            {
                return ((Color)val).Name;
            }
            else if (val is Encoding)
            {
                return ((Encoding)val).WebName;
            }
            else if (val is Bitmap)
            {
                var ms = new MemoryStream();
                ((Bitmap)val).Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return Convert.ToBase64String(ms.ToArray());
            }
            else if (val is DateTime)
            {
                return ((DateTime)val).ToString("s", CultureInfo.InvariantCulture);
            }
            else if (val != null)
            {
                return Convert.ToString(val.ToString(), CultureInfo.InvariantCulture);
            }
            return null;
        }

        public static object PropertyFromString(PropertyInfo prop, string sval)
        {
            if (sval == null) return null;
            return ValueFromString(prop.PropertyType, sval);
        }

        public static object ValueFromString(Type type, string sval)
        {
            if (sval == null) return null;
            object res;
            if (type == typeof(bool))
            {
                if (sval == "1") return true;
                if (sval == "0") return false;
            }
            else if (type == typeof(bool?))
            {
                if (sval == "1") return true;
                if (sval == "0") return false;
                return null;
            }
            else if (type.IsEnum)
            {
                return Enum.Parse(type, sval, true);
            }
            else if (type == typeof(Encoding))
            {
                return Encoding.GetEncoding(sval);
            }
            else if (type == typeof(Color))
            {
                var col = Color.FromName(sval);
                if (col.ToArgb() == 0)
                {
                    return Color.FromArgb((int)uint.Parse(sval, NumberStyles.HexNumber));
                }
                return col;
            }
            else if (type == typeof(DateTime))
            {
                return DateTime.ParseExact(sval, "s", CultureInfo.InvariantCulture);
            }
            else if (type == typeof(Bitmap))
            {
                var ms = new MemoryStream(Convert.FromBase64String(sval));
                var bmp = new Bitmap(ms);
                return bmp;
            }
            else
            {
                return Convert.ChangeType(sval, type);
            }
            return null;
        }

        private static bool DefaultTest(object val, object defvalue)
        {
            if (defvalue == null) return false;
            return val.Equals(defvalue);
        }

        public static void SaveProperties(this object o, string filename)
        {
            var doc = XmlTool.CreateDocument("Document");
            SaveProperties(o, doc.DocumentElement);
            doc.Save(filename);
        }

        public static void SaveProperties(this object o, XmlElement xml)
        {
            if (o is IExplicitXmlPersistent)
            {
                ((IExplicitXmlPersistent)o).SaveToXml(xml);
                return;
            }
            o.SavePropertiesCore(xml);
        }

        public static void SavePropertiesCore(this object o, XmlElement xml)
        {
            foreach (PropertyInfo prop in o.GetType().GetProperties())
            {
                foreach (XmlAttribAttribute attr in prop.GetCustomAttributes(typeof(XmlAttribAttribute), true))
                {
                    object val = prop.CallGet(o);
                    string sval = PropertyToString(prop, val);

                    if (sval != null && !DefaultTest(val, attr.DefaultValue)) xml.SetAttribute(attr.Name ?? prop.Name, sval);
                }
                foreach (XmlElemAttribute attr in prop.GetCustomAttributes(typeof(XmlElemAttribute), true))
                {
                    object val = prop.CallGet(o);
                    if (val != null && val.GetType() == typeof(NameWithSchema))
                    {
                        ((NameWithSchema)val).SaveToXml(xml.AddChild(attr.Name ?? prop.Name));
                    }
                    else
                    {
                        string sval = PropertyToString(prop, val);
                        if (attr.Encrypt) sval = SafeEncodeString(sval);
                        if (sval != null && !DefaultTest(val, attr.DefaultValue)) xml.AddChild(attr.Name ?? prop.Name).InnerText = sval;
                    }
                }
                foreach (XmlSubElemAttribute attr in prop.GetCustomAttributes(typeof(XmlSubElemAttribute), true))
                {
                    object val = prop.CallGet(o);
                    if (val != null)
                    {
                        var elem = xml.AddChild(attr.Name ?? prop.Name);
                        SaveProperties(val, elem);
                    }
                }
                foreach (XmlThisAttribute attr in prop.GetCustomAttributes(typeof(XmlThisAttribute), true))
                {
                    object val = prop.CallGet(o);
                    if (val != null)
                    {
                        SaveProperties(val, xml);
                    }
                }
                foreach (XmlCollectionAttribute attr in prop.GetCustomAttributes(typeof(XmlCollectionAttribute), true))
                {
                    object val = prop.CallGet(o);
                    string name = attr.GetElemName(prop);
                    if (val != null)
                    {
                        foreach (object obj in (IEnumerable)val)
                        {
                            var elem = xml.AddChild(name);
                            if (obj is string) elem.InnerText = obj.ToString();
                            else SaveProperties(obj, elem);
                        }
                    }
                }
            }
        }

        public static void LoadProperties(this object o, string filename)
        {
            var doc = new XmlDocument();
            doc.Load(filename);
            LoadProperties(o, doc.DocumentElement);
        }

        public static void LoadProperties(this object o, XmlElement xml)
        {
            if (o is IExplicitXmlPersistent)
            {
                ((IExplicitXmlPersistent)o).LoadFromXml(xml);
                return;
            }
            o.LoadPropertiesCore(xml);
        }

        public static void LoadPropertiesCore(this object o, XmlElement xml)
        {
            if (xml == null) return;
            foreach (PropertyInfo prop in o.GetType().GetProperties())
            {
                bool propHandled = false;
                //MethodInfo setMethod = prop.GetSetMethod();
                //if (setMethod == null) continue; // not SET method available
                string sval = null;
                foreach (XmlAttribAttribute attr in prop.GetCustomAttributes(typeof(XmlAttribAttribute), true))
                {
                    if (xml.HasAttribute(attr.Name ?? prop.Name)) sval = xml.GetAttribute(attr.Name ?? prop.Name);
                }
                foreach (XmlElemAttribute attr in prop.GetCustomAttributes(typeof(XmlElemAttribute), true))
                {
                    if (prop.PropertyType == typeof(NameWithSchema))
                    {
                        propHandled = true;
                        var elem = xml.SelectSingleNode(attr.Name ?? prop.Name) as XmlElement;
                        if (elem != null) prop.CallSet(o, NameWithSchema.LoadFromXml(elem));
                    }
                    else
                    {
                        if (xml.SelectSingleNode(attr.Name ?? prop.Name) != null) sval = xml.SelectSingleNode(attr.Name ?? prop.Name).InnerText;
                        if (attr.Encrypt) sval = SafeDecodeString(sval);
                    }
                }
                foreach (XmlSubElemAttribute attr in prop.GetCustomAttributes(typeof(XmlSubElemAttribute), true))
                {
                    object subval = prop.CallGet(o);
                    var elem = xml.FindElement(attr.Name ?? prop.Name);
                    if (elem != null)
                    {
                        if (subval == null)
                        {
                            try
                            {
                                subval = prop.PropertyType.CreateNewChildInstance(o);
                                prop.CallSet(o, subval);
                            }
                            catch
                            {
                                subval = null;
                            }
                        }
                        if (subval != null)
                        {
                            LoadProperties(subval, elem);
                        }
                    }
                }
                foreach (XmlThisAttribute attr in prop.GetCustomAttributes(typeof(XmlThisAttribute), true))
                {
                    object subval = prop.CallGet(o);
                    if (subval == null)
                    {
                        try
                        {
                            subval = prop.PropertyType.CreateNewInstance();
                            prop.CallSet(o, subval);
                        }
                        catch
                        {
                            subval = null;
                        }
                    }
                    if (subval != null)
                    {
                        LoadProperties(subval, xml);
                    }
                }
                foreach (XmlCollectionAttribute attr in prop.GetCustomAttributes(typeof(XmlCollectionAttribute), true))
                {
                    string name = attr.GetElemName(prop);
                    var lst = xml.SelectNodes(name);
                    if (lst.Count > 0)
                    {
                        object colval = prop.CallGet(o);
                        if (colval == null)
                        {
                            try
                            {
                                colval = prop.PropertyType.CreateNewChildInstance(o);
                                prop.CallSet(o, colval);
                            }
                            catch
                            {
                                colval = null;
                            }
                        }
                        if (colval != null)
                        {
                            foreach (XmlElement elem in lst)
                            {
                                if (attr.ElemType == typeof(string))
                                {
                                    ((IList)colval).Add(elem.InnerText);
                                }
                                else
                                {
                                    object item;
                                    item = attr.ElemType.CreateNewChildInstance(o);
                                    item.LoadProperties(elem);
                                    ((IList)colval).Add(item);
                                }
                            }
                        }
                    }
                }
                if (propHandled) continue;
                object val = PropertyFromString(prop, sval);
                if (val != null) prop.CallSet(o, val);
                //mtd.Invoke(o, new object[] { val });
            }
        }

        public static XmlElement FindElement(this XmlElement xml, string name)
        {
            return (XmlElement)xml.SelectSingleNode(name);
        }

        public static void LoadSpecificAttributes(Dictionary<string, string> SpecificData, string specificPrefix, XmlElement xml)
        {
            foreach (XmlAttribute attr in xml.Attributes)
            {
                if (attr.Name.StartsWith(specificPrefix))
                {
                    string key = attr.Name.Substring(specificPrefix.Length);
                    SpecificData[key] = attr.Value;
                }
            }
        }

        public static void SaveSpecificAttributes(Dictionary<string, string> SpecificData, string specificPrefix, XmlElement xml)
        {
            foreach (string key in SpecificData.Keys)
            {
                xml.SetAttribute(specificPrefix + key, SpecificData[key]);
            }
        }

        public static Dictionary<string, string> LoadParameters(XmlElement xml)
        {
            Dictionary<string, string> res = new Dictionary<string, string>();
            foreach (XmlElement x in xml.SelectNodes("Param"))
            {
                res[x.GetAttribute("name")] = x.InnerText;
            }
            return res;
        }

        public static void SaveParameters(XmlElement xml, IDictionary dict)
        {
            var en = dict.GetEnumerator();
            while (en.MoveNext())
            {
                var p = xml.AddChild("Param");
                p.SetAttribute("name", en.Key.ToString());
                p.InnerText = en.Value.ToString();
            }
        }

        public static bool PropertiesEquals(object a, object b)
        {
            if (a.GetType() != b.GetType()) return false;

            foreach (PropertyInfo prop in a.GetType().GetProperties())
            {
                MethodInfo mtd = prop.GetGetMethod();
                object vala = mtd.Invoke(a, new object[] { });
                object valb = mtd.Invoke(b, new object[] { });

                bool compare = false;
                foreach (XmlAttribAttribute attr in prop.GetCustomAttributes(typeof(XmlAttribAttribute), true))
                {
                    compare = true;
                }
                foreach (XmlElemAttribute attr in prop.GetCustomAttributes(typeof(XmlElemAttribute), true))
                {
                    compare = true;
                }
                foreach (XmlSubElemAttribute attr in prop.GetCustomAttributes(typeof(XmlSubElemAttribute), true))
                {
                    if (!PropertiesEquals(vala, valb)) return false;
                    compare = true;
                }
                if (compare && !Object.Equals(vala, valb))
                {
                    return false;
                }
            }

            return true;
        }

        public static void CopyProperties(object src, object dst)
        {
            if (src.GetType() != src.GetType()) return;

            foreach (PropertyInfo prop in src.GetType().GetProperties())
            {
                bool copy = false;
                foreach (XmlAttribAttribute attr in prop.GetCustomAttributes(typeof(XmlAttribAttribute), true))
                {
                    copy = true;
                }
                foreach (XmlElemAttribute attr in prop.GetCustomAttributes(typeof(XmlElemAttribute), true))
                {
                    copy = true;
                }
                if (!copy) continue;

                MethodInfo getmtd = prop.GetGetMethod();
                object valsrc = getmtd.Invoke(src, new object[] { });
                MethodInfo setmtd = prop.GetSetMethod();
                setmtd.Invoke(dst, new object[] { valsrc });
            }
        }

        public static void RemovePasswords(XmlElement xml)
        {
            var regex = new Regex("password|pwd", RegexOptions.IgnoreCase);
            foreach (XmlNode xchild in xml)
            {
                var child = xchild as XmlElement;
                if (child == null) continue;
                if (regex.Match(child.Name).Success) child.InnerText = "****";
                RemovePasswords(child);
            }
            for (int i = 0; i < xml.Attributes.Count; i++)
            {
                var at = xml.Attributes[i];
                if (regex.Match(at.Name).Success) at.Value = "****";
            }
        }

        public static string GetTextContent(this XmlNode parent, string childName)
        {
            var child = parent.SelectSingleNode(childName);
            if (child != null) return child.InnerText;
            return null;
        }

        public static T CloneUsingXml<T>(T obj)
            where T : new()
        {
            if (obj == null) return (T)(object)null;
            var doc = XmlTool.CreateDocument("Object");
            obj.SaveProperties(doc.DocumentElement);
            var res = new T();
            res.LoadProperties(doc.DocumentElement);
            return res;
        }

        public static string GetPackedDocumentXml(this XmlDocument doc)
        {
            var sw = new StringWriter();
            var opt = new XmlWriterSettings { OmitXmlDeclaration = true, Indent = false };
            using (var xw = XmlWriter.Create(sw, opt))
            {
                doc.Save(xw);
            }
            return sw.ToString();
        }
    }
}
