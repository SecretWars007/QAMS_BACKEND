using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QAMS.Infrastructure.Migrations
{
    public partial class AddMissingColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "created_by_user_id",
                table: "test_steps",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<decimal>(
                name: "actual_time_hours",
                table: "test_executions",
                type: "numeric(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "executed_hours",
                table: "projects",
                type: "numeric(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "remaining_hours",
                table: "projects",
                type: "numeric(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "work_hours_per_day",
                table: "projects",
                type: "integer",
                nullable: false,
                defaultValue: 7);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_by_user_id",
                table: "test_steps");

            migrationBuilder.DropColumn(
                name: "actual_time_hours",
                table: "test_executions");

            migrationBuilder.DropColumn(
                name: "executed_hours",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "remaining_hours",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "work_hours_per_day",
                table: "projects");
        }
    }
}
