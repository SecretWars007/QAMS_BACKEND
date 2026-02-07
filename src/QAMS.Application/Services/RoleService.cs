// src/QAMS.Application/Services/RoleService.cs
using AutoMapper;
using Microsoft.Extensions.Logging;
using QAMS.Application.DTOs.Roles;
using QAMS.Application.Interfaces;
using QAMS.Domain.Entities;
using QAMS.Domain.Exceptions;
using QAMS.Domain.Ports.Repositories;

namespace QAMS.Application.Services
{
    /// <summary>
    /// Servicio de gestión de roles dinámicos y asignación de permisos.
    /// SRP: solo gestiona roles y sus permisos.
    /// </summary>
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepo;
        private readonly IPermissionRepository _permRepo;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<RoleService> _logger;

        public RoleService(
            IRoleRepository roleRepo, IPermissionRepository permRepo,
            IUnitOfWork uow, IMapper mapper, ILogger<RoleService> logger)
        {
            _roleRepo = roleRepo;
            _permRepo = permRepo;
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<RoleDto> GetByIdAsync(Guid id)
        {
            _logger.LogInformation("Obteniendo rol {RoleId}.", id);
            var role = await _roleRepo.GetWithPermissionsAsync(id)
                ?? throw new EntityNotFoundException(nameof(Role), id);
            return _mapper.Map<RoleDto>(role);
        }

        public async Task<List<RoleDto>> GetAllAsync()
        {
            _logger.LogInformation("Obteniendo todos los roles.");
            var roles = await _roleRepo.GetAllWithPermissionsAsync();
            return _mapper.Map<List<RoleDto>>(roles);
        }

        public async Task<RoleDto> CreateAsync(CreateRoleDto dto)
        {
            _logger.LogInformation("Creando rol '{RoleName}'.", dto.Name);

            if (await _roleRepo.GetByNameAsync(dto.Name) is not null)
                throw new DomainException($"El rol '{dto.Name}' ya existe.");

            var role = new Role
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Description = dto.Description,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            await _roleRepo.AddAsync(role);
            await _uow.SaveChangesAsync();

            _logger.LogInformation("Rol '{RoleName}' creado con ID {RoleId}.", role.Name, role.Id);
            return _mapper.Map<RoleDto>(role);
        }

        public async Task<RoleDto> UpdateAsync(Guid id, CreateRoleDto dto)
        {
            _logger.LogInformation("Actualizando rol {RoleId}.", id);

            var role = await _roleRepo.GetByIdAsync(id)
                ?? throw new EntityNotFoundException(nameof(Role), id);

            role.Name = dto.Name;
            role.Description = dto.Description;
            _roleRepo.Update(role);
            await _uow.SaveChangesAsync();

            _logger.LogInformation("Rol {RoleId} actualizado.", id);
            var updated = await _roleRepo.GetWithPermissionsAsync(id);
            return _mapper.Map<RoleDto>(updated);
        }

        public async Task DeleteAsync(Guid id)
        {
            _logger.LogInformation("Desactivando rol {RoleId}.", id);
            var role = await _roleRepo.GetByIdAsync(id)
                ?? throw new EntityNotFoundException(nameof(Role), id);

            role.IsActive = false;
            _roleRepo.Update(role);
            await _uow.SaveChangesAsync();
        }

        /// <summary>
        /// Asigna permisos a un rol. Reemplaza todos los permisos existentes.
        /// Este es el corazón del RBAC dinámico.
        /// </summary>
        public async Task AssignPermissionsAsync(Guid roleId, AssignPermissionsDto dto)
        {
            _logger.LogInformation("Asignando {Count} permisos al rol {RoleId}.",
                dto.PermissionIds.Count, roleId);

            var role = await _roleRepo.GetWithPermissionsAsync(roleId)
                ?? throw new EntityNotFoundException(nameof(Role), roleId);

            // Limpiar permisos actuales
            role.RolePermissions.Clear();

            // Asignar nuevos permisos validando que existan
            foreach (var permissionId in dto.PermissionIds)
            {
                if (!await _permRepo.AnyAsync(p => p.Id == permissionId))
                    throw new EntityNotFoundException(nameof(Permission), permissionId);

                role.RolePermissions.Add(new RolePermission
                {
                    RoleId = roleId,
                    PermissionId = permissionId,
                    AssignedAt = DateTime.UtcNow
                });
            }

            _roleRepo.Update(role);
            await _uow.SaveChangesAsync();

            _logger.LogInformation("Permisos del rol {RoleId} actualizados exitosamente.", roleId);
        }

        /// <summary>
        /// Obtiene todos los permisos agrupados por módulo para la UI de admin.
        /// </summary>
        public async Task<List<PermissionDto>> GetAllPermissionsAsync()
        {
            _logger.LogInformation("Obteniendo todos los permisos.");
            var permissions = await _permRepo.GetAllAsync();
            return _mapper.Map<List<PermissionDto>>(permissions);
        }
    }
}
