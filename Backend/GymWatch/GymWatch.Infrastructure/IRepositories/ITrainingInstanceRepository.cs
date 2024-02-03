using GymWatch.Core.Domain.Models;

namespace GymWatch.Infrastructure.IRepositories;

public interface ITrainingInstanceRepository
{
    Task<TrainingInstance> GetByIdAsync(int id);
    Task<IEnumerable<TrainingInstance>> GetByUserAsync(int userId);
    Task<int> AddAsync(TrainingInstance trainingInstance);
    Task FinishTrainingInstanceAsync(int id);
}