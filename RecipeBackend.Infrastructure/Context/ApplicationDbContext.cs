using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecipeBackend.Application.Interfaces;
using RecipeBackend.Domain.Entities;

namespace RecipeBackend.Infrastructure.Infrastructure;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext()
    {
        
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }
}