del /q release\*
cd bin\Debug\
"%ProgramFiles%\7-zip\7z" a "..\..\release\RBRCIT v%1%.zip" RBRCIT.exe
"%ProgramFiles%\7-zip\7z" a "..\..\release\RBRCIT v%1%.zip" RBRCIT.ini
"%ProgramFiles%\7-zip\7z" a "..\..\release\RBRCIT v%1%.zip" RBRCIT.readme.txt
"%ProgramFiles%\7-zip\7z" a "..\..\release\RBRCIT v%1%.zip" ..\..\release\RBRCIT\
pause
