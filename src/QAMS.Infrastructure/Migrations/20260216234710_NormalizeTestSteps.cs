using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QAMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NormalizeTestSteps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExecutionStepResults_TestSteps_TestStepId",
                table: "ExecutionStepResults");

            migrationBuilder.DropForeignKey(
                name: "FK_TestSteps_test_cases_TestCaseId",
                table: "TestSteps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestSteps",
                table: "TestSteps");

            migrationBuilder.DropIndex(
                name: "IX_TestSteps_TestCaseId",
                table: "TestSteps");

            migrationBuilder.RenameTable(
                name: "TestSteps",
                newName: "test_steps");

            migrationBuilder.RenameColumn(
                name: "Action",
                table: "test_steps",
                newName: "action");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "test_steps",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TestCaseId",
                table: "test_steps",
                newName: "test_case_id");

            migrationBuilder.RenameColumn(
                name: "StepOrder",
                table: "test_steps",
                newName: "step_order");

            migrationBuilder.RenameColumn(
                name: "ExpectedResult",
                table: "test_steps",
                newName: "expected_result");

            migrationBuilder.AddPrimaryKey(
                name: "PK_test_steps",
                table: "test_steps",
                column: "id");

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 23, 47, 9, 865, DateTimeKind.Utc).AddTicks(9274));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 23, 47, 9, 865, DateTimeKind.Utc).AddTicks(9276));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 23, 47, 9, 865, DateTimeKind.Utc).AddTicks(9277));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 23, 47, 9, 865, DateTimeKind.Utc).AddTicks(9278));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 23, 47, 9, 866, DateTimeKind.Utc).AddTicks(1444));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 23, 47, 9, 866, DateTimeKind.Utc).AddTicks(1446));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 23, 47, 9, 866, DateTimeKind.Utc).AddTicks(1448));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 23, 47, 9, 866, DateTimeKind.Utc).AddTicks(1449));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 5,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 23, 47, 9, 866, DateTimeKind.Utc).AddTicks(1450));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 6,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 23, 47, 9, 866, DateTimeKind.Utc).AddTicks(1452));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 16, 23, 47, 9, 865, DateTimeKind.Utc).AddTicks(2915));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 16, 23, 47, 9, 865, DateTimeKind.Utc).AddTicks(2917));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 16, 23, 47, 9, 865, DateTimeKind.Utc).AddTicks(2919));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 16, 23, 47, 9, 865, DateTimeKind.Utc).AddTicks(2921));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 23, 47, 9, 868, DateTimeKind.Utc).AddTicks(8132));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 23, 47, 9, 868, DateTimeKind.Utc).AddTicks(8134));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 23, 47, 9, 868, DateTimeKind.Utc).AddTicks(8136));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 23, 47, 9, 868, DateTimeKind.Utc).AddTicks(8138));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 23, 47, 9, 869, DateTimeKind.Utc).AddTicks(397));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 23, 47, 9, 869, DateTimeKind.Utc).AddTicks(399));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 23, 47, 9, 869, DateTimeKind.Utc).AddTicks(401));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 23, 47, 9, 869, DateTimeKind.Utc).AddTicks(402));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 23, 47, 9, 870, DateTimeKind.Utc).AddTicks(8563));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 23, 47, 9, 870, DateTimeKind.Utc).AddTicks(8567));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 23, 47, 9, 870, DateTimeKind.Utc).AddTicks(8570));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 23, 47, 9, 870, DateTimeKind.Utc).AddTicks(8572));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 16, 23, 47, 9, 865, DateTimeKind.Utc).AddTicks(5278));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 16, 23, 47, 9, 865, DateTimeKind.Utc).AddTicks(5280));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 16, 23, 47, 9, 865, DateTimeKind.Utc).AddTicks(5281));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 16, 23, 47, 9, 865, DateTimeKind.Utc).AddTicks(5282));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 16, 23, 47, 9, 865, DateTimeKind.Utc).AddTicks(6923));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 16, 23, 47, 9, 865, DateTimeKind.Utc).AddTicks(6925));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 16, 23, 47, 9, 865, DateTimeKind.Utc).AddTicks(6927));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 16, 23, 47, 9, 865, DateTimeKind.Utc).AddTicks(6929));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 16, 23, 47, 9, 865, DateTimeKind.Utc).AddTicks(6930));

            migrationBuilder.CreateIndex(
                name: "IX_test_steps_test_case_id_step_order",
                table: "test_steps",
                columns: new[] { "test_case_id", "step_order" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ExecutionStepResults_test_steps_TestStepId",
                table: "ExecutionStepResults",
                column: "TestStepId",
                principalTable: "test_steps",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_test_steps_test_cases_test_case_id",
                table: "test_steps",
                column: "test_case_id",
                principalTable: "test_cases",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExecutionStepResults_test_steps_TestStepId",
                table: "ExecutionStepResults");

            migrationBuilder.DropForeignKey(
                name: "FK_test_steps_test_cases_test_case_id",
                table: "test_steps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_test_steps",
                table: "test_steps");

            migrationBuilder.DropIndex(
                name: "IX_test_steps_test_case_id_step_order",
                table: "test_steps");

            migrationBuilder.RenameTable(
                name: "test_steps",
                newName: "TestSteps");

            migrationBuilder.RenameColumn(
                name: "action",
                table: "TestSteps",
                newName: "Action");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "TestSteps",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "test_case_id",
                table: "TestSteps",
                newName: "TestCaseId");

            migrationBuilder.RenameColumn(
                name: "step_order",
                table: "TestSteps",
                newName: "StepOrder");

            migrationBuilder.RenameColumn(
                name: "expected_result",
                table: "TestSteps",
                newName: "ExpectedResult");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestSteps",
                table: "TestSteps",
                column: "Id");

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

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 16, 22, 55, 54, 430, DateTimeKind.Utc).AddTicks(1264));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 16, 22, 55, 54, 430, DateTimeKind.Utc).AddTicks(1267));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 16, 22, 55, 54, 430, DateTimeKind.Utc).AddTicks(1269));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 16, 22, 55, 54, 430, DateTimeKind.Utc).AddTicks(1270));

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
                name: "IX_TestSteps_TestCaseId",
                table: "TestSteps",
                column: "TestCaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExecutionStepResults_TestSteps_TestStepId",
                table: "ExecutionStepResults",
                column: "TestStepId",
                principalTable: "TestSteps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestSteps_test_cases_TestCaseId",
                table: "TestSteps",
                column: "TestCaseId",
                principalTable: "test_cases",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
