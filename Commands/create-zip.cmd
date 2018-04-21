mkdir publish\Samples
xcopy ..\Samples\*.* publish\Samples /s /e

rename publish dbshell

zip\zip.exe dbshell.zip dbshell\*.* -r

rename dbshell publish
