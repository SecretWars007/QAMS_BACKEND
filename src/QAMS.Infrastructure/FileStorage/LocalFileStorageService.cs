// src/QAMS.Infrastructure/FileStorage/LocalFileStorageService.cs
using Microsoft.Extensions.Logging;
using QAMS.Domain.Ports.Services;

namespace QAMS.Infrastructure.FileStorage
{
    /// <summary>Almacena archivos en disco local. OCP: reemplazable por S3.</summary>
    public class LocalFileStorageService(ILogger<LocalFileStorageService> logger) : IFileStorageService
    {
        private readonly string _basePath = EnsureDirectory(
            Environment.GetEnvironmentVariable("UPLOADS_PATH")
            ?? Path.Combine(AppContext.BaseDirectory, "uploads"));
        private readonly ILogger<LocalFileStorageService> _logger = logger;

        private static string EnsureDirectory(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            return path;
        }

        public async Task<string> SaveFileAsync(Stream fileStream, string fileName, string subfolder)
        {
            var folderPath = Path.Combine(_basePath, subfolder);
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            // Generar nombre único para evitar colisiones
            var uniqueName = $"{Guid.NewGuid()}_{fileName}";
            var fullPath = Path.Combine(folderPath, uniqueName);

            _logger.LogInformation("Guardando archivo en: {Path}", fullPath);

            await using var stream = new FileStream(fullPath, FileMode.Create);
            await fileStream.CopyToAsync(stream);

            // Retornar ruta relativa
            return Path.Combine(subfolder, uniqueName).Replace("\\", "/");
        }

        public Task<bool> DeleteFileAsync(string filePath)
        {
            var fullPath = Path.Combine(_basePath, filePath);
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
                _logger.LogInformation("Archivo eliminado: {Path}", fullPath);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public string GetFileUrl(string filePath) => $"/uploads/{filePath}";
    }
}

