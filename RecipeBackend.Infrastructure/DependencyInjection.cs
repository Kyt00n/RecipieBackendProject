using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using RecipeBackend.Application.Interfaces;
using RecipeBackend.Infrastructure.Infrastructure;
using RecipeBackend.Infrastructure.Repositories;

namespace RecipeBackend.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastucture(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
                )
            );

        services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
        services.AddScoped<IUserRepository, UserRepository>();
    }

}