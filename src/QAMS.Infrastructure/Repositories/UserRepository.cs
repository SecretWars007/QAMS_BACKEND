// src/QAMS.Infrastructure/Repositories/UserRepository.cs
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using QAMS.Domain.Entities;
using QAMS.Domain.Ports.Repositories;
using QAMS.Infrastructure.Persistence.Configurations;

namespace QAMS.Infrastructure.Repositories
{
    /// <summary>
    /// REPOSITORIO DE USUARIOS: Capa de acceso a datos para la entidad User.
    /// 
    /// RESPONSABILIDADES:
    /// 1. Consultas especializadas de usuarios (por username, email, con roles)
    /// 2. Operaciones de asignación y remoción de roles
    /// 3. Encapsulación de lógica de acceso a datos (ORM)
    /// 4. Mapeo entre base de datos y objetos de dominio
    /// 
    /// PATRÓN REPOSITORY:
    /// - Abstrae detalles de acceso a datos
    /// - Centraliza lógica de consultas
    /// - Facilita testing mediante mocking
    /// - Permite cambiar BD sin cambiar lógica de negocio
    /// 
    /// HERENCIA:
    /// - Hereda de GenericRepository<User> para operaciones CRUD básicas
    /// - Implementa IUserRepository para definir contrato de la interfaz
    /// 
    /// ENTITY FRAMEWORK CORE:
    /// - Usa DbSet<T> para acceso a tablas
    /// - LINQ para consultas tipadas
    /// - Include/ThenInclude para eager loading de relaciones
    /// - FirstOrDefaultAsync para operaciones asincrónicas
    /// </summary>
    public class UserRepository(QamsDbContext context) : GenericRepository<User>(context), IUserRepository
    {
        // ================================================================
        // CONSTRUCTOR: Inyecta el contexto de EF Core
        // ================================================================

        /// <summary>
        /// Inicializa una instancia de UserRepository.
        /// </summary>

        // Sobrescritura de métodos del repositorio genérico para aplicar el filtro de borrado lógico manualmente
        public override async Task<User?> GetByIdAsync(Guid id) =>
            await _dbSet.FirstOrDefaultAsync(u => u.Id == id && !u.IsDeleted);

        public override async Task<IReadOnlyList<User>> GetAllAsync() =>
            await _dbSet.Where(u => !u.IsDeleted).AsNoTracking().ToListAsync();

        public override async Task<IReadOnlyList<User>> FindAsync(Expression<Func<User, bool>> predicate) =>
            await _dbSet.Where(u => !u.IsDeleted).Where(predicate).AsNoTracking().ToListAsync();

        public override async Task<bool> AnyAsync(Expression<Func<User, bool>> predicate) =>
            await _dbSet.Where(u => !u.IsDeleted).AnyAsync(predicate);

        public override async Task<int> CountAsync(Expression<Func<User, bool>> predicate) =>
            await _dbSet.Where(u => !u.IsDeleted).CountAsync(predicate);

        /// 
        /// PARÁMETRO:
        /// - context: DbContext que representa la BD
        ///   Se pasa a la clase base para operaciones CRUD básicas
        /// 
        /// NOTA:
        /// - El contexto es inyectado por el contenedor DI
        /// - Se reutiliza en toda la aplicación (Unit of Work pattern)
        /// </summary>

        // ================================================================
        // CONSULTAS POR CRITERIOS ESPECÍFICOS (BÚSQUEDA)
        // ================================================================

        /// <summary>
        /// OBTIENE UN USUARIO POR SU USERNAME.
        /// 
        /// CASO DE USO:
        /// - Login: verificar credenciales
        /// - Validación de unicidad al crear usuario
        /// - Búsqueda por identificador único (no ID)
        /// 
        /// PARÁMETRO:
        /// - username: nombre de usuario a buscar (case-sensitive)
        /// 
        /// RETORNA:
        /// - User: el usuario encontrado, o null si no existe
        /// 
        /// QUERY GENERADA (SQL aproximado):
        /// SELECT * FROM users WHERE username = @username LIMIT 1
        /// 
        /// - No carga roles (lazy loading)
        /// - Usa comparación exact
        /// </summary>
        public async Task<User?> GetByUsernameAsync(string username) =>
            await _dbSet.FirstOrDefaultAsync(u => u.Username != null && u.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && !u.IsDeleted);

        public async Task<User?> GetByEmailAsync(string email) =>
            await _dbSet.FirstOrDefaultAsync(u => u.Email != null && u.Email.Equals(email, StringComparison.OrdinalIgnoreCase) && !u.IsDeleted);

        public async Task<User?> GetByUsernamePhysicalAsync(string username) =>
            await _dbSet.IgnoreQueryFilters()
                .FirstOrDefaultAsync(u => u.Username != null && u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

        public async Task<User?> GetByEmailPhysicalAsync(string email) =>
            await _dbSet.IgnoreQueryFilters()
                .FirstOrDefaultAsync(u => u.Email != null && u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

        public async Task<List<User>> GetPhysicalConflictsAsync(string email, string username, string documento)
        {
            var lowerEmail = email.ToLower();
            var lowerUsername = username.ToLower();

            return await _dbSet.IgnoreQueryFilters()
                .Where(u => (u.Email != null && u.Email.Equals(email, StringComparison.OrdinalIgnoreCase))
                         || (u.Username != null && u.Username.Equals(username, StringComparison.OrdinalIgnoreCase))
                         || u.DocumentoIdentidad == documento)
                .ToListAsync();
        }

        /// <summary>
        /// OBTIENE UN USUARIO CON TODOS SUS ROLES (EAGER LOADING).
        /// 
        /// PATRÓN APPLIED: EAGER LOADING
        /// - Include() carga la colección UserRoles en una sola consulta
        /// - ThenInclude() carga los detalles de cada Role
        /// - Evita N+1 queries (problema común en ORM)
        /// 
        /// CASO DE USO:
        /// - Obtener perfil de usuario con sus roles
        /// - Mostrar datos de usuario en UI (perfil, dashboard)
        /// - Asignar/remover roles
        /// 
        /// PARÁMETRO:
        /// - userId: identificador del usuario
        /// 
        /// RETORNA:
        /// - User con colección UserRoles cargada, o null si no existe
        /// 
        /// QUERY GENERADA (aprox, INNER JOINs):
        /// SELECT u.*, ur.*, r.*
        /// FROM users u
        /// LEFT JOIN user_roles ur ON u.id = ur.user_id
        /// LEFT JOIN roles r ON ur.role_id = r.id
        /// WHERE u.id = @userId
        /// 
        /// VENTAJA: Una sola consulta en lugar de N+1
        /// - 1 para obtener el usuario
        /// - 1 para cada rol (N consultas)
        /// = 1 + N queries sin Include
        /// 
        /// NOTA:
        /// - Include() y ThenInclude() solo aplican a la rama específica
        /// - Permisos NO se cargan aquí (usar GetWithRolesAndPermissionsAsync para eso)
        /// </summary>
        public async Task<User?> GetWithRolesAsync(Guid userId) =>
            // LINQ: seleccionar usuario e incluir sus roles con sus detalles (filtrando borrados)
            await _dbSet
                .Where(u => !u.IsDeleted)
                // Include filtrado para evitar roles borrados lógicamente
                .Include(u => u.UserRoles.Where(ur => !ur.IsDeleted))
                // ThenInclude carga los detalles de cada Role incluido
                .ThenInclude(ur => ur.Role)
                // Filtrar por el usuario específico y retornar el primero o null
                .FirstOrDefaultAsync(u => u.Id == userId);

        /// <summary>
        /// OBTIENE TODOS LOS USUARIOS CON SUS ROLES (EAGER LOADING, EXCLUYENDO BORRADOS).
        /// </summary>
        public async Task<List<User>> GetAllWithRolesAsync() =>
            await _dbSet
                .Where(u => !u.IsDeleted)
                .Include(u => u.UserRoles.Where(ur => !ur.IsDeleted))
                .ThenInclude(ur => ur.Role)
                .ToListAsync();

        /// <summary>
        /// OBTIENE VARIOS USUARIOS POR SUS IDS CON ROLES (BATCH LOADING, EXCLUYENDO BORRADOS).
        /// </summary>
        public async Task<List<User>> GetByIdsWithRolesAsync(IEnumerable<Guid> userIds) =>
            await _dbSet
                .Where(u => !u.IsDeleted && userIds.Contains(u.Id))
                .Include(u => u.UserRoles.Where(ur => !ur.IsDeleted))
                .ThenInclude(ur => ur.Role)
                .ToListAsync();

        /// <summary>
        /// OBTIENE UN USUARIO CON ROLES Y PERMISOS (CARGA COMPLETA PARA AUTENTICACIÓN).
        /// 
        /// PATRÓN APPLIED: EAGER LOADING ANIDADO (múltiples niveles)
        /// - Include → ThenInclude → ThenInclude
        /// - Carga toda la cadena de autenticación/autorización
        /// 
        /// CASO DE USO:
        /// - Autenticación: obtener usuario con sus permisos después de login
        /// - Autorización: verificar permisos sin consultas adicionales
        /// - Carga inicial de usuario autenticado
        /// 
        /// PARÁMETRO:
        /// - username: nombre de usuario para autenticación
        /// 
        /// RETORNA:
        /// - User con:
        ///   * Colección UserRoles cargada
        ///   * Para cada UserRole, su Role cargado
        ///   * Para cada Role, su colección RolePermissions cargada
        ///   * Para cada RolePermission, su Permission cargada
        /// - null si el usuario no existe
        /// 
        /// QUERY GENERADA (INNER JOINs múltiples):
        /// SELECT u.*, ur.*, r.*, rp.*, p.*
        /// FROM users u
        /// LEFT JOIN user_roles ur ON u.id = ur.user_id
        /// LEFT JOIN roles r ON ur.role_id = r.id
        /// LEFT JOIN role_permissions rp ON r.id = rp.role_id
        /// LEFT JOIN permissions p ON rp.permission_id = p.id
        /// WHERE u.username = @username
        /// 
        /// JERARQUÍA DE DATOS CARGADOS:
        /// User
        ///   → UserRoles (muchos)
        ///       → Role (uno por UserRole)
        ///           → RolePermissions (muchos)
        ///               → Permission (uno por RolePermission)
        /// 
        /// VENTAJA: Todos los datos para autorización en una sola consulta
        /// 
        /// NOTA:
        /// - Usar solo cuando se necesiten permisos
        /// - Para casos simples, usar GetWithRolesAsync
        /// - La consulta es más grande pero evita roundtrips
        /// </summary>
        public async Task<User?> GetWithRolesAndPermissionsAsync(string username)
        {
            return await _dbSet
                .Where(u => !u.IsDeleted)
                // Step 1: Incluir colección de UserRoles FILTRADOS por borrado lógico
                .Include(u => u.UserRoles.Where(ur => !ur.IsDeleted))
                // Step 2: Para cada UserRole, incluir el Role relacionado
                .ThenInclude(ur => ur.Role)
                // Step 3: Para cada Role, incluir sus RolePermissions
                .ThenInclude(r => r!.RolePermissions)
                // Step 4: Para cada RolePermission, incluir el Permission
                .ThenInclude(rp => rp!.Permission)
                // Usar SplitQuery para evitar cartesian product y errores de múltiples colecciones
                .AsSplitQuery()
                // Filtrar por username y retornar el primero o null
                .FirstOrDefaultAsync(u => u.Username != null && u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }

        // ================================================================
        // OPERACIONES DE ASIGNACIÓN DE ROLES (INSERT en tabla puente)
        // ================================================================

        /// <summary>
        /// ASIGNA UN ROL A UN USUARIO CREANDO RELACIÓN MANY-TO-MANY.
        /// 
        /// PATRÓN APPLIED:
        /// - Tabla puente: UserRole representa la relación entre User y Role
        /// - Operación idempotente: si ya existe, no duplica
        /// 
        /// CASO DE USO:
        /// - POST /api/users/{userId}/roles/{roleId} - asignar rol a usuario
        /// - CreateAsync: asignar rol durante creación de usuario
        /// - UpdateAsync: agregar nuevo rol a usuario existente
        /// 
        /// PARÁMETROS:
        /// - userId: identificador del usuario
        /// - roleId: identificador del rol a asignar
        /// 
        /// FLUJO DETALLADO:
        /// 1. Verificar si ya existe la asignación
        /// 2. Si existe, retornar sin hacer nada (idempotencia)
        /// 3. Si no existe, crear nuevo UserRole
        /// 4. Establecer timestamp de asignación
        /// 5. Insertar en DbSet (se persiste con SaveChangesAsync)
        /// 
        /// IDEMPOTENCIA: Concepto muy importante
        /// - Operación idempotente: llamarla múltiples veces = una sola vez
        /// - Ejemplo: asignar el mismo rol 3 veces = el usuario tiene el rol 1 vez
        /// - Evita duplicados en tablas de relación
        /// 
        /// QUERY GENERADA:
        /// -- Verificar si existe:
        /// SELECT COUNT(*) FROM user_roles WHERE user_id = @userId AND role_id = @roleId
        /// -- Si no existe, insertar:
        /// INSERT INTO user_roles (user_id, role_id, assigned_at) 
        /// VALUES (@userId, @roleId, @now)
        /// 
        /// NOTA:
        /// - No retorna datos (solo crea relación)
        /// - El cambio se persiste con SaveChangesAsync
        /// - El timestamp assigned_at registra cuándo se asignó
        /// - Se previene duplicados con verificación AnyAsync
        /// </summary>
        public async Task AssignRoleAsync(Guid userId, Guid roleId)
        {
            // ============================================================
            // PASO 1: Buscar si la asignación ya existe (Ignorando filtros de borrado)
            // ============================================================

            // Usamos IgnoreQueryFilters para detectar si el registro existe físicamente (borrado o no)
            var assignment = await _context.UserRoles
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(ur => ur.UserId == userId && ur.RoleId == roleId);

            if (assignment != null)
            {
                // Si existe y está borrado, lo restauramos
                if (assignment.IsDeleted)
                {
                    assignment.IsDeleted = false;
                    assignment.AssignedAt = DateTime.UtcNow;
                    _context.UserRoles.Update(assignment);
                }
                // Si ya existe y NO está borrado, no hacemos nada (idempotencia)
                return;
            }

            // ============================================================
            // PASO 2: Crear nuevo UserRole si no existe físicamente
            // ============================================================

            var userRole = new UserRole
            {
                UserId = userId,
                RoleId = roleId,
                AssignedAt = DateTime.UtcNow,
                IsDeleted = false
            };

            await _context.UserRoles.AddAsync(userRole);
        }

        /// <summary>
        /// REMUEVE UN ROL ESPECÍFICO DE UN USUARIO.
        /// 
        /// PATRÓN APPLIED:
        /// - Operación idempotente: si no existe, no lanza error
        /// - Eliminación física de registro en tabla puente
        /// 
        /// CASO DE USO:
        /// - DELETE /api/users/{userId}/roles/{roleId} - remover un rol específico
        /// - UpdateAsync: remover rol específico al actualizar usuario
        /// - Cambio de permisos: quitar rol sin eliminar otros
        /// 
        /// PARÁMETROS:
        /// - userId: identificador del usuario
        /// - roleId: identificador del rol a remover
        /// 
        /// FLUJO DETALLADO:
        /// 1. Buscar la asignación UserRole específica
        /// 2. Si no existe, retornar sin error (idempotencia)
        /// 3. Si existe, marcar para eliminación
        /// 4. El registro se elimina con SaveChangesAsync
        /// 
        /// QUERY GENERADA:
        /// -- Buscar el registro:
        /// SELECT * FROM user_roles WHERE user_id = @userId AND role_id = @roleId LIMIT 1
        /// -- Si existe, eliminar:
        /// DELETE FROM user_roles WHERE user_id = @userId AND role_id = @roleId
        /// 
        /// NOTA:
        /// - Solo elimina la relación, no el usuario ni el rol
        /// - Es seguro llamar si no existe (idempotencia)
        /// - Se persiste con SaveChangesAsync
        /// </summary>
        public async Task RemoveRoleAsync(Guid userId, Guid roleId)
        {
            // ============================================================
            // PASO 1: Buscar la asignación específica
            // ============================================================

            // LINQ: buscar el UserRole exacto que matchea userId Y roleId
            // Se usa IgnoreQueryFilters para asegurar que encontramos registros ya borrados lógicamente
            var assignment = await _context.UserRoles
                .IgnoreQueryFilters()
                // Filtrar por ambas claves de la relación
                .FirstOrDefaultAsync(ur => ur.UserId == userId && ur.RoleId == roleId);

            // ============================================================
            // PASO 2: Remover si existe (IDEMPOTENCIA)
            // ============================================================

            // Solo remover si se encontró la asignación
            // Si no existe, this condition es false y no se hace nada
            if (assignment != null)
                // Remove marca la entidad en estado "Deleted"
                // EF Core ejecutará DELETE SQL al llamar SaveChangesAsync
                _context.UserRoles.Remove(assignment);

            // NOTA: El cambio se persiste EXTERNAMENTE (en UserService.RemoveRoleAsync)
        }

        /// <summary>
        /// REMUEVE TODOS LOS ROLES DE UN USUARIO (ELIMINACIÓN EN LOTE).
        /// 
        /// PATRÓN APPLIED:
        /// - Operación en lote: elimina múltiples registros en una sola operación
        /// - Más eficiente que llamar RemoveRoleAsync N veces
        /// 
        /// CASO DE USO:
        /// - DELETE /api/users/{userId}/roles - remover todos los roles
        /// - UpdateAsync: reemplazar conjunto de roles (remove all + add new)
        /// - Desactivación de usuario: quitar todos sus permisos
        /// 
        /// PARÁMETRO:
        /// - userId: identificador del usuario cuyos roles se removerán
        /// 
        /// FLUJO DETALLADO:
        /// 1. Filtrar todos los UserRoles que pertenecen a este usuario
        /// 2. Marcar cada uno para eliminación
        /// 3. Los registros se eliminan todos con SaveChangesAsync
        /// 
        /// QUERY GENERADA:
        /// -- Obtener IDs de todos los roles del usuario:
        /// SELECT * FROM user_roles WHERE user_id = @userId
        /// -- Eliminar todos:
        /// DELETE FROM user_roles WHERE user_id = @userId
        /// 
        /// VENTAJA SOBRE LOOP:
        /// - RemoveAllRoles: 1 consulta de búsqueda + 1 DELETE masivo
        /// - Loop RemoveRole N veces: N consultas de búsqueda + N DELETE
        /// - RemoveAllRoles es mucho más eficiente
        /// 
        /// NOTA:
        /// - RemoveRange elimina toda una colección de una vez
        /// - Where() devuelve IQueryable (no materializa en memoria)
        /// - La materialización ocurre solo en SaveChangesAsync
        /// </summary>
        public async Task RemoveAllRolesAsync(Guid userId)
        {
            // ============================================================
            // PASO 1: Obtener todos los UserRoles del usuario materializados
            // ============================================================

            // Es importante usar ToListAsync() para que el tracker capture 
            // las entidades antes de marcarlas para borrar.
            var assignments = await _context.UserRoles
                .Where(ur => ur.UserId == userId)
                .ToListAsync();

            // ============================================================
            // PASO 2: Marcar todos para eliminación (RemoveRange)
            // ============================================================

            if (assignments.Count > 0)
            {
                _context.UserRoles.RemoveRange(assignments);
            }
        }
    }
}
