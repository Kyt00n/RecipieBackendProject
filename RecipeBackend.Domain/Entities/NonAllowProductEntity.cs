namespace RecipeBackend.Domain.Entities;

public class NonAllowProductEntity : UserEntity
{
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public UserEntity User { get; set; }
}