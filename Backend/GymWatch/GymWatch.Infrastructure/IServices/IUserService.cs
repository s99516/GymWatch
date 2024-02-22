using GymWatch.Infrastructure.DTOs;

namespace GymWatch.Infrastructure.IServices;

public interface IUserService
{
    Task<UserDto> GetByIdAsync(int id);
}