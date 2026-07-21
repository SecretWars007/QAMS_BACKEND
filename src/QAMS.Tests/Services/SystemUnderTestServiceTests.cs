#nullable enable
using System;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using QAMS.Application.DTOs.SystemsUnderTest;
using QAMS.Application.Interfaces;
using QAMS.Domain.Entities;
using QAMS.Domain.Exceptions;
using QAMS.Tests.IntegrationTests.Infrastructure;
using Xunit;

namespace QAMS.Tests.Services;

[Collection("Integration tests")]
public class SystemUnderTestServiceTests(QamsIntegrationTestFactory factory) : IntegrationTestBase(factory)
{
    private static ISystemUnderTestService GetService(IServiceScope scope)
    {
        return scope.ServiceProvider.GetRequiredService<ISystemUnderTestService>();
    }

    private async Task<Guid> CreateTestProjectAsync()
    {
        var user = await CreateTestUserAsync($"sut_owner_{Guid.NewGuid():N}");
        var projectId = Guid.NewGuid();

        await ExecuteInScopeAsync(async db =>
        {
            db.Projects.Add(new Project
            {
                Id = projectId,
                Name = $"Project SUT {Guid.NewGuid():N}",
                IsActive = true,
                CreatedByUserId = user.Id,
                ProjectStatusId = 1,
                ProjectPriorityId = 1
            });
            await db.SaveChangesAsync();
        });

        return projectId;
    }

    [Fact(DisplayName = "CreateAsync_WebPlatform_DebeRegistrarUrlDeAccesoCorrectamente")]
    public async Task CreateAsync_WebPlatform_ShouldRegisterBaseUrl()
    {
        // Arrange
        var projectId = await CreateTestProjectAsync();
        using var scope = Factory.Services.CreateScope();
        var service = GetService(scope);

        var dto = new CreateSystemUnderTestDto
        {
            ProjectId = projectId,
            Name = "Portal Web Clientes",
            PlatformTypeId = 1, // WEB
            BaseUrl = "https://clientes.ejemplo.com"
        };

        // Act
        var result = await service.CreateAsync(dto);

        // Assert
        result.Should().NotBeNull();
        result.PlatformTypeId.Should().Be(1);
        result.PlatformTypeCode.Should().Be("WEB");
        result.BaseUrl.Should().Be("https://clientes.ejemplo.com");
        result.ExecutablePath.Should().BeNull();
        result.ProcessName.Should().BeNull();
    }

    [Fact(DisplayName = "CreateAsync_DesktopPlatform_DebeRegistrarRutaDelEjecutableCorrectamente")]
    public async Task CreateAsync_DesktopPlatform_ShouldRegisterExecutablePath()
    {
        // Arrange
        var projectId = await CreateTestProjectAsync();
        using var scope = Factory.Services.CreateScope();
        var service = GetService(scope);

        var dto = new CreateSystemUnderTestDto
        {
            ProjectId = projectId,
            Name = "Aplicación Desktop POS",
            PlatformTypeId = 2, // DESKTOP
            ExecutablePath = @"C:\Program Files\App\pos_client.exe"
        };

        // Act
        var result = await service.CreateAsync(dto);

        // Assert
        result.Should().NotBeNull();
        result.PlatformTypeId.Should().Be(2);
        result.PlatformTypeCode.Should().Be("DESKTOP");
        result.ExecutablePath.Should().Be(@"C:\Program Files\App\pos_client.exe");
        result.BaseUrl.Should().BeNull();
        result.ProcessName.Should().BeNull();
    }

    [Fact(DisplayName = "CreateAsync_DataProcessingPlatform_DebeRegistrarNombreDelProcesoCorrectamente")]
    public async Task CreateAsync_DataProcessingPlatform_ShouldRegisterProcessName()
    {
        // Arrange
        var projectId = await CreateTestProjectAsync();
        using var scope = Factory.Services.CreateScope();
        var service = GetService(scope);

        var dto = new CreateSystemUnderTestDto
        {
            ProjectId = projectId,
            Name = "Batch Procesamiento Novedades",
            PlatformTypeId = 3, // DATA_PROCESSING
            ProcessName = "Process_Payroll_Batch_Worker"
        };

        // Act
        var result = await service.CreateAsync(dto);

        // Assert
        result.Should().NotBeNull();
        result.PlatformTypeId.Should().Be(3);
        result.PlatformTypeCode.Should().Be("DATA_PROCESSING");
        result.ProcessName.Should().Be("Process_Payroll_Batch_Worker");
        result.BaseUrl.Should().BeNull();
        result.ExecutablePath.Should().BeNull();
    }

    [Fact(DisplayName = "CreateAsync_WebPlatformSinUrl_DebeLanzarDomainException")]
    public async Task CreateAsync_WebPlatformWithoutBaseUrl_ShouldThrowDomainException()
    {
        // Arrange
        var projectId = await CreateTestProjectAsync();
        using var scope = Factory.Services.CreateScope();
        var service = GetService(scope);

        var dto = new CreateSystemUnderTestDto
        {
            ProjectId = projectId,
            Name = "Portal Web Sin URL",
            PlatformTypeId = 1, // WEB
            BaseUrl = null
        };

        // Act & Assert
        await Assert.ThrowsAsync<DomainException>(() => service.CreateAsync(dto));
    }

    [Fact(DisplayName = "CreateAsync_DesktopPlatformSinRuta_DebeLanzarDomainException")]
    public async Task CreateAsync_DesktopPlatformWithoutExecutablePath_ShouldThrowDomainException()
    {
        // Arrange
        var projectId = await CreateTestProjectAsync();
        using var scope = Factory.Services.CreateScope();
        var service = GetService(scope);

        var dto = new CreateSystemUnderTestDto
        {
            ProjectId = projectId,
            Name = "Desktop App Sin Ruta",
            PlatformTypeId = 2, // DESKTOP
            ExecutablePath = " "
        };

        // Act & Assert
        await Assert.ThrowsAsync<DomainException>(() => service.CreateAsync(dto));
    }

    [Fact(DisplayName = "CreateAsync_DataProcessingSinNombreProceso_DebeLanzarDomainException")]
    public async Task CreateAsync_DataProcessingWithoutProcessName_ShouldThrowDomainException()
    {
        // Arrange
        var projectId = await CreateTestProjectAsync();
        using var scope = Factory.Services.CreateScope();
        var service = GetService(scope);

        var dto = new CreateSystemUnderTestDto
        {
            ProjectId = projectId,
            Name = "Proceso sin Nombre",
            PlatformTypeId = 3, // DATA_PROCESSING
            ProcessName = null
        };

        // Act & Assert
        await Assert.ThrowsAsync<DomainException>(() => service.CreateAsync(dto));
    }

    [Fact(DisplayName = "UpdateAsync_CambioDePlataforma_DebeActualizarDetallesYLimpiarOtrosCampos")]
    public async Task UpdateAsync_ChangePlatformType_ShouldUpdateDetailsAndClearOthers()
    {
        // Arrange
        var projectId = await CreateTestProjectAsync();
        using var scope = Factory.Services.CreateScope();
        var service = GetService(scope);

        var created = await service.CreateAsync(new CreateSystemUnderTestDto
        {
            ProjectId = projectId,
            Name = "Sistema Híbrido",
            PlatformTypeId = 1,
            BaseUrl = "https://original.com"
        });

        var updateDto = new UpdateSystemUnderTestDto
        {
            PlatformTypeId = 2, // Cambiar a DESKTOP
            ExecutablePath = @"D:\Apps\Client.exe"
        };

        // Act
        var updated = await service.UpdateAsync(created.Id, updateDto);

        // Assert
        updated.PlatformTypeId.Should().Be(2);
        updated.PlatformTypeCode.Should().Be("DESKTOP");
        updated.ExecutablePath.Should().Be(@"D:\Apps\Client.exe");
        updated.BaseUrl.Should().BeNull();
        updated.ProcessName.Should().BeNull();
    }
}
