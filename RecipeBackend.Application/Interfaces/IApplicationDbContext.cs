using Microsoft.EntityFrameworkCore;
using RecipeBackend.Domain.Entities;

namespace RecipeBackend.Application.Interfaces;

public interface IApplicationDbContext
{
    DbSet<UserEntity> Users { get; set; }
    DbSet<ProductEntity> Products { get; set; }
    Task<int> SaveChangesAsync();
}