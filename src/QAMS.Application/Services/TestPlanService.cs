using AutoMapper;
using QAMS.Application.DTOs.TestPlans;
using QAMS.Domain.Exceptions;
using QAMS.Domain.Ports.Repositories;
using QAMS.Application.Interfaces;
using QAMS.Application.Interfaces.Repositories;
using QAMS.Domain.Entities;

namespace QAMS.Application.Services
{
    public class TestPlanService : ITestPlanService
    {
        private readonly ITestPlanRepository _testPlanRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly ITestSuiteRepository _testSuiteRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TestPlanService(
            ITestPlanRepository testPlanRepository,
            IProjectRepository projectRepository,
            ITestSuiteRepository testSuiteRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _testPlanRepository = testPlanRepository;
            _projectRepository = projectRepository;
            _testSuiteRepository = testSuiteRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

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

        public async Task<TestPlanDto> GetByIdAsync(Guid id)
        {
            var plan = await _testPlanRepository.GetByIdWithDetailsAsync(id);
            if (plan == null)
                throw new EntityNotFoundException(nameof(TestPlan), id);

            return _mapper.Map<TestPlanDto>(plan);
        }

        public async Task<TestPlanDto> CreateAsync(CreateTestPlanDto dto)
        {
            var project = await _projectRepository.GetByIdAsync(dto.ProjectId);
            if (project == null)
                throw new EntityNotFoundException(nameof(Project), dto.ProjectId);

            var plan = _mapper.Map<TestPlan>(dto);
            plan.StatusId = 1; // Draft / Borrador

            if (dto.TestSuiteIds != null && dto.TestSuiteIds.Any())
            {
                foreach (var suiteId in dto.TestSuiteIds)
                {
                    var suite = await _testSuiteRepository.GetByIdAsync(suiteId);
                    if (suite != null && suite.ProjectId == dto.ProjectId)
                    {
                        plan.TestPlanSuites.Add(new TestPlanSuite
                        {
                            TestSuiteId = suiteId
                        });
                    }
                }
            }

            if (dto.Criteria != null && dto.Criteria.Any())
            {
                foreach (var criteriaDto in dto.Criteria)
                {
                    plan.Criteria.Add(new TestPlanCriteria
                    {
                        CriteriaType = criteriaDto.CriteriaType,
                        Description = criteriaDto.Description,
                        IsMet = false // Siempre inicia sin cumplir
                    });
                }
            }

            await _testPlanRepository.AddAsync(plan);
            await _unitOfWork.SaveChangesAsync();

            var createdPlan = await _testPlanRepository.GetByIdWithDetailsAsync(plan.Id);
            return _mapper.Map<TestPlanDto>(createdPlan);
        }

        public async Task<TestPlanDto> UpdateAsync(Guid id, UpdateTestPlanDto dto)
        {
            var plan = await _testPlanRepository.GetByIdWithDetailsAsync(id);
            if (plan == null)
                throw new EntityNotFoundException(nameof(TestPlan), id);

            // Validación ISTQB: Para pasar a CLOSED, todos los EXIT criteria deben cumplirse
            if (dto.StatusId == 4 && plan.StatusId != 4) // 4 = Closed
            {
                var exitCriteria = plan.Criteria.Where(c => c.CriteriaType == "EXIT");
                if (exitCriteria.Any(c => !c.IsMet))
                {
                    throw new InvalidOperationException("No se puede cerrar el plan de pruebas porque no se han cumplido todos los Criterios de Salida (Exit Criteria).");
                }
            }

            plan.Name = dto.Name;
            plan.Objectives = dto.Objectives;
            plan.Scope = dto.Scope;
            plan.OutOfScope = dto.OutOfScope;
            plan.TestStrategy = dto.TestStrategy;
            plan.RiskAnalysis = dto.RiskAnalysis;
            plan.EnvironmentRequirements = dto.EnvironmentRequirements;
            plan.TestSchedule = dto.TestSchedule;
            plan.EstimatedEffortHours = dto.EstimatedEffortHours;

            plan.StartDate = dto.StartDate;
            plan.EndDate = dto.EndDate;
            plan.StatusId = dto.StatusId;

            plan.TestPlanSuites.Clear();

            if (dto.TestSuiteIds != null && dto.TestSuiteIds.Any())
            {
                foreach (var suiteId in dto.TestSuiteIds)
                {
                    var suite = await _testSuiteRepository.GetByIdAsync(suiteId);
                    if (suite != null && suite.ProjectId == plan.ProjectId)
                    {
                        plan.TestPlanSuites.Add(new TestPlanSuite
                        {
                            TestPlanId = id,
                            TestSuiteId = suiteId
                        });
                    }
                }
            }

            // Reemplazar criterios de forma sencilla para esta iteración
            if (dto.Criteria != null)
            {
                plan.Criteria.Clear();
                foreach (var criteriaDto in dto.Criteria)
                {
                    plan.Criteria.Add(new TestPlanCriteria
                    {
                        TestPlanId = id,
                        CriteriaType = criteriaDto.CriteriaType,
                        Description = criteriaDto.Description,
                        IsMet = criteriaDto.IsMet
                    });
                }
            }

            _testPlanRepository.Update(plan);
            await _unitOfWork.SaveChangesAsync();

            var updatedPlan = await _testPlanRepository.GetByIdWithDetailsAsync(plan.Id);
            return _mapper.Map<TestPlanDto>(updatedPlan);
        }

        public async Task DeleteAsync(Guid id)
        {
            var plan = await _testPlanRepository.GetByIdAsync(id);
            if (plan == null)
                throw new EntityNotFoundException(nameof(TestPlan), id);

            _testPlanRepository.Delete(plan);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
