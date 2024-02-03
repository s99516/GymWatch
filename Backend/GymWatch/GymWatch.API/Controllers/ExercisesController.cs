using GymWatch.API.Controllers.Abstraction;
using GymWatch.Core.Domain.Models;
using GymWatch.Infrastructure.DTOs;
using GymWatch.Infrastructure.IServices;
using GymWatch.Infrastructure.Requests;
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
    public async Task<int> AddCustomExerciseAsync([FromBody] CreateCustomExerciseRequest request)
    {
        var response = await _exerciseService.AddCustomExercise(request);
        return response;
    }
    
    [HttpPut]
    public async Task<int> EditCustomExerciseAsync([FromBody] EditCustomExerciseRequest request)
    {
        var response = await _exerciseService.EditCustomExercise(request);
        return response;
    }

    [HttpDelete("{id}")]
    public async Task DeleteCustomExerciseAsync(int id)
    {
        await _exerciseService.DeleteCustomExerciseAsync(id);
    }
}