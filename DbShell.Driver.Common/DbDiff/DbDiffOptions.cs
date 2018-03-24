using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.DbDiff
{
    public class DbDiffOptions
    {
        public DbDiffSpecObjectOptions DefaultSpecObject = new DbDiffSpecObjectOptions();

        public DbDiffSpecObjectOptions GetSpecObject(string objtype) { return DefaultSpecObject; }

        //public DbDiffSchemaMode LeftSchemaMode = DbDiffSchemaMode.IngoreImplicit, RightSchemaMode = DbDiffSchemaMode.IngoreImplicit;
        public DbDiffSchemaMode SchemaMode;
        public string LeftImplicitSchema, RightImplicitSchema;

        public bool AllowRecreateTable;
        public bool AllowRecreateConstraint;
        public bool AllowRecreateSpecificObject;
        public bool AllowPairRenamedTables = false;

        //public bool AllowCascadeReferenceUpdate = false;

        public bool IgnoreColumnOrder;
        public bool IgnoreConstraintNames;
        public bool IgnoreAllTableProperties;
        public bool IgnoreAllDatabaseProperties;
        public bool IgnoreColumnCharacterSet;
        public bool IgnoreColumnCollation;
        public bool IgnoreSpecificData;
        public bool IgnoreCase;
        public List<string> IgnoreDataTypeProperties = new List<string>();
        public List<string> IgnoreTableProperties = new List<string>();
        public List<string> IgnoreDatabaseProperties = new List<string>();

        public IMessageLogger DiffLogger = null;
        public IMessageLogger AlterLogger = null;

        public static DbDiffOptions AlterStructureOptions()
        {
            return new DbDiffOptions
            {
                AllowRecreateConstraint = true,
            };
        }

        internal void SetLogger(DbDiffOptsLogger ltype, IMessageLogger logger)
        {
            if (ltype == DbDiffOptsLogger.DiffLogger) DiffLogger = logger;
            if (ltype == DbDiffOptsLogger.AlterLogger) AlterLogger = logger;
        }

        public DbDiffOptions Clone()
        {
            var res = (DbDiffOptions)MemberwiseClone();
            res.IgnoreTableProperties = new List<string>(IgnoreTableProperties);
            res.IgnoreDataTypeProperties = new List<string>(IgnoreDataTypeProperties);
            res.DefaultSpecObject = DefaultSpecObject.Clone();
            return res;
        }
    }

    public enum DbDiffOptsLogger { DiffLogger, AlterLogger }
    public enum DbDiffSchemaMode { Strict, Ignore, IngoreImplicit }

    public class DbDiffSpecObjectOptions
    {
        public bool CompareCreateSql = true;
        public DbDiffSpecObjectOptions Clone()
        {
            var res = (DbDiffSpecObjectOptions)MemberwiseClone();
            return res;
        }
    }

    public class DbDiffChangeLoggerContext : IDisposable
    {
        IMessageLogger m_oldValue;
        DbDiffOptions m_opts;
        DbDiffOptsLogger m_ltype;

        public DbDiffChangeLoggerContext(DbDiffOptions opts, IMessageLogger logger, DbDiffOptsLogger ltype)
        {
            m_opts = opts;
            m_ltype = ltype;
            m_oldValue = m_opts.DiffLogger;
            m_opts.SetLogger(m_ltype, logger);
        }

        #region IDisposable Members

        public void Dispose()
        {
            m_opts.SetLogger(m_ltype, m_oldValue);
        }

        #endregion
    }
}
