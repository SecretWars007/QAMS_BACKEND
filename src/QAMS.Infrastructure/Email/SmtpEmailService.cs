// src/QAMS.Infrastructure/Email/SmtpEmailService.cs
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using QAMS.Domain.Ports.Services;

namespace QAMS.Infrastructure.Email
{
    /// <summary>
    /// Implementación de IEmailService usando System.Net.Mail.SmtpClient.
    /// Compatible con Gmail SMTP, Outlook, y cualquier servidor SMTP genérico.
    /// Para Gmail: usar smtp.gmail.com:587 con una "App Password" generada desde la cuenta de Google.
    /// </summary>
    public class SmtpEmailService(IOptions<SmtpSettings> settings, ILogger<SmtpEmailService> logger) : IEmailService
    {
        private readonly SmtpSettings _settings = settings.Value;
        private readonly ILogger<SmtpEmailService> _logger = logger;

        public async Task SendEmailAsync(string to, string subject, string htmlBody)
        {
            // Validar parámetros básicos
            if (string.IsNullOrWhiteSpace(to)) throw new ArgumentNullException(nameof(to));
            if (string.IsNullOrWhiteSpace(_settings.Username) || _settings.Username == "YOUR_SMTP_USERNAME")
            {
                _logger.LogWarning("SMTP NO ENVIADO: El usuario no está configurado o tiene el valor por defecto ('{Username}'). " +
                                   "Verifique SmtpSettings en appsettings o variables de entorno.", _settings.Username);
                return;
            }

            _logger.LogInformation("Iniciando envío de correo a '{To}' usando host '{Host}:{Port}'...", to, _settings.Host, _settings.Port);

            try
            {
                var from = new MailAddress(_settings.FromEmail, _settings.FromName);
                var toAddress = new MailAddress(to);

                using var message = new MailMessage(from, toAddress)
                {
                    Subject = subject,
                    Body = htmlBody,
                    IsBodyHtml = true
                };

                using var client = new SmtpClient(_settings.Host, _settings.Port)
                {
                    Credentials = new NetworkCredential(_settings.Username, _settings.Password),
                    EnableSsl = _settings.EnableSsl,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Timeout = 20000 // 20 segundos para dar margen en cloud environments
                };

                await client.SendMailAsync(message);
                _logger.LogInformation("Correo enviado exitosamente a '{To}'.", to);
            }
            catch (SmtpException smtpEx)
            {
                _logger.LogError(smtpEx, "Fallo SMTP (StatusCode: {StatusCode}) al enviar a '{To}'. " +
                                        "Host: {Host}, Port: {Port}, SSL: {SSL}, User: {User}",
                                        smtpEx.StatusCode, to, _settings.Host, _settings.Port, _settings.EnableSsl, _settings.Username);
                throw; // Re-lanzamos para que el llamador pueda manejarlo si lo desea (pero AuthService lo captura)
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inesperado de email al enviar a '{To}'. Detalle: {Message}", to, ex.Message);
                throw;
            }
        }
    }
}
