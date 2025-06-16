using Emporium.Core;
using Emporium.Domain.Entities;

namespace Emporium.Application.Service;

public class ProductService(IProductRepository repository)
{
    private readonly IProductRepository _repository = repository;

    public Task<IEnumerable<Product>> GetAllAsync() => _repository.GetAllAsync();

    public Task<Product?> GetByIdAsync(Guid id) => _repository.GetByIdAsync(id);

    public Task<Product> CreateAsync(Product product) => _repository.AddAsync(product);

    public Task UpdateAsync(Product product) => _repository.UpdateAsync(product);

    public Task DeleteAsync(Guid id) => _repository.DeleteAsync(id);
}
