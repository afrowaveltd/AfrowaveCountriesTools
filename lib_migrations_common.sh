#!/usr/bin/env bash
set -euo pipefail

# Načti .env jako KEY=VALUE (bez 'export')
load_env() {
  local file="${1:-./configure_migrations.env}"
  if [[ ! -f "$file" ]]; then
    echo "Config file not found: $file" >&2
    exit 1
  fi
  # shellcheck disable=SC2162
  while IFS='=' read k v; do
    [[ -z "${k:-}" ]] && continue
    [[ "$k" =~ ^# ]] && continue
    v="${v%$'\r'}"     # strip CR on Windows-checked-in files
    eval "$k=\"${v}\""
  done < "$file"
}

# Vytvoř defaultní název migrace (GUID bez pomlček nebo timestamp)
default_migration_name() {
  if command -v uuidgen >/dev/null 2>&1; then
    uuidgen | tr '[:upper:]' '[:lower:]' | tr -d '-'
  else
    date +%Y%m%d%H%M%S
  fi
}
