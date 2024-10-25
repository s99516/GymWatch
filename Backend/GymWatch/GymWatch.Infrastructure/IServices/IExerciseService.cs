using GymWatch.Infrastructure.DTOs;
using GymWatch.Infrastructure.Requests;

namespace GymWatch.Infrastructure.IServices;

public interface IExerciseService
{
    Task<ExerciseDto> CreateCustomExerciseAsync(CreateOrUpdateExerciseDto request);
    Task<ExerciseDto?> UpdateCustomExerciseAsync(CreateOrUpdateExerciseDto request);
    Task<int?> DeleteCustomExerciseAsync(int id);
}