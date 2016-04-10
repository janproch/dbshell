using System;
using System.ComponentModel;
using System.Data;
using System.Xml;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.CommonTypeSystem
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public abstract class DbTypeBase 
    {
        [Browsable(false)]
        public abstract DbTypeCode Code { get; }
        [Browsable(false)]
        public abstract Type DotNetType { get; }
        [Browsable(false)]
        public abstract string XsdType { get; }
        [Browsable(false)]
        public abstract TypeStorage DefaultStorage { get; }


        public static DbTypeBase CreateType(DbTypeCode code)
        {
            switch (code)
            {
                case DbTypeCode.Int: return new DbTypeInt();
                case DbTypeCode.String: return new DbTypeString();
                case DbTypeCode.Logical: return new DbTypeLogical();
                case DbTypeCode.Datetime: return new DbTypeDatetime();
                case DbTypeCode.Numeric: return new DbTypeNumeric();
                case DbTypeCode.Blob: return new DbTypeBlob();
                case DbTypeCode.Text: return new DbTypeText();
                case DbTypeCode.Float: return new DbTypeFloat();
                case DbTypeCode.Guid: return new DbTypeGuid();
                case DbTypeCode.Xml: return new DbTypeXml();
                case DbTypeCode.Array: return new DbTypeArray();
                case DbTypeCode.Generic: return new DbTypeGeneric();
            }
            throw new InternalError(String.Format("DBSH-00071 Unknown db type code: {0}", code));
        }

        public virtual void SetAutoincrement(bool value) { }
        public virtual bool IsAutoIncrement() { return false; }

        public virtual void SetLength(int value) { }
        public virtual int GetLength() { return 0; }

        public virtual void SetScale(int value) { }
        public virtual int GetScale() { return 0; }

        public virtual void SaveToXml(XmlElement xml)
        {
            xml.SetAttribute("datatype", Code.ToString().ToLower());
            XmlTool.SaveProperties(this, xml);
        }

        protected virtual void LoadFromXml(XmlElement xml)
        {
            XmlTool.LoadProperties(this, xml);
        }

        public static DbTypeBase Load(XmlElement xml)
        {
            DbTypeCode code = (DbTypeCode)Enum.Parse(typeof(DbTypeCode), xml.GetAttribute("datatype"), true);
            DbTypeBase res = DbTypeBase.CreateType(code);
            res.LoadFromXml(xml);
            return res;
        }

        public virtual int GetSize() { return 0; }

        public abstract DbType GetProviderType();

        public DbTypeBase Clone()
        {
            var res = (DbTypeBase)MemberwiseClone();
            return res;
        }

        public static bool IsComparable(DbTypeBase type)
        {
            if (type is DbTypeXml || type is DbTypeBlob) return false;
            return true;
        }

        /// <summary>
        /// tries to parse type from any database engine. It could be not exact, for exact parse use methods from specific database factory
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public static DbTypeBase ParseType(string dataType)
        {
            var parser = new DbTypeParser(dataType);
            return parser.CommonType;
        }
    }
}