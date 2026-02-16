// src/QAMS.Application/Services/UserService.cs
using AutoMapper;
using Microsoft.Extensions.Logging;
using QAMS.Application.DTOs.Users;
using QAMS.Application.Interfaces;
using QAMS.Domain.Entities;
using QAMS.Domain.Exceptions;
using QAMS.Domain.Ports.Repositories;
using QAMS.Domain.Ports.Services;

namespace QAMS.Application.Services
{
    /// <summary>
    /// SERVICIO DE USUARIOS: Implementa lógica de negocio para gestión de usuarios y roles.
    /// 
    /// RESPONSABILIDADES:
    /// 1. Validación de usuarios y roles antes de operaciones
    /// 2. Coordinación entre repositorios (User, Role, Unit of Work)
    /// 3. Transformación entre DTOs (API) y entidades del dominio
    /// 4. Registro de eventos de negocio mediante logging
    /// 5. Manejo de excepciones de negocio
    /// 
    /// PRINCIPIOS APLICADOS:
    /// - SRP (Single Responsibility): Solo gestiona lógica de usuario
    /// - DIP (Dependency Inversion): Depende de abstracciones (interfaces), no de implementaciones
    /// - SOLID: Alta cohesión, bajo acoplamiento mediante inyección de dependencias
    /// - Async/Await: Operaciones asincrónicas para no bloquear threads
    /// 
    /// PATRÓN ARQUITECTÓNICO:
    /// - Application Service: Coordina repository + domain + DTO
    /// - Unit of Work: Agrupa operaciones en transacciones
    /// - Auto Mapper: Mapeo automático entre objetos
    /// </summary>
    public class UserService : IUserService
    {
        // ================================================================
        // DEPENDENCIAS INYECTADAS (inyectadas a través del constructor)
        // ================================================================

        /// <summary>
        /// Repositorio de usuarios: maneja persistencia de entidades User.
        /// Proporciona operaciones CRUD y consultas especializadas.
        /// </summary>
        private readonly IUserRepository _userRepo;

        /// <summary>
        /// Repositorio de roles: maneja persistencia de entidades Role.
        /// Valida que los roles existan antes de asignarlos.
        /// </summary>
        private readonly IRoleRepository _roleRepo;

        /// <summary>
        /// Hasher de contraseñas: cifra contraseñas de manera segura.
        /// Implementa algoritmo de hashing con salt (ej: BCrypt).
        /// </summary>
        private readonly IPasswordHasher _hasher;

        /// <summary>
        /// Unidad de Trabajo: coordina transacciones entre múltiples repositorios.
        /// Asegura que todos los cambios se persistan juntos (atomicidad).
        /// </summary>
        private readonly IUnitOfWork _uow;

        /// <summary>
        /// Mapper automático: convierte entre DTOs y entidades de dominio.
        /// Ej: User entity → UserDto (para API responses)
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Logger estructurado: registra eventos y errores del servicio.
        /// Utiliza inyección de dependencia de Microsoft.Extensions.Logging.
        /// </summary>
        private readonly ILogger<UserService> _logger;

        // ================================================================
        // CONSTRUCTOR: Inyecta todas las dependencias (Dependency Injection)
        // ================================================================

        /// <summary>
        /// Inicializa una nueva instancia de UserService con todas sus dependencias.
        /// 
        /// PARÁMETROS:
        /// - userRepo: acceso a datos de usuarios
        /// - roleRepo: acceso a datos de roles
        /// - hasher: cifrado de contraseñas
        /// - uow: coordinación de transacciones
        /// - mapper: transformación de objetos
        /// - logger: registro de eventos
        /// 
        /// NOTA: Todas las dependencias son obligatorias (no nulas).
        /// Si alguna es null, se lanzará ArgumentNullException.
        /// </summary>
        public UserService(
            IUserRepository userRepo,
            IRoleRepository roleRepo,
            IPasswordHasher hasher,
            IUnitOfWork uow,
            IMapper mapper,
            ILogger<UserService> logger
        )
        {
            // Asignar cada dependencia a su campo privado para uso en métodos posteriores
            _userRepo = userRepo;
            _roleRepo = roleRepo;
            _hasher = hasher;
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }

        // ================================================================
        // OPERACIONES CRUD DE LECTURA (GET)
        // ================================================================

        /// <summary>
        /// OBTIENE UN USUARIO POR SU ID JUNTO CON SUS ROLES.
        /// 
        /// FLUJO:
        /// 1. Registra intent de lectura en logs
        /// 2. Busca usuario con eager-load de roles
        /// 3. Lanza excepción si no existe
        /// 4. Mapea entidad a DTO
        /// 5. Retorna DTO para que el controlador lo serialice a JSON
        /// 
        /// PARÁMETRO:
        /// - id: identificador único del usuario (Guid)
        /// 
        /// RETORNA:
        /// - UserDto: objeto de transferencia de datos con información del usuario
        /// 
        /// EXCEPCIONES POSIBLES:
        /// - EntityNotFoundException: cuando el usuario no existe
        /// 
        /// CASO DE USO:
        /// - GET /api/users/{id} - obtener perfil de usuario
        /// </summary>
        public async Task<UserDto> GetByIdAsync(Guid id)
        {
            // Registrar que se solicitó obtener un usuario específico
            // El parámetro {UserId} se reemplaza por el valor real en los logs estructurados
            _logger.LogInformation("Obteniendo usuario {UserId}.", id);

            // Buscar usuario en la BD con sus roles cargados (eager loading)
            // El operador ?? (null-coalescing) lanza excepción si no existe
            var user =
                await _userRepo.GetWithRolesAsync(id)
                ?? throw new EntityNotFoundException(nameof(User), id);

            // Mapear la entidad del dominio a DTO para devolver en la API
            // El DTO solo incluye campos públicos, no contraseñas u otros datos sensibles
            return _mapper.Map<UserDto>(user);
        }

        /// <summary>
        /// OBTIENE TODOS LOS USUARIOS DEL SISTEMA.
        /// 
        /// FLUJO:
        /// 1. Registra intent de lectura masiva
        /// 2. Obtiene todos los usuarios sin roles (optimización: evita N+1 queries)
        /// 3. Mapea lista de entidades a lista de DTOs
        /// 4. Retorna lista serializable a JSON
        /// 
        /// RETORNA:
        /// - List<UserDto>: lista vacía si no hay usuarios, nunca null
        /// 
        /// CASO DE USO:
        /// - GET /api/users - listar usuarios con paginación
        /// - POST request para operaciones masivas
        /// 
        /// NOTA:
        /// - No carga roles para evitar overhead de N+1 queries
        /// - Si se necesitan roles, usar GetWithRolesAsync individualmente
        /// </summary>
        public async Task<List<UserDto>> GetAllAsync()
        {
            // Registrar que se solicitó listar todos los usuarios con sus roles
            _logger.LogInformation("Obteniendo todos los usuarios con sus roles.");

            // Obtener todos los usuarios de la BD con roles incluidos
            var users = await _userRepo.GetAllWithRolesAsync();

            // Mapear cada usuario a su DTO correspondiente
            return _mapper.Map<List<UserDto>>(users);
        }

        // ================================================================
        // OPERACIONES CRUD DE CREACIÓN (POST)
        // ================================================================

        /// <summary>
        /// CREA UN NUEVO USUARIO EN EL SISTEMA.
        /// 
        /// FLUJO DETALLADO:
        /// 1. Valida que username sea único
        /// 2. Valida que email sea único
        /// 3. Crea nueva entidad User con valores iniciales
        /// 4. Cifra la contraseña con el hasher
        /// 5. Persiste usuario en BD (SaveChanges #1)
        /// 6. Valida que cada rol a asignar existe
        /// 7. Asigna cada rol al usuario
        /// 8. Persiste asignaciones de rol (SaveChanges #2)
        /// 9. Retorna UserDto con datos persistidos
        /// 
        /// PARÁMETRO:
        /// - dto: objeto CreateUserDto con datos del nuevo usuario
        ///   * Username: identificador único
        ///   * Email: correo único
        ///   * Password: contraseña en texto plano (se cifra aquí)
        ///   * FullName: nombre completo
        ///   * RoleIds: lista de roles a asignar
        /// 
        /// RETORNA:
        /// - UserDto: usuario recién creado con ID generado
        /// 
        /// EXCEPCIONES POSIBLES:
        /// - DomainException: si username o email ya existen
        /// - EntityNotFoundException: si algún roleId no existe
        /// 
        /// CASO DE USO:
        /// - POST /api/users con JSON body
        /// 
        /// NOTA IMPORTANTE:
        /// - Las contraseñas NUNCA se retornan en responses
        /// - Se hacen 2 SaveChangesAsync para separar usuario de roles
        /// </summary>
        public async Task<UserDto> CreateAsync(CreateUserDto dto)
        {
            // Registrar que se está creando un nuevo usuario
            // El valor {Username} se extrae de dto.Username
            _logger.LogInformation("Creando usuario '{Username}'.", dto.Username);

            // VALIDACIÓN: Verificar que el username sea único en el sistema
            // AnyAsync retorna true si ya existe un usuario con ese username
            if (await _userRepo.AnyAsync(u => u.Username == dto.Username))
                // Lanzar excepción de negocio si el username ya existe
                throw new DomainException($"Username '{dto.Username}' ya existe.");

            // VALIDACIÓN: Verificar que el email sea único en el sistema
            if (await _userRepo.AnyAsync(u => u.Email == dto.Email))
                throw new DomainException($"Email '{dto.Email}' ya existe.");

            // CREAR NUEVA ENTIDAD: Instanciar User con valores iniciales
            var user = new User
            {
                // Generar nuevo ID único (GUID v4)
                Id = Guid.NewGuid(),
                
                // Asignar username (ya validado como único)
                Username = dto.Username,
                
                // Asignar email (ya validado como único)
                Email = dto.Email,
                
                // Cifrar contraseña usando el hasher de seguridad
                // IMPORTANTE: La contraseña en texto plano se descarta después
                PasswordHash = _hasher.HashPassword(dto.Password),
                
                // Asignar nombre completo
                FullName = dto.FullName,
                
                // Los usuarios nuevos están activos por defecto
                IsActive = true,
                
                // Timestamp de creación en UTC (estándar universal)
                CreatedAt = DateTime.UtcNow,
            };

            // PERSISTENCIA 1: Guardar el usuario base en la BD
            // AddAsync agrega a DbSet, SaveChangesAsync ejecuta el INSERT
            await _userRepo.AddAsync(user);
            await _uow.SaveChangesAsync();

            // ASIGNACIÓN DE ROLES: Validar y asignar cada rol del DTO
            // Iteramos sobre cada roleId proporcionado en la solicitud
            foreach (var roleId in dto.RoleIds)
            {
                // VALIDACIÓN: Verificar que el rol exista antes de asignarlo
                // AnyAsync retorna true solo si existe un rol con ese ID
                if (!await _roleRepo.AnyAsync(r => r.Id == roleId))
                    // Lanzar excepción si el rol no existe
                    throw new EntityNotFoundException(nameof(Role), roleId);

                // ASIGNAR: Crear relación entre usuario y rol
                // Esto inserta en la tabla intermedia UserRole
                await _userRepo.AssignRoleAsync(user.Id, roleId);
            }

            // PERSISTENCIA 2: Guardar todas las asignaciones de rol
            // Se separa del primer SaveChanges para que si falla un rol,
            // al menos el usuario fue creado
            await _uow.SaveChangesAsync();

            // LOGGING: Registrar que la creación fue exitosa
            _logger.LogInformation(
                "Usuario '{Username}' creado con ID {UserId}.",
                user.Username,
                user.Id
            );

            // RETORNO: Obtener usuario recién creado con sus roles cargados
            // y mapear a DTO para devolverlo en la respuesta HTTP
            var created = await _userRepo.GetWithRolesAsync(user.Id);
            return _mapper.Map<UserDto>(created);
        }

        // ================================================================
        // OPERACIONES CRUD DE ACTUALIZACIÓN (PUT)
        // ================================================================

        /// <summary>
        /// ACTUALIZA UN USUARIO EXISTENTE.
        /// 
        /// FLUJO DETALLADO:
        /// 1. Valida que el usuario exista
        /// 2. Carga usuario con sus roles actuales
        /// 3. Actualiza campos básicos (email, nombre, estado)
        /// 4. Persiste cambios básicos (SaveChanges #1)
        /// 5. Reemplaza TODOS los roles (remove all + assign new)
        /// 6. Valida que cada nuevo rol exista
        /// 7. Persiste cambios de roles (SaveChanges #2)
        /// 8. Retorna usuario actualizado
        /// 
        /// PARÁMETRO:
        /// - id: identificador del usuario a actualizar
        /// - dto: objeto UpdateUserDto con valores nuevos
        ///   * Email: nuevo correo (se valida en el controlador)
        ///   * FullName: nuevo nombre completo
        ///   * IsActive: estado del usuario (activo/inactivo)
        ///   * RoleIds: nuevo conjunto de roles (reemplaza completamente)
        /// 
        /// RETORNA:
        /// - UserDto: usuario actualizado con sus nuevos roles
        /// 
        /// EXCEPCIONES POSIBLES:
        /// - EntityNotFoundException: si el usuario no existe
        /// - EntityNotFoundException: si algún nuevo roleId no existe
        /// 
        /// COMPORTAMIENTO ESPECIAL:
        /// - Los roles se REEMPLAZAN completamente (no se agregan)
        /// - Si dto.RoleIds está vacío, el usuario queda sin roles
        /// - El password NO se actualiza en este método
        /// 
        /// CASO DE USO:
        /// - PUT /api/users/{id} con JSON body
        /// </summary>
        public async Task<UserDto> UpdateAsync(Guid id, UpdateUserDto dto)
        {
            // Registrar que se está actualizando un usuario
            _logger.LogInformation("Actualizando usuario {UserId}.", id);

            // VALIDACIÓN: Obtener usuario existente (con lazy loading de roles)
            var user =
                await _userRepo.GetWithRolesAsync(id)
                ?? throw new EntityNotFoundException(nameof(User), id);

            // ============================================================
            // SECCIÓN 1: Actualizar campos básicos del usuario
            // ============================================================

            // Actualizar email
            user.Email = dto.Email;
            
            // Actualizar nombre completo
            user.FullName = dto.FullName;
            
            // Actualizar estado (activo/inactivo)
            user.IsActive = dto.IsActive;
            
            // Registrar timestamp de última actualización
            user.UpdatedAt = DateTime.UtcNow;

            // PERSISTENCIA 1: Guardar cambios básicos
            // Update marca la entidad como modificada para EF Core
            _userRepo.Update(user);
            await _uow.SaveChangesAsync();

            // ============================================================
            // SECCIÓN 2: Reemplazar roles (remove all + assign new)
            // ============================================================

            // REMOVER TODOS los roles actuales
            // Esto prepara para asignar los nuevos roles
            await _userRepo.RemoveAllRolesAsync(id);

            // ASIGNAR NUEVOS ROLES: Validar e iterar cada roleId nuevo
            foreach (var roleId in dto.RoleIds)
            {
                // VALIDACIÓN: Verificar que el rol nuevo existe
                if (!await _roleRepo.AnyAsync(r => r.Id == roleId))
                    throw new EntityNotFoundException(nameof(Role), roleId);

                // ASIGNAR: Crear nueva relación UserRole
                await _userRepo.AssignRoleAsync(id, roleId);
            }

            // PERSISTENCIA 2: Guardar todas las asignaciones de rol nuevas
            await _uow.SaveChangesAsync();

            // LOGGING: Registrar actualización exitosa
            _logger.LogInformation("Usuario {UserId} actualizado.", id);

            // RETORNO: Obtener usuario actualizado y mapear a DTO
            var updated = await _userRepo.GetWithRolesAsync(id);
            return _mapper.Map<UserDto>(updated);
        }

        // ================================================================
        // OPERACIONES DE GESTIÓN DE ROLES (POST, DELETE)
        // ================================================================

        /// <summary>
        /// ASIGNA UN ROL A UN USUARIO.
        /// 
        /// FLUJO:
        /// 1. Valida que el usuario exista
        /// 2. Valida que el rol exista
        /// 3. Asigna rol al usuario (idempotente: no duplica si ya existe)
        /// 4. Persiste cambios
        /// 
        /// PARÁMETROS:
        /// - userId: identificador del usuario
        /// - roleId: identificador del rol a asignar
        /// 
        /// EXCEPCIONES POSIBLES:
        /// - EntityNotFoundException: si usuario o rol no existen
        /// 
        /// IDEMPOTENCIA:
        /// - Si ya existe la asignación, el método completa sin error
        /// - Se implementa en UserRepository.AssignRoleAsync
        /// 
        /// CASO DE USO:
        /// - POST /api/users/{userId}/roles/{roleId}
        /// - Asignar rol a usuario existente
        /// 
        /// NOTA:
        /// - Este método NO retorna datos (endpoint retorna 204 No Content)
        /// - La respuesta de éxito es la ausencia de excepción
        /// </summary>
        public async Task AssignRoleAsync(Guid userId, Guid roleId)
        {
            // VALIDACIÓN 1: Verificar que el usuario existe
            // AnyAsync retorna false si no existe, causando excepción
            if (!await _userRepo.AnyAsync(u => u.Id == userId))
                throw new EntityNotFoundException(nameof(User), userId);

            // VALIDACIÓN 2: Verificar que el rol existe
            if (!await _roleRepo.AnyAsync(r => r.Id == roleId))
                throw new EntityNotFoundException(nameof(Role), roleId);

            // OPERACIÓN: Delegar asignación a la capa de persistencia
            // El repository maneja la idempotencia (no duplica asignaciones)
            await _userRepo.AssignRoleAsync(userId, roleId);

            // PERSISTENCIA: Guardar cambios en la BD
            await _uow.SaveChangesAsync();
        }

        /// <summary>
        /// REMUEVE UN ROL ESPECÍFICO DE UN USUARIO.
        /// 
        /// FLUJO:
        /// 1. Valida que el usuario exista
        /// 2. Valida que el rol exista
        /// 3. Remueve la asignación del usuario-rol
        /// 4. Persiste cambios
        /// 
        /// PARÁMETROS:
        /// - userId: identificador del usuario
        /// - roleId: identificador del rol a remover
        /// 
        /// EXCEPCIONES POSIBLES:
        /// - EntityNotFoundException: si usuario o rol no existen
        /// 
        /// IDEMPOTENCIA:
        /// - Si la asignación no existe, completa sin error
        /// - Se implementa en UserRepository.RemoveRoleAsync
        /// 
        /// CASO DE USO:
        /// - DELETE /api/users/{userId}/roles/{roleId}
        /// - Remover un rol específico de un usuario
        /// 
        /// DIFERENCIA CON RemoveAllRolesAsync:
        /// - Este remueve UN rol específico
        /// - RemoveAllRolesAsync remueve TODOS los roles
        /// </summary>
        public async Task RemoveRoleAsync(Guid userId, Guid roleId)
        {
            // VALIDACIÓN 1: Verificar que el usuario existe
            if (!await _userRepo.AnyAsync(u => u.Id == userId))
                throw new EntityNotFoundException(nameof(User), userId);

            // VALIDACIÓN 2: Verificar que el rol existe
            // Aunque se remueva, el rol debe existir en el sistema
            if (!await _roleRepo.AnyAsync(r => r.Id == roleId))
                throw new EntityNotFoundException(nameof(Role), roleId);

            // OPERACIÓN: Delegar remoción a la capa de persistencia
            // Si la asignación no existe, no hace nada (idempotente)
            await _userRepo.RemoveRoleAsync(userId, roleId);

            // PERSISTENCIA: Guardar cambios
            await _uow.SaveChangesAsync();
        }

        /// <summary>
        /// REMUEVE TODOS LOS ROLES DE UN USUARIO.
        /// 
        /// FLUJO:
        /// 1. Valida que el usuario exista
        /// 2. Remueve TODAS las asignaciones de rol del usuario
        /// 3. Persiste cambios
        /// 
        /// PARÁMETRO:
        /// - userId: identificador del usuario a desasignar roles
        /// 
        /// EXCEPCIONES POSIBLES:
        /// - EntityNotFoundException: si el usuario no existe
        /// 
        /// IDEMPOTENCIA:
        /// - Si el usuario no tiene roles, completa sin error
        /// - RemoveRange con colección vacía no hace nada
        /// 
        /// CASO DE USO:
        /// - DELETE /api/users/{userId}/roles
        /// - Remover todos los roles de un usuario (ej: usuario despedido)
        /// - Reset de permisos
        /// 
        /// DIFERENCIA CON RemoveRoleAsync:
        /// - Este remueve TODOS los roles en una operación
        /// - RemoveRoleAsync remueve UN rol específico
        /// - Este es más eficiente que llamar RemoveRoleAsync en loop
        /// </summary>
        public async Task RemoveAllRolesAsync(Guid userId)
        {
            // VALIDACIÓN: Verificar que el usuario existe
            if (!await _userRepo.AnyAsync(u => u.Id == userId))
                throw new EntityNotFoundException(nameof(User), userId);

            // OPERACIÓN: Delegar remoción en lote a la capa de persistencia
            // RemoveRange es más eficiente que RemoveRoleAsync N veces
            await _userRepo.RemoveAllRolesAsync(userId);

            // PERSISTENCIA: Guardar todos los cambios de una vez
            await _uow.SaveChangesAsync();
        }

        // ================================================================
        // OPERACIONES CRUD DE ELIMINACIÓN (DELETE)
        // ================================================================

        /// <summary>
        /// ELIMINA (desactiva) UN USUARIO DEL SISTEMA.
        /// 
        /// FLUJO:
        /// 1. Valida que el usuario exista
        /// 2. Implementa soft delete (marca como inactivo)
        /// 3. No elimina datos, solo los oculta lógicamente
        /// 4. Persiste cambios
        /// 
        /// PARÁMETRO:
        /// - id: identificador del usuario a eliminar
        /// 
        /// EXCEPCIONES POSIBLES:
        /// - EntityNotFoundException: si el usuario no existe
        /// 
        /// TIPO DE ELIMINACIÓN: SOFT DELETE
        /// - No elimina filas de la BD (evita violaciones de FK)
        /// - Solo marca IsActive = false
        /// - Los datos siguen siendo consultables (auditoría)
        /// - Se puede "restaurar" reactivando el usuario
        /// 
        /// VENTAJAS DEL SOFT DELETE:
        /// 1. No rompe relaciones (FK a proyectos, test cases, etc.)
        /// 2. Auditoría: se sabe quién creó qué dato
        /// 3. Reversible: se puede reactivar el usuario
        /// 4. Cumplimiento normativo: GDPR requiere retención de datos
        /// 
        /// CASO DE USO:
        /// - DELETE /api/users/{id}
        /// - Remover un usuario (ej: usuario despedido)
        /// - No se usa DELETE de BD, solo actualización lógica
        /// 
        /// NOTA:
        /// - Los datos del usuario permanecen intactos en las tablas
        /// - Las búsquedas deben filtrar por IsActive = true
        /// </summary>
        public async Task DeleteAsync(Guid id)
        {
            // Registrar que se solicitó eliminar un usuario
            _logger.LogInformation("Eliminando usuario {UserId}.", id);

            // VALIDACIÓN: Obtener usuario a eliminar
            var user =
                await _userRepo.GetByIdAsync(id)
                ?? throw new EntityNotFoundException(nameof(User), id);

            // SOFT DELETE: Marcar como inactivo en lugar de eliminar
            // Esto preserva integridad referencial y auditoría
            user.IsActive = false;
            
            // Timestamp de última actualización
            user.UpdatedAt = DateTime.UtcNow;

            // PERSISTENCIA: Guardar el cambio de estado
            _userRepo.Update(user);
            await _uow.SaveChangesAsync();

            // Logging: Registrar que el usuario fue desactivado
            _logger.LogInformation("Usuario {UserId} desactivado.", id);
        }
    }
}
