// src/QAMS.Infrastructure/Email/SmtpSettings.cs
namespace QAMS.Infrastructure.Email
{
    /// <summary>
    /// Configuración SMTP para envío de correos.
    /// Compatible con Gmail SMTP, Outlook, y cualquier servidor SMTP genérico.
    /// </summary>
    public class SmtpSettings
    {
        /// <summary>Servidor SMTP (ej: smtp.gmail.com)</summary>
        public string Host { get; set; } = "smtp.gmail.com";

        /// <summary>Puerto SMTP (587 para TLS, 465 para SSL)</summary>
        public int Port { get; set; } = 587;

        /// <summary>Usuario de autenticación SMTP (email completo para Gmail)</summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>Contraseña o App Password (para Gmail usar contraseña de aplicación)</summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>Dirección de correo del remitente</summary>
        public string FromEmail { get; set; } = string.Empty;

        /// <summary>Nombre visible del remitente</summary>
        public string FromName { get; set; } = "QAMS - Quality Assurance Management System";

        /// <summary>Habilitar SSL/TLS</summary>
        public bool EnableSsl { get; set; } = true;
    }
}
