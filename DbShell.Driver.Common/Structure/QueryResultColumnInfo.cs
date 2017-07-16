using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml;
using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.Driver.Common.DmlFramework;
using DbShell.Driver.Common.Utility;
using System.Runtime.Serialization;

namespace DbShell.Driver.Common.Structure
{
    [DataContract]
    public class QueryResultColumnInfo : IExplicitXmlPersistent
    {
        [XmlAttrib("name")]
        [DataMember]
        public string Name { get; set; }

        [XmlAttrib("data_type")]
        [DataMember]
        public string DataType { get; set; }

        /// <summary>
        /// Portable data type
        /// </summary>
        public DbTypeBase CommonType { get; set; }

        [XmlAttrib("is_aliased")]
        [DataMember]
        public bool IsAliased { get; set; }

        [XmlAttrib("is_hidden")]
        [DataMember]
        public bool IsHidden { get; set; }

        [XmlAttrib("is_readonly")]
        [DataMember]
        public bool IsReadOnly { get; set; }

        [XmlAttrib("is_key")]
        [DataMember]
        public bool IsKey { get; set; }

        [XmlAttrib("not_null")]
        [DataMember]
        public bool NotNull { get; set; }

        [XmlAttrib("auto_increment")]
        [DataMember]
        public bool AutoIncrement { get; set; }

        [XmlAttrib("size")]
        [DataMember]
        public int Size { get; set; }

        [XmlAttrib("base_server_name")]
        [DataMember]
        public string BaseServerName { get; set; }

        [XmlAttrib("base_catalog_name")]
        [DataMember]
        public string BaseCatalogName { get; set; }

        [XmlAttrib("base_column_name")]
        [DataMember]
        public string BaseColumnName { get; set; }

        [XmlAttrib("base_schema_name")]
        [DataMember]
        public string BaseSchemaName { get; set; }

        [XmlAttrib("base_table_name")]
        [DataMember]
        public string BaseTableName { get; set; }

        public ColumnInfo FindOriginalColumn(DatabaseInfo db, NameWithSchema baseName)
        {
            string name = IsAliased ? BaseColumnName : Name;
            if (name == null) return null;

            // determine original table name
            TableInfo table = null;
            if (!String.IsNullOrEmpty(BaseTableName))
            {
                table = db.FindTableLike(String.IsNullOrWhiteSpace(BaseSchemaName) ? null : BaseSchemaName, BaseTableName);
            }
            else
            {
                if (baseName != null) table = db.FindTableLike(baseName.Schema, baseName.Name);
            }
            if (table == null) return null;

            var tableCol = table.FindColumn(name);
            return tableCol;
        }

        public void SaveToXml(XmlElement xml)
        {
            this.SavePropertiesCore(xml);
            if (CommonType != null) CommonType.SaveToXml(xml.AddChild("Type"));
        }

        public void LoadFromXml(XmlElement xml)
        {
            this.LoadPropertiesCore(xml);
            var typeElem = xml.FindElement("Type");
            if (typeElem != null) CommonType = DbTypeBase.Load(typeElem);
        }

        public QueryResultColumnInfo Clone()
        {
            var res = (QueryResultColumnInfo) MemberwiseClone();
            if (CommonType != null) res.CommonType = CommonType.Clone();
            return res;
        }
    }
}
