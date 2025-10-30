@echo off
call "%~dp0lib_migrations_common.bat" "%~dp0configure_migrations.env"
echo Removing last Avalonia migration (no database changes)...
dotnet ef migrations remove ^
  --project "%PROJECT_SHARED%" ^
  --startup-project "%STARTUP_AVALONIA%" ^
  --context "%DB_CONTEXT%"
