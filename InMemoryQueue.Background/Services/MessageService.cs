namespace InMemoryQueue.Background.Services;

/// <summary>Ürün listelerini bir kanala ekleyen servis.</summary>
/// <param name="_productService">Ürün servisi.</param>
/// <param name="_channel">Ürün listelerinin yazılacağı kanal.</param>
public class MessageService(IProductService _productService, Channel<List<ProductDto>> _channel) : IMessageService
{
    /// <summary>Ürün listesini kanala ekler.</summary>
    /// <returns>İşlem başarılıysa true, aksi takdirde false döner.</returns>
    public async Task<bool> AddMessageToQueue()
    {
        // ProductService üzerinden tüm ürünleri asenkron olarak al.
        var products = await _productService.GetAllAsync();

        // Ürün listesini kanala yazmaya çalış.
        // Eğer kanal kapalıysa veya tampon doluysa false döner.
        return _channel.Writer.TryWrite(products);
    }
}