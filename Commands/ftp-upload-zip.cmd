setlocal

echo user > ftp_commands.txt
echo jenasoft_com >> ftp_commands.txt
echo draklesu>> ftp_commands.txt
echo bin >> ftp_commands.txt
echo cd jenasoft.com >> ftp_commands.txt
echo cd files >> ftp_commands.txt
echo put dbshell.zip >> ftp_commands.txt
echo bye >> ftp_commands.txt

ftp -n -s:ftp_commands.txt www.jenasoft.com

del ftp_commands.txt

endlocal
