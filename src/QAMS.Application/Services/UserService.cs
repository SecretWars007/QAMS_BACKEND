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
    /// Servicio de gestión de usuarios: CRUD completo con asignación de roles.
    /// SRP: solo gestiona usuarios. DIP: depende de abstracciones.
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

        public async Task<UserDto> GetByIdAsync(Guid id)
        {
            _logger.LogInformation("Obteniendo usuario {UserId}.", id);
            var user =
                await _userRepo.GetWithRolesAsync(id)
                ?? throw new EntityNotFoundException(nameof(User), id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            _logger.LogInformation("Obteniendo todos los usuarios.");
            var users = await _userRepo.GetAllAsync();
            return _mapper.Map<List<UserDto>>(users);
        }

        public async Task<UserDto> CreateAsync(CreateUserDto dto)
        {
            _logger.LogInformation("Creando usuario '{Username}'.", dto.Username);

            if (await _userRepo.AnyAsync(u => u.Username == dto.Username))
                throw new DomainException($"Username '{dto.Username}' ya existe.");

            if (await _userRepo.AnyAsync(u => u.Email == dto.Email))
                throw new DomainException($"Email '{dto.Email}' ya existe.");

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

            // Asignar roles validando que existan
            foreach (var roleId in dto.RoleIds)
            {
                if (!await _roleRepo.AnyAsync(r => r.Id == roleId))
                    throw new EntityNotFoundException(nameof(Role), roleId);

                user.UserRoles.Add(
                    new UserRole
                    {
                        UserId = user.Id,
                        RoleId = roleId,
                        AssignedAt = DateTime.UtcNow,
                    }
                );
            }

            await _userRepo.AddAsync(user);
            await _uow.SaveChangesAsync();

            _logger.LogInformation(
                "Usuario '{Username}' creado con ID {UserId}.",
                user.Username,
                user.Id
            );
            var created = await _userRepo.GetWithRolesAsync(user.Id);
            return _mapper.Map<UserDto>(created);
        }

        public async Task<UserDto> UpdateAsync(Guid id, UpdateUserDto dto)
        {
            _logger.LogInformation("Actualizando usuario {UserId}.", id);

            var user =
                await _userRepo.GetWithRolesAsync(id)
                ?? throw new EntityNotFoundException(nameof(User), id);

            // Actualizar campos básicos
            user.Email = dto.Email;
            user.FullName = dto.FullName;
            user.IsActive = dto.IsActive;
            user.UpdatedAt = DateTime.UtcNow;

            // Reemplazar roles: limpiar existentes y asignar nuevos
            user.UserRoles.Clear();
            foreach (var roleId in dto.RoleIds)
            {
                if (!await _roleRepo.AnyAsync(r => r.Id == roleId))
                    throw new EntityNotFoundException(nameof(Role), roleId);

                user.UserRoles.Add(
                    new UserRole
                    {
                        UserId = user.Id,
                        RoleId = roleId,
                        AssignedAt = DateTime.UtcNow,
                    }
                );
            }

            _userRepo.Update(user);
            await _uow.SaveChangesAsync();

            _logger.LogInformation("Usuario {UserId} actualizado.", id);
            var updated = await _userRepo.GetWithRolesAsync(id);
            return _mapper.Map<UserDto>(updated);
        }

        public async Task DeleteAsync(Guid id)
        {
            _logger.LogInformation("Eliminando usuario {UserId}.", id);
            var user =
                await _userRepo.GetByIdAsync(id)
                ?? throw new EntityNotFoundException(nameof(User), id);

            // Soft delete: desactivar en lugar de eliminar
            user.IsActive = false;
            user.UpdatedAt = DateTime.UtcNow;
            _userRepo.Update(user);
            await _uow.SaveChangesAsync();

            _logger.LogInformation("Usuario {UserId} desactivado.", id);
        }
    }
}
