setlocal

call clean.cmd

call build-dotnet.cmd

call setversion.cmd %1
call build-nupkg.cmd
call upload.cmd %1
rem del *.nupkg

endlocal
