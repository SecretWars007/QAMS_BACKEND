using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QAMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPasswordResetFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PasswordResetToken",
                table: "users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PasswordResetTokenExpiryTime",
                table: "users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 3, 14, 23, 23, 6, 71, DateTimeKind.Utc).AddTicks(2525));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 3, 14, 23, 23, 6, 71, DateTimeKind.Utc).AddTicks(2532));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 3, 14, 23, 23, 6, 71, DateTimeKind.Utc).AddTicks(2536));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 3, 14, 23, 23, 6, 71, DateTimeKind.Utc).AddTicks(2539));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 3, 14, 23, 23, 6, 72, DateTimeKind.Utc).AddTicks(3419));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 3, 14, 23, 23, 6, 72, DateTimeKind.Utc).AddTicks(3427));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 3, 14, 23, 23, 6, 72, DateTimeKind.Utc).AddTicks(3431));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 3, 14, 23, 23, 6, 72, DateTimeKind.Utc).AddTicks(3434));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 5,
                column: "created_at",
                value: new DateTime(2026, 3, 14, 23, 23, 6, 72, DateTimeKind.Utc).AddTicks(3436));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 6,
                column: "created_at",
                value: new DateTime(2026, 3, 14, 23, 23, 6, 72, DateTimeKind.Utc).AddTicks(3439));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 14, 23, 23, 6, 67, DateTimeKind.Utc).AddTicks(6320));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 14, 23, 23, 6, 67, DateTimeKind.Utc).AddTicks(6325));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 14, 23, 23, 6, 67, DateTimeKind.Utc).AddTicks(6333));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 14, 23, 23, 6, 67, DateTimeKind.Utc).AddTicks(6335));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 14, 23, 23, 6, 67, DateTimeKind.Utc).AddTicks(6337));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 3, 14, 23, 23, 6, 86, DateTimeKind.Utc).AddTicks(6208));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 3, 14, 23, 23, 6, 86, DateTimeKind.Utc).AddTicks(6212));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 3, 14, 23, 23, 6, 86, DateTimeKind.Utc).AddTicks(6214));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 3, 14, 23, 23, 6, 86, DateTimeKind.Utc).AddTicks(6215));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 3, 14, 23, 23, 6, 86, DateTimeKind.Utc).AddTicks(9794));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 3, 14, 23, 23, 6, 86, DateTimeKind.Utc).AddTicks(9798));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 3, 14, 23, 23, 6, 86, DateTimeKind.Utc).AddTicks(9799));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 3, 14, 23, 23, 6, 86, DateTimeKind.Utc).AddTicks(9800));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 3, 14, 23, 23, 6, 91, DateTimeKind.Utc).AddTicks(9076));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 3, 14, 23, 23, 6, 91, DateTimeKind.Utc).AddTicks(9083));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 3, 14, 23, 23, 6, 91, DateTimeKind.Utc).AddTicks(9085));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 3, 14, 23, 23, 6, 91, DateTimeKind.Utc).AddTicks(9086));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 14, 23, 23, 6, 67, DateTimeKind.Utc).AddTicks(8424));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 14, 23, 23, 6, 67, DateTimeKind.Utc).AddTicks(8425));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 14, 23, 23, 6, 67, DateTimeKind.Utc).AddTicks(8426));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 14, 23, 23, 6, 67, DateTimeKind.Utc).AddTicks(8427));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 14, 23, 23, 6, 68, DateTimeKind.Utc).AddTicks(305));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 14, 23, 23, 6, 68, DateTimeKind.Utc).AddTicks(308));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 14, 23, 23, 6, 68, DateTimeKind.Utc).AddTicks(309));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 14, 23, 23, 6, 68, DateTimeKind.Utc).AddTicks(353));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 14, 23, 23, 6, 68, DateTimeKind.Utc).AddTicks(354));

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
                columns: new[] { "PasswordResetToken", "PasswordResetTokenExpiryTime" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordResetToken",
                table: "users");

            migrationBuilder.DropColumn(
                name: "PasswordResetTokenExpiryTime",
                table: "users");

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 3, 21, 16, 580, DateTimeKind.Utc).AddTicks(1892));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 3, 21, 16, 580, DateTimeKind.Utc).AddTicks(1896));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 3, 21, 16, 580, DateTimeKind.Utc).AddTicks(1898));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 3, 21, 16, 580, DateTimeKind.Utc).AddTicks(1899));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 3, 21, 16, 581, DateTimeKind.Utc).AddTicks(6058));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 3, 21, 16, 581, DateTimeKind.Utc).AddTicks(6063));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 3, 21, 16, 581, DateTimeKind.Utc).AddTicks(6065));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 3, 21, 16, 581, DateTimeKind.Utc).AddTicks(6066));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 5,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 3, 21, 16, 581, DateTimeKind.Utc).AddTicks(6067));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 6,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 3, 21, 16, 581, DateTimeKind.Utc).AddTicks(6068));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 25, 3, 21, 16, 575, DateTimeKind.Utc).AddTicks(2245));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 25, 3, 21, 16, 575, DateTimeKind.Utc).AddTicks(2248));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 25, 3, 21, 16, 575, DateTimeKind.Utc).AddTicks(2250));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 25, 3, 21, 16, 575, DateTimeKind.Utc).AddTicks(2251));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 25, 3, 21, 16, 575, DateTimeKind.Utc).AddTicks(2253));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 3, 21, 16, 608, DateTimeKind.Utc).AddTicks(1562));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 3, 21, 16, 608, DateTimeKind.Utc).AddTicks(1567));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 3, 21, 16, 608, DateTimeKind.Utc).AddTicks(1569));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 3, 21, 16, 608, DateTimeKind.Utc).AddTicks(1570));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 3, 21, 16, 610, DateTimeKind.Utc).AddTicks(1696));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 3, 21, 16, 610, DateTimeKind.Utc).AddTicks(1700));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 3, 21, 16, 610, DateTimeKind.Utc).AddTicks(1702));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 3, 21, 16, 610, DateTimeKind.Utc).AddTicks(1703));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 3, 21, 16, 616, DateTimeKind.Utc).AddTicks(9099));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 3, 21, 16, 616, DateTimeKind.Utc).AddTicks(9105));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 3, 21, 16, 616, DateTimeKind.Utc).AddTicks(9106));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 25, 3, 21, 16, 616, DateTimeKind.Utc).AddTicks(9108));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 25, 3, 21, 16, 575, DateTimeKind.Utc).AddTicks(6030));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 25, 3, 21, 16, 575, DateTimeKind.Utc).AddTicks(6032));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 25, 3, 21, 16, 575, DateTimeKind.Utc).AddTicks(6034));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 25, 3, 21, 16, 575, DateTimeKind.Utc).AddTicks(6035));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 25, 3, 21, 16, 576, DateTimeKind.Utc).AddTicks(68));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 25, 3, 21, 16, 576, DateTimeKind.Utc).AddTicks(70));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 25, 3, 21, 16, 576, DateTimeKind.Utc).AddTicks(72));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 25, 3, 21, 16, 576, DateTimeKind.Utc).AddTicks(74));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 25, 3, 21, 16, 576, DateTimeKind.Utc).AddTicks(76));
        }
    }
}
