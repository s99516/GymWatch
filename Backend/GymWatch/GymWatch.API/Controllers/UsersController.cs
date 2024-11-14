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
    public async Task<UserDto> RegisterUserAsync([FromBody] RegisterUserRequest request)
    {
        var response = await _userService.RegisterAsync(request.Email, request.Password);
        return response;
    }

    [HttpPut]
    public async Task<UserDto> UpdateUserAsync([FromBody] UpdateUserRequest request)
    {
        var response = await _userService.UpdateUserAsync(request.Id, request.Email, request.Password);
        return response;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var response = await _userService.DeleteAsync(id);
        return response is not null ? Ok(response) : NotFound();
    }
}