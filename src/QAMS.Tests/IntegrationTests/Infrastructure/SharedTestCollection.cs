using Xunit;

namespace QAMS.Tests.IntegrationTests.Infrastructure;

/// <summary>
/// Colección compartida que garantiza que TODOS los tests de integración
/// utilicen una ÚNICA instancia de QamsIntegrationTestFactory (un solo contenedor DB).
/// 
/// Esto elimina la condición de carrera de FK que ocurría cuando xUnit
/// inicializaba múltiples fábricas en paralelo contra diferentes contenedores.
/// 
/// Uso: decorar cada clase de test con [Collection(SharedTestCollection.Name)]
/// </summary>
[CollectionDefinition(SharedTestCollection.Name)]
public class SharedTestCollection : ICollectionFixture<QamsIntegrationTestFactory>
{
    public const string Name = "QAMS Integration Tests";
}
