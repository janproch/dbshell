﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.DbDiff;

namespace DbShell.Driver.Sqlite
{
    public class SqliteDatabaseFactory : DatabaseFactoryBase
    {
        public static readonly SqliteDatabaseFactory Instance = new SqliteDatabaseFactory();

        public override string[] Identifiers
        {
            get { return new string[] {"sqlite"}; }
        }

        public override DbConnection CreateConnection(string connectionString)
        {
            return new SQLiteConnection(connectionString);
        }

        public override Type[] ConnectionTypes
        {
            get { return new Type[] {typeof (SQLiteConnection)}; }
        }

        public override ISqlDumper CreateDumper(ISqlOutputStream stream, SqlFormatProperties props)
        {
            return new SqliteSqlDumper(stream, this, props);
        }

        public override ISqlDialect CreateDialect()
        {
            return new SqliteDialect();
        }

        public static void Initialize()
        {
            FactoryProvider.RegisterFactory(Instance);
        }

        public override DatabaseAnalyser CreateAnalyser()
        {
            return new SqliteAnalyser();
        }

        public override SqlDialectCaps DialectCaps
        {
            get
            {
                var res = base.DialectCaps;
                res.MultiCommand = true;
                res.ForeignKeys = true;
                res.Uniques = false;
                res.MultipleSchema = false;
                res.MultipleDatabase = false;
                res.UncheckedReferences = true;
                res.NestedTransactions = true;
                res.AnonymousPrimaryKey = true;
                res.RangeSelect = true;
                return res;
            }
        }
    }
}
