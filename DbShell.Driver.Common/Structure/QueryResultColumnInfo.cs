using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml;
using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.Driver.Common.DmlFramework;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.Structure
{
    public class QueryResultColumnInfo : IExplicitXmlPersistent
    {
        [XmlAttrib("name")]
        public string Name { get; set; }

        [XmlAttrib("data_type")]
        public string DataType { get; set; }

        /// <summary>
        /// Portable data type
        /// </summary>
        public DbTypeBase CommonType { get; set; }

        [XmlAttrib("is_aliased")]
        public bool IsAliased { get; set; }

        [XmlAttrib("is_hidden")]
        public bool IsHidden { get; set; }

        [XmlAttrib("is_readonly")]
        public bool IsReadOnly { get; set; }

        [XmlAttrib("is_key")]
        public bool IsKey { get; set; }

        [XmlAttrib("not_null")]
        public bool NotNull { get; set; }

        [XmlAttrib("auto_increment")]
        public bool AutoIncrement { get; set; }

        [XmlAttrib("size")]
        public int Size { get; set; }

        [XmlAttrib("base_server_name")]
        public string BaseServerName { get; set; }

        [XmlAttrib("base_catalog_name")]
        public string BaseCatalogName { get; set; }

        [XmlAttrib("base_column_name")]
        public string BaseColumnName { get; set; }

        [XmlAttrib("base_schema_name")]
        public string BaseSchemaName { get; set; }

        [XmlAttrib("base_table_name")]
        public string BaseTableName { get; set; }

        public ColumnInfo FindOriginalColumn(DatabaseInfo db, NameWithSchema baseName)
        {
            string name = IsAliased ? BaseColumnName : Name;
            if (name == null) return null;

            // determine original table name
            TableInfo table = null;
            if (!String.IsNullOrEmpty(BaseTableName))
            {
                table = db.FindTable(String.IsNullOrWhiteSpace(BaseSchemaName) ? null : BaseSchemaName, BaseTableName);
            }
            else
            {
                if (baseName != null) table = db.FindTable(baseName.Schema, baseName.Name);
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
