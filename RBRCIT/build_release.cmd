rem del /q release\*
rem cd bin\Debug\
del "RBRCIT v%1%.zip"
"%ProgramFiles%\7-zip\7z" a "RBRCIT v%1%.zip" .\bin\Debug\RBRCIT.exe
"%ProgramFiles%\7-zip\7z" a "RBRCIT v%1%.zip" RBRCIT.ini
"%ProgramFiles%\7-zip\7z" a "RBRCIT v%1%.zip" RBRCIT.readme.txt
"%ProgramFiles%\7-zip\7z" a "RBRCIT v%1%.zip" .\release\RBRCIT\
pause
