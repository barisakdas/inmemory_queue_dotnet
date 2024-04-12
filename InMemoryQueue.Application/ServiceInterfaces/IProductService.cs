namespace InMemoryQueue.Application.ServiceInterfaces;

/// <summary> Ürünlerle ilgili işlemleri gerçekleştiren servis.</summary>
public interface IProductService
{
    /// <summary>Tüm ürünleri asenkron olarak getirir.</summary>
    /// <returns>Ürün DTO listesi.</returns>
    Task<List<ProductDto>> GetAllAsync();

    /// <summary>Belirli bir ID'ye sahip ürünü asenkron olarak getirir.</summary>
    /// <param name="id">Getirilecek ürünün ID'si.</param>
    /// <returns>Ürün DTO'su veya bulunamazsa null.</returns>
    Task<ProductDto> GetByIdAsync(int id);

    /// <summary>Yeni bir ürünü asenkron olarak listeye ekler.</summary>
    /// <param name="model">Eklenecek ürünün DTO'su.</param>
    /// <returns>Task nesnesi.</returns>
    Task InsertAsync(ProductDto model);

    /// <summary>Var olan bir ürünü asenkron olarak günceller.</summary>
    /// <param name="model">Güncellenecek ürünün DTO'su.</param>
    /// <returns>Task nesnesi.</returns>
    Task UpdateAsync(ProductDto model);

    /// <summary>Belirli bir ID'ye sahip ürünü asenkron olarak listeden siler.</summary>
    /// <param name="id">Silinecek ürünün ID'si.</param>
    /// <returns>Task nesnesi.</returns>
    Task DeleteAsync(int id);
}