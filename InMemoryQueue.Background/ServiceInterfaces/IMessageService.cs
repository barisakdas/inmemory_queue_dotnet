namespace InMemoryQueue.Background.ServiceInterfaces;

/// <summary>Ürün listelerini bir kanala ekleyen servis.</summary>
/// <param name="_productService">Ürün servisi.</param>
/// <param name="_channel">Ürün listelerinin yazılacağı kanal.</param>
public interface IMessageService
{
    /// <summary>Ürün listesini kanala ekler.</summary>
    /// <returns>İşlem başarılıysa true, aksi takdirde false döner.</returns>
    Task<bool> AddMessageToQueue();
}