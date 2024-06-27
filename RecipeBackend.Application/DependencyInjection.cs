using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using RecipeBackend.Application.Interfaces;

namespace RecipeBackend.Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(DependencyInjection).Assembly;
        services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssembly(assembly));
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}