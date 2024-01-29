using GymWatch.Core.Domain.Models;
using GymWatch.Infrastructure.IRepositories;

namespace GymWatch.Infrastructure.Repositories.InMemoryRepositories;

public class InMemoryExerciseRepository : IExerciseRepository
{
    public List<Exercise> Exercises = new()
    {
        new Exercise("Deadlift", "Description deadlift", false)
        {
            Id = 1
        },
        new Exercise("Benchpress", "Description benchpress", false)
        {
            Id = 2
        },
        new Exercise("Squad", "Description squad", false)
        {
            Id = 3
        },
        new Exercise("Custom", "Custom squad", true)
        {
            Id = 4,
            UserId = 1
        },
    };
    
    public async Task<IEnumerable<Exercise>> GetDefaultExercisesAsync()
    {
        return  await Task.FromResult(Exercises.Where(x => !x.IsCustom).ToList());
    }

    public async Task<IEnumerable<Exercise>> GetUserCustomExercisesAsync(int userId)
    {
        return await Task.FromResult(Exercises.Where(x => x.IsCustom && x.UserId == userId).ToList());
    }
}