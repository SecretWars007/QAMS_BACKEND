using System;

namespace QAMS.Domain.Constants
{
    /// <summary>
    /// IDs e información estática de los roles principales del sistema.
    /// Ubicado en Domain para que todas las capas puedan referenciarlos.
    /// </summary>
    public static class SystemRoles
    {
        public static readonly Guid AdminRoleId = new("11111111-1111-1111-1111-111111111111");
        public static readonly Guid TesterRoleId = new("22222222-2222-2222-2222-222222222222");
        public static readonly Guid LeadRoleId = new("33333333-3333-3333-3333-333333333333");
        public static readonly Guid DeveloperRoleId = new("44444444-4444-4444-4444-444444444444");
    }
}
