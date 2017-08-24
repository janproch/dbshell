using System.Collections.Generic;
using System.Linq;
using System.Xml;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.Driver.Common.Utility;
using System.Text;
using System.Runtime.Serialization;

namespace DbShell.Driver.Common.Structure
{
    /// <summary>
    /// Information about column structure
    /// </summary>
    [DataContract]
    public class ColumnInfo : TableObjectInfo, IExplicitXmlPersistent
    {
        public ColumnInfo(TableInfo table)
            : base(table)
        {
            CommonType = new DbTypeString();
        }

        /// <summary>
        /// Column name
        /// </summary>
        [XmlAttrib("name")]
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Data type
        /// </summary>
        [XmlAttrib("datatype")]
        [DataMember]
        public string DataType { get; set; }

        /// <summary>
        /// Default value
        /// </summary>
        [XmlAttrib("default")]
        [DataMember]
        public string DefaultValue { get; set; }

        /// <summary>
        /// String length
        /// </summary>
        [XmlAttrib("length")]
        [DataMember]
        public int Length { get; set; }

        /// <summary>
        /// Column cannot be null
        /// </summary>
        [XmlAttrib("notnull")]
        [DataMember]
        public bool NotNull { get; set; }

        /// <summary>
        /// Precision if decimal number
        /// </summary>
        [XmlAttrib("precision")]
        [DataMember]
        public int Precision { get; set; }

        /// <summary>
        /// Scale of decimal number
        /// </summary>
        [XmlAttrib("scale")]
        [DataMember]
        public int Scale { get; set; }

        /// <summary>
        /// Is Identity?
        /// </summary>
        [XmlAttrib("auto_increment")]
        [DataMember]
        public bool AutoIncrement { get; set; }

        /// <summary>
        /// Is part of primary key?
        /// </summary>
        [XmlAttrib("primary_key")]
        [DataMember]
        public bool PrimaryKey { get; set; }

        /// <summary>
        /// Comment
        /// </summary>
        [XmlAttrib("comment")]
        [DataMember]
        public string Comment { get; set; }

        /// <summary>
        /// name of default constraint
        /// </summary>
        [XmlAttrib("default_constraint")]
        [DataMember]
        public string DefaultConstraint { get; set; }

        /// <summary>
        /// expression for computed column
        /// </summary>
        [XmlAttrib("computed_expression")]
        [DataMember]
        public string ComputedExpression { get; set; }

        /// <summary>
        /// whether computed column is persisted
        /// </summary>
        [XmlAttrib("is_persisted")]
        [DataMember]
        public bool IsPersisted { get; set; }

        /// <summary>
        /// whether computed column is sparse
        /// </summary>
        [XmlAttrib("is_sparse")]
        [DataMember]
        public bool IsSparse { get; set; }

        /// <summary>
        /// Portable data type
        /// </summary>
        public DbTypeBase CommonType { get; set; }

        [DataMember]
        public FilterParserTool.ExpressionType FilterType => FilterParserTool.GetExpressionType(CommonType);

        [DataMember]
        public string CommonTypeCode => CommonType?.Code.ToString();

        public int ColumnOrder
        {
            get
            {
                if (OwnerTable == null) return -1;
                return OwnerTable.Columns.IndexOf(this);
            }
        }

        public ColumnInfo CloneColumn(TableInfo ownTable = null)
        {
            var res = new ColumnInfo(ownTable ?? OwnerTable);
            res.Assign(this);
            return res;
        }

        public override DatabaseObjectInfo CloneObject(DatabaseObjectInfo owner)
        {
            return CloneColumn(owner as TableInfo);
        }

        public override void Assign(DatabaseObjectInfo source)
        {
            base.Assign(source);
            var src = (ColumnInfo)source;
            Name = src.Name;
            DataType = src.DataType;
            DefaultValue = src.DefaultValue;
            DefaultConstraint = src.DefaultConstraint;
            Length = src.Length;
            NotNull = src.NotNull;
            Precision = src.Precision;
            Scale = src.Scale;
            AutoIncrement = src.AutoIncrement;
            PrimaryKey = src.PrimaryKey;
            Comment = src.Comment;
            IsPersisted = src.IsPersisted;
            ComputedExpression = src.ComputedExpression;
            IsSparse = src.IsSparse;
            if (src.CommonType != null) CommonType = src.CommonType.Clone();
            else CommonType = null;
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

        public List<ForeignKeyInfo> GetForeignKeys()
        {
            var res = new List<ForeignKeyInfo>();
            if (OwnerTable != null)
            {
                foreach (var fk in OwnerTable.ForeignKeys)
                {
                    if (fk.Columns.Any(c => c.RefColumn == this))
                    {
                        res.Add(fk);
                    }
                }
            }
            return res;
        }

        public bool IsSingleColumnPk()
        {
            if (OwnerTable?.PrimaryKey?.Columns?.Count != 1) return false;
            return OwnerTable.PrimaryKey.Columns[0].RefColumn == this;
        }

        public string LengthDisplay
        {
            get
            {
                if (CommonType is DbTypeNumeric) return $"{Precision}, {Scale}";
                if (Length == 0) return "";
                if (Length == -1) return "max";
                return Length.ToString();
            }
        }

        public string DefaultValueDisplay
        {
            get
            {
                string res = DefaultValue;
                while (res != null && res.StartsWith("(") && res.EndsWith(")"))
                {
                    res = res.Substring(1, res.Length - 2);
                }
                return res;
            }
        }

        public override DatabaseObjectType ObjectType
        {
            get { return DatabaseObjectType.Column; }
        }

        public override void SetDummyTable(NameWithSchema name)
        {
            var table = new TableInfo(null);
            table.FullName = name;
            table.Columns.Add(this);
        }

        public bool IsStringColumn()
        {
            if (DataType != null) return DataType.ToLower().Contains("char");
            if (CommonType != null) return CommonType is DbTypeString;
            return true;
        }

        public void EnsureDataType(ISqlTypeProvider typeProvider)
        {
            if (DataType == null)
            {
                typeProvider.GetNativeDataType(CommonType, this);
            }
        }

        public override FullDatabaseRelatedName GetName()
        {
            return new FullDatabaseRelatedName
            {
                ObjectName = OwnerTable != null ? OwnerTable.FullName : null,
                ObjectType = DatabaseObjectType.Column,
                SubName = Name,
            };
        }

        public override string ToString()
        {
            string res = Name;
            if (OwnerTable != null && OwnerTable.FullName != null) res = OwnerTable.FullName.ToString() + "." + res;
            return res;
        }

        public string GetSqlType()
        {
            var sb = new StringBuilder();
            sb.Append(DataType);
            if (Length != 0 && (CommonType == null || CommonType is DbTypeString))
            {
                if (Length == -1 || Length > 8000) sb.Append("(max)");
                else sb.Append($"({Length})");
            }
            if (Precision > 0 && CommonType is DbTypeNumeric && (DataType.ToLower() != "money"))
            {
                sb.Append($"({Precision},{Scale})");
            }
            return sb.ToString();
        }
    }
}