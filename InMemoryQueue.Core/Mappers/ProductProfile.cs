using InMemoryQueue.Core.Dtos;
using InMemoryQueue.Core.Entities;

namespace InMemoryQueue.Core.Mappers;

public static class ProductProfile
{
    public static Product ToProduct(this ProductDto productDto)
        => new Product
        {
            Id = productDto.Id,
            Name = productDto.Name,
            Category = productDto.Category,
            Stock = productDto.Stock,
            Price = productDto.Price
        };

    public static ProductDto ToProductDto(this Product product)
        => new ProductDto(
            product.Id,
            product.Name,
            product.Category,
            product.Stock,
            product.Price
        );
}