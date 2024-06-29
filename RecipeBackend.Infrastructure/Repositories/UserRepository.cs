using System;
using RecipeBackend.Application.Interfaces;
using RecipeBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using RecipeBackend.Infrastructure.Infrastructure;

namespace RecipeBackend.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddUser(UserEntity user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<UserEntity>? GetUserByUsername(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}
