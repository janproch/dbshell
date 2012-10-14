using System;
using System.Collections.Generic;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.Structure
{
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
}