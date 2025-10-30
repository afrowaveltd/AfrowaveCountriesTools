#!/usr/bin/env bash
set -euo pipefail
source "$(dirname "$0")/lib_migrations_common.sh"
load_env

echo "Removing last Consolonia migration (no database changes)..."
dotnet ef migrations remove \
  --project "${PROJECT_SHARED}" \
  --startup-project "${STARTUP_CONSOLONIA}" \
  --context "${DB_CONTEXT}"
