# Reglas de Oro

1. **Idioma**: El agente debe responder SIEMPRE y TODO en español.
2. **Actualizaciones de Estado**: El agente debe informar del estado de sus tareas cada 600 segundos (usando recordatorios si es necesario o manteniendo actualizaciones frecuentes).
3. **Tests Reales**: Los tests no deben usar mocks (Moq, etc.). Deben ser tests reales de integración que prueben contra una base de datos real o un entorno real (por ejemplo, usando Testcontainers).
# QAMS - Project Guidelines & Agent Persona

Welcome! This document defines the architectural standards, coding practices, and core principles for the **QAMS (Quality Assurance Management System)** project. It serves as a source of truth for both human developers and the Antigravity AI agent.

## 1. Project Overview & Mission
**QAMS** is a premium management system for Quality Assurance teams. It enables managing projects, test cases, test executions, and tracking progress via Kanban boards and automated reports.

- **Backend**: .NET 9 Web API
- **Primary Database**: PostgreSQL
- **Infrastructure**: Docker & Docker Compose


---

## 2. Architectural Blueprint: Clean Architecture
This project follows **Clean Architecture** to ensure separation of concerns, testability, and independence from external frameworks.

### 🏗️ 2.1 Domain Layer (`QAMS.Domain`)
- **Entities**: Business objects with data and behavior.
- **Exceptions**: Specific domain exceptions (e.g., `DomainException`).
- **Ports (Interfaces)**: Outgoing interfaces (e.g., `IRepository`, `IServices`).
- **Constraints**: No dependencies on any other layer or external libraries (except basic ones).

### ⚙️ 2.2 Application Layer (`QAMS.Application`)
- **Use Cases**: Services implementing business logic.
- **DTOs**: Data Transfer Objects for communication with the outside world.
- **Mappings**: AutoMapper profiles to convert between Entities and DTOs.
- **Interfaces**: Incoming and outgoing interfaces used by the core logic.
- **Validation**: FluentValidation or DataAnnotations for request validation.

### 🔌 2.3 Infrastructure Layer (`QAMS.Infrastructure`)
- **Persistence**: EF Core DbContext, Migrations, and Repository implementations.
- **Security**: JWT generation, Password hashing, RBAC implementation.
- **External Services**: Logging, Email, PDF generation, etc.
- **Dependencies**: Depends on Domain and Application.

### 🚀 2.4 API Layer (`QAMS.Api`)
- **Controllers**: Thin controllers handling HTTP requests and calling application services.
- **Middleware**: Error handling, Authentication, Logging.
- **Configuration**: Service registration (`Program.cs`) and `appsettings.json`.

---

## 3. Coding Standards & Best Practices

### 💎 3.1 General Principles
- **SOLID**: Follow all five principles religiously.
- **DRY (Don't Repeat Yourself)**: Abstract common logic into services or helpers.
- **YAGNI (You Ain't Gonna Need It)**: Don't implement features/complexity that aren't requested.
- **KISS (Keep It Simple, Stupid)**: Favor readability over "clever" code.

### 📝 3.2 Naming Conventions
- **Classes/Methods**: `PascalCase`.
- **Private Fields**: `_camelCase` with an underscore prefix.
- **Interfaces**: Prefix with `I` (e.g., `IUserService`).
- **Variables**: `camelCase`.
- **Files**: Match class names.

### 🛡️ 3.3 Error Handling
- Use global exception handling middleware in the API layer.
- Throw specific domain or application exceptions instead of general ones.
- Never return sensitive stack traces in production (via `ASPNETCORE_ENVIRONMENT`).

### 🧪 3.4 Security First
- **Password Hashing**: Use `IPasswordHasher` (BCrypt/Argon2).
- **Authentication**: JWT Bearer tokens with Refresh Tokens.
- **Authorization**: Granular RBAC (Roles & Permissions).
- **Validation**: Validate all inputs at the API gateway level.

---

## 4. Agent Operational Guidelines
When working as the AI agent (Antigravity), you must follow this workflow:

1.  **Research**: Use `list_dir`, `view_file`, and `grep_search` to understand existing code before changing anything.
2.  **Check Knowledge Items (KIs)**: Always check `<appDataDir>/knowledge` for existing context.
3.  **Plan**: Create/Update `implementation_plan.md` for non-trivial tasks.
4.  **Execute**: Implement changes incrementally. Use `replace_file_content` for surgical edits and `write_to_file` for new components.
5.  **Verify**: Always run `dotnet build` and check logs to ensure the system is stable. If Docker is available, test there.
6.  **Document**: Update `walkthrough.md` to show what was accomplished.
7.  **Sync**: Proactively use `git add`, `git commit`, and `git push` to keep the remote repository updated with the changes made in each task. Always use descriptive commit messages (prefix with `feat:`, `fix:`, `chore:`, etc.).
8.  **Auto-Publish (MANDATORY)**: Always run the `/publish-docker` workflow immediately after any code modification or when a user request is completed. This is not optional; any change to the backend must be live in the Docker environment.



## 6. Architecture Vision
The backend is the core of the system:
- Maintain high performance and clean API responses.
- Ensure all business logic remains in the Application layer.
- Keep the API layer thin and focused on HTTP concerns.

---

## 6. Key Commands
- **Migration**: `dotnet ef migrations add Name --project src/QAMS.Infrastructure --startup-project src/QAMS.Api`
- **Database Update**: `dotnet ef database update --project src/QAMS.Infrastructure --startup-project src/QAMS.Api`
- **Docker**: `docker-compose up --build -d`
- **Build**: `dotnet build`

---

*This document is dynamic. Update it as the architecture evolves.*

