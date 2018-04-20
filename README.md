# dbshell

DbShell is toolkit for automation of database operations.

Example - copy all tables from SQLite to MS SQL.

At first, install NuGet package DbShell.All: `Install-Package DbShell.All`

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
