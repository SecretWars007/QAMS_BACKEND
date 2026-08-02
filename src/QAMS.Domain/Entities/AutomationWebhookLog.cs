// src/QAMS.Domain/Entities/AutomationWebhookLog.cs
using QAMS.Domain.Common;

namespace QAMS.Domain.Entities
{
    /// <summary>
    /// Log de resultados recibidos por webhook desde pipelines de automatización (CI/CD).
    /// Permite importar resultados de Playwright, JUnit, pytest, etc. en QAMS.
    /// </summary>
    public class AutomationWebhookLog : IAuditable
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ProjectId { get; set; }
        public virtual Project Project { get; set; } = null!;

        /// <summary>Nombre del pipeline o tool (ej: "Jenkins Pipeline", "GitHub Actions")</summary>
        public string Source { get; set; } = string.Empty;

        /// <summary>Formato del payload recibido: junit_xml, playwright_json, pytest_json</summary>
        public string PayloadFormat { get; set; } = "junit_xml";

        /// <summary>Cantidad de casos importados</summary>
        public int TotalTests { get; set; }
        public int PassedTests { get; set; }
        public int FailedTests { get; set; }
        public int SkippedTests { get; set; }

        /// <summary>Estado del procesamiento: SUCCESS, PARTIAL, FAILED</summary>
        public string ProcessingStatus { get; set; } = "SUCCESS";

        /// <summary>Mensaje de error si falló el procesamiento</summary>
        public string? ErrorMessage { get; set; }

        /// <summary>Payload raw recibido (guardado para auditoría)</summary>
        public string? RawPayload { get; set; }

        // IAuditable
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Guid? CreatedByUserId { get; set; }
        public virtual User? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedByUserId { get; set; }
        public virtual User? UpdatedBy { get; set; }
    }
}
