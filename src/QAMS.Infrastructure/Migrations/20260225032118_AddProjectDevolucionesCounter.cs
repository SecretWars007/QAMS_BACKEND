using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QAMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddProjectDevolucionesCounter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "devoluciones_counter",
                table: "projects",
                type: "integer",
                nullable: false,
                defaultValue: 0);


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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "devoluciones_counter",
                table: "projects",
                newName: "DevolucionesCounter");

            migrationBuilder.AlterColumn<int>(
                name: "DevolucionesCounter",
                table: "projects",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 0);

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
        }
    }
}
