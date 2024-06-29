using MediatR;
using RecipeBackend.Application.Interfaces;
using RecipeBackend.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace RecipeBackend.Application.Features.RecipeFeatures.Commands
{
    public class CreateRecipeCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<int> ProductIds { get; set; }

        public class CreateRecipeCommandHandler : IRequestHandler<CreateRecipeCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateRecipeCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateRecipeCommand command, CancellationToken cancellationToken)
            {
                var products = _context.Products.Where(p => command.ProductIds.Contains(p.Id)).ToList();

                var recipe = new RecipeEntity
                {
                    Name = command.Name,
                    Description = command.Description,
                    Ingredients = products
                };
                _context.Recipes.Add(recipe);
                await _context.SaveChangesAsync();
                return recipe.Id;
            }
        }
    }
}