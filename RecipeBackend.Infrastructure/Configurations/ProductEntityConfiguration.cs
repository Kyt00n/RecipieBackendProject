using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeBackend.Domain.Entities;

namespace RecipeBackend.Infrastructure.Configurations;

public class ProductEntityConfiguration : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        
        builder.HasMany(f => f.Recipes)
            .WithMany(r => r.Ingredients);
    }
    
}