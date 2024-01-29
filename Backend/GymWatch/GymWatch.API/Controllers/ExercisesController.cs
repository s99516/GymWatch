using GymWatch.API.Controllers.Abstraction;
using GymWatch.Infrastructure.DTOs;
using GymWatch.Infrastructure.IServices;
using Microsoft.AspNetCore.Mvc;

namespace GymWatch.API.Controllers;

public class ExercisesController : ApiControllerBase
{
    private readonly IExerciseProvider _exerciseProvider;

    public ExercisesController(IExerciseProvider exerciseProvider)
    {
        _exerciseProvider = exerciseProvider;
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
}