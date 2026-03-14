using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QAMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class LinkEvidenceToStep : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evidences_evidence_types_FileTypeId",
                table: "Evidences");

            migrationBuilder.DropForeignKey(
                name: "FK_Evidences_test_executions_TestExecutionId",
                table: "Evidences");

            migrationBuilder.DropForeignKey(
                name: "FK_ExecutionStepResults_step_result_statuses_StatusId",
                table: "ExecutionStepResults");

            migrationBuilder.DropForeignKey(
                name: "FK_ExecutionStepResults_test_executions_TestExecutionId",
                table: "ExecutionStepResults");

            migrationBuilder.DropForeignKey(
                name: "FK_ExecutionStepResults_test_steps_TestStepId",
                table: "ExecutionStepResults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Evidences",
                table: "Evidences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExecutionStepResults",
                table: "ExecutionStepResults");

            migrationBuilder.DropIndex(
                name: "IX_ExecutionStepResults_TestExecutionId",
                table: "ExecutionStepResults");

            migrationBuilder.RenameTable(
                name: "Evidences",
                newName: "evidences");

            migrationBuilder.RenameTable(
                name: "ExecutionStepResults",
                newName: "execution_step_results");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "evidences",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "evidences",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UploadedAt",
                table: "evidences",
                newName: "uploaded_at");

            migrationBuilder.RenameColumn(
                name: "TestExecutionId",
                table: "evidences",
                newName: "test_execution_id");

            migrationBuilder.RenameColumn(
                name: "FileTypeId",
                table: "evidences",
                newName: "file_type_id");

            migrationBuilder.RenameColumn(
                name: "FileSize",
                table: "evidences",
                newName: "file_size");

            migrationBuilder.RenameColumn(
                name: "FilePath",
                table: "evidences",
                newName: "file_path");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "evidences",
                newName: "file_name");

            migrationBuilder.RenameColumn(
                name: "ContentType",
                table: "evidences",
                newName: "content_type");

            migrationBuilder.RenameIndex(
                name: "IX_Evidences_TestExecutionId",
                table: "evidences",
                newName: "IX_evidences_test_execution_id");

            migrationBuilder.RenameIndex(
                name: "IX_Evidences_FileTypeId",
                table: "evidences",
                newName: "IX_evidences_file_type_id");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "execution_step_results",
                newName: "notes");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "execution_step_results",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TestStepId",
                table: "execution_step_results",
                newName: "test_step_id");

            migrationBuilder.RenameColumn(
                name: "TestExecutionId",
                table: "execution_step_results",
                newName: "test_execution_id");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "execution_step_results",
                newName: "status_id");

            migrationBuilder.RenameColumn(
                name: "EvaluatedAt",
                table: "execution_step_results",
                newName: "evaluated_at");

            migrationBuilder.RenameColumn(
                name: "ActualResult",
                table: "execution_step_results",
                newName: "actual_result");

            migrationBuilder.RenameIndex(
                name: "IX_ExecutionStepResults_TestStepId",
                table: "execution_step_results",
                newName: "IX_execution_step_results_test_step_id");

            migrationBuilder.RenameIndex(
                name: "IX_ExecutionStepResults_StatusId",
                table: "execution_step_results",
                newName: "IX_execution_step_results_status_id");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "evidences",
                type: "character varying(2000)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "uploaded_at",
                table: "evidences",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "file_path",
                table: "evidences",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "file_name",
                table: "evidences",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "content_type",
                table: "evidences",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "EvidenceTypeId",
                table: "evidences",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "execution_step_result_id",
                table: "evidences",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "notes",
                table: "execution_step_results",
                type: "character varying(2000)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "evaluated_at",
                table: "execution_step_results",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "actual_result",
                table: "execution_step_results",
                type: "character varying(2000)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StepResultStatusId",
                table: "execution_step_results",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TestStepId1",
                table: "execution_step_results",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_evidences",
                table: "evidences",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_execution_step_results",
                table: "execution_step_results",
                column: "id");

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 17, 2, 12, 31, 148, DateTimeKind.Utc).AddTicks(7894));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 17, 2, 12, 31, 148, DateTimeKind.Utc).AddTicks(7903));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 17, 2, 12, 31, 148, DateTimeKind.Utc).AddTicks(7905));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 17, 2, 12, 31, 148, DateTimeKind.Utc).AddTicks(7906));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 17, 2, 12, 31, 149, DateTimeKind.Utc).AddTicks(6544));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 17, 2, 12, 31, 149, DateTimeKind.Utc).AddTicks(6550));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 17, 2, 12, 31, 149, DateTimeKind.Utc).AddTicks(6552));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 17, 2, 12, 31, 149, DateTimeKind.Utc).AddTicks(6561));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 5,
                column: "created_at",
                value: new DateTime(2026, 2, 17, 2, 12, 31, 149, DateTimeKind.Utc).AddTicks(6564));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 6,
                column: "created_at",
                value: new DateTime(2026, 2, 17, 2, 12, 31, 149, DateTimeKind.Utc).AddTicks(6565));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 17, 2, 12, 31, 142, DateTimeKind.Utc).AddTicks(5808));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 17, 2, 12, 31, 142, DateTimeKind.Utc).AddTicks(5812));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 17, 2, 12, 31, 142, DateTimeKind.Utc).AddTicks(5815));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 17, 2, 12, 31, 142, DateTimeKind.Utc).AddTicks(5817));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 17, 2, 12, 31, 163, DateTimeKind.Utc).AddTicks(7801));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 17, 2, 12, 31, 163, DateTimeKind.Utc).AddTicks(7806));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 17, 2, 12, 31, 163, DateTimeKind.Utc).AddTicks(7810));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 17, 2, 12, 31, 163, DateTimeKind.Utc).AddTicks(7813));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 17, 2, 12, 31, 164, DateTimeKind.Utc).AddTicks(5939));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 17, 2, 12, 31, 164, DateTimeKind.Utc).AddTicks(5945));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 17, 2, 12, 31, 164, DateTimeKind.Utc).AddTicks(5949));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 17, 2, 12, 31, 164, DateTimeKind.Utc).AddTicks(5951));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 17, 2, 12, 31, 171, DateTimeKind.Utc).AddTicks(6644));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 17, 2, 12, 31, 171, DateTimeKind.Utc).AddTicks(6648));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 17, 2, 12, 31, 171, DateTimeKind.Utc).AddTicks(6650));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 17, 2, 12, 31, 171, DateTimeKind.Utc).AddTicks(6652));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 17, 2, 12, 31, 143, DateTimeKind.Utc).AddTicks(658));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 17, 2, 12, 31, 143, DateTimeKind.Utc).AddTicks(662));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 17, 2, 12, 31, 143, DateTimeKind.Utc).AddTicks(664));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 17, 2, 12, 31, 143, DateTimeKind.Utc).AddTicks(666));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 17, 2, 12, 31, 143, DateTimeKind.Utc).AddTicks(3775));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 17, 2, 12, 31, 143, DateTimeKind.Utc).AddTicks(3779));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 17, 2, 12, 31, 143, DateTimeKind.Utc).AddTicks(3781));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 17, 2, 12, 31, 143, DateTimeKind.Utc).AddTicks(3784));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 17, 2, 12, 31, 143, DateTimeKind.Utc).AddTicks(3786));

            migrationBuilder.CreateIndex(
                name: "IX_evidences_EvidenceTypeId",
                table: "evidences",
                column: "EvidenceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_evidences_execution_step_result_id",
                table: "evidences",
                column: "execution_step_result_id");

            migrationBuilder.CreateIndex(
                name: "IX_execution_step_results_StepResultStatusId",
                table: "execution_step_results",
                column: "StepResultStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_execution_step_results_test_execution_id_test_step_id",
                table: "execution_step_results",
                columns: new[] { "test_execution_id", "test_step_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_execution_step_results_TestStepId1",
                table: "execution_step_results",
                column: "TestStepId1");

            migrationBuilder.AddForeignKey(
                name: "FK_evidences_evidence_types_EvidenceTypeId",
                table: "evidences",
                column: "EvidenceTypeId",
                principalTable: "evidence_types",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_evidences_evidence_types_file_type_id",
                table: "evidences",
                column: "file_type_id",
                principalTable: "evidence_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_evidences_execution_step_results_execution_step_result_id",
                table: "evidences",
                column: "execution_step_result_id",
                principalTable: "execution_step_results",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_evidences_test_executions_test_execution_id",
                table: "evidences",
                column: "test_execution_id",
                principalTable: "test_executions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_execution_step_results_step_result_statuses_StepResultStatu~",
                table: "execution_step_results",
                column: "StepResultStatusId",
                principalTable: "step_result_statuses",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_execution_step_results_step_result_statuses_status_id",
                table: "execution_step_results",
                column: "status_id",
                principalTable: "step_result_statuses",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_execution_step_results_test_executions_test_execution_id",
                table: "execution_step_results",
                column: "test_execution_id",
                principalTable: "test_executions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_execution_step_results_test_steps_TestStepId1",
                table: "execution_step_results",
                column: "TestStepId1",
                principalTable: "test_steps",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_execution_step_results_test_steps_test_step_id",
                table: "execution_step_results",
                column: "test_step_id",
                principalTable: "test_steps",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_evidences_evidence_types_EvidenceTypeId",
                table: "evidences");

            migrationBuilder.DropForeignKey(
                name: "FK_evidences_evidence_types_file_type_id",
                table: "evidences");

            migrationBuilder.DropForeignKey(
                name: "FK_evidences_execution_step_results_execution_step_result_id",
                table: "evidences");

            migrationBuilder.DropForeignKey(
                name: "FK_evidences_test_executions_test_execution_id",
                table: "evidences");

            migrationBuilder.DropForeignKey(
                name: "FK_execution_step_results_step_result_statuses_StepResultStatu~",
                table: "execution_step_results");

            migrationBuilder.DropForeignKey(
                name: "FK_execution_step_results_step_result_statuses_status_id",
                table: "execution_step_results");

            migrationBuilder.DropForeignKey(
                name: "FK_execution_step_results_test_executions_test_execution_id",
                table: "execution_step_results");

            migrationBuilder.DropForeignKey(
                name: "FK_execution_step_results_test_steps_TestStepId1",
                table: "execution_step_results");

            migrationBuilder.DropForeignKey(
                name: "FK_execution_step_results_test_steps_test_step_id",
                table: "execution_step_results");

            migrationBuilder.DropPrimaryKey(
                name: "PK_evidences",
                table: "evidences");

            migrationBuilder.DropIndex(
                name: "IX_evidences_EvidenceTypeId",
                table: "evidences");

            migrationBuilder.DropIndex(
                name: "IX_evidences_execution_step_result_id",
                table: "evidences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_execution_step_results",
                table: "execution_step_results");

            migrationBuilder.DropIndex(
                name: "IX_execution_step_results_StepResultStatusId",
                table: "execution_step_results");

            migrationBuilder.DropIndex(
                name: "IX_execution_step_results_test_execution_id_test_step_id",
                table: "execution_step_results");

            migrationBuilder.DropIndex(
                name: "IX_execution_step_results_TestStepId1",
                table: "execution_step_results");

            migrationBuilder.DropColumn(
                name: "EvidenceTypeId",
                table: "evidences");

            migrationBuilder.DropColumn(
                name: "execution_step_result_id",
                table: "evidences");

            migrationBuilder.DropColumn(
                name: "StepResultStatusId",
                table: "execution_step_results");

            migrationBuilder.DropColumn(
                name: "TestStepId1",
                table: "execution_step_results");

            migrationBuilder.RenameTable(
                name: "evidences",
                newName: "Evidences");

            migrationBuilder.RenameTable(
                name: "execution_step_results",
                newName: "ExecutionStepResults");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Evidences",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Evidences",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "uploaded_at",
                table: "Evidences",
                newName: "UploadedAt");

            migrationBuilder.RenameColumn(
                name: "test_execution_id",
                table: "Evidences",
                newName: "TestExecutionId");

            migrationBuilder.RenameColumn(
                name: "file_type_id",
                table: "Evidences",
                newName: "FileTypeId");

            migrationBuilder.RenameColumn(
                name: "file_size",
                table: "Evidences",
                newName: "FileSize");

            migrationBuilder.RenameColumn(
                name: "file_path",
                table: "Evidences",
                newName: "FilePath");

            migrationBuilder.RenameColumn(
                name: "file_name",
                table: "Evidences",
                newName: "FileName");

            migrationBuilder.RenameColumn(
                name: "content_type",
                table: "Evidences",
                newName: "ContentType");

            migrationBuilder.RenameIndex(
                name: "IX_evidences_test_execution_id",
                table: "Evidences",
                newName: "IX_Evidences_TestExecutionId");

            migrationBuilder.RenameIndex(
                name: "IX_evidences_file_type_id",
                table: "Evidences",
                newName: "IX_Evidences_FileTypeId");

            migrationBuilder.RenameColumn(
                name: "notes",
                table: "ExecutionStepResults",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ExecutionStepResults",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "test_step_id",
                table: "ExecutionStepResults",
                newName: "TestStepId");

            migrationBuilder.RenameColumn(
                name: "test_execution_id",
                table: "ExecutionStepResults",
                newName: "TestExecutionId");

            migrationBuilder.RenameColumn(
                name: "status_id",
                table: "ExecutionStepResults",
                newName: "StatusId");

            migrationBuilder.RenameColumn(
                name: "evaluated_at",
                table: "ExecutionStepResults",
                newName: "EvaluatedAt");

            migrationBuilder.RenameColumn(
                name: "actual_result",
                table: "ExecutionStepResults",
                newName: "ActualResult");

            migrationBuilder.RenameIndex(
                name: "IX_execution_step_results_test_step_id",
                table: "ExecutionStepResults",
                newName: "IX_ExecutionStepResults_TestStepId");

            migrationBuilder.RenameIndex(
                name: "IX_execution_step_results_status_id",
                table: "ExecutionStepResults",
                newName: "IX_ExecutionStepResults_StatusId");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Evidences",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(2000)",
                oldMaxLength: 2000,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UploadedAt",
                table: "Evidences",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()");

            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                table: "Evidences",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                table: "Evidences",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "ContentType",
                table: "Evidences",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "ExecutionStepResults",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(2000)",
                oldMaxLength: 2000,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EvaluatedAt",
                table: "ExecutionStepResults",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()");

            migrationBuilder.AlterColumn<string>(
                name: "ActualResult",
                table: "ExecutionStepResults",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(2000)",
                oldMaxLength: 2000,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Evidences",
                table: "Evidences",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExecutionStepResults",
                table: "ExecutionStepResults",
                column: "Id");

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
                name: "IX_ExecutionStepResults_TestExecutionId",
                table: "ExecutionStepResults",
                column: "TestExecutionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Evidences_evidence_types_FileTypeId",
                table: "Evidences",
                column: "FileTypeId",
                principalTable: "evidence_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Evidences_test_executions_TestExecutionId",
                table: "Evidences",
                column: "TestExecutionId",
                principalTable: "test_executions",
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
                name: "FK_ExecutionStepResults_test_executions_TestExecutionId",
                table: "ExecutionStepResults",
                column: "TestExecutionId",
                principalTable: "test_executions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExecutionStepResults_test_steps_TestStepId",
                table: "ExecutionStepResults",
                column: "TestStepId",
                principalTable: "test_steps",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
