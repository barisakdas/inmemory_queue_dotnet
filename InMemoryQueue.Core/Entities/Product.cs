using InMemoryQueue.Core.Dtos;

namespace InMemoryQueue.Core.Entities;

public class Product
{
    public int Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Category { get; set; } = default!;
    public int Stock { get; set; } = default!;
    public double Price { get; set; } = default!;
}