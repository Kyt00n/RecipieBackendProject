using RecipeBackend.Domain.Entities;

namespace RecipeBackend.Application.Interfaces;

public interface ITokenService
{
    string GenerateToken(UserEntity user);
}