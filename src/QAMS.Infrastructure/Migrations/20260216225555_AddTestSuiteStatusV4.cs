using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QAMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTestSuiteStatusV4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // First, fix the naming of the TestSuites table which is currently in PascalCase
            // and its existing columns to match the current snake_case configuration.

            // TestSuites -> test_suites
            migrationBuilder.RenameTable(name: "TestSuites", newName: "test_suites");
            migrationBuilder.RenameColumn(name: "Id", table: "test_suites", newName: "id");
            migrationBuilder.RenameColumn(name: "ProjectId", table: "test_suites", newName: "project_id");
            migrationBuilder.RenameColumn(name: "Name", table: "test_suites", newName: "name");
            migrationBuilder.RenameColumn(name: "Description", table: "test_suites", newName: "description");
            migrationBuilder.RenameColumn(name: "CreatedAt", table: "test_suites", newName: "created_at");

            // Avoid renaming columns that might be missing in the DB like UpdatedAt or IsActive
            // based on current DB audit.

            // Now proceed with adding the new Status column to the now renamed test_suites table
            migrationBuilder.AddColumn<int>(
                name: "status_id",
                table: "test_suites",
                type: "integer",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateTable(
                name: "test_suite_statuses",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_test_suite_statuses", x => x.id);
                });

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 22, 55, 54, 430, DateTimeKind.Utc).AddTicks(7371));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 22, 55, 54, 430, DateTimeKind.Utc).AddTicks(7377));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 22, 55, 54, 430, DateTimeKind.Utc).AddTicks(7378));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 22, 55, 54, 430, DateTimeKind.Utc).AddTicks(7380));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 22, 55, 54, 431, DateTimeKind.Utc).AddTicks(992));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 22, 55, 54, 431, DateTimeKind.Utc).AddTicks(994));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 22, 55, 54, 431, DateTimeKind.Utc).AddTicks(996));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 22, 55, 54, 431, DateTimeKind.Utc).AddTicks(997));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 5,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 22, 55, 54, 431, DateTimeKind.Utc).AddTicks(999));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 6,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 22, 55, 54, 431, DateTimeKind.Utc).AddTicks(1000));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 16, 22, 55, 54, 429, DateTimeKind.Utc).AddTicks(5419));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 16, 22, 55, 54, 429, DateTimeKind.Utc).AddTicks(5422));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 16, 22, 55, 54, 429, DateTimeKind.Utc).AddTicks(5425));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 16, 22, 55, 54, 429, DateTimeKind.Utc).AddTicks(5427));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 22, 55, 54, 436, DateTimeKind.Utc).AddTicks(7205));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 22, 55, 54, 436, DateTimeKind.Utc).AddTicks(7210));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 22, 55, 54, 436, DateTimeKind.Utc).AddTicks(7212));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 22, 55, 54, 436, DateTimeKind.Utc).AddTicks(7213));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 22, 55, 54, 437, DateTimeKind.Utc).AddTicks(1542));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 22, 55, 54, 437, DateTimeKind.Utc).AddTicks(1545));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 22, 55, 54, 437, DateTimeKind.Utc).AddTicks(1547));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 22, 55, 54, 437, DateTimeKind.Utc).AddTicks(1548));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 22, 55, 54, 439, DateTimeKind.Utc).AddTicks(7957));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 22, 55, 54, 439, DateTimeKind.Utc).AddTicks(7967));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 22, 55, 54, 439, DateTimeKind.Utc).AddTicks(7971));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 22, 55, 54, 439, DateTimeKind.Utc).AddTicks(7975));

            migrationBuilder.InsertData(
                table: "test_suite_statuses",
                columns: new[] { "id", "Code", "CreatedAt", "description", "IsActive", "name", "SortOrder" },
                values: new object[,]
                {
                    { 1, "PENDIENTE", new DateTime(2026, 2, 16, 22, 55, 54, 430, DateTimeKind.Utc).AddTicks(1264), "Suite pendiente de ejecución", true, "PENDIENTE", 0 },
                    { 2, "EN_PROCESO", new DateTime(2026, 2, 16, 22, 55, 54, 430, DateTimeKind.Utc).AddTicks(1267), "Suite en ejecución activa", true, "EN PROCESO", 0 },
                    { 3, "COMPLETADO", new DateTime(2026, 2, 16, 22, 55, 54, 430, DateTimeKind.Utc).AddTicks(1269), "Todos los casos de la suite ejecutados", true, "COMPLETADO", 0 },
                    { 4, "DETENIDO", new DateTime(2026, 2, 16, 22, 55, 54, 430, DateTimeKind.Utc).AddTicks(1270), "Ejecución de la suite pausada", true, "DETENIDO", 0 }
                });

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 16, 22, 55, 54, 430, DateTimeKind.Utc).AddTicks(4153));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 16, 22, 55, 54, 430, DateTimeKind.Utc).AddTicks(4155));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 16, 22, 55, 54, 430, DateTimeKind.Utc).AddTicks(4158));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 16, 22, 55, 54, 430, DateTimeKind.Utc).AddTicks(4159));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 16, 22, 55, 54, 430, DateTimeKind.Utc).AddTicks(4161));

            migrationBuilder.CreateIndex(
                name: "IX_test_suites_status_id",
                table: "test_suites",
                column: "status_id");

            migrationBuilder.AddForeignKey(
                name: "FK_test_suites_test_suite_statuses_status_id",
                table: "test_suites",
                column: "status_id",
                principalTable: "test_suite_statuses",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_test_suites_test_suite_statuses_status_id",
                table: "test_suites");

            migrationBuilder.DropTable(
                name: "test_suite_statuses");

            migrationBuilder.DropIndex(
                name: "IX_test_suites_status_id",
                table: "test_suites");

            migrationBuilder.DropColumn(
                name: "status_id",
                table: "test_suites");

            // Revert test_suites naming
            migrationBuilder.RenameTable(name: "test_suites", newName: "TestSuites");
            migrationBuilder.RenameColumn(name: "id", table: "TestSuites", newName: "Id");
            migrationBuilder.RenameColumn(name: "project_id", table: "TestSuites", newName: "ProjectId");
            migrationBuilder.RenameColumn(name: "name", table: "TestSuites", newName: "Name");
            migrationBuilder.RenameColumn(name: "description", table: "TestSuites", newName: "Description");
            migrationBuilder.RenameColumn(name: "created_at", table: "TestSuites", newName: "CreatedAt");

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 22, 53, 15, 61, DateTimeKind.Utc).AddTicks(2154));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 22, 53, 15, 61, DateTimeKind.Utc).AddTicks(2160));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 22, 53, 15, 61, DateTimeKind.Utc).AddTicks(2164));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 22, 53, 15, 61, DateTimeKind.Utc).AddTicks(2167));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 22, 53, 15, 61, DateTimeKind.Utc).AddTicks(5400));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 22, 53, 15, 61, DateTimeKind.Utc).AddTicks(5404));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 22, 53, 15, 61, DateTimeKind.Utc).AddTicks(5406));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 22, 53, 15, 61, DateTimeKind.Utc).AddTicks(5407));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 5,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 22, 53, 15, 61, DateTimeKind.Utc).AddTicks(5409));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 6,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 22, 53, 15, 61, DateTimeKind.Utc).AddTicks(5411));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 16, 22, 53, 15, 59, DateTimeKind.Utc).AddTicks(8966));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 16, 22, 53, 15, 59, DateTimeKind.Utc).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 16, 22, 53, 15, 59, DateTimeKind.Utc).AddTicks(8974));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 16, 22, 53, 15, 59, DateTimeKind.Utc).AddTicks(8977));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 22, 53, 15, 65, DateTimeKind.Utc).AddTicks(4305));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 22, 53, 15, 65, DateTimeKind.Utc).AddTicks(4307));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 22, 53, 15, 65, DateTimeKind.Utc).AddTicks(4309));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 22, 53, 15, 65, DateTimeKind.Utc).AddTicks(4310));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 22, 53, 15, 65, DateTimeKind.Utc).AddTicks(6948));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 22, 53, 15, 65, DateTimeKind.Utc).AddTicks(6950));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 22, 53, 15, 65, DateTimeKind.Utc).AddTicks(6952));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 22, 53, 15, 65, DateTimeKind.Utc).AddTicks(6953));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 22, 53, 15, 67, DateTimeKind.Utc).AddTicks(4108));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 22, 53, 15, 67, DateTimeKind.Utc).AddTicks(4110));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 22, 53, 15, 67, DateTimeKind.Utc).AddTicks(4111));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 22, 53, 15, 67, DateTimeKind.Utc).AddTicks(4112));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 16, 22, 53, 15, 60, DateTimeKind.Utc).AddTicks(5470));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 16, 22, 53, 15, 60, DateTimeKind.Utc).AddTicks(5475));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 16, 22, 53, 15, 60, DateTimeKind.Utc).AddTicks(5478));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 16, 22, 53, 15, 60, DateTimeKind.Utc).AddTicks(5481));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 16, 22, 53, 15, 60, DateTimeKind.Utc).AddTicks(5484));
        }
    }
}
