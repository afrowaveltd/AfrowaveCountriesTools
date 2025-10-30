@echo off
call "%~dp0lib_migrations_common.bat" "%~dp0configure_migrations.env"
dotnet ef migrations list ^
  --project "%PROJECT_SHARED%" ^
  --startup-project "%STARTUP_CONSOLONIA%" ^
  --context "%DB_CONTEXT%"
