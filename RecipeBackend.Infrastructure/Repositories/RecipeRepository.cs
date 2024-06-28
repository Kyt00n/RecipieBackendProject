using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecipeBackend.Application.Interfaces;
using RecipeBackend.Domain.Entities;
using RecipeBackend.Infrastructure.Infrastructure;

namespace RecipeBackend.Infrastructure.Repositories;

public class RecipeRepository : IRecipeRepository
{
    private readonly ApplicationDbContext _context;

    public RecipeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddRecipe(RecipeEntity recipe)
    {
        _context.Recipes.Add(recipe);
        await _context.SaveChangesAsync();
    }   

    public async Task<RecipeEntity> GetRecipeById(int id)
    {
        var recipe =  await _context.Recipes.FindAsync(id);
        if (recipe == null)
        {
            throw new KeyNotFoundException();
        }
        return recipe;
    }

    public async Task<IEnumerable<RecipeEntity>> GetRecipes()
    {
        return await _context.Recipes.ToListAsync();
    }

    public async Task<IEnumerable<RecipeEntity>> GetRecipesThatMatchesProducts(ICollection<ProductEntity> products)
    {
        var productIds = products.Select(p => p.Id).ToList();
        return await _context.Recipes
            .Where(r => productIds.All(pid => r.Ingredients.Any(i => i.Id == pid)))
            .ToListAsync();
    }
}