using GymWatch.Infrastructure.DTOs;
using GymWatch.Infrastructure.IRepositories;
using GymWatch.Infrastructure.IServices;
using GymWatch.Infrastructure.Mappers;

namespace GymWatch.Infrastructure.Services;

public class ExerciseProvider : IExerciseProvider
{
    private readonly IExerciseRepository _exerciseRepository;

    public ExerciseProvider(IExerciseRepository exerciseRepository)
    {
        _exerciseRepository = exerciseRepository;
    }

    public async Task<List<ExerciseDto>> GetDefaultExercisesAsync()
    {
        var exercises = await _exerciseRepository.GetDefaultExercisesAsync();
        
        var result = exercises.ToDtoList();
        return result;
    }

    public async Task<List<ExerciseDto>> GetUserCustomExercisesAsync(int userId)
    {
        var exercises = await _exerciseRepository.GetUserCustomExercisesAsync(userId);
        
        var result = exercises.ToDtoList();
        return result;
    }

    public async Task<List<ExerciseDto>> GetExercisesWithUserCustomExercisesAsync(int userId)
    {
        var defaultExercises = await _exerciseRepository.GetDefaultExercisesAsync();
        var userCustomExercises = await _exerciseRepository.GetUserCustomExercisesAsync(userId);

        var result = defaultExercises.Concat(userCustomExercises).
            ToDtoList();

        return result;
    }
}