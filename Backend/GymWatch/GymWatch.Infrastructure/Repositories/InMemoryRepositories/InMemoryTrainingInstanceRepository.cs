using GymWatch.Core.Domain.Enums;
using GymWatch.Core.Domain.Models;
using GymWatch.Infrastructure.IRepositories;

namespace GymWatch.Infrastructure.Repositories.InMemoryRepositories;

public class InMemoryTrainingInstanceRepository : ITrainingInstanceRepository
{
    private List<TrainingInstance> TrainingInstances = new()
    {
        new TrainingInstance("Name 1", 70, TrainingState.Ended, new User { Id = 1})
        {
            Id = 1,
            UserId = 1
        },
        new TrainingInstance("Name 2", 72, TrainingState.Ended, new User { Id = 1})
        {
            Id = 2,
            UserId = 1
        },
        new TrainingInstance("Name 3", 72.4, TrainingState.Ended, new User { Id = 2})
        {
            Id = 3,
            UserId = 2
        },
        new TrainingInstance("Name 4", 72.8, TrainingState.Active, new User { Id = 2})
        {
            Id = 4,
            UserId = 2
        },
    };
    
    public async Task<TrainingInstance?> GetByIdAsync(int id)
    {
        var trainingInstance = await Task.FromResult(TrainingInstances.Where(x => x.Id == id).FirstOrDefault());
        return trainingInstance;
    }

    public async Task<IEnumerable<TrainingInstance>> GetByUserAsync(int userId)
    {
        var trainingInstance = await Task.FromResult(TrainingInstances.Where(x => x.UserId == userId).ToList());
        return trainingInstance;
    }

    public async Task<int> AddAsync(TrainingInstance trainingInstance)
    {
        var lastId = TrainingInstances.LastOrDefault()?.Id;
        trainingInstance.Id = (lastId ?? 0) + 1;
        TrainingInstances.Add(trainingInstance);
        
        return await Task.FromResult(trainingInstance.Id);
    }

    public async Task FinishTrainingInstanceAsync(int id)
    {
        var trainingInstance = await Task.FromResult(TrainingInstances.Where(x => x.Id == id).FirstOrDefault());

        if (trainingInstance == null)
            throw new Exception($"Cannot find training instance with id {id} to process finish instance");
        
        trainingInstance.EndTrainingInstance();
    }
}