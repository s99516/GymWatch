using GymWatch.Core.Domain.Models;
using GymWatch.Infrastructure.DTOs;
using GymWatch.Infrastructure.IRepositories;
using GymWatch.Infrastructure.IServices;
using GymWatch.Infrastructure.Mappers;
using GymWatch.Infrastructure.Requests;

namespace GymWatch.Infrastructure.Services;

public class TrainingInstanceService : ITrainingInstanceService
{
    private readonly ITrainingInstanceRepository _trainingInstanceRepository;
    private readonly IUserRepository _userRepository;

    public TrainingInstanceService(ITrainingInstanceRepository trainingInstanceRepository, IUserRepository userRepository)
    {
        _trainingInstanceRepository = trainingInstanceRepository;
        _userRepository = userRepository;
    }

    public async Task<TrainingInstanceDto?> GetByIdAsync(int id)
    {
        var trainingInstance = await _trainingInstanceRepository.GetByIdAsync(id);
        
        return trainingInstance?.ToDto();
    }

    public async Task<IEnumerable<TrainingInstanceDto>> GetByUserAsync(int userId)
    {
        var trainingInstances = await _trainingInstanceRepository.GetByUserAsync(userId);

        return trainingInstances.ToDtoList();
    }

    public async Task<TrainingInstanceDto> CreateTrainingInstanceAsync(CreateTrainingInstanceRequest request)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);
        
        var trainingInstance = new TrainingInstance(request.Name, request.BodyWeight, request.State, user);

        await _trainingInstanceRepository.AddAsync(trainingInstance);
        await _trainingInstanceRepository.SaveChangesAsync();
        
        return trainingInstance.ToDto();
    }

    public async Task<int?> FinishTrainingInstanceAsync(int id)
    {
        var trainingInstance = await _trainingInstanceRepository.GetByIdAsync(id);
        
        trainingInstance?.Finish();
        
        await _trainingInstanceRepository.SaveChangesAsync();
        
        return trainingInstance?.Id;
    }
}