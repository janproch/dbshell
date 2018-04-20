mkdir publish\Samples
xcopy ..\Samples\*.* publish\Samples

rename publish dbshell

zip\zip.exe dbshell.zip dbshell\*.* -r

rename dbshell publish
