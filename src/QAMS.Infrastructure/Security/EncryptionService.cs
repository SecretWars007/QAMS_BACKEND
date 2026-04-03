using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using QAMS.Application.Interfaces;

namespace QAMS.Infrastructure.Security;

public class EncryptionService : IEncryptionService
{
    private readonly byte[] _key;
    private readonly byte[] _iv;

    public EncryptionService(IOptions<EncryptionSettings> settings)
    {
        _key = Encoding.UTF8.GetBytes(settings.Value.Key);
        _iv = Encoding.UTF8.GetBytes(settings.Value.IV);

        if (_key.Length != 32) throw new ArgumentException("Key must be 32 characters (256 bits)");
        if (_iv.Length != 16) throw new ArgumentException("IV must be 16 characters (128 bits)");
    }

    public string Encrypt(string plainText)
    {
        if (string.IsNullOrEmpty(plainText)) return plainText;

        using var aes = Aes.Create();
        aes.Key = _key;
        aes.IV = _iv;

        var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
        using var ms = new MemoryStream();
        using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
        {
            using var sw = new StreamWriter(cs);
            sw.Write(plainText);
        }

        return Convert.ToBase64String(ms.ToArray());
    }

    public string Decrypt(string cipherText)
    {
        if (string.IsNullOrEmpty(cipherText)) return cipherText;

        try
        {
            using var aes = Aes.Create();
            aes.Key = _key;
            aes.IV = _iv;

            var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            using var ms = new MemoryStream(Convert.FromBase64String(cipherText));
            using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
            using var sr = new StreamReader(cs);
            return sr.ReadToEnd();
        }
        catch (Exception)
        {
            // If decryption fails, it might be because the text was not encrypted.
            // In a production environment, you might want to log this or throw an exception.
            throw new CryptographicException("Failed to decrypt the provided data. Please ensure it is correctly encrypted.");
        }
    }
}
