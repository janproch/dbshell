call setversion.cmd %1
call build-nupkg.cmd
call upload.cmd %1
del *.nupkg
