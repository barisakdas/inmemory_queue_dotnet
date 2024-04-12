namespace InMemoryQueue.Background.ServiceInterfaces;

public interface IFileService
{
    /// <summary>Yeni bir Excel dosyası için yol oluşturur.</summary>
    /// <returns>Yeni oluşturulan Excel dosyasının adı.</returns>
    Task<string> CreatePath();
}