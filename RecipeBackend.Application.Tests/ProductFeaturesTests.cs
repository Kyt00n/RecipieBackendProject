using Microsoft.EntityFrameworkCore;
using Moq;
using RecipeBackend.Application.Features.ProductFeatures.Commands;
using RecipeBackend.Application.Interfaces;
using RecipeBackend.Domain.Entities;

namespace RecipeBackend.Application.Tests;

public class ProductFeaturesTests
{
    private readonly Mock<IApplicationDbContext> _contextMock;
    private readonly CreateProductCommand.CreateProductCommandHandler _handler;

    public ProductFeaturesTests()
    {
        _contextMock = new Mock<IApplicationDbContext>();
        _handler = new CreateProductCommand.CreateProductCommandHandler(_contextMock.Object);
    }

    [Fact]
    public async Task Handle_CreatesProduct_WhenCommandIsValid()
    {
        // Arrange
        var command = new CreateProductCommand { Name = "Test Product", Quantity = 10.0, Unit = "Kg", UserId = 1 };

        var productSetMock = new Mock<DbSet<ProductEntity>>();
        _contextMock.Setup(context => context.Products).Returns(productSetMock.Object);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        productSetMock.Verify(set => set.Add(It.IsAny<ProductEntity>()), Times.Once);
        _contextMock.Verify(context => context.SaveChangesAsync(), Times.Once);
    }
}