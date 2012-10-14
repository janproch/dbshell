using System.Collections.Generic;
using System.Linq;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.Structure
{
    public abstract class DatabaseObjectInfo
    {
        public DatabaseInfo OwnerDatabase { get; private set; }

        public DatabaseObjectInfo(DatabaseInfo database)
        {
            OwnerDatabase = database;
        }

        protected virtual void Assign(DatabaseObjectInfo source)
        {
        }
    }

    public abstract class NamedObjectInfo : DatabaseObjectInfo
    {
        public NameWithSchema FullName { get; set; }

        public string Name { get { return FullName.Name; } }
        public string Schema { get { return FullName.Schema; } }

        public NamedObjectInfo(DatabaseInfo database)
            : base(database)
        {
        }

        protected override void Assign(DatabaseObjectInfo source)
        {
            base.Assign(source);
            var src = (NamedObjectInfo) source;
            FullName = src.FullName;
        }
    }

    public class ColumnList : List<ColumnInfo>
    {
        public int GetIndex(string name)
        {
            return this.IndexOfIf(c => c.Name == name);
        }

        public ColumnInfo this[string name]
        {
            get
            {
                int index = GetIndex(name);
                if (index < 0) return null;
                return this[index];
            }
        }
    }

    public abstract class ColumnListInfo : NamedObjectInfo
    {
        private ColumnList _columns = new ColumnList();

        public ColumnList Columns { get { return _columns; } }

        public int ColumnCount { get { return Columns.Count; } }

        public ColumnListInfo(DatabaseInfo database)
            : base(database)
        {
        }

        protected override void Assign(DatabaseObjectInfo source)
        {
            base.Assign(source);
            var src = (ColumnListInfo) source;
            foreach (var col in src.Columns) Columns.Add(col.Clone());
        }
    }

    public class ViewInfo : ColumnListInfo
    {
        public ViewInfo(DatabaseInfo database)
            : base(database)
        {
        }
    }

    public class TableInfo : ColumnListInfo
    {
        public TableInfo(DatabaseInfo database)
            : base(database)
        {
        }

        private List<ForeignKeyInfo> _foreignKeys = new List<ForeignKeyInfo>();


        public PrimaryKeyInfo PrimaryKey { get; set; }
        public List<ForeignKeyInfo> ForeignKeys { get { return _foreignKeys; } }

        public TableInfo Clone()
        {
            var res = new TableInfo(OwnerDatabase);
            res.Assign(this);
            return res;
        }

        public ColumnInfo FindAutoIncrementColumn()
        {
            foreach (var col in Columns)
            {
                if (col.AutoIncrement) return col;
            }
            return null;
        }

        public List<ForeignKeyInfo> GetReferences()
        {
            var res = new List<ForeignKeyInfo>();
            foreach (var table in OwnerDatabase.Tables)
            {
                foreach (var fk in table.ForeignKeys)
                {
                    if (fk.RefTable == this) res.Add(fk);
                }
            }
            return res;
        }
    }

    public class TableObjectInfo : DatabaseObjectInfo
    {
        public TableInfo OwnerTable { get; private set; }

        public TableObjectInfo(TableInfo table)
            : base(table.OwnerDatabase)
        {
            OwnerTable = table;
        }
    }

    public class ColumnInfo : TableObjectInfo
    {
        public ColumnInfo(TableInfo table)
            : base(table)
        {
            CommonType = new DbTypeString();
        }

        public string Name { get; set; }
        public string DataType { get; set; }
        public string DefaultValue { get; set; }
        public int Length { get; set; }
        public bool NotNull { get; set; }
        public int Precision { get; set; }
        public int Scale { get; set; }
        public bool AutoIncrement;
        public bool PrimaryKey;
        public string Comment { get; set; }

        public DbTypeBase CommonType { get; set; }

        public ColumnInfo Clone()
        {
            var res = new ColumnInfo(OwnerTable);
            res.Assign(this);
            return res;
        }
    }

    public class ColumnReference
    {
        public ColumnInfo RefColumn { get; set; }

        public string Name
        {
            get
            {
                if (RefColumn == null) return null;
                return RefColumn.Name;
            }
        }
        //public string ColumnName { get; set; }
    }

    public class ColumnsConstraintInfo : TableObjectInfo
    {
        private List<ColumnReference> _columns = new List<ColumnReference>();
        public List<ColumnReference> Columns { get { return _columns; } }

        public ColumnsConstraintInfo(TableInfo table)
            :base(table)
        {
            
        }
    }

    public class PrimaryKeyInfo : ColumnsConstraintInfo
    {
        public string ConstraintName;

        public PrimaryKeyInfo(TableInfo table)
            :base(table)
        {
            
        }
    }

    public class ForeignKeyInfo : ColumnsConstraintInfo
    {
        public string ConstraintName;

        private List<ColumnReference> _refColumns = new List<ColumnReference>();

        public TableInfo RefTable { get; set; }
        public List<ColumnReference> RefColumns { get { return _refColumns; } }

        public ForeignKeyInfo(TableInfo table)
            :base(table)
        {
            
        }
    }

    public static class ColumnInfoExtension
    {
        public static string[] GetNames(this IEnumerable<ColumnInfo> cols)
        {
            return new List<string>(from c in cols select c.Name).ToArray();
        }
        public static string[] GetNames(this IEnumerable<ColumnReference> refs)
        {
            return new List<string>(from c in refs select c.RefColumn.Name).ToArray();
        }
    }
}
