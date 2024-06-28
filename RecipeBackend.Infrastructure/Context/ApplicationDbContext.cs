using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecipeBackend.Application.Interfaces;
using RecipeBackend.Domain.Entities;
using RecipeBackend.Infrastructure.Configurations;

namespace RecipeBackend.Infrastructure.Infrastructure;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext()
    {
        
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());

        base.OnModelCreating(modelBuilder);
    }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<NonAllowProductEntity> NonAllowProducts { get; set; }
    public DbSet<RecipeEntity> Recipes { get; set; }
    
    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }
}