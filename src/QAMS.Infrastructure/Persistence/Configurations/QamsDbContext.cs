// src/QAMS.Infrastructure/Persistence/QamsDbContext.cs
// Contexto principal de Entity Framework Core para PostgreSQL.
// Registra TODAS las entidades del dominio, tablas catálogo y relaciones.
// Aplica configuraciones Fluent API desde el assembly de Infrastructure.

using Microsoft.EntityFrameworkCore;
using QAMS.Domain.Entities;
using QAMS.Domain.Entities.Catalogs;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    /// <summary>
    /// Contexto de base de datos principal del sistema QAMS.
    /// Responsabilidades:
    /// - Registrar todos los DbSet (tablas) del sistema.
    /// - Aplicar configuraciones Fluent API desde IEntityTypeConfiguration.
    /// - Gestionar la conexión con PostgreSQL.
    /// Principio SRP: solo se encarga de la configuración del ORM.
    /// </summary>
    /// <remarks>
    /// Constructor que recibe las opciones de configuración por inyección.
    /// Las opciones incluyen la cadena de conexión a PostgreSQL
    /// configurada en DependencyInjection.cs.
    /// </remarks>
    /// <param name="options">Opciones de configuración del DbContext</param>
    public class QamsDbContext(DbContextOptions<QamsDbContext> options) : DbContext(options)
    {
        // =======================================================================
        // TABLAS CATÁLOGO (Reemplazan los Enums - Administrables desde la BD)
        // Cada catálogo hereda de CatalogBase y tiene PK int con seed data.
        // =======================================================================

        /// <summary>
        /// Tabla catálogo de estados de ejecución de pruebas.
        /// Valores seed: PENDING, IN_PROGRESS, PASSED, FAILED, BLOCKED, SKIPPED.
        /// Tabla PostgreSQL: execution_statuses
        /// </summary>
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
            // Esto detecta automáticamente:
            // - Las 5 configuraciones de catálogos con seed data
            // - Las 6 configuraciones de seguridad (RBAC)
            // - Las 7 configuraciones de negocio (QA)
            // - Las 3 configuraciones de Kanban
            // Total: 21 configuraciones aplicadas automáticamente
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(QamsDbContext).Assembly);
        }
    }
}
