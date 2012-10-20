using System.Xml;
using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.Structure
{
    public class ColumnInfo : TableObjectInfo, IExplicitXmlPersistent
    {
        public ColumnInfo(TableInfo table)
            : base(table)
        {
            CommonType = new DbTypeString();
        }

        [XmlAttrib("name")]
        public string Name { get; set; }
        [XmlAttrib("datatype")]
        public string DataType { get; set; }
        [XmlAttrib("default")]
        public string DefaultValue { get; set; }
        [XmlAttrib("length")]
        public int Length { get; set; }
        [XmlAttrib("notnull")]
        public bool NotNull { get; set; }
        [XmlAttrib("precision")]
        public int Precision { get; set; }
        [XmlAttrib("scale")]
        public int Scale { get; set; }
        [XmlAttrib("auto_increment")]
        public bool AutoIncrement { get; set; }
        [XmlAttrib("primary_key")]
        public bool PrimaryKey { get; set; }
        [XmlAttrib("comment")]
        public string Comment { get; set; }

        public DbTypeBase CommonType { get; set; }

        public ColumnInfo Clone()
        {
            var res = new ColumnInfo(OwnerTable);
            res.Assign(this);
            return res;
        }

        public void SaveToXml(XmlElement xml)
        {
            this.SavePropertiesCore(xml);
            if (CommonType != null)
            {
                CommonType.SaveToXml(xml.AddChild("Type"));
            }
        }

        public void LoadFromXml(XmlElement xml)
        {
            this.LoadPropertiesCore(xml);
            var type = xml.FindElement("Type");
            if (type != null) CommonType = DbTypeBase.Load(type);
        }
    }
}