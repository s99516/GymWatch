using GymWatch.Infrastructure.DTOs;

namespace GymWatch.Infrastructure.Handlers.Abstraction;

public interface IJwtHandler
{
    JwtDto CreateToken(string email);
}