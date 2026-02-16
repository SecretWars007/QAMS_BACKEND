using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QAMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSystemSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evidences_EvidenceTypes_FileTypeId",
                table: "Evidences");

            migrationBuilder.DropForeignKey(
                name: "FK_ExecutionStepResults_StepResultStatuses_StatusId",
                table: "ExecutionStepResults");

            migrationBuilder.DropForeignKey(
                name: "FK_KanbanTasks_TaskPriorities_PriorityId",
                table: "KanbanTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_KanbanTasks_Users_AssigneeId",
                table: "KanbanTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_role_permissions_Roles_RoleId",
                table: "role_permissions");

            migrationBuilder.DropForeignKey(
                name: "FK_test_executions_Users_tester_id",
                table: "test_executions");

            migrationBuilder.DropForeignKey(
                name: "FK_TestCases_TestCasePriorities_PriorityId",
                table: "TestCases");

            migrationBuilder.DropForeignKey(
                name: "FK_user_roles_Roles_RoleId",
                table: "user_roles");

            migrationBuilder.DropForeignKey(
                name: "FK_user_roles_Users_UserId",
                table: "user_roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestCasePriorities",
                table: "TestCasePriorities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskPriorities",
                table: "TaskPriorities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StepResultStatuses",
                table: "StepResultStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EvidenceTypes",
                table: "EvidenceTypes");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "roles");

            migrationBuilder.RenameTable(
                name: "TestCasePriorities",
                newName: "test_case_priorities");

            migrationBuilder.RenameTable(
                name: "TaskPriorities",
                newName: "task_priorities");

            migrationBuilder.RenameTable(
                name: "StepResultStatuses",
                newName: "step_result_statuses");

            migrationBuilder.RenameTable(
                name: "EvidenceTypes",
                newName: "evidence_types");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "users",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "users",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "RefreshTokenExpiryTime",
                table: "users",
                newName: "refresh_token_expiry_time");

            migrationBuilder.RenameColumn(
                name: "RefreshToken",
                table: "users",
                newName: "refresh_token");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "users",
                newName: "password_hash");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "users",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "users",
                newName: "full_name");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "users",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "roles",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "roles",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "roles",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "roles",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "roles",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "test_case_priorities",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "test_case_priorities",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "test_case_priorities",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "test_case_priorities",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "SortOrder",
                table: "test_case_priorities",
                newName: "sort_order");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "test_case_priorities",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "test_case_priorities",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "task_priorities",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "task_priorities",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "task_priorities",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "task_priorities",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "SortOrder",
                table: "task_priorities",
                newName: "sort_order");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "task_priorities",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "task_priorities",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "step_result_statuses",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "step_result_statuses",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "step_result_statuses",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "step_result_statuses",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "SortOrder",
                table: "step_result_statuses",
                newName: "sort_order");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "step_result_statuses",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "step_result_statuses",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "evidence_types",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "evidence_types",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "evidence_types",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "evidence_types",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "SortOrder",
                table: "evidence_types",
                newName: "sort_order");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "evidence_types",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "evidence_types",
                newName: "created_at");

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "users",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "users",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<bool>(
                name: "is_active",
                table: "users",
                type: "boolean",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "full_name",
                table: "users",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "roles",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "roles",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "is_active",
                table: "roles",
                type: "boolean",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "roles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "test_case_priorities",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "test_case_priorities",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "code",
                table: "test_case_priorities",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "sort_order",
                table: "test_case_priorities",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<bool>(
                name: "is_active",
                table: "test_case_priorities",
                type: "boolean",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "test_case_priorities",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "task_priorities",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "task_priorities",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "code",
                table: "task_priorities",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "sort_order",
                table: "task_priorities",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<bool>(
                name: "is_active",
                table: "task_priorities",
                type: "boolean",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "task_priorities",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "step_result_statuses",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "step_result_statuses",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "code",
                table: "step_result_statuses",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "sort_order",
                table: "step_result_statuses",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<bool>(
                name: "is_active",
                table: "step_result_statuses",
                type: "boolean",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "step_result_statuses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "evidence_types",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "evidence_types",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "code",
                table: "evidence_types",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "sort_order",
                table: "evidence_types",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<bool>(
                name: "is_active",
                table: "evidence_types",
                type: "boolean",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "evidence_types",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_roles",
                table: "roles",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_test_case_priorities",
                table: "test_case_priorities",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_task_priorities",
                table: "task_priorities",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_step_result_statuses",
                table: "step_result_statuses",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_evidence_types",
                table: "evidence_types",
                column: "id");

            migrationBuilder.InsertData(
                table: "evidence_types",
                columns: new[] { "id", "code", "created_at", "description", "is_active", "name", "sort_order" },
                values: new object[,]
                {
                    { 1, "IMAGE", new DateTime(2026, 2, 15, 19, 20, 5, 647, DateTimeKind.Utc).AddTicks(5486), null, true, "Imagen", 1 },
                    { 2, "VIDEO", new DateTime(2026, 2, 15, 19, 20, 5, 647, DateTimeKind.Utc).AddTicks(5489), null, true, "Video", 2 },
                    { 3, "DOCUMENT", new DateTime(2026, 2, 15, 19, 20, 5, 647, DateTimeKind.Utc).AddTicks(5491), null, true, "Documento", 3 },
                    { 4, "LOG_FILE", new DateTime(2026, 2, 15, 19, 20, 5, 647, DateTimeKind.Utc).AddTicks(5492), null, true, "Archivo de Log", 4 }
                });

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 15, 19, 20, 5, 648, DateTimeKind.Utc).AddTicks(292));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 15, 19, 20, 5, 648, DateTimeKind.Utc).AddTicks(296));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 15, 19, 20, 5, 648, DateTimeKind.Utc).AddTicks(298));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 15, 19, 20, 5, 648, DateTimeKind.Utc).AddTicks(299));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 5,
                column: "created_at",
                value: new DateTime(2026, 2, 15, 19, 20, 5, 648, DateTimeKind.Utc).AddTicks(301));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 6,
                column: "created_at",
                value: new DateTime(2026, 2, 15, 19, 20, 5, 648, DateTimeKind.Utc).AddTicks(302));

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "created_at", "description", "is_active", "name" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Acceso total al sistema", true, "Administrator" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ejecución y gestión de pruebas", true, "Tester" }
                });

            migrationBuilder.InsertData(
                table: "step_result_statuses",
                columns: new[] { "id", "code", "created_at", "description", "is_active", "name", "sort_order" },
                values: new object[,]
                {
                    { 1, "NOT_EXECUTED", new DateTime(2026, 2, 15, 19, 20, 5, 649, DateTimeKind.Utc).AddTicks(8170), null, true, "No Ejecutado", 1 },
                    { 2, "PASSED", new DateTime(2026, 2, 15, 19, 20, 5, 649, DateTimeKind.Utc).AddTicks(8174), null, true, "Aprobado", 2 },
                    { 3, "FAILED", new DateTime(2026, 2, 15, 19, 20, 5, 649, DateTimeKind.Utc).AddTicks(8176), null, true, "Fallido", 3 },
                    { 4, "BLOCKED", new DateTime(2026, 2, 15, 19, 20, 5, 649, DateTimeKind.Utc).AddTicks(8177), null, true, "Bloqueado", 4 }
                });

            migrationBuilder.InsertData(
                table: "task_priorities",
                columns: new[] { "id", "code", "created_at", "description", "is_active", "name", "sort_order" },
                values: new object[,]
                {
                    { 1, "LOW", new DateTime(2026, 2, 15, 19, 20, 5, 650, DateTimeKind.Utc).AddTicks(1469), null, true, "Baja", 1 },
                    { 2, "MEDIUM", new DateTime(2026, 2, 15, 19, 20, 5, 650, DateTimeKind.Utc).AddTicks(1471), null, true, "Media", 2 },
                    { 3, "HIGH", new DateTime(2026, 2, 15, 19, 20, 5, 650, DateTimeKind.Utc).AddTicks(1473), null, true, "Alta", 3 },
                    { 4, "CRITICAL", new DateTime(2026, 2, 15, 19, 20, 5, 650, DateTimeKind.Utc).AddTicks(1474), null, true, "Crítica", 4 }
                });

            migrationBuilder.InsertData(
                table: "test_case_priorities",
                columns: new[] { "id", "code", "created_at", "description", "is_active", "name", "sort_order" },
                values: new object[,]
                {
                    { 1, "LOW", new DateTime(2026, 2, 15, 19, 20, 5, 650, DateTimeKind.Utc).AddTicks(5371), null, true, "Baja", 1 },
                    { 2, "MEDIUM", new DateTime(2026, 2, 15, 19, 20, 5, 650, DateTimeKind.Utc).AddTicks(5375), null, true, "Media", 2 },
                    { 3, "HIGH", new DateTime(2026, 2, 15, 19, 20, 5, 650, DateTimeKind.Utc).AddTicks(5377), null, true, "Alta", 3 },
                    { 4, "CRITICAL", new DateTime(2026, 2, 15, 19, 20, 5, 650, DateTimeKind.Utc).AddTicks(5379), null, true, "Crítica", 4 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "created_at", "email", "full_name", "is_active", "password_hash", "refresh_token", "refresh_token_expiry_time", "updated_at", "username" },
                values: new object[] { new Guid("99999999-9999-9999-9999-999999999999"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "admin@qams.local", "Administrador Base", true, "$2a$12$R9h/LIPzKuOfSRR6M9V39u.BBzBRS7O.O80X9/b9L.p51v5FzE5x.", null, null, null, "admin" });

            migrationBuilder.InsertData(
                table: "role_permissions",
                columns: new[] { "PermissionId", "RoleId", "AssignedAt" },
                values: new object[,]
                {
                    { new Guid("41544143-4f4c-5347-5f4d-414e41474500"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("41544143-4f4c-5347-5f56-494557000000"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("424e414b-4e41-435f-5245-415445000000"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("424e414b-4e41-445f-454c-455445000000"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("43455845-5455-4f49-4e53-5f4352454154"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("43455845-5455-4f49-4e53-5f5550444154"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("43455845-5455-4f49-4e53-5f55504c4f41"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("454c4f52-5f53-4544-4c45-544500000000"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("454c4f52-5f53-4956-4557-000000000000"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("454c4f52-5f53-5055-4441-544500000000"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("454c4f52-5f53-5243-4541-544500000000"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("454c4f52-5f53-5341-5349-474e5f504552"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("4a4f5250-4345-5354-5f43-524541544500"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("4a4f5250-4345-5354-5f44-454c45544500"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("4a4f5250-4345-5354-5f55-504441544500"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("52455355-5f53-4544-4c45-544500000000"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("52455355-5f53-4956-4557-000000000000"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("52455355-5f53-5055-4441-544500000000"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("52455355-5f53-5243-4541-544500000000"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("54534554-435f-5341-4553-5f4352454154"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("54534554-435f-5341-4553-5f44454c4554"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("54534554-435f-5341-4553-5f5550444154"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "user_roles",
                columns: new[] { "RoleId", "UserId", "AssignedAt" },
                values: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("99999999-9999-9999-9999-999999999999"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.CreateIndex(
                name: "IX_users_email",
                table: "users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_username",
                table: "users",
                column: "username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_roles_name",
                table: "roles",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_test_case_priorities_code",
                table: "test_case_priorities",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_task_priorities_code",
                table: "task_priorities",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_step_result_statuses_code",
                table: "step_result_statuses",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_evidence_types_code",
                table: "evidence_types",
                column: "code",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Evidences_evidence_types_FileTypeId",
                table: "Evidences",
                column: "FileTypeId",
                principalTable: "evidence_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExecutionStepResults_step_result_statuses_StatusId",
                table: "ExecutionStepResults",
                column: "StatusId",
                principalTable: "step_result_statuses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KanbanTasks_task_priorities_PriorityId",
                table: "KanbanTasks",
                column: "PriorityId",
                principalTable: "task_priorities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KanbanTasks_users_AssigneeId",
                table: "KanbanTasks",
                column: "AssigneeId",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_role_permissions_roles_RoleId",
                table: "role_permissions",
                column: "RoleId",
                principalTable: "roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_test_executions_users_tester_id",
                table: "test_executions",
                column: "tester_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestCases_test_case_priorities_PriorityId",
                table: "TestCases",
                column: "PriorityId",
                principalTable: "test_case_priorities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_roles_roles_RoleId",
                table: "user_roles",
                column: "RoleId",
                principalTable: "roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_roles_users_UserId",
                table: "user_roles",
                column: "UserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evidences_evidence_types_FileTypeId",
                table: "Evidences");

            migrationBuilder.DropForeignKey(
                name: "FK_ExecutionStepResults_step_result_statuses_StatusId",
                table: "ExecutionStepResults");

            migrationBuilder.DropForeignKey(
                name: "FK_KanbanTasks_task_priorities_PriorityId",
                table: "KanbanTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_KanbanTasks_users_AssigneeId",
                table: "KanbanTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_role_permissions_roles_RoleId",
                table: "role_permissions");

            migrationBuilder.DropForeignKey(
                name: "FK_test_executions_users_tester_id",
                table: "test_executions");

            migrationBuilder.DropForeignKey(
                name: "FK_TestCases_test_case_priorities_PriorityId",
                table: "TestCases");

            migrationBuilder.DropForeignKey(
                name: "FK_user_roles_roles_RoleId",
                table: "user_roles");

            migrationBuilder.DropForeignKey(
                name: "FK_user_roles_users_UserId",
                table: "user_roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_email",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_username",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_roles",
                table: "roles");

            migrationBuilder.DropIndex(
                name: "IX_roles_name",
                table: "roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_test_case_priorities",
                table: "test_case_priorities");

            migrationBuilder.DropIndex(
                name: "IX_test_case_priorities_code",
                table: "test_case_priorities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_task_priorities",
                table: "task_priorities");

            migrationBuilder.DropIndex(
                name: "IX_task_priorities_code",
                table: "task_priorities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_step_result_statuses",
                table: "step_result_statuses");

            migrationBuilder.DropIndex(
                name: "IX_step_result_statuses_code",
                table: "step_result_statuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_evidence_types",
                table: "evidence_types");

            migrationBuilder.DropIndex(
                name: "IX_evidence_types_code",
                table: "evidence_types");

            migrationBuilder.DeleteData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("41544143-4f4c-5347-5f4d-414e41474500"), new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("41544143-4f4c-5347-5f56-494557000000"), new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("424e414b-4e41-435f-5245-415445000000"), new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("424e414b-4e41-445f-454c-455445000000"), new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f4352454154"), new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5550444154"), new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f55504c4f41"), new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("454c4f52-5f53-4544-4c45-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("454c4f52-5f53-4956-4557-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("454c4f52-5f53-5055-4441-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("454c4f52-5f53-5243-4541-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("454c4f52-5f53-5341-5349-474e5f504552"), new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f43-524541544500"), new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f44-454c45544500"), new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f55-504441544500"), new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("52455355-5f53-4544-4c45-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("52455355-5f53-4956-4557-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("52455355-5f53-5055-4441-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("52455355-5f53-5243-4541-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f4352454154"), new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f44454c4554"), new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5550444154"), new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "user_roles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("99999999-9999-9999-9999-999999999999") });

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"));

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "roles",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "test_case_priorities",
                newName: "TestCasePriorities");

            migrationBuilder.RenameTable(
                name: "task_priorities",
                newName: "TaskPriorities");

            migrationBuilder.RenameTable(
                name: "step_result_statuses",
                newName: "StepResultStatuses");

            migrationBuilder.RenameTable(
                name: "evidence_types",
                newName: "EvidenceTypes");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "Users",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "Users",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "refresh_token_expiry_time",
                table: "Users",
                newName: "RefreshTokenExpiryTime");

            migrationBuilder.RenameColumn(
                name: "refresh_token",
                table: "Users",
                newName: "RefreshToken");

            migrationBuilder.RenameColumn(
                name: "password_hash",
                table: "Users",
                newName: "PasswordHash");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "Users",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "full_name",
                table: "Users",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Users",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Roles",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Roles",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Roles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "Roles",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Roles",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "TestCasePriorities",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "TestCasePriorities",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "TestCasePriorities",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "TestCasePriorities",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "sort_order",
                table: "TestCasePriorities",
                newName: "SortOrder");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "TestCasePriorities",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "TestCasePriorities",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "TaskPriorities",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "TaskPriorities",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "TaskPriorities",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "TaskPriorities",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "sort_order",
                table: "TaskPriorities",
                newName: "SortOrder");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "TaskPriorities",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "TaskPriorities",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "StepResultStatuses",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "StepResultStatuses",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "StepResultStatuses",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "StepResultStatuses",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "sort_order",
                table: "StepResultStatuses",
                newName: "SortOrder");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "StepResultStatuses",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "StepResultStatuses",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "EvidenceTypes",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "EvidenceTypes",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "EvidenceTypes",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "EvidenceTypes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "sort_order",
                table: "EvidenceTypes",
                newName: "SortOrder");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "EvidenceTypes",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "EvidenceTypes",
                newName: "CreatedAt");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Roles",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Roles",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Roles",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Roles",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TestCasePriorities",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TestCasePriorities",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "TestCasePriorities",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "SortOrder",
                table: "TestCasePriorities",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "TestCasePriorities",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "TestCasePriorities",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TaskPriorities",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TaskPriorities",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "TaskPriorities",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "SortOrder",
                table: "TaskPriorities",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "TaskPriorities",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "TaskPriorities",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "StepResultStatuses",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "StepResultStatuses",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "StepResultStatuses",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "SortOrder",
                table: "StepResultStatuses",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "StepResultStatuses",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "StepResultStatuses",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "EvidenceTypes",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "EvidenceTypes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "EvidenceTypes",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "SortOrder",
                table: "EvidenceTypes",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "EvidenceTypes",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "EvidenceTypes",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestCasePriorities",
                table: "TestCasePriorities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskPriorities",
                table: "TaskPriorities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StepResultStatuses",
                table: "StepResultStatuses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EvidenceTypes",
                table: "EvidenceTypes",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 14, 4, 12, 37, 143, DateTimeKind.Utc).AddTicks(2369));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 14, 4, 12, 37, 143, DateTimeKind.Utc).AddTicks(2380));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 14, 4, 12, 37, 143, DateTimeKind.Utc).AddTicks(2385));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 14, 4, 12, 37, 143, DateTimeKind.Utc).AddTicks(2388));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 5,
                column: "created_at",
                value: new DateTime(2026, 2, 14, 4, 12, 37, 143, DateTimeKind.Utc).AddTicks(2391));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 6,
                column: "created_at",
                value: new DateTime(2026, 2, 14, 4, 12, 37, 143, DateTimeKind.Utc).AddTicks(2394));

            migrationBuilder.AddForeignKey(
                name: "FK_Evidences_EvidenceTypes_FileTypeId",
                table: "Evidences",
                column: "FileTypeId",
                principalTable: "EvidenceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExecutionStepResults_StepResultStatuses_StatusId",
                table: "ExecutionStepResults",
                column: "StatusId",
                principalTable: "StepResultStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KanbanTasks_TaskPriorities_PriorityId",
                table: "KanbanTasks",
                column: "PriorityId",
                principalTable: "TaskPriorities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KanbanTasks_Users_AssigneeId",
                table: "KanbanTasks",
                column: "AssigneeId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_role_permissions_Roles_RoleId",
                table: "role_permissions",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_test_executions_Users_tester_id",
                table: "test_executions",
                column: "tester_id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestCases_TestCasePriorities_PriorityId",
                table: "TestCases",
                column: "PriorityId",
                principalTable: "TestCasePriorities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_roles_Roles_RoleId",
                table: "user_roles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_roles_Users_UserId",
                table: "user_roles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
