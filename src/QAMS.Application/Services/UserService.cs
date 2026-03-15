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
    /// Servicio de Usuarios: Gestiona la lógica de negocio de usuarios, incluyendo
    /// creación, actualización, eliminación (soft-delete) y asignación de roles.
    /// Coordina UserRepo, RoleRepo y generadores de hash para seguridad.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IRoleRepository _roleRepo;
        private readonly IPasswordHasher _hasher;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;

        public UserService(
            IUserRepository userRepo,
            IRoleRepository roleRepo,
            IPasswordHasher hasher,
            IUnitOfWork uow,
            IMapper mapper,
            ILogger<UserService> logger
        )
        {
            _userRepo = userRepo;
            _roleRepo = roleRepo;
            _hasher = hasher;
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene un usuario específico por su ID junto con sus roles cargados.
        /// Lanza EntityNotFoundException si no existe.
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
        /// Obtiene la lista completa de usuarios con sus respectivos roles.
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
        /// <summary>
        /// Crea un nuevo usuario validando que el correo y nombre de usuario no existan.
        /// Cifra la contraseña y asigna los roles iniciales provistos.
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
        /// <summary>
        /// Actualiza la información base de un usuario y reemplaza TODOS sus roles actuales
        /// por la nueva lista provista en el DTO.
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
        /// <summary>
        /// Asigna un rol específico a un usuario. Es una operación idempotente (si ya existe, no hace nada).
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
        /// Remueve la asignación de un rol específico para un usuario. Idempotente.
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
        /// Elimina todas las asociaciones de un usuario con todos los roles.
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
        /// <summary>
        /// Realiza un borrado lógico (soft-delete) de un usuario cambiando su estado IsActive a falso.
        /// No elimina los registros físicos para mantener auditoría e integridad referencial.
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

