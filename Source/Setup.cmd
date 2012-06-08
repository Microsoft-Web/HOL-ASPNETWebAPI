@echo off
setlocal
CD /d "%~dp0"

::Test If script has Admin Priviledges/is elevated
REG QUERY "HKU\S-1-5-19"
IF %ERRORLEVEL% NEQ 0 (
    ECHO Please run this script as an administrator
    pause
    EXIT /B 1
)
cls
echo Setup Options
echo =============
echo.
echo 1. Check dependencies and execute setup scripts. 
echo    Note: requires internet connection.
echo.
echo 2. Execute setup scripts only.
echo    WARNING: The setup could fail and the Hands-on Lab might not work properly if you don't have all the prerequisites installed.
echo.
echo 3. Exit.
echo.
choice /c:123 /M "Choose an option: " 
if errorlevel 3 goto exit
if errorlevel 2 goto execsetup
if errorlevel 1 goto downloaddc

:downloaddc
REM Here executes the PS1 to download the DC.EXE.
echo Downloading Dependency Checker

IF EXIST %WINDIR%\SysWow64 (
set powerShellDir=%WINDIR%\SysWow64\windowspowershell\v1.0
) ELSE (
set powerShellDir=%WINDIR%\system32\windowspowershell\v1.0
)

call %powerShellDir%\powershell.exe -Command Set-ExecutionPolicy unrestricted
call %powerShellDir%\powershell.exe -Command "&'.\Setup\Scripts\RunDC.ps1'"
goto pause

:execsetup
REM Here executes the Setup.cmd only.
echo Executing setup scripts.
call .\Setup\Setup.cmd
goto exit

:pause
pause

:exit


