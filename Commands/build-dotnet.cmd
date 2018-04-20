setlocal
cd ..

dotnet restore DbShell.sln

cd DbShell.All

dotnet publish DbShell.All.csproj -o ..\Commands\publish -c Release

endlocal