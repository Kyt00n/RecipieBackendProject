using RecipeBackend.Domain.Entities;

namespace RecipeBackend.Application.Interfaces;

public interface IRecipeRepository
{
    Task AddRecipe(RecipeEntity recipe);
    Task<RecipeEntity> GetRecipeById(int id);
    Task<IEnumerable<RecipeEntity>> GetRecipes();
    Task<IEnumerable<RecipeEntity>> GetRecipesThatMatchesProducts(ICollection<ProductEntity> products);
}