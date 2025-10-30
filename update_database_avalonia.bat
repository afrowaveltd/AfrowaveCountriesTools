@echo off
set "TARGET=%~1"
call "%~dp0lib_migrations_common.bat" "%~dp0configure_migrations.env"
echo Updating DB (Avalonia) to: %TARGET%
if "%TARGET%"=="" (
  dotnet ef database update ^
    --project "%PROJECT_SHARED%" ^
    --startup-project "%STARTUP_AVALONIA%" ^
    --context "%DB_CONTEXT%"
) else (
  dotnet ef database update "%TARGET%" ^
    --project "%PROJECT_SHARED%" ^
    --startup-project "%STARTUP_AVALONIA%" ^
    --context "%DB_CONTEXT%"
)
