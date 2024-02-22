using GymWatch.Core.Domain.Models;
using GymWatch.Infrastructure.EF;
using GymWatch.Infrastructure.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace GymWatch.Infrastructure.Repositories.SQLRepositories;

public class TrainingInstanceRepository : ITrainingInstanceRepository
{
    private GymWatchDbContext _context;

    public TrainingInstanceRepository(GymWatchDbContext context)
    {
        _context = context;
    }
    public async Task<TrainingInstance?> GetByIdAsync(int id)
    {
        var result = await _context.TrainingInstances.FirstOrDefaultAsync(x => x.Id.Equals(id));
        return result;
    }

    public async Task<IEnumerable<TrainingInstance>> GetByUserAsync(int userId)
    {
        var result = await _context.TrainingInstances.Where(x => x.UserId.Equals(userId)).ToListAsync();
        return result;
    }

    public async Task<int> AddAsync(TrainingInstance trainingInstance)
    {
        await _context.TrainingInstances.AddAsync(trainingInstance);
        await _context.SaveChangesAsync();
        return trainingInstance.Id;
    }

    public async Task FinishTrainingInstanceAsync(int id)
    {
        var trainingInstance = await GetByIdAsync(id);
        trainingInstance?.EndTrainingInstance();
        
        await _context.SaveChangesAsync();
    }
}