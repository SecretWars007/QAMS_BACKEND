// src/QAMS.Application/Interfaces/IRbacService.cs
namespace QAMS.Application.Interfaces
{
    public interface IRbacService
    {
        Task<bool> UserHasPermissionAsync(Guid userId, string permissionCode);
        Task<IReadOnlyList<string>> GetUserPermissionsAsync(Guid userId);
        Task<bool> UserHasAnyPermissionAsync(Guid userId, params string[] permissionCodes);
    }
}
