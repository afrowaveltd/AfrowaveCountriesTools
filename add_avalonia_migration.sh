#!/usr/bin/env bash
set -euo pipefail
source "$(dirname "$0")/lib_migrations_common.sh"
load_env

MIGRATION_NAME="${1:-$(default_migration_name)}"
echo "Adding Avalonia migration: ${MIGRATION_NAME}"

dotnet ef migrations add "${MIGRATION_NAME}" \
  --project "${PROJECT_SHARED}" \
  --startup-project "${STARTUP_AVALONIA}" \
  --context "${DB_CONTEXT}" \
  --output-dir "${OUTDIR_AVALONIA}" \
  --namespace "${NAMESPACE_BASE}.Avalonia"
