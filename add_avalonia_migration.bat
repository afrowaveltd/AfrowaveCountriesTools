@echo off
setlocal ENABLEEXTENSIONS ENABLEDELAYEDEXECUTION
set "MIGRATION_NAME=%~1"
call "%~dp0lib_migrations_common.bat" "%~dp0configure_migrations.env"

if "%MIGRATION_NAME%"=="" (
  REM lib nastaví MIGRATION_NAME (GUID bez pomlček)
)

echo Adding Avalonia migration: %MIGRATION_NAME%

dotnet ef migrations add "%MIGRATION_NAME%" ^
  --project "%PROJECT_SHARED%" ^
  --startup-project "%STARTUP_AVALONIA%" ^
  --context "%DB_CONTEXT%" ^
  --output-dir "%OUTDIR_AVALONIA%" ^
  --namespace "%NAMESPACE_BASE%.Avalonia"
