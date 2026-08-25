using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QAMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBddScenarioToTestCase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "defect_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 754, DateTimeKind.Utc).AddTicks(474));

            migrationBuilder.UpdateData(
                table: "defect_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 754, DateTimeKind.Utc).AddTicks(476));

            migrationBuilder.UpdateData(
                table: "defect_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 754, DateTimeKind.Utc).AddTicks(477));

            migrationBuilder.UpdateData(
                table: "defect_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 754, DateTimeKind.Utc).AddTicks(479));

            migrationBuilder.UpdateData(
                table: "defect_severities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 754, DateTimeKind.Utc).AddTicks(4022));

            migrationBuilder.UpdateData(
                table: "defect_severities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 754, DateTimeKind.Utc).AddTicks(4024));

            migrationBuilder.UpdateData(
                table: "defect_severities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 754, DateTimeKind.Utc).AddTicks(4026));

            migrationBuilder.UpdateData(
                table: "defect_severities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 754, DateTimeKind.Utc).AddTicks(4027));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 754, DateTimeKind.Utc).AddTicks(6851));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 754, DateTimeKind.Utc).AddTicks(6854));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 754, DateTimeKind.Utc).AddTicks(6855));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 754, DateTimeKind.Utc).AddTicks(6856));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 5,
                column: "created_at",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 754, DateTimeKind.Utc).AddTicks(6857));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 756, DateTimeKind.Utc).AddTicks(3198));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 756, DateTimeKind.Utc).AddTicks(3202));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 756, DateTimeKind.Utc).AddTicks(3203));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 756, DateTimeKind.Utc).AddTicks(3204));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 757, DateTimeKind.Utc).AddTicks(709));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 757, DateTimeKind.Utc).AddTicks(713));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 757, DateTimeKind.Utc).AddTicks(715));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 757, DateTimeKind.Utc).AddTicks(716));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 5,
                column: "created_at",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 757, DateTimeKind.Utc).AddTicks(717));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 6,
                column: "created_at",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 757, DateTimeKind.Utc).AddTicks(718));

            migrationBuilder.UpdateData(
                table: "finding_severities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 763, DateTimeKind.Utc).AddTicks(5408));

            migrationBuilder.UpdateData(
                table: "finding_severities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 763, DateTimeKind.Utc).AddTicks(5413));

            migrationBuilder.UpdateData(
                table: "finding_severities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 763, DateTimeKind.Utc).AddTicks(5415));

            migrationBuilder.UpdateData(
                table: "finding_severities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 763, DateTimeKind.Utc).AddTicks(5416));

            migrationBuilder.UpdateData(
                table: "finding_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 764, DateTimeKind.Utc).AddTicks(244));

            migrationBuilder.UpdateData(
                table: "finding_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 764, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "finding_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 764, DateTimeKind.Utc).AddTicks(249));

            migrationBuilder.UpdateData(
                table: "finding_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 764, DateTimeKind.Utc).AddTicks(250));

            migrationBuilder.UpdateData(
                table: "finding_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 764, DateTimeKind.Utc).AddTicks(4875));

            migrationBuilder.UpdateData(
                table: "finding_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 764, DateTimeKind.Utc).AddTicks(4879));

            migrationBuilder.UpdateData(
                table: "finding_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 764, DateTimeKind.Utc).AddTicks(4881));

            migrationBuilder.UpdateData(
                table: "finding_types",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 764, DateTimeKind.Utc).AddTicks(4882));

            migrationBuilder.UpdateData(
                table: "platform_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 771, DateTimeKind.Utc).AddTicks(3080));

            migrationBuilder.UpdateData(
                table: "platform_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 771, DateTimeKind.Utc).AddTicks(3083));

            migrationBuilder.UpdateData(
                table: "platform_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 771, DateTimeKind.Utc).AddTicks(3084));

            migrationBuilder.UpdateData(
                table: "project_priorities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 781, DateTimeKind.Utc).AddTicks(4746));

            migrationBuilder.UpdateData(
                table: "project_priorities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 781, DateTimeKind.Utc).AddTicks(4749));

            migrationBuilder.UpdateData(
                table: "project_priorities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 781, DateTimeKind.Utc).AddTicks(4750));

            migrationBuilder.UpdateData(
                table: "project_priorities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 781, DateTimeKind.Utc).AddTicks(4751));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 750, DateTimeKind.Utc).AddTicks(4379));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 750, DateTimeKind.Utc).AddTicks(4381));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 750, DateTimeKind.Utc).AddTicks(4383));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 750, DateTimeKind.Utc).AddTicks(4384));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 750, DateTimeKind.Utc).AddTicks(4386));

            migrationBuilder.UpdateData(
                table: "requirement_complexities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 785, DateTimeKind.Utc).AddTicks(8664));

            migrationBuilder.UpdateData(
                table: "requirement_complexities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 785, DateTimeKind.Utc).AddTicks(8667));

            migrationBuilder.UpdateData(
                table: "requirement_complexities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 785, DateTimeKind.Utc).AddTicks(8669));

            migrationBuilder.UpdateData(
                table: "requirement_complexities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 785, DateTimeKind.Utc).AddTicks(8670));

            migrationBuilder.UpdateData(
                table: "requirement_priorities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 789, DateTimeKind.Utc).AddTicks(4572));

            migrationBuilder.UpdateData(
                table: "requirement_priorities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 789, DateTimeKind.Utc).AddTicks(4577));

            migrationBuilder.UpdateData(
                table: "requirement_priorities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 789, DateTimeKind.Utc).AddTicks(4578));

            migrationBuilder.UpdateData(
                table: "requirement_priorities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 789, DateTimeKind.Utc).AddTicks(4580));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 789, DateTimeKind.Utc).AddTicks(7457));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 789, DateTimeKind.Utc).AddTicks(7461));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 789, DateTimeKind.Utc).AddTicks(7462));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 789, DateTimeKind.Utc).AddTicks(7464));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 789, DateTimeKind.Utc).AddTicks(7466));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 789, DateTimeKind.Utc).AddTicks(7467));

            migrationBuilder.UpdateData(
                table: "requirement_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 790, DateTimeKind.Utc).AddTicks(7337));

            migrationBuilder.UpdateData(
                table: "requirement_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 790, DateTimeKind.Utc).AddTicks(7339));

            migrationBuilder.UpdateData(
                table: "requirement_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 790, DateTimeKind.Utc).AddTicks(7340));

            migrationBuilder.UpdateData(
                table: "requirement_types",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 790, DateTimeKind.Utc).AddTicks(7341));

            migrationBuilder.UpdateData(
                table: "review_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 793, DateTimeKind.Utc).AddTicks(5577));

            migrationBuilder.UpdateData(
                table: "review_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 793, DateTimeKind.Utc).AddTicks(5580));

            migrationBuilder.UpdateData(
                table: "review_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 793, DateTimeKind.Utc).AddTicks(5582));

            migrationBuilder.UpdateData(
                table: "review_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 793, DateTimeKind.Utc).AddTicks(5589));

            migrationBuilder.UpdateData(
                table: "review_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 793, DateTimeKind.Utc).AddTicks(7635));

            migrationBuilder.UpdateData(
                table: "review_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 793, DateTimeKind.Utc).AddTicks(7637));

            migrationBuilder.UpdateData(
                table: "review_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 793, DateTimeKind.Utc).AddTicks(7638));

            migrationBuilder.UpdateData(
                table: "review_types",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 793, DateTimeKind.Utc).AddTicks(7639));

            migrationBuilder.UpdateData(
                table: "risk_levels",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 793, DateTimeKind.Utc).AddTicks(9282));

            migrationBuilder.UpdateData(
                table: "risk_levels",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 793, DateTimeKind.Utc).AddTicks(9284));

            migrationBuilder.UpdateData(
                table: "risk_levels",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 793, DateTimeKind.Utc).AddTicks(9285));

            migrationBuilder.UpdateData(
                table: "risk_levels",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 793, DateTimeKind.Utc).AddTicks(9286));

            migrationBuilder.UpdateData(
                table: "risk_levels",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 793, DateTimeKind.Utc).AddTicks(9287));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("41544143-4f4c-5347-5f4d-414e41474500"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8686));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("41544143-4f4c-5347-5f56-494557000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8684));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-435f-5245-415445000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8744));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-445f-454c-455445000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8747));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8745));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8742));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f4352454154"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8715));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5550444154"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8716));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f55504c4f41"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8718));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8714));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-4352-454154450000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8726));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-4445-4c4554450000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8729));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-5550-444154450000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8727));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-5649-455700000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8719));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-4544-4c45-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8681));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-4956-4557-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8667));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-5055-4441-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8679));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-5243-4541-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8670));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-5341-5349-474e5f504552"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8682));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8748));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564552-5745-5f53-4352-454154450000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8731));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564552-5745-5f53-4445-4c4554450000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8741));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564552-5745-5f53-5550-444154450000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8733));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564552-5745-5f53-5649-455700000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8730));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564e45-4f52-4d4e-454e-54535f435245"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8769));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564e45-4f52-4d4e-454e-54535f44454c"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8771));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564e45-4f52-4d4e-454e-54535f555044"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8770));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564e45-4f52-4d4e-454e-54535f564945"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8767));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f43-524541544500"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8689));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f44-454c45544500"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8692));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f55-504441544500"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8691));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8688));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f43524541"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8758));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f44454c45"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8760));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f55504441"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8759));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f56494557"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8756));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-4544-4c45-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8664));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-4956-4557-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8618));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-5055-4441-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8662));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-5243-4541-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8659));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-5341-5349-474e5f524f4c"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8665));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f4352454154"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8710));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f44454c4554"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8712));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5550444154"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8711));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8700));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("55514552-5249-4d45-454e-54535f435245"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8696));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("55514552-5249-4d45-454e-54535f44454c"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8699));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("55514552-5249-4d45-454e-54535f555044"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8697));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("55514552-5249-4d45-454e-54535f564945"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8694));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4544-454c-5445-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8755));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4956-5745-0000-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8749));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5055-4144-5445-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8753));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5243-4145-5445-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8751));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("41544143-4f4c-5347-5f56-494557000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8816));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8813));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8812));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f4352454154"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8792));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5550444154"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8794));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f55504c4f41"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8796));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8791));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-4352-454154450000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8799));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-5550-444154450000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8808));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-5649-455700000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8797));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8815));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564552-5745-5f53-5649-455700000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8810));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564e45-4f52-4d4e-454e-54535f564945"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8828));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8782));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f43524541"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8825));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f55504441"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8827));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f56494557"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8823));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8788));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("55514552-5249-4d45-454e-54535f564945"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8787));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4956-5745-0000-000000000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8818));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5055-4144-5445-000000000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8822));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5243-4145-5445-000000000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8820));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("41544143-4f4c-5347-5f56-494557000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8906));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-435f-5245-415445000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8891));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-445f-454c-455445000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8895));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8893));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8889));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f4352454154"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8864));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5550444154"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8872));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f55504c4f41"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8874));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8862));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-4352-454154450000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8878));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-4445-4c4554450000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8881));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-5550-444154450000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8880));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-5649-455700000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8876));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8904));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564552-5745-5f53-4352-454154450000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8885));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564552-5745-5f53-4445-4c4554450000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8888));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564552-5745-5f53-5550-444154450000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8886));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564552-5745-5f53-5649-455700000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8883));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564e45-4f52-4d4e-454e-54535f435245"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8931));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564e45-4f52-4d4e-454e-54535f44454c"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8934));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564e45-4f52-4d4e-454e-54535f555044"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8933));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564e45-4f52-4d4e-454e-54535f564945"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8923));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f43-524541544500"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8844));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f44-454c45544500"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8847));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f55-504441544500"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8846));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8841));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f43524541"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8918));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f44454c45"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8922));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f55504441"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8920));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f56494557"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8917));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-4956-4557-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8849));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f4352454154"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8858));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f44454c4554"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8861));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5550444154"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8860));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8856));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("55514552-5249-4d45-454e-54535f435245"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8852));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("55514552-5249-4d45-454e-54535f44454c"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8855));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("55514552-5249-4d45-454e-54535f555044"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8854));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("55514552-5249-4d45-454e-54535f564945"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8851));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4544-454c-5445-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8915));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4956-5745-0000-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8908));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5055-4144-5445-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8913));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5243-4145-5445-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8911));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8955));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8953));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8944));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-4352-454154450000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8948));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-5550-444154450000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8950));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("45464544-5443-5f53-5649-455700000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8946));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8957));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564552-5745-5f53-5649-455700000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8952));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("49564e45-4f52-4d4e-454e-54535f564945"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8966));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8937));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4c505845-524f-5441-4f52-595f56494557"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8967));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8942));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("55514552-5249-4d45-454e-54535f564945"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8940));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4956-5745-0000-000000000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 794, DateTimeKind.Utc).AddTicks(8964));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 795, DateTimeKind.Utc).AddTicks(1793));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 795, DateTimeKind.Utc).AddTicks(1795));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 795, DateTimeKind.Utc).AddTicks(1797));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 795, DateTimeKind.Utc).AddTicks(1798));

            migrationBuilder.UpdateData(
                table: "suite_automation_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 750, DateTimeKind.Utc).AddTicks(6042));

            migrationBuilder.UpdateData(
                table: "suite_automation_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 750, DateTimeKind.Utc).AddTicks(6044));

            migrationBuilder.UpdateData(
                table: "suite_automation_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 750, DateTimeKind.Utc).AddTicks(6045));

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 750, DateTimeKind.Utc).AddTicks(7448));

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 750, DateTimeKind.Utc).AddTicks(7451));

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 750, DateTimeKind.Utc).AddTicks(7452));

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 750, DateTimeKind.Utc).AddTicks(7453));

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 750, DateTimeKind.Utc).AddTicks(7454));

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 750, DateTimeKind.Utc).AddTicks(7454));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 796, DateTimeKind.Utc).AddTicks(6880));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 796, DateTimeKind.Utc).AddTicks(6883));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 796, DateTimeKind.Utc).AddTicks(6884));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 796, DateTimeKind.Utc).AddTicks(6885));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 807, DateTimeKind.Utc).AddTicks(6071));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 807, DateTimeKind.Utc).AddTicks(6074));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 807, DateTimeKind.Utc).AddTicks(6076));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 807, DateTimeKind.Utc).AddTicks(6076));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 807, DateTimeKind.Utc).AddTicks(8146));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 807, DateTimeKind.Utc).AddTicks(8148));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 807, DateTimeKind.Utc).AddTicks(8149));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 807, DateTimeKind.Utc).AddTicks(8150));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 807, DateTimeKind.Utc).AddTicks(8151));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 807, DateTimeKind.Utc).AddTicks(8152));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 807, DateTimeKind.Utc).AddTicks(8153));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 807, DateTimeKind.Utc).AddTicks(8154));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 807, DateTimeKind.Utc).AddTicks(8154));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 807, DateTimeKind.Utc).AddTicks(8155));

            migrationBuilder.UpdateData(
                table: "test_levels",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 817, DateTimeKind.Utc).AddTicks(9135));

            migrationBuilder.UpdateData(
                table: "test_levels",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 817, DateTimeKind.Utc).AddTicks(9139));

            migrationBuilder.UpdateData(
                table: "test_levels",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 817, DateTimeKind.Utc).AddTicks(9141));

            migrationBuilder.UpdateData(
                table: "test_levels",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 817, DateTimeKind.Utc).AddTicks(9142));

            migrationBuilder.UpdateData(
                table: "test_levels",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 817, DateTimeKind.Utc).AddTicks(9143));

            migrationBuilder.UpdateData(
                table: "test_plan_environments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 821, DateTimeKind.Utc).AddTicks(6353));

            migrationBuilder.UpdateData(
                table: "test_plan_environments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 821, DateTimeKind.Utc).AddTicks(6356));

            migrationBuilder.UpdateData(
                table: "test_plan_environments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 821, DateTimeKind.Utc).AddTicks(6358));

            migrationBuilder.UpdateData(
                table: "test_plan_environments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 821, DateTimeKind.Utc).AddTicks(6359));

            migrationBuilder.UpdateData(
                table: "test_plan_environments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 821, DateTimeKind.Utc).AddTicks(6360));

            migrationBuilder.UpdateData(
                table: "test_plan_environments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 821, DateTimeKind.Utc).AddTicks(6361));

            migrationBuilder.UpdateData(
                table: "test_plan_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 750, DateTimeKind.Utc).AddTicks(8773));

            migrationBuilder.UpdateData(
                table: "test_plan_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 750, DateTimeKind.Utc).AddTicks(8775));

            migrationBuilder.UpdateData(
                table: "test_plan_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 750, DateTimeKind.Utc).AddTicks(8776));

            migrationBuilder.UpdateData(
                table: "test_plan_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 750, DateTimeKind.Utc).AddTicks(8777));

            migrationBuilder.UpdateData(
                table: "test_plan_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 823, DateTimeKind.Utc).AddTicks(8318));

            migrationBuilder.UpdateData(
                table: "test_plan_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 823, DateTimeKind.Utc).AddTicks(8321));

            migrationBuilder.UpdateData(
                table: "test_plan_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 823, DateTimeKind.Utc).AddTicks(8322));

            migrationBuilder.UpdateData(
                table: "test_strategies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 825, DateTimeKind.Utc).AddTicks(1384));

            migrationBuilder.UpdateData(
                table: "test_strategies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 825, DateTimeKind.Utc).AddTicks(1387));

            migrationBuilder.UpdateData(
                table: "test_strategies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 825, DateTimeKind.Utc).AddTicks(1388));

            migrationBuilder.UpdateData(
                table: "test_strategies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 825, DateTimeKind.Utc).AddTicks(1389));

            migrationBuilder.UpdateData(
                table: "test_strategies",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 825, DateTimeKind.Utc).AddTicks(1390));

            migrationBuilder.UpdateData(
                table: "test_strategies",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 825, DateTimeKind.Utc).AddTicks(1391));

            migrationBuilder.UpdateData(
                table: "test_strategies",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 825, DateTimeKind.Utc).AddTicks(1392));

            migrationBuilder.UpdateData(
                table: "test_strategies",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 825, DateTimeKind.Utc).AddTicks(1393));

            migrationBuilder.UpdateData(
                table: "test_strategies",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 825, DateTimeKind.Utc).AddTicks(1394));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 751, DateTimeKind.Utc).AddTicks(1398));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 751, DateTimeKind.Utc).AddTicks(1400));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 751, DateTimeKind.Utc).AddTicks(1402));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 751, DateTimeKind.Utc).AddTicks(1403));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 751, DateTimeKind.Utc).AddTicks(3249));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 751, DateTimeKind.Utc).AddTicks(3251));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 751, DateTimeKind.Utc).AddTicks(3253));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 751, DateTimeKind.Utc).AddTicks(3254));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 751, DateTimeKind.Utc).AddTicks(3256));

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("22222222-2222-2222-2222-222222222222"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 834, DateTimeKind.Utc).AddTicks(8455));

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("22222222-2222-2222-2222-222222222222"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 834, DateTimeKind.Utc).AddTicks(8457));

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("44444444-4444-4444-4444-444444444444"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 834, DateTimeKind.Utc).AddTicks(8459));

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("44444444-4444-4444-4444-444444444444"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 834, DateTimeKind.Utc).AddTicks(8460));

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("99999999-9999-9999-9999-999999999999") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 25, 23, 48, 20, 834, DateTimeKind.Utc).AddTicks(8434));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 244, DateTimeKind.Utc).AddTicks(654));

            migrationBuilder.UpdateData(
                table: "test_levels",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 244, DateTimeKind.Utc).AddTicks(667));

            migrationBuilder.UpdateData(
                table: "test_levels",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 244, DateTimeKind.Utc).AddTicks(669));

            migrationBuilder.UpdateData(
                table: "test_levels",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 244, DateTimeKind.Utc).AddTicks(670));

            migrationBuilder.UpdateData(
                table: "test_levels",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 244, DateTimeKind.Utc).AddTicks(671));

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
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 264, DateTimeKind.Utc).AddTicks(1185));

            migrationBuilder.UpdateData(
                table: "test_plan_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 264, DateTimeKind.Utc).AddTicks(1190));

            migrationBuilder.UpdateData(
                table: "test_plan_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 7, 20, 11, 5, 264, DateTimeKind.Utc).AddTicks(1191));

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
    }
}
