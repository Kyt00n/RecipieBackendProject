using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeBackend.Domain.Entities;

namespace RecipeBackend.Infrastructure.Configurations;

public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasMany(u => u.Products)
            .WithOne(f => f.User)
            .HasForeignKey(f => f.UserId);
        
        builder.HasMany(u => u.NonAllowProducts)
            .WithOne(a => a.User)
            .HasForeignKey(a => a.UserId);
    }
}