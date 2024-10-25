using System.Data;
using GymWatch.Core.Domain.Models;
using GymWatch.Infrastructure.DTOs;
using GymWatch.Infrastructure.IRepositories;
using GymWatch.Infrastructure.IServices;
using GymWatch.Infrastructure.Mappers;

namespace GymWatch.Infrastructure.Services;

public class ExerciseService : IExerciseService
{
    private readonly IUserRepository _userRepository;
    private readonly IExerciseRepository _exerciseRepository;

    public ExerciseService(IUserRepository userRepository, IExerciseRepository exerciseRepository)
    {
        _userRepository = userRepository;
        _exerciseRepository = exerciseRepository;
    }

    public async Task<ExerciseDto> CreateCustomExerciseAsync(CreateOrUpdateExerciseDto request)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);
        var exercise = new Exercise(request.Name, request.Description, request.BodyPart, true, user);
        
        await _exerciseRepository.AddAsync(exercise);
        await _userRepository.SaveChangesAsync();
        
        return exercise.ToDto();
    }

    public async Task<ExerciseDto?> UpdateCustomExerciseAsync(CreateOrUpdateExerciseDto request)
    {
        var exercise = await _exerciseRepository.GetByIdAsync(request.Id);
        
        exercise?.Update(request.Name, request.Description, request.BodyPart);
        
        await _exerciseRepository.SaveChangesAsync();
        
        return exercise?.ToDto();
    }

    public async Task<int?> DeleteCustomExerciseAsync(int id)
    {
        var exercise = await _exerciseRepository.GetByIdAsync(id);
        
        exercise?.Delete();
        
        await _exerciseRepository.SaveChangesAsync();
        
        return exercise?.Id;
    }
}