using System;
using System.Data.Common;
using DbShell.Driver.Common.DbDiff;

namespace DbShell.Driver.Common.AbstractDb
{
    public interface IDatabaseFactory
    {
        string[] Identifiers { get; }
        Type[] ConnectionTypes { get; }
        SqlDumperCaps DumperCaps { get; }
        SqlDialectCaps DialectCaps { get; }
        DbConnection CreateConnection(string connectionString);
        DatabaseAnalyser CreateAnalyser();
        IDialectDataAdapter CreateDataAdapter();
        ISqlDumper CreateDumper(ISqlOutputStream stream, SqlFormatProperties props);
        ISqlDialect CreateDialect();
        IBulkInserter CreateBulkInserter();
        ILiteralFormatter CreateLiteralFormatter();
        IStatisticsProvider CreateStatisticsProvider();
#if !NETCOREAPP1_1
        IParsingService CreateParsingService();
#endif
        IDatabaseServerInterface CreateDatabaseServerInterface();
        ISqlTypeProvider CreateSqlTypeProvider();
    }
}
