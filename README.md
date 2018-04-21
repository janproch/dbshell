# DbShell

DbShell is toolkit for automation of database operations.
DbShell packages can be used individualy, but you have to customize DI containers (call appropriate services.AddXXX extension methods).
If you don't have time to do that, install NuGet package DbShell.All: `Install-Package DbShell.All`

## Example - copy all tables from SQLite to MS SQL.

```
using DbShell.All;
using DbShell.Core;

...

var copyAll = new CopyAllTables
{
    SourceConnection = "sqlite://Data Source=PATH_TO_SQLITE_FILE",
    TargetConnection = "sqlserver://SQLSERVER_CONNECTION_STRING",
    DisableConstraints = true,
};

copyAll.Run();
```

## Example - get table names and table columns
```
// build service containing all supported database egnines and file formats, with default logging
var serviceProvider = DbShellUtility.BuildDefaultServiceProvider();

// create connection provider from provider string
var connectionProvider = ConnectionProvider.FromString(serviceProvider, "sqlserver://SQLSERVER_CONNECTION_STRING");

using (var conn = connectionProvider.Connect())
{
    // create analyser - object which analyses database structure
    var analyser = connectionProvider.Factory.CreateAnalyser();

    // assign DbConnection to analyse
    analyser.Connection = conn;

    // analyse only tables. If this line is omited, all database objects (eg. views, stored procedures...) will be analysed
    analyser.Phase = DatabaseAnalysePhase.Tables;

    // perform full analysis (other option is IncrementalAnalysis, when changes are detected)
    analyser.FullAnalysis();

    // get result structure
    var analysedStructure = analyser.Structure;

    // print table and column names
    foreach (var table in analysedStructure.Tables)
    {
        Console.WriteLine(table.Name);
        foreach (var column in table.Columns)
        {
            Console.WriteLine("    " + column.Name + " " + column.DataType);
        }
    }
}

```
