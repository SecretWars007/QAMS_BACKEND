using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QAMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTestPlanToTestExecution : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "test_plan_id",
                table: "test_executions",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_test_executions_test_plan_id",
                table: "test_executions",
                column: "test_plan_id");

            migrationBuilder.AddForeignKey(
                name: "fk_test_executions_test_plans_test_plan_id",
                table: "test_executions",
                column: "test_plan_id",
                principalTable: "test_plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_test_executions_test_plans_test_plan_id",
                table: "test_executions");

            migrationBuilder.DropIndex(
                name: "ix_test_executions_test_plan_id",
                table: "test_executions");

            migrationBuilder.DropColumn(
                name: "test_plan_id",
                table: "test_executions");
        }
    }
}
