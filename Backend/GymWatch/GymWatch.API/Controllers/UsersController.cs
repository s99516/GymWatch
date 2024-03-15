using GymWatch.API.Controllers.Abstraction;
using GymWatch.Infrastructure.DTOs;
using GymWatch.Infrastructure.IServices;
using GymWatch.Infrastructure.Requests;
using Microsoft.AspNetCore.Mvc;

namespace GymWatch.API.Controllers;

public class UsersController : ApiControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserByIdAsync(int id)
    {
        var response = await _userService.GetByIdAsync(id);
        
        if (response is null) return NotFound();
        return Json(response);
    }

    [HttpPost]
    public async Task<int> RegisterUserAsync([FromBody] RegisterUserRequest request)
    {
        var response = await _userService.RegisterAsync(request.Email, request.Password);

        return response;
    }
}