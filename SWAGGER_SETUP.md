# Configuración de Swagger en QAMS API

## Estado Actual
Swagger ha sido agregado al proyecto QAMS.Api. Sin embargo, hay un problema de compatibilidad entre Swashbuckle.AspNetCore y .NET 10 que impide su uso en este momento.

## Solución Temporal
La configuración de Swagger está comentada en [Program.cs](src/QAMS.Api/Program.cs) porque:
- Swashbuckle.AspNetCore versiones < 7.0 no incluyen `Microsoft.OpenApi.Models`
- Swashbuckle.AspNetCore versiones >= 7.0 tienen conflictos de compatibilidad con .NET 10
- Microsoft.AspNetCore.OpenApi en .NET 10 requiere configuración adicional

## Próximos Pasos Recomendados

### Opción 1: Actualizar a .NET 9 (Recomendado)
Cambiar el `TargetFramework` en `QAMS.Api.csproj` de `net10.0` a `net9.0` permitirá usar Swashbuckle sin problemas.

```xml
<TargetFramework>net9.0</TargetFramework>
```

### Opción 2: Esperar Actualizaciones
Esperar a que Swashbuckle.AspNetCore publique una versión completamente compatible con .NET 10.

### Opción 3: Usar NSwag
Utilizar [NSwag](https://github.com/RicoSuter/NSwag) en lugar de Swashbuckle, que tiene mejor soporte para versiones nuevas de .NET.

```bash
dotnet add src/QAMS.Api/QAMS.Api.csproj package NSwag.AspNetCore
```

## Paquetes Instalados
- `Microsoft.AspNetCore.OpenApi` (v10.0.1) - Incluido con .NET 10
- `Swashbuckle.AspNetCore` - Removido temporalmente debido a problemas de compatibilidad

## Próximos Pasos en Program.cs

Una vez que se resuelva la incompatibilidad, descomentar estas líneas en [Program.cs](src/QAMS.Api/Program.cs):

### 1. Agregar AddSwaggerGen en Program.cs (líneas ~75):
```csharp
builder.Services.AddSwaggerGen();
```

### 2. Habilitar Swagger UI en Program.cs (líneas ~95):
```csharp
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
```

## Acceso a Swagger
Una vez configurado, Swagger estará disponible en:
- **URL**: `http://localhost:5000/swagger/index.html`
- **OpenAPI JSON**: `http://localhost:5000/swagger/v1/swagger.json`

## Documentación de Endpoints
Los endpoints de la API se documentarán automáticamente en Swagger una vez que se resuelva la configuración.
