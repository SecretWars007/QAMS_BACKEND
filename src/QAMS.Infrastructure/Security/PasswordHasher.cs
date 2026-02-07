// src/QAMS.Infrastructure/Security/PasswordHasher.cs
using QAMS.Domain.Ports.Services;

namespace QAMS.Infrastructure.Security
{
    /// <summary>Implementación de hashing con BCrypt. DIP: implementa puerto.</summary>
    public class PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            // BCrypt genera salt automáticamente y lo incluye en el hash
            return BCrypt.Net.BCrypt.HashPassword(password, workFactor: 12);
        }

        public bool VerifyPassword(string password, string passwordHash)
        {
            // BCrypt extrae el salt del hash para verificar
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }
    }
}
