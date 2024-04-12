namespace InMemoryQueue.Application.Services;

/// <summary> Ürünlerle ilgili işlemleri gerçekleştiren servis.</summary>
public class ProductService : IProductService
{
    // Ürün listesini tutan özel bir alan.
    private List<Product> _products = new List<Product>()
    {
        new Product { Id = 1, Name = "Kalem", Category = "Kırtasiye", Stock = 10, Price = 10.5 },
        new Product { Id = 2, Name = "Defter", Category = "Kırtasiye", Stock = 20, Price = 20.5 },
        new Product { Id = 3, Name = "Silgi", Category = "Kırtasiye", Stock = 15, Price = 5.5 },
        new Product { Id = 4, Name = "Cetvel", Category = "Kırtasiye", Stock = 25, Price = 7.5 },
        new Product { Id = 5, Name = "Dolma Kalem", Category = "Kırtasiye", Stock = 5, Price = 50.0 },
        new Product { Id = 6, Name = "Tükenmez Kalem", Category = "Kırtasiye", Stock = 50, Price = 3.75 },
        new Product { Id = 7, Name = "Boya Kalemi", Category = "Kırtasiye", Stock = 30, Price = 15.0 },
        new Product { Id = 8, Name = "Makas", Category = "Kırtasiye", Stock = 8, Price = 12.5 },
        new Product { Id = 9, Name = "Yapıştırıcı", Category = "Kırtasiye", Stock = 16, Price = 9.25 },
        new Product { Id = 10, Name = "Post-it", Category = "Kırtasiye", Stock = 60, Price = 19.99 }
    };

    /// <summary>Tüm ürünleri asenkron olarak getirir.</summary>
    /// <returns>Ürün DTO listesi.</returns>
    public async Task<List<ProductDto>> GetAllAsync()
    {
        // DTO listesi için yeni bir liste oluştur.
        var response = new List<ProductDto>();

        // Her bir ürünü DTO'ya dönüştür ve listeye ekle.
        _products.ForEach(product => response.Add(product.ToProductDto()));

        // DTO listesini döndür.
        return response;
    }

    /// <summary>Belirli bir ID'ye sahip ürünü asenkron olarak getirir.</summary>
    /// <param name="id">Getirilecek ürünün ID'si.</param>
    /// <returns>Ürün DTO'su veya bulunamazsa null.</returns>
    public async Task<ProductDto> GetByIdAsync(int id)
    {
        // ID'ye göre ürünü bul.
        var product = _products.FirstOrDefault(p => p.Id == id);

        // Ürün bulunamazsa null döndür.
        if (product is null)
            return null;

        // Ürünü DTO'ya dönüştür ve döndür.
        return product.ToProductDto();
    }

    /// <summary>Yeni bir ürünü asenkron olarak listeye ekler.</summary>
    /// <param name="model">Eklenecek ürünün DTO'su.</param>
    /// <returns>Task nesnesi.</returns>
    public Task InsertAsync(ProductDto model)
    {
        // DTO'dan ürünü oluştur ve listeye ekle.
        _products.Add(model.ToProduct());

        // İşlem tamamlandı olarak işaretle.
        return Task.CompletedTask;
    }

    /// <summary>Var olan bir ürünü asenkron olarak günceller.</summary>
    /// <param name="model">Güncellenecek ürünün DTO'su.</param>
    /// <returns>Task nesnesi.</returns>
    public Task UpdateAsync(ProductDto model)
    {
        // Güncellenecek ürünü bul ve listeden kaldır.
        var product = _products.FirstOrDefault(x => x.Id == model.Id);
        _products.Remove(product);

        // Yeni değerleri ile ürünü listeye ekle.
        _products.Add(model.ToProduct());

        // İşlem tamamlandı olarak işaretle.
        return Task.CompletedTask;
    }

    /// <summary>Belirli bir ID'ye sahip ürünü asenkron olarak listeden siler.</summary>
    /// <param name="id">Silinecek ürünün ID'si.</param>
    /// <returns>Task nesnesi.</returns>
    public Task DeleteAsync(int id)
    {
        // ID'ye göre ürünü bul ve listeden kaldır.
        _products.Remove(_products.FirstOrDefault(x => x.Id == id));

        // İşlem tamamlandı olarak işaretle.
        return Task.CompletedTask;
    }
}