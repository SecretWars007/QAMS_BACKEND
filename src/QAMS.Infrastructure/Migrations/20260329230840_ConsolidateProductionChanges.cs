using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QAMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ConsolidateProductionChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_execution_step_observations_users_CreatedByUserId",
                table: "execution_step_observations");

            migrationBuilder.DropForeignKey(
                name: "FK_KanbanBoards_projects_ProjectId",
                table: "KanbanBoards");

            migrationBuilder.DropForeignKey(
                name: "FK_KanbanColumns_KanbanBoards_KanbanBoardId",
                table: "KanbanColumns");

            migrationBuilder.DropForeignKey(
                name: "FK_KanbanTasks_KanbanColumns_KanbanColumnId",
                table: "KanbanTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_KanbanTasks_task_priorities_PriorityId",
                table: "KanbanTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_KanbanTasks_test_cases_TestCaseId",
                table: "KanbanTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_KanbanTasks_users_AssigneeId",
                table: "KanbanTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_project_devolutions_users_CreatedByUserId",
                table: "project_devolutions");

            migrationBuilder.DropForeignKey(
                name: "FK_project_observation_responses_users_CreatedByUserId",
                table: "project_observation_responses");

            migrationBuilder.DropForeignKey(
                name: "FK_project_observations_users_CreatedByUserId",
                table: "project_observations");

            migrationBuilder.DropForeignKey(
                name: "FK_test_case_certifiers_users_user_id",
                table: "test_case_certifiers");


            migrationBuilder.DropTable(
                name: "execution_step_observation_responses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KanbanTasks",
                table: "KanbanTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KanbanColumns",
                table: "KanbanColumns");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KanbanBoards",
                table: "KanbanBoards");

            migrationBuilder.DeleteData(
                table: "user_roles",
                keyColumns: ["role_id", "user_id"],
                keyValues: [new Guid("11111111-1111-1111-1111-111111111111"), new Guid("99999999-9999-9999-9999-999999999999")]);

            migrationBuilder.DropColumn(
                name: "PasswordResetToken",
                table: "users");

            migrationBuilder.DropColumn(
                name: "PasswordResetTokenExpiryTime",
                table: "users");

            migrationBuilder.RenameTable(
                name: "KanbanTasks",
                newName: "kanban_tasks");

            migrationBuilder.RenameTable(
                name: "KanbanColumns",
                newName: "kanban_columns");

            migrationBuilder.RenameTable(
                name: "KanbanBoards",
                newName: "kanban_boards");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "kanban_tasks",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "kanban_tasks",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "kanban_tasks",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "kanban_tasks",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "TestCaseId",
                table: "kanban_tasks",
                newName: "test_case_id");

            migrationBuilder.RenameColumn(
                name: "PriorityId",
                table: "kanban_tasks",
                newName: "priority_id");

            migrationBuilder.RenameColumn(
                name: "OrderIndex",
                table: "kanban_tasks",
                newName: "order_index");

            migrationBuilder.RenameColumn(
                name: "KanbanColumnId",
                table: "kanban_tasks",
                newName: "kanban_column_id");

            migrationBuilder.RenameColumn(
                name: "DueDate",
                table: "kanban_tasks",
                newName: "due_date");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "kanban_tasks",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "AssigneeId",
                table: "kanban_tasks",
                newName: "assignee_id");

            migrationBuilder.RenameIndex(
                name: "IX_KanbanTasks_TestCaseId",
                table: "kanban_tasks",
                newName: "IX_kanban_tasks_test_case_id");

            migrationBuilder.RenameIndex(
                name: "IX_KanbanTasks_PriorityId",
                table: "kanban_tasks",
                newName: "IX_kanban_tasks_priority_id");

            migrationBuilder.RenameIndex(
                name: "IX_KanbanTasks_KanbanColumnId",
                table: "kanban_tasks",
                newName: "IX_kanban_tasks_kanban_column_id");

            migrationBuilder.RenameIndex(
                name: "IX_KanbanTasks_AssigneeId",
                table: "kanban_tasks",
                newName: "IX_kanban_tasks_assignee_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "kanban_columns",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "kanban_columns",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "OrderIndex",
                table: "kanban_columns",
                newName: "order_index");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "kanban_columns",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "KanbanBoardId",
                table: "kanban_columns",
                newName: "board_id");

            migrationBuilder.RenameIndex(
                name: "IX_KanbanColumns_KanbanBoardId",
                table: "kanban_columns",
                newName: "IX_kanban_columns_board_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "kanban_boards",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "kanban_boards",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "kanban_boards",
                newName: "project_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "kanban_boards",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_KanbanBoards_ProjectId",
                table: "kanban_boards",
                newName: "IX_kanban_boards_project_id");

            migrationBuilder.AddColumn<string>(
                name: "documento_identidad",
                table: "users",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "fecha_nacimiento",
                table: "users",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "telefono",
                table: "users",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "user_roles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUserId",
                table: "user_roles",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "user_roles",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedByUserId",
                table: "user_roles",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "user_roles",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "user_roles",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedByUserId",
                table: "user_roles",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUserId",
                table: "test_types",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "test_types",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedByUserId",
                table: "test_types",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "test_types",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "test_types",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedByUserId",
                table: "test_types",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "test_suites",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()");

            migrationBuilder.AddColumn<Guid>(
                name: "created_by_user_id",
                table: "test_suites",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                table: "test_suites",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "deleted_by_user_id",
                table: "test_suites",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "test_suites",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "test_suites",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "updated_by_user_id",
                table: "test_suites",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUserId",
                table: "test_suite_statuses",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "test_suite_statuses",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedByUserId",
                table: "test_suite_statuses",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "test_suite_statuses",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "test_suite_statuses",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedByUserId",
                table: "test_suite_statuses",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "expected_result",
                table: "test_steps",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "action",
                table: "test_steps",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "test_steps",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "test_steps",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedByUserId",
                table: "test_steps",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "test_steps",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "test_steps",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedByUserId",
                table: "test_steps",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "execution_date",
                table: "test_executions",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "test_executions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "created_by_user_id",
                table: "test_executions",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                table: "test_executions",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "deleted_by_user_id",
                table: "test_executions",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "test_executions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "test_executions",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "updated_by_user_id",
                table: "test_executions",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "preconditions",
                table: "test_cases",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "test_cases",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "test_cases",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                table: "test_cases",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "deleted_by_user_id",
                table: "test_cases",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "test_cases",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "updated_by_user_id",
                table: "test_cases",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUserId",
                table: "test_case_priorities",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "test_case_priorities",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedByUserId",
                table: "test_case_priorities",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "test_case_priorities",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "test_case_priorities",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedByUserId",
                table: "test_case_priorities",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "test_case_certifiers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUserId",
                table: "test_case_certifiers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "test_case_certifiers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedByUserId",
                table: "test_case_certifiers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "test_case_certifiers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "test_case_certifiers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedByUserId",
                table: "test_case_certifiers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUserId",
                table: "task_priorities",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "task_priorities",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedByUserId",
                table: "task_priorities",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "task_priorities",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "task_priorities",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedByUserId",
                table: "task_priorities",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUserId",
                table: "step_result_statuses",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "step_result_statuses",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedByUserId",
                table: "step_result_statuses",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "step_result_statuses",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "step_result_statuses",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedByUserId",
                table: "step_result_statuses",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUserId",
                table: "roles",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "roles",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedByUserId",
                table: "roles",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "roles",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "roles",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedByUserId",
                table: "roles",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "role_permissions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUserId",
                table: "role_permissions",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "role_permissions",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedByUserId",
                table: "role_permissions",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "role_permissions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "role_permissions",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedByUserId",
                table: "role_permissions",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "priority",
                table: "projects",
                type: "text",
                nullable: false,
                defaultValue: "Medium",
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "projects",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "projects",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "budget",
                table: "projects",
                type: "numeric(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                table: "projects",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "deleted_by_user_id",
                table: "projects",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "projects",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "leader_id",
                table: "projects",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "risks",
                table: "projects",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "updated_by_user_id",
                table: "projects",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "version",
                table: "projects",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "1.0");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "project_testers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUserId",
                table: "project_testers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "project_testers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedByUserId",
                table: "project_testers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "project_testers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "project_testers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedByUserId",
                table: "project_testers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUserId",
                table: "project_statuses",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "project_statuses",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedByUserId",
                table: "project_statuses",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "project_statuses",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "project_statuses",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedByUserId",
                table: "project_statuses",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedByUserId",
                table: "project_observations",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "project_observations",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedByUserId",
                table: "project_observations",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "project_observations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsResolved",
                table: "project_observations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "project_observations",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedByUserId",
                table: "project_observations",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedByUserId",
                table: "project_observation_responses",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "project_observation_responses",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedByUserId",
                table: "project_observation_responses",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "project_observation_responses",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "project_observation_responses",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedByUserId",
                table: "project_observation_responses",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedByUserId",
                table: "project_devolutions",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "project_devolutions",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedByUserId",
                table: "project_devolutions",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "project_devolutions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "project_devolutions",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedByUserId",
                table: "project_devolutions",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "permissions",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUserId",
                table: "permissions",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "permissions",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedByUserId",
                table: "permissions",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "permissions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "permissions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "permissions",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedByUserId",
                table: "permissions",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "execution_step_results",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUserId",
                table: "execution_step_results",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "execution_step_results",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedByUserId",
                table: "execution_step_results",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "execution_step_results",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "execution_step_results",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedByUserId",
                table: "execution_step_results",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedByUserId",
                table: "execution_step_observations",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "execution_step_observations",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedByUserId",
                table: "execution_step_observations",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "execution_step_observations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "execution_step_observations",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedByUserId",
                table: "execution_step_observations",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUserId",
                table: "execution_statuses",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "execution_statuses",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedByUserId",
                table: "execution_statuses",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "execution_statuses",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "execution_statuses",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedByUserId",
                table: "execution_statuses",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "content_type",
                table: "evidences",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "evidences",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUserId",
                table: "evidences",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "evidences",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedByUserId",
                table: "evidences",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "evidences",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "evidences",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedByUserId",
                table: "evidences",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUserId",
                table: "evidence_types",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "evidence_types",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedByUserId",
                table: "evidence_types",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "evidence_types",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "evidence_types",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedByUserId",
                table: "evidence_types",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "kanban_tasks",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "kanban_tasks",
                type: "character varying(2000)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaskPriorityId",
                table: "kanban_tasks",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "created_by_user_id",
                table: "kanban_tasks",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                table: "kanban_tasks",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "deleted_by_user_id",
                table: "kanban_tasks",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "kanban_tasks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "updated_by_user_id",
                table: "kanban_tasks",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "kanban_columns",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<Guid>(
                name: "created_by_user_id",
                table: "kanban_columns",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                table: "kanban_columns",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "deleted_by_user_id",
                table: "kanban_columns",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "kanban_columns",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "kanban_columns",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "updated_by_user_id",
                table: "kanban_columns",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "kanban_boards",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<Guid>(
                name: "created_by_user_id",
                table: "kanban_boards",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                table: "kanban_boards",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "deleted_by_user_id",
                table: "kanban_boards",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "kanban_boards",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "kanban_boards",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "updated_by_user_id",
                table: "kanban_boards",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_kanban_tasks",
                table: "kanban_tasks",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_kanban_columns",
                table: "kanban_columns",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_kanban_boards",
                table: "kanban_boards",
                column: "id");

            migrationBuilder.CreateTable(
                name: "requirements",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    project_id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    acceptance_criteria = table.Column<string>(type: "text", nullable: true),
                    type = table.Column<string>(type: "text", nullable: false, defaultValue: "Functional"),
                    priority = table.Column<string>(type: "text", nullable: false, defaultValue: "Medium"),
                    complexity = table.Column<string>(type: "text", nullable: false, defaultValue: "Medium"),
                    status = table.Column<string>(type: "text", nullable: false, defaultValue: "Pending"),
                    source = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_by_user_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by_user_id = table.Column<Guid>(type: "uuid", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_by_user_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requirements", x => x.id);
                    table.ForeignKey(
                        name: "FK_requirements_projects_project_id",
                        column: x => x.project_id,
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_requirements_users_created_by_user_id",
                        column: x => x.created_by_user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_requirements_users_deleted_by_user_id",
                        column: x => x.deleted_by_user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_requirements_users_updated_by_user_id",
                        column: x => x.updated_by_user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 1,
                columns: ["created_at", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId"],
                values: [new DateTime(2026, 3, 29, 23, 8, 39, 499, DateTimeKind.Utc).AddTicks(5184), null, null, null, false, null, null]);

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 499, DateTimeKind.Utc).AddTicks(5191), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 3,
                columns: ["created_at", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId"],
                values: [new DateTime(2026, 3, 29, 23, 8, 39, 499, DateTimeKind.Utc).AddTicks(5193), null, null, null, false, null, null]);

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "created_at", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 499, DateTimeKind.Utc).AddTicks(5195), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 499, DateTimeKind.Utc).AddTicks(9984), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 499, DateTimeKind.Utc).AddTicks(9995), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "created_at", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 499, DateTimeKind.Utc).AddTicks(9997), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "created_at", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 499, DateTimeKind.Utc).AddTicks(9999), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "created_at", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 500, DateTimeKind.Utc), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "created_at", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 500, DateTimeKind.Utc).AddTicks(2), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("41544143-4f4c-5347-5f4d-414e41474500"),
                columns: new[] { "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "Name", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { null, null, null, false, "", null, null });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("41544143-4f4c-5347-5f56-494557000000"),
                columns: new[] { "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "Name", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { null, null, null, false, "", null, null });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("424e414b-4e41-435f-5245-415445000000"),
                columns: new[] { "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "Name", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { null, null, null, false, "", null, null });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("424e414b-4e41-445f-454c-455445000000"),
                columns: new[] { "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "Name", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { null, null, null, false, "", null, null });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("424e414b-4e41-555f-5044-415445000000"),
                columns: new[] { "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "Name", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { null, null, null, false, "", null, null });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("424e414b-4e41-565f-4945-570000000000"),
                columns: new[] { "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "Name", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { null, null, null, false, "", null, null });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("43455845-5455-4f49-4e53-5f4352454154"),
                columns: new[] { "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "Name", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { null, null, null, false, "", null, null });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("43455845-5455-4f49-4e53-5f5550444154"),
                columns: new[] { "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "Name", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { null, null, null, false, "", null, null });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("43455845-5455-4f49-4e53-5f55504c4f41"),
                columns: new[] { "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "Name", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { null, null, null, false, "", null, null });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("43455845-5455-4f49-4e53-5f5649455700"),
                columns: new[] { "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "Name", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { null, null, null, false, "", null, null });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("454c4f52-5f53-4544-4c45-544500000000"),
                columns: new[] { "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "Name", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { null, null, null, false, "", null, null });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("454c4f52-5f53-4956-4557-000000000000"),
                columns: new[] { "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "Name", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { null, null, null, false, "", null, null });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("454c4f52-5f53-5055-4441-544500000000"),
                columns: new[] { "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "Name", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { null, null, null, false, "", null, null });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("454c4f52-5f53-5243-4541-544500000000"),
                columns: new[] { "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "Name", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { null, null, null, false, "", null, null });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("454c4f52-5f53-5341-5349-474e5f504552"),
                columns: new[] { "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "Name", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { null, null, null, false, "", null, null });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("48534144-4f42-5241-445f-564945570000"),
                columns: new[] { "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "Name", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { null, null, null, false, "", null, null });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("4a4f5250-4345-5354-5f43-524541544500"),
                columns: new[] { "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "Name", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { null, null, null, false, "", null, null });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("4a4f5250-4345-5354-5f44-454c45544500"),
                columns: new[] { "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "Name", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { null, null, null, false, "", null, null });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("4a4f5250-4345-5354-5f55-504441544500"),
                columns: new[] { "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "Name", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { null, null, null, false, "", null, null });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("4a4f5250-4345-5354-5f56-494557000000"),
                columns: new[] { "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "Name", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { null, null, null, false, "", null, null });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("52455355-5f53-4544-4c45-544500000000"),
                columns: new[] { "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "Name", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { null, null, null, false, "", null, null });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("52455355-5f53-4956-4557-000000000000"),
                columns: new[] { "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "Name", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { null, null, null, false, "", null, null });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("52455355-5f53-5055-4441-544500000000"),
                columns: new[] { "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "Name", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { null, null, null, false, "", null, null });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("52455355-5f53-5243-4541-544500000000"),
                columns: new[] { "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "Name", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { null, null, null, false, "", null, null });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("52455355-5f53-5341-5349-474e5f524f4c"),
                columns: new[] { "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "Name", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { null, null, null, false, "", null, null });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("54534554-435f-5341-4553-5f4352454154"),
                columns: new[] { "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "Name", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { null, null, null, false, "", null, null });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("54534554-435f-5341-4553-5f44454c4554"),
                columns: new[] { "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "Name", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { null, null, null, false, "", null, null });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("54534554-435f-5341-4553-5f5550444154"),
                columns: new[] { "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "Name", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { null, null, null, false, "", null, null });

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("54534554-435f-5341-4553-5f5649455700"),
                columns: new[] { "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "Name", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { null, null, null, false, "", null, null });

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 495, DateTimeKind.Utc).AddTicks(6275), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 495, DateTimeKind.Utc).AddTicks(6279), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 495, DateTimeKind.Utc).AddTicks(6282), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 495, DateTimeKind.Utc).AddTicks(6285), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 495, DateTimeKind.Utc).AddTicks(6288), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("41544143-4f4c-5347-5f4d-414e41474500"), new Guid("11111111-1111-1111-1111-111111111111") },
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2655), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("41544143-4f4c-5347-5f56-494557000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2635), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-435f-5245-415445000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2721), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-445f-454c-455445000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2726), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2723), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2718), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f4352454154"), new Guid("11111111-1111-1111-1111-111111111111") },
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2711), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5550444154"), new Guid("11111111-1111-1111-1111-111111111111") },
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2713), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f55504c4f41"), new Guid("11111111-1111-1111-1111-111111111111") },
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2715), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("11111111-1111-1111-1111-111111111111") },
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2708), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-4544-4c45-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2627), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-4956-4557-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2617), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-5055-4441-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2624), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-5243-4541-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2621), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-5341-5349-474e5f504552"), new Guid("11111111-1111-1111-1111-111111111111") },
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2630), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("11111111-1111-1111-1111-111111111111") },
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2729), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f43-524541544500"), new Guid("11111111-1111-1111-1111-111111111111") },
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2661), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f44-454c45544500"), new Guid("11111111-1111-1111-1111-111111111111") },
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2693), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f55-504441544500"), new Guid("11111111-1111-1111-1111-111111111111") },
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2664), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2659), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-4544-4c45-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2609), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-4956-4557-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(1699), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-5055-4441-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2602), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-5243-4541-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2376), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-5341-5349-474e5f524f4c"), new Guid("11111111-1111-1111-1111-111111111111") },
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2613), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f4352454154"), new Guid("11111111-1111-1111-1111-111111111111") },
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2700), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f44454c4554"), new Guid("11111111-1111-1111-1111-111111111111") },
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2706), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5550444154"), new Guid("11111111-1111-1111-1111-111111111111") },
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2703), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("11111111-1111-1111-1111-111111111111") },
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2698), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("41544143-4f4c-5347-5f56-494557000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2833), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2826), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2823), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f4352454154"), new Guid("22222222-2222-2222-2222-222222222222") },
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2815), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5550444154"), new Guid("22222222-2222-2222-2222-222222222222") },
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2818), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f55504c4f41"), new Guid("22222222-2222-2222-2222-222222222222") },
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2820), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("22222222-2222-2222-2222-222222222222") },
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2812), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("22222222-2222-2222-2222-222222222222") },
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2830), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2785), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("22222222-2222-2222-2222-222222222222") },
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2808), null, null, null, false, null, null });

            // migrationBuilder.UpdateData(
            //     table: "roles",
            //     keyColumn: "id",
            //     keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
            //     columns: new[] { "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
            //     values: new object[] { null, null, null, false, null, null });
            // 
            // migrationBuilder.UpdateData(
            //     table: "roles",
            //     keyColumn: "id",
            //     keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
            //     columns: new[] { "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
            //     values: new object[] { null, null, null, false, null, null });

            // migrationBuilder.InsertData(
            //     table: "roles",
            //     columns: new[] { "id", "created_at", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "description", "is_active", "IsDeleted", "name", "UpdatedAt", "UpdatedByUserId" },
            //     values: new object[,]
            //     {
            //         { new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, null, "Planifica suites, asigna tareas y genera reportes", true, false, "Líder de Pruebas (Lead)", null, null },
            //         { new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, null, "Revisa defectos asignados y actualiza código", true, false, "Desarrollador", null, null }
            //     });

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 569, DateTimeKind.Utc).AddTicks(3836), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 569, DateTimeKind.Utc).AddTicks(3846), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "created_at", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 569, DateTimeKind.Utc).AddTicks(3848), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "created_at", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 569, DateTimeKind.Utc).AddTicks(3850), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 571, DateTimeKind.Utc).AddTicks(8550), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 571, DateTimeKind.Utc).AddTicks(8555), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "created_at", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 571, DateTimeKind.Utc).AddTicks(8557), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "created_at", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 571, DateTimeKind.Utc).AddTicks(8559), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 605, DateTimeKind.Utc).AddTicks(933), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 605, DateTimeKind.Utc).AddTicks(938), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "created_at", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 605, DateTimeKind.Utc).AddTicks(940), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "created_at", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 605, DateTimeKind.Utc).AddTicks(942), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 496, DateTimeKind.Utc).AddTicks(147), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 496, DateTimeKind.Utc).AddTicks(150), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 496, DateTimeKind.Utc).AddTicks(152), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 496, DateTimeKind.Utc).AddTicks(154), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 496, DateTimeKind.Utc).AddTicks(2802), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 496, DateTimeKind.Utc).AddTicks(2805), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 496, DateTimeKind.Utc).AddTicks(2809), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 496, DateTimeKind.Utc).AddTicks(2812), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new DateTime(2026, 3, 29, 23, 8, 39, 496, DateTimeKind.Utc).AddTicks(2815), null, null, null, false, null, null });

            migrationBuilder.InsertData(
                table: "user_roles",
                columns: new[] { "role_id", "user_id", "assigned_at", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("99999999-9999-9999-9999-999999999999"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 3, 29, 23, 8, 39, 657, DateTimeKind.Utc).AddTicks(3424), null, null, null, false, null, null });

            // migrationBuilder.UpdateData(
            //     table: "users",
            //     keyColumn: "id",
            //     keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
            //     columns: new[] { "documento_identidad", "fecha_nacimiento", "telefono" },
            //     values: new object[] { "00000000", new DateOnly(1990, 1, 1), null });

            // migrationBuilder.InsertData(
            //     table: "role_permissions",
            //     columns: new[] { "permission_id", "role_id", "assigned_at", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
            //     values: new object[,]
            //     {
            //         { new Guid("41544143-4f4c-5347-5f56-494557000000"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2899), null, null, null, false, null, null },
            //         { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2892), null, null, null, false, null, null },
            //         { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2888), null, null, null, false, null, null },
            //         { new Guid("43455845-5455-4f49-4e53-5f4352454154"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2880), null, null, null, false, null, null },
            //         { new Guid("43455845-5455-4f49-4e53-5f5550444154"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2883), null, null, null, false, null, null },
            //         { new Guid("43455845-5455-4f49-4e53-5f55504c4f41"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2820), null, null, null, false, null, null },
            //         { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2877), null, null, null, false, null, null },
            //         { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2895), null, null, null, false, null, null },
            //         { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2851), null, null, null, false, null, null },
            //         { new Guid("54534554-435f-5341-4553-5f4352454154"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2858), null, null, null, false, null, null },
            //         { new Guid("54534554-435f-5341-4553-5f5550444154"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2873), null, null, null, false, null, null },
            //         { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2855), null, null, null, false, null, null },
            //         { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2918), null, null, null, false, null, null },
            //         { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2915), null, null, null, false, null, null },
            //         { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2912), null, null, null, false, null, null },
            //         { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2929), null, null, null, false, null, null },
            //         { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2904), null, null, null, false, null, null },
            //         { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 3, 29, 23, 8, 39, 567, DateTimeKind.Utc).AddTicks(2909), null, null, null, false, null, null }
            //     });

            // migrationBuilder.CreateIndex(
            //     name: "IX_users_documento_identidad_fecha_nacimiento",
            //     table: "users",
            //     columns: new[] { "documento_identidad", "fecha_nacimiento" },
            //     unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_roles_CreatedByUserId",
                table: "user_roles",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_roles_DeletedByUserId",
                table: "user_roles",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_roles_UpdatedByUserId",
                table: "user_roles",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_test_steps_DeletedByUserId",
                table: "test_steps",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_test_steps_UpdatedByUserId",
                table: "test_steps",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_test_executions_created_by_user_id",
                table: "test_executions",
                column: "created_by_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_test_executions_deleted_by_user_id",
                table: "test_executions",
                column: "deleted_by_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_test_executions_updated_by_user_id",
                table: "test_executions",
                column: "updated_by_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_test_cases_deleted_by_user_id",
                table: "test_cases",
                column: "deleted_by_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_test_cases_updated_by_user_id",
                table: "test_cases",
                column: "updated_by_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_test_cases_UserId",
                table: "test_cases",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_test_case_certifiers_CreatedByUserId",
                table: "test_case_certifiers",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_test_case_certifiers_DeletedByUserId",
                table: "test_case_certifiers",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_test_case_certifiers_UpdatedByUserId",
                table: "test_case_certifiers",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_roles_CreatedByUserId",
                table: "roles",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_roles_DeletedByUserId",
                table: "roles",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_roles_UpdatedByUserId",
                table: "roles",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_role_permissions_CreatedByUserId",
                table: "role_permissions",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_role_permissions_DeletedByUserId",
                table: "role_permissions",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_role_permissions_UpdatedByUserId",
                table: "role_permissions",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_projects_deleted_by_user_id",
                table: "projects",
                column: "deleted_by_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_projects_leader_id",
                table: "projects",
                column: "leader_id");

            migrationBuilder.CreateIndex(
                name: "IX_projects_updated_by_user_id",
                table: "projects",
                column: "updated_by_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_projects_UserId",
                table: "projects",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_project_testers_CreatedByUserId",
                table: "project_testers",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_project_testers_DeletedByUserId",
                table: "project_testers",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_project_testers_UpdatedByUserId",
                table: "project_testers",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_project_observations_DeletedByUserId",
                table: "project_observations",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_project_observations_UpdatedByUserId",
                table: "project_observations",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_project_observation_responses_DeletedByUserId",
                table: "project_observation_responses",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_project_observation_responses_UpdatedByUserId",
                table: "project_observation_responses",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_project_devolutions_DeletedByUserId",
                table: "project_devolutions",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_project_devolutions_UpdatedByUserId",
                table: "project_devolutions",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_permissions_CreatedByUserId",
                table: "permissions",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_permissions_DeletedByUserId",
                table: "permissions",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_permissions_UpdatedByUserId",
                table: "permissions",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_execution_step_observations_DeletedByUserId",
                table: "execution_step_observations",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_execution_step_observations_UpdatedByUserId",
                table: "execution_step_observations",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_evidences_CreatedByUserId",
                table: "evidences",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_evidences_DeletedByUserId",
                table: "evidences",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_evidences_UpdatedByUserId",
                table: "evidences",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_kanban_tasks_created_by_user_id",
                table: "kanban_tasks",
                column: "created_by_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_kanban_tasks_deleted_by_user_id",
                table: "kanban_tasks",
                column: "deleted_by_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_kanban_tasks_TaskPriorityId",
                table: "kanban_tasks",
                column: "TaskPriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_kanban_tasks_updated_by_user_id",
                table: "kanban_tasks",
                column: "updated_by_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_kanban_columns_created_by_user_id",
                table: "kanban_columns",
                column: "created_by_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_kanban_columns_deleted_by_user_id",
                table: "kanban_columns",
                column: "deleted_by_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_kanban_columns_updated_by_user_id",
                table: "kanban_columns",
                column: "updated_by_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_requirements_code",
                table: "requirements",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_requirements_created_by_user_id",
                table: "requirements",
                column: "created_by_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_requirements_deleted_by_user_id",
                table: "requirements",
                column: "deleted_by_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_requirements_project_id",
                table: "requirements",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "IX_requirements_updated_by_user_id",
                table: "requirements",
                column: "updated_by_user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_evidences_users_CreatedByUserId",
                table: "evidences",
                column: "CreatedByUserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_evidences_users_DeletedByUserId",
                table: "evidences",
                column: "DeletedByUserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_evidences_users_UpdatedByUserId",
                table: "evidences",
                column: "UpdatedByUserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_execution_step_observations_users_CreatedByUserId",
                table: "execution_step_observations",
                column: "CreatedByUserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_execution_step_observations_users_DeletedByUserId",
                table: "execution_step_observations",
                column: "DeletedByUserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_execution_step_observations_users_UpdatedByUserId",
                table: "execution_step_observations",
                column: "UpdatedByUserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_kanban_boards_projects_project_id",
                table: "kanban_boards",
                column: "project_id",
                principalTable: "projects",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_kanban_columns_kanban_boards_board_id",
                table: "kanban_columns",
                column: "board_id",
                principalTable: "kanban_boards",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_kanban_columns_users_created_by_user_id",
                table: "kanban_columns",
                column: "created_by_user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_kanban_columns_users_deleted_by_user_id",
                table: "kanban_columns",
                column: "deleted_by_user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_kanban_columns_users_updated_by_user_id",
                table: "kanban_columns",
                column: "updated_by_user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_kanban_tasks_kanban_columns_kanban_column_id",
                table: "kanban_tasks",
                column: "kanban_column_id",
                principalTable: "kanban_columns",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_kanban_tasks_task_priorities_TaskPriorityId",
                table: "kanban_tasks",
                column: "TaskPriorityId",
                principalTable: "task_priorities",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_kanban_tasks_test_case_priorities_priority_id",
                table: "kanban_tasks",
                column: "priority_id",
                principalTable: "test_case_priorities",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_kanban_tasks_test_cases_test_case_id",
                table: "kanban_tasks",
                column: "test_case_id",
                principalTable: "test_cases",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_kanban_tasks_users_assignee_id",
                table: "kanban_tasks",
                column: "assignee_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_kanban_tasks_users_created_by_user_id",
                table: "kanban_tasks",
                column: "created_by_user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_kanban_tasks_users_deleted_by_user_id",
                table: "kanban_tasks",
                column: "deleted_by_user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_kanban_tasks_users_updated_by_user_id",
                table: "kanban_tasks",
                column: "updated_by_user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_permissions_users_CreatedByUserId",
                table: "permissions",
                column: "CreatedByUserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_permissions_users_DeletedByUserId",
                table: "permissions",
                column: "DeletedByUserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_permissions_users_UpdatedByUserId",
                table: "permissions",
                column: "UpdatedByUserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_project_devolutions_users_CreatedByUserId",
                table: "project_devolutions",
                column: "CreatedByUserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_project_devolutions_users_DeletedByUserId",
                table: "project_devolutions",
                column: "DeletedByUserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_project_devolutions_users_UpdatedByUserId",
                table: "project_devolutions",
                column: "UpdatedByUserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_project_observation_responses_users_CreatedByUserId",
                table: "project_observation_responses",
                column: "CreatedByUserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_project_observation_responses_users_DeletedByUserId",
                table: "project_observation_responses",
                column: "DeletedByUserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_project_observation_responses_users_UpdatedByUserId",
                table: "project_observation_responses",
                column: "UpdatedByUserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_project_observations_users_CreatedByUserId",
                table: "project_observations",
                column: "CreatedByUserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_project_observations_users_DeletedByUserId",
                table: "project_observations",
                column: "DeletedByUserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_project_observations_users_UpdatedByUserId",
                table: "project_observations",
                column: "UpdatedByUserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_project_testers_users_CreatedByUserId",
                table: "project_testers",
                column: "CreatedByUserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_project_testers_users_DeletedByUserId",
                table: "project_testers",
                column: "DeletedByUserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_project_testers_users_UpdatedByUserId",
                table: "project_testers",
                column: "UpdatedByUserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_projects_users_UserId",
                table: "projects",
                column: "UserId",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_projects_users_deleted_by_user_id",
                table: "projects",
                column: "deleted_by_user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_projects_users_leader_id",
                table: "projects",
                column: "leader_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_projects_users_updated_by_user_id",
                table: "projects",
                column: "updated_by_user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_role_permissions_users_CreatedByUserId",
                table: "role_permissions",
                column: "CreatedByUserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_role_permissions_users_DeletedByUserId",
                table: "role_permissions",
                column: "DeletedByUserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_role_permissions_users_UpdatedByUserId",
                table: "role_permissions",
                column: "UpdatedByUserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_roles_users_CreatedByUserId",
                table: "roles",
                column: "CreatedByUserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_roles_users_DeletedByUserId",
                table: "roles",
                column: "DeletedByUserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_roles_users_UpdatedByUserId",
                table: "roles",
                column: "UpdatedByUserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_test_case_certifiers_users_CreatedByUserId",
                table: "test_case_certifiers",
                column: "CreatedByUserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_test_case_certifiers_users_DeletedByUserId",
                table: "test_case_certifiers",
                column: "DeletedByUserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_test_case_certifiers_users_UpdatedByUserId",
                table: "test_case_certifiers",
                column: "UpdatedByUserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_test_case_certifiers_users_user_id",
                table: "test_case_certifiers",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_test_cases_users_UserId",
                table: "test_cases",
                column: "UserId",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_test_cases_users_deleted_by_user_id",
                table: "test_cases",
                column: "deleted_by_user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_test_cases_users_updated_by_user_id",
                table: "test_cases",
                column: "updated_by_user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_test_executions_users_created_by_user_id",
                table: "test_executions",
                column: "created_by_user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_test_executions_users_deleted_by_user_id",
                table: "test_executions",
                column: "deleted_by_user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_test_executions_users_updated_by_user_id",
                table: "test_executions",
                column: "updated_by_user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_test_steps_users_DeletedByUserId",
                table: "test_steps",
                column: "DeletedByUserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_test_steps_users_UpdatedByUserId",
                table: "test_steps",
                column: "UpdatedByUserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);


            migrationBuilder.AddForeignKey(
                name: "FK_user_roles_users_CreatedByUserId",
                table: "user_roles",
                column: "CreatedByUserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_user_roles_users_DeletedByUserId",
                table: "user_roles",
                column: "DeletedByUserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_user_roles_users_UpdatedByUserId",
                table: "user_roles",
                column: "UpdatedByUserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_evidences_users_CreatedByUserId",
                table: "evidences");

            migrationBuilder.DropForeignKey(
                name: "FK_evidences_users_DeletedByUserId",
                table: "evidences");

            migrationBuilder.DropForeignKey(
                name: "FK_evidences_users_UpdatedByUserId",
                table: "evidences");

            migrationBuilder.DropForeignKey(
                name: "FK_execution_step_observations_users_CreatedByUserId",
                table: "execution_step_observations");

            migrationBuilder.DropForeignKey(
                name: "FK_execution_step_observations_users_DeletedByUserId",
                table: "execution_step_observations");

            migrationBuilder.DropForeignKey(
                name: "FK_execution_step_observations_users_UpdatedByUserId",
                table: "execution_step_observations");

            migrationBuilder.DropForeignKey(
                name: "FK_kanban_boards_projects_project_id",
                table: "kanban_boards");

            migrationBuilder.DropForeignKey(
                name: "FK_kanban_columns_kanban_boards_board_id",
                table: "kanban_columns");

            migrationBuilder.DropForeignKey(
                name: "FK_kanban_columns_users_created_by_user_id",
                table: "kanban_columns");

            migrationBuilder.DropForeignKey(
                name: "FK_kanban_columns_users_deleted_by_user_id",
                table: "kanban_columns");

            migrationBuilder.DropForeignKey(
                name: "FK_kanban_columns_users_updated_by_user_id",
                table: "kanban_columns");

            migrationBuilder.DropForeignKey(
                name: "FK_kanban_tasks_kanban_columns_kanban_column_id",
                table: "kanban_tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_kanban_tasks_task_priorities_TaskPriorityId",
                table: "kanban_tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_kanban_tasks_test_case_priorities_priority_id",
                table: "kanban_tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_kanban_tasks_test_cases_test_case_id",
                table: "kanban_tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_kanban_tasks_users_assignee_id",
                table: "kanban_tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_kanban_tasks_users_created_by_user_id",
                table: "kanban_tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_kanban_tasks_users_deleted_by_user_id",
                table: "kanban_tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_kanban_tasks_users_updated_by_user_id",
                table: "kanban_tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_permissions_users_CreatedByUserId",
                table: "permissions");

            migrationBuilder.DropForeignKey(
                name: "FK_permissions_users_DeletedByUserId",
                table: "permissions");

            migrationBuilder.DropForeignKey(
                name: "FK_permissions_users_UpdatedByUserId",
                table: "permissions");

            migrationBuilder.DropForeignKey(
                name: "FK_project_devolutions_users_CreatedByUserId",
                table: "project_devolutions");

            migrationBuilder.DropForeignKey(
                name: "FK_project_devolutions_users_DeletedByUserId",
                table: "project_devolutions");

            migrationBuilder.DropForeignKey(
                name: "FK_project_devolutions_users_UpdatedByUserId",
                table: "project_devolutions");

            migrationBuilder.DropForeignKey(
                name: "FK_project_observation_responses_users_CreatedByUserId",
                table: "project_observation_responses");

            migrationBuilder.DropForeignKey(
                name: "FK_project_observation_responses_users_DeletedByUserId",
                table: "project_observation_responses");

            migrationBuilder.DropForeignKey(
                name: "FK_project_observation_responses_users_UpdatedByUserId",
                table: "project_observation_responses");

            migrationBuilder.DropForeignKey(
                name: "FK_project_observations_users_CreatedByUserId",
                table: "project_observations");

            migrationBuilder.DropForeignKey(
                name: "FK_project_observations_users_DeletedByUserId",
                table: "project_observations");

            migrationBuilder.DropForeignKey(
                name: "FK_project_observations_users_UpdatedByUserId",
                table: "project_observations");

            migrationBuilder.DropForeignKey(
                name: "FK_project_testers_users_CreatedByUserId",
                table: "project_testers");

            migrationBuilder.DropForeignKey(
                name: "FK_project_testers_users_DeletedByUserId",
                table: "project_testers");

            migrationBuilder.DropForeignKey(
                name: "FK_project_testers_users_UpdatedByUserId",
                table: "project_testers");

            migrationBuilder.DropForeignKey(
                name: "FK_projects_users_UserId",
                table: "projects");

            migrationBuilder.DropForeignKey(
                name: "FK_projects_users_deleted_by_user_id",
                table: "projects");

            migrationBuilder.DropForeignKey(
                name: "FK_projects_users_leader_id",
                table: "projects");

            migrationBuilder.DropForeignKey(
                name: "FK_projects_users_updated_by_user_id",
                table: "projects");

            migrationBuilder.DropForeignKey(
                name: "FK_role_permissions_users_CreatedByUserId",
                table: "role_permissions");

            migrationBuilder.DropForeignKey(
                name: "FK_role_permissions_users_DeletedByUserId",
                table: "role_permissions");

            migrationBuilder.DropForeignKey(
                name: "FK_role_permissions_users_UpdatedByUserId",
                table: "role_permissions");

            migrationBuilder.DropForeignKey(
                name: "FK_roles_users_CreatedByUserId",
                table: "roles");

            migrationBuilder.DropForeignKey(
                name: "FK_roles_users_DeletedByUserId",
                table: "roles");

            migrationBuilder.DropForeignKey(
                name: "FK_roles_users_UpdatedByUserId",
                table: "roles");

            migrationBuilder.DropForeignKey(
                name: "FK_test_case_certifiers_users_CreatedByUserId",
                table: "test_case_certifiers");

            migrationBuilder.DropForeignKey(
                name: "FK_test_case_certifiers_users_DeletedByUserId",
                table: "test_case_certifiers");

            migrationBuilder.DropForeignKey(
                name: "FK_test_case_certifiers_users_UpdatedByUserId",
                table: "test_case_certifiers");

            migrationBuilder.DropForeignKey(
                name: "FK_test_case_certifiers_users_user_id",
                table: "test_case_certifiers");

            migrationBuilder.DropForeignKey(
                name: "FK_test_cases_users_UserId",
                table: "test_cases");

            migrationBuilder.DropForeignKey(
                name: "FK_test_cases_users_deleted_by_user_id",
                table: "test_cases");

            migrationBuilder.DropForeignKey(
                name: "FK_test_cases_users_updated_by_user_id",
                table: "test_cases");

            migrationBuilder.DropForeignKey(
                name: "FK_test_executions_users_created_by_user_id",
                table: "test_executions");

            migrationBuilder.DropForeignKey(
                name: "FK_test_executions_users_deleted_by_user_id",
                table: "test_executions");

            migrationBuilder.DropForeignKey(
                name: "FK_test_executions_users_updated_by_user_id",
                table: "test_executions");

            // migrationBuilder.DropForeignKey(
            //     name: "FK_test_steps_users_DeletedByUserId",
            //     table: "test_steps");
            // 
            // migrationBuilder.DropForeignKey(
            //     name: "FK_test_steps_users_UpdatedByUserId",
            //     table: "test_steps");
            // 
            // migrationBuilder.DropForeignKey(
            //     name: "FK_test_steps_users_created_by_user_id",
            //     table: "test_steps");

            migrationBuilder.DropForeignKey(
                name: "FK_user_roles_users_CreatedByUserId",
                table: "user_roles");

            migrationBuilder.DropForeignKey(
                name: "FK_user_roles_users_DeletedByUserId",
                table: "user_roles");

            migrationBuilder.DropForeignKey(
                name: "FK_user_roles_users_UpdatedByUserId",
                table: "user_roles");

            migrationBuilder.DropTable(
                name: "requirements");

            migrationBuilder.DropIndex(
                name: "IX_users_documento_identidad_fecha_nacimiento",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_user_roles_CreatedByUserId",
                table: "user_roles");

            migrationBuilder.DropIndex(
                name: "IX_user_roles_DeletedByUserId",
                table: "user_roles");

            migrationBuilder.DropIndex(
                name: "IX_user_roles_UpdatedByUserId",
                table: "user_roles");

            // migrationBuilder.DropIndex(
            //     name: "IX_test_steps_DeletedByUserId",
            //     table: "test_steps");
            // 
            // migrationBuilder.DropIndex(
            //     name: "IX_test_steps_UpdatedByUserId",
            //     table: "test_steps");

            migrationBuilder.DropIndex(
                name: "IX_test_executions_created_by_user_id",
                table: "test_executions");

            migrationBuilder.DropIndex(
                name: "IX_test_executions_deleted_by_user_id",
                table: "test_executions");

            migrationBuilder.DropIndex(
                name: "IX_test_executions_updated_by_user_id",
                table: "test_executions");

            migrationBuilder.DropIndex(
                name: "IX_test_cases_deleted_by_user_id",
                table: "test_cases");

            migrationBuilder.DropIndex(
                name: "IX_test_cases_updated_by_user_id",
                table: "test_cases");

            migrationBuilder.DropIndex(
                name: "IX_test_cases_UserId",
                table: "test_cases");

            migrationBuilder.DropIndex(
                name: "IX_test_case_certifiers_CreatedByUserId",
                table: "test_case_certifiers");

            migrationBuilder.DropIndex(
                name: "IX_test_case_certifiers_DeletedByUserId",
                table: "test_case_certifiers");

            migrationBuilder.DropIndex(
                name: "IX_test_case_certifiers_UpdatedByUserId",
                table: "test_case_certifiers");

            migrationBuilder.DropIndex(
                name: "IX_roles_CreatedByUserId",
                table: "roles");

            migrationBuilder.DropIndex(
                name: "IX_roles_DeletedByUserId",
                table: "roles");

            migrationBuilder.DropIndex(
                name: "IX_roles_UpdatedByUserId",
                table: "roles");

            migrationBuilder.DropIndex(
                name: "IX_role_permissions_CreatedByUserId",
                table: "role_permissions");

            migrationBuilder.DropIndex(
                name: "IX_role_permissions_DeletedByUserId",
                table: "role_permissions");

            migrationBuilder.DropIndex(
                name: "IX_role_permissions_UpdatedByUserId",
                table: "role_permissions");

            migrationBuilder.DropIndex(
                name: "IX_projects_deleted_by_user_id",
                table: "projects");

            migrationBuilder.DropIndex(
                name: "IX_projects_leader_id",
                table: "projects");

            migrationBuilder.DropIndex(
                name: "IX_projects_updated_by_user_id",
                table: "projects");

            migrationBuilder.DropIndex(
                name: "IX_projects_UserId",
                table: "projects");

            migrationBuilder.DropIndex(
                name: "IX_project_testers_CreatedByUserId",
                table: "project_testers");

            migrationBuilder.DropIndex(
                name: "IX_project_testers_DeletedByUserId",
                table: "project_testers");

            migrationBuilder.DropIndex(
                name: "IX_project_testers_UpdatedByUserId",
                table: "project_testers");

            migrationBuilder.DropIndex(
                name: "IX_project_observations_DeletedByUserId",
                table: "project_observations");

            migrationBuilder.DropIndex(
                name: "IX_project_observations_UpdatedByUserId",
                table: "project_observations");

            migrationBuilder.DropIndex(
                name: "IX_project_observation_responses_DeletedByUserId",
                table: "project_observation_responses");

            migrationBuilder.DropIndex(
                name: "IX_project_observation_responses_UpdatedByUserId",
                table: "project_observation_responses");

            migrationBuilder.DropIndex(
                name: "IX_project_devolutions_DeletedByUserId",
                table: "project_devolutions");

            migrationBuilder.DropIndex(
                name: "IX_project_devolutions_UpdatedByUserId",
                table: "project_devolutions");

            migrationBuilder.DropIndex(
                name: "IX_permissions_CreatedByUserId",
                table: "permissions");

            migrationBuilder.DropIndex(
                name: "IX_permissions_DeletedByUserId",
                table: "permissions");

            migrationBuilder.DropIndex(
                name: "IX_permissions_UpdatedByUserId",
                table: "permissions");

            migrationBuilder.DropIndex(
                name: "IX_execution_step_observations_DeletedByUserId",
                table: "execution_step_observations");

            migrationBuilder.DropIndex(
                name: "IX_execution_step_observations_UpdatedByUserId",
                table: "execution_step_observations");

            migrationBuilder.DropIndex(
                name: "IX_evidences_CreatedByUserId",
                table: "evidences");

            migrationBuilder.DropIndex(
                name: "IX_evidences_DeletedByUserId",
                table: "evidences");

            migrationBuilder.DropIndex(
                name: "IX_evidences_UpdatedByUserId",
                table: "evidences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_kanban_tasks",
                table: "kanban_tasks");

            migrationBuilder.DropIndex(
                name: "IX_kanban_tasks_created_by_user_id",
                table: "kanban_tasks");

            migrationBuilder.DropIndex(
                name: "IX_kanban_tasks_deleted_by_user_id",
                table: "kanban_tasks");

            migrationBuilder.DropIndex(
                name: "IX_kanban_tasks_TaskPriorityId",
                table: "kanban_tasks");

            migrationBuilder.DropIndex(
                name: "IX_kanban_tasks_updated_by_user_id",
                table: "kanban_tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_kanban_columns",
                table: "kanban_columns");

            migrationBuilder.DropIndex(
                name: "IX_kanban_columns_created_by_user_id",
                table: "kanban_columns");

            migrationBuilder.DropIndex(
                name: "IX_kanban_columns_deleted_by_user_id",
                table: "kanban_columns");

            migrationBuilder.DropIndex(
                name: "IX_kanban_columns_updated_by_user_id",
                table: "kanban_columns");

            migrationBuilder.DropPrimaryKey(
                name: "PK_kanban_boards",
                table: "kanban_boards");

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("41544143-4f4c-5347-5f56-494557000000"), new Guid("33333333-3333-3333-3333-333333333333") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("33333333-3333-3333-3333-333333333333") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("33333333-3333-3333-3333-333333333333") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f4352454154"), new Guid("33333333-3333-3333-3333-333333333333") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5550444154"), new Guid("33333333-3333-3333-3333-333333333333") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f55504c4f41"), new Guid("33333333-3333-3333-3333-333333333333") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("33333333-3333-3333-3333-333333333333") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("33333333-3333-3333-3333-333333333333") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("33333333-3333-3333-3333-333333333333") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f4352454154"), new Guid("33333333-3333-3333-3333-333333333333") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5550444154"), new Guid("33333333-3333-3333-3333-333333333333") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("33333333-3333-3333-3333-333333333333") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("44444444-4444-4444-4444-444444444444") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("44444444-4444-4444-4444-444444444444") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("44444444-4444-4444-4444-444444444444") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("44444444-4444-4444-4444-444444444444") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("44444444-4444-4444-4444-444444444444") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("44444444-4444-4444-4444-444444444444") });

            migrationBuilder.DeleteData(
                table: "user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("99999999-9999-9999-9999-999999999999") });

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

            migrationBuilder.DropColumn(
                name: "documento_identidad",
                table: "users");

            migrationBuilder.DropColumn(
                name: "fecha_nacimiento",
                table: "users");

            migrationBuilder.DropColumn(
                name: "telefono",
                table: "users");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "user_roles");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "user_roles");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "user_roles");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "user_roles");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "user_roles");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "user_roles");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "user_roles");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "test_types");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "test_types");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "test_types");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "test_types");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "test_types");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "test_types");

            migrationBuilder.DropColumn(
                name: "created_by_user_id",
                table: "test_suites");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                table: "test_suites");

            migrationBuilder.DropColumn(
                name: "deleted_by_user_id",
                table: "test_suites");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "test_suites");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "test_suites");

            migrationBuilder.DropColumn(
                name: "updated_by_user_id",
                table: "test_suites");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "test_suite_statuses");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "test_suite_statuses");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "test_suite_statuses");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "test_suite_statuses");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "test_suite_statuses");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "test_suite_statuses");

            // migrationBuilder.DropColumn(
            //     name: "CreatedAt",
            //     table: "test_steps");
            // 
            // migrationBuilder.DropColumn(
            //     name: "DeletedAt",
            //     table: "test_steps");
            // 
            // migrationBuilder.DropColumn(
            //     name: "DeletedByUserId",
            //     table: "test_steps");
            // 
            // migrationBuilder.DropColumn(
            //     name: "IsDeleted",
            //     table: "test_steps");
            // 
            // migrationBuilder.DropColumn(
            //     name: "UpdatedAt",
            //     table: "test_steps");
            // 
            // migrationBuilder.DropColumn(
            //     name: "UpdatedByUserId",
            //     table: "test_steps");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "test_executions");

            migrationBuilder.DropColumn(
                name: "created_by_user_id",
                table: "test_executions");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                table: "test_executions");

            migrationBuilder.DropColumn(
                name: "deleted_by_user_id",
                table: "test_executions");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "test_executions");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "test_executions");

            migrationBuilder.DropColumn(
                name: "updated_by_user_id",
                table: "test_executions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "test_cases");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                table: "test_cases");

            migrationBuilder.DropColumn(
                name: "deleted_by_user_id",
                table: "test_cases");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "test_cases");

            migrationBuilder.DropColumn(
                name: "updated_by_user_id",
                table: "test_cases");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "test_case_priorities");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "test_case_priorities");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "test_case_priorities");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "test_case_priorities");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "test_case_priorities");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "test_case_priorities");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "test_case_certifiers");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "test_case_certifiers");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "test_case_certifiers");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "test_case_certifiers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "test_case_certifiers");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "test_case_certifiers");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "test_case_certifiers");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "task_priorities");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "task_priorities");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "task_priorities");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "task_priorities");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "task_priorities");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "task_priorities");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "step_result_statuses");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "step_result_statuses");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "step_result_statuses");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "step_result_statuses");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "step_result_statuses");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "step_result_statuses");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "roles");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "roles");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "roles");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "roles");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "roles");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "roles");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "role_permissions");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "role_permissions");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "role_permissions");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "role_permissions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "role_permissions");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "role_permissions");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "role_permissions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "budget",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "deleted_by_user_id",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "leader_id",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "risks",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "updated_by_user_id",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "version",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "project_testers");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "project_testers");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "project_testers");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "project_testers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "project_testers");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "project_testers");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "project_testers");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "project_statuses");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "project_statuses");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "project_statuses");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "project_statuses");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "project_statuses");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "project_statuses");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "project_observations");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "project_observations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "project_observations");

            migrationBuilder.DropColumn(
                name: "IsResolved",
                table: "project_observations");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "project_observations");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "project_observations");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "project_observation_responses");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "project_observation_responses");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "project_observation_responses");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "project_observation_responses");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "project_observation_responses");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "project_devolutions");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "project_devolutions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "project_devolutions");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "project_devolutions");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "project_devolutions");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "permissions");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "permissions");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "permissions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "permissions");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "permissions");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "permissions");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "permissions");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "execution_step_results");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "execution_step_results");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "execution_step_results");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "execution_step_results");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "execution_step_results");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "execution_step_results");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "execution_step_results");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "execution_step_observations");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "execution_step_observations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "execution_step_observations");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "execution_step_observations");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "execution_step_observations");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "execution_statuses");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "execution_statuses");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "execution_statuses");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "execution_statuses");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "execution_statuses");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "execution_statuses");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "evidences");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "evidences");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "evidences");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "evidences");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "evidences");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "evidences");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "evidences");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "evidence_types");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "evidence_types");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "evidence_types");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "evidence_types");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "evidence_types");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "evidence_types");

            migrationBuilder.DropColumn(
                name: "TaskPriorityId",
                table: "kanban_tasks");

            migrationBuilder.DropColumn(
                name: "created_by_user_id",
                table: "kanban_tasks");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                table: "kanban_tasks");

            migrationBuilder.DropColumn(
                name: "deleted_by_user_id",
                table: "kanban_tasks");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "kanban_tasks");

            migrationBuilder.DropColumn(
                name: "updated_by_user_id",
                table: "kanban_tasks");

            migrationBuilder.DropColumn(
                name: "created_by_user_id",
                table: "kanban_columns");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                table: "kanban_columns");

            migrationBuilder.DropColumn(
                name: "deleted_by_user_id",
                table: "kanban_columns");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "kanban_columns");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "kanban_columns");

            migrationBuilder.DropColumn(
                name: "updated_by_user_id",
                table: "kanban_columns");

            migrationBuilder.DropColumn(
                name: "created_by_user_id",
                table: "kanban_boards");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                table: "kanban_boards");

            migrationBuilder.DropColumn(
                name: "deleted_by_user_id",
                table: "kanban_boards");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "kanban_boards");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "kanban_boards");

            migrationBuilder.DropColumn(
                name: "updated_by_user_id",
                table: "kanban_boards");

            migrationBuilder.RenameTable(
                name: "kanban_tasks",
                newName: "KanbanTasks");

            migrationBuilder.RenameTable(
                name: "kanban_columns",
                newName: "KanbanColumns");

            migrationBuilder.RenameTable(
                name: "kanban_boards",
                newName: "KanbanBoards");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "KanbanTasks",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "KanbanTasks",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "KanbanTasks",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "KanbanTasks",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "test_case_id",
                table: "KanbanTasks",
                newName: "TestCaseId");

            migrationBuilder.RenameColumn(
                name: "priority_id",
                table: "KanbanTasks",
                newName: "PriorityId");

            migrationBuilder.RenameColumn(
                name: "order_index",
                table: "KanbanTasks",
                newName: "OrderIndex");

            migrationBuilder.RenameColumn(
                name: "kanban_column_id",
                table: "KanbanTasks",
                newName: "KanbanColumnId");

            migrationBuilder.RenameColumn(
                name: "due_date",
                table: "KanbanTasks",
                newName: "DueDate");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "KanbanTasks",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "assignee_id",
                table: "KanbanTasks",
                newName: "AssigneeId");

            migrationBuilder.RenameIndex(
                name: "IX_kanban_tasks_test_case_id",
                table: "KanbanTasks",
                newName: "IX_KanbanTasks_TestCaseId");

            migrationBuilder.RenameIndex(
                name: "IX_kanban_tasks_priority_id",
                table: "KanbanTasks",
                newName: "IX_KanbanTasks_PriorityId");

            migrationBuilder.RenameIndex(
                name: "IX_kanban_tasks_kanban_column_id",
                table: "KanbanTasks",
                newName: "IX_KanbanTasks_KanbanColumnId");

            migrationBuilder.RenameIndex(
                name: "IX_kanban_tasks_assignee_id",
                table: "KanbanTasks",
                newName: "IX_KanbanTasks_AssigneeId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "KanbanColumns",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "KanbanColumns",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "order_index",
                table: "KanbanColumns",
                newName: "OrderIndex");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "KanbanColumns",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "board_id",
                table: "KanbanColumns",
                newName: "KanbanBoardId");

            migrationBuilder.RenameIndex(
                name: "IX_kanban_columns_board_id",
                table: "KanbanColumns",
                newName: "IX_KanbanColumns_KanbanBoardId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "KanbanBoards",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "KanbanBoards",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "project_id",
                table: "KanbanBoards",
                newName: "ProjectId");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "KanbanBoards",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_kanban_boards_project_id",
                table: "KanbanBoards",
                newName: "IX_KanbanBoards_ProjectId");

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

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "test_suites",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "expected_result",
                table: "test_steps",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "action",
                table: "test_steps",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<DateTime>(
                name: "execution_date",
                table: "test_executions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "preconditions",
                table: "test_cases",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "test_cases",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<int>(
                name: "priority",
                table: "projects",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValue: "Medium");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "projects",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedByUserId",
                table: "project_observations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedByUserId",
                table: "project_observation_responses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedByUserId",
                table: "project_devolutions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "permissions",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedByUserId",
                table: "execution_step_observations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "content_type",
                table: "evidences",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "KanbanTasks",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "KanbanTasks",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(2000)",
                oldMaxLength: 2000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "KanbanColumns",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "KanbanBoards",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_KanbanTasks",
                table: "KanbanTasks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KanbanColumns",
                table: "KanbanColumns",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KanbanBoards",
                table: "KanbanBoards",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "execution_step_observation_responses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ExecutionStepObservationId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Response = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_execution_step_observation_responses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_execution_step_observation_responses_execution_step_observa~",
                        column: x => x.ExecutionStepObservationId,
                        principalTable: "execution_step_observations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_execution_step_observation_responses_users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 3, 25, 22, 21, 37, 876, DateTimeKind.Utc).AddTicks(6067));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 3, 25, 22, 21, 37, 876, DateTimeKind.Utc).AddTicks(6069));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 3, 25, 22, 21, 37, 876, DateTimeKind.Utc).AddTicks(6070));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 3, 25, 22, 21, 37, 876, DateTimeKind.Utc).AddTicks(6071));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 3, 25, 22, 21, 37, 876, DateTimeKind.Utc).AddTicks(8544));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 3, 25, 22, 21, 37, 876, DateTimeKind.Utc).AddTicks(8546));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 3, 25, 22, 21, 37, 876, DateTimeKind.Utc).AddTicks(8547));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 3, 25, 22, 21, 37, 876, DateTimeKind.Utc).AddTicks(8549));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 5,
                column: "created_at",
                value: new DateTime(2026, 3, 25, 22, 21, 37, 876, DateTimeKind.Utc).AddTicks(8551));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 6,
                column: "created_at",
                value: new DateTime(2026, 3, 25, 22, 21, 37, 876, DateTimeKind.Utc).AddTicks(8553));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 25, 22, 21, 37, 875, DateTimeKind.Utc).AddTicks(1364));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 25, 22, 21, 37, 875, DateTimeKind.Utc).AddTicks(1367));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 25, 22, 21, 37, 875, DateTimeKind.Utc).AddTicks(1368));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 25, 22, 21, 37, 875, DateTimeKind.Utc).AddTicks(1370));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 25, 22, 21, 37, 875, DateTimeKind.Utc).AddTicks(1407));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 3, 25, 22, 21, 37, 885, DateTimeKind.Utc).AddTicks(5938));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 3, 25, 22, 21, 37, 885, DateTimeKind.Utc).AddTicks(5940));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 3, 25, 22, 21, 37, 885, DateTimeKind.Utc).AddTicks(5941));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 3, 25, 22, 21, 37, 885, DateTimeKind.Utc).AddTicks(5942));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 3, 25, 22, 21, 37, 885, DateTimeKind.Utc).AddTicks(8533));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 3, 25, 22, 21, 37, 885, DateTimeKind.Utc).AddTicks(8535));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 3, 25, 22, 21, 37, 885, DateTimeKind.Utc).AddTicks(8536));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 3, 25, 22, 21, 37, 885, DateTimeKind.Utc).AddTicks(8537));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 3, 25, 22, 21, 37, 887, DateTimeKind.Utc).AddTicks(5380));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 3, 25, 22, 21, 37, 887, DateTimeKind.Utc).AddTicks(5382));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 3, 25, 22, 21, 37, 887, DateTimeKind.Utc).AddTicks(5384));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 3, 25, 22, 21, 37, 887, DateTimeKind.Utc).AddTicks(5385));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 25, 22, 21, 37, 875, DateTimeKind.Utc).AddTicks(3525));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 25, 22, 21, 37, 875, DateTimeKind.Utc).AddTicks(3529));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 25, 22, 21, 37, 875, DateTimeKind.Utc).AddTicks(3530));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 25, 22, 21, 37, 875, DateTimeKind.Utc).AddTicks(3531));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 25, 22, 21, 37, 875, DateTimeKind.Utc).AddTicks(5000));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 25, 22, 21, 37, 875, DateTimeKind.Utc).AddTicks(5003));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 25, 22, 21, 37, 875, DateTimeKind.Utc).AddTicks(5005));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 25, 22, 21, 37, 875, DateTimeKind.Utc).AddTicks(5007));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 25, 22, 21, 37, 875, DateTimeKind.Utc).AddTicks(5009));

            migrationBuilder.InsertData(
                table: "user_roles",
                columns: new[] { "role_id", "user_id", "assigned_at" },
                values: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("99999999-9999-9999-9999-999999999999"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
                columns: new[] { "PasswordResetToken", "PasswordResetTokenExpiryTime" },
                values: new object[] { null, null });

            migrationBuilder.CreateIndex(
                name: "IX_execution_step_observation_responses_CreatedByUserId",
                table: "execution_step_observation_responses",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_execution_step_observation_responses_ExecutionStepObservati~",
                table: "execution_step_observation_responses",
                column: "ExecutionStepObservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_execution_step_observations_users_CreatedByUserId",
                table: "execution_step_observations",
                column: "CreatedByUserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_KanbanBoards_projects_ProjectId",
                table: "KanbanBoards",
                column: "ProjectId",
                principalTable: "projects",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KanbanColumns_KanbanBoards_KanbanBoardId",
                table: "KanbanColumns",
                column: "KanbanBoardId",
                principalTable: "KanbanBoards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KanbanTasks_KanbanColumns_KanbanColumnId",
                table: "KanbanTasks",
                column: "KanbanColumnId",
                principalTable: "KanbanColumns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KanbanTasks_task_priorities_PriorityId",
                table: "KanbanTasks",
                column: "PriorityId",
                principalTable: "task_priorities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KanbanTasks_test_cases_TestCaseId",
                table: "KanbanTasks",
                column: "TestCaseId",
                principalTable: "test_cases",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_KanbanTasks_users_AssigneeId",
                table: "KanbanTasks",
                column: "AssigneeId",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_project_devolutions_users_CreatedByUserId",
                table: "project_devolutions",
                column: "CreatedByUserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_project_observation_responses_users_CreatedByUserId",
                table: "project_observation_responses",
                column: "CreatedByUserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_project_observations_users_CreatedByUserId",
                table: "project_observations",
                column: "CreatedByUserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_test_case_certifiers_users_user_id",
                table: "test_case_certifiers",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            // migrationBuilder.AddForeignKey(
            //     name: "FK_test_steps_users_created_by_user_id",
            //     table: "test_steps",
            //     column: "created_by_user_id",
            //     principalTable: "users",
            //     principalColumn: "id",
            //     onDelete: ReferentialAction.Restrict);
        }
    }
}
