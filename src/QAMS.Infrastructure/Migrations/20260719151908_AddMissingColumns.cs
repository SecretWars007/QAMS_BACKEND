using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QAMS.Infrastructure.Migrations
{
    public partial class AddMissingColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE test_steps ADD COLUMN IF NOT EXISTS created_by_user_id uuid NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';");
            migrationBuilder.Sql("ALTER TABLE test_executions ADD COLUMN IF NOT EXISTS actual_time_hours numeric(10,2) NOT NULL DEFAULT 0.0;");
            migrationBuilder.Sql("ALTER TABLE projects ADD COLUMN IF NOT EXISTS executed_hours numeric(10,2) NOT NULL DEFAULT 0.0;");
            migrationBuilder.Sql("ALTER TABLE projects ADD COLUMN IF NOT EXISTS remaining_hours numeric(10,2) NOT NULL DEFAULT 0.0;");
            migrationBuilder.Sql("ALTER TABLE projects ADD COLUMN IF NOT EXISTS work_hours_per_day integer NOT NULL DEFAULT 7;");
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
