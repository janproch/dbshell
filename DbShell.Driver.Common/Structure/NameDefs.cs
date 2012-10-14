using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.Structure
{
    public class NameWithSchema : IComparable, IFormattable
    {
        public readonly string Schema = null;
        public readonly string Name;
        public readonly bool HideSchema;

        public NameWithSchema(string schema, string name)
        {
            if (!String.IsNullOrEmpty(schema)) Schema = schema;
            Name = name;
        }
        public NameWithSchema(string schema, string name, bool hideSchema)
        {
            if (!String.IsNullOrEmpty(schema)) Schema = schema;
            Name = name;
            HideSchema = hideSchema;
        }
        public NameWithSchema GetNameWithHiddenSchema()
        {
            return new NameWithSchema(Schema, Name, true);
        }
        public NameWithSchema GetNameWithNullSchema()
        {
            return new NameWithSchema(Name);
        }
        public NameWithSchema(string name)
        {
            if (name == null) return;
            if (name.Contains("."))
            {
                string[] comps = name.Split(new char[] { '.' }, 2);
                Schema = comps[0];
                Name = comps[1];
            }
            else
            {
                Name = name;
            }
        }
        public override bool Equals(object obj)
        {
            if (obj is NameWithSchema)
            {
                return this == (NameWithSchema)obj;
            }
            return base.Equals(obj);
        }
        public static bool operator ==(NameWithSchema a, NameWithSchema b)
        {
            if ((object)a == null || (object)b == null) return (object)a == null && (object)b == null;
            return a.Name == b.Name && a.Schema == b.Schema;
            //if (a.HideSchema && a.Schema != null) a = new NameWithSchema(a.Name);
            //if (b.HideSchema && b.Schema != null) b = new NameWithSchema(b.Name);
            //return (a.Name ?? "").ToUpper() == (b.Name ?? "").ToUpper() && (a.Schema ?? "").ToUpper() == (b.Schema ?? "").ToUpper();
        }
        public static bool operator !=(NameWithSchema a, NameWithSchema b)
        {
            return !(a == b);
        }
        public override int GetHashCode()
        {
            if (Name == null) return 0;
            return Name.GetHashCode();
            //return Name.ToUpper().GetHashCode();
        }
        public static int Compare(NameWithSchema a, NameWithSchema b)
        {
            int res = 0;
            if (a.Schema == null && b.Schema != null) return -1;
            if (a.Schema != null && b.Schema == null) return 1;
            if (a.Schema != null && b.Schema != null) res = String.Compare(a.Schema, b.Schema, true);
            if (res != 0) return res;
            if (a.Name == null && b.Name != null) return -1;
            if (a.Name != null && b.Name == null) return 1;
            if (a.Name != null && b.Name != null) res = String.Compare(a.Name, b.Name, true);
            return res;
        }

        public void SaveToXml(XmlElement xml)
        {
            SaveToXml(xml, "");
        }

        public void SaveToXml(XmlElement xml, string prefix)
        {
            SaveToXml(xml, prefix + "schema", prefix + "name");
        }

        public void SaveToXml(XmlElement xml, string schemaattr, string nameattr)
        {
            if (Schema != null) xml.SetAttribute(schemaattr, Schema);
            if (Name != null) xml.SetAttribute(nameattr, Name);
        }

        public static NameWithSchema LoadFromXml(XmlElement xml, string prefix)
        {
            return LoadFromXml(xml, prefix + "schema", prefix + "name");
        }

        public static NameWithSchema LoadFromXml(XmlElement xml, string schemaattr, string nameattr)
        {
            if (xml == null) return null;
            // HACK: aby slo nacist historicke datove archivy
            if (nameattr == "name" && xml.HasAttribute("table") && !xml.HasAttribute("name")) nameattr = "table";
            if (!xml.HasAttribute(nameattr)) return null;
            return new NameWithSchema(xml.GetAttribute(schemaattr), xml.GetAttribute(nameattr));
        }

        public static NameWithSchema LoadFromXml(XmlElement xml)
        {
            return LoadFromXml(xml, "");
        }

        #region IComparable Members

        public int CompareTo(object obj)
        {
            var name2 = obj as NameWithSchema;
            if (name2 != null) return NameWithSchema.Compare(this, name2);
            return 0;
        }

        #endregion

        public override string ToString()
        {
            return ToString("M", null);
        }

        #region IFormattable Members

        public string ToString(string format, IFormatProvider formatProvider)
        {
            switch (format)
            {
                case "L":
                case "M":
                case "S":
                    if (Schema != null && !HideSchema) return Schema + "." + Name;
                    return Name;
                case "F":
                    if (Schema != null) return Schema + "." + Name;
                    return Name;
                default:
                    return Name;
            }
        }

        #endregion

        public NameWithSchema ToUpper()
        {
            return new NameWithSchema(Schema != null ? Schema.ToUpper() : null, Name != null ? Name.ToUpper() : null);
        }

        public NameWithSchema ToLower()
        {
            return new NameWithSchema(Schema != null ? Schema.ToLower() : null, Name != null ? Name.ToLower() : null);
        }

        public NameWithSchema GetOnlyCaseDifferentName(IEnumerable<NameWithSchema> choices)
        {
            if (choices.IndexOfIf(n => n == this) < 0)
            {
                var up = ToUpper();
                var res = choices.FirstOrDefault(n => n.ToUpper() == up);
                if (res != null) return res;
            }
            return this;
        }
    }

    public class ObjectPath : IFormattable
    {
        public string DbName;
        public NameWithSchema ObjectName;
        public List<string> SubNames = new List<string>();

        public ObjectPath(string dbname)
        {
            DbName = dbname;
        }

        public ObjectPath(string dbname, NameWithSchema objname, params string[] subnames)
        {
            DbName = dbname;
            ObjectName = objname;
            SubNames.AddRange(subnames);
        }

        public ObjectPath GetChild(NameWithSchema name)
        {
            ObjectPath res = new ObjectPath(DbName);
            if (ObjectName == null)
            {
                res.ObjectName = name;
                return res;
            }
            else
            {
                res.ObjectName = ObjectName;
                res.SubNames.AddRange(SubNames);
                res.SubNames.Add(name.Name);
                return res;
            }
        }

        public NameWithSchema GetName()
        {
            if (SubNames.Count > 0) return new NameWithSchema(SubNames[SubNames.Count - 1]);
            return ObjectName;
        }

        public string GetNameWithoutSchema()
        {
            if (SubNames.Count > 0) return SubNames[SubNames.Count - 1];
            return ObjectName.Name;
        }

        public NameWithSchema GetNameWithSchema()
        {
            if (SubNames.Count > 0) return new NameWithSchema(ObjectName.Schema, SubNames[SubNames.Count - 1]);
            return ObjectName;
        }

        public override string ToString()
        {
            return ToString("S", null);
        }

        #region IFormattable Members

        public string ToString(string format, IFormatProvider formatProvider)
        {
            switch (format)
            {
                case "L":
                case "M":
                    if (SubNames.Count > 0) return ObjectName.ToString(format, formatProvider) + "." + SubNames.CreateDelimitedText(".");
                    return ObjectName.ToString(format, formatProvider);
                case "S":
                default:
                    if (SubNames.Count > 0) return SubNames[SubNames.Count - 1];
                    return ObjectName.ToString(format, formatProvider);
            }
        }

        #endregion
    }

    public static class NameWithSchemaExtension
    {
        public static string SafeGetName(this NameWithSchema name)
        {
            if (name != null) return name.Name;
            return null;
        }

        public static string SafeGetSchema(this NameWithSchema name)
        {
            if (name != null) return name.Schema;
            return null;
        }
    }

    public class FullDatabaseRelatedName
    {
        public string ObjectType;
        public NameWithSchema ObjectName;
        public string SubName;

        public override string ToString()
        {
            if (ObjectName != null)
            {
                return ObjectName.ToString();
            }
            return base.ToString();
        }
    }

    public interface IFullNamedObject
    {
        NameWithSchema FullName { get; }
    }
}
