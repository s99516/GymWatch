using GymWatch.Infrastructure.Commands;
using GymWatch.Infrastructure.Extensions;
using GymWatch.Infrastructure.Handlers.Abstraction;
using GymWatch.Infrastructure.IServices;
using Microsoft.Extensions.Caching.Memory;

namespace GymWatch.Infrastructure.Handlers;

public class LoginHandler
{
    private readonly IUserService _userService;
    private readonly IJwtHandler _jwtHandler;
    private readonly IMemoryCache _memoryCache;
    
    public LoginHandler(IUserService userService, IJwtHandler jwtHandler, IMemoryCache memoryCache)
    {
        _userService = userService;
        _jwtHandler = jwtHandler;
        _memoryCache = memoryCache;
    }

    public async Task HandleAsync(LoginCommand command)
    {
        await _userService.LoginAsync(command.Email, command.Password);

        var jwt = _jwtHandler.CreateToken(command.Email);
        
        _memoryCache.SetJwt(command.TokenId, jwt);
    }
}

