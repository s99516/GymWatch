using System.Data;
using FluentValidation;
using GymWatch.Core.Domain.Models;
using GymWatch.Infrastructure.DTOs;
using GymWatch.Infrastructure.IRepositories;
using GymWatch.Infrastructure.IServices;
using GymWatch.Infrastructure.Mappers;
using GymWatch.Infrastructure.Validators;

namespace GymWatch.Infrastructure.Services;

public class ExerciseService : IExerciseService
{
    private readonly IUserRepository _userRepository;
    private readonly IExerciseRepository _exerciseRepository;
    private readonly ExerciseValidator _exerciseValidator;

    public ExerciseService(IUserRepository userRepository, IExerciseRepository exerciseRepository, ExerciseValidator exerciseValidator)
    {
        _userRepository = userRepository;
        _exerciseRepository = exerciseRepository;
        _exerciseValidator = exerciseValidator;
    }

    public async Task<ExerciseDto> CreateCustomExerciseAsync(CreateOrUpdateExerciseDto request)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);
        var exercise = new Exercise(request.Name, request.Description, request.BodyPart, true, user);

        await _exerciseValidator.ValidateAndThrowAsync(exercise);
        
        await _exerciseRepository.AddAsync(exercise);
        await _userRepository.SaveChangesAsync();
        
        return exercise.ToDto();
    }

    public async Task<ExerciseDto?> UpdateCustomExerciseAsync(CreateOrUpdateExerciseDto request)
    {
        var exercise = await _exerciseRepository.GetByIdAsync(request.Id);
        
        exercise?.Update(request.Name, request.Description, request.BodyPart);
        
        if (exercise is not null)   await _exerciseValidator.ValidateAndThrowAsync(exercise);
        
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