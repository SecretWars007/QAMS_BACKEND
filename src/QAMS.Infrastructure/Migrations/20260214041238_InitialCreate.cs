using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QAMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EvidenceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvidenceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "execution_statuses",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    sort_order = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_execution_statuses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Module = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StepResultStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StepResultStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskPriorities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskPriorities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestCasePriorities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestCasePriorities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    RefreshToken = table.Column<string>(type: "text", nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KanbanBoards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KanbanBoards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KanbanBoards_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestSuites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestSuites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestSuites_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "role_permissions",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    PermissionId = table.Column<Guid>(type: "uuid", nullable: false),
                    AssignedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role_permissions", x => new { x.RoleId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_role_permissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_role_permissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_roles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    AssignedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_roles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_user_roles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_roles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KanbanColumns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    KanbanBoardId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    OrderIndex = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KanbanColumns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KanbanColumns_KanbanBoards_KanbanBoardId",
                        column: x => x.KanbanBoardId,
                        principalTable: "KanbanBoards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestCases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TestSuiteId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Preconditions = table.Column<string>(type: "text", nullable: true),
                    ExpectedResult = table.Column<string>(type: "text", nullable: false),
                    PriorityId = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestCases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestCases_TestCasePriorities_PriorityId",
                        column: x => x.PriorityId,
                        principalTable: "TestCasePriorities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestCases_TestSuites_TestSuiteId",
                        column: x => x.TestSuiteId,
                        principalTable: "TestSuites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KanbanTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    KanbanColumnId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    AssigneeId = table.Column<Guid>(type: "uuid", nullable: true),
                    TestCaseId = table.Column<Guid>(type: "uuid", nullable: true),
                    PriorityId = table.Column<int>(type: "integer", nullable: false),
                    DueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    OrderIndex = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KanbanTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KanbanTasks_KanbanColumns_KanbanColumnId",
                        column: x => x.KanbanColumnId,
                        principalTable: "KanbanColumns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KanbanTasks_TaskPriorities_PriorityId",
                        column: x => x.PriorityId,
                        principalTable: "TaskPriorities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KanbanTasks_TestCases_TestCaseId",
                        column: x => x.TestCaseId,
                        principalTable: "TestCases",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KanbanTasks_Users_AssigneeId",
                        column: x => x.AssigneeId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "test_executions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    test_case_id = table.Column<Guid>(type: "uuid", nullable: false),
                    tester_id = table.Column<Guid>(type: "uuid", nullable: false),
                    status_id = table.Column<int>(type: "integer", nullable: false),
                    notes = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    execution_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    completed_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_test_executions", x => x.id);
                    table.ForeignKey(
                        name: "FK_test_executions_TestCases_test_case_id",
                        column: x => x.test_case_id,
                        principalTable: "TestCases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_test_executions_Users_tester_id",
                        column: x => x.tester_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_test_executions_execution_statuses_status_id",
                        column: x => x.status_id,
                        principalTable: "execution_statuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestSteps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TestCaseId = table.Column<Guid>(type: "uuid", nullable: false),
                    StepOrder = table.Column<int>(type: "integer", nullable: false),
                    Action = table.Column<string>(type: "text", nullable: false),
                    ExpectedResult = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestSteps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestSteps_TestCases_TestCaseId",
                        column: x => x.TestCaseId,
                        principalTable: "TestCases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Evidences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TestExecutionId = table.Column<Guid>(type: "uuid", nullable: false),
                    FileTypeId = table.Column<int>(type: "integer", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    FilePath = table.Column<string>(type: "text", nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    ContentType = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    UploadedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evidences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evidences_EvidenceTypes_FileTypeId",
                        column: x => x.FileTypeId,
                        principalTable: "EvidenceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evidences_test_executions_TestExecutionId",
                        column: x => x.TestExecutionId,
                        principalTable: "test_executions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExecutionStepResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TestExecutionId = table.Column<Guid>(type: "uuid", nullable: false),
                    TestStepId = table.Column<Guid>(type: "uuid", nullable: false),
                    StatusId = table.Column<int>(type: "integer", nullable: false),
                    ActualResult = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    EvaluatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExecutionStepResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExecutionStepResults_StepResultStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "StepResultStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExecutionStepResults_TestSteps_TestStepId",
                        column: x => x.TestStepId,
                        principalTable: "TestSteps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExecutionStepResults_test_executions_TestExecutionId",
                        column: x => x.TestExecutionId,
                        principalTable: "test_executions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Code", "CreatedAt", "Description", "Module" },
                values: new object[,]
                {
                    { new Guid("41544143-4f4c-5347-5f4d-414e41474500"), "CATALOGS_MANAGE", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Administrar catálogos", "Catalogs" },
                    { new Guid("41544143-4f4c-5347-5f56-494557000000"), "CATALOGS_VIEW", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ver catálogos", "Catalogs" },
                    { new Guid("424e414b-4e41-435f-5245-415445000000"), "KANBAN_CREATE", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Crear tableros/tareas", "Kanban" },
                    { new Guid("424e414b-4e41-445f-454c-455445000000"), "KANBAN_DELETE", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Eliminar tareas", "Kanban" },
                    { new Guid("424e414b-4e41-555f-5044-415445000000"), "KANBAN_UPDATE", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mover tareas", "Kanban" },
                    { new Guid("424e414b-4e41-565f-4945-570000000000"), "KANBAN_VIEW", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ver tableros Kanban", "Kanban" },
                    { new Guid("43455845-5455-4f49-4e53-5f4352454154"), "EXECUTIONS_CREATE", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Crear ejecuciones", "Executions" },
                    { new Guid("43455845-5455-4f49-4e53-5f5550444154"), "EXECUTIONS_UPDATE", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Actualizar ejecuciones", "Executions" },
                    { new Guid("43455845-5455-4f49-4e53-5f55504c4f41"), "EXECUTIONS_UPLOAD_EVIDENCE", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Subir evidencia", "Executions" },
                    { new Guid("43455845-5455-4f49-4e53-5f5649455700"), "EXECUTIONS_VIEW", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ver ejecuciones", "Executions" },
                    { new Guid("454c4f52-5f53-4544-4c45-544500000000"), "ROLES_DELETE", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Eliminar roles", "Roles" },
                    { new Guid("454c4f52-5f53-4956-4557-000000000000"), "ROLES_VIEW", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ver roles", "Roles" },
                    { new Guid("454c4f52-5f53-5055-4441-544500000000"), "ROLES_UPDATE", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Actualizar roles", "Roles" },
                    { new Guid("454c4f52-5f53-5243-4541-544500000000"), "ROLES_CREATE", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Crear roles", "Roles" },
                    { new Guid("454c4f52-5f53-5341-5349-474e5f504552"), "ROLES_ASSIGN_PERMISSIONS", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Asignar permisos a roles", "Roles" },
                    { new Guid("48534144-4f42-5241-445f-564945570000"), "DASHBOARD_VIEW", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ver dashboard", "Dashboard" },
                    { new Guid("4a4f5250-4345-5354-5f43-524541544500"), "PROJECTS_CREATE", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Crear proyectos", "Projects" },
                    { new Guid("4a4f5250-4345-5354-5f44-454c45544500"), "PROJECTS_DELETE", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Eliminar proyectos", "Projects" },
                    { new Guid("4a4f5250-4345-5354-5f55-504441544500"), "PROJECTS_UPDATE", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Actualizar proyectos", "Projects" },
                    { new Guid("4a4f5250-4345-5354-5f56-494557000000"), "PROJECTS_VIEW", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ver proyectos", "Projects" },
                    { new Guid("52455355-5f53-4544-4c45-544500000000"), "USERS_DELETE", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Eliminar usuarios", "Users" },
                    { new Guid("52455355-5f53-4956-4557-000000000000"), "USERS_VIEW", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ver usuarios", "Users" },
                    { new Guid("52455355-5f53-5055-4441-544500000000"), "USERS_UPDATE", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Actualizar usuarios", "Users" },
                    { new Guid("52455355-5f53-5243-4541-544500000000"), "USERS_CREATE", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Crear usuarios", "Users" },
                    { new Guid("54534554-435f-5341-4553-5f4352454154"), "TEST_CASES_CREATE", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Crear casos de prueba", "TestCases" },
                    { new Guid("54534554-435f-5341-4553-5f44454c4554"), "TEST_CASES_DELETE", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Eliminar casos de prueba", "TestCases" },
                    { new Guid("54534554-435f-5341-4553-5f5550444154"), "TEST_CASES_UPDATE", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Actualizar casos de prueba", "TestCases" },
                    { new Guid("54534554-435f-5341-4553-5f5649455700"), "TEST_CASES_VIEW", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ver casos de prueba", "TestCases" }
                });

            migrationBuilder.InsertData(
                table: "execution_statuses",
                columns: new[] { "id", "code", "created_at", "description", "is_active", "name", "sort_order" },
                values: new object[,]
                {
                    { 1, "PENDING", new DateTime(2026, 2, 14, 4, 12, 37, 143, DateTimeKind.Utc).AddTicks(2369), "Ejecución creada pero no iniciada.", true, "Pendiente", 1 },
                    { 2, "IN_PROGRESS", new DateTime(2026, 2, 14, 4, 12, 37, 143, DateTimeKind.Utc).AddTicks(2380), "Ejecución en curso.", true, "En Progreso", 2 },
                    { 3, "PASSED", new DateTime(2026, 2, 14, 4, 12, 37, 143, DateTimeKind.Utc).AddTicks(2385), "Todos los pasos exitosos.", true, "Aprobado", 3 },
                    { 4, "FAILED", new DateTime(2026, 2, 14, 4, 12, 37, 143, DateTimeKind.Utc).AddTicks(2388), "Al menos un paso falló.", true, "Fallido", 4 },
                    { 5, "BLOCKED", new DateTime(2026, 2, 14, 4, 12, 37, 143, DateTimeKind.Utc).AddTicks(2391), "Impedimento externo.", true, "Bloqueado", 5 },
                    { 6, "SKIPPED", new DateTime(2026, 2, 14, 4, 12, 37, 143, DateTimeKind.Utc).AddTicks(2394), "Omitido intencionalmente.", true, "Omitido", 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Evidences_FileTypeId",
                table: "Evidences",
                column: "FileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Evidences_TestExecutionId",
                table: "Evidences",
                column: "TestExecutionId");

            migrationBuilder.CreateIndex(
                name: "IX_execution_statuses_code",
                table: "execution_statuses",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExecutionStepResults_StatusId",
                table: "ExecutionStepResults",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ExecutionStepResults_TestExecutionId",
                table: "ExecutionStepResults",
                column: "TestExecutionId");

            migrationBuilder.CreateIndex(
                name: "IX_ExecutionStepResults_TestStepId",
                table: "ExecutionStepResults",
                column: "TestStepId");

            migrationBuilder.CreateIndex(
                name: "IX_KanbanBoards_ProjectId",
                table: "KanbanBoards",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_KanbanColumns_KanbanBoardId",
                table: "KanbanColumns",
                column: "KanbanBoardId");

            migrationBuilder.CreateIndex(
                name: "IX_KanbanTasks_AssigneeId",
                table: "KanbanTasks",
                column: "AssigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_KanbanTasks_KanbanColumnId",
                table: "KanbanTasks",
                column: "KanbanColumnId");

            migrationBuilder.CreateIndex(
                name: "IX_KanbanTasks_PriorityId",
                table: "KanbanTasks",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_KanbanTasks_TestCaseId",
                table: "KanbanTasks",
                column: "TestCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_role_permissions_PermissionId",
                table: "role_permissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_test_executions_status_id",
                table: "test_executions",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_test_executions_test_case_id",
                table: "test_executions",
                column: "test_case_id");

            migrationBuilder.CreateIndex(
                name: "IX_test_executions_tester_id",
                table: "test_executions",
                column: "tester_id");

            migrationBuilder.CreateIndex(
                name: "IX_TestCases_PriorityId",
                table: "TestCases",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_TestCases_TestSuiteId",
                table: "TestCases",
                column: "TestSuiteId");

            migrationBuilder.CreateIndex(
                name: "IX_TestSteps_TestCaseId",
                table: "TestSteps",
                column: "TestCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_TestSuites_ProjectId",
                table: "TestSuites",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_user_roles_RoleId",
                table: "user_roles",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Evidences");

            migrationBuilder.DropTable(
                name: "ExecutionStepResults");

            migrationBuilder.DropTable(
                name: "KanbanTasks");

            migrationBuilder.DropTable(
                name: "role_permissions");

            migrationBuilder.DropTable(
                name: "user_roles");

            migrationBuilder.DropTable(
                name: "EvidenceTypes");

            migrationBuilder.DropTable(
                name: "StepResultStatuses");

            migrationBuilder.DropTable(
                name: "TestSteps");

            migrationBuilder.DropTable(
                name: "test_executions");

            migrationBuilder.DropTable(
                name: "KanbanColumns");

            migrationBuilder.DropTable(
                name: "TaskPriorities");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "TestCases");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "execution_statuses");

            migrationBuilder.DropTable(
                name: "KanbanBoards");

            migrationBuilder.DropTable(
                name: "TestCasePriorities");

            migrationBuilder.DropTable(
                name: "TestSuites");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
