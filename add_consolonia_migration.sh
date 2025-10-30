#!/usr/bin/env bash
set -euo pipefail
source "$(dirname "$0")/lib_migrations_common.sh"
load_env

MIGRATION_NAME="${1:-$(default_migration_name)}"
echo "Adding Consolonia migration: ${MIGRATION_NAME}"

dotnet ef migrations add "${MIGRATION_NAME}" \
  --project "${PROJECT_SHARED}" \
  --startup-project "${STARTUP_CONSOLONIA}" \
  --context "${DB_CONTEXT}" \
  --output-dir "${OUTDIR_CONSOLONIA}" \
  --namespace "${NAMESPACE_BASE}.Consolonia"
