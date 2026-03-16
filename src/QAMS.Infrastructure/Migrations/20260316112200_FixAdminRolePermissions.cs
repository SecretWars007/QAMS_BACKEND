using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QAMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixAdminRolePermissions : Migration
    {
        // GUID del permiso USERS_ASSIGN_ROLES (determinístico por código)
        private static readonly Guid UsersAssignRolesPermId = new Guid("52455355-5f53-5341-5349-474e5f524f4c");
        // GUID del rol Administrator
        private static readonly Guid AdminRoleId = new Guid("11111111-1111-1111-1111-111111111111");
        // GUID del usuario admin
        private static readonly Guid AdminUserId = new Guid("99999999-9999-9999-9999-999999999999");

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1. Garantizar que el permiso USERS_ASSIGN_ROLES existe
            migrationBuilder.Sql($@"
                INSERT INTO permissions (id, code, description, module, created_at)
                VALUES (
                    '{UsersAssignRolesPermId}',
                    'USERS_ASSIGN_ROLES',
                    'Asignar roles a usuarios',
                    'Users',
                    '2025-01-01T00:00:00Z'
                )
                ON CONFLICT (id) DO NOTHING;
            ");

            // 2. Garantizar que el rol Administrator existe
            migrationBuilder.Sql($@"
                INSERT INTO roles (id, name, description, is_active, created_at)
                VALUES (
                    '{AdminRoleId}',
                    'Administrator',
                    'Acceso total al sistema',
                    TRUE,
                    '2025-01-01T00:00:00Z'
                )
                ON CONFLICT (id) DO NOTHING;
            ");

            // 3. Garantizar que el admin user existe
            migrationBuilder.Sql($@"
                INSERT INTO users (id, username, email, full_name, password_hash, is_active, created_at)
                VALUES (
                    '{AdminUserId}',
                    'admin',
                    'admin@qams.local',
                    'Administrador Base',
                    '$2a$12$0jdJPZWmFkqBX5PmpGsjaeXoZqGvvD1fUOifS6Foj9guzZVPZzo.C',
                    TRUE,
                    '2025-01-01T00:00:00Z'
                )
                ON CONFLICT (id) DO NOTHING;
            ");

            // 4. Garantizar que el admin tiene el rol Administrator
            migrationBuilder.Sql($@"
                INSERT INTO user_roles (user_id, role_id, assigned_at)
                VALUES (
                    '{AdminUserId}',
                    '{AdminRoleId}',
                    '2025-01-01T00:00:00Z'
                )
                ON CONFLICT (user_id, role_id) DO NOTHING;
            ");

            // 5. Garantizar que Administrator tiene USERS_ASSIGN_ROLES
            migrationBuilder.Sql($@"
                INSERT INTO role_permissions (permission_id, role_id, assigned_at)
                VALUES (
                    '{UsersAssignRolesPermId}',
                    '{AdminRoleId}',
                    '2025-01-01T00:00:00Z'
                )
                ON CONFLICT (permission_id, role_id) DO NOTHING;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // No revertir: esto es una corrección de datos mínima
        }
    }
}
