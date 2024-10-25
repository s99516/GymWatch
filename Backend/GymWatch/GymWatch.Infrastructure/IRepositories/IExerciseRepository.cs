using GymWatch.Core.Domain.Models;
using GymWatch.Infrastructure.DTOs;
using GymWatch.Infrastructure.IRepositories.Abstraction;
using GymWatch.Infrastructure.Requests;

namespace GymWatch.Infrastructure.IRepositories;

public interface IExerciseRepository : IRepository<Exercise>
{
    Task<IEnumerable<Exercise>> GetDefaultExercisesAsync();
    Task<IEnumerable<Exercise>> GetUserCustomExercisesAsync(int userId);
}