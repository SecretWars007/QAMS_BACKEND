using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QAMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTestClosureApproval : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsClosed",
                table: "test_plans",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "test_plan_approval_logs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TestPlanId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    SignatureHash = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Verdict = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Comments = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_test_plan_approval_logs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_test_plan_approval_logs_test_plans_TestPlanId",
                        column: x => x.TestPlanId,
                        principalTable: "test_plans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_test_plan_approval_logs_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "defect_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 588, DateTimeKind.Utc).AddTicks(7031));

            migrationBuilder.UpdateData(
                table: "defect_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 588, DateTimeKind.Utc).AddTicks(7044));

            migrationBuilder.UpdateData(
                table: "defect_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 588, DateTimeKind.Utc).AddTicks(7045));

            migrationBuilder.UpdateData(
                table: "defect_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 588, DateTimeKind.Utc).AddTicks(7046));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 590, DateTimeKind.Utc).AddTicks(2020));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 590, DateTimeKind.Utc).AddTicks(2040));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 590, DateTimeKind.Utc).AddTicks(2041));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 590, DateTimeKind.Utc).AddTicks(2044));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 5,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 590, DateTimeKind.Utc).AddTicks(2045));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 594, DateTimeKind.Utc).AddTicks(1949));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 594, DateTimeKind.Utc).AddTicks(1954));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 594, DateTimeKind.Utc).AddTicks(1955));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 594, DateTimeKind.Utc).AddTicks(1956));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 594, DateTimeKind.Utc).AddTicks(6594));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 594, DateTimeKind.Utc).AddTicks(6598));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 594, DateTimeKind.Utc).AddTicks(6599));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 594, DateTimeKind.Utc).AddTicks(6600));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 5,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 594, DateTimeKind.Utc).AddTicks(6601));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 6,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 594, DateTimeKind.Utc).AddTicks(6602));

            migrationBuilder.UpdateData(
                table: "finding_severities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 601, DateTimeKind.Utc).AddTicks(7357));

            migrationBuilder.UpdateData(
                table: "finding_severities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 601, DateTimeKind.Utc).AddTicks(7360));

            migrationBuilder.UpdateData(
                table: "finding_severities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 601, DateTimeKind.Utc).AddTicks(7362));

            migrationBuilder.UpdateData(
                table: "finding_severities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 601, DateTimeKind.Utc).AddTicks(7363));

            migrationBuilder.UpdateData(
                table: "finding_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 601, DateTimeKind.Utc).AddTicks(9116));

            migrationBuilder.UpdateData(
                table: "finding_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 601, DateTimeKind.Utc).AddTicks(9120));

            migrationBuilder.UpdateData(
                table: "finding_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 601, DateTimeKind.Utc).AddTicks(9121));

            migrationBuilder.UpdateData(
                table: "finding_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 601, DateTimeKind.Utc).AddTicks(9123));

            migrationBuilder.UpdateData(
                table: "finding_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 602, DateTimeKind.Utc).AddTicks(1479));

            migrationBuilder.UpdateData(
                table: "finding_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 602, DateTimeKind.Utc).AddTicks(1482));

            migrationBuilder.UpdateData(
                table: "finding_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 602, DateTimeKind.Utc).AddTicks(1483));

            migrationBuilder.UpdateData(
                table: "finding_types",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 602, DateTimeKind.Utc).AddTicks(1484));

            migrationBuilder.UpdateData(
                table: "platform_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 609, DateTimeKind.Utc).AddTicks(5470));

            migrationBuilder.UpdateData(
                table: "platform_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 609, DateTimeKind.Utc).AddTicks(5474));

            migrationBuilder.UpdateData(
                table: "platform_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 609, DateTimeKind.Utc).AddTicks(5475));

            migrationBuilder.UpdateData(
                table: "project_priorities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 625, DateTimeKind.Utc).AddTicks(9614));

            migrationBuilder.UpdateData(
                table: "project_priorities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 625, DateTimeKind.Utc).AddTicks(9618));

            migrationBuilder.UpdateData(
                table: "project_priorities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 625, DateTimeKind.Utc).AddTicks(9627));

            migrationBuilder.UpdateData(
                table: "project_priorities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 625, DateTimeKind.Utc).AddTicks(9628));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 581, DateTimeKind.Utc).AddTicks(2908));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 581, DateTimeKind.Utc).AddTicks(2911));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 581, DateTimeKind.Utc).AddTicks(2912));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 581, DateTimeKind.Utc).AddTicks(2914));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 581, DateTimeKind.Utc).AddTicks(2916));

            migrationBuilder.UpdateData(
                table: "requirement_complexities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 628, DateTimeKind.Utc).AddTicks(2459));

            migrationBuilder.UpdateData(
                table: "requirement_complexities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 628, DateTimeKind.Utc).AddTicks(2462));

            migrationBuilder.UpdateData(
                table: "requirement_complexities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 628, DateTimeKind.Utc).AddTicks(2463));

            migrationBuilder.UpdateData(
                table: "requirement_complexities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 628, DateTimeKind.Utc).AddTicks(2464));

            migrationBuilder.UpdateData(
                table: "requirement_priorities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 630, DateTimeKind.Utc).AddTicks(8456));

            migrationBuilder.UpdateData(
                table: "requirement_priorities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 630, DateTimeKind.Utc).AddTicks(8458));

            migrationBuilder.UpdateData(
                table: "requirement_priorities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 630, DateTimeKind.Utc).AddTicks(8459));

            migrationBuilder.UpdateData(
                table: "requirement_priorities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 630, DateTimeKind.Utc).AddTicks(8460));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 631, DateTimeKind.Utc).AddTicks(244));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 631, DateTimeKind.Utc).AddTicks(246));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 631, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 631, DateTimeKind.Utc).AddTicks(248));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 631, DateTimeKind.Utc).AddTicks(249));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 631, DateTimeKind.Utc).AddTicks(254));

            migrationBuilder.UpdateData(
                table: "requirement_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 631, DateTimeKind.Utc).AddTicks(7836));

            migrationBuilder.UpdateData(
                table: "requirement_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 631, DateTimeKind.Utc).AddTicks(7838));

            migrationBuilder.UpdateData(
                table: "requirement_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 631, DateTimeKind.Utc).AddTicks(7844));

            migrationBuilder.UpdateData(
                table: "requirement_types",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 631, DateTimeKind.Utc).AddTicks(7846));

            migrationBuilder.UpdateData(
                table: "review_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 634, DateTimeKind.Utc).AddTicks(5172));

            migrationBuilder.UpdateData(
                table: "review_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 634, DateTimeKind.Utc).AddTicks(5174));

            migrationBuilder.UpdateData(
                table: "review_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 634, DateTimeKind.Utc).AddTicks(5176));

            migrationBuilder.UpdateData(
                table: "review_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 634, DateTimeKind.Utc).AddTicks(5177));

            migrationBuilder.UpdateData(
                table: "review_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 634, DateTimeKind.Utc).AddTicks(7369));

            migrationBuilder.UpdateData(
                table: "review_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 634, DateTimeKind.Utc).AddTicks(7372));

            migrationBuilder.UpdateData(
                table: "review_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 634, DateTimeKind.Utc).AddTicks(7380));

            migrationBuilder.UpdateData(
                table: "review_types",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 634, DateTimeKind.Utc).AddTicks(7382));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("41544143-4f4c-5347-5f4d-414e41474500"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6321));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("41544143-4f4c-5347-5f56-494557000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6319));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-435f-5245-415445000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6351));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-445f-454c-455445000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6354));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6352));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6349));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f4352454154"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6338));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5550444154"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6339));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f55504c4f41"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6341));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6336));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-4544-4c45-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6310));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-4956-4557-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6304));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-5055-4441-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6308));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-5243-4541-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6306));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-5341-5349-474e5f504552"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6312));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6356));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f43-524541544500"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6325));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f44-454c45544500"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6328));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f55-504441544500"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6326));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6323));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-4544-4c45-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6300));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-4956-4557-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6253));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-5055-4441-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6298));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-5243-4541-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6294));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-5341-5349-474e5f524f4c"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6302));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f4352454154"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6331));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f44454c4554"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6335));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5550444154"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6333));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6330));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4544-454c-5445-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6364));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4956-5745-0000-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6357));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5055-4144-5445-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6362));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5243-4145-5445-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6360));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("41544143-4f4c-5347-5f56-494557000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6398));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6394));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6392));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f4352454154"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6381));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5550444154"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6389));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f55504c4f41"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6390));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6379));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6396));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6372));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6377));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4956-5745-0000-000000000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6400));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5055-4144-5445-000000000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6404));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5243-4145-5445-000000000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6402));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("41544143-4f4c-5347-5f56-494557000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6443));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6439));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6437));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f4352454154"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6432));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5550444154"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6434));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f55504c4f41"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6435));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6430));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6441));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f43-524541544500"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6412));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f55-504441544500"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6414));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6410));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-4956-4557-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6416));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f4352454154"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6427));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5550444154"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6429));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6425));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4544-454c-5445-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6456));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4956-5745-0000-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6444));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5055-4144-5445-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6448));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5243-4145-5445-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6446));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6467));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6465));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6464));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6469));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6459));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6461));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4956-5745-0000-000000000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(6471));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(9772));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(9778));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(9780));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 635, DateTimeKind.Utc).AddTicks(9781));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 637, DateTimeKind.Utc).AddTicks(8774));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 637, DateTimeKind.Utc).AddTicks(8777));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 637, DateTimeKind.Utc).AddTicks(8778));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 637, DateTimeKind.Utc).AddTicks(8779));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 644, DateTimeKind.Utc).AddTicks(4663));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 644, DateTimeKind.Utc).AddTicks(4666));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 644, DateTimeKind.Utc).AddTicks(4667));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 644, DateTimeKind.Utc).AddTicks(4668));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 644, DateTimeKind.Utc).AddTicks(6413));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 644, DateTimeKind.Utc).AddTicks(6415));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 644, DateTimeKind.Utc).AddTicks(6416));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 644, DateTimeKind.Utc).AddTicks(6418));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 644, DateTimeKind.Utc).AddTicks(6419));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 644, DateTimeKind.Utc).AddTicks(6420));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 644, DateTimeKind.Utc).AddTicks(6421));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 644, DateTimeKind.Utc).AddTicks(6422));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 644, DateTimeKind.Utc).AddTicks(6422));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 644, DateTimeKind.Utc).AddTicks(6423));

            migrationBuilder.UpdateData(
                table: "test_plan_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 581, DateTimeKind.Utc).AddTicks(7840));

            migrationBuilder.UpdateData(
                table: "test_plan_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 581, DateTimeKind.Utc).AddTicks(7849));

            migrationBuilder.UpdateData(
                table: "test_plan_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 581, DateTimeKind.Utc).AddTicks(7850));

            migrationBuilder.UpdateData(
                table: "test_plan_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 581, DateTimeKind.Utc).AddTicks(7851));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 582, DateTimeKind.Utc).AddTicks(434));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 582, DateTimeKind.Utc).AddTicks(439));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 582, DateTimeKind.Utc).AddTicks(440));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 582, DateTimeKind.Utc).AddTicks(441));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 582, DateTimeKind.Utc).AddTicks(2451));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 582, DateTimeKind.Utc).AddTicks(2453));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 582, DateTimeKind.Utc).AddTicks(2454));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 582, DateTimeKind.Utc).AddTicks(2456));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 582, DateTimeKind.Utc).AddTicks(2457));

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("99999999-9999-9999-9999-999999999999") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 16, 55, 6, 660, DateTimeKind.Utc).AddTicks(8311));

            migrationBuilder.CreateIndex(
                name: "IX_test_plan_approval_logs_TestPlanId",
                table: "test_plan_approval_logs",
                column: "TestPlanId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_test_plan_approval_logs_UserId",
                table: "test_plan_approval_logs",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "test_plan_approval_logs");

            migrationBuilder.DropColumn(
                name: "IsClosed",
                table: "test_plans");

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
        }
    }
}
