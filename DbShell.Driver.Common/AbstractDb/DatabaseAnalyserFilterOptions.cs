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
        public bool GlobalSettings = true;

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
                    case DatabaseObjectType.StoredProcedure:
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
            GlobalSettings = false;
        }

        public bool AnyTables
        {
            get { return TableFilter == null || TableFilter.Count > 0; }
        }

        public bool AnyViews
        {
            get { return ViewFilter == null || ViewFilter.Count > 0; }
        }

        public bool AnyStoredProcedures
        {
            get { return StoredProcedureFilter == null || StoredProcedureFilter.Count > 0; }
        }

        public bool AnyFunctions
        {
            get { return FunctionFilter == null || FunctionFilter.Count > 0; }
        }
    }
}
