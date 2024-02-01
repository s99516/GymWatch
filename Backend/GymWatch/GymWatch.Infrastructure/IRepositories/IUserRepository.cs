using GymWatch.Core.Domain.Models;

namespace GymWatch.Infrastructure.IRepositories;

public interface IUserRepository
{
    Task<User> GetByIdAsync(int id);
}