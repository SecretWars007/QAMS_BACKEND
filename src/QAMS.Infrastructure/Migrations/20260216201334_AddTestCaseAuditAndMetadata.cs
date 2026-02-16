using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QAMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTestCaseAuditAndMetadata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KanbanTasks_TestCases_TestCaseId",
                table: "KanbanTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_test_executions_TestCases_test_case_id",
                table: "test_executions");

            migrationBuilder.DropForeignKey(
                name: "FK_TestCases_TestSuites_TestSuiteId",
                table: "TestCases");

            migrationBuilder.DropForeignKey(
                name: "FK_TestCases_test_case_priorities_PriorityId",
                table: "TestCases");

            migrationBuilder.DropForeignKey(
                name: "FK_TestSteps_TestCases_TestCaseId",
                table: "TestSteps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestCases",
                table: "TestCases");

            migrationBuilder.RenameTable(
                name: "TestCases",
                newName: "test_cases");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "test_cases",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Preconditions",
                table: "test_cases",
                newName: "preconditions");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "test_cases",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "test_cases",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "test_cases",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "TestSuiteId",
                table: "test_cases",
                newName: "test_suite_id");

            migrationBuilder.RenameColumn(
                name: "PriorityId",
                table: "test_cases",
                newName: "priority_id");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "test_cases",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "ExpectedResult",
                table: "test_cases",
                newName: "expected_result");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "test_cases",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_TestCases_TestSuiteId",
                table: "test_cases",
                newName: "IX_test_cases_test_suite_id");

            migrationBuilder.RenameIndex(
                name: "IX_TestCases_PriorityId",
                table: "test_cases",
                newName: "IX_test_cases_priority_id");

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "test_cases",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "preconditions",
                table: "test_cases",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "test_cases",
                type: "character varying(2000)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "is_active",
                table: "test_cases",
                type: "boolean",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "expected_result",
                table: "test_cases",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "test_cases",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<Guid>(
                name: "created_by_user_id",
                table: "test_cases",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "end_date",
                table: "test_cases",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "estimated_time_hours",
                table: "test_cases",
                type: "numeric(6,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "project_id",
                table: "test_cases",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "start_date",
                table: "test_cases",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "test_type_id",
                table: "test_cases",
                type: "integer",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddPrimaryKey(
                name: "PK_test_cases",
                table: "test_cases",
                column: "id");

            migrationBuilder.CreateTable(
                name: "test_types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Code = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_test_types", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 20, 13, 33, 586, DateTimeKind.Utc).AddTicks(9463));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 20, 13, 33, 586, DateTimeKind.Utc).AddTicks(9467));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 20, 13, 33, 586, DateTimeKind.Utc).AddTicks(9468));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 20, 13, 33, 586, DateTimeKind.Utc).AddTicks(9470));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 20, 13, 33, 589, DateTimeKind.Utc).AddTicks(4039));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 20, 13, 33, 589, DateTimeKind.Utc).AddTicks(4047));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 20, 13, 33, 589, DateTimeKind.Utc).AddTicks(4049));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 20, 13, 33, 589, DateTimeKind.Utc).AddTicks(4050));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 5,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 20, 13, 33, 589, DateTimeKind.Utc).AddTicks(4051));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 6,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 20, 13, 33, 589, DateTimeKind.Utc).AddTicks(4053));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 16, 20, 13, 33, 584, DateTimeKind.Utc).AddTicks(9721));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 16, 20, 13, 33, 584, DateTimeKind.Utc).AddTicks(9724));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 16, 20, 13, 33, 584, DateTimeKind.Utc).AddTicks(9727));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 16, 20, 13, 33, 584, DateTimeKind.Utc).AddTicks(9729));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 20, 13, 33, 600, DateTimeKind.Utc).AddTicks(1487));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 20, 13, 33, 600, DateTimeKind.Utc).AddTicks(1491));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 20, 13, 33, 600, DateTimeKind.Utc).AddTicks(1492));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 20, 13, 33, 600, DateTimeKind.Utc).AddTicks(1494));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 20, 13, 33, 600, DateTimeKind.Utc).AddTicks(5527));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 20, 13, 33, 600, DateTimeKind.Utc).AddTicks(5530));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 20, 13, 33, 600, DateTimeKind.Utc).AddTicks(5531));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 20, 13, 33, 600, DateTimeKind.Utc).AddTicks(5533));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 20, 13, 33, 604, DateTimeKind.Utc).AddTicks(1864));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 20, 13, 33, 604, DateTimeKind.Utc).AddTicks(1870));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 20, 13, 33, 604, DateTimeKind.Utc).AddTicks(1871));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 20, 13, 33, 604, DateTimeKind.Utc).AddTicks(1872));

            migrationBuilder.InsertData(
                table: "test_types",
                columns: new[] { "Id", "Code", "CreatedAt", "Description", "IsActive", "Name", "SortOrder" },
                values: new object[,]
                {
                    { 1, "FUNCTIONAL_MANUAL", new DateTime(2026, 2, 16, 20, 13, 33, 585, DateTimeKind.Utc).AddTicks(8593), "Prueba funcional ejecutada manualmente", true, "Funcional Manual", 1 },
                    { 2, "FUNCTIONAL_AUTOMATED", new DateTime(2026, 2, 16, 20, 13, 33, 585, DateTimeKind.Utc).AddTicks(8596), "Prueba funcional automatizada", true, "Funcional Automatizada", 2 },
                    { 3, "NON_FUNCTIONAL", new DateTime(2026, 2, 16, 20, 13, 33, 585, DateTimeKind.Utc).AddTicks(8598), "Prueba de rendimiento, seguridad, usabilidad, etc.", true, "No Funcional", 3 },
                    { 4, "REGRESSION", new DateTime(2026, 2, 16, 20, 13, 33, 585, DateTimeKind.Utc).AddTicks(8600), "Prueba para verificar que cambios no rompieron funcionalidad existente", true, "Regresión", 4 },
                    { 5, "SMOKE", new DateTime(2026, 2, 16, 20, 13, 33, 585, DateTimeKind.Utc).AddTicks(8602), "Prueba rápida de funcionalidad crítica", true, "Smoke Test", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_test_cases_created_by_user_id",
                table: "test_cases",
                column: "created_by_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_test_cases_project_id",
                table: "test_cases",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "IX_test_cases_test_type_id",
                table: "test_cases",
                column: "test_type_id");

            migrationBuilder.AddForeignKey(
                name: "FK_KanbanTasks_test_cases_TestCaseId",
                table: "KanbanTasks",
                column: "TestCaseId",
                principalTable: "test_cases",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_test_cases_TestSuites_test_suite_id",
                table: "test_cases",
                column: "test_suite_id",
                principalTable: "TestSuites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_test_cases_projects_project_id",
                table: "test_cases",
                column: "project_id",
                principalTable: "projects",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_test_cases_test_case_priorities_priority_id",
                table: "test_cases",
                column: "priority_id",
                principalTable: "test_case_priorities",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_test_cases_test_types_test_type_id",
                table: "test_cases",
                column: "test_type_id",
                principalTable: "test_types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_test_cases_users_created_by_user_id",
                table: "test_cases",
                column: "created_by_user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_test_executions_test_cases_test_case_id",
                table: "test_executions",
                column: "test_case_id",
                principalTable: "test_cases",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestSteps_test_cases_TestCaseId",
                table: "TestSteps",
                column: "TestCaseId",
                principalTable: "test_cases",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KanbanTasks_test_cases_TestCaseId",
                table: "KanbanTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_test_cases_TestSuites_test_suite_id",
                table: "test_cases");

            migrationBuilder.DropForeignKey(
                name: "FK_test_cases_projects_project_id",
                table: "test_cases");

            migrationBuilder.DropForeignKey(
                name: "FK_test_cases_test_case_priorities_priority_id",
                table: "test_cases");

            migrationBuilder.DropForeignKey(
                name: "FK_test_cases_test_types_test_type_id",
                table: "test_cases");

            migrationBuilder.DropForeignKey(
                name: "FK_test_cases_users_created_by_user_id",
                table: "test_cases");

            migrationBuilder.DropForeignKey(
                name: "FK_test_executions_test_cases_test_case_id",
                table: "test_executions");

            migrationBuilder.DropForeignKey(
                name: "FK_TestSteps_test_cases_TestCaseId",
                table: "TestSteps");

            migrationBuilder.DropTable(
                name: "test_types");

            migrationBuilder.DropPrimaryKey(
                name: "PK_test_cases",
                table: "test_cases");

            migrationBuilder.DropIndex(
                name: "IX_test_cases_created_by_user_id",
                table: "test_cases");

            migrationBuilder.DropIndex(
                name: "IX_test_cases_project_id",
                table: "test_cases");

            migrationBuilder.DropIndex(
                name: "IX_test_cases_test_type_id",
                table: "test_cases");

            migrationBuilder.DropColumn(
                name: "created_by_user_id",
                table: "test_cases");

            migrationBuilder.DropColumn(
                name: "end_date",
                table: "test_cases");

            migrationBuilder.DropColumn(
                name: "estimated_time_hours",
                table: "test_cases");

            migrationBuilder.DropColumn(
                name: "project_id",
                table: "test_cases");

            migrationBuilder.DropColumn(
                name: "start_date",
                table: "test_cases");

            migrationBuilder.DropColumn(
                name: "test_type_id",
                table: "test_cases");

            migrationBuilder.RenameTable(
                name: "test_cases",
                newName: "TestCases");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "TestCases",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "preconditions",
                table: "TestCases",
                newName: "Preconditions");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "TestCases",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "TestCases",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "TestCases",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "test_suite_id",
                table: "TestCases",
                newName: "TestSuiteId");

            migrationBuilder.RenameColumn(
                name: "priority_id",
                table: "TestCases",
                newName: "PriorityId");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "TestCases",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "expected_result",
                table: "TestCases",
                newName: "ExpectedResult");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "TestCases",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_test_cases_test_suite_id",
                table: "TestCases",
                newName: "IX_TestCases_TestSuiteId");

            migrationBuilder.RenameIndex(
                name: "IX_test_cases_priority_id",
                table: "TestCases",
                newName: "IX_TestCases_PriorityId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "TestCases",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Preconditions",
                table: "TestCases",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TestCases",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(2000)",
                oldMaxLength: 2000,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "TestCases",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<string>(
                name: "ExpectedResult",
                table: "TestCases",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "TestCases",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestCases",
                table: "TestCases",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 19, 49, 43, 243, DateTimeKind.Utc).AddTicks(147));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 19, 49, 43, 243, DateTimeKind.Utc).AddTicks(149));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 19, 49, 43, 243, DateTimeKind.Utc).AddTicks(150));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 19, 49, 43, 243, DateTimeKind.Utc).AddTicks(151));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 19, 49, 43, 243, DateTimeKind.Utc).AddTicks(2333));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 19, 49, 43, 243, DateTimeKind.Utc).AddTicks(2335));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 19, 49, 43, 243, DateTimeKind.Utc).AddTicks(2336));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 19, 49, 43, 243, DateTimeKind.Utc).AddTicks(2337));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 5,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 19, 49, 43, 243, DateTimeKind.Utc).AddTicks(2339));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 6,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 19, 49, 43, 243, DateTimeKind.Utc).AddTicks(2340));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 16, 19, 49, 43, 242, DateTimeKind.Utc).AddTicks(7338));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 16, 19, 49, 43, 242, DateTimeKind.Utc).AddTicks(7340));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 16, 19, 49, 43, 242, DateTimeKind.Utc).AddTicks(7342));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 16, 19, 49, 43, 242, DateTimeKind.Utc).AddTicks(7343));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 19, 49, 43, 245, DateTimeKind.Utc).AddTicks(3375));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 19, 49, 43, 245, DateTimeKind.Utc).AddTicks(3377));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 19, 49, 43, 245, DateTimeKind.Utc).AddTicks(3378));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 19, 49, 43, 245, DateTimeKind.Utc).AddTicks(3379));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 19, 49, 43, 254, DateTimeKind.Utc).AddTicks(4758));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 19, 49, 43, 254, DateTimeKind.Utc).AddTicks(4771));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 19, 49, 43, 254, DateTimeKind.Utc).AddTicks(4772));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 19, 49, 43, 254, DateTimeKind.Utc).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 19, 49, 43, 255, DateTimeKind.Utc).AddTicks(296));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 19, 49, 43, 255, DateTimeKind.Utc).AddTicks(298));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 19, 49, 43, 255, DateTimeKind.Utc).AddTicks(299));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 19, 49, 43, 255, DateTimeKind.Utc).AddTicks(300));

            migrationBuilder.AddForeignKey(
                name: "FK_KanbanTasks_TestCases_TestCaseId",
                table: "KanbanTasks",
                column: "TestCaseId",
                principalTable: "TestCases",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_test_executions_TestCases_test_case_id",
                table: "test_executions",
                column: "test_case_id",
                principalTable: "TestCases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestCases_TestSuites_TestSuiteId",
                table: "TestCases",
                column: "TestSuiteId",
                principalTable: "TestSuites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestCases_test_case_priorities_PriorityId",
                table: "TestCases",
                column: "PriorityId",
                principalTable: "test_case_priorities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestSteps_TestCases_TestCaseId",
                table: "TestSteps",
                column: "TestCaseId",
                principalTable: "TestCases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
