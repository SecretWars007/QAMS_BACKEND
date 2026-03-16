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
    public class SmtpEmailService : IEmailService
    {
        private readonly SmtpSettings _settings;
        private readonly ILogger<SmtpEmailService> _logger;

        public SmtpEmailService(IOptions<SmtpSettings> settings, ILogger<SmtpEmailService> logger)
        {
            _settings = settings.Value;
            _logger = logger;
        }

        public async Task SendEmailAsync(string to, string subject, string htmlBody)
        {
            if (string.IsNullOrWhiteSpace(_settings.Username) || string.IsNullOrWhiteSpace(_settings.Password))
            {
                _logger.LogWarning(
                    "SMTP no configurado (Username/Password vacíos). Correo a '{To}' con asunto '{Subject}' NO enviado. " +
                    "Configure las variables SmtpSettings__Username y SmtpSettings__Password.",
                    to, subject);
                return;
            }

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
                    Timeout = 15000 // 15 segundos
                };

                await client.SendMailAsync(message);

                _logger.LogInformation("Correo enviado exitosamente a '{To}' con asunto '{Subject}'.", to, subject);
            }
            catch (SmtpException smtpEx)
            {
                _logger.LogError(smtpEx,
                    "Error SMTP al enviar correo a '{To}'. StatusCode: {StatusCode}. " +
                    "Verifique: 1) Credenciales SMTP, 2) App Password de Gmail, 3) Puerto y Host correctos.",
                    to, smtpEx.StatusCode);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inesperado al enviar correo a '{To}'.", to);
            }
        }
    }
}
