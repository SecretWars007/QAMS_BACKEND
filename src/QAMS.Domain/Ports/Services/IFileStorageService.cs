// src/QAMS.Domain/Ports/Services/IFileStorageService.cs
namespace QAMS.Domain.Ports.Services
{
    /// <summary>Contrato para almacenamiento de archivos. OCP aplicado.</summary>
    public interface IFileStorageService
    {
        Task<string> SaveFileAsync(Stream fileStream, string fileName, string subfolder);
        Task<bool> DeleteFileAsync(string filePath);
        string GetFileUrl(string filePath);
    }
}
