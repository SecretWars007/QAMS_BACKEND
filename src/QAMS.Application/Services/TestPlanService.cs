using AutoMapper;
using QAMS.Application.DTOs.TestPlans;
using QAMS.Domain.Exceptions;
using QAMS.Domain.Ports.Repositories;
using QAMS.Application.Interfaces;
using QAMS.Application.Interfaces.Repositories;
using QAMS.Domain.Entities;
using System.Security.Cryptography;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QAMS.Application.Services;

public class TestPlanService(
    ITestPlanRepository testPlanRepository,
    IProjectRepository projectRepository,
    ITestSuiteRepository testSuiteRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper,
    ICurrentUserService currentUserService) : ITestPlanService
{
    private readonly ITestPlanRepository _testPlanRepository = testPlanRepository;
    private readonly IProjectRepository _projectRepository = projectRepository;
    private readonly ITestSuiteRepository _testSuiteRepository = testSuiteRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly ICurrentUserService _currentUserService = currentUserService;

    public async Task<IEnumerable<TestPlanDto>> GetAllAsync()
    {
        var plans = await _testPlanRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<TestPlanDto>>(plans);
    }

    public async Task<IEnumerable<TestPlanDto>> GetByProjectAsync(Guid projectId)
    {
        var plans = await _testPlanRepository.GetByProjectAsync(projectId);
        return _mapper.Map<IEnumerable<TestPlanDto>>(plans);
    }

    public async Task<IEnumerable<TestPlanDto>> GetBySutAsync(Guid sutId)
    {
        var plans = await _testPlanRepository.GetBySutAsync(sutId);
        return _mapper.Map<IEnumerable<TestPlanDto>>(plans);
    }

    public async Task<TestPlanDto> GetByIdAsync(Guid id)
    {
        var plan = await _testPlanRepository.GetByIdWithDetailsAsync(id) 
            ?? throw new EntityNotFoundException(nameof(TestPlan), id);

        return _mapper.Map<TestPlanDto>(plan);
    }

    public async Task<TestPlanDto> CreateAsync(CreateTestPlanDto dto)
    {
        var project = await _projectRepository.GetByIdAsync(dto.ProjectId) 
            ?? throw new EntityNotFoundException(nameof(Project), dto.ProjectId);

        var plan = _mapper.Map<TestPlan>(dto);
        plan.StatusId = 1; // Draft / Borrador
        plan.StartDate = plan.StartDate.Kind == DateTimeKind.Unspecified ? DateTime.SpecifyKind(plan.StartDate, DateTimeKind.Utc) : plan.StartDate.ToUniversalTime();
        plan.EndDate = plan.EndDate.Kind == DateTimeKind.Unspecified ? DateTime.SpecifyKind(plan.EndDate, DateTimeKind.Utc) : plan.EndDate.ToUniversalTime();
        plan.TestPlanTypeId = dto.TestPlanTypeId;
        plan.TestLevelId = dto.TestLevelId;
        plan.TestManagerId = dto.TestManagerId;

        await AddTestSuitesAsync(plan, dto.TestSuiteIds, dto.ProjectId);
        InitializeCriteria(plan);
        AddMilestones(plan, dto.Milestones);
        AddRisks(plan, dto.Risks);

        await _testPlanRepository.AddAsync(plan);
        await _unitOfWork.SaveChangesAsync();

        var createdPlan = await _testPlanRepository.GetByIdWithDetailsAsync(plan.Id);
        return _mapper.Map<TestPlanDto>(createdPlan);
    }

    private async Task AddTestSuitesAsync(TestPlan plan, List<Guid>? testSuiteIds, Guid projectId)
    {
        if (testSuiteIds is { Count: > 0 })
        {
            foreach (var suiteId in testSuiteIds)
            {
                var suite = await _testSuiteRepository.GetByIdAsync(suiteId);
                if (suite != null && suite.ProjectId == projectId)
                {
                    plan.TestPlanSuites.Add(new TestPlanSuite
                    {
                        TestSuiteId = suiteId,
                        TestPlanId = plan.Id
                    });
                }
            }
        }
    }

    private static void InitializeCriteria(TestPlan plan)
    {
        if (plan.Criteria is { Count: > 0 })
        {
            foreach (var c in plan.Criteria)
            {
                c.IsMet = false; // Siempre inicia sin cumplir
            }
        }
    }

    private static void AddMilestones(TestPlan plan, List<TestPlanMilestoneDto>? milestones)
    {
        if (milestones is { Count: > 0 })
        {
            foreach (var m in milestones)
            {
                plan.Milestones.Add(new TestPlanMilestone
                {
                    Name = m.Name,
                    Description = m.Description,
                    DueDate = m.DueDate.Kind == DateTimeKind.Unspecified ? DateTime.SpecifyKind(m.DueDate, DateTimeKind.Utc) : m.DueDate.ToUniversalTime(),
                    IsCompleted = m.IsCompleted,
                    TestPlanId = plan.Id
                });
            }
        }
    }

    private static void AddRisks(TestPlan plan, List<TestPlanRiskDto>? risks)
    {
        if (risks is { Count: > 0 })
        {
            foreach (var r in risks)
            {
                plan.Risks.Add(new TestPlanRisk
                {
                    Description = r.Description,
                    Probability = r.Probability,
                    Impact = r.Impact,
                    Mitigation = r.Mitigation,
                    TestPlanId = plan.Id
                });
            }
        }
    }

    public async Task<TestPlanDto> UpdateAsync(Guid id, UpdateTestPlanDto dto)
    {
        var plan = await _testPlanRepository.GetByIdWithDetailsAsync(id) 
            ?? throw new EntityNotFoundException(nameof(TestPlan), id);

        ValidateIstqbClosure(plan, dto.StatusId);

        plan.Name = dto.Name;
        plan.Objectives = dto.Objectives;
        plan.Scope = dto.Scope;
        plan.OutOfScope = dto.OutOfScope;
        plan.TestStrategyId = dto.TestStrategyId;
        plan.TestPlanTypeId = dto.TestPlanTypeId;
        plan.TestLevelId = dto.TestLevelId;
        plan.TestManagerId = dto.TestManagerId;
        plan.RiskLevelId = dto.RiskLevelId;
        plan.TestEnvironmentId = dto.TestEnvironmentId;
        plan.TestSchedule = dto.TestSchedule;
        plan.EstimatedEffortHours = dto.EstimatedEffortHours;

        plan.StartDate = dto.StartDate.Kind == DateTimeKind.Unspecified ? DateTime.SpecifyKind(dto.StartDate, DateTimeKind.Utc) : dto.StartDate.ToUniversalTime();
        plan.EndDate = dto.EndDate.Kind == DateTimeKind.Unspecified ? DateTime.SpecifyKind(dto.EndDate, DateTimeKind.Utc) : dto.EndDate.ToUniversalTime();
        plan.StatusId = dto.StatusId;

        plan.TestPlanSuites.Clear();
        await AddTestSuitesAsync(plan, dto.TestSuiteIds, plan.ProjectId);

        UpdateCriteria(plan, dto.Criteria);
        UpdateMilestones(plan, dto.Milestones);
        UpdateRisks(plan, dto.Risks);

        _testPlanRepository.Update(plan);
        await _unitOfWork.SaveChangesAsync();

        var updatedPlan = await _testPlanRepository.GetByIdWithDetailsAsync(plan.Id);
        return _mapper.Map<TestPlanDto>(updatedPlan);
    }

    private static void ValidateIstqbClosure(TestPlan plan, int newStatusId)
    {
        if (newStatusId == 4 && plan.StatusId != 4) // 4 = Closed
        {
            var exitCriteria = plan.Criteria.Where(c => c.CriteriaType == "EXIT").ToList();
            if (exitCriteria.Count > 0 && exitCriteria.Exists(c => !c.IsMet))
            {
                throw new InvalidOperationException("No se puede cerrar el plan de pruebas porque no se han cumplido todos los Criterios de Salida (Exit Criteria).");
            }
        }
    }

    private static void UpdateCriteria(TestPlan plan, List<TestPlanCriteriaDto>? criteriaDto)
    {
        if (criteriaDto != null)
        {
            var incomingIds = criteriaDto.Where(c => c.Id != Guid.Empty).Select(c => c.Id).ToList();
            var toRemove = plan.Criteria.Where(c => !incomingIds.Contains(c.Id)).ToList();
            foreach (var item in toRemove)
            {
                plan.Criteria.Remove(item);
            }

            foreach (var cDto in criteriaDto)
            {
                if (cDto.Id != Guid.Empty)
                {
                    var existing = plan.Criteria.FirstOrDefault(c => c.Id == cDto.Id);
                    if (existing != null)
                    {
                        existing.CriteriaType = cDto.CriteriaType;
                        existing.Description = cDto.Description;
                        existing.IsMet = cDto.IsMet;
                        existing.Priority = cDto.Priority;
                        existing.Category = cDto.Category;
                    }
                }
                else
                {
                    plan.Criteria.Add(new TestPlanCriteria
                    {
                        TestPlanId = plan.Id,
                        CriteriaType = cDto.CriteriaType,
                        Description = cDto.Description,
                        IsMet = cDto.IsMet,
                        Priority = cDto.Priority,
                        Category = cDto.Category
                    });
                }
            }
        }
    }

    private static void UpdateMilestones(TestPlan plan, List<TestPlanMilestoneDto>? milestonesDto)
    {
        if (milestonesDto != null)
        {
            var incomingIds = milestonesDto.Where(m => m != null && m.Id.HasValue && m.Id.Value != Guid.Empty).Select(m => (Guid)m.Id!).ToList();
            var toRemove = plan.Milestones.Where(m => !incomingIds.Contains(m.Id)).ToList();
            foreach (var item in toRemove) plan.Milestones.Remove(item);

            foreach (var mDto in milestonesDto)
            {
                if (mDto.Id.HasValue && mDto.Id.Value != Guid.Empty)
                {
                    var existing = plan.Milestones.FirstOrDefault(m => m.Id == mDto.Id.Value);
                    if (existing != null)
                    {
                        existing.Name = mDto.Name;
                        existing.Description = mDto.Description;
                        existing.DueDate = mDto.DueDate.Kind == DateTimeKind.Unspecified ? DateTime.SpecifyKind(mDto.DueDate, DateTimeKind.Utc) : mDto.DueDate.ToUniversalTime();
                        existing.IsCompleted = mDto.IsCompleted;
                    }
                }
                else
                {
                    plan.Milestones.Add(new TestPlanMilestone
                    {
                        TestPlanId = plan.Id,
                        Name = mDto.Name,
                        Description = mDto.Description,
                        DueDate = mDto.DueDate.Kind == DateTimeKind.Unspecified ? DateTime.SpecifyKind(mDto.DueDate, DateTimeKind.Utc) : mDto.DueDate.ToUniversalTime(),
                        IsCompleted = mDto.IsCompleted
                    });
                }
            }
        }
    }

    private static void UpdateRisks(TestPlan plan, List<TestPlanRiskDto>? risksDto)
    {
        if (risksDto != null)
        {
            var incomingIds = risksDto.Where(r => r != null && r.Id.HasValue && r.Id.Value != Guid.Empty).Select(r => (Guid)r.Id!).ToList();
            var toRemove = plan.Risks.Where(r => !incomingIds.Contains(r.Id)).ToList();
            foreach (var item in toRemove) plan.Risks.Remove(item);

            foreach (var rDto in risksDto)
            {
                if (rDto.Id.HasValue && rDto.Id.Value != Guid.Empty)
                {
                    var existing = plan.Risks.FirstOrDefault(r => r.Id == rDto.Id.Value);
                    if (existing != null)
                    {
                        existing.Description = rDto.Description;
                        existing.Probability = rDto.Probability;
                        existing.Impact = rDto.Impact;
                        existing.Mitigation = rDto.Mitigation;
                    }
                }
                else
                {
                    plan.Risks.Add(new TestPlanRisk
                    {
                        TestPlanId = plan.Id,
                        Description = rDto.Description,
                        Probability = rDto.Probability,
                        Impact = rDto.Impact,
                        Mitigation = rDto.Mitigation
                    });
                }
            }
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        var plan = await _testPlanRepository.GetByIdAsync(id) 
            ?? throw new EntityNotFoundException(nameof(TestPlan), id);

        _testPlanRepository.Delete(plan);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task ApproveAsync(Guid id, ApproveTestPlanDto dto)
    {
        var plan = await _testPlanRepository.GetByIdWithDetailsAsync(id) 
            ?? throw new EntityNotFoundException(nameof(TestPlan), id);

        if (plan.IsClosed)
            throw new InvalidOperationException("Test plan is already closed and approved.");

        var userId = _currentUserService.UserId ?? throw new UnauthorizedAccessException("User is not authenticated.");

        // Simple hash calculation for signature
        string rawData = $"{plan.Id}-{userId}-{DateTime.UtcNow:O}-{dto.Verdict}";
        
        byte[] hashBytes = SHA256.HashData(Encoding.UTF8.GetBytes(rawData));
        string hashString = Convert.ToBase64String(hashBytes);

        var log = new TestPlanApprovalLog
        {
            Id = Guid.NewGuid(),
            TestPlanId = id,
            UserId = userId,
            Verdict = dto.Verdict,
            Comments = dto.Comments,
            SignatureHash = hashString,
            CreatedAt = DateTime.UtcNow
        };

        plan.IsClosed = true;
        plan.StatusId = 4; // Cerrado
        plan.ApprovalLogs ??= [];
        plan.ApprovalLogs.Add(log);

        _testPlanRepository.Update(plan);
        
        await _unitOfWork.SaveChangesAsync();
    }
}
