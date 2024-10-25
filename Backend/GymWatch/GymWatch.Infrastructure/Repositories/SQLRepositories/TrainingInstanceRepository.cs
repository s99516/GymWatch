using GymWatch.Core.Domain.Models;
using GymWatch.Infrastructure.EF;
using GymWatch.Infrastructure.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace GymWatch.Infrastructure.Repositories.SQLRepositories;

public class TrainingInstanceRepository  : Repository<TrainingInstance>, ITrainingInstanceRepository
{
    private GymWatchDbContext _context;

    public TrainingInstanceRepository(GymWatchDbContext context) : base(context)
    {
        _context = context;
    }
    public async Task<TrainingInstance?> GetByIdAsync(int id)
    {
        var result = await _context.TrainingInstances.FirstOrDefaultAsync(x => x.Id.Equals(id));
        return result;
    }

    public async Task<TrainingInstance> CreateAsync(TrainingInstance trainingInstance)
    {
        var entry = await _context.TrainingInstances.AddAsync(trainingInstance);
        await _context.SaveChangesAsync();
        
        return entry.Entity;
    }

    public async Task<IEnumerable<TrainingInstance>> GetByUserAsync(int userId)
    {
        return await _context.TrainingInstances.Where(x => x.UserId.Equals(userId)).ToListAsync();
    }
}