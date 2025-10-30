#!/usr/bin/env bash
set -euo pipefail
source "$(dirname "$0")/lib_migrations_common.sh"
load_env

dotnet ef migrations list \
  --project "${PROJECT_SHARED}" \
  --startup-project "${STARTUP_CONSOLONIA}" \
  --context "${DB_CONTEXT}"
