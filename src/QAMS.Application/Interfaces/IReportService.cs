// src/QAMS.Application/Interfaces/IReportService.cs
using System;
using System.Threading.Tasks;
using QAMS.Application.DTOs.Reports;

namespace QAMS.Application.Interfaces
{
    public interface IReportService
    {
        Task<byte[]> GenerateProjectReportAsync(ProjectReportFilterDto filter);
        Task<byte[]> GenerateBurndownReportAsync(Guid projectId);
        Task<byte[]> GenerateProjectObservationsReportAsync(Guid projectId);
        Task<byte[]> GenerateFinalComplianceReportAsync(Guid projectId);
        Task<byte[]> GenerateTestSummaryReportAsync(Guid testPlanId);
    }
}
