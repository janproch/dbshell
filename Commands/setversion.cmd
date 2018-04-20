setlocal

copy nuget\DbShell.All.nuspec build\DbShell.All.nuspec
ReplaceInFile build\DbShell.All.nuspec 0.0.3811 %1
copy nuget\DbShell.Core.nuspec build\DbShell.Core.nuspec
ReplaceInFile build\DbShell.Core.nuspec 0.0.3811 %1
copy nuget\DbShell.Csv.nuspec build\DbShell.Csv.nuspec
ReplaceInFile build\DbShell.Csv.nuspec 0.0.3811 %1
copy nuget\DbShell.Driver.Common.nuspec build\DbShell.Driver.Common.nuspec
ReplaceInFile build\DbShell.Driver.Common.nuspec 0.0.3811 %1
copy nuget\DbShell.Driver.MySql.nuspec build\DbShell.Driver.MySql.nuspec
ReplaceInFile build\DbShell.Driver.MySql.nuspec 0.0.3811 %1
copy nuget\DbShell.Driver.Postgres.nuspec build\DbShell.Driver.Postgres.nuspec
ReplaceInFile build\DbShell.Driver.Postgres.nuspec 0.0.3811 %1
copy nuget\DbShell.Driver.Sqlite.nuspec build\DbShell.Driver.Sqlite.nuspec
ReplaceInFile build\DbShell.Driver.Sqlite.nuspec 0.0.3811 %1
copy nuget\DbShell.Driver.SqlServer.nuspec build\DbShell.Driver.SqlServer.nuspec
ReplaceInFile build\DbShell.Driver.SqlServer.nuspec 0.0.3811 %1
copy nuget\DbShell.Excel.nuspec build\DbShell.Excel.nuspec
ReplaceInFile build\DbShell.Excel.nuspec 0.0.3811 %1
copy nuget\DbShell.Xml.nuspec build\DbShell.Xml.nuspec
ReplaceInFile build\DbShell.Xml.nuspec 0.0.3811 %1

endlocal