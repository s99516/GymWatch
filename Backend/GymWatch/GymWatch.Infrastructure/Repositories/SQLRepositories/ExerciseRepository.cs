using GymWatch.Core.Domain.Models;
using GymWatch.Infrastructure.DTOs;
using GymWatch.Infrastructure.EF;
using GymWatch.Infrastructure.IRepositories;
using GymWatch.Infrastructure.IRepositories.Abstraction;
using GymWatch.Infrastructure.Requests;
using Microsoft.EntityFrameworkCore;

namespace GymWatch.Infrastructure.Repositories.SQLRepositories;

public class ExerciseRepository : Repository<Exercise>, IExerciseRepository
{
    private readonly GymWatchDbContext _context;

    public ExerciseRepository(GymWatchDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Exercise>> GetDefaultExercisesAsync()
    {
        return await _context.Exercises.Where(x => !x.IsCustom && !x.IsDeleted).ToListAsync();
    }

    public async Task<IEnumerable<Exercise>> GetUserCustomExercisesAsync(int userId)
    {
        return await _context.Exercises.Where(x => x.UserId == userId && x.IsCustom && !x.IsDeleted).ToListAsync();
    }
}