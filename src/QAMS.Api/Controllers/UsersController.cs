// src/QAMS.Api/Controllers/UsersController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QAMS.Api.Filters;
using QAMS.Application.DTOs.Users;
using QAMS.Application.Interfaces;

namespace QAMS.Api.Controllers
{
    /// <summary>
    /// CONTROLADOR DE USUARIOS: Maneja solicitudes HTTP REST para operaciones de usuario.
    /// 
    /// RESPONSABILIDADES:
    /// 1. Mapear rutas HTTP a métodos de acción
    /// 2. Validar autorización mediante [Authorize] y [HasPermission]
    /// 3. Desserializar JSON de request a DTOs
    /// 4. Llamar al servicio de aplicación con los datos validados
    /// 5. Serializar respuestas de negocio a JSON
    /// 6. Retornar códigos HTTP apropiados (200, 201, 204, 404, etc.)
    /// 7. Propagar excepciones al middleware de manejo de errores
    /// 
    /// PATRÓN MVC (Model-View-Controller):
    /// - Controller: punto de entrada de solicitudes HTTP
    /// - DTO: modelo que viaja en el JSON
    /// - Service: lógica de negocio
    /// - Repository: acceso a datos
    /// 
    /// AUTORIZACIÓN:
    /// - [Authorize]: requiere autenticación (JWT bearer token)
    /// - [HasPermission]: verifica permisos específicos basados en roles
    /// 
    /// MAPEO DE RUTAS:
    /// - Route: "api/[controller]" → /api/users
    /// - Métodos HTTP: GET, POST, PUT, DELETE
    /// - Parámetros: ruta ({id}, {roleId}) y body
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        // ================================================================
        // DEPENDENCIAS INYECTADAS
        // ================================================================

        /// <summary>
        /// Servicio de usuarios: coordina lógica de negocio.
        /// Inyectado por el contenedor DI al crear el controlador.
        /// </summary>
        private readonly IUserService _userService;

        // ================================================================
        // CONSTRUCTOR: Inyecta dependencias
        // ================================================================

        /// <summary>
        /// Inicializa el controlador con el servicio de usuarios.
        /// 
        /// PARÁMETRO:
        /// - userService: inyectado por el contenedor DI
        /// 
        /// NOTA:
        /// - El constructor es invocado por ASP.NET Core para cada request
        /// - Las dependencias vienen del contenedor configurado en Program.cs
        /// </summary>
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // ================================================================
        // OPERACIONES CRUD DE LECTURA (GET)
        // ================================================================

        /// <summary>
        /// OBTIENE TODOS LOS USUARIOS DEL SISTEMA.
        /// 
        /// ESPECIFICACIÓN HTTP:
        /// - Método: GET
        /// - Ruta: /api/users
        /// - Autenticación: Requerida [Authorize]
        /// - Autorización: USERS_VIEW
        /// - Body: ninguno
        /// - Response: 200 OK con lista de usuarios
        /// 
        /// FLUJO:
        /// 1. Validar autenticación (bearer token válido)
        /// 2. Validar autorización (usuario tiene permiso USERS_VIEW)
        /// 3. Llamar _userService.GetAllAsync()
        /// 4. Serializar resultado a JSON
        /// 5. Retornar 200 OK con lista
        /// 
        /// CASOS DE USO:
        /// - Listar usuarios en UI (tabla de usuarios)
        /// - Buscar usuario por nombre (búsqueda cliente-side)
        /// - Cargar usuarios para dropdowns
        /// 
        /// RESPUESTA EXITOSA (200 OK):
        /// [
        ///   {
        ///     "id": "guid",
        ///     "username": "johndoe",
        ///     "email": "john@example.com",
        ///     "fullName": "John Doe",
        ///     "isActive": true,
        ///     "roles": [ { "id": "guid", "name": "Admin" } ]
        ///   }
        /// ]
        /// 
        /// EXCEPCIONES PROPAGADAS:
        /// - 401 Unauthorized: token no válido o expirado
        /// - 403 Forbidden: usuario no tiene permiso USERS_VIEW
        /// </summary>
        [HttpGet]
        [HasPermission("USERS_VIEW")]
        public async Task<IActionResult> GetAll() => Ok(await _userService.GetAllAsync());

        /// <summary>
        /// OBTIENE UN USUARIO ESPECÍFICO POR SU ID.
        /// 
        /// ESPECIFICACIÓN HTTP:
        /// - Método: GET
        /// - Ruta: /api/users/{id}
        /// - Parámetro: id (GUID)
        /// - Autenticación: Requerida
        /// - Autorización: USERS_VIEW
        /// - Response: 200 OK si existe, 404 Not Found si no existe
        /// 
        /// FLUJO:
        /// 1. Validar autenticación y autorización
        /// 2. Parsear parámetro id como Guid
        /// 3. Llamar _userService.GetByIdAsync(id)
        /// 4. Si no existe, servicio lanza EntityNotFoundException
        /// 5. Middleware captura la excepción y retorna 404
        /// 6. Si existe, retornar 200 OK con datos
        /// 
        /// CASOS DE USO:
        /// - Obtener perfil de usuario
        /// - Cargar datos en formulario de edición
        /// - Verificar datos de usuario antes de operación
        /// 
        /// PARÁMETRO:
        /// - id: identificador único del usuario (GUID)
        ///   Ej: /api/users/550e8400-e29b-41d4-a716-446655440000
        /// 
        /// RESPUESTA EXITOSA (200 OK):
        /// {
        ///   "id": "550e8400-e29b-41d4-a716-446655440000",
        ///   "username": "johndoe",
        ///   "email": "john@example.com",
        ///   "fullName": "John Doe",
        ///   "isActive": true,
        ///   "roles": [ ... ]
        /// }
        /// 
        /// RESPUESTA ERROR (404 Not Found):
        /// {
        ///   "error": "User with id 550e8400-e29b-41d4-a716-446655440000 not found"
        /// }
        /// </summary>
        [HttpGet("{id:guid}")]
        [HasPermission("USERS_VIEW")]
        public async Task<IActionResult> GetById(Guid id) => Ok(await _userService.GetByIdAsync(id));

        // ================================================================
        // OPERACIONES CRUD DE CREACIÓN (POST)
        // ================================================================

        /// <summary>
        /// CREA UN NUEVO USUARIO EN EL SISTEMA.
        /// 
        /// ESPECIFICACIÓN HTTP:
        /// - Método: POST
        /// - Ruta: /api/users
        /// - Content-Type: application/json
        /// - Autenticación: Requerida
        /// - Autorización: USERS_CREATE
        /// - Response: 201 Created con usuario creado
        /// 
        /// FLUJO:
        /// 1. Validar autenticación y autorización
        /// 2. Desserializar body JSON a CreateUserDto
        /// 3. Validar modelo (ModelState)
        /// 4. Llamar _userService.CreateAsync(dto)
        /// 5. Si todo OK, servicio retorna UserDto
        /// 6. Retornar 201 Created con Location header
        /// 
        /// PARÁMETRO:
        /// - dto: objeto con datos del nuevo usuario
        ///   {
        ///     "username": "johndoe",
        ///     "email": "john@example.com",
        ///     "password": "SecurePassword123!",
        ///     "fullName": "John Doe",
        ///     "roleIds": ["role-guid-1", "role-guid-2"]
        ///   }
        /// 
        /// VALIDACIONES DE NEGOCIO:
        /// - Username debe ser único
        /// - Email debe ser único
        /// - Password debe cumplir requisitos mínimos
        /// - Cada roleId debe existir en el sistema
        /// 
        /// RESPUESTA EXITOSA (201 Created):
        /// Location: /api/users/{newUserId}
        /// {
        ///   "id": "nuevo-guid",
        ///   "username": "johndoe",
        ///   "email": "john@example.com",
        ///   "roles": [...]
        /// }
        /// 
        /// EXCEPCIONES PROPAGADAS:
        /// - 400 Bad Request: datos inválidos o incompletos
        /// - 409 Conflict: username o email ya existen
        /// - 404 Not Found: algún roleId no existe
        /// 
        /// NOTA:
        /// - CreatedAtAction genera Location header para el recurso creado
        /// - Sigue estándar REST: POST retorna 201 + recurso + location
        /// </summary>
        [HttpPost]
        [HasPermission("USERS_CREATE")]
        public async Task<IActionResult> Create([FromBody] CreateUserDto dto)
        {
            // Llamar al servicio para crear el usuario
            // Si falla, la excepción es propagada al middleware
            var created = await _userService.CreateAsync(dto);
            
            // Retornar 201 Created con:
            // - Código 201 (Created)
            // - Header Location con URL del recurso creado
            // - Body con el usuario creado
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // ================================================================
        // OPERACIONES CRUD DE ACTUALIZACIÓN (PUT)
        // ================================================================

        /// <summary>
        /// ACTUALIZA UN USUARIO EXISTENTE.
        /// 
        /// ESPECIFICACIÓN HTTP:
        /// - Método: PUT
        /// - Ruta: /api/users/{id}
        /// - Content-Type: application/json
        /// - Autenticación: Requerida
        /// - Autorización: USERS_UPDATE
        /// - Response: 200 OK con usuario actualizado
        /// 
        /// FLUJO:
        /// 1. Validar autenticación y autorización
        /// 2. Parsear id como Guid
        /// 3. Desserializar body JSON a UpdateUserDto
        /// 4. Llamar _userService.UpdateAsync(id, dto)
        /// 5. Servicio valida que usuario existe
        /// 6. Servicio actualiza campos y roles
        /// 7. Retornar 200 OK con usuario actualizado
        /// 
        /// PARÁMETRO:
        /// - id: identificador del usuario a actualizar
        /// - dto: objeto con nuevos valores
        ///   {
        ///     "email": "newemail@example.com",
        ///     "fullName": "John Updated",
        ///     "isActive": true,
        ///     "roleIds": ["role-guid-1"]
        ///   }
        /// 
        /// COMPORTAMIENTO ESPECIAL:
        /// - Reemplaza COMPLETAMENTE el conjunto de roles
        /// - Si roleIds está vacío, usuario queda sin roles
        /// - NO permite cambiar username (identificador)
        /// - NO permite cambiar password (usar endpoint separado)
        /// 
        /// RESPUESTA EXITOSA (200 OK):
        /// {
        ///   "id": "usuario-guid",
        ///   "username": "johndoe",
        ///   "email": "newemail@example.com",
        ///   "fullName": "John Updated",
        ///   "isActive": true,
        ///   "roles": [...]
        /// }
        /// 
        /// EXCEPCIONES PROPAGADAS:
        /// - 400 Bad Request: datos inválidos
        /// - 404 Not Found: usuario no existe
        /// - 404 Not Found: algún roleId no existe
        /// </summary>
        [HttpPut("{id:guid}")]
        [HasPermission("USERS_UPDATE")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUserDto dto)
            => Ok(await _userService.UpdateAsync(id, dto));

        // ================================================================
        // OPERACIONES CRUD DE ELIMINACIÓN (DELETE)
        // ================================================================

        /// <summary>
        /// ELIMINA (desactiva) UN USUARIO DEL SISTEMA.
        /// 
        /// ESPECIFICACIÓN HTTP:
        /// - Método: DELETE
        /// - Ruta: /api/users/{id}
        /// - Autenticación: Requerida
        /// - Autorización: USERS_DELETE
        /// - Response: 204 No Content (sin body)
        /// 
        /// FLUJO:
        /// 1. Validar autenticación y autorización
        /// 2. Parsear id como Guid
        /// 3. Llamar _userService.DeleteAsync(id)
        /// 4. Servicio implementa SOFT DELETE (marca como inactivo)
        /// 5. Retornar 204 No Content (sin body)
        /// 
        /// PARÁMETRO:
        /// - id: identificador del usuario a eliminar
        /// 
        /// TIPO DE ELIMINACIÓN: SOFT DELETE
        /// - No elimina registro de BD (solo marca IsActive = false)
        /// - Preserva integridad referencial (FK a otros datos)
        /// - Mantiene auditoría (qué usuario creó qué dato)
        /// - Permite recuperación (reactivar usuario)
        /// 
        /// RESPUESTA EXITOSA (204 No Content):
        /// - Sin body
        /// - Sin Location header
        /// - Solo confirma que se completó
        /// 
        /// EXCEPCIONES PROPAGADAS:
        /// - 404 Not Found: usuario no existe
        /// 
        /// NOTA:
        /// - 204 No Content es el código correcto para DELETE exitoso
        /// - El cliente NO debe esperar body en la respuesta
        /// </summary>
        [HttpDelete("{id:guid}")]
        [HasPermission("USERS_DELETE")]
        public async Task<IActionResult> Delete(Guid id)
        {
            // Llamar al servicio para eliminar
            await _userService.DeleteAsync(id);
            
            // Retornar 204 No Content (sin body, sin contenido)
            return NoContent();
        }

        // ================================================================
        // OPERACIONES DE GESTIÓN DE ROLES
        // ================================================================

        /// <summary>
        /// ASIGNA UN ROL A UN USUARIO.
        /// 
        /// ESPECIFICACIÓN HTTP:
        /// - Método: POST
        /// - Ruta: /api/users/{id}/roles/{roleId}
        /// - Autenticación: Requerida
        /// - Autorización: USERS_ASSIGN_ROLES
        /// - Response: 204 No Content
        /// 
        /// FLUJO:
        /// 1. Validar autenticación y autorización
        /// 2. Parsear parámetros de ruta (id, roleId)
        /// 3. Llamar _userService.AssignRoleAsync(id, roleId)
        /// 4. Servicio valida que usuario y rol existen
        /// 5. Servicio asigna rol (idempotente)
        /// 6. Retornar 204 No Content
        /// 
        /// PARÁMETROS:
        /// - id: identificador del usuario
        /// - roleId: identificador del rol a asignar
        /// 
        /// EJEMPLO:
        /// POST /api/users/550e8400-e29b-41d4-a716-446655440000/roles/550e8400-e29b-41d4-a716-446655440001
        /// 
        /// COMPORTAMIENTO ESPECIAL:
        /// - IDEMPOTENTE: asignar el mismo rol múltiples veces = una sola asignación
        /// - No causa error si ya está asignado
        /// - Retorna éxito de todas formas (204 No Content)
        /// 
        /// RESPUESTA EXITOSA (204 No Content):
        /// - Sin body
        /// - Confirma que se completó
        /// 
        /// EXCEPCIONES PROPAGADAS:
        /// - 404 Not Found: usuario no existe
        /// - 404 Not Found: rol no existe
        /// 
        /// CASOS DE USO:
        /// - Asignar rol a usuario existente
        /// - Cambiar nivel de acceso de usuario
        /// - Promover usuario a rol superior
        /// </summary>
        [HttpPost("{id:guid}/roles/{roleId:guid}")]
        [HasPermission("USERS_ASSIGN_ROLES")]
        public async Task<IActionResult> AssignRole(Guid id, Guid roleId)
        {
            // Llamar al servicio para asignar el rol
            await _userService.AssignRoleAsync(id, roleId);
            
            // Retornar 204 No Content (operación exitosa sin respuesta)
            return NoContent();
        }

        /// <summary>
        /// REMUEVE UN ROL ESPECÍFICO DE UN USUARIO.
        /// 
        /// ESPECIFICACIÓN HTTP:
        /// - Método: DELETE
        /// - Ruta: /api/users/{id}/roles/{roleId}
        /// - Autenticación: Requerida
        /// - Autorización: USERS_ASSIGN_ROLES
        /// - Response: 204 No Content
        /// 
        /// FLUJO:
        /// 1. Validar autenticación y autorización
        /// 2. Parsear parámetros (id, roleId)
        /// 3. Llamar _userService.RemoveRoleAsync(id, roleId)
        /// 4. Servicio valida que usuario y rol existen
        /// 5. Servicio remueve la asignación (idempotente)
        /// 6. Retornar 204 No Content
        /// 
        /// PARÁMETROS:
        /// - id: identificador del usuario
        /// - roleId: identificador del rol a remover
        /// 
        /// EJEMPLO:
        /// DELETE /api/users/550e8400-e29b-41d4-a716-446655440000/roles/550e8400-e29b-41d4-a716-446655440001
        /// 
        /// COMPORTAMIENTO ESPECIAL:
        /// - IDEMPOTENTE: remover rol no asignado completa sin error
        /// - No causa error si ya no tiene el rol
        /// - Retorna 204 de todas formas
        /// 
        /// RESPUESTA EXITOSA (204 No Content):
        /// - Sin body
        /// - Confirma que se completó
        /// 
        /// EXCEPCIONES PROPAGADAS:
        /// - 404 Not Found: usuario no existe
        /// - 404 Not Found: rol no existe
        /// 
        /// DIFERENCIA CON RemoveAllRoles:
        /// - Este remueve UN rol específico
        /// - RemoveAllRoles remueve TODOS los roles
        /// 
        /// CASOS DE USO:
        /// - Quitar un permiso específico
        /// - Degradar usuario de un rol
        /// - Remover acceso a funcionalidad específica
        /// </summary>
        [HttpDelete("{id:guid}/roles/{roleId:guid}")]
        [HasPermission("USERS_ASSIGN_ROLES")]
        public async Task<IActionResult> RemoveRole(Guid id, Guid roleId)
        {
            // Llamar al servicio para remover el rol
            await _userService.RemoveRoleAsync(id, roleId);
            
            // Retornar 204 No Content
            return NoContent();
        }

        /// <summary>
        /// REMUEVE TODOS LOS ROLES DE UN USUARIO.
        /// 
        /// ESPECIFICACIÓN HTTP:
        /// - Método: DELETE
        /// - Ruta: /api/users/{id}/roles
        /// - Autenticación: Requerida
        /// - Autorización: USERS_ASSIGN_ROLES
        /// - Response: 204 No Content
        /// 
        /// FLUJO:
        /// 1. Validar autenticación y autorización
        /// 2. Parsear id como Guid
        /// 3. Llamar _userService.RemoveAllRolesAsync(id)
        /// 4. Servicio valida que usuario existe
        /// 5. Servicio remueve TODOS los roles
        /// 6. Retornar 204 No Content
        /// 
        /// PARÁMETRO:
        /// - id: identificador del usuario
        /// 
        /// EJEMPLO:
        /// DELETE /api/users/550e8400-e29b-41d4-a716-446655440000/roles
        /// 
        /// COMPORTAMIENTO IMPORTANTE:
        /// - Remueve TODOS los roles de una vez
        /// - Usuario queda sin permisos (excepto acceso anónimo)
        /// - Más eficiente que llamar RemoveRole N veces
        /// - IDEMPOTENTE: si ya sin roles, completa sin error
        /// 
        /// RESPUESTA EXITOSA (204 No Content):
        /// - Sin body
        /// - Confirma que todos los roles fueron removidos
        /// 
        /// EXCEPCIONES PROPAGADAS:
        /// - 404 Not Found: usuario no existe
        /// 
        /// DIFERENCIA CON RemoveRole:
        /// - Este remueve TODOS los roles en una operación
        /// - RemoveRole remueve UN rol específico
        /// 
        /// CASOS DE USO:
        /// - Suspender usuario (quitar todos los permisos)
        /// - Despido: remover acceso inmediato a todo
        /// - Reset de permisos: desactivar y reactivar
        /// - Cambio de equipo: quitar roles antiguos antes de asignar nuevos
        /// </summary>
        [HttpDelete("{id:guid}/roles")]
        [HasPermission("USERS_ASSIGN_ROLES")]
        public async Task<IActionResult> RemoveAllRoles(Guid id)
        {
            // Llamar al servicio para remover todos los roles
            await _userService.RemoveAllRolesAsync(id);
            
            // Retornar 204 No Content
            return NoContent();
        }
    }
}
