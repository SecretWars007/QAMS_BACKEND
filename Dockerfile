# Dockerfile optimizado para producción con enfoque en seguridad (Hardening)

# Stage 1: Construcción (Build)
FROM mcr.microsoft.com/dotnet/sdk:9.0-alpine AS build
WORKDIR /src

# Instalar dependencias necesarias para herramientas específicas si fuera el caso
# RUN apk add --no-cache icu-libs
# ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

# Copiar archivos de proyecto y restaurar capas para maximizar caché de Docker
COPY ["QAMS.sln", "./"]
COPY ["src/QAMS.Api/QAMS.Api.csproj", "src/QAMS.Api/"]
COPY ["src/QAMS.Application/QAMS.Application.csproj", "src/QAMS.Application/"]
COPY ["src/QAMS.Infrastructure/QAMS.Infrastructure.csproj", "src/QAMS.Infrastructure/"]
COPY ["src/QAMS.Domain/QAMS.Domain.csproj", "src/QAMS.Domain/"]
COPY ["src/QAMS.Tests/QAMS.Tests.csproj", "src/QAMS.Tests/"]

RUN dotnet restore "QAMS.sln"

# Copiar código fuente y construir
COPY . .
WORKDIR "/src/src/QAMS.Api"
RUN dotnet publish "QAMS.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 2: Runtime (Producción)
FROM mcr.microsoft.com/dotnet/aspnet:9.0-alpine AS runtime
WORKDIR /app

# Crear directorio de uploads con permisos para el usuario app
RUN mkdir -p /app/uploads && chown -R app:app /app/uploads

# Ejecutar como usuario no privilegiado
USER app

# Copiar binarios desde el stage de build
COPY --from=build --chown=app:app /app/publish .

# Variables de entorno de seguridad y red
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_HTTP_PORTS=8080
ENV DOTNET_EnableDiagnostics=0

EXPOSE 8080

# Punto de entrada
ENTRYPOINT ["dotnet", "QAMS.Api.dll"]
