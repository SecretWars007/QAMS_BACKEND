// src/QAMS.Domain/Ports/Services/IJwtTokenGenerator.cs
using QAMS.Domain.Entities;

namespace QAMS.Domain.Ports.Services
{
    /// <summary>Contrato para generación de JWT. DIP aplicado.</summary>
    public interface IJwtTokenGenerator
    {
        string GenerateAccessToken(User user, IEnumerable<string> permissions);
        string GenerateRefreshToken();
    }
}
