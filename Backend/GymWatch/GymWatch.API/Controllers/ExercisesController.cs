using GymWatch.API.Controllers.Abstraction;
using GymWatch.Core.Domain.Models;
using GymWatch.Infrastructure.DTOs;
using GymWatch.Infrastructure.IServices;
using GymWatch.Infrastructure.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymWatch.API.Controllers;

public class ExercisesController : ApiControllerBase
{
    private readonly IExerciseProvider _exerciseProvider;
    private readonly IExerciseService _exerciseService;

    public ExercisesController(IExerciseProvider exerciseProvider, IExerciseService exerciseService)
    {
        _exerciseProvider = exerciseProvider;
        _exerciseService = exerciseService;
    }
    
    [HttpGet]
    public async Task<List<ExerciseDto>> GetDefaultExercisesAsync()
    {
        var response = await _exerciseProvider.GetDefaultExercisesAsync();
        return response;
    }
    
    [HttpGet("user-exercises/{userId}")]
    public async Task<List<ExerciseDto>> GetUserCustomExercisesAsync(int userId)
    {
        var response = await _exerciseProvider.GetUserCustomExercisesAsync(userId);
        return response;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomExerciseAsync([FromBody] CreateOrUpdateExerciseDto request)
    {
        var response = await _exerciseService.CreateCustomExerciseAsync(request);
        return Ok(response);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateCustomExerciseAsync([FromBody] CreateOrUpdateExerciseDto request)
    {
        var response = await _exerciseService.UpdateCustomExerciseAsync(request);
        return  response is not null ? Ok(response) : NotFound();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomExerciseAsync(int id)
    {
        var response = await _exerciseService.DeleteCustomExerciseAsync(id);
        return  response is not null ? Ok(response) : NotFound();
    }
}