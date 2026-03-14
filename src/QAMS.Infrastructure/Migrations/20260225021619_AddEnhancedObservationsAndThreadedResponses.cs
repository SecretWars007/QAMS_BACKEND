using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QAMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEnhancedObservationsAndThreadedResponses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "execution_step_observation_responses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ExecutionStepObservationId = table.Column<Guid>(type: "uuid", nullable: false),
                    Response = table.Column<string>(type: "text", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_execution_step_observation_responses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_execution_step_observation_responses_execution_step_observa~",
                        column: x => x.ExecutionStepObservationId,
                        principalTable: "execution_step_observations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_execution_step_observation_responses_users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "project_observations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    Observation = table.Column<string>(type: "text", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project_observations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_project_observations_projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_project_observations_users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "project_observation_responses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectObservationId = table.Column<Guid>(type: "uuid", nullable: false),
                    Response = table.Column<string>(type: "text", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project_observation_responses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_project_observation_responses_project_observations_ProjectO~",
                        column: x => x.ProjectObservationId,
                        principalTable: "project_observations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_project_observation_responses_users_CreatedByUserId",
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
                value: new DateTime(2026, 2, 25, 2, 16, 17, 241, DateTimeKind.Utc).AddTicks(1147));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 2, 16, 17, 241, DateTimeKind.Utc).AddTicks(1151));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 2, 16, 17, 241, DateTimeKind.Utc).AddTicks(1153));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 2, 16, 17, 241, DateTimeKind.Utc).AddTicks(1154));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 2, 16, 17, 241, DateTimeKind.Utc).AddTicks(9785));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 2, 16, 17, 241, DateTimeKind.Utc).AddTicks(9795));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 2, 16, 17, 241, DateTimeKind.Utc).AddTicks(9797));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 2, 16, 17, 241, DateTimeKind.Utc).AddTicks(9798));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 5,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 2, 16, 17, 241, DateTimeKind.Utc).AddTicks(9799));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 6,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 2, 16, 17, 241, DateTimeKind.Utc).AddTicks(9800));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 25, 2, 16, 17, 230, DateTimeKind.Utc).AddTicks(8431));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 25, 2, 16, 17, 230, DateTimeKind.Utc).AddTicks(8434));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 25, 2, 16, 17, 230, DateTimeKind.Utc).AddTicks(8436));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 25, 2, 16, 17, 230, DateTimeKind.Utc).AddTicks(8438));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 25, 2, 16, 17, 230, DateTimeKind.Utc).AddTicks(8446));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 2, 16, 17, 269, DateTimeKind.Utc).AddTicks(5375));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 2, 16, 17, 269, DateTimeKind.Utc).AddTicks(5388));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 2, 16, 17, 269, DateTimeKind.Utc).AddTicks(5390));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 2, 16, 17, 269, DateTimeKind.Utc).AddTicks(5391));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 2, 16, 17, 271, DateTimeKind.Utc).AddTicks(6755));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 2, 16, 17, 271, DateTimeKind.Utc).AddTicks(6758));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 2, 16, 17, 271, DateTimeKind.Utc).AddTicks(6760));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 2, 16, 17, 271, DateTimeKind.Utc).AddTicks(6762));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 2, 16, 17, 283, DateTimeKind.Utc).AddTicks(8456));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 2, 16, 17, 283, DateTimeKind.Utc).AddTicks(8462));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 2, 16, 17, 283, DateTimeKind.Utc).AddTicks(8464));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 2, 16, 17, 283, DateTimeKind.Utc).AddTicks(8465));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 25, 2, 16, 17, 233, DateTimeKind.Utc).AddTicks(1558));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 25, 2, 16, 17, 233, DateTimeKind.Utc).AddTicks(1569));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 25, 2, 16, 17, 233, DateTimeKind.Utc).AddTicks(1571));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 25, 2, 16, 17, 233, DateTimeKind.Utc).AddTicks(1573));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 25, 2, 16, 17, 235, DateTimeKind.Utc).AddTicks(2559));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 25, 2, 16, 17, 235, DateTimeKind.Utc).AddTicks(2562));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 25, 2, 16, 17, 235, DateTimeKind.Utc).AddTicks(2564));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 25, 2, 16, 17, 235, DateTimeKind.Utc).AddTicks(2566));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 25, 2, 16, 17, 235, DateTimeKind.Utc).AddTicks(2567));

            migrationBuilder.CreateIndex(
                name: "IX_execution_step_observation_responses_CreatedByUserId",
                table: "execution_step_observation_responses",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_execution_step_observation_responses_ExecutionStepObservati~",
                table: "execution_step_observation_responses",
                column: "ExecutionStepObservationId");

            migrationBuilder.CreateIndex(
                name: "IX_project_observation_responses_CreatedByUserId",
                table: "project_observation_responses",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_project_observation_responses_ProjectObservationId",
                table: "project_observation_responses",
                column: "ProjectObservationId");

            migrationBuilder.CreateIndex(
                name: "IX_project_observations_CreatedByUserId",
                table: "project_observations",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_project_observations_ProjectId",
                table: "project_observations",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "execution_step_observation_responses");

            migrationBuilder.DropTable(
                name: "project_observation_responses");

            migrationBuilder.DropTable(
                name: "project_observations");

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

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 25, 2, 6, 26, 349, DateTimeKind.Utc).AddTicks(1649));

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
        }
    }
}
