# QAMS - Project Guidelines & Agent Persona

Welcome! This document defines the architectural standards, coding practices, and core principles for the **QAMS (Quality Assurance Management System)** project. It serves as a source of truth for both human developers and the Antigravity AI agent.

## 1. Project Overview & Mission
**QAMS** is a premium management system for Quality Assurance teams. It enables managing projects, test cases, test executions, and tracking progress via Kanban boards and automated reports.

- **Backend**: .NET 9 Web API
- **Frontend**: Angular (Premium UI/UX)
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

## 5. UI/UX Vision (Fullstack)
The frontend should feel **premium and professional**:
- Use frosted glass effects (Glassmorphism), subtle gradients, and modern typography (Inter/Outfit).
- High response speed and micro-animations for interactivity.
- Consistent color palette: Deep dark modes or clean architectural whites.

---

## 6. Key Commands
- **Migration**: `dotnet ef migrations add Name --project src/QAMS.Infrastructure --startup-project src/QAMS.Api`
- **Database Update**: `dotnet ef database update --project src/QAMS.Infrastructure --startup-project src/QAMS.Api`
- **Docker**: `docker-compose up --build -d`
- **Build**: `dotnet build`

---

*This document is dynamic. Update it as the architecture evolves.*
