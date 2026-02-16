// src/QAMS.Infrastructure/Security/CurrentUserService.cs
using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using QAMS.Application.Interfaces;

namespace QAMS.Infrastructure.Security
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid? UserId
        {
            get
            {
                var user = _httpContextAccessor.HttpContext?.User;
                var id = user?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value
                      ?? user?.FindFirst("sub")?.Value
                      ?? user?.FindFirst("id")?.Value;

                return id != null && Guid.TryParse(id, out var guid) ? guid : null;
            }
        }

        public string? UserName => _httpContextAccessor.HttpContext?.User?.Identity?.Name;
    }
}
