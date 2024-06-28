using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecipeBackend.Application.Interfaces;
using RecipeBackend.Domain.Entities;
using RecipeBackend.Infrastructure.Infrastructure;

namespace RecipeBackend.Infrastructure.Repositories;

public class ProductRepository: IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddProduct(ProductEntity product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }

    public async Task<ProductEntity> GetProductById(int id)
    {
        return await _context.Products.FindAsync(id) ?? throw new InvalidOperationException();
    }

    public async Task<IEnumerable<ProductEntity>> GetProductsByUserId(int userId)
    {
        return await _context.Products.Where(p => p.UserId == userId).ToListAsync();
    }
}