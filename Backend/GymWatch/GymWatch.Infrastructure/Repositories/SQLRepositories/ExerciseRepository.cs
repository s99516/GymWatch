using GymWatch.Core.Domain.Models;
using GymWatch.Infrastructure.EF;
using GymWatch.Infrastructure.IRepositories;
using GymWatch.Infrastructure.Requests;
using Microsoft.EntityFrameworkCore;

namespace GymWatch.Infrastructure.Repositories.SQLRepositories;

public class ExerciseRepository : IExerciseRepository
{
    private readonly GymWatchDbContext _context;

    public ExerciseRepository(GymWatchDbContext context)
    {
        _context = context;
    }
    
    public async Task<Exercise?> GetByIdAsync(int id)
    {
        var result = await _context.Exercises.FirstOrDefaultAsync(x => x.Equals(id));
        return result;
    }

    public async Task<IEnumerable<Exercise>> GetDefaultExercisesAsync()
    {
        var result = await _context.Exercises.Where(x => !x.IsCustom).ToListAsync();
        return result;
    }

    public async Task<IEnumerable<Exercise>> GetUserCustomExercisesAsync(int userId)
    {
        var result = await _context.Exercises.Where(x => x.IsCustom && x.UserId.Equals(userId)).ToListAsync();
        return result;
    }

    public async Task<int> AddAsync(Exercise exercise)
    {
        var entry = await _context.Exercises.AddAsync(exercise);
        await _context.SaveChangesAsync();

        return entry.Entity.Id;
    }

    public async Task<int> EditAsync(EditCustomExerciseRequest request)
    {
        var exercise = await GetByIdAsync(request.Id);

        if (exercise is null) throw new Exception($"Cannot find exercise with id {request.Id} to update");
        
        exercise.Update(request.Name, request.Description);
        
        await _context.SaveChangesAsync();
        
        return exercise.Id;
    }

    public async Task DeleteAsync(int id)
    {
        var exercise = await _context.Exercises.FirstOrDefaultAsync(x => x.Id.Equals(id));

        if (exercise is null) throw new Exception($"Cannot find exercise with id {id} to delete");

        _context.Exercises.Remove(exercise);

        await _context.SaveChangesAsync();
    }
}