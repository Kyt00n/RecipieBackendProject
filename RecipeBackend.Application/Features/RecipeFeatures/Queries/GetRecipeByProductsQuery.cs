using MediatR;
using RecipeBackend.Application.Interfaces;

namespace RecipeBackend.Application.Features.RecipeFeatures.Queries;

public class GetRecipeIdsByProductsQuery : IRequest<IEnumerable<int>>
{
    public int UserId { get; set; }

    public class GetRecipeIdsByProductsQueryHandler : IRequestHandler<GetRecipeIdsByProductsQuery, IEnumerable<int>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IRecipeRepository _recipeRepository;

        public GetRecipeIdsByProductsQueryHandler(IProductRepository productRepository, IRecipeRepository recipeRepository)
        {
            _productRepository = productRepository;
            _recipeRepository = recipeRepository;
        }

        public async Task<IEnumerable<int>> Handle(GetRecipeIdsByProductsQuery request, CancellationToken cancellationToken)
        {
            var userProducts = await _productRepository.GetProductsByUserId(request.UserId);
            var matchingRecipes = await _recipeRepository.GetRecipesThatMatchesProducts(userProducts.ToList());

            return matchingRecipes.Select(r => r.Id);
        }
    }
}