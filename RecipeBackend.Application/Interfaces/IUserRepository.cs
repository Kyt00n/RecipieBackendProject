using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBackend.Application.Interfaces
{
    public interface IUserRepository
    {
        Task AddUser(User user);
        Task<User> GetUserByUsername(string username);
    }
}

