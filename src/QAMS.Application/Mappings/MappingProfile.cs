// src/QAMS.Application/Mappings/MappingProfile.cs
using System.Linq;
using AutoMapper;
using QAMS.Application.DTOs.Auth;
using QAMS.Application.DTOs.Catalogs;
using QAMS.Application.DTOs.Dashboard;
using QAMS.Application.DTOs.Kanban;
using QAMS.Application.DTOs.Projects;
using QAMS.Application.DTOs.Roles;
using QAMS.Application.DTOs.TestCases;
using QAMS.Application.DTOs.TestExecutions;
using QAMS.Application.DTOs.TestPlans;
using QAMS.Application.DTOs.TestSuites;
using QAMS.Application.DTOs.Users;
using QAMS.Application.DTOs.Reviews;
using QAMS.Domain.Entities;
using QAMS.Domain.Entities.Catalogs;

namespace QAMS.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ConfigureRbacMappings();
            ConfigureCatalogMappings();
            ConfigureProjectMappings();
            ConfigureTestCaseMappings();
            ConfigureExecutionMappings();
            ConfigureKanbanMappings();
            ConfigureReviewMappings();
        }

        private void ConfigureRbacMappings()
        {
            CreateMap<Permission, PermissionDto>();

            CreateMap<Role, RoleDto>()
                .ForMember(d => d.Permissions, o => o.MapFrom(s => s.RolePermissions.Select(rp => rp.Permission)));

            CreateMap<User, UserDto>()
                .ForMember(d => d.Roles, o => o.MapFrom(s => s.UserRoles.Select(ur => ur.Role != null ? ur.Role.Name : string.Empty)));
        }

        private void ConfigureCatalogMappings()
        {
            CreateMap<ExecutionStatus, CatalogItemDto>();
            CreateMap<EvidenceType, CatalogItemDto>();
            CreateMap<StepResultStatus, CatalogItemDto>();
            CreateMap<TaskPriority, CatalogItemDto>();
            CreateMap<TestCasePriority, CatalogItemDto>();
        }

        private void ConfigureProjectMappings()
        {
            CreateMap<TestPlanCriteria, TestPlanCriteriaDto>();
            CreateMap<TestPlanCriteriaDto, TestPlanCriteria>();

            CreateMap<TestPlan, TestPlanDto>()
                .ForMember(d => d.ProjectName, o => o.MapFrom(s => s.Project != null ? s.Project.Name : string.Empty))
                .ForMember(d => d.CreatedByUserName, o => o.MapFrom(s => s.CreatedBy != null ? s.CreatedBy.FullName : string.Empty))
                .ForMember(d => d.Status, o => o.MapFrom(s => s.Status != null ? new CatalogItemDto { Id = s.Status.Id, Name = s.Status.Name } : null))
                .ForMember(d => d.TestSuites, o => o.MapFrom(s => s.TestPlanSuites.Select(tps => tps.TestSuite)));

            CreateMap<CreateTestPlanDto, TestPlan>();

            CreateMap<Project, ProjectDto>()
                .ForMember(d => d.TestSuiteCount, o => o.MapFrom(s => s.TestSuites.Count))
                .ForMember(d => d.KanbanBoardCount, o => o.MapFrom(s => s.KanbanBoards.Count))
                .ForMember(d => d.CreatedByUserName, o => o.MapFrom(s => s.CreatedBy != null ? s.CreatedBy.FullName : string.Empty))
                .ForMember(d => d.ProjectStatusName, o => o.MapFrom(s => s.ProjectStatus != null ? s.ProjectStatus.Name : string.Empty))
                .ForMember(d => d.ProjectPriorityName, o => o.MapFrom(s => s.ProjectPriority != null ? s.ProjectPriority.Name : string.Empty))
                .ForMember(d => d.ProjectPriorityId, o => o.MapFrom(s => s.ProjectPriorityId))
                .ForMember(d => d.TesterNames, o => o.MapFrom(s => s.ProjectTesters.Where(pt => pt.User != null).Select(pt => pt.User!.FullName)))
                .ForMember(d => d.DevolucionesCounter, o => o.MapFrom(s => s.DevolucionesCounter))
                .ForMember(d => d.HistoricDevolutions, o => o.MapFrom(s => s.HistoricDevolutions))
                .ForMember(d => d.Requirements, o => o.MapFrom(s => s.Requirements));

            CreateMap<Requirement, RequirementDto>()
                .ForMember(d => d.RequirementTypeName, o => o.MapFrom(s => s.RequirementType != null ? s.RequirementType.Name : string.Empty))
                .ForMember(d => d.RequirementPriorityName, o => o.MapFrom(s => s.RequirementPriority != null ? s.RequirementPriority.Name : string.Empty))
                .ForMember(d => d.RequirementComplexityName, o => o.MapFrom(s => s.RequirementComplexity != null ? s.RequirementComplexity.Name : string.Empty))
                .ForMember(d => d.RequirementStatusName, o => o.MapFrom(s => s.RequirementStatus != null ? s.RequirementStatus.Name : string.Empty));
            CreateMap<CreateRequirementDto, Requirement>();

            CreateMap<ProjectDevolution, ProjectDevolutionDto>()
                .ForMember(d => d.CreatedByUserName, o => o.MapFrom(s => s.CreatedBy != null ? s.CreatedBy.FullName : string.Empty));
        }

        private void ConfigureTestCaseMappings()
        {
            CreateMap<TestCase, TestCaseDto>()
                .ForMember(d => d.PriorityName, o => o.MapFrom(s => s.Priority != null ? s.Priority.Name : string.Empty))
                .ForMember(d => d.PriorityCode, o => o.MapFrom(s => s.Priority != null ? s.Priority.Code : string.Empty))
                .ForMember(d => d.CreatedByUserName, o => o.MapFrom(s => s.CreatedBy != null ? s.CreatedBy.FullName : string.Empty))
                .ForMember(d => d.TestTypeName, o => o.MapFrom(s => s.TestType != null ? s.TestType.Name : string.Empty))
                .ForMember(d => d.ProjectName, o => o.MapFrom(s => s.Project != null ? s.Project.Name : string.Empty))
                .ForMember(d => d.TestSuiteName, o => o.MapFrom(s => s.TestSuite != null ? s.TestSuite.Name : string.Empty))
                .ForMember(d => d.ImpactLevel, o => o.MapFrom(s => s.ImpactLevel))
                .ForMember(d => d.LikelihoodLevel, o => o.MapFrom(s => s.LikelihoodLevel))
                .ForMember(d => d.RiskScore, o => o.MapFrom(s => s.RiskScore))
                .ForMember(d => d.CertifierNames, o => o.MapFrom(s => s.Certifiers.Where(c => c.User != null).Select(c => c.User!.FullName)))
                .ForMember(d => d.CertifierUserIds, o => o.MapFrom(s => s.Certifiers.Select(c => c.UserId)))
                .ForMember(d => d.Steps, o => o.MapFrom(s => s.TestSteps))
                .ForMember(d => d.DesignTechniqueName, o => o.MapFrom(s => s.DesignTechnique != null ? s.DesignTechnique.Name : string.Empty));

            CreateMap<TestSuite, TestSuiteDto>()
                .ForMember(d => d.TestCaseCount, o => o.MapFrom(s => s.TestCases.Count))
                .ForMember(d => d.StatusName, o => o.MapFrom(s => s.Status != null ? s.Status.Name : string.Empty));

            CreateMap<TestStep, TestStepDto>();
        }

        private void ConfigureExecutionMappings()
        {
            CreateMap<TestExecution, TestExecutionDto>()
                .ForMember(d => d.TestCaseTitle, o => o.MapFrom(s => s.TestCase != null ? s.TestCase.Title : string.Empty))
                .ForMember(d => d.TesterName, o => o.MapFrom(s => s.Tester != null ? s.Tester.FullName : string.Empty))
                .ForMember(d => d.StatusName, o => o.MapFrom(s => s.Status != null ? s.Status.Name : string.Empty))
                .ForMember(d => d.StatusCode, o => o.MapFrom(s => s.Status != null ? s.Status.Code : string.Empty))
                .ForMember(d => d.StepResults, o => o.MapFrom(s => s.StepResults.OrderBy(sr => sr.TestStep != null ? sr.TestStep.StepOrder : 0)));

            CreateMap<ExecutionStepResult, StepResultDto>()
                .ForMember(d => d.StatusName, o => o.MapFrom(s => s.Status != null ? s.Status.Name : string.Empty))
                .ForMember(d => d.StepOrder, o => o.MapFrom(s => s.TestStep != null ? s.TestStep.StepOrder : 0))
                .ForMember(d => d.Action, o => o.MapFrom(s => s.TestStep != null ? s.TestStep.Action : string.Empty))
                .ForMember(d => d.Evidences, o => o.MapFrom(s => s.Evidences));

            CreateMap<ExecutionStepObservation, ObservationDto>()
                .ForMember(d => d.CreatedByUserName, o => o.MapFrom(s => s.CreatedBy != null ? s.CreatedBy.FullName : string.Empty))
                .ForMember(d => d.RespondedByUserName, o => o.MapFrom(s => s.RespondedBy != null ? s.RespondedBy.FullName : string.Empty));

            CreateMap<Evidence, EvidenceDto>()
                .ForMember(d => d.ExecutionStepResultId, o => o.MapFrom(s => s.ExecutionStepResultId))
                .ForMember(d => d.FileTypeName, o => o.MapFrom(s => s.FileType != null ? s.FileType.Name : string.Empty))
                .ForMember(d => d.FileUrl, o => o.Ignore());
        }

        private void ConfigureKanbanMappings()
        {
            CreateMap<KanbanBoard, KanbanBoardDto>();
            CreateMap<KanbanColumn, KanbanColumnDto>();

            CreateMap<KanbanTask, KanbanTaskDto>()
                .ForMember(d => d.AssigneeName,
                    o => o.MapFrom(s => s.ResponsibleUser != null ? s.ResponsibleUser.FullName : string.Empty))
                .ForMember(d => d.PriorityName,
                    o => o.MapFrom(s => s.Priority != null ? s.Priority.Name : string.Empty))
                .ForMember(d => d.PriorityCode,
                    o => o.MapFrom(s => s.Priority != null ? s.Priority.Code : string.Empty))
                // ── Contexto de Certificación ISTQB ──
                .ForMember(d => d.TestCaseTitle,
                    o => o.MapFrom(s => s.TestCase != null ? s.TestCase.Title : null))
                .ForMember(d => d.TotalSteps,
                    o => o.MapFrom(s => s.TestCase != null ? s.TestCase.TestSteps.Count : 0))
                .ForMember(d => d.CompletedSteps,
                    o => o.MapFrom(s => GetCompletedSteps(s)))
                .ForMember(d => d.PassedSteps,
                    o => o.MapFrom(s => GetPassedSteps(s)))
                .ForMember(d => d.OpenDefectsCount,
                    o => o.MapFrom(s => s.TestCase != null
                        ? s.TestCase.Defects.Count(d => !d.IsDeleted &&
                            d.DefectStatus != null && d.DefectStatus.Code != "CLOSED")
                        : 0))
                .ForMember(d => d.LastExecutionStatusCode,
                    o => o.MapFrom(s => GetLastExecutionStatusCode(s)))
                .ForMember(d => d.LastExecutionStatusName,
                    o => o.MapFrom(s => GetLastExecutionStatusName(s)))
                .ForMember(d => d.SutName,
                    o => o.MapFrom(s => GetSutName(s)));
        }

        private static int GetCompletedSteps(KanbanTask s)
        {
            if (s.TestCase == null) return 0;
            var latest = s.TestCase.TestExecutions.OrderByDescending(e => e.CreatedAt).FirstOrDefault();
            if (latest == null) return 0;
            return latest.StepResults.Count(sr => sr.Status != null && (sr.Status.Code == "PASS" || sr.Status.Code == "FAIL"));
        }

        private static int GetPassedSteps(KanbanTask s)
        {
            if (s.TestCase == null) return 0;
            var latest = s.TestCase.TestExecutions.OrderByDescending(e => e.CreatedAt).FirstOrDefault();
            if (latest == null) return 0;
            return latest.StepResults.Count(sr => sr.Status != null && sr.Status.Code == "PASS");
        }

        private static string? GetLastExecutionStatusCode(KanbanTask s)
        {
            if (s.TestCase == null) return null;
            var latest = s.TestCase.TestExecutions.OrderByDescending(e => e.CreatedAt).FirstOrDefault();
            return latest?.Status?.Code;
        }

        private static string? GetLastExecutionStatusName(KanbanTask s)
        {
            if (s.TestCase == null) return null;
            var latest = s.TestCase.TestExecutions.OrderByDescending(e => e.CreatedAt).FirstOrDefault();
            return latest?.Status?.Name;
        }

        private static string? GetSutName(KanbanTask s)
        {
            if (s.TestCase == null || s.Column == null || s.Column.Board == null || s.Column.Board.Project == null)
                return null;
            return s.Column.Board.Project.SystemUnderTest?.Name;
        }

        private void ConfigureReviewMappings()
        {
            CreateMap<ReviewSession, ReviewSessionDto>()
                .ForMember(d => d.ProjectName, o => o.MapFrom(s => s.Project != null ? s.Project.Name : string.Empty))
                .ForMember(d => d.ReviewTypeCode, o => o.MapFrom(s => s.ReviewType != null ? s.ReviewType.Code : string.Empty))
                .ForMember(d => d.ReviewTypeName, o => o.MapFrom(s => s.ReviewType != null ? s.ReviewType.Name : string.Empty))
                .ForMember(d => d.StatusCode, o => o.MapFrom(s => s.Status != null ? s.Status.Code : string.Empty))
                .ForMember(d => d.StatusName, o => o.MapFrom(s => s.Status != null ? s.Status.Name : string.Empty))
                .ForMember(d => d.ModeratorName, o => o.MapFrom(s => s.Moderator != null ? s.Moderator.FullName : string.Empty))
                .ForMember(d => d.AuthorName, o => o.MapFrom(s => s.Author != null ? s.Author.FullName : string.Empty))
                .ForMember(d => d.CreatedByUserName, o => o.MapFrom(s => s.CreatedBy != null ? s.CreatedBy.FullName : string.Empty))
                .ForMember(d => d.Participants, o => o.MapFrom(s => s.Participants))
                .ForMember(d => d.Findings, o => o.MapFrom(s => s.Findings));

            CreateMap<ReviewFinding, ReviewFindingDto>()
                .ForMember(d => d.FindingTypeCode, o => o.MapFrom(s => s.FindingType != null ? s.FindingType.Code : string.Empty))
                .ForMember(d => d.FindingTypeName, o => o.MapFrom(s => s.FindingType != null ? s.FindingType.Name : string.Empty))
                .ForMember(d => d.SeverityCode, o => o.MapFrom(s => s.Severity != null ? s.Severity.Code : string.Empty))
                .ForMember(d => d.SeverityName, o => o.MapFrom(s => s.Severity != null ? s.Severity.Name : string.Empty))
                .ForMember(d => d.FindingStatusCode, o => o.MapFrom(s => s.FindingStatus != null ? s.FindingStatus.Code : string.Empty))
                .ForMember(d => d.FindingStatusName, o => o.MapFrom(s => s.FindingStatus != null ? s.FindingStatus.Name : string.Empty))
                .ForMember(d => d.AssignedToName, o => o.MapFrom(s => s.AssignedTo != null ? s.AssignedTo.FullName : string.Empty));

            CreateMap<ReviewParticipant, ReviewParticipantDto>()
                .ForMember(d => d.UserName, o => o.MapFrom(s => s.User != null ? s.User.FullName : string.Empty))
                .ForMember(d => d.UserEmail, o => o.MapFrom(s => s.User != null ? s.User.Email : string.Empty));

            CreateMap<CreateReviewSessionDto, ReviewSession>();
            CreateMap<CreateReviewFindingDto, ReviewFinding>();
        }
    }
}
