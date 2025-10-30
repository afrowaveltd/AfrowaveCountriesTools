@echo off
setlocal ENABLEEXTENSIONS

REM Načte KEY=VALUE páry z configure_migrations.env do proměnných prostředí
REM (ignoruje prázdné řádky a řádky začínající #)
if "%~1"=="" (
  set "_CFG=configure_migrations.env"
) else (
  set "_CFG=%~1"
)

if not exist "%_CFG%" (
  echo Config file not found: %_CFG%
  exit /b 1
)

for /f "usebackq tokens=1,2 delims==" %%A in ("%_CFG%") do (
  set "_line=%%A"
  if not "%%A"=="" if not "!_line:~0,1!"=="#" (
    set "%%A=%%B"
  )
)

REM Vytvoří defaultní název migrace (GUID bez pomlček)
REM Ukládej do %MIGRATION_NAME% pouze pokud ještě není nastaveno
if "%MIGRATION_NAME%"=="" (
  for /f %%i in ('powershell -NoProfile -Command "[guid]::NewGuid().ToString(''N'')"') do set "MIGRATION_NAME=%%i"
)
endlocal & set "PROJECT_SHARED=%PROJECT_SHARED%" & set "DB_CONTEXT=%DB_CONTEXT%" ^
  & set "NAMESPACE_BASE=%NAMESPACE_BASE%" ^
  & set "STARTUP_AVALONIA=%STARTUP_AVALONIA%" & set "OUTDIR_AVALONIA=%OUTDIR_AVALONIA%" ^
  & set "STARTUP_CONSOLONIA=%STARTUP_CONSOLONIA%" & set "OUTDIR_CONSOLONIA=%OUTDIR_CONSOLONIA%" ^
  & set "MIGRATION_NAME=%MIGRATION_NAME%"
