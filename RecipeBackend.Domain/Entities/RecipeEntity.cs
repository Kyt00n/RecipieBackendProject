using System.ComponentModel.DataAnnotations;

namespace RecipeBackend.Domain.Entities;

public class RecipeEntity : BaseEntity
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public ICollection<ProductEntity> Ingredients { get; set; } 
}