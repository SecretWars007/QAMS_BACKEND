// src/QAMS.Application/Templates/EmailTemplates.cs
namespace QAMS.Application.Templates
{
    /// <summary>
    /// Plantillas HTML para correos electrónicos del sistema QAMS.
    /// </summary>
    public static class EmailTemplates
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
                                        <a href=""https://qams-web.onrender.com/"" style=""display:inline-block;background:linear-gradient(135deg,#6366f1,#8b5cf6);color:#ffffff;text-decoration:none;padding:14px 40px;border-radius:10px;font-size:15px;font-weight:600;letter-spacing:0.3px;"">
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

        public static string GetForgotPasswordEmailHtml(string fullName, string resetLink)
        {
            return $@"
<!DOCTYPE html>
<html lang=""es"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
</head>
<body style=""margin:0;padding:0;background-color:#0f0f23;font-family:'Segoe UI',Roboto,'Helvetica Neue',Arial,sans-serif;"">
    <table role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""padding:40px 20px;"">
        <tr>
            <td align=""center"">
                <table role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""600"" style=""background-color:#1a1a2e;border:1px solid rgba(99,102,241,0.2);border-radius:16px;"">
                    <tr>
                        <td style=""padding:40px;text-align:center;"">
                            <h2 style=""color:#ffffff;margin-top:0;"">Restablecer tu contraseña</h2>
                            <p style=""color:#94a3b8;font-size:16px;line-height:1.6;text-align:left;"">
                                Hola {fullName},<br><br>
                                Recibimos una solicitud para restablecer tu contraseña en QAMS. Si fuiste tú, por favor haz clic en el siguiente botón:
                            </p>
                            <a href=""{resetLink}"" style=""display:inline-block;background:linear-gradient(135deg,#6366f1,#8b5cf6);color:#ffffff;text-decoration:none;padding:12px 30px;border-radius:8px;font-weight:bold;margin:20px 0;"">Restablecer Contraseña</a>
                            <p style=""color:#64748b;font-size:14px;text-align:left;"">
                                Si el botón no funciona, copia y pega este enlace en tu navegador:<br>
                                <a href=""{resetLink}"" style=""color:#8b5cf6;word-break:break-all;"">{resetLink}</a>
                            </p>
                            <p style=""color:#94a3b8;font-size:14px;text-align:left;margin-top:20px;"">
                                Si no solicitaste esto, puedes ignorar este correo sin problemas.
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

        public static string GetPasswordResetSuccessEmailHtml(string fullName)
        {
            return $@"
<!DOCTYPE html>
<html lang=""es"">
<body style=""margin:0;padding:0;background-color:#0f0f23;font-family:'Segoe UI',Roboto,'Helvetica Neue',Arial,sans-serif;"">
    <table role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""padding:40px 20px;"">
        <tr>
            <td align=""center"">
                <table role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""600"" style=""background-color:#1a1a2e;border:1px solid rgba(34,197,94,0.3);border-radius:16px;"">
                    <tr>
                        <td style=""padding:40px;text-align:center;"">
                            <h2 style=""color:#4ade80;margin-top:0;"">Contraseña Actualizada Exitosamente</h2>
                            <p style=""color:#94a3b8;font-size:16px;line-height:1.6;text-align:left;"">
                                Hola {fullName},<br><br>
                                Te confirmamos que la contraseña de tu cuenta en QAMS ha sido actualizada exitosamente.
                            </p>
                            <a href=""https://qams-web.onrender.com/"" style=""display:inline-block;background:#4ade80;color:#0f0f23;text-decoration:none;padding:12px 30px;border-radius:8px;font-weight:bold;margin:20px 0;"">Ir al Inicio</a>
                            <p style=""color:#94a3b8;font-size:14px;text-align:left;margin-top:20px;"">
                                Si no realizaste esta acción, por favor contacta al administrador del sistema inmediatamente.
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

        public static string GetPasswordChangeSuccessEmailHtml(string fullName)
        {
            return GetPasswordResetSuccessEmailHtml(fullName); // Reutilizar la misma plantilla por ahora
        }

        public static string GetProjectCreatedEmailHtml(string fullName, string projectName, string projectKey)
        {
            return $@"
<!DOCTYPE html>
<html lang=""es"">
<body style=""margin:0;padding:0;background-color:#0f0f23;font-family:'Segoe UI',Roboto,'Helvetica Neue',Arial,sans-serif;"">
    <table role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""padding:40px 20px;"">
        <tr>
            <td align=""center"">
                <table role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""600"" style=""background-color:#1a1a2e;border:1px solid rgba(99,102,241,0.2);border-radius:16px;"">
                    <tr>
                        <td style=""padding:40px;"">
                            <h2 style=""color:#ffffff;margin-top:0;text-align:center;"">Nuevo Proyecto Asignado</h2>
                            <p style=""color:#e2e8f0;font-size:16px;line-height:1.6;"">
                                Hola {fullName},
                            </p>
                            <p style=""color:#94a3b8;font-size:15px;line-height:1.6;"">
                                Has sido asignado a un nuevo proyecto en QAMS.
                            </p>
                            <div style=""background:rgba(99,102,241,0.1);border:1px solid rgba(99,102,241,0.25);border-radius:8px;padding:20px;margin:20px 0;"">
                                <p style=""margin:0;color:#818cf8;font-size:12px;font-weight:bold;text-transform:uppercase;"">Proyecto</p>
                                <p style=""margin:5px 0 0;color:#ffffff;font-size:18px;font-weight:bold;"">{projectName}</p>
                                <p style=""margin:5px 0 0;color:#94a3b8;font-size:14px;"">Clave (Virtual): {projectKey}</p>
                            </div>
                            <div style=""text-align:center;"">
                                <a href=""https://qams-web.onrender.com/"" style=""display:inline-block;background:linear-gradient(135deg,#6366f1,#8b5cf6);color:#ffffff;text-decoration:none;padding:12px 30px;border-radius:8px;font-weight:bold;"">Ver en el Dashboard</a>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</body>
</html>";
        }

        public static string GetProjectUpdatedEmailHtml(string fullName, string projectName)
        {
            return $@"
<!DOCTYPE html>
<html lang=""es"">
<body style=""margin:0;padding:0;background-color:#0f0f23;font-family:'Segoe UI',Roboto,'Helvetica Neue',Arial,sans-serif;"">
    <table role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""padding:40px 20px;"">
        <tr>
            <td align=""center"">
                <table role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""600"" style=""background-color:#1a1a2e;border:1px solid rgba(234,179,8,0.3);border-radius:16px;"">
                    <tr>
                        <td style=""padding:40px;"">
                            <h2 style=""color:#facc15;margin-top:0;text-align:center;"">Proyecto Actualizado</h2>
                            <p style=""color:#e2e8f0;font-size:16px;line-height:1.6;"">
                                Hola {fullName},
                            </p>
                            <p style=""color:#94a3b8;font-size:15px;line-height:1.6;"">
                                El proyecto <strong>{projectName}</strong> (asociado a tu cuenta) ha sido modificado recientemente.
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

        public static string GetProjectDeletedEmailHtml(string fullName, string projectName)
        {
            return $@"
<!DOCTYPE html>
<html lang=""es"">
<body style=""margin:0;padding:0;background-color:#0f0f23;font-family:'Segoe UI',Roboto,'Helvetica Neue',Arial,sans-serif;"">
    <table role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""padding:40px 20px;"">
        <tr>
            <td align=""center"">
                <table role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""600"" style=""background-color:#1a1a2e;border:1px solid rgba(239,68,68,0.3);border-radius:16px;"">
                    <tr>
                        <td style=""padding:40px;"">
                            <h2 style=""color:#f87171;margin-top:0;text-align:center;"">Proyecto Desactivado/Eliminado</h2>
                            <p style=""color:#e2e8f0;font-size:16px;line-height:1.6;"">
                                Hola {fullName},
                            </p>
                            <p style=""color:#94a3b8;font-size:15px;line-height:1.6;"">
                                Te notificamos que el proyecto <strong>{projectName}</strong> ha sido desactivado o eliminado del sistema.
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
