namespace Emporium.Infrastructure;

using Emporium.Core;
using Emporium.Domain.Entities;

public class InMemoryProductRepository : IProductRepository
{
    private readonly List<Product> _products = [];

    public Task<Product> AddAsync(Product product)
    {
        product.Id = Guid.NewGuid();
        product.CreatedAt = DateTime.UtcNow;
        product.UpdatedAt = DateTime.UtcNow;
        _products.Add(product);
        return Task.FromResult(product);
    }

    public Task DeleteAsync(Guid id)
    {
        var index = _products.FindIndex(p => p.Id == id);
        if (index >= 0)
        {
            _products.RemoveAt(index);
        }
        return Task.CompletedTask;
    }

    public Task<IEnumerable<Product>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<Product>>(_products);
    }

    public Task<Product?> GetByIdAsync(Guid id)
    {
        Product? product = _products.FirstOrDefault(p => p.Id == id);
        return Task.FromResult(product);
    }

    public Task UpdateAsync(Product product)
    {
        var existing = _products.FirstOrDefault(p => p.Id == product.Id);
        if (existing is not null)
        {
            existing.Name = product.Name;
            existing.Description = product.Description;
            existing.Price = product.Price;
            existing.StockQuantity = product.StockQuantity;
            existing.CategoryId = product.CategoryId;
            existing.Category = product.Category;
            existing.UpdatedAt = DateTime.UtcNow;
        }
        return Task.CompletedTask;
    }
}
