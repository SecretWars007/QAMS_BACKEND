using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QAMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDevolutionObservationsAndObservationFile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Removed redundant AddColumn calls for:
            // test_steps.created_by_user_id
            // test_executions.actual_time_hours
            // projects.DevolucionesCounter
            // projects.executed_hours
            // projects.remaining_hours
            // projects.work_hours_per_day
            // (These columns already exist in the database)

            migrationBuilder.CreateTable(
                name: "execution_step_observations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ExecutionStepResultId = table.Column<Guid>(type: "uuid", nullable: false),
                    Observation = table.Column<string>(type: "text", nullable: false),
                    Response = table.Column<string>(type: "text", nullable: true),
                    FileTypeId = table.Column<int>(type: "integer", nullable: true),
                    FileName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    FilePath = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    FileSize = table.Column<long>(type: "bigint", nullable: true),
                    ContentType = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RespondedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    RespondedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_execution_step_observations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_execution_step_observations_evidence_types_FileTypeId",
                        column: x => x.FileTypeId,
                        principalTable: "evidence_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_execution_step_observations_execution_step_results_Executio~",
                        column: x => x.ExecutionStepResultId,
                        principalTable: "execution_step_results",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_execution_step_observations_users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_execution_step_observations_users_RespondedByUserId",
                        column: x => x.RespondedByUserId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "project_devolutions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    DevolutionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: false),
                    ResponseDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ResponseNotes = table.Column<string>(type: "text", nullable: true),
                    ObservationsCount = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project_devolutions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_project_devolutions_projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_project_devolutions_users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 2, 6, 26, 352, DateTimeKind.Utc).AddTicks(9132));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 2, 6, 26, 352, DateTimeKind.Utc).AddTicks(9137));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 2, 6, 26, 352, DateTimeKind.Utc).AddTicks(9140));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 2, 6, 26, 352, DateTimeKind.Utc).AddTicks(9141));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 2, 6, 26, 353, DateTimeKind.Utc).AddTicks(3769));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 2, 6, 26, 353, DateTimeKind.Utc).AddTicks(3775));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 2, 6, 26, 353, DateTimeKind.Utc).AddTicks(3776));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 2, 6, 26, 353, DateTimeKind.Utc).AddTicks(3778));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 5,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 2, 6, 26, 353, DateTimeKind.Utc).AddTicks(3779));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 6,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 2, 6, 26, 353, DateTimeKind.Utc).AddTicks(3780));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 25, 2, 6, 26, 349, DateTimeKind.Utc).AddTicks(1641));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 25, 2, 6, 26, 349, DateTimeKind.Utc).AddTicks(1643));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 25, 2, 6, 26, 349, DateTimeKind.Utc).AddTicks(1645));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 25, 2, 6, 26, 349, DateTimeKind.Utc).AddTicks(1647));

            migrationBuilder.InsertData(
                table: "project_statuses",
                columns: new[] { "Id", "Code", "CreatedAt", "Description", "IsActive", "Name", "SortOrder" },
                values: new object[] { 5, "DEVOLUCION", new DateTime(2026, 2, 25, 2, 6, 26, 349, DateTimeKind.Utc).AddTicks(1649), "Proyecto devuelto por falta de aprobación o errores graves", true, "Devolución", 5 });

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 2, 6, 26, 367, DateTimeKind.Utc).AddTicks(7463));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 2, 6, 26, 367, DateTimeKind.Utc).AddTicks(7466));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 2, 6, 26, 367, DateTimeKind.Utc).AddTicks(7468));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 2, 6, 26, 367, DateTimeKind.Utc).AddTicks(7469));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 2, 6, 26, 368, DateTimeKind.Utc).AddTicks(3177));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 2, 6, 26, 368, DateTimeKind.Utc).AddTicks(3182));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 2, 6, 26, 368, DateTimeKind.Utc).AddTicks(3183));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 2, 6, 26, 368, DateTimeKind.Utc).AddTicks(3185));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 2, 6, 26, 372, DateTimeKind.Utc).AddTicks(1713));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 2, 6, 26, 372, DateTimeKind.Utc).AddTicks(1718));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 2, 6, 26, 372, DateTimeKind.Utc).AddTicks(1721));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 2, 6, 26, 372, DateTimeKind.Utc).AddTicks(1723));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 25, 2, 6, 26, 349, DateTimeKind.Utc).AddTicks(4678));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 25, 2, 6, 26, 349, DateTimeKind.Utc).AddTicks(4680));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 25, 2, 6, 26, 349, DateTimeKind.Utc).AddTicks(4681));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 25, 2, 6, 26, 349, DateTimeKind.Utc).AddTicks(4682));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 25, 2, 6, 26, 349, DateTimeKind.Utc).AddTicks(7266));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 25, 2, 6, 26, 349, DateTimeKind.Utc).AddTicks(7271));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 25, 2, 6, 26, 349, DateTimeKind.Utc).AddTicks(7273));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 25, 2, 6, 26, 349, DateTimeKind.Utc).AddTicks(7274));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 25, 2, 6, 26, 349, DateTimeKind.Utc).AddTicks(7276));

            migrationBuilder.CreateIndex(
                name: "IX_execution_step_observations_CreatedByUserId",
                table: "execution_step_observations",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_execution_step_observations_ExecutionStepResultId",
                table: "execution_step_observations",
                column: "ExecutionStepResultId");

            migrationBuilder.CreateIndex(
                name: "IX_execution_step_observations_FileTypeId",
                table: "execution_step_observations",
                column: "FileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_execution_step_observations_RespondedByUserId",
                table: "execution_step_observations",
                column: "RespondedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_project_devolutions_CreatedByUserId",
                table: "project_devolutions",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_project_devolutions_ProjectId",
                table: "project_devolutions",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "execution_step_observations");

            migrationBuilder.DropTable(
                name: "project_devolutions");

            migrationBuilder.DeleteData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 5);

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
        }
    }
}
