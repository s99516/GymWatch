using GymWatch.Infrastructure.DTOs;

namespace GymWatch.Infrastructure.IServices;

public interface IUserService
{
    Task<UserDto> GetByIdAsync(int id);
    Task<UserDto> GetByEmailAsync(string email);
    Task<int> RegisterAsync(string email, string password);
    Task LoginAsync(string email, string password);
}