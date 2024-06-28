namespace RecipeBackend.Domain.Entities;

public class ProductEntity : BaseEntity
{
    public string Name { get; set; }
    public double Quantity { get; set; }
    public string Unit { get; set; }
    public UserEntity User { get; set; }
    public int UserId { get; set; }
    public ICollection<RecipeEntity> Recipes { get; set; }
}