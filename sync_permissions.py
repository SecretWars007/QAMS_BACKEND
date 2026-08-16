import subprocess
import json

# Fetch existing codes from DB
result = subprocess.run(
    ["docker", "exec", "qams-postgres", "psql", "-U", "postgres", "-d", "qams_db", "-t", "-c", "SELECT code FROM permissions;"],
    capture_output=True, text=True
)
db_codes = set(line.strip() for line in result.stdout.split('\n') if line.strip())

# The full list of codes
all_codes = [
    "USERS_VIEW", "USERS_CREATE", "USERS_UPDATE", "USERS_DELETE", "USERS_ASSIGN_ROLES",
    "ROLES_VIEW", "ROLES_CREATE", "ROLES_UPDATE", "ROLES_DELETE", "ROLES_ASSIGN_PERMISSIONS",
    "CATALOGS_VIEW", "CATALOGS_MANAGE",
    "PROJECTS_VIEW", "PROJECTS_CREATE", "PROJECTS_UPDATE", "PROJECTS_DELETE",
    "REQUIREMENTS_VIEW", "REQUIREMENTS_CREATE", "REQUIREMENTS_UPDATE", "REQUIREMENTS_DELETE",
    "TEST_CASES_VIEW", "TEST_CASES_CREATE", "TEST_CASES_UPDATE", "TEST_CASES_DELETE",
    "EXECUTIONS_VIEW", "EXECUTIONS_CREATE", "EXECUTIONS_UPDATE", "EXECUTIONS_UPLOAD_EVIDENCE",
    "DEFECTS_VIEW", "DEFECTS_CREATE", "DEFECTS_UPDATE", "DEFECTS_DELETE",
    "REVIEWS_VIEW", "REVIEWS_CREATE", "REVIEWS_UPDATE", "REVIEWS_DELETE",
    "KANBAN_VIEW", "KANBAN_CREATE", "KANBAN_UPDATE", "KANBAN_DELETE",
    "DASHBOARD_VIEW",
    "SUT_VIEW", "SUT_CREATE", "SUT_UPDATE", "SUT_DELETE",
    "EXPLORATORY_VIEW", "EXPLORATORY_CREATE", "EXPLORATORY_UPDATE", "EXPLORATORY_DELETE",
    "ENVIRONMENTS_VIEW", "ENVIRONMENTS_CREATE", "ENVIRONMENTS_UPDATE", "ENVIRONMENTS_DELETE"
]

missing_codes = [code for code in all_codes if code not in db_codes]
print(f"Missing permissions: {missing_codes}")

# We need to insert them and assign to Lead role (33333333-3333-3333-3333-333333333333) and Admin role (11111111-1111-1111-1111-111111111111)
if missing_codes:
    sql = ""
    for code in missing_codes:
        module = code.split('_')[0].capitalize()
        # Create a deterministic GUID like C# does (but doing it in postgres using md5)
        # Or simpler: just use gen_random_uuid()
        sql += f"INSERT INTO permissions (id, code, description, module, created_at) VALUES (gen_random_uuid(), '{code}', '{code}', '{module}', NOW());\n"
    
    # After inserting permissions, insert role_permissions for Lead and Admin
    sql += "INSERT INTO role_permissions (role_id, permission_id, assigned_at) SELECT '33333333-3333-3333-3333-333333333333', id, NOW() FROM permissions WHERE code IN (" + ",".join([f"'{c}'" for c in missing_codes]) + ") ON CONFLICT DO NOTHING;\n"
    sql += "INSERT INTO role_permissions (role_id, permission_id, assigned_at) SELECT '11111111-1111-1111-1111-111111111111', id, NOW() FROM permissions WHERE code IN (" + ",".join([f"'{c}'" for c in missing_codes]) + ") ON CONFLICT DO NOTHING;\n"

    print("Executing SQL:\n", sql)
    with open("sync.sql", "w") as f:
        f.write(sql)
    subprocess.run(["docker", "cp", "sync.sql", "qams-postgres:/sync.sql"])
    subprocess.run(["docker", "exec", "qams-postgres", "psql", "-U", "postgres", "-d", "qams_db", "-f", "/sync.sql"])
    print("Permissions synced successfully.")
