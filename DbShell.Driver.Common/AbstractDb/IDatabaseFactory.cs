using System;
using System.Data.Common;

namespace DbShell.Driver.Common.AbstractDb
{
    public interface IDatabaseFactory
    {
        string[] Identifiers { get; }
        Type[] ConnectionTypes { get; }
        DbConnection CreateConnection(string connectionString);
        DatabaseAnalyser CreateAnalyser();
        IDialectDataAdapter CreateDataAdapter();
        ISqlDumper CreateDumper(ISqlOutputStream stream, SqlFormatProperties props);
        ISqlDialect CreateDialect();
        IBulkInserter CreateBulkInserter();
        ILiteralFormatter CreateLiteralFormatter();
        IStatisticsProvider CreateStatisticsProvider();
        IParsingService CreateParsingService();
        IDatabaseServerInterface CreateDatabaseServerInterface();
        ISqlTypeProvider CreateSqlTypeProvider();
    }
}
