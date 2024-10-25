using GymWatch.Core.Domain.Models;
using GymWatch.Infrastructure.IRepositories.Abstraction;

namespace GymWatch.Infrastructure.IRepositories;

public interface ITrainingInstanceRepository : IRepository<TrainingInstance>
{
    Task<IEnumerable<TrainingInstance>> GetByUserAsync(int userId);
}