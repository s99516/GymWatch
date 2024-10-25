using GymWatch.Infrastructure.DTOs;

namespace GymWatch.Infrastructure.IServices;

public interface IUserService
{
    Task<UserDto?> GetByIdAsync(int id);
    Task<UserDto?> GetByEmailAsync(string email);
    Task<UserDto> RegisterAsync(string email, string password);
    Task LoginAsync(string email, string password);
    Task<int?> DeleteAsync(int id);
}