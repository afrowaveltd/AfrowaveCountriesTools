#!/usr/bin/env bash
set -euo pipefail
source "$(dirname "$0")/lib_migrations_common.sh"
load_env

TARGET="${1:-}"  # volitelné: konkrétní migrace (např. 20251030xxxxxx), jinak poslední
echo "Updating DB (Avalonia) to: ${TARGET:-latest}"

dotnet ef database update ${TARGET:+\"$TARGET\"} \
  --project "${PROJECT_SHARED}" \
  --startup-project "${STARTUP_AVALONIA}" \
  --context "${DB_CONTEXT}"
