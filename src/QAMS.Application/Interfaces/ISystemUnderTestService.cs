// src/QAMS.Application/Interfaces/ISystemUnderTestService.cs
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QAMS.Application.DTOs.SystemsUnderTest;

namespace QAMS.Application.Interfaces
{
    public interface ISystemUnderTestService
    {
        Task<IReadOnlyList<SystemUnderTestDto>> GetByProjectIdAsync(Guid projectId);
        Task<SystemUnderTestDto?> GetByIdAsync(Guid id);
        Task<SystemUnderTestDto> CreateAsync(CreateSystemUnderTestDto dto);
        Task<SystemUnderTestDto> UpdateAsync(Guid id, UpdateSystemUnderTestDto dto);
        Task DeleteAsync(Guid id);
    }
}
