namespace RecipeBackend.Domain.Entities;

public class ProductEntity : BaseEntity
{
    public string Name { get; set; }
    public double Quantity { get; set; }
    public string Unit { get; set; }
}