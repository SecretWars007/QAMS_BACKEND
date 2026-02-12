# Multi-stage Dockerfile to build and run QAMS API
# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy solution and restore
COPY QAMS.sln ./
COPY src/QAMS.Api/QAMS.Api.csproj src/QAMS.Api/
COPY src/QAMS.Application/QAMS.Application.csproj src/QAMS.Application/
COPY src/QAMS.Infrastructure/QAMS.Infrastructure.csproj src/QAMS.Infrastructure/
COPY src/QAMS.Domain/QAMS.Domain.csproj src/QAMS.Domain/

RUN dotnet restore QAMS.sln

# Copy everything and build
COPY . .
RUN dotnet publish src/QAMS.Api/QAMS.Api.csproj -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish ./

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "QAMS.Api.dll"]
