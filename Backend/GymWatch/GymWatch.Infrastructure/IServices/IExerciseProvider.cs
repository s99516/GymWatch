using GymWatch.Infrastructure.DTOs;

namespace GymWatch.Infrastructure.IServices;

public interface IExerciseProvider
{
    Task<List<ExerciseDto>> GetDefaultExercisesAsync();
    Task<List<ExerciseDto>> GetUserCustomExercisesAsync(int userId);
    Task<List<ExerciseDto>> GetExercisesWithUserCustomExercisesAsync(int userId);
}