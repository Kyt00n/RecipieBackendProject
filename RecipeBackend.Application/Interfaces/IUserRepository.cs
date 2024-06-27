using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeBackend.Domain.Entities;
using System.Threading.Tasks;


namespace RecipeBackend.Application.Interfaces
{
    public interface IUserRepository
    {
        Task AddUser(UserEntity user);
        Task<UserEntity> GetUserByUsername(string username);
    }
}

