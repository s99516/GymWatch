using GymWatch.API.Controllers.Abstraction;
using GymWatch.Infrastructure.DTOs;
using GymWatch.Infrastructure.IServices;
using GymWatch.Infrastructure.Requests;
using Microsoft.AspNetCore.Mvc;

namespace GymWatch.API.Controllers;

public class TrainingInstancesController : ApiControllerBase
{
    private readonly ITrainingInstanceService _trainingInstanceService;

    public TrainingInstancesController(ITrainingInstanceService trainingInstanceService)
    {
        _trainingInstanceService = trainingInstanceService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(int id)
    {
        var result = await _trainingInstanceService.GetByIdAsync(id);
        if (result == null) return NotFound();
        return Json(result);
    }

    [HttpGet("by-user/{userId}")]
    public async Task<IActionResult> GetBuUserAsync(int userId)
    {
        var result = await _trainingInstanceService.GetByUserAsync(userId);
        return Json(result);
    }


    [HttpPost]
    public async Task<IActionResult> AddTrainingInstanceAsync([FromBody] CreateTrainingInstanceRequest request)
    {
        var result = await _trainingInstanceService.AddTrainingInstanceAsync(request);
        return Json(result);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> FinishTrainingInstanceAsync(int id)
    {
        await _trainingInstanceService.FinishTrainingInstanceAsync(id);
        return Ok();
    }
    
}