using GymWatch.Core.Domain.Models;

namespace GymWatch.Infrastructure.IRepositories;

public interface IExerciseRepository
{
    Task<IEnumerable<Exercise>> GetDefaultExercisesAsync();
    Task<IEnumerable<Exercise>> GetUserCustomExercisesAsync(int userId);
}