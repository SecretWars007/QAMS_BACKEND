// src/QAMS.Application/Interfaces/ICurrentUserService.cs
using System;

namespace QAMS.Application.Interfaces
{
    public interface ICurrentUserService
    {
        Guid? UserId { get; }
        string? UserName { get; }
    }
}
