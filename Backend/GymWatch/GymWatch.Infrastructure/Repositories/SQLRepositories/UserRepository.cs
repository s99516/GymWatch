using GymWatch.Core.Domain.Models;
using GymWatch.Infrastructure.EF;
using GymWatch.Infrastructure.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace GymWatch.Infrastructure.Repositories.SQLRepositories;

public class UserRepository : IUserRepository
{
    private readonly GymWatchDbContext _context;

    public UserRepository(GymWatchDbContext context)
    {
        _context = context;
    }
    public async Task<User?> GetByIdAsync(int id)
    {
        var result = await _context.Users.FirstOrDefaultAsync(x => x.Id.Equals(id));
        return result;
    }

    public async Task<int> AddAsync(User entity)
    {
        await _context.Users.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity.Id;
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        var result = await _context.Users.FirstOrDefaultAsync(x => x.Email.Equals(email));

        return result;
    }
}