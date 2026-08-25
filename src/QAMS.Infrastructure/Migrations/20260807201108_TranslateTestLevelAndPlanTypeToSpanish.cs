using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QAMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TranslateTestLevelAndPlanTypeToSpanish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
// migrationBuilder.AddColumn<string>(
//     name: "attachment_file_name",
//     table: "defects",
//     type: "character varying(300)",
//     maxLength: 300,
//     nullable: true);

// migrationBuilder.AddColumn<string>(
//     name: "attachment_url",
//     table: "defects",
//     type: "character varying(1000)",
//     maxLength: 1000,
//     nullable: true);

            migrationBuilder.UpdateData(
                table: "defect_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 74, DateTimeKind.Utc).AddTicks(1288));

            migrationBuilder.UpdateData(
                table: "defect_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 74, DateTimeKind.Utc).AddTicks(1297));

            migrationBuilder.UpdateData(
                table: "defect_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 74, DateTimeKind.Utc).AddTicks(1299));

            migrationBuilder.UpdateData(
                table: "defect_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 74, DateTimeKind.Utc).AddTicks(1300));

            migrationBuilder.UpdateData(
                table: "defect_severities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 75, DateTimeKind.Utc).AddTicks(2414));

            migrationBuilder.UpdateData(
                table: "defect_severities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 75, DateTimeKind.Utc).AddTicks(2417));

            migrationBuilder.UpdateData(
                table: "defect_severities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 75, DateTimeKind.Utc).AddTicks(2419));

            migrationBuilder.UpdateData(
                table: "defect_severities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 75, DateTimeKind.Utc).AddTicks(2419));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 75, DateTimeKind.Utc).AddTicks(9824));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 75, DateTimeKind.Utc).AddTicks(9829));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 75, DateTimeKind.Utc).AddTicks(9831));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 75, DateTimeKind.Utc).AddTicks(9832));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 5,
                column: "created_at",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 75, DateTimeKind.Utc).AddTicks(9833));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 82, DateTimeKind.Utc).AddTicks(9044));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 82, DateTimeKind.Utc).AddTicks(9056));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 82, DateTimeKind.Utc).AddTicks(9097));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 82, DateTimeKind.Utc).AddTicks(9098));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 84, DateTimeKind.Utc).AddTicks(9492));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 84, DateTimeKind.Utc).AddTicks(9506));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 84, DateTimeKind.Utc).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 84, DateTimeKind.Utc).AddTicks(9509));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 5,
                column: "created_at",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 84, DateTimeKind.Utc).AddTicks(9511));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 6,
                column: "created_at",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 84, DateTimeKind.Utc).AddTicks(9512));

            migrationBuilder.UpdateData(
                table: "finding_severities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 109, DateTimeKind.Utc).AddTicks(1984));

            migrationBuilder.UpdateData(
                table: "finding_severities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 109, DateTimeKind.Utc).AddTicks(1992));

            migrationBuilder.UpdateData(
                table: "finding_severities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 109, DateTimeKind.Utc).AddTicks(1993));

            migrationBuilder.UpdateData(
                table: "finding_severities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 109, DateTimeKind.Utc).AddTicks(1994));

            migrationBuilder.UpdateData(
                table: "finding_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 110, DateTimeKind.Utc).AddTicks(2836));

            migrationBuilder.UpdateData(
                table: "finding_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 110, DateTimeKind.Utc).AddTicks(2846));

            migrationBuilder.UpdateData(
                table: "finding_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 110, DateTimeKind.Utc).AddTicks(2847));

            migrationBuilder.UpdateData(
                table: "finding_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 110, DateTimeKind.Utc).AddTicks(2848));

            migrationBuilder.UpdateData(
                table: "finding_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 110, DateTimeKind.Utc).AddTicks(9386));

            migrationBuilder.UpdateData(
                table: "finding_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 110, DateTimeKind.Utc).AddTicks(9391));

            migrationBuilder.UpdateData(
                table: "finding_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 110, DateTimeKind.Utc).AddTicks(9392));

            migrationBuilder.UpdateData(
                table: "finding_types",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 110, DateTimeKind.Utc).AddTicks(9393));

            migrationBuilder.UpdateData(
                table: "platform_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 138, DateTimeKind.Utc).AddTicks(5451));

            migrationBuilder.UpdateData(
                table: "platform_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 138, DateTimeKind.Utc).AddTicks(5462));

            migrationBuilder.UpdateData(
                table: "platform_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 138, DateTimeKind.Utc).AddTicks(5464));

            migrationBuilder.UpdateData(
                table: "project_priorities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 172, DateTimeKind.Utc).AddTicks(5890));

            migrationBuilder.UpdateData(
                table: "project_priorities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 172, DateTimeKind.Utc).AddTicks(5900));

            migrationBuilder.UpdateData(
                table: "project_priorities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 172, DateTimeKind.Utc).AddTicks(5901));

            migrationBuilder.UpdateData(
                table: "project_priorities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 172, DateTimeKind.Utc).AddTicks(5903));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 60, DateTimeKind.Utc).AddTicks(1640));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 60, DateTimeKind.Utc).AddTicks(1643));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 60, DateTimeKind.Utc).AddTicks(1645));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 60, DateTimeKind.Utc).AddTicks(1647));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 60, DateTimeKind.Utc).AddTicks(1649));

            migrationBuilder.UpdateData(
                table: "requirement_complexities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 177, DateTimeKind.Utc).AddTicks(3287));

            migrationBuilder.UpdateData(
                table: "requirement_complexities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 177, DateTimeKind.Utc).AddTicks(3292));

            migrationBuilder.UpdateData(
                table: "requirement_complexities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 177, DateTimeKind.Utc).AddTicks(3293));

            migrationBuilder.UpdateData(
                table: "requirement_complexities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 177, DateTimeKind.Utc).AddTicks(3294));

            migrationBuilder.UpdateData(
                table: "requirement_priorities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 184, DateTimeKind.Utc).AddTicks(5094));

            migrationBuilder.UpdateData(
                table: "requirement_priorities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 184, DateTimeKind.Utc).AddTicks(5102));

            migrationBuilder.UpdateData(
                table: "requirement_priorities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 184, DateTimeKind.Utc).AddTicks(5103));

            migrationBuilder.UpdateData(
                table: "requirement_priorities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 184, DateTimeKind.Utc).AddTicks(5104));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 184, DateTimeKind.Utc).AddTicks(9080));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 184, DateTimeKind.Utc).AddTicks(9099));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 184, DateTimeKind.Utc).AddTicks(9100));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 184, DateTimeKind.Utc).AddTicks(9101));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 184, DateTimeKind.Utc).AddTicks(9102));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 184, DateTimeKind.Utc).AddTicks(9104));

            migrationBuilder.UpdateData(
                table: "requirement_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 186, DateTimeKind.Utc).AddTicks(8988));

            migrationBuilder.UpdateData(
                table: "requirement_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 186, DateTimeKind.Utc).AddTicks(8992));

            migrationBuilder.UpdateData(
                table: "requirement_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 186, DateTimeKind.Utc).AddTicks(8993));

            migrationBuilder.UpdateData(
                table: "requirement_types",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 186, DateTimeKind.Utc).AddTicks(8994));

            migrationBuilder.UpdateData(
                table: "review_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 193, DateTimeKind.Utc).AddTicks(8813));

            migrationBuilder.UpdateData(
                table: "review_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 193, DateTimeKind.Utc).AddTicks(8819));

            migrationBuilder.UpdateData(
                table: "review_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 193, DateTimeKind.Utc).AddTicks(8820));

            migrationBuilder.UpdateData(
                table: "review_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 193, DateTimeKind.Utc).AddTicks(8821));

            migrationBuilder.UpdateData(
                table: "review_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 194, DateTimeKind.Utc).AddTicks(2253));

            migrationBuilder.UpdateData(
                table: "review_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 194, DateTimeKind.Utc).AddTicks(2257));

            migrationBuilder.UpdateData(
                table: "review_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 194, DateTimeKind.Utc).AddTicks(2258));

            migrationBuilder.UpdateData(
                table: "review_types",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 194, DateTimeKind.Utc).AddTicks(2259));

            migrationBuilder.UpdateData(
                table: "risk_levels",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 194, DateTimeKind.Utc).AddTicks(4487));

            migrationBuilder.UpdateData(
                table: "risk_levels",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 194, DateTimeKind.Utc).AddTicks(4489));

            migrationBuilder.UpdateData(
                table: "risk_levels",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 194, DateTimeKind.Utc).AddTicks(4490));

            migrationBuilder.UpdateData(
                table: "risk_levels",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 194, DateTimeKind.Utc).AddTicks(4491));

            migrationBuilder.UpdateData(
                table: "risk_levels",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 194, DateTimeKind.Utc).AddTicks(4492));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("41544143-4f4c-5347-5f4d-414e41474500"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5568));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("41544143-4f4c-5347-5f56-494557000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5566));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-435f-5245-415445000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5648));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-445f-454c-455445000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5655));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5653));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5646));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f4352454154"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5610));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5550444154"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5612));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f55504c4f41"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5613));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5608));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-4352-454154450000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5629));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-4445-4c4554450000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5634));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-5550-444154450000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5631));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-5649-455700000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5615));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-4544-4c45-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5562));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-4956-4557-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5555));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-5055-4441-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5559));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-5243-4541-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5557));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-5341-5349-474e5f504552"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5564));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5657));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564552-5745-5f53-4352-454154450000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5639));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564552-5745-5f53-4445-4c4554450000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5645));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564552-5745-5f53-5550-444154450000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5643));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564552-5745-5f53-5649-455700000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5637));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564e45-4f52-4d4e-454e-54535f435245"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5687));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564e45-4f52-4d4e-454e-54535f44454c"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5691));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564e45-4f52-4d4e-454e-54535f555044"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5689));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564e45-4f52-4d4e-454e-54535f564945"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5686));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f43-524541544500"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5572));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f44-454c45544500"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5592));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f55-504441544500"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5574));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5570));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f43524541"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5680));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f44454c45"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5684));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f55504441"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5682));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f56494557"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5679));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-4544-4c45-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5550));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-4956-4557-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5458));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-5055-4441-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5548));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-5243-4541-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5545));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-5341-5349-474e5f524f4c"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5552));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f4352454154"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5603));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f44454c4554"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5606));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5550444154"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5605));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5601));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("55514552-5249-4d45-454e-54535f435245"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5595));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("55514552-5249-4d45-454e-54535f44454c"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5599));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("55514552-5249-4d45-454e-54535f555044"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5597));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("55514552-5249-4d45-454e-54535f564945"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5594));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4544-454c-5445-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5677));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4956-5745-0000-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5659));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5055-4144-5445-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5675));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5243-4145-5445-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5661));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("41544143-4f4c-5347-5f56-494557000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5770));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5766));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5764));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f4352454154"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5751));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5550444154"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5753));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f55504c4f41"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5755));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5749));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-4352-454154450000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5759));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-5550-444154450000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5761));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-5649-455700000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5756));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5768));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564552-5745-5f53-5649-455700000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5763));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564e45-4f52-4d4e-454e-54535f564945"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5802));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5712));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f43524541"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5798));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f55504441"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5800));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f56494557"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5797));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5721));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("55514552-5249-4d45-454e-54535f564945"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5718));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4956-5745-0000-000000000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5772));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5055-4144-5445-000000000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5795));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5243-4145-5445-000000000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5775));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("41544143-4f4c-5347-5f56-494557000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5907));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-435f-5245-415445000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5899));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-445f-454c-455445000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5903));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5901));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5897));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f4352454154"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5853));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5550444154"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f55504c4f41"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5858));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5851));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-4352-454154450000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5862));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-4445-4c4554450000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5866));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-5550-444154450000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5864));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-5649-455700000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5859));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5905));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564552-5745-5f53-4352-454154450000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5870));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564552-5745-5f53-4445-4c4554450000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5895));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564552-5745-5f53-5550-444154450000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5893));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564552-5745-5f53-5649-455700000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5868));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564e45-4f52-4d4e-454e-54535f435245"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5939));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564e45-4f52-4d4e-454e-54535f44454c"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5943));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564e45-4f52-4d4e-454e-54535f555044"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5941));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564e45-4f52-4d4e-454e-54535f564945"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5938));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f43-524541544500"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5817));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f44-454c45544500"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5821));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f55-504441544500"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5819));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5814));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f43524541"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5932));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f44454c45"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5936));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f55504441"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5934));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f56494557"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5930));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-4956-4557-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5823));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f4352454154"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5846));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f44454c4554"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5850));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5550444154"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5848));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5844));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("55514552-5249-4d45-454e-54535f435245"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5826));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("55514552-5249-4d45-454e-54535f44454c"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5830));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("55514552-5249-4d45-454e-54535f555044"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5828));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("55514552-5249-4d45-454e-54535f564945"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5825));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4544-454c-5445-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5928));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4956-5745-0000-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5909));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5055-4144-5445-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5914));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5243-4145-5445-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5911));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5978));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5976));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5953));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-4352-454154450000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5969));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-5550-444154450000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5972));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-5649-455700000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5955));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5980));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564552-5745-5f53-5649-455700000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5974));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564e45-4f52-4d4e-454e-54535f564945"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5984));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5946));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f56494557"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5985));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5951));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("55514552-5249-4d45-454e-54535f564945"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5949));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4956-5745-0000-000000000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 199, DateTimeKind.Utc).AddTicks(5982));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 200, DateTimeKind.Utc).AddTicks(3268));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 200, DateTimeKind.Utc).AddTicks(3274));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 200, DateTimeKind.Utc).AddTicks(3275));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 200, DateTimeKind.Utc).AddTicks(3277));

            migrationBuilder.UpdateData(
                table: "suite_automation_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 61, DateTimeKind.Utc).AddTicks(3467));

            migrationBuilder.UpdateData(
                table: "suite_automation_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 61, DateTimeKind.Utc).AddTicks(3473));

            migrationBuilder.UpdateData(
                table: "suite_automation_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 61, DateTimeKind.Utc).AddTicks(3475));

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 62, DateTimeKind.Utc).AddTicks(438));

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 62, DateTimeKind.Utc).AddTicks(459));

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 62, DateTimeKind.Utc).AddTicks(460));

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 62, DateTimeKind.Utc).AddTicks(462));

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 62, DateTimeKind.Utc).AddTicks(463));

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 62, DateTimeKind.Utc).AddTicks(464));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 206, DateTimeKind.Utc).AddTicks(8756));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 206, DateTimeKind.Utc).AddTicks(8771));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 206, DateTimeKind.Utc).AddTicks(8772));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 206, DateTimeKind.Utc).AddTicks(8773));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 229, DateTimeKind.Utc).AddTicks(104));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 229, DateTimeKind.Utc).AddTicks(108));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 229, DateTimeKind.Utc).AddTicks(109));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 229, DateTimeKind.Utc).AddTicks(121));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 229, DateTimeKind.Utc).AddTicks(3125));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 229, DateTimeKind.Utc).AddTicks(3128));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 229, DateTimeKind.Utc).AddTicks(3130));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 229, DateTimeKind.Utc).AddTicks(3131));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 229, DateTimeKind.Utc).AddTicks(3132));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 229, DateTimeKind.Utc).AddTicks(3133));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 229, DateTimeKind.Utc).AddTicks(3134));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 229, DateTimeKind.Utc).AddTicks(3134));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 229, DateTimeKind.Utc).AddTicks(3135));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 229, DateTimeKind.Utc).AddTicks(3136));

            migrationBuilder.UpdateData(
                table: "test_levels",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2026, 8, 7, 20, 11, 5, 244, DateTimeKind.Utc).AddTicks(654), "Pruebas Unitarias" });

            migrationBuilder.UpdateData(
                table: "test_levels",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2026, 8, 7, 20, 11, 5, 244, DateTimeKind.Utc).AddTicks(667), "Pruebas de Integración" });

            migrationBuilder.UpdateData(
                table: "test_levels",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2026, 8, 7, 20, 11, 5, 244, DateTimeKind.Utc).AddTicks(669), "Pruebas de Sistema" });

            migrationBuilder.UpdateData(
                table: "test_levels",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2026, 8, 7, 20, 11, 5, 244, DateTimeKind.Utc).AddTicks(670), "Pruebas de Aceptación (UAT)" });

            migrationBuilder.UpdateData(
                table: "test_levels",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2026, 8, 7, 20, 11, 5, 244, DateTimeKind.Utc).AddTicks(671), "Pruebas de Regresión" });

            migrationBuilder.UpdateData(
                table: "test_plan_environments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 255, DateTimeKind.Utc).AddTicks(8161));

            migrationBuilder.UpdateData(
                table: "test_plan_environments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 255, DateTimeKind.Utc).AddTicks(8166));

            migrationBuilder.UpdateData(
                table: "test_plan_environments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 255, DateTimeKind.Utc).AddTicks(8168));

            migrationBuilder.UpdateData(
                table: "test_plan_environments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 255, DateTimeKind.Utc).AddTicks(8169));

            migrationBuilder.UpdateData(
                table: "test_plan_environments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 255, DateTimeKind.Utc).AddTicks(8170));

            migrationBuilder.UpdateData(
                table: "test_plan_environments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 255, DateTimeKind.Utc).AddTicks(8171));

            migrationBuilder.UpdateData(
                table: "test_plan_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 62, DateTimeKind.Utc).AddTicks(5959));

            migrationBuilder.UpdateData(
                table: "test_plan_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 62, DateTimeKind.Utc).AddTicks(5964));

            migrationBuilder.UpdateData(
                table: "test_plan_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 62, DateTimeKind.Utc).AddTicks(5966));

            migrationBuilder.UpdateData(
                table: "test_plan_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 62, DateTimeKind.Utc).AddTicks(5967));

            migrationBuilder.UpdateData(
                table: "test_plan_types",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2026, 8, 7, 20, 11, 5, 264, DateTimeKind.Utc).AddTicks(1185), "Plan Maestro de Pruebas" });

            migrationBuilder.UpdateData(
                table: "test_plan_types",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2026, 8, 7, 20, 11, 5, 264, DateTimeKind.Utc).AddTicks(1190), "Plan de Pruebas por Nivel" });

            migrationBuilder.UpdateData(
                table: "test_plan_types",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2026, 8, 7, 20, 11, 5, 264, DateTimeKind.Utc).AddTicks(1191), "Plan de Pruebas por Iteración" });

            migrationBuilder.UpdateData(
                table: "test_strategies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 268, DateTimeKind.Utc).AddTicks(733));

            migrationBuilder.UpdateData(
                table: "test_strategies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 268, DateTimeKind.Utc).AddTicks(739));

            migrationBuilder.UpdateData(
                table: "test_strategies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 268, DateTimeKind.Utc).AddTicks(741));

            migrationBuilder.UpdateData(
                table: "test_strategies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 268, DateTimeKind.Utc).AddTicks(742));

            migrationBuilder.UpdateData(
                table: "test_strategies",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 268, DateTimeKind.Utc).AddTicks(743));

            migrationBuilder.UpdateData(
                table: "test_strategies",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 268, DateTimeKind.Utc).AddTicks(744));

            migrationBuilder.UpdateData(
                table: "test_strategies",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 268, DateTimeKind.Utc).AddTicks(745));

            migrationBuilder.UpdateData(
                table: "test_strategies",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 268, DateTimeKind.Utc).AddTicks(746));

            migrationBuilder.UpdateData(
                table: "test_strategies",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 268, DateTimeKind.Utc).AddTicks(747));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 63, DateTimeKind.Utc).AddTicks(1511));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 63, DateTimeKind.Utc).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 63, DateTimeKind.Utc).AddTicks(1516));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 63, DateTimeKind.Utc).AddTicks(1517));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 63, DateTimeKind.Utc).AddTicks(8374));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 63, DateTimeKind.Utc).AddTicks(8377));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 63, DateTimeKind.Utc).AddTicks(8379));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 63, DateTimeKind.Utc).AddTicks(8381));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 63, DateTimeKind.Utc).AddTicks(8384));

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("22222222-2222-2222-2222-222222222222"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 291, DateTimeKind.Utc).AddTicks(1605));

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("22222222-2222-2222-2222-222222222222"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 291, DateTimeKind.Utc).AddTicks(1608));

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("44444444-4444-4444-4444-444444444444"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 291, DateTimeKind.Utc).AddTicks(1610));

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("44444444-4444-4444-4444-444444444444"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 291, DateTimeKind.Utc).AddTicks(1612));

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("99999999-9999-9999-9999-999999999999") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 291, DateTimeKind.Utc).AddTicks(1576));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "attachment_file_name",
                table: "defects");

            migrationBuilder.DropColumn(
                name: "attachment_url",
                table: "defects");

            migrationBuilder.UpdateData(
                table: "defect_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 706, DateTimeKind.Utc).AddTicks(7495));

            migrationBuilder.UpdateData(
                table: "defect_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 706, DateTimeKind.Utc).AddTicks(7505));

            migrationBuilder.UpdateData(
                table: "defect_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 706, DateTimeKind.Utc).AddTicks(7509));

            migrationBuilder.UpdateData(
                table: "defect_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 706, DateTimeKind.Utc).AddTicks(7512));

            migrationBuilder.UpdateData(
                table: "defect_severities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 707, DateTimeKind.Utc).AddTicks(8651));

            migrationBuilder.UpdateData(
                table: "defect_severities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 707, DateTimeKind.Utc).AddTicks(8659));

            migrationBuilder.UpdateData(
                table: "defect_severities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 707, DateTimeKind.Utc).AddTicks(8663));

            migrationBuilder.UpdateData(
                table: "defect_severities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 707, DateTimeKind.Utc).AddTicks(8667));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 708, DateTimeKind.Utc).AddTicks(4440));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 708, DateTimeKind.Utc).AddTicks(4444));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 708, DateTimeKind.Utc).AddTicks(4445));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 708, DateTimeKind.Utc).AddTicks(4446));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 5,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 708, DateTimeKind.Utc).AddTicks(4448));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 712, DateTimeKind.Utc).AddTicks(8480));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 712, DateTimeKind.Utc).AddTicks(8489));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 712, DateTimeKind.Utc).AddTicks(8493));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 712, DateTimeKind.Utc).AddTicks(8495));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 714, DateTimeKind.Utc).AddTicks(1216));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 714, DateTimeKind.Utc).AddTicks(1225));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 714, DateTimeKind.Utc).AddTicks(1230));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 714, DateTimeKind.Utc).AddTicks(1233));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 5,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 714, DateTimeKind.Utc).AddTicks(1237));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 6,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 714, DateTimeKind.Utc).AddTicks(1240));

            migrationBuilder.UpdateData(
                table: "finding_severities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 719, DateTimeKind.Utc).AddTicks(7861));

            migrationBuilder.UpdateData(
                table: "finding_severities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 719, DateTimeKind.Utc).AddTicks(7864));

            migrationBuilder.UpdateData(
                table: "finding_severities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 719, DateTimeKind.Utc).AddTicks(7865));

            migrationBuilder.UpdateData(
                table: "finding_severities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 719, DateTimeKind.Utc).AddTicks(7866));

            migrationBuilder.UpdateData(
                table: "finding_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 719, DateTimeKind.Utc).AddTicks(9556));

            migrationBuilder.UpdateData(
                table: "finding_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 719, DateTimeKind.Utc).AddTicks(9560));

            migrationBuilder.UpdateData(
                table: "finding_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 719, DateTimeKind.Utc).AddTicks(9561));

            migrationBuilder.UpdateData(
                table: "finding_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 719, DateTimeKind.Utc).AddTicks(9562));

            migrationBuilder.UpdateData(
                table: "finding_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 720, DateTimeKind.Utc).AddTicks(2866));

            migrationBuilder.UpdateData(
                table: "finding_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 720, DateTimeKind.Utc).AddTicks(2868));

            migrationBuilder.UpdateData(
                table: "finding_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 720, DateTimeKind.Utc).AddTicks(2870));

            migrationBuilder.UpdateData(
                table: "finding_types",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 720, DateTimeKind.Utc).AddTicks(2871));

            migrationBuilder.UpdateData(
                table: "platform_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 726, DateTimeKind.Utc).AddTicks(760));

            migrationBuilder.UpdateData(
                table: "platform_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 726, DateTimeKind.Utc).AddTicks(762));

            migrationBuilder.UpdateData(
                table: "platform_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 726, DateTimeKind.Utc).AddTicks(763));

            migrationBuilder.UpdateData(
                table: "project_priorities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 757, DateTimeKind.Utc).AddTicks(4489));

            migrationBuilder.UpdateData(
                table: "project_priorities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 757, DateTimeKind.Utc).AddTicks(4499));

            migrationBuilder.UpdateData(
                table: "project_priorities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 757, DateTimeKind.Utc).AddTicks(4502));

            migrationBuilder.UpdateData(
                table: "project_priorities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 757, DateTimeKind.Utc).AddTicks(4505));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 699, DateTimeKind.Utc).AddTicks(6205));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 699, DateTimeKind.Utc).AddTicks(6215));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 699, DateTimeKind.Utc).AddTicks(6220));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 699, DateTimeKind.Utc).AddTicks(6223));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 699, DateTimeKind.Utc).AddTicks(6227));

            migrationBuilder.UpdateData(
                table: "requirement_complexities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 770, DateTimeKind.Utc).AddTicks(4771));

            migrationBuilder.UpdateData(
                table: "requirement_complexities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 770, DateTimeKind.Utc).AddTicks(4784));

            migrationBuilder.UpdateData(
                table: "requirement_complexities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 770, DateTimeKind.Utc).AddTicks(4787));

            migrationBuilder.UpdateData(
                table: "requirement_complexities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 770, DateTimeKind.Utc).AddTicks(4790));

            migrationBuilder.UpdateData(
                table: "requirement_priorities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 783, DateTimeKind.Utc).AddTicks(3688));

            migrationBuilder.UpdateData(
                table: "requirement_priorities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 783, DateTimeKind.Utc).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "requirement_priorities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 783, DateTimeKind.Utc).AddTicks(3702));

            migrationBuilder.UpdateData(
                table: "requirement_priorities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 783, DateTimeKind.Utc).AddTicks(3704));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 783, DateTimeKind.Utc).AddTicks(9878));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 783, DateTimeKind.Utc).AddTicks(9891));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 783, DateTimeKind.Utc).AddTicks(9894));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 783, DateTimeKind.Utc).AddTicks(9896));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 783, DateTimeKind.Utc).AddTicks(9899));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 783, DateTimeKind.Utc).AddTicks(9901));

            migrationBuilder.UpdateData(
                table: "requirement_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 785, DateTimeKind.Utc).AddTicks(8886));

            migrationBuilder.UpdateData(
                table: "requirement_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 785, DateTimeKind.Utc).AddTicks(8894));

            migrationBuilder.UpdateData(
                table: "requirement_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 785, DateTimeKind.Utc).AddTicks(8897));

            migrationBuilder.UpdateData(
                table: "requirement_types",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 785, DateTimeKind.Utc).AddTicks(8900));

            migrationBuilder.UpdateData(
                table: "review_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 795, DateTimeKind.Utc).AddTicks(5955));

            migrationBuilder.UpdateData(
                table: "review_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 795, DateTimeKind.Utc).AddTicks(5968));

            migrationBuilder.UpdateData(
                table: "review_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 795, DateTimeKind.Utc).AddTicks(5971));

            migrationBuilder.UpdateData(
                table: "review_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 795, DateTimeKind.Utc).AddTicks(5974));

            migrationBuilder.UpdateData(
                table: "review_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 796, DateTimeKind.Utc).AddTicks(2409));

            migrationBuilder.UpdateData(
                table: "review_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 796, DateTimeKind.Utc).AddTicks(2417));

            migrationBuilder.UpdateData(
                table: "review_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 796, DateTimeKind.Utc).AddTicks(2420));

            migrationBuilder.UpdateData(
                table: "review_types",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 796, DateTimeKind.Utc).AddTicks(2422));

            migrationBuilder.UpdateData(
                table: "risk_levels",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 796, DateTimeKind.Utc).AddTicks(8952));

            migrationBuilder.UpdateData(
                table: "risk_levels",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 796, DateTimeKind.Utc).AddTicks(8957));

            migrationBuilder.UpdateData(
                table: "risk_levels",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 796, DateTimeKind.Utc).AddTicks(8960));

            migrationBuilder.UpdateData(
                table: "risk_levels",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 796, DateTimeKind.Utc).AddTicks(8962));

            migrationBuilder.UpdateData(
                table: "risk_levels",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 796, DateTimeKind.Utc).AddTicks(8964));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("41544143-4f4c-5347-5f4d-414e41474500"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2682));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("41544143-4f4c-5347-5f56-494557000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2677));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-435f-5245-415445000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2795));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-445f-454c-455445000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2801));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2798));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2791));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f4352454154"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2737));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5550444154"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2740));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f55504c4f41"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2742));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2734));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-4352-454154450000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2749));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-4445-4c4554450000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2755));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-5550-444154450000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2753));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-5649-455700000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2746));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-4544-4c45-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2670));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-4956-4557-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2634));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-5055-4441-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2666));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-5243-4541-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2639));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-5341-5349-474e5f504552"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2674));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2804));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564552-5745-5f53-4352-454154450000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2762));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564552-5745-5f53-4445-4c4554450000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2768));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564552-5745-5f53-5550-444154450000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2765));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564552-5745-5f53-5649-455700000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2759));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564e45-4f52-4d4e-454e-54535f435245"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2850));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564e45-4f52-4d4e-454e-54535f44454c"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2856));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564e45-4f52-4d4e-454e-54535f555044"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2853));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564e45-4f52-4d4e-454e-54535f564945"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2835));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f43-524541544500"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2689));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f44-454c45544500"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2695));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f55-504441544500"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2692));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2685));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f43524541"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2827));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f44454c45"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2832));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f55504441"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2830));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f56494557"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2822));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-4544-4c45-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2627));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-4956-4557-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2510));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-5055-4441-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2622));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-5243-4541-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2617));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-5341-5349-474e5f524f4c"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2630));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f4352454154"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2727));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f44454c4554"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2732));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5550444154"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2729));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2709));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("55514552-5249-4d45-454e-54535f435245"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2700));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("55514552-5249-4d45-454e-54535f44454c"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2706));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("55514552-5249-4d45-454e-54535f555044"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2703));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("55514552-5249-4d45-454e-54535f564945"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2698));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4544-454c-5445-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2820));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4956-5745-0000-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2808));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5055-4144-5445-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2817));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5243-4145-5445-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2812));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("41544143-4f4c-5347-5f56-494557000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2986));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2979));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2976));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f4352454154"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2937));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5550444154"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2940));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f55504c4f41"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2943));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2933));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-4352-454154450000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2951));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-5550-444154450000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2969));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-5649-455700000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2947));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2982));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564552-5745-5f53-5649-455700000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2972));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564e45-4f52-4d4e-454e-54535f564945"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3008));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2910));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f43524541"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3002));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f55504441"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3006));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f56494557"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2999));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2928));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("55514552-5249-4d45-454e-54535f564945"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2923));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4956-5745-0000-000000000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2989));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5055-4144-5445-000000000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2996));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5243-4145-5445-000000000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(2992));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("41544143-4f4c-5347-5f56-494557000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3171));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-435f-5245-415445000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3139));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-445f-454c-455445000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3145));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3142));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3135));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f4352454154"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3082));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5550444154"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3084));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f55504c4f41"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3104));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3079));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-4352-454154450000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3111));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-4445-4c4554450000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3118));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-5550-444154450000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3115));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-5649-455700000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3107));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3168));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564552-5745-5f53-4352-454154450000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3125));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564552-5745-5f53-4445-4c4554450000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3131));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564552-5745-5f53-5550-444154450000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3128));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564552-5745-5f53-5649-455700000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3121));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564e45-4f52-4d4e-454e-54535f435245"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3207));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564e45-4f52-4d4e-454e-54535f44454c"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3224));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564e45-4f52-4d4e-454e-54535f555044"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3220));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564e45-4f52-4d4e-454e-54535f564945"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3204));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f43-524541544500"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3041));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f44-454c45544500"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3049));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f55-504441544500"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3046));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3022));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f43524541"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3194));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f44454c45"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3201));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f55504441"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3198));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f56494557"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3191));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-4956-4557-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3052));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f4352454154"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3071));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f44454c4554"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3076));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5550444154"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3073));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3067));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("55514552-5249-4d45-454e-54535f435245"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3059));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("55514552-5249-4d45-454e-54535f44454c"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3065));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("55514552-5249-4d45-454e-54535f555044"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3061));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("55514552-5249-4d45-454e-54535f564945"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3055));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4544-454c-5445-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3187));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4956-5745-0000-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3174));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5055-4144-5445-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3184));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5243-4145-5445-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3180));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3263));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3260));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3241));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-4352-454154450000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3248));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-5550-444154450000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3252));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-5649-455700000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3245));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3267));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564552-5745-5f53-5649-455700000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3255));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564e45-4f52-4d4e-454e-54535f564945"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3283));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3230));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f56494557"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3286));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3237));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("55514552-5249-4d45-454e-54535f564945"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3234));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4956-5745-0000-000000000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 802, DateTimeKind.Utc).AddTicks(3270));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 804, DateTimeKind.Utc).AddTicks(313));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 804, DateTimeKind.Utc).AddTicks(320));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 804, DateTimeKind.Utc).AddTicks(323));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 804, DateTimeKind.Utc).AddTicks(325));

            migrationBuilder.UpdateData(
                table: "suite_automation_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 700, DateTimeKind.Utc).AddTicks(2021));

            migrationBuilder.UpdateData(
                table: "suite_automation_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 700, DateTimeKind.Utc).AddTicks(2026));

            migrationBuilder.UpdateData(
                table: "suite_automation_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 700, DateTimeKind.Utc).AddTicks(2029));

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 700, DateTimeKind.Utc).AddTicks(6086));

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 700, DateTimeKind.Utc).AddTicks(6091));

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 700, DateTimeKind.Utc).AddTicks(6094));

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 700, DateTimeKind.Utc).AddTicks(6097));

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 700, DateTimeKind.Utc).AddTicks(6099));

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 700, DateTimeKind.Utc).AddTicks(6101));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 811, DateTimeKind.Utc).AddTicks(8813));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 811, DateTimeKind.Utc).AddTicks(8822));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 811, DateTimeKind.Utc).AddTicks(8825));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 811, DateTimeKind.Utc).AddTicks(8827));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 832, DateTimeKind.Utc).AddTicks(1435));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 832, DateTimeKind.Utc).AddTicks(1439));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 832, DateTimeKind.Utc).AddTicks(1441));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 832, DateTimeKind.Utc).AddTicks(1443));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 832, DateTimeKind.Utc).AddTicks(5096));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 832, DateTimeKind.Utc).AddTicks(5102));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 832, DateTimeKind.Utc).AddTicks(5104));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 832, DateTimeKind.Utc).AddTicks(5105));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 832, DateTimeKind.Utc).AddTicks(5106));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 832, DateTimeKind.Utc).AddTicks(5108));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 832, DateTimeKind.Utc).AddTicks(5109));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 832, DateTimeKind.Utc).AddTicks(5110));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 832, DateTimeKind.Utc).AddTicks(5111));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 832, DateTimeKind.Utc).AddTicks(5113));

            migrationBuilder.UpdateData(
                table: "test_levels",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2026, 8, 6, 22, 35, 16, 843, DateTimeKind.Utc).AddTicks(7896), "Unit Testing" });

            migrationBuilder.UpdateData(
                table: "test_levels",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2026, 8, 6, 22, 35, 16, 843, DateTimeKind.Utc).AddTicks(7904), "Integration Testing" });

            migrationBuilder.UpdateData(
                table: "test_levels",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2026, 8, 6, 22, 35, 16, 843, DateTimeKind.Utc).AddTicks(7906), "System Testing" });

            migrationBuilder.UpdateData(
                table: "test_levels",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2026, 8, 6, 22, 35, 16, 843, DateTimeKind.Utc).AddTicks(7907), "Acceptance Testing (UAT)" });

            migrationBuilder.UpdateData(
                table: "test_levels",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2026, 8, 6, 22, 35, 16, 843, DateTimeKind.Utc).AddTicks(7908), "Regression Testing" });

            migrationBuilder.UpdateData(
                table: "test_plan_environments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 847, DateTimeKind.Utc).AddTicks(484));

            migrationBuilder.UpdateData(
                table: "test_plan_environments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 847, DateTimeKind.Utc).AddTicks(488));

            migrationBuilder.UpdateData(
                table: "test_plan_environments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 847, DateTimeKind.Utc).AddTicks(490));

            migrationBuilder.UpdateData(
                table: "test_plan_environments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 847, DateTimeKind.Utc).AddTicks(493));

            migrationBuilder.UpdateData(
                table: "test_plan_environments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 847, DateTimeKind.Utc).AddTicks(496));

            migrationBuilder.UpdateData(
                table: "test_plan_environments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 847, DateTimeKind.Utc).AddTicks(499));

            migrationBuilder.UpdateData(
                table: "test_plan_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 700, DateTimeKind.Utc).AddTicks(9612));

            migrationBuilder.UpdateData(
                table: "test_plan_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 700, DateTimeKind.Utc).AddTicks(9619));

            migrationBuilder.UpdateData(
                table: "test_plan_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 700, DateTimeKind.Utc).AddTicks(9632));

            migrationBuilder.UpdateData(
                table: "test_plan_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 700, DateTimeKind.Utc).AddTicks(9635));

            migrationBuilder.UpdateData(
                table: "test_plan_types",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2026, 8, 6, 22, 35, 16, 850, DateTimeKind.Utc).AddTicks(3443), "Master Test Plan" });

            migrationBuilder.UpdateData(
                table: "test_plan_types",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2026, 8, 6, 22, 35, 16, 850, DateTimeKind.Utc).AddTicks(3447), "Level Test Plan" });

            migrationBuilder.UpdateData(
                table: "test_plan_types",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2026, 8, 6, 22, 35, 16, 850, DateTimeKind.Utc).AddTicks(3448), "Iteration Test Plan" });

            migrationBuilder.UpdateData(
                table: "test_strategies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 851, DateTimeKind.Utc).AddTicks(6133));

            migrationBuilder.UpdateData(
                table: "test_strategies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 851, DateTimeKind.Utc).AddTicks(6135));

            migrationBuilder.UpdateData(
                table: "test_strategies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 851, DateTimeKind.Utc).AddTicks(6137));

            migrationBuilder.UpdateData(
                table: "test_strategies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 851, DateTimeKind.Utc).AddTicks(6138));

            migrationBuilder.UpdateData(
                table: "test_strategies",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 851, DateTimeKind.Utc).AddTicks(6139));

            migrationBuilder.UpdateData(
                table: "test_strategies",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 851, DateTimeKind.Utc).AddTicks(6140));

            migrationBuilder.UpdateData(
                table: "test_strategies",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 851, DateTimeKind.Utc).AddTicks(6141));

            migrationBuilder.UpdateData(
                table: "test_strategies",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 851, DateTimeKind.Utc).AddTicks(6142));

            migrationBuilder.UpdateData(
                table: "test_strategies",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 851, DateTimeKind.Utc).AddTicks(6143));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 701, DateTimeKind.Utc).AddTicks(2806));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 701, DateTimeKind.Utc).AddTicks(2811));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 701, DateTimeKind.Utc).AddTicks(2814));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 701, DateTimeKind.Utc).AddTicks(2817));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 701, DateTimeKind.Utc).AddTicks(4977));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 701, DateTimeKind.Utc).AddTicks(4979));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 701, DateTimeKind.Utc).AddTicks(4981));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 701, DateTimeKind.Utc).AddTicks(4982));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 701, DateTimeKind.Utc).AddTicks(4984));

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("22222222-2222-2222-2222-222222222222"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 867, DateTimeKind.Utc).AddTicks(2985));

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("22222222-2222-2222-2222-222222222222"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 867, DateTimeKind.Utc).AddTicks(2988));

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("44444444-4444-4444-4444-444444444444"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 867, DateTimeKind.Utc).AddTicks(2989));

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("44444444-4444-4444-4444-444444444444"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 867, DateTimeKind.Utc).AddTicks(2991));

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("99999999-9999-9999-9999-999999999999") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 6, 22, 35, 16, 867, DateTimeKind.Utc).AddTicks(2960));
        }
    }
}
