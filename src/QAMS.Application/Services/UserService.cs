// src/QAMS.Application/Services/UserService.cs
using AutoMapper;
using Microsoft.Extensions.Logging;
using QAMS.Application.DTOs.Users;
using QAMS.Application.Interfaces;
using QAMS.Domain.Entities;
using QAMS.Domain.Exceptions;
using QAMS.Domain.Ports.Repositories;
using QAMS.Domain.Ports.Services;
using System.Linq;

namespace QAMS.Application.Services
{
    /// <summary>
    /// Servicio de Usuarios: Gestiona la lógica de negocio de usuarios, incluyendo
    /// creación, actualización, eliminación (soft-delete) y asignación de roles.
    /// Coordina UserRepo, RoleRepo y generadores de hash para seguridad.
    /// </summary>
    public class UserService(
        IUserRepository userRepo,
        IRoleRepository roleRepo,
        IPasswordHasher hasher,
        ICurrentUserService currentUserService,
        IUnitOfWork uow,
        IMapper mapper,
        IEmailService emailService,
        ILogger<UserService> logger)
        : IUserService
    {
        private readonly IUserRepository _userRepo = userRepo;
        private readonly IRoleRepository _roleRepo = roleRepo;
        private readonly IPasswordHasher _hasher = hasher;
        private readonly ICurrentUserService _currentUserService = currentUserService;
        private readonly IUnitOfWork _uow = uow;
        private readonly IMapper _mapper = mapper;
        private readonly IEmailService _emailService = emailService;
        private readonly ILogger<UserService> _logger = logger;


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
            _logger.LogInformation("Obteniendo todos los usuarios activos y inactivos con sus roles.");

            // Obtener todos los usuarios de la BD con roles incluidos
            var allUsers = await _userRepo.GetAllWithRolesAsync();

            // Mapear cada usuario a su DTO correspondiente
            return _mapper.Map<List<UserDto>>(allUsers);
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
                Id = Guid.NewGuid(),
                Username = dto.Username,
                Email = dto.Email,
                PasswordHash = _hasher.HashPassword(dto.Password),
                FullName = dto.FullName,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
            };

            // PERSISTENCIA: Agregar el usuario y sus roles de forma atómica
            await _userRepo.AddAsync(user);

            // ASIGNACIÓN DE ROLES: Validar y asignar cada rol del DTO
            foreach (var roleId in dto.RoleIds)
            {
                if (!await _roleRepo.AnyAsync(r => r.Id == roleId))
                    throw new EntityNotFoundException(nameof(Role), roleId);

                await _userRepo.AssignRoleAsync(user.Id, roleId);
            }

            // Un solo SaveChangesAsync para garantizar atomicidad
            await _uow.SaveChangesAsync();

            _logger.LogInformation("Usuario '{Username}' creado con ID {UserId}.", user.Username, user.Id);

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

            // VALIDACIÓN: El email no debe estar en uso por OTRO usuario
            if (user.Email != dto.Email && await _userRepo.AnyAsync(u => u.Email == dto.Email && u.Id != id))
                throw new DomainException($"El email '{dto.Email}' ya está siendo usado por otro usuario.");

            if (dto.IsActive.HasValue)
            {
                // VALIDACIÓN: No permitir auto-desactivación (similar a self-delete)
                if (id == _currentUserService.UserId && !dto.IsActive.Value && user.IsActive)
                {
                    _logger.LogWarning("Intento de auto-desactivación bloqueado para el usuario {UserId}.", id);
                    throw new DomainException("No puedes desactivar tu propio usuario desde este endpoint. Usa la configuración de perfil si está disponible.");
                }

                // VALIDACIÓN: No permitir inactivar si tiene roles asignados
                if (!dto.IsActive.Value && user.IsActive && user.UserRoles != null && user.UserRoles.Count > 0)
                {
                    _logger.LogWarning("Intento de inactivación fallido: El usuario {UserId} tiene roles asignados.", id);
                    throw new DomainException("No se puede inactivar al usuario si tiene roles asignados. Primero remueve sus roles.");
                }

                user.IsActive = dto.IsActive.Value;
            }

            // Actualizar campos
            user.Email = dto.Email;
            user.FullName = dto.FullName;
            user.UpdatedAt = DateTime.UtcNow;

            // PERSISTENCIA 1: Guardar cambios básicos
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
            // VALIDACIÓN 1: Verificar que el usuario existe y está activo
            var user = await _userRepo.GetByIdAsync(userId)
                ?? throw new EntityNotFoundException(nameof(User), userId);

            if (!user.IsActive)
                throw new DomainException("No se pueden asignar roles a un usuario inactivo.");

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

            // VALIDACIÓN 1: No permitir que el usuario se elimine a sí mismo
            if (id == _currentUserService.UserId)
            {
                _logger.LogWarning("Intento fallido de auto-eliminación por el usuario {UserId}.", id);
                throw new DomainException("No puedes eliminar tu propio usuario.");
            }

            // VALIDACIÓN 2: Obtener usuario a eliminar con sus roles
            var user =
                await _userRepo.GetWithRolesAsync(id)
                ?? throw new EntityNotFoundException(nameof(User), id);

            // VALIDACIÓN 3: No permitir borrar si tiene roles asignados
            if (user.UserRoles != null && user.UserRoles.Count > 0)
            {
                _logger.LogWarning("Intento de eliminación fallido: El usuario {UserId} tiene {RoleCount} roles asignados.", id, user.UserRoles.Count);
                throw new DomainException($"No se puede eliminar el usuario porque tiene roles asignados. Primero remueve sus roles.");
            }

            // SOFT DELETE: Marcar como eliminado e inactivo
            // Esto preserva integridad referencial y oculta al usuario gracias al Global Query Filter
            user.IsActive = false;
            user.LogicallyDeleted = true;
            
            // Timestamp de última actualización
            user.UpdatedAt = DateTime.UtcNow;

            // PERSISTENCIA: Guardar el cambio de estado
            _userRepo.Update(user);
            await _uow.SaveChangesAsync();

            // Logging: Registrar que el usuario fue desactivado
            _logger.LogInformation("Usuario {UserId} desactivado.", id);
        }

        /// <summary>
        /// Cambia la contraseña de un usuario (Admin reset).
        /// </summary>
        public async Task ResetPasswordAsync(Guid userId, string newPassword)
        {
            _logger.LogInformation("Restableciendo contraseña para el usuario {UserId}.", userId);

            var user = await _userRepo.GetByIdAsync(userId)
                ?? throw new EntityNotFoundException(nameof(User), userId);

            user.PasswordHash = _hasher.HashPassword(newPassword);
            user.UpdatedAt = DateTime.UtcNow;

            _userRepo.Update(user);
            await _uow.SaveChangesAsync();

            _logger.LogInformation("Contraseña restablecida exitosamente para {UserId}.", userId);

            try 
            {
                var body = QAMS.Application.Templates.EmailTemplates.GetAdminPasswordResetEmailHtml(user.FullName, newPassword);
                await _emailService.SendEmailAsync(user.Email, "Contraseña actualizada por administrador", body);
            }
            catch(Exception emailEx) 
            {
                _logger.LogWarning(emailEx, "No se pudo enviar el correo de confirmación de Reset Password a '{Email}'.", user.Email);
            }
        }
    }
}

