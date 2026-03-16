// src/QAMS.Domain/Ports/Services/IEmailService.cs
namespace QAMS.Domain.Ports.Services
{
    /// <summary>
    /// Puerto para el envío de correos electrónicos.
    /// La implementación concreta (SMTP, SendGrid, etc.) vive en Infrastructure.
    /// </summary>
    public interface IEmailService
    {
        /// <summary>Envía un correo electrónico con contenido HTML.</summary>
        Task SendEmailAsync(string to, string subject, string htmlBody);
    }
}
