using RecipeBackend.Domain.Entities;

namespace RecipeBackend.Application.Interfaces;

public interface IProductRepository
{
    Task AddProduct(ProductEntity product);
    Task<ProductEntity> GetProductById(int id);
    Task<IEnumerable<ProductEntity>> GetProductsByUserId(int userId);
}