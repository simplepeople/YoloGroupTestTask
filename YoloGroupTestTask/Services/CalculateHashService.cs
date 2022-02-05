using System.Security.Cryptography;
using YoloGroupTestTask.Interfaces;

namespace YoloGroupTestTask.Services;

public class CalculateHashService : ICalculateHashService
{
    /// <summary>
    /// Probably here we should add a lot of check of file exists and
    /// try/catch blocks in case of errors 
    /// </summary>
    /// <returns></returns>
    public async Task<string> CalculateHash()
    {
        var filePath = GetFilePath();
        await using var stream = GetFileStream(filePath);
        return await Calculate(stream);
    }

    private static string GetFilePath()
    {
        const string calculateHashDirectory = "Assets/CalculateHash";
        return Directory.GetFiles(calculateHashDirectory).Single();
    }

    private static Stream GetFileStream(string filePath)
    {
        return File.OpenRead(filePath);
    }

    /// <summary>
    /// If file storage stays same, then probably we have to use some queue-based mechanism
    /// with specified number of parallel reads to avoid performance degradation
    /// </summary>
    /// <param name="stream"></param>
    /// <returns></returns>
    private static async Task<string> Calculate(Stream stream)
    {
        using var sha256 = SHA256.Create();
        var buffer = new byte[8192];
        int read;
        while ((read = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
        {
            sha256.TransformBlock(buffer, 0, read, buffer, 0);
        }

        sha256.TransformFinalBlock(buffer, 0, 0);
        return BitConverter.ToString(sha256.Hash).Replace("-", string.Empty);
    }
}