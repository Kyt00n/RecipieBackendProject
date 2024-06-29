using MediatR;
using RecipeBackend.Application.Interfaces;
using RecipeBackend.Domain.Entities;

namespace RecipeBackend.Application.Features.ProductFeatures.Commands;


public class CreateProductCommand :IRequest<int>
{
    public string Name { get; set; }
    public double Quantity { get; set; }
    public string Unit { get; set; }
    public int UserId { get; set; }
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public CreateProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new ProductEntity();
            product.Name = command.Name;
            product.Quantity = command.Quantity;
            product.Unit = command.Unit;
            product.UserId = command.UserId;
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product.Id;
        }
    }
}