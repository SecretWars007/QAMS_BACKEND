using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QAMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddStaticTestingModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "design_technique_id",
                table: "test_cases",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "test_execution_id",
                table: "kanban_tasks",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "finding_severities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_finding_severities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "finding_statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_finding_statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "finding_types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_finding_types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "review_statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_review_statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "review_types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_review_types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "test_design_techniques",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_test_design_techniques", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "review_sessions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    project_id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    artifact_under_review = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    review_type_id = table.Column<int>(type: "integer", nullable: false),
                    status_id = table.Column<int>(type: "integer", nullable: false),
                    scheduled_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    completed_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    moderator_id = table.Column<Guid>(type: "uuid", nullable: true),
                    author_id = table.Column<Guid>(type: "uuid", nullable: true),
                    entry_criteria = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    exit_criteria = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    conclusions = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
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
                    table.PrimaryKey("PK_review_sessions", x => x.id);
                    table.ForeignKey(
                        name: "FK_review_sessions_projects_project_id",
                        column: x => x.project_id,
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_review_sessions_review_statuses_status_id",
                        column: x => x.status_id,
                        principalTable: "review_statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_review_sessions_review_types_review_type_id",
                        column: x => x.review_type_id,
                        principalTable: "review_types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_review_sessions_users_author_id",
                        column: x => x.author_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_review_sessions_users_created_by_user_id",
                        column: x => x.created_by_user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_review_sessions_users_deleted_by_user_id",
                        column: x => x.deleted_by_user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_review_sessions_users_moderator_id",
                        column: x => x.moderator_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_review_sessions_users_updated_by_user_id",
                        column: x => x.updated_by_user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "review_findings",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    review_session_id = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    location = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    finding_type_id = table.Column<int>(type: "integer", nullable: false),
                    severity_id = table.Column<int>(type: "integer", nullable: false),
                    finding_status_id = table.Column<int>(type: "integer", nullable: false),
                    assigned_to_id = table.Column<Guid>(type: "uuid", nullable: true),
                    resolution = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    resolved_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
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
                    table.PrimaryKey("PK_review_findings", x => x.id);
                    table.ForeignKey(
                        name: "FK_review_findings_finding_severities_severity_id",
                        column: x => x.severity_id,
                        principalTable: "finding_severities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_review_findings_finding_statuses_finding_status_id",
                        column: x => x.finding_status_id,
                        principalTable: "finding_statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_review_findings_finding_types_finding_type_id",
                        column: x => x.finding_type_id,
                        principalTable: "finding_types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_review_findings_review_sessions_review_session_id",
                        column: x => x.review_session_id,
                        principalTable: "review_sessions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_review_findings_users_assigned_to_id",
                        column: x => x.assigned_to_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_review_findings_users_created_by_user_id",
                        column: x => x.created_by_user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "review_participants",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    review_session_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    role = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    attended = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    invited_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_review_participants", x => x.id);
                    table.ForeignKey(
                        name: "FK_review_participants_review_sessions_review_session_id",
                        column: x => x.review_session_id,
                        principalTable: "review_sessions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_review_participants_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "defect_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 69, DateTimeKind.Utc).AddTicks(9098));

            migrationBuilder.UpdateData(
                table: "defect_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 69, DateTimeKind.Utc).AddTicks(9102));

            migrationBuilder.UpdateData(
                table: "defect_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 69, DateTimeKind.Utc).AddTicks(9104));

            migrationBuilder.UpdateData(
                table: "defect_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 69, DateTimeKind.Utc).AddTicks(9105));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 70, DateTimeKind.Utc).AddTicks(1808));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 70, DateTimeKind.Utc).AddTicks(1810));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 70, DateTimeKind.Utc).AddTicks(1812));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 70, DateTimeKind.Utc).AddTicks(1813));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 5,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 70, DateTimeKind.Utc).AddTicks(1814));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 72, DateTimeKind.Utc).AddTicks(1366));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 72, DateTimeKind.Utc).AddTicks(1373));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 72, DateTimeKind.Utc).AddTicks(1374));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 72, DateTimeKind.Utc).AddTicks(1375));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 72, DateTimeKind.Utc).AddTicks(5812));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 72, DateTimeKind.Utc).AddTicks(5817));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 72, DateTimeKind.Utc).AddTicks(5818));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 72, DateTimeKind.Utc).AddTicks(5819));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 5,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 72, DateTimeKind.Utc).AddTicks(5820));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 6,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 72, DateTimeKind.Utc).AddTicks(5821));

            migrationBuilder.InsertData(
                table: "finding_severities",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "Description", "IsActive", "IsDeleted", "Name", "SortOrder", "UpdatedAt", "UpdatedByUserId" },
                values: new object[,]
                {
                    { 1, "BLOCKER", new DateTime(2026, 8, 1, 0, 46, 57, 77, DateTimeKind.Utc).AddTicks(5999), null, null, null, null, true, false, "Bloqueante", 1, null, null },
                    { 2, "MAJOR", new DateTime(2026, 8, 1, 0, 46, 57, 77, DateTimeKind.Utc).AddTicks(6002), null, null, null, null, true, false, "Mayor", 2, null, null },
                    { 3, "MINOR", new DateTime(2026, 8, 1, 0, 46, 57, 77, DateTimeKind.Utc).AddTicks(6003), null, null, null, null, true, false, "Menor", 3, null, null },
                    { 4, "TRIVIAL", new DateTime(2026, 8, 1, 0, 46, 57, 77, DateTimeKind.Utc).AddTicks(6004), null, null, null, null, true, false, "Trivial", 4, null, null }
                });

            migrationBuilder.InsertData(
                table: "finding_statuses",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "Description", "IsActive", "IsDeleted", "Name", "SortOrder", "UpdatedAt", "UpdatedByUserId" },
                values: new object[,]
                {
                    { 1, "OPEN", new DateTime(2026, 8, 1, 0, 46, 57, 77, DateTimeKind.Utc).AddTicks(8084), null, null, null, null, true, false, "Abierto", 1, null, null },
                    { 2, "ACCEPTED", new DateTime(2026, 8, 1, 0, 46, 57, 77, DateTimeKind.Utc).AddTicks(8086), null, null, null, null, true, false, "Aceptado", 2, null, null },
                    { 3, "REJECTED", new DateTime(2026, 8, 1, 0, 46, 57, 77, DateTimeKind.Utc).AddTicks(8087), null, null, null, null, true, false, "Rechazado", 3, null, null },
                    { 4, "RESOLVED", new DateTime(2026, 8, 1, 0, 46, 57, 77, DateTimeKind.Utc).AddTicks(8088), null, null, null, null, true, false, "Resuelto", 4, null, null }
                });

            migrationBuilder.InsertData(
                table: "finding_types",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "Description", "IsActive", "IsDeleted", "Name", "SortOrder", "UpdatedAt", "UpdatedByUserId" },
                values: new object[,]
                {
                    { 1, "DEFECT", new DateTime(2026, 8, 1, 0, 46, 57, 77, DateTimeKind.Utc).AddTicks(9697), null, null, null, null, true, false, "Defecto", 1, null, null },
                    { 2, "IMPROVEMENT", new DateTime(2026, 8, 1, 0, 46, 57, 77, DateTimeKind.Utc).AddTicks(9699), null, null, null, null, true, false, "Mejora", 2, null, null },
                    { 3, "QUESTION", new DateTime(2026, 8, 1, 0, 46, 57, 77, DateTimeKind.Utc).AddTicks(9701), null, null, null, null, true, false, "Pregunta", 3, null, null },
                    { 4, "COMMENT", new DateTime(2026, 8, 1, 0, 46, 57, 77, DateTimeKind.Utc).AddTicks(9702), null, null, null, null, true, false, "Comentario", 4, null, null }
                });

            migrationBuilder.UpdateData(
                table: "platform_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 84, DateTimeKind.Utc).AddTicks(5221));

            migrationBuilder.UpdateData(
                table: "platform_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 84, DateTimeKind.Utc).AddTicks(5223));

            migrationBuilder.UpdateData(
                table: "platform_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 84, DateTimeKind.Utc).AddTicks(5224));

            migrationBuilder.UpdateData(
                table: "project_priorities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 95, DateTimeKind.Utc).AddTicks(2405));

            migrationBuilder.UpdateData(
                table: "project_priorities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 95, DateTimeKind.Utc).AddTicks(2408));

            migrationBuilder.UpdateData(
                table: "project_priorities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 95, DateTimeKind.Utc).AddTicks(2410));

            migrationBuilder.UpdateData(
                table: "project_priorities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 95, DateTimeKind.Utc).AddTicks(2411));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 65, DateTimeKind.Utc).AddTicks(2234));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 65, DateTimeKind.Utc).AddTicks(2237));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 65, DateTimeKind.Utc).AddTicks(2238));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 65, DateTimeKind.Utc).AddTicks(2240));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 65, DateTimeKind.Utc).AddTicks(2242));

            migrationBuilder.UpdateData(
                table: "requirement_complexities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 97, DateTimeKind.Utc).AddTicks(3619));

            migrationBuilder.UpdateData(
                table: "requirement_complexities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 97, DateTimeKind.Utc).AddTicks(3622));

            migrationBuilder.UpdateData(
                table: "requirement_complexities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 97, DateTimeKind.Utc).AddTicks(3623));

            migrationBuilder.UpdateData(
                table: "requirement_complexities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 97, DateTimeKind.Utc).AddTicks(3624));

            migrationBuilder.UpdateData(
                table: "requirement_priorities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 99, DateTimeKind.Utc).AddTicks(9765));

            migrationBuilder.UpdateData(
                table: "requirement_priorities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 99, DateTimeKind.Utc).AddTicks(9767));

            migrationBuilder.UpdateData(
                table: "requirement_priorities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 99, DateTimeKind.Utc).AddTicks(9769));

            migrationBuilder.UpdateData(
                table: "requirement_priorities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 99, DateTimeKind.Utc).AddTicks(9770));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 100, DateTimeKind.Utc).AddTicks(3369));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 100, DateTimeKind.Utc).AddTicks(3372));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 100, DateTimeKind.Utc).AddTicks(3373));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 100, DateTimeKind.Utc).AddTicks(3374));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 100, DateTimeKind.Utc).AddTicks(3375));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 100, DateTimeKind.Utc).AddTicks(3376));

            migrationBuilder.UpdateData(
                table: "requirement_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 101, DateTimeKind.Utc).AddTicks(7961));

            migrationBuilder.UpdateData(
                table: "requirement_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 101, DateTimeKind.Utc).AddTicks(7964));

            migrationBuilder.UpdateData(
                table: "requirement_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 101, DateTimeKind.Utc).AddTicks(7965));

            migrationBuilder.UpdateData(
                table: "requirement_types",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 101, DateTimeKind.Utc).AddTicks(7966));

            migrationBuilder.InsertData(
                table: "review_statuses",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "Description", "IsActive", "IsDeleted", "Name", "SortOrder", "UpdatedAt", "UpdatedByUserId" },
                values: new object[,]
                {
                    { 1, "PLANNED", new DateTime(2026, 8, 1, 0, 46, 57, 104, DateTimeKind.Utc).AddTicks(5248), null, null, null, null, true, false, "Planificada", 1, null, null },
                    { 2, "IN_PROGRESS", new DateTime(2026, 8, 1, 0, 46, 57, 104, DateTimeKind.Utc).AddTicks(5250), null, null, null, null, true, false, "En Progreso", 2, null, null },
                    { 3, "COMPLETED", new DateTime(2026, 8, 1, 0, 46, 57, 104, DateTimeKind.Utc).AddTicks(5258), null, null, null, null, true, false, "Completada", 3, null, null },
                    { 4, "CANCELLED", new DateTime(2026, 8, 1, 0, 46, 57, 104, DateTimeKind.Utc).AddTicks(5259), null, null, null, null, true, false, "Cancelada", 4, null, null }
                });

            migrationBuilder.InsertData(
                table: "review_types",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "Description", "IsActive", "IsDeleted", "Name", "SortOrder", "UpdatedAt", "UpdatedByUserId" },
                values: new object[,]
                {
                    { 1, "INFORMAL", new DateTime(2026, 8, 1, 0, 46, 57, 104, DateTimeKind.Utc).AddTicks(6868), null, null, null, null, true, false, "Revisión Informal", 1, null, null },
                    { 2, "WALKTHROUGH", new DateTime(2026, 8, 1, 0, 46, 57, 104, DateTimeKind.Utc).AddTicks(6870), null, null, null, null, true, false, "Walkthrough", 2, null, null },
                    { 3, "TECHNICAL_REVIEW", new DateTime(2026, 8, 1, 0, 46, 57, 104, DateTimeKind.Utc).AddTicks(6871), null, null, null, null, true, false, "Revisión Técnica", 3, null, null },
                    { 4, "INSPECTION", new DateTime(2026, 8, 1, 0, 46, 57, 104, DateTimeKind.Utc).AddTicks(6872), null, null, null, null, true, false, "Inspección", 4, null, null }
                });

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("41544143-4f4c-5347-5f4d-414e41474500"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5894));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("41544143-4f4c-5347-5f56-494557000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5892));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-435f-5245-415445000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5926));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-445f-454c-455445000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5929));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5928));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5924));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f4352454154"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5918));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5550444154"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5919));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f55504c4f41"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5921));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5910));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-4544-4c45-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5888));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-4956-4557-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5876));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-5055-4441-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5886));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-5243-4541-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5878));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-5341-5349-474e5f504552"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5890));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5931));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f43-524541544500"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5898));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f44-454c45544500"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5902));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f55-504441544500"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5900));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5896));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-4544-4c45-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5872));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-4956-4557-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5828));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-5055-4441-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5870));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-5243-4541-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5867));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-5341-5349-474e5f524f4c"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5874));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f4352454154"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5905));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f44454c4554"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5908));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5550444154"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5907));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5903));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4544-454c-5445-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5939));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4956-5745-0000-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5933));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5055-4144-5445-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5937));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5243-4145-5445-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5935));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("41544143-4f4c-5347-5f56-494557000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5970));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5966));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5964));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f4352454154"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5959));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5550444154"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5960));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f55504c4f41"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5962));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5957));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5968));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5944));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5955));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4956-5745-0000-000000000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5972));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5055-4144-5445-000000000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5976));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5243-4145-5445-000000000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5974));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("41544143-4f4c-5347-5f56-494557000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(6027));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(6024));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(6022));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f4352454154"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(6016));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5550444154"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(6018));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f55504c4f41"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(6020));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(6015));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(6025));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f43-524541544500"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5985));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f55-504441544500"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(6006));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(5982));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-4956-4557-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(6007));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f4352454154"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(6011));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5550444154"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(6013));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(6009));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4544-454c-5445-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(6040));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4956-5745-0000-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(6029));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5055-4144-5445-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(6038));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5243-4145-5445-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(6036));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(6051));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(6048));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(6053));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(6042));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(6045));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4956-5745-0000-000000000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(6055));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(8675));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(8677));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(8678));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 105, DateTimeKind.Utc).AddTicks(8679));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 109, DateTimeKind.Utc).AddTicks(4050));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 109, DateTimeKind.Utc).AddTicks(4055));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 109, DateTimeKind.Utc).AddTicks(4056));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 109, DateTimeKind.Utc).AddTicks(4057));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 117, DateTimeKind.Utc).AddTicks(6414));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 117, DateTimeKind.Utc).AddTicks(6419));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 117, DateTimeKind.Utc).AddTicks(6420));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 117, DateTimeKind.Utc).AddTicks(6421));

            migrationBuilder.InsertData(
                table: "test_design_techniques",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "Description", "IsActive", "IsDeleted", "Name", "SortOrder", "UpdatedAt", "UpdatedByUserId" },
                values: new object[,]
                {
                    { 1, "EQUIVALENCE_PARTITIONING", new DateTime(2026, 8, 1, 0, 46, 57, 117, DateTimeKind.Utc).AddTicks(8930), null, null, null, null, true, false, "Partición de Equivalencia (Caja Negra)", 1, null, null },
                    { 2, "BOUNDARY_VALUE_ANALYSIS", new DateTime(2026, 8, 1, 0, 46, 57, 117, DateTimeKind.Utc).AddTicks(8934), null, null, null, null, true, false, "Análisis de Valores Límite (Caja Negra)", 2, null, null },
                    { 3, "DECISION_TABLE", new DateTime(2026, 8, 1, 0, 46, 57, 117, DateTimeKind.Utc).AddTicks(8935), null, null, null, null, true, false, "Tabla de Decisión (Caja Negra)", 3, null, null },
                    { 4, "STATE_TRANSITION", new DateTime(2026, 8, 1, 0, 46, 57, 117, DateTimeKind.Utc).AddTicks(8936), null, null, null, null, true, false, "Transición de Estados (Caja Negra)", 4, null, null },
                    { 5, "USE_CASE_TESTING", new DateTime(2026, 8, 1, 0, 46, 57, 117, DateTimeKind.Utc).AddTicks(8937), null, null, null, null, true, false, "Pruebas de Casos de Uso (Caja Negra)", 5, null, null },
                    { 6, "STATEMENT_COVERAGE", new DateTime(2026, 8, 1, 0, 46, 57, 117, DateTimeKind.Utc).AddTicks(8938), null, null, null, null, true, false, "Cobertura de Sentencias (Caja Blanca)", 6, null, null },
                    { 7, "BRANCH_COVERAGE", new DateTime(2026, 8, 1, 0, 46, 57, 117, DateTimeKind.Utc).AddTicks(8939), null, null, null, null, true, false, "Cobertura de Ramas (Caja Blanca)", 7, null, null },
                    { 8, "ERROR_GUESSING", new DateTime(2026, 8, 1, 0, 46, 57, 117, DateTimeKind.Utc).AddTicks(8940), null, null, null, null, true, false, "Predicción de Errores (Experiencia)", 8, null, null },
                    { 9, "EXPLORATORY", new DateTime(2026, 8, 1, 0, 46, 57, 117, DateTimeKind.Utc).AddTicks(8940), null, null, null, null, true, false, "Prueba Exploratoria (Experiencia)", 9, null, null },
                    { 10, "CHECKLIST_BASED", new DateTime(2026, 8, 1, 0, 46, 57, 117, DateTimeKind.Utc).AddTicks(8941), null, null, null, null, true, false, "Pruebas basadas en Lista de Comprobación (Experiencia)", 10, null, null }
                });

            migrationBuilder.UpdateData(
                table: "test_plan_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 65, DateTimeKind.Utc).AddTicks(5930));

            migrationBuilder.UpdateData(
                table: "test_plan_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 65, DateTimeKind.Utc).AddTicks(5932));

            migrationBuilder.UpdateData(
                table: "test_plan_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 65, DateTimeKind.Utc).AddTicks(5933));

            migrationBuilder.UpdateData(
                table: "test_plan_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 65, DateTimeKind.Utc).AddTicks(5934));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 65, DateTimeKind.Utc).AddTicks(9642));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 65, DateTimeKind.Utc).AddTicks(9649));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 65, DateTimeKind.Utc).AddTicks(9650));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 65, DateTimeKind.Utc).AddTicks(9651));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 66, DateTimeKind.Utc).AddTicks(5462));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 66, DateTimeKind.Utc).AddTicks(5465));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 66, DateTimeKind.Utc).AddTicks(5467));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 66, DateTimeKind.Utc).AddTicks(5469));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 66, DateTimeKind.Utc).AddTicks(5471));

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("99999999-9999-9999-9999-999999999999") },
                column: "CreatedAt",
                value: new DateTime(2026, 8, 1, 0, 46, 57, 137, DateTimeKind.Utc).AddTicks(4105));

            migrationBuilder.CreateIndex(
                name: "IX_test_cases_design_technique_id",
                table: "test_cases",
                column: "design_technique_id");

            migrationBuilder.CreateIndex(
                name: "IX_kanban_tasks_test_execution_id",
                table: "kanban_tasks",
                column: "test_execution_id");

            migrationBuilder.CreateIndex(
                name: "IX_finding_severities_Code",
                table: "finding_severities",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_finding_statuses_Code",
                table: "finding_statuses",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_finding_types_Code",
                table: "finding_types",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_review_findings_assigned_to_id",
                table: "review_findings",
                column: "assigned_to_id");

            migrationBuilder.CreateIndex(
                name: "IX_review_findings_created_by_user_id",
                table: "review_findings",
                column: "created_by_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_review_findings_finding_status_id",
                table: "review_findings",
                column: "finding_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_review_findings_finding_type_id",
                table: "review_findings",
                column: "finding_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_review_findings_review_session_id",
                table: "review_findings",
                column: "review_session_id");

            migrationBuilder.CreateIndex(
                name: "IX_review_findings_severity_id",
                table: "review_findings",
                column: "severity_id");

            migrationBuilder.CreateIndex(
                name: "IX_review_participants_review_session_id",
                table: "review_participants",
                column: "review_session_id");

            migrationBuilder.CreateIndex(
                name: "IX_review_participants_user_id",
                table: "review_participants",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_review_sessions_author_id",
                table: "review_sessions",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_review_sessions_created_by_user_id",
                table: "review_sessions",
                column: "created_by_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_review_sessions_deleted_by_user_id",
                table: "review_sessions",
                column: "deleted_by_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_review_sessions_moderator_id",
                table: "review_sessions",
                column: "moderator_id");

            migrationBuilder.CreateIndex(
                name: "IX_review_sessions_project_id",
                table: "review_sessions",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "IX_review_sessions_review_type_id",
                table: "review_sessions",
                column: "review_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_review_sessions_status_id",
                table: "review_sessions",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_review_sessions_updated_by_user_id",
                table: "review_sessions",
                column: "updated_by_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_review_statuses_Code",
                table: "review_statuses",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_review_types_Code",
                table: "review_types",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_test_design_techniques_Code",
                table: "test_design_techniques",
                column: "Code",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_kanban_tasks_test_executions_test_execution_id",
                table: "kanban_tasks",
                column: "test_execution_id",
                principalTable: "test_executions",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_test_cases_test_design_techniques_design_technique_id",
                table: "test_cases",
                column: "design_technique_id",
                principalTable: "test_design_techniques",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_kanban_tasks_test_executions_test_execution_id",
                table: "kanban_tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_test_cases_test_design_techniques_design_technique_id",
                table: "test_cases");

            migrationBuilder.DropTable(
                name: "review_findings");

            migrationBuilder.DropTable(
                name: "review_participants");

            migrationBuilder.DropTable(
                name: "test_design_techniques");

            migrationBuilder.DropTable(
                name: "finding_severities");

            migrationBuilder.DropTable(
                name: "finding_statuses");

            migrationBuilder.DropTable(
                name: "finding_types");

            migrationBuilder.DropTable(
                name: "review_sessions");

            migrationBuilder.DropTable(
                name: "review_statuses");

            migrationBuilder.DropTable(
                name: "review_types");

            migrationBuilder.DropIndex(
                name: "IX_test_cases_design_technique_id",
                table: "test_cases");

            migrationBuilder.DropIndex(
                name: "IX_kanban_tasks_test_execution_id",
                table: "kanban_tasks");

            migrationBuilder.DropColumn(
                name: "design_technique_id",
                table: "test_cases");

            migrationBuilder.DropColumn(
                name: "test_execution_id",
                table: "kanban_tasks");

            migrationBuilder.UpdateData(
                table: "defect_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 32, DateTimeKind.Utc).AddTicks(6288));

            migrationBuilder.UpdateData(
                table: "defect_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 32, DateTimeKind.Utc).AddTicks(6403));

            migrationBuilder.UpdateData(
                table: "defect_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 32, DateTimeKind.Utc).AddTicks(6406));

            migrationBuilder.UpdateData(
                table: "defect_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 32, DateTimeKind.Utc).AddTicks(6407));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 35, DateTimeKind.Utc).AddTicks(765));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 35, DateTimeKind.Utc).AddTicks(780));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 35, DateTimeKind.Utc).AddTicks(782));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 35, DateTimeKind.Utc).AddTicks(783));

            migrationBuilder.UpdateData(
                table: "defect_statuses",
                keyColumn: "id",
                keyValue: 5,
                column: "created_at",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 35, DateTimeKind.Utc).AddTicks(785));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 46, DateTimeKind.Utc).AddTicks(9770));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 46, DateTimeKind.Utc).AddTicks(9774));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 46, DateTimeKind.Utc).AddTicks(9775));

            migrationBuilder.UpdateData(
                table: "evidence_types",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 46, DateTimeKind.Utc).AddTicks(9776));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 48, DateTimeKind.Utc).AddTicks(7684));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 48, DateTimeKind.Utc).AddTicks(7694));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 48, DateTimeKind.Utc).AddTicks(7695));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 48, DateTimeKind.Utc).AddTicks(7697));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 5,
                column: "created_at",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 48, DateTimeKind.Utc).AddTicks(7698));

            migrationBuilder.UpdateData(
                table: "execution_statuses",
                keyColumn: "id",
                keyValue: 6,
                column: "created_at",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 48, DateTimeKind.Utc).AddTicks(7701));

            migrationBuilder.UpdateData(
                table: "platform_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 97, DateTimeKind.Utc).AddTicks(4768));

            migrationBuilder.UpdateData(
                table: "platform_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 97, DateTimeKind.Utc).AddTicks(4777));

            migrationBuilder.UpdateData(
                table: "platform_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 97, DateTimeKind.Utc).AddTicks(4778));

            migrationBuilder.UpdateData(
                table: "project_priorities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 141, DateTimeKind.Utc).AddTicks(2093));

            migrationBuilder.UpdateData(
                table: "project_priorities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 141, DateTimeKind.Utc).AddTicks(2110));

            migrationBuilder.UpdateData(
                table: "project_priorities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 141, DateTimeKind.Utc).AddTicks(2112));

            migrationBuilder.UpdateData(
                table: "project_priorities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 141, DateTimeKind.Utc).AddTicks(2113));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 9, DateTimeKind.Utc).AddTicks(9926));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 9, DateTimeKind.Utc).AddTicks(9929));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 9, DateTimeKind.Utc).AddTicks(9931));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 9, DateTimeKind.Utc).AddTicks(9933));

            migrationBuilder.UpdateData(
                table: "project_statuses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 9, DateTimeKind.Utc).AddTicks(9935));

            migrationBuilder.UpdateData(
                table: "requirement_complexities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 152, DateTimeKind.Utc).AddTicks(144));

            migrationBuilder.UpdateData(
                table: "requirement_complexities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 152, DateTimeKind.Utc).AddTicks(157));

            migrationBuilder.UpdateData(
                table: "requirement_complexities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 152, DateTimeKind.Utc).AddTicks(158));

            migrationBuilder.UpdateData(
                table: "requirement_complexities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 152, DateTimeKind.Utc).AddTicks(159));

            migrationBuilder.UpdateData(
                table: "requirement_priorities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 164, DateTimeKind.Utc).AddTicks(8611));

            migrationBuilder.UpdateData(
                table: "requirement_priorities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 164, DateTimeKind.Utc).AddTicks(8618));

            migrationBuilder.UpdateData(
                table: "requirement_priorities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 164, DateTimeKind.Utc).AddTicks(8620));

            migrationBuilder.UpdateData(
                table: "requirement_priorities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 164, DateTimeKind.Utc).AddTicks(8621));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 166, DateTimeKind.Utc).AddTicks(296));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 166, DateTimeKind.Utc).AddTicks(308));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 166, DateTimeKind.Utc).AddTicks(309));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 166, DateTimeKind.Utc).AddTicks(311));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 166, DateTimeKind.Utc).AddTicks(312));

            migrationBuilder.UpdateData(
                table: "requirement_statuses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 166, DateTimeKind.Utc).AddTicks(313));

            migrationBuilder.UpdateData(
                table: "requirement_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 171, DateTimeKind.Utc).AddTicks(186));

            migrationBuilder.UpdateData(
                table: "requirement_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 171, DateTimeKind.Utc).AddTicks(195));

            migrationBuilder.UpdateData(
                table: "requirement_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 171, DateTimeKind.Utc).AddTicks(197));

            migrationBuilder.UpdateData(
                table: "requirement_types",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 171, DateTimeKind.Utc).AddTicks(198));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("41544143-4f4c-5347-5f4d-414e41474500"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(582));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("41544143-4f4c-5347-5f56-494557000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(579));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-435f-5245-415445000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(653));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-445f-454c-455445000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(660));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(657));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(650));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f4352454154"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(640));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5550444154"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(643));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f55504c4f41"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(646));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(637));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-4544-4c45-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(572));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-4956-4557-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(559));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-5055-4441-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(566));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-5243-4541-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(562));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("454c4f52-5f53-5341-5349-474e5f504552"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(576));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(664));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f43-524541544500"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(589));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f44-454c45544500"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(596));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f55-504441544500"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(593));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(586));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-4544-4c45-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(544));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-4956-4557-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(62));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-5055-4441-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(235));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-5243-4541-544500000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(223));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-5341-5349-474e5f524f4c"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(556));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f4352454154"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(627));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f44454c4554"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(634));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5550444154"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(631));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(599));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4544-454c-5445-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(710));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4956-5745-0000-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(667));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5055-4144-5445-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(706));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5243-4145-5445-000000000000"), new Guid("11111111-1111-1111-1111-111111111111") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(671));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("41544143-4f4c-5347-5f56-494557000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(1300));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(1293));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(1289));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f4352454154"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(1278));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5550444154"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(1282));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f55504c4f41"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(1285));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(1274));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(1296));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(1104));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(1264));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4956-5745-0000-000000000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(1304));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5055-4144-5445-000000000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(1338));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5243-4145-5445-000000000000"), new Guid("22222222-2222-2222-2222-222222222222") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(1334));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("41544143-4f4c-5347-5f56-494557000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(1428));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(1420));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(1394));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f4352454154"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(1383));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5550444154"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(1387));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f55504c4f41"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(1390));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(1380));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(1424));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f43-524541544500"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(1357));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f55-504441544500"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(1361));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(1353));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("52455355-5f53-4956-4557-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(1365));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f4352454154"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(1373));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5550444154"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(1376));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(1369));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4544-454c-5445-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(1443));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4956-5745-0000-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(1432));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5055-4144-5445-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(1439));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-5243-4145-5445-000000000000"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(1435));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-555f-5044-415445000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(1466));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("424e414b-4e41-565f-4945-570000000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(1463));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("43455845-5455-4f49-4e53-5f5649455700"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(1459));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("48534144-4f42-5241-445f-564945570000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(1490));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("4a4f5250-4345-5354-5f56-494557000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(1449));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("54534554-435f-5341-4553-5f5649455700"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(1453));

            migrationBuilder.UpdateData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("5f545553-4956-5745-0000-000000000000"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 176, DateTimeKind.Utc).AddTicks(1493));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 178, DateTimeKind.Utc).AddTicks(9222));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 178, DateTimeKind.Utc).AddTicks(9241));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 178, DateTimeKind.Utc).AddTicks(9242));

            migrationBuilder.UpdateData(
                table: "step_result_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 178, DateTimeKind.Utc).AddTicks(9244));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 190, DateTimeKind.Utc).AddTicks(6724));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 190, DateTimeKind.Utc).AddTicks(6742));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 190, DateTimeKind.Utc).AddTicks(6744));

            migrationBuilder.UpdateData(
                table: "task_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 190, DateTimeKind.Utc).AddTicks(6745));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 235, DateTimeKind.Utc).AddTicks(7611));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 235, DateTimeKind.Utc).AddTicks(7628));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 235, DateTimeKind.Utc).AddTicks(7631));

            migrationBuilder.UpdateData(
                table: "test_case_priorities",
                keyColumn: "id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 235, DateTimeKind.Utc).AddTicks(7632));

            migrationBuilder.UpdateData(
                table: "test_plan_statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 11, DateTimeKind.Utc).AddTicks(2093));

            migrationBuilder.UpdateData(
                table: "test_plan_statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 11, DateTimeKind.Utc).AddTicks(2105));

            migrationBuilder.UpdateData(
                table: "test_plan_statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 11, DateTimeKind.Utc).AddTicks(2107));

            migrationBuilder.UpdateData(
                table: "test_plan_statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 11, DateTimeKind.Utc).AddTicks(2108));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 12, DateTimeKind.Utc).AddTicks(736));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 12, DateTimeKind.Utc).AddTicks(742));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 12, DateTimeKind.Utc).AddTicks(743));

            migrationBuilder.UpdateData(
                table: "test_suite_statuses",
                keyColumn: "id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 12, DateTimeKind.Utc).AddTicks(744));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 12, DateTimeKind.Utc).AddTicks(6643));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 12, DateTimeKind.Utc).AddTicks(6645));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 12, DateTimeKind.Utc).AddTicks(6647));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 12, DateTimeKind.Utc).AddTicks(6667));

            migrationBuilder.UpdateData(
                table: "test_types",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 12, DateTimeKind.Utc).AddTicks(6676));

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("99999999-9999-9999-9999-999999999999") },
                column: "CreatedAt",
                value: new DateTime(2026, 7, 31, 2, 23, 56, 345, DateTimeKind.Utc).AddTicks(9107));
        }
    }
}
