using System.Data;
using GymWatch.Core.Domain.Models;
using GymWatch.Infrastructure.IRepositories;
using GymWatch.Infrastructure.Requests;

namespace GymWatch.Infrastructure.Repositories.InMemoryRepositories;

public class InMemoryExerciseRepository : IExerciseRepository
{
    private List<Exercise> Exercises = new()
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

    public async Task<Exercise?> GetByIdAsync(int id)
    {
        return await Task.FromResult(Exercises.Where(x => x.Id == id).FirstOrDefault());
    }

    public async Task<IEnumerable<Exercise>> GetDefaultExercisesAsync()
    {
        return  await Task.FromResult(Exercises.Where(x => !x.IsCustom).ToList());
    }

    public async Task<IEnumerable<Exercise>> GetUserCustomExercisesAsync(int userId)
    {
        return await Task.FromResult(Exercises.Where(x => x.IsCustom && x.UserId == userId).ToList());
    }

    public async Task<int> AddAsync(Exercise exercise)
    {
        var lastId = Exercises.LastOrDefault()?.Id;
        exercise.Id = (lastId ?? 0) + 1;
        Exercises.Add(exercise);
        
        return await Task.FromResult(exercise.Id);
    }

    public async Task<int> EditAsync(EditCustomExerciseRequest request)
    {
        var entity = await GetByIdAsync(request.Id);

        if (entity == null) throw new Exception($"Cannot find exercise with id {request.Id} to process update");

        entity.Update(request.Name, request.Description);
        return entity.Id;
    }

    public async Task DeleteAsync(int id)
    {
        Exercises = Exercises.Where(x => x.Id != id && x.IsCustom).ToList();
    }
}