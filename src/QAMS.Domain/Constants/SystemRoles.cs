// src/QAMS.Domain/Constants/SystemRoles.cs
using System;

namespace QAMS.Domain.Constants
{
    /// <summary>
    /// IDs e información estática de los roles principales del sistema.
    /// Ubicado en Domain para que todas las capas puedan referenciarlos.
    /// </summary>
    public static class SystemRoles
    {
        public static readonly Guid AdminRoleId = new Guid("11111111-1111-1111-1111-111111111111");
        public static readonly Guid TesterRoleId = new Guid("22222222-2222-2222-2222-222222222222");
    }
}
