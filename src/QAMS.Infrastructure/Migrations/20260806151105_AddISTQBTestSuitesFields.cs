using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QAMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddISTQBTestSuitesFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_test_plan_suites_test_plans_TestPlanId",
                table: "test_plan_suites");

            migrationBuilder.DropForeignKey(
                name: "FK_test_plan_suites_test_suites_TestSuiteId",
                table: "test_plan_suites");

            migrationBuilder.RenameColumn(
                name: "TestSuiteId",
                table: "test_plan_suites",
                newName: "test_suite_id");

            migrationBuilder.RenameColumn(
                name: "TestPlanId",
                table: "test_plan_suites",
                newName: "test_plan_id");

            migrationBuilder.RenameIndex(
                name: "IX_test_plan_suites_TestSuiteId",
                table: "test_plan_suites",
                newName: "IX_test_plan_suites_test_suite_id");

            migrationBuilder.AddColumn<int>(
                name: "automation_status_id",
                table: "test_suites",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "coverage_objective",
                table: "test_suites",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "estimated_duration_hours",
                table: "test_suites",
                type: "numeric(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "execution_priority_id",
                table: "test_suites",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "owner_user_id",
                table: "test_suites",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "preconditions",
                table: "test_suites",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "test_level_id",
                table: "test_suites",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "test_type_id",
                table: "test_suites",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "execution_order",
                table: "test_plan_suites",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "planned_end_date",
                table: "test_plan_suites",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "planned_start_date",
                table: "test_plan_suites",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "responsible_user_id",
                table: "test_plan_suites",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "suite_automation_statuses",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_suite_automation_statuses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tags",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tags", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "test_suite_tags",
                columns: table => new
                {
                    test_suite_id = table.Column<Guid>(type: "uuid", nullable: false),
                    tag_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_test_suite_tags", x => new { x.test_suite_id, x.tag_id });
                    table.ForeignKey(
                        name: "FK_test_suite_tags_tags_tag_id",
                        column: x => x.tag_id,
                        principalTable: "tags",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_test_suite_tags_test_suites_test_suite_id",
                        column: x => x.test_suite_id,
                        principalTable: "test_suites",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "defect_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 382, DateTimeKind.Utc).AddTicks(5146));

            migrationBuilder.UpdateData(
                table: "defect_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 382, DateTimeKind.Utc).AddTicks(5150));

            migrationBuilder.UpdateData(
                table: "defect_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 382, DateTimeKind.Utc).AddTicks(5151));

            migrationBuilder.UpdateData(
                table: "defect_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 382, DateTimeKind.Utc).AddTicks(5152));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 382, DateTimeKind.Utc).AddTicks(9116));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 382, DateTimeKind.Utc).AddTicks(9119));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 382, DateTimeKind.Utc).AddTicks(9120));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 382, DateTimeKind.Utc).AddTicks(9122));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 5,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 382, DateTimeKind.Utc).AddTicks(9123));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 385, DateTimeKind.Utc).AddTicks(6473));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 385, DateTimeKind.Utc).AddTicks(6478));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 385, DateTimeKind.Utc).AddTicks(6479));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 385, DateTimeKind.Utc).AddTicks(6480));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 386, DateTimeKind.Utc).AddTicks(5218));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 386, DateTimeKind.Utc).AddTicks(5223));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 386, DateTimeKind.Utc).AddTicks(5225));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 386, DateTimeKind.Utc).AddTicks(5226));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 5,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 386, DateTimeKind.Utc).AddTicks(5227));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 6,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 386, DateTimeKind.Utc).AddTicks(5228));

            migrationBuilder.UpdateData(
                table: "finding_severities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 393, DateTimeKind.Utc).AddTicks(8982));

            migrationBuilder.UpdateData(
                table: "finding_severities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 393, DateTimeKind.Utc).AddTicks(8987));

            migrationBuilder.UpdateData(
                table: "finding_severities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 393, DateTimeKind.Utc).AddTicks(8989));

            migrationBuilder.UpdateData(
                table: "finding_severities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 393, DateTimeKind.Utc).AddTicks(8990));

            migrationBuilder.UpdateData(
                table: "finding_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 394, DateTimeKind.Utc).AddTicks(5789));

            migrationBuilder.UpdateData(
                table: "finding_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 394, DateTimeKind.Utc).AddTicks(5792));

            migrationBuilder.UpdateData(
                table: "finding_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 394, DateTimeKind.Utc).AddTicks(5794));

            migrationBuilder.UpdateData(
                table: "finding_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 394, DateTimeKind.Utc).AddTicks(5796));

            migrationBuilder.UpdateData(
                table: "finding_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 394, DateTimeKind.Utc).AddTicks(9469));

            migrationBuilder.UpdateData(
                table: "finding_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 394, DateTimeKind.Utc).AddTicks(9472));

            migrationBuilder.UpdateData(
                table: "finding_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 394, DateTimeKind.Utc).AddTicks(9474));

            migrationBuilder.UpdateData(
                table: "finding_types",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 394, DateTimeKind.Utc).AddTicks(9475));

            migrationBuilder.UpdateData(
                table: "platform_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 402, DateTimeKind.Utc).AddTicks(8564));

            migrationBuilder.UpdateData(
                table: "platform_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 402, DateTimeKind.Utc).AddTicks(8567));

            migrationBuilder.UpdateData(
                table: "platform_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 402, DateTimeKind.Utc).AddTicks(8569));

            migrationBuilder.UpdateData(
                table: "project_priorities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 418, DateTimeKind.Utc).AddTicks(7536));

            migrationBuilder.UpdateData(
                table: "project_priorities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 418, DateTimeKind.Utc).AddTicks(7542));

            migrationBuilder.UpdateData(
                table: "project_priorities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 418, DateTimeKind.Utc).AddTicks(7545));

            migrationBuilder.UpdateData(
                table: "project_priorities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 418, DateTimeKind.Utc).AddTicks(7547));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 377, DateTimeKind.Utc).AddTicks(212));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 377, DateTimeKind.Utc).AddTicks(215));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 377, DateTimeKind.Utc).AddTicks(217));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 377, DateTimeKind.Utc).AddTicks(218));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 377, DateTimeKind.Utc).AddTicks(220));

            migrationBuilder.UpdateData(
                table: "requirement_complexities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 423, DateTimeKind.Utc).AddTicks(5107));

            migrationBuilder.UpdateData(
                table: "requirement_complexities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 423, DateTimeKind.Utc).AddTicks(5110));

            migrationBuilder.UpdateData(
                table: "requirement_complexities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 423, DateTimeKind.Utc).AddTicks(5122));

            migrationBuilder.UpdateData(
                table: "requirement_complexities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 423, DateTimeKind.Utc).AddTicks(5123));

            migrationBuilder.UpdateData(
                table: "requirement_priorities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 426, DateTimeKind.Utc).AddTicks(3924));

            migrationBuilder.UpdateData(
                table: "requirement_priorities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 426, DateTimeKind.Utc).AddTicks(3927));

            migrationBuilder.UpdateData(
                table: "requirement_priorities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 426, DateTimeKind.Utc).AddTicks(3928));

            migrationBuilder.UpdateData(
                table: "requirement_priorities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 426, DateTimeKind.Utc).AddTicks(3929));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 426, DateTimeKind.Utc).AddTicks(7432));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 426, DateTimeKind.Utc).AddTicks(7434));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 426, DateTimeKind.Utc).AddTicks(7435));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 426, DateTimeKind.Utc).AddTicks(7437));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 426, DateTimeKind.Utc).AddTicks(7438));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 426, DateTimeKind.Utc).AddTicks(7439));

            migrationBuilder.UpdateData(
                table: "requirement_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 428, DateTimeKind.Utc).AddTicks(2455));

            migrationBuilder.UpdateData(
                table: "requirement_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 428, DateTimeKind.Utc).AddTicks(2462));

            migrationBuilder.UpdateData(
                table: "requirement_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 428, DateTimeKind.Utc).AddTicks(2463));

            migrationBuilder.UpdateData(
                table: "requirement_types",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 428, DateTimeKind.Utc).AddTicks(2464));

            migrationBuilder.UpdateData(
                table: "review_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 432, DateTimeKind.Utc).AddTicks(77));

            migrationBuilder.UpdateData(
                table: "review_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 432, DateTimeKind.Utc).AddTicks(80));

            migrationBuilder.UpdateData(
                table: "review_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 432, DateTimeKind.Utc).AddTicks(81));

            migrationBuilder.UpdateData(
                table: "review_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 432, DateTimeKind.Utc).AddTicks(82));

            migrationBuilder.UpdateData(
                table: "review_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 432, DateTimeKind.Utc).AddTicks(2001));

            migrationBuilder.UpdateData(
                table: "review_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 432, DateTimeKind.Utc).AddTicks(2002));

            migrationBuilder.UpdateData(
                table: "review_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 432, DateTimeKind.Utc).AddTicks(2004));

            migrationBuilder.UpdateData(
                table: "review_types",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 432, DateTimeKind.Utc).AddTicks(2005));

            migrationBuilder.UpdateData(
                table: "risk_levels",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 432, DateTimeKind.Utc).AddTicks(3806));

            migrationBuilder.UpdateData(
                table: "risk_levels",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 432, DateTimeKind.Utc).AddTicks(3808));

            migrationBuilder.UpdateData(
                table: "risk_levels",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 432, DateTimeKind.Utc).AddTicks(3809));

            migrationBuilder.UpdateData(
                table: "risk_levels",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 432, DateTimeKind.Utc).AddTicks(3810));

            migrationBuilder.UpdateData(
                table: "risk_levels",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 432, DateTimeKind.Utc).AddTicks(3816));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("41544143-4f4c-5347-5f4d-414e41474500"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8004));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("41544143-4f4c-5347-5f56-494557000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(7956));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-435f-5245-415445000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8217));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-445f-454c-455445000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8220));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8219));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8215));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f4352454154"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8164));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5550444154"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8165));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f55504c4f41"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8167));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8162));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-4352-454154450000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8170));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-4445-4c4554450000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8173));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-5550-444154450000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8172));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-5649-455700000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8168));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-4544-4c45-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(7953));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-4956-4557-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(7939));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-5055-4441-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(7951));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-5243-4541-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(7948));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-5341-5349-474e5f504552"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(7954));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8222));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564552-5745-5f53-4352-454154450000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8210));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564552-5745-5f53-4445-4c4554450000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8213));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564552-5745-5f53-5550-444154450000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8212));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564552-5745-5f53-5649-455700000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8175));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564e45-4f52-4d4e-454e-54535f435245"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8366));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564e45-4f52-4d4e-454e-54535f44454c"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8373));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564e45-4f52-4d4e-454e-54535f555044"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8371));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564e45-4f52-4d4e-454e-54535f564945"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8364));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f43-524541544500"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8022));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f44-454c45544500"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8025));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f55-504441544500"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8024));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8019));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f43524541"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8347));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f44454c45"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8363));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f55504441"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8361));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f56494557"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8233));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-4544-4c45-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(7793));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-4956-4557-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(7657));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-5055-4441-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(7789));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-5243-4541-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(7785));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-5341-5349-474e5f524f4c"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(7905));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f4352454154"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8157));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f44454c4554"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8160));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5550444154"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8159));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8154));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("55514552-5249-4d45-454e-54535f435245"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8029));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("55514552-5249-4d45-454e-54535f44454c"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8152));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("55514552-5249-4d45-454e-54535f555044"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8145));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("55514552-5249-4d45-454e-54535f564945"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8027));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4544-454c-5445-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8232));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4956-5745-0000-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8223));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5055-4144-5445-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8230));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5243-4145-5445-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8228));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("41544143-4f4c-5347-5f56-494557000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8601));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8597));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8595));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f4352454154"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8483));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5550444154"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8485));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f55504c4f41"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8569));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8481));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-4352-454154450000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8589));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-5550-444154450000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8591));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-5649-455700000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8585));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8599));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564552-5745-5f53-5649-455700000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8593));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564e45-4f52-4d4e-454e-54535f564945"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8636));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8433));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f43524541"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8610));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f55504441"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8634));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f56494557"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8608));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8479));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("55514552-5249-4d45-454e-54535f564945"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8476));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4956-5745-0000-000000000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8603));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5055-4144-5445-000000000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8607));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5243-4145-5445-000000000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8605));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("41544143-4f4c-5347-5f56-494557000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8754));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-435f-5245-415445000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8747));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-445f-454c-455445000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8751));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8749));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8730));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f4352454154"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8712));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5550444154"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8713));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f55504c4f41"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8714));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8710));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-4352-454154450000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8718));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-4445-4c4554450000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8722));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-5550-444154450000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8720));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-5649-455700000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8716));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8752));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564552-5745-5f53-4352-454154450000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8725));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564552-5745-5f53-4445-4c4554450000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8728));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564552-5745-5f53-5550-444154450000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8727));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564552-5745-5f53-5649-455700000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8723));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564e45-4f52-4d4e-454e-54535f435245"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8785));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564e45-4f52-4d4e-454e-54535f44454c"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8788));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564e45-4f52-4d4e-454e-54535f555044"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8787));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564e45-4f52-4d4e-454e-54535f564945"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8783));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f43-524541544500"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8669));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f44-454c45544500"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8673));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f55-504441544500"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8671));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8666));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f43524541"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8767));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f44454c45"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8782));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f55504441"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8780));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f56494557"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8765));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-4956-4557-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8674));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f4352454154"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8689));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f44454c4554"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8708));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5550444154"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8690));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8687));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("55514552-5249-4d45-454e-54535f435245"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8683));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("55514552-5249-4d45-454e-54535f44454c"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8686));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("55514552-5249-4d45-454e-54535f555044"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8684));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("55514552-5249-4d45-454e-54535f564945"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8676));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4544-454c-5445-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8764));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4956-5745-0000-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8756));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5055-4144-5445-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8762));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5243-4145-5445-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8760));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8834));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8806));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8797));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-4352-454154450000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8800));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-5550-444154450000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8802));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-5649-455700000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8799));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8837));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564552-5745-5f53-5649-455700000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8804));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564e45-4f52-4d4e-454e-54535f564945"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8840));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8791));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f56494557"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8842));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8795));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("55514552-5249-4d45-454e-54535f564945"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8793));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4956-5745-0000-000000000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 433, DateTimeKind.Utc).AddTicks(8838));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 435, DateTimeKind.Utc).AddTicks(143));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 435, DateTimeKind.Utc).AddTicks(151));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 435, DateTimeKind.Utc).AddTicks(153));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 435, DateTimeKind.Utc).AddTicks(154));

            migrationBuilder.InsertData(
                table: "suite_automation_statuses",
                columns: new[] { "id", "code", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "description", "IsActive", "IsDeleted", "name", "SortOrder", "UpdatedAt", "UpdatedByUserId" },
                values: new object[,]
                {
                    { 1, "MANUAL", new DateTime(2026, 8, 6, 15, 11, 2, 377, DateTimeKind.Utc).AddTicks(2609), null, null, null, "Ejecución totalmente manual", true, false, "MANUAL", 0, null, null },
                    { 2, "PARTIAL", new DateTime(2026, 8, 6, 15, 11, 2, 377, DateTimeKind.Utc).AddTicks(2612), null, null, null, "Ejecución con soporte de scripts/herramientas", true, false, "PARCIALMENTE AUTOMATIZADA", 0, null, null },
                    { 3, "AUTOMATED", new DateTime(2026, 8, 6, 15, 11, 2, 377, DateTimeKind.Utc).AddTicks(2613), null, null, null, "Ejecución desatendida vía pipeline", true, false, "TOTALMENTE AUTOMATIZADA", 0, null, null }
                });

            migrationBuilder.InsertData(
                table: "tags",
                columns: new[] { "id", "code", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "description", "IsActive", "IsDeleted", "name", "SortOrder", "UpdatedAt", "UpdatedByUserId" },
                values: new object[,]
                {
                    { 1, "SMOKE", new DateTime(2026, 8, 6, 15, 11, 2, 377, DateTimeKind.Utc).AddTicks(4403), null, null, null, "Prueba de humo básica", true, false, "Smoke Test", 0, null, null },
                    { 2, "REGRESSION", new DateTime(2026, 8, 6, 15, 11, 2, 377, DateTimeKind.Utc).AddTicks(4405), null, null, null, "Pruebas de regresión completa", true, false, "Regresión", 0, null, null },
                    { 3, "SANITY", new DateTime(2026, 8, 6, 15, 11, 2, 377, DateTimeKind.Utc).AddTicks(4406), null, null, null, "Prueba de sanidad tras un bug fix", true, false, "Sanity Test", 0, null, null },
                    { 4, "RELEASE", new DateTime(2026, 8, 6, 15, 11, 2, 377, DateTimeKind.Utc).AddTicks(4407), null, null, null, "Pruebas obligatorias para paso a prod", true, false, "Release Readiness", 0, null, null },
                    { 5, "PERFORMANCE", new DateTime(2026, 8, 6, 15, 11, 2, 377, DateTimeKind.Utc).AddTicks(4408), null, null, null, "Relacionado con rendimiento", true, false, "Performance", 0, null, null },
                    { 6, "SECURITY", new DateTime(2026, 8, 6, 15, 11, 2, 377, DateTimeKind.Utc).AddTicks(4409), null, null, null, "Pruebas de seguridad", true, false, "Seguridad", 0, null, null }
                });

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 437, DateTimeKind.Utc).AddTicks(9230));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 437, DateTimeKind.Utc).AddTicks(9234));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 437, DateTimeKind.Utc).AddTicks(9235));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 437, DateTimeKind.Utc).AddTicks(9237));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 447, DateTimeKind.Utc).AddTicks(9900));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 447, DateTimeKind.Utc).AddTicks(9922));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 447, DateTimeKind.Utc).AddTicks(9924));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 447, DateTimeKind.Utc).AddTicks(9925));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 448, DateTimeKind.Utc).AddTicks(5135));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 448, DateTimeKind.Utc).AddTicks(5140));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 448, DateTimeKind.Utc).AddTicks(5141));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 448, DateTimeKind.Utc).AddTicks(5142));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 448, DateTimeKind.Utc).AddTicks(5143));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 448, DateTimeKind.Utc).AddTicks(5144));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 448, DateTimeKind.Utc).AddTicks(5145));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 448, DateTimeKind.Utc).AddTicks(5146));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 448, DateTimeKind.Utc).AddTicks(5147));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 448, DateTimeKind.Utc).AddTicks(5148));

            migrationBuilder.UpdateData(
                table: "test_levels",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 461, DateTimeKind.Utc).AddTicks(1999));

            migrationBuilder.UpdateData(
                table: "test_levels",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 461, DateTimeKind.Utc).AddTicks(2002));

            migrationBuilder.UpdateData(
                table: "test_levels",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 461, DateTimeKind.Utc).AddTicks(2003));

            migrationBuilder.UpdateData(
                table: "test_levels",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 461, DateTimeKind.Utc).AddTicks(2004));

            migrationBuilder.UpdateData(
                table: "test_levels",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 461, DateTimeKind.Utc).AddTicks(2005));

            migrationBuilder.UpdateData(
                table: "test_plan_environments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 467, DateTimeKind.Utc).AddTicks(3490));

            migrationBuilder.UpdateData(
                table: "test_plan_environments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 467, DateTimeKind.Utc).AddTicks(3493));

            migrationBuilder.UpdateData(
                table: "test_plan_environments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 467, DateTimeKind.Utc).AddTicks(3494));

            migrationBuilder.UpdateData(
                table: "test_plan_environments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 467, DateTimeKind.Utc).AddTicks(3495));

            migrationBuilder.UpdateData(
                table: "test_plan_environments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 467, DateTimeKind.Utc).AddTicks(3496));

            migrationBuilder.UpdateData(
                table: "test_plan_environments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 467, DateTimeKind.Utc).AddTicks(3497));

            migrationBuilder.UpdateData(
                table: "test_plan_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 377, DateTimeKind.Utc).AddTicks(5970));

            migrationBuilder.UpdateData(
                table: "test_plan_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 377, DateTimeKind.Utc).AddTicks(5973));

            migrationBuilder.UpdateData(
                table: "test_plan_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 377, DateTimeKind.Utc).AddTicks(5974));

            migrationBuilder.UpdateData(
                table: "test_plan_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 377, DateTimeKind.Utc).AddTicks(5975));

            migrationBuilder.UpdateData(
                table: "test_plan_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 471, DateTimeKind.Utc).AddTicks(1311));

            migrationBuilder.UpdateData(
                table: "test_plan_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 471, DateTimeKind.Utc).AddTicks(1314));

            migrationBuilder.UpdateData(
                table: "test_plan_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 471, DateTimeKind.Utc).AddTicks(1316));

            migrationBuilder.UpdateData(
                table: "test_strategies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 472, DateTimeKind.Utc).AddTicks(3748));

            migrationBuilder.UpdateData(
                table: "test_strategies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 472, DateTimeKind.Utc).AddTicks(3750));

            migrationBuilder.UpdateData(
                table: "test_strategies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 472, DateTimeKind.Utc).AddTicks(3751));

            migrationBuilder.UpdateData(
                table: "test_strategies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 472, DateTimeKind.Utc).AddTicks(3752));

            migrationBuilder.UpdateData(
                table: "test_strategies",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 472, DateTimeKind.Utc).AddTicks(3753));

            migrationBuilder.UpdateData(
                table: "test_strategies",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 472, DateTimeKind.Utc).AddTicks(3754));

            migrationBuilder.UpdateData(
                table: "test_strategies",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 472, DateTimeKind.Utc).AddTicks(3755));

            migrationBuilder.UpdateData(
                table: "test_strategies",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 472, DateTimeKind.Utc).AddTicks(3756));

            migrationBuilder.UpdateData(
                table: "test_strategies",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 472, DateTimeKind.Utc).AddTicks(3757));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 377, DateTimeKind.Utc).AddTicks(7603));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 377, DateTimeKind.Utc).AddTicks(7605));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 377, DateTimeKind.Utc).AddTicks(7612));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 377, DateTimeKind.Utc).AddTicks(7618));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 377, DateTimeKind.Utc).AddTicks(9308));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 377, DateTimeKind.Utc).AddTicks(9310));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 377, DateTimeKind.Utc).AddTicks(9312));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 377, DateTimeKind.Utc).AddTicks(9314));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 377, DateTimeKind.Utc).AddTicks(9323));

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("22222222-2222-2222-2222-222222222222"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 503, DateTimeKind.Utc).AddTicks(2519));

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("22222222-2222-2222-2222-222222222222"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 503, DateTimeKind.Utc).AddTicks(2527));

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("44444444-4444-4444-4444-444444444444"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 503, DateTimeKind.Utc).AddTicks(2529));

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("44444444-4444-4444-4444-444444444444"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 503, DateTimeKind.Utc).AddTicks(2531));

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("99999999-9999-9999-9999-999999999999") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 15, 11, 2, 503, DateTimeKind.Utc).AddTicks(1527));

            migrationBuilder.CreateIndex(
                name: "IX_test_suites_automation_status_id",
                table: "test_suites",
                column: "automation_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_test_suites_execution_priority_id",
                table: "test_suites",
                column: "execution_priority_id");

            migrationBuilder.CreateIndex(
                name: "IX_test_suites_owner_user_id",
                table: "test_suites",
                column: "owner_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_test_suites_test_level_id",
                table: "test_suites",
                column: "test_level_id");

            migrationBuilder.CreateIndex(
                name: "IX_test_suites_test_type_id",
                table: "test_suites",
                column: "test_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_test_plan_suites_responsible_user_id",
                table: "test_plan_suites",
                column: "responsible_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_test_suite_tags_tag_id",
                table: "test_suite_tags",
                column: "tag_id");

            migrationBuilder.AddForeignKey(
                name: "FK_test_plan_suites_test_plans_test_plan_id",
                table: "test_plan_suites",
                column: "test_plan_id",
                principalTable: "test_plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_test_plan_suites_test_suites_test_suite_id",
                table: "test_plan_suites",
                column: "test_suite_id",
                principalTable: "test_suites",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_test_plan_suites_users_responsible_user_id",
                table: "test_plan_suites",
                column: "responsible_user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_test_suites_suite_automation_statuses_automation_status_id",
                table: "test_suites",
                column: "automation_status_id",
                principalTable: "suite_automation_statuses",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_test_suites_test_case_priorities_execution_priority_id",
                table: "test_suites",
                column: "execution_priority_id",
                principalTable: "test_case_priorities",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_test_suites_test_levels_test_level_id",
                table: "test_suites",
                column: "test_level_id",
                principalTable: "test_levels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_test_suites_test_types_test_type_id",
                table: "test_suites",
                column: "test_type_id",
                principalTable: "test_types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_test_suites_users_owner_user_id",
                table: "test_suites",
                column: "owner_user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_test_plan_suites_test_plans_test_plan_id",
                table: "test_plan_suites");

            migrationBuilder.DropForeignKey(
                name: "FK_test_plan_suites_test_suites_test_suite_id",
                table: "test_plan_suites");

            migrationBuilder.DropForeignKey(
                name: "FK_test_plan_suites_users_responsible_user_id",
                table: "test_plan_suites");

            migrationBuilder.DropForeignKey(
                name: "FK_test_suites_suite_automation_statuses_automation_status_id",
                table: "test_suites");

            migrationBuilder.DropForeignKey(
                name: "FK_test_suites_test_case_priorities_execution_priority_id",
                table: "test_suites");

            migrationBuilder.DropForeignKey(
                name: "FK_test_suites_test_levels_test_level_id",
                table: "test_suites");

            migrationBuilder.DropForeignKey(
                name: "FK_test_suites_test_types_test_type_id",
                table: "test_suites");

            migrationBuilder.DropForeignKey(
                name: "FK_test_suites_users_owner_user_id",
                table: "test_suites");

            migrationBuilder.DropTable(
                name: "suite_automation_statuses");

            migrationBuilder.DropTable(
                name: "test_suite_tags");

            migrationBuilder.DropTable(
                name: "tags");

            migrationBuilder.DropIndex(
                name: "IX_test_suites_automation_status_id",
                table: "test_suites");

            migrationBuilder.DropIndex(
                name: "IX_test_suites_execution_priority_id",
                table: "test_suites");

            migrationBuilder.DropIndex(
                name: "IX_test_suites_owner_user_id",
                table: "test_suites");

            migrationBuilder.DropIndex(
                name: "IX_test_suites_test_level_id",
                table: "test_suites");

            migrationBuilder.DropIndex(
                name: "IX_test_suites_test_type_id",
                table: "test_suites");

            migrationBuilder.DropIndex(
                name: "IX_test_plan_suites_responsible_user_id",
                table: "test_plan_suites");

            migrationBuilder.DropColumn(
                name: "automation_status_id",
                table: "test_suites");

            migrationBuilder.DropColumn(
                name: "coverage_objective",
                table: "test_suites");

            migrationBuilder.DropColumn(
                name: "estimated_duration_hours",
                table: "test_suites");

            migrationBuilder.DropColumn(
                name: "execution_priority_id",
                table: "test_suites");

            migrationBuilder.DropColumn(
                name: "owner_user_id",
                table: "test_suites");

            migrationBuilder.DropColumn(
                name: "preconditions",
                table: "test_suites");

            migrationBuilder.DropColumn(
                name: "test_level_id",
                table: "test_suites");

            migrationBuilder.DropColumn(
                name: "test_type_id",
                table: "test_suites");

            migrationBuilder.DropColumn(
                name: "execution_order",
                table: "test_plan_suites");

            migrationBuilder.DropColumn(
                name: "planned_end_date",
                table: "test_plan_suites");

            migrationBuilder.DropColumn(
                name: "planned_start_date",
                table: "test_plan_suites");

            migrationBuilder.DropColumn(
                name: "responsible_user_id",
                table: "test_plan_suites");

            migrationBuilder.RenameColumn(
                name: "test_suite_id",
                table: "test_plan_suites",
                newName: "TestSuiteId");

            migrationBuilder.RenameColumn(
                name: "test_plan_id",
                table: "test_plan_suites",
                newName: "TestPlanId");

            migrationBuilder.RenameIndex(
                name: "IX_test_plan_suites_test_suite_id",
                table: "test_plan_suites",
                newName: "IX_test_plan_suites_TestSuiteId");

            migrationBuilder.UpdateData(
                table: "defect_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 302, DateTimeKind.Utc).AddTicks(2724));

            migrationBuilder.UpdateData(
                table: "defect_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 302, DateTimeKind.Utc).AddTicks(2729));

            migrationBuilder.UpdateData(
                table: "defect_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 302, DateTimeKind.Utc).AddTicks(2731));

            migrationBuilder.UpdateData(
                table: "defect_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 302, DateTimeKind.Utc).AddTicks(2732));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 302, DateTimeKind.Utc).AddTicks(8297));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 302, DateTimeKind.Utc).AddTicks(8302));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 302, DateTimeKind.Utc).AddTicks(8303));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 302, DateTimeKind.Utc).AddTicks(8305));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 5,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 302, DateTimeKind.Utc).AddTicks(8306));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 306, DateTimeKind.Utc).AddTicks(3481));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 306, DateTimeKind.Utc).AddTicks(3484));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 306, DateTimeKind.Utc).AddTicks(3486));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 306, DateTimeKind.Utc).AddTicks(3487));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 306, DateTimeKind.Utc).AddTicks(6735));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 306, DateTimeKind.Utc).AddTicks(6738));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 306, DateTimeKind.Utc).AddTicks(6740));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 306, DateTimeKind.Utc).AddTicks(6741));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 5,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 306, DateTimeKind.Utc).AddTicks(6742));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 6,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 306, DateTimeKind.Utc).AddTicks(6743));

            migrationBuilder.UpdateData(
                table: "finding_severities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 312, DateTimeKind.Utc).AddTicks(5562));

            migrationBuilder.UpdateData(
                table: "finding_severities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 312, DateTimeKind.Utc).AddTicks(5567));

            migrationBuilder.UpdateData(
                table: "finding_severities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 312, DateTimeKind.Utc).AddTicks(5568));

            migrationBuilder.UpdateData(
                table: "finding_severities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 312, DateTimeKind.Utc).AddTicks(5569));

            migrationBuilder.UpdateData(
                table: "finding_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 312, DateTimeKind.Utc).AddTicks(8472));

            migrationBuilder.UpdateData(
                table: "finding_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 312, DateTimeKind.Utc).AddTicks(8476));

            migrationBuilder.UpdateData(
                table: "finding_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 312, DateTimeKind.Utc).AddTicks(8478));

            migrationBuilder.UpdateData(
                table: "finding_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 312, DateTimeKind.Utc).AddTicks(8479));

            migrationBuilder.UpdateData(
                table: "finding_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 313, DateTimeKind.Utc).AddTicks(1232));

            migrationBuilder.UpdateData(
                table: "finding_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 313, DateTimeKind.Utc).AddTicks(1236));

            migrationBuilder.UpdateData(
                table: "finding_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 313, DateTimeKind.Utc).AddTicks(1237));

            migrationBuilder.UpdateData(
                table: "finding_types",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 313, DateTimeKind.Utc).AddTicks(1238));

            migrationBuilder.UpdateData(
                table: "platform_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 320, DateTimeKind.Utc).AddTicks(192));

            migrationBuilder.UpdateData(
                table: "platform_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 320, DateTimeKind.Utc).AddTicks(197));

            migrationBuilder.UpdateData(
                table: "platform_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 320, DateTimeKind.Utc).AddTicks(198));

            migrationBuilder.UpdateData(
                table: "project_priorities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 336, DateTimeKind.Utc).AddTicks(5582));

            migrationBuilder.UpdateData(
                table: "project_priorities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 336, DateTimeKind.Utc).AddTicks(5589));

            migrationBuilder.UpdateData(
                table: "project_priorities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 336, DateTimeKind.Utc).AddTicks(5590));

            migrationBuilder.UpdateData(
                table: "project_priorities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 336, DateTimeKind.Utc).AddTicks(5591));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 298, DateTimeKind.Utc).AddTicks(7514));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 298, DateTimeKind.Utc).AddTicks(7516));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 298, DateTimeKind.Utc).AddTicks(7518));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 298, DateTimeKind.Utc).AddTicks(7519));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 298, DateTimeKind.Utc).AddTicks(7521));

            migrationBuilder.UpdateData(
                table: "requirement_complexities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 339, DateTimeKind.Utc).AddTicks(5931));

            migrationBuilder.UpdateData(
                table: "requirement_complexities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 339, DateTimeKind.Utc).AddTicks(5935));

            migrationBuilder.UpdateData(
                table: "requirement_complexities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 339, DateTimeKind.Utc).AddTicks(5937));

            migrationBuilder.UpdateData(
                table: "requirement_complexities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 339, DateTimeKind.Utc).AddTicks(5938));

            migrationBuilder.UpdateData(
                table: "requirement_priorities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 344, DateTimeKind.Utc).AddTicks(3818));

            migrationBuilder.UpdateData(
                table: "requirement_priorities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 344, DateTimeKind.Utc).AddTicks(3824));

            migrationBuilder.UpdateData(
                table: "requirement_priorities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 344, DateTimeKind.Utc).AddTicks(3826));

            migrationBuilder.UpdateData(
                table: "requirement_priorities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 344, DateTimeKind.Utc).AddTicks(3827));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 345, DateTimeKind.Utc).AddTicks(1646));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 345, DateTimeKind.Utc).AddTicks(1676));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 345, DateTimeKind.Utc).AddTicks(1678));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 345, DateTimeKind.Utc).AddTicks(1680));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 345, DateTimeKind.Utc).AddTicks(1682));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 345, DateTimeKind.Utc).AddTicks(1683));

            migrationBuilder.UpdateData(
                table: "requirement_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 347, DateTimeKind.Utc).AddTicks(5468));

            migrationBuilder.UpdateData(
                table: "requirement_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 347, DateTimeKind.Utc).AddTicks(5471));

            migrationBuilder.UpdateData(
                table: "requirement_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 347, DateTimeKind.Utc).AddTicks(5473));

            migrationBuilder.UpdateData(
                table: "requirement_types",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 347, DateTimeKind.Utc).AddTicks(5474));

            migrationBuilder.UpdateData(
                table: "review_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 354, DateTimeKind.Utc).AddTicks(1988));

            migrationBuilder.UpdateData(
                table: "review_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 354, DateTimeKind.Utc).AddTicks(1992));

            migrationBuilder.UpdateData(
                table: "review_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 354, DateTimeKind.Utc).AddTicks(1993));

            migrationBuilder.UpdateData(
                table: "review_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 354, DateTimeKind.Utc).AddTicks(1994));

            migrationBuilder.UpdateData(
                table: "review_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 354, DateTimeKind.Utc).AddTicks(4402));

            migrationBuilder.UpdateData(
                table: "review_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 354, DateTimeKind.Utc).AddTicks(4405));

            migrationBuilder.UpdateData(
                table: "review_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 354, DateTimeKind.Utc).AddTicks(4407));

            migrationBuilder.UpdateData(
                table: "review_types",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 354, DateTimeKind.Utc).AddTicks(4408));

            migrationBuilder.UpdateData(
                table: "risk_levels",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 354, DateTimeKind.Utc).AddTicks(8337));

            migrationBuilder.UpdateData(
                table: "risk_levels",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 354, DateTimeKind.Utc).AddTicks(8345));

            migrationBuilder.UpdateData(
                table: "risk_levels",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 354, DateTimeKind.Utc).AddTicks(8346));

            migrationBuilder.UpdateData(
                table: "risk_levels",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 354, DateTimeKind.Utc).AddTicks(8347));

            migrationBuilder.UpdateData(
                table: "risk_levels",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 354, DateTimeKind.Utc).AddTicks(8348));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("41544143-4f4c-5347-5f4d-414e41474500"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6457));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("41544143-4f4c-5347-5f56-494557000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6455));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-435f-5245-415445000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6524));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-445f-454c-455445000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6528));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6525));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6522));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f4352454154"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6496));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5550444154"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6497));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f55504c4f41"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6499));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6494));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-4352-454154450000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6502));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-4445-4c4554450000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6506));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-5550-444154450000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6504));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-5649-455700000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6500));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-4544-4c45-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6452));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-4956-4557-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6433));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-5055-4441-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6438));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-5243-4541-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6435));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-5341-5349-474e5f504552"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6453));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6530));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564552-5745-5f53-4352-454154450000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6508));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564552-5745-5f53-4445-4c4554450000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6512));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564552-5745-5f53-5550-444154450000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6510));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564552-5745-5f53-5649-455700000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6507));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564e45-4f52-4d4e-454e-54535f435245"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6552));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564e45-4f52-4d4e-454e-54535f44454c"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6556));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564e45-4f52-4d4e-454e-54535f555044"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6554));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564e45-4f52-4d4e-454e-54535f564945"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6544));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f43-524541544500"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6461));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f44-454c45544500"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6463));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f55-504441544500"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6462));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6459));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f43524541"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6540));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f44454c45"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6543));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f55504441"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6542));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f56494557"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6539));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-4544-4c45-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6429));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-4956-4557-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6349));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-5055-4441-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6427));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-5243-4541-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6425));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-5341-5349-474e5f524f4c"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6431));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f4352454154"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6473));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f44454c4554"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6493));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5550444154"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6491));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6471));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("55514552-5249-4d45-454e-54535f435245"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6467));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("55514552-5249-4d45-454e-54535f44454c"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6470));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("55514552-5249-4d45-454e-54535f555044"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6468));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("55514552-5249-4d45-454e-54535f564945"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6465));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4544-454c-5445-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6537));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4956-5745-0000-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6532));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5055-4144-5445-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6535));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5243-4145-5445-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6534));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("41544143-4f4c-5347-5f56-494557000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6632));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6628));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6626));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f4352454154"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6602));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5550444154"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6604));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f55504c4f41"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6606));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6600));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-4352-454154450000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6609));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-5550-444154450000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6611));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-5649-455700000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6607));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6631));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564552-5745-5f53-5649-455700000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6625));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564e45-4f52-4d4e-454e-54535f564945"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6645));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6580));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f43524541"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6641));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f55504441"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6643));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f56494557"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6640));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6598));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("55514552-5249-4d45-454e-54535f564945"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6595));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4956-5745-0000-000000000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6634));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5055-4144-5445-000000000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6638));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5243-4145-5445-000000000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6636));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("41544143-4f4c-5347-5f56-494557000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6736));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-435f-5245-415445000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6722));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-445f-454c-455445000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6725));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6724));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6720));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f4352454154"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6693));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5550444154"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6694));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f55504c4f41"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6703));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6691));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-4352-454154450000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6707));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-4445-4c4554450000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6711));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-5550-444154450000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6709));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-5649-455700000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6705));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6727));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564552-5745-5f53-4352-454154450000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6714));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564552-5745-5f53-4445-4c4554450000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6718));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564552-5745-5f53-5550-444154450000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6716));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564552-5745-5f53-5649-455700000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6713));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564e45-4f52-4d4e-454e-54535f435245"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6756));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564e45-4f52-4d4e-454e-54535f44454c"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6770));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564e45-4f52-4d4e-454e-54535f555044"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6769));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564e45-4f52-4d4e-454e-54535f564945"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6754));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f43-524541544500"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6657));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f44-454c45544500"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6674));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f55-504441544500"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6672));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6654));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f43524541"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6749));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f44454c45"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6752));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f55504441"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6751));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f56494557"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6747));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-4956-4557-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6676));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f4352454154"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6686));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f44454c4554"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6689));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5550444154"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6688));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6684));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("55514552-5249-4d45-454e-54535f435245"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6679));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("55514552-5249-4d45-454e-54535f44454c"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6683));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("55514552-5249-4d45-454e-54535f555044"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6681));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("55514552-5249-4d45-454e-54535f564945"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6678));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4544-454c-5445-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6745));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4956-5745-0000-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6738));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5055-4144-5445-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6743));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5243-4145-5445-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6741));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6791));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6788));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6779));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-4352-454154450000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6783));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-5550-444154450000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6785));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-5649-455700000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6781));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6793));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564552-5745-5f53-5649-455700000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6787));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564e45-4f52-4d4e-454e-54535f564945"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6802));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6773));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f56494557"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6804));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6777));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("55514552-5249-4d45-454e-54535f564945"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6775));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4956-5745-0000-000000000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 356, DateTimeKind.Utc).AddTicks(6794));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 357, DateTimeKind.Utc).AddTicks(1467));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 357, DateTimeKind.Utc).AddTicks(1473));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 357, DateTimeKind.Utc).AddTicks(1474));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 357, DateTimeKind.Utc).AddTicks(1475));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 359, DateTimeKind.Utc).AddTicks(8190));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 359, DateTimeKind.Utc).AddTicks(8195));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 359, DateTimeKind.Utc).AddTicks(8196));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 359, DateTimeKind.Utc).AddTicks(8198));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 373, DateTimeKind.Utc).AddTicks(2015));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 373, DateTimeKind.Utc).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 373, DateTimeKind.Utc).AddTicks(2023));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 373, DateTimeKind.Utc).AddTicks(2024));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 373, DateTimeKind.Utc).AddTicks(7324));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 373, DateTimeKind.Utc).AddTicks(7328));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 373, DateTimeKind.Utc).AddTicks(7329));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 373, DateTimeKind.Utc).AddTicks(7330));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 373, DateTimeKind.Utc).AddTicks(7331));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 373, DateTimeKind.Utc).AddTicks(7332));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 373, DateTimeKind.Utc).AddTicks(7333));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 373, DateTimeKind.Utc).AddTicks(7334));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 373, DateTimeKind.Utc).AddTicks(7335));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 373, DateTimeKind.Utc).AddTicks(7336));

            migrationBuilder.UpdateData(
                table: "test_levels",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 383, DateTimeKind.Utc).AddTicks(2179));

            migrationBuilder.UpdateData(
                table: "test_levels",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 383, DateTimeKind.Utc).AddTicks(2184));

            migrationBuilder.UpdateData(
                table: "test_levels",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 383, DateTimeKind.Utc).AddTicks(2185));

            migrationBuilder.UpdateData(
                table: "test_levels",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 383, DateTimeKind.Utc).AddTicks(2186));

            migrationBuilder.UpdateData(
                table: "test_levels",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 383, DateTimeKind.Utc).AddTicks(2187));

            migrationBuilder.UpdateData(
                table: "test_plan_environments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 388, DateTimeKind.Utc).AddTicks(2940));

            migrationBuilder.UpdateData(
                table: "test_plan_environments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 388, DateTimeKind.Utc).AddTicks(2947));

            migrationBuilder.UpdateData(
                table: "test_plan_environments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 388, DateTimeKind.Utc).AddTicks(2948));

            migrationBuilder.UpdateData(
                table: "test_plan_environments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 388, DateTimeKind.Utc).AddTicks(2949));

            migrationBuilder.UpdateData(
                table: "test_plan_environments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 388, DateTimeKind.Utc).AddTicks(2950));

            migrationBuilder.UpdateData(
                table: "test_plan_environments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 388, DateTimeKind.Utc).AddTicks(2951));

            migrationBuilder.UpdateData(
                table: "test_plan_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 298, DateTimeKind.Utc).AddTicks(9918));

            migrationBuilder.UpdateData(
                table: "test_plan_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 298, DateTimeKind.Utc).AddTicks(9920));

            migrationBuilder.UpdateData(
                table: "test_plan_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 298, DateTimeKind.Utc).AddTicks(9922));

            migrationBuilder.UpdateData(
                table: "test_plan_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 298, DateTimeKind.Utc).AddTicks(9923));

            migrationBuilder.UpdateData(
                table: "test_plan_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 389, DateTimeKind.Utc).AddTicks(7671));

            migrationBuilder.UpdateData(
                table: "test_plan_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 389, DateTimeKind.Utc).AddTicks(7675));

            migrationBuilder.UpdateData(
                table: "test_plan_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 389, DateTimeKind.Utc).AddTicks(7676));

            migrationBuilder.UpdateData(
                table: "test_strategies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 391, DateTimeKind.Utc).AddTicks(2938));

            migrationBuilder.UpdateData(
                table: "test_strategies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 391, DateTimeKind.Utc).AddTicks(2944));

            migrationBuilder.UpdateData(
                table: "test_strategies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 391, DateTimeKind.Utc).AddTicks(2946));

            migrationBuilder.UpdateData(
                table: "test_strategies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 391, DateTimeKind.Utc).AddTicks(2948));

            migrationBuilder.UpdateData(
                table: "test_strategies",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 391, DateTimeKind.Utc).AddTicks(2950));

            migrationBuilder.UpdateData(
                table: "test_strategies",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 391, DateTimeKind.Utc).AddTicks(2951));

            migrationBuilder.UpdateData(
                table: "test_strategies",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 391, DateTimeKind.Utc).AddTicks(2952));

            migrationBuilder.UpdateData(
                table: "test_strategies",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 391, DateTimeKind.Utc).AddTicks(2961));

            migrationBuilder.UpdateData(
                table: "test_strategies",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 391, DateTimeKind.Utc).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 299, DateTimeKind.Utc).AddTicks(1680));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 299, DateTimeKind.Utc).AddTicks(1683));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 299, DateTimeKind.Utc).AddTicks(1684));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 299, DateTimeKind.Utc).AddTicks(1685));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 299, DateTimeKind.Utc).AddTicks(3112));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 299, DateTimeKind.Utc).AddTicks(3114));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 299, DateTimeKind.Utc).AddTicks(3116));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 299, DateTimeKind.Utc).AddTicks(3118));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 299, DateTimeKind.Utc).AddTicks(3119));

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("22222222-2222-2222-2222-222222222222"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 403, DateTimeKind.Utc).AddTicks(9334));

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("22222222-2222-2222-2222-222222222222"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 403, DateTimeKind.Utc).AddTicks(9337));

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("44444444-4444-4444-4444-444444444444"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 403, DateTimeKind.Utc).AddTicks(9339));

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("44444444-4444-4444-4444-444444444444"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 403, DateTimeKind.Utc).AddTicks(9340));

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("99999999-9999-9999-9999-999999999999") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 14, 35, 29, 403, DateTimeKind.Utc).AddTicks(9319));

            migrationBuilder.AddForeignKey(
                name: "FK_test_plan_suites_test_plans_TestPlanId",
                table: "test_plan_suites",
                column: "TestPlanId",
                principalTable: "test_plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_test_plan_suites_test_suites_TestSuiteId",
                table: "test_plan_suites",
                column: "TestSuiteId",
                principalTable: "test_suites",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
