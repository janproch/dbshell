setlocal

call clean.cmd

call build-dotnet.cmd

call create-zip.cmd

call ftp-upload-zip.cmd

endlocal
