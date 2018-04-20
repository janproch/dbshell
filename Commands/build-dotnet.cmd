setlocal
cd ..

dotnet restore DbShell.sln

cd DbShell

dotnet publish DbShell.csproj -o ..\Commands\publish -c Release

endlocal