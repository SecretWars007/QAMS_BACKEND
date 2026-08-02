using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QAMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "defect_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 111, DateTimeKind.Utc).AddTicks(5808));

            migrationBuilder.UpdateData(
                table: "defect_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 111, DateTimeKind.Utc).AddTicks(5815));

            migrationBuilder.UpdateData(
                table: "defect_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 111, DateTimeKind.Utc).AddTicks(5816));

            migrationBuilder.UpdateData(
                table: "defect_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 111, DateTimeKind.Utc).AddTicks(5817));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 111, DateTimeKind.Utc).AddTicks(8566));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 111, DateTimeKind.Utc).AddTicks(8569));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 111, DateTimeKind.Utc).AddTicks(8570));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 111, DateTimeKind.Utc).AddTicks(8571));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 5,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 111, DateTimeKind.Utc).AddTicks(8572));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 113, DateTimeKind.Utc).AddTicks(5412));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 113, DateTimeKind.Utc).AddTicks(5414));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 113, DateTimeKind.Utc).AddTicks(5416));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 113, DateTimeKind.Utc).AddTicks(5417));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 113, DateTimeKind.Utc).AddTicks(7947));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 113, DateTimeKind.Utc).AddTicks(7950));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 113, DateTimeKind.Utc).AddTicks(7951));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 113, DateTimeKind.Utc).AddTicks(7952));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 5,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 113, DateTimeKind.Utc).AddTicks(7953));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 6,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 113, DateTimeKind.Utc).AddTicks(7954));

            migrationBuilder.UpdateData(
                table: "finding_severities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 117, DateTimeKind.Utc).AddTicks(4819));

            migrationBuilder.UpdateData(
                table: "finding_severities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 117, DateTimeKind.Utc).AddTicks(4822));

            migrationBuilder.UpdateData(
                table: "finding_severities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 117, DateTimeKind.Utc).AddTicks(4824));

            migrationBuilder.UpdateData(
                table: "finding_severities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 117, DateTimeKind.Utc).AddTicks(4825));

            migrationBuilder.UpdateData(
                table: "finding_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 117, DateTimeKind.Utc).AddTicks(6591));

            migrationBuilder.UpdateData(
                table: "finding_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 117, DateTimeKind.Utc).AddTicks(6593));

            migrationBuilder.UpdateData(
                table: "finding_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 117, DateTimeKind.Utc).AddTicks(6594));

            migrationBuilder.UpdateData(
                table: "finding_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 117, DateTimeKind.Utc).AddTicks(6595));

            migrationBuilder.UpdateData(
                table: "finding_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 117, DateTimeKind.Utc).AddTicks(8939));

            migrationBuilder.UpdateData(
                table: "finding_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 117, DateTimeKind.Utc).AddTicks(8942));

            migrationBuilder.UpdateData(
                table: "finding_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 117, DateTimeKind.Utc).AddTicks(8943));

            migrationBuilder.UpdateData(
                table: "finding_types",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 117, DateTimeKind.Utc).AddTicks(8944));

            migrationBuilder.UpdateData(
                table: "platform_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 122, DateTimeKind.Utc).AddTicks(6559));

            migrationBuilder.UpdateData(
                table: "platform_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 122, DateTimeKind.Utc).AddTicks(6561));

            migrationBuilder.UpdateData(
                table: "platform_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 122, DateTimeKind.Utc).AddTicks(6562));

            migrationBuilder.UpdateData(
                table: "project_priorities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 130, DateTimeKind.Utc).AddTicks(7247));

            migrationBuilder.UpdateData(
                table: "project_priorities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 130, DateTimeKind.Utc).AddTicks(7249));

            migrationBuilder.UpdateData(
                table: "project_priorities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 130, DateTimeKind.Utc).AddTicks(7256));

            migrationBuilder.UpdateData(
                table: "project_priorities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 130, DateTimeKind.Utc).AddTicks(7258));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 109, DateTimeKind.Utc).AddTicks(813));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 109, DateTimeKind.Utc).AddTicks(815));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 109, DateTimeKind.Utc).AddTicks(817));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 109, DateTimeKind.Utc).AddTicks(818));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 109, DateTimeKind.Utc).AddTicks(820));

            migrationBuilder.UpdateData(
                table: "requirement_complexities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 132, DateTimeKind.Utc).AddTicks(4533));

            migrationBuilder.UpdateData(
                table: "requirement_complexities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 132, DateTimeKind.Utc).AddTicks(4535));

            migrationBuilder.UpdateData(
                table: "requirement_complexities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 132, DateTimeKind.Utc).AddTicks(4536));

            migrationBuilder.UpdateData(
                table: "requirement_complexities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 132, DateTimeKind.Utc).AddTicks(4537));

            migrationBuilder.UpdateData(
                table: "requirement_priorities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 134, DateTimeKind.Utc).AddTicks(8770));

            migrationBuilder.UpdateData(
                table: "requirement_priorities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 134, DateTimeKind.Utc).AddTicks(8773));

            migrationBuilder.UpdateData(
                table: "requirement_priorities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 134, DateTimeKind.Utc).AddTicks(8774));

            migrationBuilder.UpdateData(
                table: "requirement_priorities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 134, DateTimeKind.Utc).AddTicks(8775));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 135, DateTimeKind.Utc).AddTicks(595));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 135, DateTimeKind.Utc).AddTicks(597));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 135, DateTimeKind.Utc).AddTicks(598));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 135, DateTimeKind.Utc).AddTicks(600));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 135, DateTimeKind.Utc).AddTicks(605));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 135, DateTimeKind.Utc).AddTicks(606));

            migrationBuilder.UpdateData(
                table: "requirement_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 135, DateTimeKind.Utc).AddTicks(7172));

            migrationBuilder.UpdateData(
                table: "requirement_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 135, DateTimeKind.Utc).AddTicks(7180));

            migrationBuilder.UpdateData(
                table: "requirement_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 135, DateTimeKind.Utc).AddTicks(7181));

            migrationBuilder.UpdateData(
                table: "requirement_types",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 135, DateTimeKind.Utc).AddTicks(7183));

            migrationBuilder.UpdateData(
                table: "review_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 138, DateTimeKind.Utc).AddTicks(2716));

            migrationBuilder.UpdateData(
                table: "review_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 138, DateTimeKind.Utc).AddTicks(2719));

            migrationBuilder.UpdateData(
                table: "review_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 138, DateTimeKind.Utc).AddTicks(2721));

            migrationBuilder.UpdateData(
                table: "review_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 138, DateTimeKind.Utc).AddTicks(2722));

            migrationBuilder.UpdateData(
                table: "review_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 138, DateTimeKind.Utc).AddTicks(4421));

            migrationBuilder.UpdateData(
                table: "review_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 138, DateTimeKind.Utc).AddTicks(4423));

            migrationBuilder.UpdateData(
                table: "review_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 138, DateTimeKind.Utc).AddTicks(4424));

            migrationBuilder.UpdateData(
                table: "review_types",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 138, DateTimeKind.Utc).AddTicks(4425));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("41544143-4f4c-5347-5f4d-414e41474500"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3643));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("41544143-4f4c-5347-5f56-494557000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3642));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-435f-5245-415445000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3668));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-445f-454c-455445000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3671));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3670));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3667));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f4352454154"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3663));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5550444154"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3664));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f55504c4f41"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3666));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3661));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-4544-4c45-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3639));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-4956-4557-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3616));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-5055-4441-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3637));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-5243-4541-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3635));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-5341-5349-474e5f504552"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3640));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3673));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f43-524541544500"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3646));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f44-454c45544500"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3649));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f55-504441544500"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3648));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3645));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-4544-4c45-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3607));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-4956-4557-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3570));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-5055-4441-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3605));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-5243-4541-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3602));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-5341-5349-474e5f524f4c"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3608));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f4352454154"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3652));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f44454c4554"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3660));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5550444154"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3653));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3650));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4544-454c-5445-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3680));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4956-5745-0000-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3674));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5055-4144-5445-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3678));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5243-4145-5445-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3676));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("41544143-4f4c-5347-5f56-494557000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3716));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3713));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3711));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f4352454154"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3707));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5550444154"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3708));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f55504c4f41"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3709));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3705));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3714));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3689));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3703));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4956-5745-0000-000000000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3717));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5055-4144-5445-000000000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3720));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5243-4145-5445-000000000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3719));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("41544143-4f4c-5347-5f56-494557000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3758));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3750));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3748));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f4352454154"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3744));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5550444154"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3746));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f55504c4f41"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3747));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3743));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3752));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f43-524541544500"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3734));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f55-504441544500"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3736));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3732));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-4956-4557-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3737));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f4352454154"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3740));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5550444154"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3742));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3739));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4544-454c-5445-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3764));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4956-5745-0000-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3760));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5055-4144-5445-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3763));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5243-4145-5445-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3761));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3775));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3774));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3772));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3777));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3768));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3770));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4956-5745-0000-000000000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(3778));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(6545));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(6548));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(6550));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 139, DateTimeKind.Utc).AddTicks(6551));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 142, DateTimeKind.Utc).AddTicks(2742));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 142, DateTimeKind.Utc).AddTicks(2744));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 142, DateTimeKind.Utc).AddTicks(2752));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 142, DateTimeKind.Utc).AddTicks(2753));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 149, DateTimeKind.Utc).AddTicks(4194));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 149, DateTimeKind.Utc).AddTicks(4197));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 149, DateTimeKind.Utc).AddTicks(4198));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 149, DateTimeKind.Utc).AddTicks(4199));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 149, DateTimeKind.Utc).AddTicks(6457));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 149, DateTimeKind.Utc).AddTicks(6460));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 149, DateTimeKind.Utc).AddTicks(6461));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 149, DateTimeKind.Utc).AddTicks(6462));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 149, DateTimeKind.Utc).AddTicks(6463));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 149, DateTimeKind.Utc).AddTicks(6464));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 149, DateTimeKind.Utc).AddTicks(6464));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 149, DateTimeKind.Utc).AddTicks(6465));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 149, DateTimeKind.Utc).AddTicks(6466));

            migrationBuilder.UpdateData(
                table: "test_design_techniques",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 149, DateTimeKind.Utc).AddTicks(6467));

            migrationBuilder.UpdateData(
                table: "test_plan_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 109, DateTimeKind.Utc).AddTicks(2881));

            migrationBuilder.UpdateData(
                table: "test_plan_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 109, DateTimeKind.Utc).AddTicks(2885));

            migrationBuilder.UpdateData(
                table: "test_plan_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 109, DateTimeKind.Utc).AddTicks(2886));

            migrationBuilder.UpdateData(
                table: "test_plan_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 109, DateTimeKind.Utc).AddTicks(2887));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 109, DateTimeKind.Utc).AddTicks(4483));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 109, DateTimeKind.Utc).AddTicks(4485));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 109, DateTimeKind.Utc).AddTicks(4486));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 109, DateTimeKind.Utc).AddTicks(4487));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 109, DateTimeKind.Utc).AddTicks(5942));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 109, DateTimeKind.Utc).AddTicks(5944));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 109, DateTimeKind.Utc).AddTicks(5946));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 109, DateTimeKind.Utc).AddTicks(5947));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 109, DateTimeKind.Utc).AddTicks(5949));

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("99999999-9999-9999-9999-999999999999") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 18, 54, 11, 164, DateTimeKind.Utc).AddTicks(8633));

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "created_at", "documento_identidad", "email", "fecha_nacimiento", "full_name", "is_active", "password_hash", "PasswordResetToken", "PasswordResetTokenExpiryTime", "refresh_token", "refresh_token_expiry_time", "telefono", "updated_at", "username" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "11111111", "tester1@qams.local", new DateOnly(1995, 1, 1), "Tester Uno", true, "$2a$12$0jdJPZWmFkqBX5PmpGsjaeXoZqGvvD1fUOifS6Foj9guzZVPZzo.C", null, null, null, null, null, null, "tester1" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "22222222", "tester2@qams.local", new DateOnly(1996, 2, 2), "Tester Dos", true, "$2a$12$0jdJPZWmFkqBX5PmpGsjaeXoZqGvvD1fUOifS6Foj9guzZVPZzo.C", null, null, null, null, null, null, "tester2" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "33333333", "developer1@qams.local", new DateOnly(1993, 3, 3), "Desarrollador Uno", true, "$2a$12$0jdJPZWmFkqBX5PmpGsjaeXoZqGvvD1fUOifS6Foj9guzZVPZzo.C", null, null, null, null, null, null, "developer1" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "44444444", "developer2@qams.local", new DateOnly(1994, 4, 4), "Desarrollador Dos", true, "$2a$12$0jdJPZWmFkqBX5PmpGsjaeXoZqGvvD1fUOifS6Foj9guzZVPZzo.C", null, null, null, null, null, null, "developer2" }
                });

            migrationBuilder.InsertData(
                table: "user_roles",
                columns: new[] { "role_id", "user_id", "assigned_at", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "UpdatedAt", "UpdatedByUserId" },
                values: new object[,]
                {
                    { new Guid("22222222-2222-2222-2222-222222222222"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 1, 18, 54, 11, 164, DateTimeKind.Utc).AddTicks(8644), null, null, null, null, null },
                    { new Guid("22222222-2222-2222-2222-222222222222"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 1, 18, 54, 11, 164, DateTimeKind.Utc).AddTicks(8646), null, null, null, null, null },
                    { new Guid("44444444-4444-4444-4444-444444444444"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 1, 18, 54, 11, 164, DateTimeKind.Utc).AddTicks(8648), null, null, null, null, null },
                    { new Guid("44444444-4444-4444-4444-444444444444"), new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 8, 1, 18, 54, 11, 164, DateTimeKind.Utc).AddTicks(8650), null, null, null, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("22222222-2222-2222-2222-222222222222"), new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.DeleteData(
                table: "user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("22222222-2222-2222-2222-222222222222"), new Guid("22222222-2222-2222-2222-222222222222") });

            migrationBuilder.DeleteData(
                table: "user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("44444444-4444-4444-4444-444444444444"), new Guid("33333333-3333-3333-3333-333333333333") });

            migrationBuilder.DeleteData(
                table: "user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("44444444-4444-4444-4444-444444444444"), new Guid("44444444-4444-4444-4444-444444444444") });

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

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
        }
    }
}
