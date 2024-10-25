using GymWatch.Core.Domain.Models;
using GymWatch.Infrastructure.EF;
using GymWatch.Infrastructure.IRepositories;
using GymWatch.Infrastructure.IRepositories.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace GymWatch.Infrastructure.Repositories.SQLRepositories;

public class UserRepository : Repository<User>, IUserRepository
{
    private readonly GymWatchDbContext _context;

    public UserRepository(GymWatchDbContext context) : base(context)
    {
        _context = context;
    }
    public async Task<User?> GetByIdAsync(int id)
    {
        var result = await _context.Users.FirstOrDefaultAsync(x => x.Id.Equals(id));
        return result;
    }

    public async Task<User> CreateAsync(User entity)
    {
        var entry = await _context.Users.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entry.Entity;
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        var result = await _context.Users.FirstOrDefaultAsync(x => x.Email.Equals(email));

        return result;
    }
}