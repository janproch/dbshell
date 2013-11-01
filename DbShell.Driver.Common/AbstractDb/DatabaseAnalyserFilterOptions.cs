using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Structure;

namespace DbShell.Driver.Common.AbstractDb
{
    public class DatabaseAnalyserFilterOptions
    {
        public List<string> TableFilter;
        public List<string> ViewFilter;
        public List<string> StoredProcedureFilter;
        public List<string> FunctionFilter;

        public List<string> this[DatabaseObjectType type]
        {
            get
            {
                switch (type)
                {
                    case DatabaseObjectType.Table:
                        return TableFilter;
                    case DatabaseObjectType.View:
                        return ViewFilter;
                    case DatabaseObjectType.Procedure:
                        return StoredProcedureFilter;
                    case DatabaseObjectType.Function:
                        return FunctionFilter;
                }
                throw new Exception("DBSH-0000 Invalid database object type:" + type.ToString());
            }
        }

        public void SetEmptyFilter()
        {
            TableFilter = new List<string>();
            ViewFilter = new List<string>();
            StoredProcedureFilter = new List<string>();
            FunctionFilter = new List<string>();
        }
    }
}
