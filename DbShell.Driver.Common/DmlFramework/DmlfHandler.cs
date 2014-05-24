using System.Collections.Generic;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.DmlFramework
{
    public class DmlfHandler : IDmlfHandler
    {
        public Dictionary<NameWithSchema, TableInfo> Tables = new Dictionary<NameWithSchema, TableInfo>();
        public TableInfo BaseStructure;
        public DatabaseInfo Database;

        #region IDmlfHandler Members

        public virtual TableInfo GetStructure(NameWithSchema name)
        {
            if (name == null && BaseStructure != null) return BaseStructure;
            var res = Tables.Get(name);
            if (res != null) return res;
            //if (Database != null && name != null) return Database.GetTable(name).InvokeLoadStructure(TableInfoMembers.ColumnNames | TableInfoMembers.PrimaryKey);
            //if (Database != null && BaseTable != null && BaseTable.TableOrView != null) return Database.GetTable(BaseTable.TableOrView).InvokeLoadStructure(TableInfoMembers.ColumnNames | TableInfoMembers.PrimaryKey);
            return null;
        }

        public DmlfSource BaseTable { get; set; }

        #endregion
    }
}