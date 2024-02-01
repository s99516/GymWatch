using GymWatch.Core.Domain.Models;
using GymWatch.Infrastructure.IRepositories;

namespace GymWatch.Infrastructure.Repositories.InMemoryRepositories;

public class InMemoryUserRepository : IUserRepository
{
    private List<User> Users = new()
    {
        new User
        {
            Id = 1,
            Email = "email1@.com",
            Password = "secret1",
            DateCreated = DateTime.UtcNow
        },
        new User
        {
            Id = 2,
            Email = "email2@.com",
            Password = "secret2",
            DateCreated = DateTime.UtcNow
        }
    };
    
    public async Task<User?> GetByIdAsync(int id)
    {
        return await Task.FromResult(Users.Where(x => x.Id == id).FirstOrDefault());
    }
}