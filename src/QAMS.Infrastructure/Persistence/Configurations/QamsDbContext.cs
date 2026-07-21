// src/QAMS.Infrastructure/Persistence/QamsDbContext.cs
using Microsoft.EntityFrameworkCore;
using QAMS.Application.Interfaces;
using QAMS.Domain.Common;
using QAMS.Domain.Entities;
using QAMS.Domain.Entities.Catalogs;
using System.Linq.Expressions;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    public class QamsDbContext(DbContextOptions<QamsDbContext> options, ICurrentUserService currentUserService) : DbContext(options)
    {
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public DbSet<ExecutionStatus> ExecutionStatuses => Set<ExecutionStatus>();

        /// <summary>
        /// Tabla catálogo de tipos de archivo de evidencia.
        /// Valores seed: IMAGE, VIDEO, DOCUMENT, LOG_FILE.
        /// Tabla PostgreSQL: evidence_types
        /// </summary>
        public DbSet<EvidenceType> EvidenceTypes => Set<EvidenceType>();

        /// <summary>
        /// Tabla catálogo de estados de resultado de paso individual.
        /// Valores seed: NOT_EXECUTED, PASSED, FAILED, BLOCKED.
        /// Tabla PostgreSQL: step_result_statuses
        /// </summary>
        public DbSet<StepResultStatus> StepResultStatuses => Set<StepResultStatus>();

        /// <summary>
        /// Tabla catálogo de prioridades para tareas Kanban.
        /// Valores seed: LOW, MEDIUM, HIGH, CRITICAL.
        /// Tabla PostgreSQL: task_priorities
        /// </summary>
        public DbSet<TaskPriority> TaskPriorities => Set<TaskPriority>();

        /// <summary>
        /// Tabla catálogo de prioridades para casos de prueba.
        /// Separado de TaskPriority por 4FN (independencia multivaluada).
        /// Valores seed: LOW, MEDIUM, HIGH, CRITICAL.
        /// Tabla PostgreSQL: test_case_priorities
        /// </summary>
        public DbSet<TestCasePriority> TestCasePriorities => Set<TestCasePriority>();

        /// <summary>
        /// Tabla catálogo de tipos de prueba.
        /// Valores seed: FUNCTIONAL_MANUAL, FUNCTIONAL_AUTOMATED, NON_FUNCTIONAL, REGRESSION, SMOKE.
        /// Tabla PostgreSQL: test_types
        /// </summary>
        public DbSet<TestType> TestTypes => Set<TestType>();

        /// <summary>Catálogo de estados de TestSuite.</summary>
        public DbSet<TestSuiteStatus> TestSuiteStatuses => Set<TestSuiteStatus>();

        /// <summary>Catálogo de tipos de plataforma para Sistemas Bajo Prueba.</summary>
        public DbSet<PlatformType> PlatformTypes => Set<PlatformType>();

        // =======================================================================
        // TABLAS DE SEGURIDAD (Sistema RBAC Dinámico)
        // Permite administrar usuarios, roles y permisos desde la UI.
        // =======================================================================

        /// <summary>
        /// Tabla de usuarios del sistema.
        /// Contiene credenciales, perfil y refresh token.
        /// Tabla PostgreSQL: users
        /// </summary>
        public DbSet<User> Users => Set<User>();

        /// <summary>
        /// Tabla de roles dinámicos administrables.
        /// Los roles agrupan permisos y se asignan a usuarios.
        /// Tabla PostgreSQL: roles
        /// </summary>
        public DbSet<Role> Roles => Set<Role>();

        /// <summary>
        /// Tabla de permisos granulares del sistema.
        /// Cada permiso representa una acción atómica (ej: TEST_CASES_CREATE).
        /// Tabla PostgreSQL: permissions
        /// </summary>
        public DbSet<Permission> Permissions => Set<Permission>();

        /// <summary>
        /// Tabla puente para la relación muchos-a-muchos entre User y Role.
        /// PK compuesta: (UserId, RoleId). Cumple 4FN.
        /// Tabla PostgreSQL: user_roles
        /// </summary>
        public DbSet<UserRole> UserRoles => Set<UserRole>();

        /// <summary>Testers asignados a proyectos.</summary>
        public DbSet<ProjectTester> ProjectTesters => Set<ProjectTester>();

        public DbSet<QAMS.Domain.Entities.Catalogs.ProjectStatus> ProjectStatuses => Set<QAMS.Domain.Entities.Catalogs.ProjectStatus>();

        /// <summary>
        /// Tabla puente para la relación muchos-a-muchos entre Role y Permission.
        /// PK compuesta: (RoleId, PermissionId). Cumple 4FN.
        /// Tabla PostgreSQL: role_permissions
        /// </summary>
        public DbSet<RolePermission> RolePermissions => Set<RolePermission>();

        // =======================================================================
        // TABLAS DE NEGOCIO (Gestión de Pruebas - QA)
        // Estructura jerárquica: Project -> TestSuite -> TestCase -> TestStep
        // Ejecuciones: TestExecution -> ExecutionStepResult + Evidence
        // =======================================================================

        /// <summary>
        /// Tabla de proyectos de QA.
        /// Un proyecto agrupa suites de prueba y tableros Kanban.
        /// Tabla PostgreSQL: projects
        /// </summary>
        public DbSet<Project> Projects => Set<Project>();

        /// <summary>Requisitos funcionales del proyecto.</summary>
        public DbSet<Requirement> Requirements => Set<Requirement>();

        /// <summary>
        /// Tabla de histórico de devoluciones de proyectos.
        /// </summary>
        public DbSet<ProjectDevolution> ProjectDevolutions => Set<ProjectDevolution>();

        /// <summary>
        /// Tabla de suites (conjuntos) de prueba.
        /// Una suite pertenece a un proyecto y contiene casos de prueba.
        /// Tabla PostgreSQL: test_suites
        /// </summary>
        public DbSet<TestSuite> TestSuites => Set<TestSuite>();

        /// <summary>
        /// Tabla de casos de prueba funcional manual.
        /// Un caso pertenece a una suite y contiene pasos secuenciales.
        /// FK PriorityId referencia a catálogo test_case_priorities.
        /// Tabla PostgreSQL: test_cases
        /// </summary>
        public DbSet<TestCase> TestCases => Set<TestCase>();

        /// <summary>
        /// Tabla de pasos individuales de un caso de prueba.
        /// Cada paso tiene acción y resultado esperado.
        /// Índice único: (TestCaseId, StepOrder).
        /// Tabla PostgreSQL: test_steps
        /// </summary>
        public DbSet<TestStep> TestSteps => Set<TestStep>();

        /// <summary>
        /// Tabla de ejecuciones de prueba.
        /// Registra quién ejecutó, cuándo y el resultado global.
        /// FK StatusId referencia a catálogo execution_statuses.
        /// Tabla PostgreSQL: test_executions
        /// </summary>
        public DbSet<TestExecution> TestExecutions => Set<TestExecution>();

        /// <summary>
        /// Tabla de resultados individuales por paso en cada ejecución.
        /// Registra si cada paso pasó, falló o no fue ejecutado.
        /// FK StatusId referencia a catálogo step_result_statuses.
        /// Índice único: (TestExecutionId, TestStepId).
        /// Tabla PostgreSQL: execution_step_results
        /// </summary>
        public DbSet<ExecutionStepResult> ExecutionStepResults => Set<ExecutionStepResult>();

        /// <summary>
        /// Tabla de evidencias (capturas de pantalla, videos, documentos).
        /// Almacena la ruta al archivo, NO el archivo en sí (no BLOB).
        /// FK FileTypeId referencia a catálogo evidence_types.
        /// Tabla PostgreSQL: evidences
        /// </summary>
        public DbSet<Evidence> Evidences => Set<Evidence>();

        /// <summary>
        /// Tabla de observaciones y respuestas por paso de ejecución.
        /// </summary>
        public DbSet<ExecutionStepObservation> ExecutionStepObservations => Set<ExecutionStepObservation>();

        /// <summary>
        /// Tabla de observaciones generales a nivel de proyecto.
        /// </summary>
        public DbSet<ProjectObservation> ProjectObservations => Set<ProjectObservation>();

        public DbSet<ProjectObservationResponse> ProjectObservationResponses => Set<ProjectObservationResponse>();

        // =======================================================================
        // TABLAS KANBAN (Gestión Visual de Tareas)
        // Estructura: KanbanBoard -> KanbanColumn -> KanbanTask
        // =======================================================================

        /// <summary>
        /// Tabla de tableros Kanban.
        /// Un tablero pertenece a un proyecto y contiene columnas.
        /// Tabla PostgreSQL: kanban_boards
        /// </summary>
        public DbSet<KanbanBoard> KanbanBoards => Set<KanbanBoard>();

        /// <summary>
        /// Tabla de columnas dentro de un tablero Kanban.
        /// Cada columna tiene un nombre y un índice de orden.
        /// Columnas predeterminadas: Por Hacer, En Progreso, En Revisión, Completado.
        /// Tabla PostgreSQL: kanban_columns
        /// </summary>
        public DbSet<KanbanColumn> KanbanColumns => Set<KanbanColumn>();

        /// <summary>
        /// Tabla de tareas dentro de una columna Kanban.
        /// Puede asignarse a un usuario y vincularse a un caso de prueba.
        /// FK PriorityId referencia a catálogo task_priorities.
        /// Tabla PostgreSQL: kanban_tasks
        /// </summary>
        public DbSet<KanbanTask> KanbanTasks => Set<KanbanTask>();

        // =======================================================================
        // MÓDULO ISTQB — DEFECTOS Y COBERTURA
        // =======================================================================

        /// <summary>
        /// Tabla puente M:N entre Requisitos y Casos de Prueba.
        /// Permite calcular la cobertura de requisitos (ISTQB).
        /// Tabla PostgreSQL: requirement_test_cases
        /// </summary>
        public virtual DbSet<RequirementTestCase> RequirementTestCases { get; set; } = null!;
        public virtual DbSet<SystemUnderTest> SystemsUnderTest { get; set; } = null!;

        /// <summary>
        /// Tabla de defectos/bugs detectados durante ejecuciones de prueba.
        /// Trazabilidad: Defecto → Ejecución → Caso de Prueba → Requisito.
        /// Tabla PostgreSQL: defects
        /// </summary>
        public DbSet<Defect> Defects => Set<Defect>();

        /// <summary>Catálogo de prioridades de defecto (LOW/MEDIUM/HIGH/CRITICAL)</summary>
        public DbSet<DefectPriority> DefectPriorities => Set<DefectPriority>();

        /// <summary>Catálogo de estados de defecto (OPEN/IN_PROGRESS/RESOLVED/CLOSED/REJECTED)</summary>
        public DbSet<DefectStatus> DefectStatuses => Set<DefectStatus>();

        public DbSet<TestPlan> TestPlans => Set<TestPlan>();
        public DbSet<TestPlanStatus> TestPlanStatuses => Set<TestPlanStatus>();
        public DbSet<TestPlanCriteria> TestPlanCriteria => Set<TestPlanCriteria>();
        public DbSet<TestPlanSuite> TestPlanSuites => Set<TestPlanSuite>();
        public DbSet<ApiKey> ApiKeys => Set<ApiKey>();

        // =======================================================================
        // CONFIGURACIÓN DEL MODELO (Fluent API)
        // =======================================================================

        /// <summary>
        /// Método que EF Core invoca para configurar el modelo de datos.
        /// Aplica TODAS las configuraciones Fluent API definidas en clases
        /// que implementan IEntityTypeConfiguration en el assembly de Infrastructure.
        ///
        /// Configuraciones aplicadas automáticamente:
        /// - ExecutionStatusConfiguration (catálogo + seed data)
        /// - EvidenceTypeConfiguration (catálogo + seed data)
        /// - StepResultStatusConfiguration (catálogo + seed data)
        /// - TaskPriorityConfiguration (catálogo + seed data)
        /// - TestCasePriorityConfiguration (catálogo + seed data)
        /// - UserConfiguration (índices únicos en username y email)
        /// - RoleConfiguration (índice único en name)
        /// - PermissionConfiguration (índice único en code)
        /// - PermissionSeedConfiguration (seed data de todos los permisos RBAC)
        /// - UserRoleConfiguration (PK compuesta, relaciones M:N)
        /// - RolePermissionConfiguration (PK compuesta, relaciones M:N)
        /// - ProjectConfiguration (índice único en name)
        /// - TestSuiteConfiguration (relación con Project)
        /// - TestCaseConfiguration (FK a catálogo TestCasePriority)
        /// - TestStepConfiguration (índice único compuesto)
        /// - TestExecutionConfiguration (FK a catálogo ExecutionStatus)
        /// - ExecutionStepResultConfiguration (FK a catálogo StepResultStatus)
        /// - EvidenceConfiguration (FK a catálogo EvidenceType)
        /// - KanbanBoardConfiguration (relación con Project)
        /// - KanbanColumnConfiguration (relación con KanbanBoard)
        /// - KanbanTaskConfiguration (FK a catálogo TaskPriority)
        /// </summary>
        /// <param name="modelBuilder">Constructor del modelo de EF Core</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Invocar la configuración base de DbContext
            base.OnModelCreating(modelBuilder);

            // Escanear y aplicar TODAS las clases que implementan
            // IEntityTypeConfiguration<T> en el assembly actual (Infrastructure).
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(QamsDbContext).Assembly);

            // Aplicar Filtro Global Recursivo para Entidades Soft Delete
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var clrType = entityType.ClrType;

                // 1. Filtro Soft Delete
                if (typeof(ISoftDelete).IsAssignableFrom(clrType))
                {
                    var method = typeof(QamsDbContext)
                        .GetMethod(nameof(SetSoftDeleteFilter), System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                        ?.MakeGenericMethod(clrType);
                    method?.Invoke(this, [modelBuilder]);
                }

                // 2. Configuración Dinámica de Navigaciones de Auditoría (CreatedBy, UpdatedBy, DeletedBy)
                // Esto resuelve el error InvalidOperationException cuando hay múltiples relaciones con User.
                var properties = clrType.GetProperties();

                // Configurar CreatedBy (Excepto para User para evitar problemas de esquema en tests)
                if (clrType != typeof(User) && properties.Any(p => p.Name == "CreatedBy" && p.PropertyType == typeof(User)))
                {
                    modelBuilder.Entity(clrType)
                        .HasOne("CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedByUserId")
                        .OnDelete(DeleteBehavior.SetNull);
                }

                // Configurar UpdatedBy (Excepto para User)
                if (clrType != typeof(User) && properties.Any(p => p.Name == "UpdatedBy" && p.PropertyType == typeof(User)))
                {
                    modelBuilder.Entity(clrType)
                        .HasOne("UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedByUserId")
                        .OnDelete(DeleteBehavior.SetNull);
                }

                // Configurar DeletedBy (Excepto para User)
                if (clrType != typeof(User) && properties.Any(p => p.Name == "DeletedBy" && p.PropertyType == typeof(User)))
                {
                    modelBuilder.Entity(clrType)
                        .HasOne("DeletedBy")
                        .WithMany()
                        .HasForeignKey("DeletedByUserId")
                        .OnDelete(DeleteBehavior.SetNull);
                }
            }
        }

        private static void SetSoftDeleteFilter<TEntity>(ModelBuilder modelBuilder) where TEntity : class, ISoftDelete
        {
            modelBuilder.Entity<TEntity>().HasQueryFilter(e => !e.IsDeleted);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var userId = _currentUserService.UserId;
            var now = DateTime.UtcNow;

            foreach (var entry in ChangeTracker.Entries<IAuditable>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = now;
                        if (entry.Entity.CreatedByUserId == null || entry.Entity.CreatedByUserId == Guid.Empty)
                        {
                            entry.Entity.CreatedByUserId = userId;
                        }
                        break;

                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = now;
                        entry.Entity.UpdatedByUserId = userId;
                        break;
                }
            }

            foreach (var entry in ChangeTracker.Entries<ISoftDelete>())
            {
                if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    entry.Entity.IsDeleted = true;
                    entry.Entity.DeletedAt = now;
                    entry.Entity.DeletedByUserId = userId;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
