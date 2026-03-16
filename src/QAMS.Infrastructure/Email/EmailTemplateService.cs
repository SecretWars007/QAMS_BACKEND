// src/QAMS.Infrastructure/Email/EmailTemplateService.cs
namespace QAMS.Infrastructure.Email
{
    /// <summary>
    /// Servicio de plantillas HTML para correos electrónicos.
    /// Genera HTML profesional con diseño moderno y colores del sistema QAMS.
    /// </summary>
    public static class EmailTemplateService
    {
        /// <summary>
        /// Genera el HTML del correo de bienvenida después del registro.
        /// </summary>
        public static string GetWelcomeEmailHtml(string fullName, string username)
        {
            return $@"
<!DOCTYPE html>
<html lang=""es"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Bienvenido a QAMS</title>
</head>
<body style=""margin:0;padding:0;background-color:#0f0f23;font-family:'Segoe UI',Roboto,'Helvetica Neue',Arial,sans-serif;"">
    <table role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""min-height:100vh;"">
        <tr>
            <td align=""center"" style=""padding:40px 20px;"">
                <table role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""600"" style=""max-width:600px;width:100%;"">
                    
                    <!-- Header con gradiente -->
                    <tr>
                        <td style=""background:linear-gradient(135deg,#6366f1 0%,#8b5cf6 50%,#a855f7 100%);border-radius:16px 16px 0 0;padding:40px 40px 30px;text-align:center;"">
                            <!-- Logo QAMS -->
                            <div style=""margin-bottom:20px;"">
                                <span style=""display:inline-block;width:60px;height:60px;background:rgba(255,255,255,0.2);border-radius:16px;line-height:60px;font-size:28px;font-weight:800;color:#ffffff;letter-spacing:-1px;"">QA</span>
                            </div>
                            <h1 style=""margin:0;color:#ffffff;font-size:28px;font-weight:700;letter-spacing:-0.5px;"">
                                ¡Bienvenido a QAMS!
                            </h1>
                            <p style=""margin:8px 0 0;color:rgba(255,255,255,0.85);font-size:16px;font-weight:400;"">
                                Quality Assurance Management System
                            </p>
                        </td>
                    </tr>

                    <!-- Cuerpo principal -->
                    <tr>
                        <td style=""background-color:#1a1a2e;padding:40px;border-left:1px solid rgba(99,102,241,0.2);border-right:1px solid rgba(99,102,241,0.2);"">
                            <p style=""margin:0 0 20px;color:#e2e8f0;font-size:18px;font-weight:600;"">
                                Hola {fullName},
                            </p>
                            <p style=""margin:0 0 24px;color:#94a3b8;font-size:15px;line-height:1.7;"">
                                Tu cuenta ha sido creada exitosamente en el sistema <strong style=""color:#a78bfa;"">QAMS</strong>.
                                Ya puedes iniciar sesión y comenzar a gestionar tus proyectos de calidad.
                            </p>

                            <!-- Tarjeta de credenciales -->
                            <table role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""margin-bottom:28px;"">
                                <tr>
                                    <td style=""background:rgba(99,102,241,0.1);border:1px solid rgba(99,102,241,0.25);border-radius:12px;padding:24px;"">
                                        <p style=""margin:0 0 4px;color:#818cf8;font-size:12px;font-weight:600;text-transform:uppercase;letter-spacing:1px;"">
                                            Tu usuario
                                        </p>
                                        <p style=""margin:0;color:#ffffff;font-size:20px;font-weight:700;letter-spacing:0.5px;"">
                                            {username}
                                        </p>
                                    </td>
                                </tr>
                            </table>

                            <!-- Features -->
                            <p style=""margin:0 0 16px;color:#cbd5e1;font-size:14px;font-weight:600;"">
                                Con QAMS puedes:
                            </p>
                            <table role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""margin-bottom:28px;"">
                                <tr>
                                    <td style=""padding:8px 0;"">
                                        <span style=""display:inline-block;width:28px;height:28px;background:rgba(34,197,94,0.15);border-radius:8px;text-align:center;line-height:28px;font-size:14px;vertical-align:middle;margin-right:12px;"">✓</span>
                                        <span style=""color:#e2e8f0;font-size:14px;vertical-align:middle;"">Gestionar proyectos de QA y suites de prueba</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td style=""padding:8px 0;"">
                                        <span style=""display:inline-block;width:28px;height:28px;background:rgba(34,197,94,0.15);border-radius:8px;text-align:center;line-height:28px;font-size:14px;vertical-align:middle;margin-right:12px;"">✓</span>
                                        <span style=""color:#e2e8f0;font-size:14px;vertical-align:middle;"">Ejecutar y registrar casos de prueba con evidencias</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td style=""padding:8px 0;"">
                                        <span style=""display:inline-block;width:28px;height:28px;background:rgba(34,197,94,0.15);border-radius:8px;text-align:center;line-height:28px;font-size:14px;vertical-align:middle;margin-right:12px;"">✓</span>
                                        <span style=""color:#e2e8f0;font-size:14px;vertical-align:middle;"">Visualizar métricas y dashboards en tiempo real</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td style=""padding:8px 0;"">
                                        <span style=""display:inline-block;width:28px;height:28px;background:rgba(34,197,94,0.15);border-radius:8px;text-align:center;line-height:28px;font-size:14px;vertical-align:middle;margin-right:12px;"">✓</span>
                                        <span style=""color:#e2e8f0;font-size:14px;vertical-align:middle;"">Generar reportes PDF de cumplimiento</span>
                                    </td>
                                </tr>
                            </table>

                            <!-- Botón CTA -->
                            <table role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
                                <tr>
                                    <td align=""center"">
                                        <a href=""#"" style=""display:inline-block;background:linear-gradient(135deg,#6366f1,#8b5cf6);color:#ffffff;text-decoration:none;padding:14px 40px;border-radius:10px;font-size:15px;font-weight:600;letter-spacing:0.3px;"">
                                            Iniciar Sesión
                                        </a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <!-- Footer -->
                    <tr>
                        <td style=""background-color:#12122a;border-radius:0 0 16px 16px;padding:24px 40px;border-left:1px solid rgba(99,102,241,0.2);border-right:1px solid rgba(99,102,241,0.2);border-bottom:1px solid rgba(99,102,241,0.2);text-align:center;"">
                            <p style=""margin:0 0 8px;color:#64748b;font-size:13px;"">
                                Este correo fue enviado automáticamente por <strong style=""color:#818cf8;"">QAMS</strong>.
                            </p>
                            <p style=""margin:0;color:#475569;font-size:12px;"">
                                © {DateTime.UtcNow.Year} QAMS - Quality Assurance Management System. Todos los derechos reservados.
                            </p>
                        </td>
                    </tr>

                </table>
            </td>
        </tr>
    </table>
</body>
</html>";
        }
    }
}
