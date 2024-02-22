using GymWatch.Core.Domain.Models;
using GymWatch.Infrastructure.IRepositories.Abstraction;

namespace GymWatch.Infrastructure.IRepositories;

public interface ITrainingInstanceRepository : IRepository<TrainingInstance>
{
    Task<TrainingInstance?> GetByIdAsync(int id);
    Task<IEnumerable<TrainingInstance>> GetByUserAsync(int userId);
    Task<int> AddAsync(TrainingInstance trainingInstance);
    Task FinishTrainingInstanceAsync(int id);
}