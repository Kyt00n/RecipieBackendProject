using System.ComponentModel.DataAnnotations;

namespace RecipeBackend.Domain.Entities;

public class UserEntity : BaseEntity
{
    
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}