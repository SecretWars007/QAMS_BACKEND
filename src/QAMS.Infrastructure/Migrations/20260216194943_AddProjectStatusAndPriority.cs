using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QAMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddProjectStatusAndPriority : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_projects_users_created_by_user_id",
                table: "projects");

            migrationBuilder.AddColumn<int>(
                name: "priority",
                table: "projects",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "project_status_id",
                table: "projects",
                type: "integer",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateTable(
                name: "project_statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project_statuses", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 19, 49, 43, 243, DateTimeKind.Utc).AddTicks(147));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 19, 49, 43, 243, DateTimeKind.Utc).AddTicks(149));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 19, 49, 43, 243, DateTimeKind.Utc).AddTicks(150));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 19, 49, 43, 243, DateTimeKind.Utc).AddTicks(151));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 19, 49, 43, 243, DateTimeKind.Utc).AddTicks(2333));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 19, 49, 43, 243, DateTimeKind.Utc).AddTicks(2335));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 19, 49, 43, 243, DateTimeKind.Utc).AddTicks(2336));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 19, 49, 43, 243, DateTimeKind.Utc).AddTicks(2337));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 5,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 19, 49, 43, 243, DateTimeKind.Utc).AddTicks(2339));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 6,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 19, 49, 43, 243, DateTimeKind.Utc).AddTicks(2340));

            migrationBuilder.InsertData(
                table: "project_statuses",
                columns: new[] { "Id", "Code", "CreatedAt", "Description", "IsActive", "Name", "SortOrder" },
                values: new object[,]
                {
                    { 1, "PENDIENTE", new DateTime(2026, 2, 16, 19, 49, 43, 242, DateTimeKind.Utc).AddTicks(7338), "Proyecto registrado pero no iniciado", true, "Pendiente", 1 },
                    { 2, "EN_PROCESO", new DateTime(2026, 2, 16, 19, 49, 43, 242, DateTimeKind.Utc).AddTicks(7340), "Proyecto en ejecución activa", true, "En Proceso", 2 },
                    { 3, "DETENIDO", new DateTime(2026, 2, 16, 19, 49, 43, 242, DateTimeKind.Utc).AddTicks(7342), "Proyecto pausado o cancelado temporalmente", true, "Detenido", 3 },
                    { 4, "CERTIFICADO", new DateTime(2026, 2, 16, 19, 49, 43, 242, DateTimeKind.Utc).AddTicks(7343), "Proyecto completado y validado", true, "Certificado", 4 }
                });

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 19, 49, 43, 245, DateTimeKind.Utc).AddTicks(3375));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 19, 49, 43, 245, DateTimeKind.Utc).AddTicks(3377));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 19, 49, 43, 245, DateTimeKind.Utc).AddTicks(3378));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 19, 49, 43, 245, DateTimeKind.Utc).AddTicks(3379));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 19, 49, 43, 254, DateTimeKind.Utc).AddTicks(4758));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 19, 49, 43, 254, DateTimeKind.Utc).AddTicks(4771));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 19, 49, 43, 254, DateTimeKind.Utc).AddTicks(4772));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 19, 49, 43, 254, DateTimeKind.Utc).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 19, 49, 43, 255, DateTimeKind.Utc).AddTicks(296));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 19, 49, 43, 255, DateTimeKind.Utc).AddTicks(298));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 19, 49, 43, 255, DateTimeKind.Utc).AddTicks(299));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 19, 49, 43, 255, DateTimeKind.Utc).AddTicks(300));

            migrationBuilder.CreateIndex(
                name: "IX_projects_project_status_id",
                table: "projects",
                column: "project_status_id");

            migrationBuilder.AddForeignKey(
                name: "FK_projects_project_statuses_project_status_id",
                table: "projects",
                column: "project_status_id",
                principalTable: "project_statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_projects_users_created_by_user_id",
                table: "projects",
                column: "created_by_user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_projects_project_statuses_project_status_id",
                table: "projects");

            migrationBuilder.DropForeignKey(
                name: "FK_projects_users_created_by_user_id",
                table: "projects");

            migrationBuilder.DropTable(
                name: "project_statuses");

            migrationBuilder.DropIndex(
                name: "IX_projects_project_status_id",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "priority",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "project_status_id",
                table: "projects");

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 18, 51, 4, 47, DateTimeKind.Utc).AddTicks(3859));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 18, 51, 4, 47, DateTimeKind.Utc).AddTicks(3861));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 18, 51, 4, 47, DateTimeKind.Utc).AddTicks(3863));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 18, 51, 4, 47, DateTimeKind.Utc).AddTicks(3864));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 18, 51, 4, 47, DateTimeKind.Utc).AddTicks(6764));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 18, 51, 4, 47, DateTimeKind.Utc).AddTicks(6766));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 18, 51, 4, 47, DateTimeKind.Utc).AddTicks(6767));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 18, 51, 4, 47, DateTimeKind.Utc).AddTicks(6768));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 5,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 18, 51, 4, 47, DateTimeKind.Utc).AddTicks(6769));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 6,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 18, 51, 4, 47, DateTimeKind.Utc).AddTicks(6770));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 18, 51, 4, 49, DateTimeKind.Utc).AddTicks(6927));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 18, 51, 4, 49, DateTimeKind.Utc).AddTicks(6929));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 18, 51, 4, 49, DateTimeKind.Utc).AddTicks(6931));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 18, 51, 4, 49, DateTimeKind.Utc).AddTicks(6932));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 18, 51, 4, 49, DateTimeKind.Utc).AddTicks(8992));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 18, 51, 4, 49, DateTimeKind.Utc).AddTicks(8994));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 18, 51, 4, 49, DateTimeKind.Utc).AddTicks(8995));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 18, 51, 4, 49, DateTimeKind.Utc).AddTicks(8996));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 18, 51, 4, 50, DateTimeKind.Utc).AddTicks(865));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 18, 51, 4, 50, DateTimeKind.Utc).AddTicks(867));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 18, 51, 4, 50, DateTimeKind.Utc).AddTicks(868));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 2, 16, 18, 51, 4, 50, DateTimeKind.Utc).AddTicks(869));

            migrationBuilder.AddForeignKey(
                name: "FK_projects_users_created_by_user_id",
                table: "projects",
                column: "created_by_user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
