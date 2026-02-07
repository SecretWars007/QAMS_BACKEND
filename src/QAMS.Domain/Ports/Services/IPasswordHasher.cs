// src/QAMS.Domain/Ports/Services/IPasswordHasher.cs
namespace QAMS.Domain.Ports.Services
{
    /// <summary>Contrato para hashing de contraseñas. DIP aplicado.</summary>
    public interface IPasswordHasher
    {
        string HashPassword(string password);
        bool VerifyPassword(string password, string passwordHash);
    }
}
