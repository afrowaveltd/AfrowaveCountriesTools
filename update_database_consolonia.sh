#!/usr/bin/env bash
set -euo pipefail
source "$(dirname "$0")/lib_migrations_common.sh"
load_env

TARGET="${1:-}"
echo "Updating DB (Consolonia) to: ${TARGET:-latest}"

dotnet ef database update ${TARGET:+\"$TARGET\"} \
  --project "${PROJECT_SHARED}" \
  --startup-project "${STARTUP_CONSOLONIA}" \
  --context "${DB_CONTEXT}"
