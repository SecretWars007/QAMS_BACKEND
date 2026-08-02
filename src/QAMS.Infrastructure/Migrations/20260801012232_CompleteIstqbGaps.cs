using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QAMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CompleteIstqbGaps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "bdd_scenario",
                table: "test_cases",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_bdd",
                table: "test_cases",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "parent_test_case_id",
                table: "test_cases",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ShareToken",
                table: "projects",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ColumnEnteredAt",
                table: "kanban_tasks",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "WipLimit",
                table: "kanban_columns",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "exploratory_sessions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    project_id = table.Column<Guid>(type: "uuid", nullable: false),
                    tester_id = table.Column<Guid>(type: "uuid", nullable: false),
                    charter = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    status_id = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    start_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    end_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    duration_minutes = table.Column<int>(type: "integer", nullable: true),
                    notes = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exploratory_sessions", x => x.id);
                    table.ForeignKey(
                        name: "FK_exploratory_sessions_projects_project_id",
                        column: x => x.project_id,
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_exploratory_sessions_users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_exploratory_sessions_users_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_exploratory_sessions_users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_exploratory_sessions_users_tester_id",
                        column: x => x.tester_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "exploratory_findings",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    session_id = table.Column<Guid>(type: "uuid", nullable: false),
                    type_id = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exploratory_findings", x => x.id);
                    table.ForeignKey(
                        name: "FK_exploratory_findings_exploratory_sessions_session_id",
                        column: x => x.session_id,
                        principalTable: "exploratory_sessions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_exploratory_findings_users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_exploratory_findings_users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.UpdateData(
                table: "defect_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 897, DateTimeKind.Utc).AddTicks(3977));

            migrationBuilder.UpdateData(
                table: "defect_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 897, DateTimeKind.Utc).AddTicks(3982));

            migrationBuilder.UpdateData(
                table: "defect_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 897, DateTimeKind.Utc).AddTicks(3983));

            migrationBuilder.UpdateData(
                table: "defect_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 897, DateTimeKind.Utc).AddTicks(3984));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 897, DateTimeKind.Utc).AddTicks(6490));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 897, DateTimeKind.Utc).AddTicks(6492));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 897, DateTimeKind.Utc).AddTicks(6494));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 897, DateTimeKind.Utc).AddTicks(6495));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 5,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 897, DateTimeKind.Utc).AddTicks(6501));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 899, DateTimeKind.Utc).AddTicks(3081));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 899, DateTimeKind.Utc).AddTicks(3083));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 899, DateTimeKind.Utc).AddTicks(3085));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 899, DateTimeKind.Utc).AddTicks(3086));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 899, DateTimeKind.Utc).AddTicks(5555));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 899, DateTimeKind.Utc).AddTicks(5557));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 899, DateTimeKind.Utc).AddTicks(5558));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 899, DateTimeKind.Utc).AddTicks(5559));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 5,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 899, DateTimeKind.Utc).AddTicks(5560));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 6,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 899, DateTimeKind.Utc).AddTicks(5561));

            migrationBuilder.UpdateData(
                table: "finding_severities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 903, DateTimeKind.Utc).AddTicks(3574));

            migrationBuilder.UpdateData(
                table: "finding_severities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 903, DateTimeKind.Utc).AddTicks(3576));

            migrationBuilder.UpdateData(
                table: "finding_severities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 903, DateTimeKind.Utc).AddTicks(3578));

            migrationBuilder.UpdateData(
                table: "finding_severities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 903, DateTimeKind.Utc).AddTicks(3579));

            migrationBuilder.UpdateData(
                table: "finding_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 903, DateTimeKind.Utc).AddTicks(5234));

            migrationBuilder.UpdateData(
                table: "finding_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 903, DateTimeKind.Utc).AddTicks(5235));

            migrationBuilder.UpdateData(
                table: "finding_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 903, DateTimeKind.Utc).AddTicks(5236));

            migrationBuilder.UpdateData(
                table: "finding_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 903, DateTimeKind.Utc).AddTicks(5237));

            migrationBuilder.UpdateData(
                table: "finding_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 903, DateTimeKind.Utc).AddTicks(6930));

            migrationBuilder.UpdateData(
                table: "finding_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 903, DateTimeKind.Utc).AddTicks(6932));

            migrationBuilder.UpdateData(
                table: "finding_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 903, DateTimeKind.Utc).AddTicks(6933));

            migrationBuilder.UpdateData(
                table: "finding_types",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 903, DateTimeKind.Utc).AddTicks(6934));

            migrationBuilder.UpdateData(
                table: "platform_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 908, DateTimeKind.Utc).AddTicks(4903));

            migrationBuilder.UpdateData(
                table: "platform_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 908, DateTimeKind.Utc).AddTicks(4905));

            migrationBuilder.UpdateData(
                table: "platform_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 908, DateTimeKind.Utc).AddTicks(4906));

            migrationBuilder.UpdateData(
                table: "project_priorities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 916, DateTimeKind.Utc).AddTicks(5376));

            migrationBuilder.UpdateData(
                table: "project_priorities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 916, DateTimeKind.Utc).AddTicks(5379));

            migrationBuilder.UpdateData(
                table: "project_priorities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 916, DateTimeKind.Utc).AddTicks(5380));

            migrationBuilder.UpdateData(
                table: "project_priorities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 916, DateTimeKind.Utc).AddTicks(5381));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 894, DateTimeKind.Utc).AddTicks(9359));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 894, DateTimeKind.Utc).AddTicks(9362));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 894, DateTimeKind.Utc).AddTicks(9363));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 894, DateTimeKind.Utc).AddTicks(9365));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 894, DateTimeKind.Utc).AddTicks(9373));

            migrationBuilder.UpdateData(
                table: "requirement_complexities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 918, DateTimeKind.Utc).AddTicks(3608));

            migrationBuilder.UpdateData(
                table: "requirement_complexities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 918, DateTimeKind.Utc).AddTicks(3611));

            migrationBuilder.UpdateData(
                table: "requirement_complexities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 918, DateTimeKind.Utc).AddTicks(3612));

            migrationBuilder.UpdateData(
                table: "requirement_complexities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 918, DateTimeKind.Utc).AddTicks(3613));

            migrationBuilder.UpdateData(
                table: "requirement_priorities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 920, DateTimeKind.Utc).AddTicks(8035));

            migrationBuilder.UpdateData(
                table: "requirement_priorities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 920, DateTimeKind.Utc).AddTicks(8038));

            migrationBuilder.UpdateData(
                table: "requirement_priorities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 920, DateTimeKind.Utc).AddTicks(8039));

            migrationBuilder.UpdateData(
                table: "requirement_priorities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 920, DateTimeKind.Utc).AddTicks(8040));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 921, DateTimeKind.Utc).AddTicks(376));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 921, DateTimeKind.Utc).AddTicks(379));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 921, DateTimeKind.Utc).AddTicks(380));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 921, DateTimeKind.Utc).AddTicks(381));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 921, DateTimeKind.Utc).AddTicks(382));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 921, DateTimeKind.Utc).AddTicks(383));

            migrationBuilder.UpdateData(
                table: "requirement_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 921, DateTimeKind.Utc).AddTicks(7435));

            migrationBuilder.UpdateData(
                table: "requirement_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 921, DateTimeKind.Utc).AddTicks(7437));

            migrationBuilder.UpdateData(
                table: "requirement_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 921, DateTimeKind.Utc).AddTicks(7439));

            migrationBuilder.UpdateData(
                table: "requirement_types",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 921, DateTimeKind.Utc).AddTicks(7440));

            migrationBuilder.UpdateData(
                table: "review_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 924, DateTimeKind.Utc).AddTicks(2942));

            migrationBuilder.UpdateData(
                table: "review_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 924, DateTimeKind.Utc).AddTicks(2944));

            migrationBuilder.UpdateData(
                table: "review_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 924, DateTimeKind.Utc).AddTicks(2946));

            migrationBuilder.UpdateData(
                table: "review_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 924, DateTimeKind.Utc).AddTicks(2947));

            migrationBuilder.UpdateData(
                table: "review_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 924, DateTimeKind.Utc).AddTicks(7579));

            migrationBuilder.UpdateData(
                table: "review_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 924, DateTimeKind.Utc).AddTicks(7584));

            migrationBuilder.UpdateData(
                table: "review_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 924, DateTimeKind.Utc).AddTicks(7587));

            migrationBuilder.UpdateData(
                table: "review_types",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 924, DateTimeKind.Utc).AddTicks(7589));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("41544143-4f4c-5347-5f4d-414e41474500"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4903));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("41544143-4f4c-5347-5f56-494557000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4900));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-435f-5245-415445000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4927));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-445f-454c-455445000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4930));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4929));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4926));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f4352454154"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4917));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5550444154"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4923));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f55504c4f41"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4925));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4915));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-4544-4c45-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4897));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-4956-4557-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4871));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-5055-4441-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4889));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-5243-4541-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4888));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-5341-5349-474e5f504552"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4898));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4931));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f43-524541544500"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4906));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f44-454c45544500"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4909));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f55-504441544500"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4907));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4905));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-4544-4c45-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4863));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-4956-4557-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4821));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-5055-4441-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4862));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-5243-4541-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4859));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-5341-5349-474e5f524f4c"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4869));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f4352454154"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4911));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f44454c4554"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4914));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5550444154"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4913));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4910));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4544-454c-5445-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4937));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4956-5745-0000-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4933));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5055-4144-5445-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4936));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5243-4145-5445-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4935));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("41544143-4f4c-5347-5f56-494557000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4972));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4969));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4967));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f4352454154"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4963));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5550444154"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4964));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f55504c4f41"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4966));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4961));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4970));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4948));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4954));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4956-5745-0000-000000000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4973));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5055-4144-5445-000000000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4976));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5243-4145-5445-000000000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4975));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("41544143-4f4c-5347-5f56-494557000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(5007));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(5004));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(5003));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f4352454154"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4999));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5550444154"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(5000));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f55504c4f41"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(5001));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4998));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(5006));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f43-524541544500"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4984));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f55-504441544500"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4986));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4982));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-4956-4557-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4992));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f4352454154"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4995));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5550444154"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4996));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(4994));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4544-454c-5445-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(5019));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4956-5745-0000-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(5009));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5055-4144-5445-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(5017));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5243-4145-5445-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(5010));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(5029));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(5027));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(5026));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(5030));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(5021));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(5023));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4956-5745-0000-000000000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(5032));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(8066));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(8069));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(8071));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 926, DateTimeKind.Utc).AddTicks(8072));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 928, DateTimeKind.Utc).AddTicks(7140));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 928, DateTimeKind.Utc).AddTicks(7142));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 928, DateTimeKind.Utc).AddTicks(7143));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 928, DateTimeKind.Utc).AddTicks(7144));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 935, DateTimeKind.Utc).AddTicks(8740));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 935, DateTimeKind.Utc).AddTicks(8742));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 935, DateTimeKind.Utc).AddTicks(8744));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 935, DateTimeKind.Utc).AddTicks(8745));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 936, DateTimeKind.Utc).AddTicks(431));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 936, DateTimeKind.Utc).AddTicks(432));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 936, DateTimeKind.Utc).AddTicks(434));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 936, DateTimeKind.Utc).AddTicks(435));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 936, DateTimeKind.Utc).AddTicks(435));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 936, DateTimeKind.Utc).AddTicks(436));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 936, DateTimeKind.Utc).AddTicks(437));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 936, DateTimeKind.Utc).AddTicks(438));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 936, DateTimeKind.Utc).AddTicks(439));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 936, DateTimeKind.Utc).AddTicks(440));

            migrationBuilder.UpdateData(
                table: "test_plan_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 895, DateTimeKind.Utc).AddTicks(1342));

            migrationBuilder.UpdateData(
                table: "test_plan_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 895, DateTimeKind.Utc).AddTicks(1345));

            migrationBuilder.UpdateData(
                table: "test_plan_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 895, DateTimeKind.Utc).AddTicks(1346));

            migrationBuilder.UpdateData(
                table: "test_plan_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 895, DateTimeKind.Utc).AddTicks(1347));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 895, DateTimeKind.Utc).AddTicks(2941));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 895, DateTimeKind.Utc).AddTicks(2943));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 895, DateTimeKind.Utc).AddTicks(2944));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 895, DateTimeKind.Utc).AddTicks(2945));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 895, DateTimeKind.Utc).AddTicks(4313));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 895, DateTimeKind.Utc).AddTicks(4315));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 895, DateTimeKind.Utc).AddTicks(4317));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 895, DateTimeKind.Utc).AddTicks(4318));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 895, DateTimeKind.Utc).AddTicks(4320));

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("99999999-9999-9999-9999-999999999999") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 1, 22, 30, 949, DateTimeKind.Utc).AddTicks(7918));

            migrationBuilder.CreateIndex(
                name: "IX_test_cases_parent_test_case_id",
                table: "test_cases",
                column: "parent_test_case_id");

            migrationBuilder.CreateIndex(
                name: "IX_exploratory_findings_CreatedByUserId",
                table: "exploratory_findings",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_exploratory_findings_session_id",
                table: "exploratory_findings",
                column: "session_id");

            migrationBuilder.CreateIndex(
                name: "IX_exploratory_findings_UpdatedByUserId",
                table: "exploratory_findings",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_exploratory_sessions_CreatedByUserId",
                table: "exploratory_sessions",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_exploratory_sessions_DeletedByUserId",
                table: "exploratory_sessions",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_exploratory_sessions_project_id",
                table: "exploratory_sessions",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "IX_exploratory_sessions_tester_id",
                table: "exploratory_sessions",
                column: "tester_id");

            migrationBuilder.CreateIndex(
                name: "IX_exploratory_sessions_UpdatedByUserId",
                table: "exploratory_sessions",
                column: "UpdatedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_test_cases_test_cases_parent_test_case_id",
                table: "test_cases",
                column: "parent_test_case_id",
                principalTable: "test_cases",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_test_cases_test_cases_parent_test_case_id",
                table: "test_cases");

            migrationBuilder.DropTable(
                name: "exploratory_findings");

            migrationBuilder.DropTable(
                name: "exploratory_sessions");

            migrationBuilder.DropIndex(
                name: "IX_test_cases_parent_test_case_id",
                table: "test_cases");

            migrationBuilder.DropColumn(
                name: "bdd_scenario",
                table: "test_cases");

            migrationBuilder.DropColumn(
                name: "is_bdd",
                table: "test_cases");

            migrationBuilder.DropColumn(
                name: "parent_test_case_id",
                table: "test_cases");

            migrationBuilder.DropColumn(
                name: "ShareToken",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "ColumnEnteredAt",
                table: "kanban_tasks");

            migrationBuilder.DropColumn(
                name: "WipLimit",
                table: "kanban_columns");

            migrationBuilder.UpdateData(
                table: "defect_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 69, DateTimeKind.Utc).AddTicks(9098));

            migrationBuilder.UpdateData(
                table: "defect_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 69, DateTimeKind.Utc).AddTicks(9102));

            migrationBuilder.UpdateData(
                table: "defect_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 69, DateTimeKind.Utc).AddTicks(9104));

            migrationBuilder.UpdateData(
                table: "defect_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 69, DateTimeKind.Utc).AddTicks(9105));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 70, DateTimeKind.Utc).AddTicks(1808));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 70, DateTimeKind.Utc).AddTicks(1810));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 70, DateTimeKind.Utc).AddTicks(1812));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 70, DateTimeKind.Utc).AddTicks(1813));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 5,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 70, DateTimeKind.Utc).AddTicks(1814));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 72, DateTimeKind.Utc).AddTicks(1366));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 72, DateTimeKind.Utc).AddTicks(1373));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 72, DateTimeKind.Utc).AddTicks(1374));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 72, DateTimeKind.Utc).AddTicks(1375));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 72, DateTimeKind.Utc).AddTicks(5812));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 72, DateTimeKind.Utc).AddTicks(5817));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 72, DateTimeKind.Utc).AddTicks(5818));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 72, DateTimeKind.Utc).AddTicks(5819));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 5,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 72, DateTimeKind.Utc).AddTicks(5820));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 6,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 72, DateTimeKind.Utc).AddTicks(5821));

            migrationBuilder.UpdateData(
                table: "finding_severities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 77, DateTimeKind.Utc).AddTicks(5999));

            migrationBuilder.UpdateData(
                table: "finding_severities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 77, DateTimeKind.Utc).AddTicks(6002));

            migrationBuilder.UpdateData(
                table: "finding_severities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 77, DateTimeKind.Utc).AddTicks(6003));

            migrationBuilder.UpdateData(
                table: "finding_severities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 77, DateTimeKind.Utc).AddTicks(6004));

            migrationBuilder.UpdateData(
                table: "finding_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 77, DateTimeKind.Utc).AddTicks(8084));

            migrationBuilder.UpdateData(
                table: "finding_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 77, DateTimeKind.Utc).AddTicks(8086));

            migrationBuilder.UpdateData(
                table: "finding_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 77, DateTimeKind.Utc).AddTicks(8087));

            migrationBuilder.UpdateData(
                table: "finding_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 77, DateTimeKind.Utc).AddTicks(8088));

            migrationBuilder.UpdateData(
                table: "finding_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 77, DateTimeKind.Utc).AddTicks(9697));

            migrationBuilder.UpdateData(
                table: "finding_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 77, DateTimeKind.Utc).AddTicks(9699));

            migrationBuilder.UpdateData(
                table: "finding_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 77, DateTimeKind.Utc).AddTicks(9701));

            migrationBuilder.UpdateData(
                table: "finding_types",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 77, DateTimeKind.Utc).AddTicks(9702));

            migrationBuilder.UpdateData(
                table: "platform_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 84, DateTimeKind.Utc).AddTicks(5221));

            migrationBuilder.UpdateData(
                table: "platform_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 84, DateTimeKind.Utc).AddTicks(5223));

            migrationBuilder.UpdateData(
                table: "platform_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 84, DateTimeKind.Utc).AddTicks(5224));

            migrationBuilder.UpdateData(
                table: "project_priorities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 95, DateTimeKind.Utc).AddTicks(2405));

            migrationBuilder.UpdateData(
                table: "project_priorities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 95, DateTimeKind.Utc).AddTicks(2408));

            migrationBuilder.UpdateData(
                table: "project_priorities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 95, DateTimeKind.Utc).AddTicks(2410));

            migrationBuilder.UpdateData(
                table: "project_priorities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 95, DateTimeKind.Utc).AddTicks(2411));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 65, DateTimeKind.Utc).AddTicks(2234));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 65, DateTimeKind.Utc).AddTicks(2237));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 65, DateTimeKind.Utc).AddTicks(2238));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 65, DateTimeKind.Utc).AddTicks(2240));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 65, DateTimeKind.Utc).AddTicks(2242));

            migrationBuilder.UpdateData(
                table: "requirement_complexities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 97, DateTimeKind.Utc).AddTicks(3619));

            migrationBuilder.UpdateData(
                table: "requirement_complexities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 97, DateTimeKind.Utc).AddTicks(3622));

            migrationBuilder.UpdateData(
                table: "requirement_complexities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 97, DateTimeKind.Utc).AddTicks(3623));

            migrationBuilder.UpdateData(
                table: "requirement_complexities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 97, DateTimeKind.Utc).AddTicks(3624));

            migrationBuilder.UpdateData(
                table: "requirement_priorities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 99, DateTimeKind.Utc).AddTicks(9765));

            migrationBuilder.UpdateData(
                table: "requirement_priorities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 99, DateTimeKind.Utc).AddTicks(9767));

            migrationBuilder.UpdateData(
                table: "requirement_priorities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 99, DateTimeKind.Utc).AddTicks(9769));

            migrationBuilder.UpdateData(
                table: "requirement_priorities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 99, DateTimeKind.Utc).AddTicks(9770));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 100, DateTimeKind.Utc).AddTicks(3369));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 100, DateTimeKind.Utc).AddTicks(3372));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 100, DateTimeKind.Utc).AddTicks(3373));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 100, DateTimeKind.Utc).AddTicks(3374));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 100, DateTimeKind.Utc).AddTicks(3375));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 100, DateTimeKind.Utc).AddTicks(3376));

            migrationBuilder.UpdateData(
                table: "requirement_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 101, DateTimeKind.Utc).AddTicks(7961));

            migrationBuilder.UpdateData(
                table: "requirement_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 101, DateTimeKind.Utc).AddTicks(7964));

            migrationBuilder.UpdateData(
                table: "requirement_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 101, DateTimeKind.Utc).AddTicks(7965));

            migrationBuilder.UpdateData(
                table: "requirement_types",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 101, DateTimeKind.Utc).AddTicks(7966));

            migrationBuilder.UpdateData(
                table: "review_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 104, DateTimeKind.Utc).AddTicks(5248));

            migrationBuilder.UpdateData(
                table: "review_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 104, DateTimeKind.Utc).AddTicks(5250));

            migrationBuilder.UpdateData(
                table: "review_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 104, DateTimeKind.Utc).AddTicks(5258));

            migrationBuilder.UpdateData(
                table: "review_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 104, DateTimeKind.Utc).AddTicks(5259));

            migrationBuilder.UpdateData(
                table: "review_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 104, DateTimeKind.Utc).AddTicks(6868));

            migrationBuilder.UpdateData(
                table: "review_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 104, DateTimeKind.Utc).AddTicks(6870));

            migrationBuilder.UpdateData(
                table: "review_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 104, DateTimeKind.Utc).AddTicks(6871));

            migrationBuilder.UpdateData(
                table: "review_types",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 104, DateTimeKind.Utc).AddTicks(6872));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("41544143-4f4c-5347-5f4d-414e41474500"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5894));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("41544143-4f4c-5347-5f56-494557000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5892));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-435f-5245-415445000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5926));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-445f-454c-455445000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5929));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5928));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5924));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f4352454154"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5918));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5550444154"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5919));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f55504c4f41"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5921));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5910));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-4544-4c45-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5888));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-4956-4557-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5876));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-5055-4441-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5886));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-5243-4541-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5878));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-5341-5349-474e5f504552"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5890));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5931));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f43-524541544500"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5898));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f44-454c45544500"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5902));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f55-504441544500"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5900));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5896));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-4544-4c45-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5872));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-4956-4557-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5828));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-5055-4441-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5870));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-5243-4541-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5867));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-5341-5349-474e5f524f4c"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5874));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f4352454154"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5905));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f44454c4554"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5908));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5550444154"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5907));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5903));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4544-454c-5445-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5939));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4956-5745-0000-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5933));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5055-4144-5445-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5937));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5243-4145-5445-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5935));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("41544143-4f4c-5347-5f56-494557000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5970));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5966));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5964));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f4352454154"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5959));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5550444154"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5960));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f55504c4f41"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5962));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5957));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5968));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5944));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5955));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4956-5745-0000-000000000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5972));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5055-4144-5445-000000000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5976));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5243-4145-5445-000000000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5974));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("41544143-4f4c-5347-5f56-494557000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(6027));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(6024));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(6022));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f4352454154"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(6016));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5550444154"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(6018));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f55504c4f41"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(6020));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(6015));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(6025));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f43-524541544500"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5985));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f55-504441544500"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(6006));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5982));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-4956-4557-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(6007));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f4352454154"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(6011));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5550444154"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(6013));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(6009));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4544-454c-5445-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(6040));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4956-5745-0000-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(6029));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5055-4144-5445-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(6038));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5243-4145-5445-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(6036));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(6051));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(6048));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(6053));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(6042));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(6045));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4956-5745-0000-000000000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(6055));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(8675));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(8677));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(8678));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(8679));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 109, DateTimeKind.Utc).AddTicks(4050));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 109, DateTimeKind.Utc).AddTicks(4055));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 109, DateTimeKind.Utc).AddTicks(4056));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 109, DateTimeKind.Utc).AddTicks(4057));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 117, DateTimeKind.Utc).AddTicks(6414));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 117, DateTimeKind.Utc).AddTicks(6419));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 117, DateTimeKind.Utc).AddTicks(6420));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 117, DateTimeKind.Utc).AddTicks(6421));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 117, DateTimeKind.Utc).AddTicks(8930));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 117, DateTimeKind.Utc).AddTicks(8934));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 117, DateTimeKind.Utc).AddTicks(8935));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 117, DateTimeKind.Utc).AddTicks(8936));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 117, DateTimeKind.Utc).AddTicks(8937));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 117, DateTimeKind.Utc).AddTicks(8938));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 117, DateTimeKind.Utc).AddTicks(8939));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 117, DateTimeKind.Utc).AddTicks(8940));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 117, DateTimeKind.Utc).AddTicks(8940));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 117, DateTimeKind.Utc).AddTicks(8941));

            migrationBuilder.UpdateData(
                table: "test_plan_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 65, DateTimeKind.Utc).AddTicks(5930));

            migrationBuilder.UpdateData(
                table: "test_plan_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 65, DateTimeKind.Utc).AddTicks(5932));

            migrationBuilder.UpdateData(
                table: "test_plan_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 65, DateTimeKind.Utc).AddTicks(5933));

            migrationBuilder.UpdateData(
                table: "test_plan_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 65, DateTimeKind.Utc).AddTicks(5934));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 65, DateTimeKind.Utc).AddTicks(9642));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 65, DateTimeKind.Utc).AddTicks(9649));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 65, DateTimeKind.Utc).AddTicks(9650));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 65, DateTimeKind.Utc).AddTicks(9651));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 66, DateTimeKind.Utc).AddTicks(5462));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 66, DateTimeKind.Utc).AddTicks(5465));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 66, DateTimeKind.Utc).AddTicks(5467));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 66, DateTimeKind.Utc).AddTicks(5469));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 66, DateTimeKind.Utc).AddTicks(5471));

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("99999999-9999-9999-9999-999999999999") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 137, DateTimeKind.Utc).AddTicks(4105));
        }
    }
}
