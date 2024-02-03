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
        
        var result = trainingInstance?.ToDto();
        return result;
    }

    public async Task<IEnumerable<TrainingInstanceDto>> GetByUserAsync(int userId)
    {
        var trainingInstances = await _trainingInstanceRepository.GetByUserAsync(userId);
        
        var result = trainingInstances.ToDtoList();
        return result;
    }

    public async Task<int> AddTrainingInstanceAsync(CreateTrainingInstanceRequest request)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);

        if (user == null)
            throw new Exception($"Cannot find user with id: {request.UserId} to create training instance");
        
        var trainingInstance = new TrainingInstance(request.Name, request.BodyWeight, request.State, user);
        var id = await _trainingInstanceRepository.AddAsync(trainingInstance);
        return id;
    }

    public async Task FinishTrainingInstanceAsync(int id)
    {
        await _trainingInstanceRepository.FinishTrainingInstanceAsync(id);
    }
}