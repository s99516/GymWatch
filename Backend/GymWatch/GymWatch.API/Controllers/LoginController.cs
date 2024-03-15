using GymWatch.API.Controllers.Abstraction;
using GymWatch.Infrastructure.Commands;
using GymWatch.Infrastructure.Extensions;
using GymWatch.Infrastructure.Handlers;
using GymWatch.Infrastructure.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace GymWatch.API.Controllers;

public class LoginController : ApiControllerBase
{
    private readonly IMemoryCache _memoryCache;
    private readonly LoginHandler _loginHandler;

    public LoginController(IMemoryCache memoryCache, LoginHandler loginHandler)
    {
        _memoryCache = memoryCache;
        _loginHandler = loginHandler;
    }
    
    [HttpPost]
    public async Task<IActionResult> LoginAsync([FromBody] LoginCommand command)
    {
        command.TokenId = Guid.NewGuid();
        await _loginHandler.HandleAsync(command);
        var jwt = _memoryCache.GetJwt(command.TokenId);

        return Json(jwt);
    }
}